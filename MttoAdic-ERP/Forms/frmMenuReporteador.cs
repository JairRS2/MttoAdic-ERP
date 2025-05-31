using MttoAdic_ERP.Models;
using Syncfusion.GridExcelConverter;
using Syncfusion.GridHelperClasses;
using Syncfusion.Grouping;
using Syncfusion.GroupingGridExcelConverter;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Windows.Forms.Tools;
using System.Data;
using System.Data.OleDb;

namespace MttoAdic_ERP
{
    public partial class frmMenuReporteador : Form
    {
        private string tabSeleccionada = string.Empty;
        string strAlmacen = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\srv2kas\\Base Datos Administra_R\\Almacen.mdb;Jet OLEDB:Database Password=a9TnX13HHOo;";
        string strTesoreria = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\srv2kas\\Base Datos Administra_R\\Tesoreria.mdb;Jet OLEDB:Database Password=a9TnX13HHOo;";
        string strServicios = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\srv2kas\\Base Datos Servicios\\bdServicios.mdb;Jet OLEDB:Database Password=a9TnX13HHOo;";
        string strMantto = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\srv2kas\\Base Datos Adic_R\\Mantenimiento.mdb";
        string strLlantas = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\srv2kas\\Base Datos Llantas\\AlmacenLlantas.mdb;Jet OLEDB:Database Password=a9TnX13HHOo;";
        string strAlmacenCP = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\srv2kas\\Base Datos Administra Foraneas\\AlmacenCP.mdb;Jet OLEDB:Database Password=a9TnX13HHOo;";
        csConexionSQL csConex2 = new csConexionSQL("saaadic30ga.ddns.net", "dbBitacoras", "xhodaraoz", "XmaiN16xDt@@MA");
        csConexionSQL csConex = new csConexionSQL("cadic.ddns.net", "dbDiesel", "xhodaraoz", "XmaiN16xDt@@MA");
        string SQL = string.Empty;

        public frmMenuReporteador()
        {
            InitializeComponent();
            ggcDevolucionVale.GridGroupDropArea.DragColumnHeaderText = "Arrastre el campo para agrupar";
            ggcVales.GridGroupDropArea.DragColumnHeaderText = "Arrastre el campo para agrupar";
            ggcCompras.GridGroupDropArea.DragColumnHeaderText = "Arrastre el campo para agrupar";
            ggcLlantas.GridGroupDropArea.DragColumnHeaderText = "Arrastre el campo para agrupar";
            ggcComprasLLantas.GridGroupDropArea.DragColumnHeaderText = "Arrastre el campo para agrupar";
            ggcDiesel.GridGroupDropArea.DragColumnHeaderText = "Arrastre el campo para agrupar";
        }

        private void frmReporteadorMenu_Load(object sender, EventArgs e)
        {
            tabReporteador.Alignment = TabAlignment.Left;
            tabReporteador.TabStyle = typeof(TabRendererMetro);
            tabReporteador.BorderVisible = true;
            tabReporteador.VSLikeScrollButton = true;
            tabReporteador.Alignment = TabAlignment.Left;
            tabReporteador.TextAlignment = StringAlignment.Far;
            tabReporteador.TextLineAlignment = StringAlignment.Near;
            tabSeleccionada = tabReporteador.SelectedTab.Text;
        }

        private void cargaDatos()
        {
            DateTime dDesde = dtpDesde.Value;
            DateTime dHasta = dtpHasta.Value;

            if (tabSeleccionada == "Compras")
            {
                try
                {
                    int PorcCompras = 0;
                    int MaxCompras = 0;

                    List<OrdenCompra> lstDatos = new List<OrdenCompra>();

                    #region Almacen
                    DataTable dtCompras = new DataTable();
                    using (OleDbConnection connectionAlm = new OleDbConnection(strAlmacen))
                    {
                        connectionAlm.Open();

                        SQL = "select ord.nNumOrd as Orden,IIF(ord.nCveEmp=1, 'APV', " +
                            "IIF(ord.nCveEmp=2, 'EA', IIF(ord.nCveEmp=3, 'OCS', " +
                            "IIF(ord.nCveEmp=6, 'OFG',0)))) As Empresa, ord.cPrvOrd as Clave_Proveedor," +
                            "'Proveedor' as Proveedor, dFecOrd as FechaOrden, IIF(ord.nEdoOrd=1,'EMITIDO'," +
                            "IIF(ord.nEdoOrd=2,'ENTREGADO',IIF(ord.nEdoOrd=3,'CANCELADO'," +
                            "IIF(ord.nEdoOrd=4,'TRASPASO',IIF(ord.nEdoOrd=5,'DEVUELTO',0))))) as Estado_Orden, " +
                            "ord.cFacOrd as Factura, ord.dFecFac as FechaFactura, " +
                            "IIF(nPgoOrd=1,'Contado','Credito') as Tipo_Pago, nCtdOrd as Cantidad, " +
                            "det.cCodPrd as Codigo, prd.cDesPrd as Producto, nCtoOrd as Costo, det.nNumPed as Pedido, " +
                            "IIF(det.nEdoOrd=1,'EMITIDO'," +
                            "IIF(det.nEdoOrd=2,'ENTREGADO',IIF(det.nEdoOrd=3,'CANCELADO'," +
                            "IIF(det.nEdoOrd=4,'TRASPASO',IIF(det.nEdoOrd=5,'DEVUELTO',0))))) as Estado_Partida, det.nFolBit as Bitacora, lin.cDesLin as Linea, ord.cFolFis as Folio_Fiscal, 0 as nMes, '0' as Mes, 0 as Ano " +
                            "from((((orden ord inner join ordendetalle det on ord.nnumord = det.nnumord) " +
                            "inner join Productos prd on prd.cCodPrd = det.cCodPrd) " +
                            "inner join lineas lin on prd.nLinPrd=lin.nCveLin) " +
                            "left join Pedido ped on ped.nNumPed = det.nNumPed) " +
                            "Where ord.dFecFac>=#" + dDesde.ToString("MM-dd-yyyy") + "# And ord.dFecFac<=#" + dHasta.ToString("MM-dd-yyyy") + "#";

                        OleDbCommand commandCompras = new OleDbCommand(SQL, connectionAlm);

                        OleDbDataReader readerCompras = commandCompras.ExecuteReader();

                        dtCompras.Load(readerCompras);

                        connectionAlm.Close();

                        foreach (DataColumn col in dtCompras.Columns)
                            col.ReadOnly = false;

                        MaxCompras = dtCompras.Rows.Count;
                        PorcCompras = 0;
                        pbReportes.Maximum = MaxCompras;
                        pbReportes.Minimum = 0;
                        pbReportes.Value = PorcCompras;

                        foreach (DataRow item in dtCompras.Rows)
                        {
                            int no_Orden = Convert.ToInt32(item["Orden"]);
                            string codigo = item["Codigo"].ToString()!;
                            int pedido = 0;
                            if (item["Pedido"] != null)
                            {
                                pedido = Convert.ToInt32(item["Pedido"]);
                            }
                            DateTime dFechaOrden = DateTime.Parse(item["FechaOrden"].ToString()!);
                            DateTime dFechaFactura = DateTime.Parse(item["FechaFactura"].ToString()!);
                            int nmes = Convert.ToInt32(dFechaFactura.ToString("MM"));
                            item["nMes"] = nmes;
                            string mes = dFechaFactura.ToString("MMMM");
                            item["Mes"] = mes;
                            int ano = Convert.ToInt32(dFechaFactura.ToString("yyyy"));
                            item["Ano"] = ano;

                            string cCvePro = item["Clave_Proveedor"].ToString()!;
                            string qryProv = "select cDesCon From conc2 where ccuecon='" + cCvePro + "'";

                            using (OleDbConnection connectionTeso = new OleDbConnection(strTesoreria))
                            {
                                connectionTeso.Open();

                                OleDbCommand commandProv = new OleDbCommand(qryProv, connectionTeso);

                                OleDbDataReader readerProv = commandProv.ExecuteReader();

                                DataTable dtProv = new DataTable();
                                dtProv.Load(readerProv);

                                if (dtProv.Rows.Count > 0)
                                {
                                    item["Proveedor"] = dtProv.Rows[0]["cDesCon"].ToString()!;
                                }

                                connectionTeso.Close();
                            }

                            var Orden = new OrdenCompra
                            {
                                No_Orden = no_Orden,
                                Empresa = item["Empresa"].ToString()!,
                                Clave_Proveedor = item["Clave_Proveedor"].ToString()!,
                                Proveedor = item["Proveedor"].ToString()!,
                                Fecha_Orden = dFechaOrden.ToString("dd/MM/yyyy"),
                                Estado_Orden = item["Estado_Orden"].ToString()!,
                                Factura = item["Factura"].ToString()!,
                                Fecha_Factura = dFechaFactura.ToString("dd/MM/yyyy"),
                                Tipo_Pago = item["Tipo_Pago"].ToString()!,
                                Cantidad = Convert.ToDecimal(item["Cantidad"]),
                                Codigo = item["Codigo"].ToString()!,
                                Producto = item["Producto"].ToString()!,
                                Costo = Convert.ToDecimal(item["Costo"]),
                                Pedido = pedido,
                                Estado_Partida = item["Estado_Partida"].ToString()!,
                                Bitacora = Convert.ToInt32(item["Bitacora"]),
                                nMes = nmes,
                                Mes = mes,
                                Ano = ano,
                                Tipo = "Almacen",
                                Linea = item["Linea"].ToString()!,
                                Folio_Fiscal = item["Folio_Fiscal"].ToString()!
                            };

                            lstDatos.Add(Orden);

                            PorcCompras += 1;
                            pbReportes.Value = PorcCompras;
                        }
                    }
                    #endregion

                    #region Externos
                    using (OleDbConnection connectionExt = new OleDbConnection(strServicios))
                    {
                        connectionExt.Open();

                        string qryExt = "Select ord.nNumOrd as Orden,IIF(ord.nCveEmp=1, 'APV',IIF(ord.nCveEmp=2, 'EA', IIF(ord.nCveEmp=3, " +
                            "'OCS', IIF(ord.nCveEmp=6, 'OFG',0)))) As Empresa, det.cCvePrv as Clave_Proveedor, " +
                            "'Proveedor' as Proveedor, dFecOrd as Fecha_Orden, IIF(ord.nEdoOrd = 0, 'EMITIDO', " +
                            "IIF(ord.nEdoOrd = 1, 'ENTREGADO', IIF(ord.nEdoOrd = 2, 'CANCELADO', 0))) as Estado_Orden, " +
                            "ord.sFacOrd as Factura, ord.dFecFac as Fecha_Factura, ord.nTipoPago as Tipo_Pago, " +
                            "det.nCantSrv as Cantidad, det.nIdServicio as Codigo, ser.sDescripcionSvr as Producto, " +
                            "det.nCostoSrv as Costo, ord.nNumPedido as Pedido, 'Entregado' as Estado_Partida, " +
                            "ped.nFolioBit as Bitacora, ord.cFolFis as Folio_Fiscal from(((tbOrdenServicio ord " +
                            "inner join tbDetalleOrden det on ord.nNumOrd = det.nNumOrd) " +
                            "left join tbPedidos ped on ord.nNumPedido = ped.nNumPedido) " +
                            "inner join tbServicios ser on det.nIdServicio = ser.nIdServicio) " +
                            "Where ord.dFecFac>=#" + dDesde.ToString("MM-dd-yyyy") + "# And ord.dFecFac<=#" + dHasta.ToString("MM-dd-yyyy") + "#";

                        OleDbCommand commandExt = new OleDbCommand(qryExt, connectionExt);

                        OleDbDataReader readerExt = commandExt.ExecuteReader();

                        DataTable dtExt = new DataTable();
                        dtExt.Load(readerExt);

                        MaxCompras = dtExt.Rows.Count;
                        PorcCompras = 0;
                        pbReportes.Maximum = MaxCompras;
                        pbReportes.Minimum = 0;
                        pbReportes.Value = PorcCompras;

                        foreach (DataRow item in dtExt.Rows)
                        {
                            try
                            {
                                if (item["Orden"] == null)
                                { }
                                int no_Orden = Convert.ToInt32(item["Orden"]);
                                string codigo = item["Codigo"].ToString()!;
                                int pedido = 0;
                                if (item["Pedido"] != null)
                                {
                                    pedido = Convert.ToInt32(item["Pedido"]);
                                }

                                DateTime dFechaOrden = DateTime.Parse(item["Fecha_Orden"].ToString()!);
                                DateTime dFechaFactura = DateTime.Parse(item["Fecha_Factura"].ToString()!);
                                int nmes = Convert.ToInt32(dFechaFactura.ToString("MM"));
                                string mes = dFechaFactura.ToString("MMMM");
                                int ano = Convert.ToInt32(dFechaFactura.ToString("yyyy"));

                                string cCvePro = item["Clave_Proveedor"].ToString()!;
                                string Proveedor = "Proveedor";

                                string qryProv = "select cDesCon From conc2 where ccuecon='" + cCvePro + "'";

                                using (OleDbConnection connectionTeso = new OleDbConnection(strTesoreria))
                                {
                                    connectionTeso.Open();

                                    OleDbCommand commandProv = new OleDbCommand(qryProv, connectionTeso);

                                    OleDbDataReader readerProv = commandProv.ExecuteReader();

                                    DataTable dtProv = new DataTable();
                                    dtProv.Load(readerProv);

                                    if (dtProv.Rows.Count > 0)
                                    {
                                        Proveedor = dtProv.Rows[0]["cDesCon"].ToString()!;
                                    }
                                    else
                                    {
                                    }
                                }

                                int nBit = 0;

                                if (item["Bitacora"] != null && item["Bitacora"].ToString() != "")
                                {
                                    nBit = Convert.ToInt32(item["Bitacora"]);
                                }

                                decimal nCan = 0;

                                if (item["Cantidad"] != null)
                                {
                                    nCan = Convert.ToDecimal(item["Cantidad"]);
                                }

                                decimal nCos = 0;

                                if (item["Costo"] != null)
                                {
                                    nCos = Convert.ToDecimal(item["Costo"]);
                                }

                                string Folio_Fiscal = item["Folio_Fiscal"].ToString()!;

                                var Orden = new OrdenCompra
                                {
                                    No_Orden = no_Orden,
                                    Empresa = item["Empresa"].ToString()!,
                                    Clave_Proveedor = item["Clave_Proveedor"].ToString()!,
                                    Proveedor = Proveedor,
                                    Fecha_Orden = dFechaOrden.ToString("dd/MM/yyyy"),
                                    Estado_Orden = item["Estado_Orden"].ToString()!,
                                    Factura = item["Factura"].ToString()!,
                                    Fecha_Factura = dFechaFactura.ToString("dd/MM/yyyy"),
                                    Tipo_Pago = item["Tipo_Pago"].ToString()!,
                                    Cantidad = nCan,
                                    Codigo = item["Codigo"].ToString()!,
                                    Producto = item["Producto"].ToString()!,
                                    Costo = nCos,
                                    Pedido = pedido,
                                    Estado_Partida = item["Estado_Partida"].ToString()!,
                                    Bitacora = nBit,
                                    nMes = nmes,
                                    Mes = mes,
                                    Ano = ano,
                                    Tipo = "Externo",
                                    Linea = "Externo",
                                    Folio_Fiscal = Folio_Fiscal
                                };
                                lstDatos.Add(Orden);
                            }
                            catch (Exception ex)
                            {
                            }
                            PorcCompras += 1;
                            pbReportes.Value = PorcCompras;
                        }
                    }
                    #endregion Externos

                    ggcCompras.DataSource = null;
                    ggcCompras.DataSource = lstDatos;

                    foreach (GridColumnDescriptor col in ggcCompras.TableDescriptor.Columns)
                    {
                        col.AllowFilter = true;
                    }

                    GridDynamicFilter dynamicFilter = new GridDynamicFilter();
                    dynamicFilter.WireGrid(ggcCompras);

                    ggcCompras.TableDescriptor.AllowNew = false;
                    ggcCompras.TableDescriptor.AllowEdit = false;
                    ggcCompras.TableDescriptor.AllowRemove = false;

                    this.ggcCompras.TableDescriptor.Appearance.AnySummaryCell.BackColor = Color.Green;
                    this.ggcCompras.TableDescriptor.Appearance.AnySummaryCell.TextColor = Color.White;
                    this.ggcCompras.TableDescriptor.Appearance.AnySummaryCell.Font.Bold = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("cargarDatos.Compras " + ex.Message);
                }
            }

            if (tabSeleccionada == "Vales")
            {
                try
                {
                    int PorcVales = 0;
                    int MaxVales = 0;

                    List<ValeAlmacen> lstDatos = new List<ValeAlmacen>();

                    #region Almacen
                    DataTable dtVales = new DataTable();
                    using (OleDbConnection connectionAlm = new OleDbConnection(strAlmacen))
                    {
                        connectionAlm.Open();

                        SQL = "Select IIF(nCveEmp=1, 'APV', IIF(nCveEmp=2, 'EA', IIF(nCveEmp=3, 'OCS', IIF(nCveEmp=6, 'OFG',IIF(nCveEmp=8, 'ATL',0))))) As Empresa, 'Sin Servicio' as Servicio, cCveUni as Unidad, " +
                            "nIdUni as Id, va.nNumVal as Vale, dEntVal as Fecha, va.nFolBit as Bitacora, nCtdVal as Cantidad, det.cCodPrd as Codigo, cDesPrd as Producto, " +
                            "(nPreVal * 1.16) as Precio, (nCtdVal*nPreval*1.16) as Importe, cTipCpa as Tipo, lin.cDesLin as Linea, 'Cordoba' as Zona, 0 as nMes, '0' as Mes, 0 as Ano, 'Sin Obs' as Observaciones " +
                            "from (((Vales va " +
                            "inner join valesdetalle det on va.nNumVal=det.nNumVal) " +
                            "inner join productos pr on det.cCodPrd=pr.cCodPrd) " +
                            "inner join lineas lin on pr.nLinPrd=lin.nCveLin) " +
                            "Where det.nEdoVal=2 And dEntVal>=#" + dDesde.ToString("MM-dd-yyyy") + "# And dEntVal<=#" + dHasta.ToString("MM-dd-yyyy") + "#";

                        OleDbCommand commandVales = new OleDbCommand(SQL, connectionAlm);

                        OleDbDataReader readerVales = commandVales.ExecuteReader();

                        dtVales.Load(readerVales);

                        connectionAlm.Close();

                        foreach (DataColumn col in dtVales.Columns)
                            col.ReadOnly = false;

                        MaxVales = dtVales.Rows.Count;
                        PorcVales = 0;
                        pbReportes.Maximum = MaxVales;
                        pbReportes.Minimum = 0;
                        pbReportes.Value = PorcVales;

                        foreach (DataRow item in dtVales.Rows)
                        {
                            try
                            {
                                int bita = Convert.ToInt32(item["Bitacora"]);
                                string qryBita = "Select IIF(cSrvSrv='1','Terranova',IIF(cSrvSrv='2','Galaxy',IIF(cSrvSrv='3','Astro New',IIF(cSrvSrv='4','Sierra',IIF(cSrvSrv='5','Admvo',IIF(cSrvSrv='6','F.Tour',IIF(cSrvSrv='7','Urbano',IIF(cSrvSrv='9','Astro Plus', IIF(cSrvSrv='10','NT'))))))))) as Servicio, cCveUni as Unidad, nNumInt as ID, IIF(nCveEmp=1, 'APV', IIF(nCveEmp=2, 'EA', IIF(nCveEmp=3, 'OCS', IIF(nCveEmp=6, 'OFG', IIF(nCveEmp=8, 'ATL',0))))) As Empresa From OrdenMto Where nFolBit=" + bita;

                                string servicio = "Sin Servicio";
                                string unidad = "0";
                                int Id = 0;
                                string empresa = "0";

                                using (OleDbConnection connectionBita = new OleDbConnection(strMantto))
                                {
                                    connectionBita.Open();

                                    OleDbCommand commandBita = new OleDbCommand(qryBita, connectionBita);

                                    OleDbDataReader readerBita = commandBita.ExecuteReader();

                                    DataTable dtBita = new DataTable();
                                    dtBita.Load(readerBita);

                                    if (dtBita.Rows.Count > 0)
                                    {
                                        servicio = dtBita.Rows[0]["Servicio"].ToString()!;
                                        item["Servicio"] = servicio;
                                        unidad = dtBita.Rows[0]["Unidad"].ToString()!;
                                        item["Unidad"] = unidad;
                                        Id = Convert.ToInt32(dtBita.Rows[0]["ID"]);
                                        item["Id"] = Id;
                                        empresa = dtBita.Rows[0]["Empresa"].ToString()!;
                                        item["Empresa"] = empresa;
                                    }

                                    connectionBita.Close();
                                }

                                DateTime dFecha = DateTime.Parse(item["Fecha"].ToString()!);
                                int nmes = Convert.ToInt32(dFecha.ToString("MM"));
                                item["nmes"] = nmes;
                                string mes = dFecha.ToString("MMMM");
                                item["mes"] = mes;
                                int ano = Convert.ToInt32(dFecha.ToString("yyyy"));
                                item["ano"] = ano;

                                var Vale = new ValeAlmacen
                                {
                                    Empresa = empresa,
                                    Unidad = unidad,
                                    ID = Id,
                                    Vale = Convert.ToInt32(item["Vale"]),
                                    Fecha = dFecha.ToString("dd/MM/yyyy"),
                                    Bitacora = Convert.ToInt32(item["Bitacora"]),
                                    Cantidad = Convert.ToDouble(item["Cantidad"]),
                                    Codigo = item["Codigo"].ToString(),
                                    Producto = item["Producto"].ToString(),
                                    Precio = Convert.ToDouble(item["Precio"]),
                                    Importe = Convert.ToDouble(item["Importe"]),
                                    Tipo = item["Tipo"].ToString(),
                                    Servicio = servicio,
                                    nMes = nmes,
                                    Mes = mes,
                                    Ano = ano,
                                    Linea = item["Linea"].ToString(),
                                    Zona = item["Zona"].ToString(),
                                    Observaciones = item["Observaciones"].ToString()
                                };

                                lstDatos.Add(Vale);
                            }
                            catch (Exception ex)
                            {
                            }
                            PorcVales += 1;
                            pbReportes.Value = PorcVales;
                        }
                    }
                    #endregion

                    #region Cosco
                    DataTable dtCosco = new DataTable();
                    using (OleDbConnection connectionAlmCosco = new OleDbConnection(strAlmacenCP))
                    {
                        connectionAlmCosco.Open();

                        SQL = "Select IIF(nCveEmp=1, 'APV', IIF(nCveEmp=2, 'EA', IIF(nCveEmp=3, 'OCS', IIF(nCveEmp=6, 'OFG', IIF(nCveEmp=8, 'ATL',0))))) As Empresa, 'Sin Servicio' as Servicio, cCveUni as Unidad, " +
                                                    "nIdUni as ID, va.nNumVal as Vale, dEntVal as Fecha, va.nFolBit as Bitacora, nCtdVal as Cantidad, det.cCodPrd as Codigo, cDesPrd as Producto, " +
                                                    "(nPreVal * 1.16) as Precio, (nCtdVal*nPreval*1.16) as Importe, cTipCpa as Tipo, lin.cDesLin as Linea, 'Coscomatepec' as Zona, 0 as nMes, '0' as Mes, 0 as Ano, 'Sin Obs' as Observaciones " +
                                                    "from (((Vales va " +
                                                    "inner join valesdetalle det on va.nNumVal=det.nNumVal) " +
                                                    "inner join productos pr on det.cCodPrd=pr.cCodPrd) " +
                                                    "inner join lineas lin on pr.nLinPrd=lin.nCveLin) " +
                                                    "Where det.nEdoVal=2 And dEntVal>=#" + dDesde.ToString("MM-dd-yyyy") + "# And dEntVal<=#" + dHasta.ToString("MM-dd-yyyy") + "#";
                        OleDbCommand commandValesCosco = new OleDbCommand(SQL, connectionAlmCosco);

                        OleDbDataReader readerValesCosco = commandValesCosco.ExecuteReader();

                        dtCosco.Load(readerValesCosco);

                        connectionAlmCosco.Close();

                        foreach (DataColumn col in dtCosco.Columns)
                            col.ReadOnly = false;

                        MaxVales = dtCosco.Rows.Count;
                        PorcVales = 0;
                        pbReportes.Maximum = MaxVales;
                        pbReportes.Minimum = 0;
                        pbReportes.Value = PorcVales;

                        foreach (DataRow item in dtCosco.Rows)
                        {
                            try
                            {
                                int bita = Convert.ToInt32(item["Bitacora"]);
                                string qryBita = "Select IIF(cSrvSrv='1','Terranova',IIF(cSrvSrv='2','Galaxy',IIF(cSrvSrv='3','Astro New',IIF(cSrvSrv='4','Sierra',IIF(cSrvSrv='5','Admvo',IIF(cSrvSrv='6','F.Tour',IIF(cSrvSrv='7','Urbano',IIF(cSrvSrv='9','Astro Plus', IIF(cSrvSrv='10','NT'))))))))) as Servicio, cCveUni as Unidad, nNumInt as ID, IIF(nCveEmp=1, 'APV', IIF(nCveEmp=2, 'EA', IIF(nCveEmp=3, 'OCS', IIF(nCveEmp=6, 'OFG', IIF(nCveEmp=8, 'ATL',0))))) As Empresa From OrdenMto Where nFolBit=" + bita;

                                string servicio = "Sin Servicio";
                                string unidad = "0";
                                int Id = 0;
                                string empresa = "0";

                                using (OleDbConnection connectionBita = new OleDbConnection(strMantto))
                                {
                                    connectionBita.Open();

                                    OleDbCommand commandBita = new OleDbCommand(qryBita, connectionBita);

                                    OleDbDataReader readerBita = commandBita.ExecuteReader();

                                    DataTable dtBita = new DataTable();
                                    dtBita.Load(readerBita);

                                    if (dtBita.Rows.Count > 0)
                                    {
                                        servicio = dtBita.Rows[0]["Servicio"].ToString()!;
                                        item["Servicio"] = servicio;
                                        unidad = dtBita.Rows[0]["Unidad"].ToString()!;
                                        item["Unidad"] = unidad;
                                        Id = Convert.ToInt32(dtBita.Rows[0]["ID"]);
                                        item["Id"] = Id;
                                        empresa = dtBita.Rows[0]["Empresa"].ToString()!;
                                        item["Empresa"] = empresa;
                                    }

                                    connectionBita.Close();
                                }

                                DateTime dFecha = DateTime.Parse(item["Fecha"].ToString()!);
                                int nmes = Convert.ToInt32(dFecha.ToString("MM"));
                                item["nmes"] = nmes;
                                string mes = dFecha.ToString("MMMM");
                                item["mes"] = mes;
                                int ano = Convert.ToInt32(dFecha.ToString("yyyy"));
                                item["ano"] = ano;

                                var Vale = new ValeAlmacen
                                {
                                    Empresa = empresa,
                                    Unidad = unidad,
                                    ID = Id,
                                    Vale = Convert.ToInt32(item["Vale"]),
                                    Fecha = dFecha.ToString("dd/MM/yyyy"),
                                    Bitacora = Convert.ToInt32(item["Bitacora"]),
                                    Cantidad = Convert.ToDouble(item["Cantidad"]),
                                    Codigo = item["Codigo"].ToString(),
                                    Producto = item["Producto"].ToString(),
                                    Precio = Convert.ToDouble(item["Precio"]),
                                    Importe = Convert.ToDouble(item["Importe"]),
                                    Tipo = item["Tipo"].ToString(),
                                    Servicio = servicio,
                                    nMes = nmes,
                                    Mes = mes,
                                    Ano = ano,
                                    Linea = item["Linea"].ToString(),
                                    Zona = item["Zona"].ToString(),
                                    Observaciones = item["Observaciones"].ToString()
                                };

                                lstDatos.Add(Vale);
                            }
                            catch (Exception ex)
                            {
                            }
                            PorcVales += 1;
                            pbReportes.Value = PorcVales;
                        }
                    }
                    #endregion

                    #region Externos
                    int PorcExternos = 0;
                    int MaxExternos = 0;

                    DataTable dtExternos = new DataTable();

                    using (OleDbConnection connectionExt = new OleDbConnection(strServicios))
                    {
                        connectionExt.Open();

                        string qryServ = "select ord.nNumOrd as Orden, dFecFac as Fecha, IIF(Ord.nCveEmp=1, 'APV', IIF(Ord.nCveEmp=2, 'EA', IIF(Ord.nCveEmp=3, 'OCS', IIF(Ord.nCveEmp=6, 'OFG',IIF(Ord.nCveEmp=8, 'ATL',0))))) As Empresa, " +
                            "nCantSrv as Cantidad, det.nIdServicio as Codigo, sDescripcionSvr as Producto, (det.nCostoSrv * 1.16) as Precio, " +
                            "(((det.nCostoSrv * nCantSrv)-nDescuento) * 1.16) as Importe, ped.nFolioBit as Bitacora, ped.cObsPed as Observaciones " +
                                            "from((tbOrdenServicio ord " +
                                            "inner join tbDetalleOrden det on ord.nNumOrd = det.nNumOrd) " +
                                            "inner join tbServicios serv on det.nIdServicio = serv.nIdServicio) " +
                                            "inner join tbPedidos ped on ord.nNumPedido = ped.nNumPedido " +
                                            "Where (ord.nEdoOrd in(1)) and((det.cCvePrv <> '2102068000' and det.cCvePrv <> '2102077000' and det.cCvePrv <> '2102128000' and det.cCvePrv <> '2102307000'))  " +
                                            "and dFecFac>=#" + dDesde.ToString("MM-dd-yyyy") + "# And dFecFac<=#" + dHasta.ToString("MM-dd-yyyy") + "#";

                        OleDbCommand commandServ = new OleDbCommand(qryServ, connectionExt);

                        OleDbDataReader readerServ = commandServ.ExecuteReader();

                        DataTable dtServ = new DataTable();
                        dtServ.Load(readerServ);

                        connectionExt.Close();

                        foreach (DataColumn col in dtServ.Columns)
                            col.ReadOnly = false;

                        PorcExternos = 0;
                        MaxExternos = dtServ.Rows.Count;
                        pbReportes.Maximum = MaxExternos;
                        pbReportes.Minimum = 0;
                        pbReportes.Value = PorcExternos;

                        foreach (DataRow item in dtServ.Rows)
                        {
                            try
                            {
                                int bita = Convert.ToInt32(item["Bitacora"]);
                                int Orden = Convert.ToInt32(item["Orden"]);
                                string codigo = Convert.ToInt32(item["Codigo"]).ToString();

                                string qryBita = "Select IIF(cSrvSrv='1','Terranova',IIF(cSrvSrv='2','Galaxy',IIF(cSrvSrv='3','Astro New',IIF(cSrvSrv='4','Sierra',IIF(cSrvSrv='5','Admvo',IIF(cSrvSrv='6','F.Tour',IIF(cSrvSrv='7','Urbano',IIF(cSrvSrv='9','Astro Plus', IIF(cSrvSrv='10','NT'))))))))) as Servicio, cCveUni as Unidad, nNumInt as ID From OrdenMto Where nFolBit=" + bita;

                                string servicio = "Sin Servicio";
                                string unidad = "0";
                                int Id = 0;

                                using (OleDbConnection connectionBita = new OleDbConnection(strMantto))
                                {
                                    connectionBita.Open();

                                    OleDbCommand commandBita = new OleDbCommand(qryBita, connectionBita);

                                    OleDbDataReader readerBita = commandBita.ExecuteReader();

                                    DataTable dtBita = new DataTable();
                                    dtBita.Load(readerBita);

                                    if (dtBita.Rows.Count > 0)
                                    {
                                        servicio = dtBita.Rows[0]["Servicio"].ToString()!;
                                        unidad = dtBita.Rows[0]["Unidad"].ToString()!;
                                        Id = Convert.ToInt32(dtBita.Rows[0]["ID"]);
                                    }
                                    else
                                    {
                                    }
                                }

                                DateTime dFecha = DateTime.Parse(item["Fecha"].ToString()!);
                                int nmes = Convert.ToInt32(dFecha.ToString("MM"));
                                string mes = dFecha.ToString("MMMM");
                                int ano = Convert.ToInt32(dFecha.ToString("yyyy"));

                                var Vale = new ValeAlmacen
                                {
                                    Empresa = item["Empresa"].ToString()!,
                                    Unidad = unidad,
                                    ID = Id,
                                    Vale = Orden,
                                    Fecha = dFecha.ToString("dd/MM/yyyy"),
                                    Bitacora = bita,
                                    Cantidad = Convert.ToDouble(item["Cantidad"]),
                                    Codigo = item["Codigo"].ToString()!,
                                    Producto = item["Producto"].ToString()!,
                                    Precio = Convert.ToDouble(item["Precio"]),
                                    Importe = Convert.ToDouble(item["Importe"]),
                                    Tipo = "0",
                                    Servicio = servicio,
                                    nMes = nmes,
                                    Mes = mes,
                                    Ano = ano,
                                    Linea = "Servicio Externo",
                                    Zona = "Cordoba",
                                    Observaciones = item["Observaciones"].ToString()!
                                };
                                lstDatos.Add(Vale);
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                            PorcExternos += 1;
                            pbReportes.Value = PorcExternos;
                        }
                    }
                    #endregion

                    ggcVales.DataSource = null;
                    ggcVales.DataSource = lstDatos;

                    foreach (GridColumnDescriptor col in ggcVales.TableDescriptor.Columns)
                    {
                        col.AllowFilter = true;
                    }

                    GridDynamicFilter dynamicFilter = new GridDynamicFilter();
                    dynamicFilter.WireGrid(ggcVales);

                    ggcVales.TableDescriptor.AllowNew = false;
                    ggcVales.TableDescriptor.AllowEdit = false;
                    ggcVales.TableDescriptor.AllowRemove = false;

                    ggcVales.TableDescriptor.Appearance.AnySummaryCell.BackColor = Color.Green;
                    ggcVales.TableDescriptor.Appearance.AnySummaryCell.TextColor = Color.White;
                    ggcVales.TableDescriptor.Appearance.AnySummaryCell.Font.Bold = true;

                    GridSummaryColumnDescriptor summaryColumnDescriptor = new GridSummaryColumnDescriptor("Sum", SummaryType.DoubleAggregate, "Importe", "{Sum:#}");
                    GridSummaryRowDescriptor summaryRowDescriptor = new GridSummaryRowDescriptor("Sum", "Total Importe", summaryColumnDescriptor);

                    summaryRowDescriptor.Appearance.AnyCell.BackColor = Color.Green;
                    summaryRowDescriptor.Appearance.AnyCell.TextColor = Color.White;
                    summaryRowDescriptor.Appearance.AnyCell.CellType = GridCellTypeName.Static;
                    ggcVales.TableDescriptor.SummaryRows.Add(summaryRowDescriptor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("cargarDatos.Vales " + ex.Message);
                }
            }

            if (tabSeleccionada == "DevolucionesVale")
            {
                try
                {
                    int PorcDevVales = 0;
                    int MaxDevVales = 0;

                    DataTable dtDevVales = new DataTable();

                    using (OleDbConnection connectionAlm = new OleDbConnection(strAlmacen))
                    {
                        connectionAlm.Open();

                        SQL = "select nNumVal as Vale, cCodPrd as Codigo, cDesPrd as Producto, " +
                        "nCtdPrd as Cantidad, nPrePrd as Precio, nCtdPrd * nPrePrd as Importe, 'dFecDev' as Fecha, dFecDev as Fecha_ " +
                        "from Devoluciones " +
                        "Where dFecDev >= #" + dDesde.ToString("MM-dd-yyyy") + "# and dFecDev <= #" + dHasta.ToString("MM-dd-yyyy") + "# " +
                        "Order by nNumDev";

                        OleDbCommand commandDetVales = new OleDbCommand(SQL, connectionAlm);

                        OleDbDataReader readerDetVales = commandDetVales.ExecuteReader();

                        dtDevVales.Load(readerDetVales);

                        connectionAlm.Close();

                        foreach (DataColumn col in dtDevVales.Columns)
                            col.ReadOnly = false;

                        MaxDevVales = dtDevVales.Rows.Count;
                        PorcDevVales = 0;
                        pbReportes.Maximum = MaxDevVales;
                        pbReportes.Minimum = 0;
                        pbReportes.Value = PorcDevVales;

                        foreach (DataRow item in dtDevVales.Rows)
                        {
                            DateTime dFecha = DateTime.Parse(item["Fecha_"].ToString()!);
                            item["Fecha"] = dFecha.ToString("dd/MM/yyyy");

                            PorcDevVales += 1;
                            pbReportes.Value = PorcDevVales;
                        }

                        DataColumnCollection columns = dtDevVales.Columns;

                        if (columns.Contains("Fecha_"))
                            if (columns.CanRemove(columns["Fecha_"]))
                                columns.Remove("Fecha_");

                        ggcDevolucionVale.DataSource = null;
                        ggcDevolucionVale.DataSource = dtDevVales;

                        foreach (GridColumnDescriptor col in ggcDevolucionVale.TableDescriptor.Columns)
                        {
                            col.AllowFilter = true;
                        }

                        GridDynamicFilter dynamicFilter = new GridDynamicFilter();
                        dynamicFilter.WireGrid(ggcDevolucionVale);

                        ggcDevolucionVale.TableDescriptor.AllowNew = false;
                        ggcDevolucionVale.TableDescriptor.AllowEdit = false;
                        ggcDevolucionVale.TableDescriptor.AllowRemove = false;

                        ggcDevolucionVale.TableDescriptor.Appearance.AnySummaryCell.BackColor = Color.Green;
                        ggcDevolucionVale.TableDescriptor.Appearance.AnySummaryCell.TextColor = Color.Red;
                        ggcDevolucionVale.TableDescriptor.Appearance.AnySummaryCell.Font.Bold = true;

                        GridSummaryColumnDescriptor summaryColumnDescriptor = new GridSummaryColumnDescriptor("Sum", SummaryType.DoubleAggregate, "Importe", "{Sum:#}");
                        GridSummaryRowDescriptor summaryRowDescriptor = new GridSummaryRowDescriptor("Sum", "Total Importe", summaryColumnDescriptor);
                        summaryRowDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                        summaryRowDescriptor.Appearance.AnyCell.BackColor = Color.Cornsilk;

                        ggcDevolucionVale.ChildGroupOptions.ShowCaptionSummaryCells = true;
                        ggcDevolucionVale.ChildGroupOptions.ShowSummaries = false;
                        ggcDevolucionVale.ChildGroupOptions.CaptionSummaryRow = "Sum";

                        ggcDevolucionVale.Appearance.GroupCaptionCell.BackColor = ggcDevolucionVale.Appearance.RecordFieldCell.BackColor;
                        ggcDevolucionVale.Appearance.GroupCaptionCell.Borders.Top = new GridBorder(GridBorderStyle.Standard);
                        ggcDevolucionVale.Appearance.GroupCaptionCell.CellType = "Static";

                        ggcDevolucionVale.TableDescriptor.SummaryRows.Add(summaryRowDescriptor);


                        //{ CategoryCaption}: { Category} - { RecordCount} Items
                        /*
                        summaryRowDescriptor.Appearance.AnyCell.BackColor = Color.Green;
                        summaryRowDescriptor.Appearance.AnyCell.TextColor = Color.White;
                        summaryRowDescriptor.Appearance.AnyCell.CellType = GridCellTypeName.Static;
                        ggcDevolucionVale.TableDescriptor.SummaryRows.Add(summaryRowDescriptor);
                        */
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("cargarDatos.DevolucionesVale " + ex.Message);
                }
            }

            if (tabSeleccionada == "Llantas")
            {
                try
                {
                    int PorcLlantas = 0;
                    int MaxLlantas = 0;

                    DataTable dtLlantas = new DataTable();

                    using (OleDbConnection connectionLla = new OleDbConnection(strLlantas))
                    {
                        connectionLla.Open();

                        SQL = "select val.nnumval as Vale, IIF(val.nCveEmp=1, 'APV', IIF(val.nCveEmp=2, 'EA', IIF(val.nCveEmp=3, 'OCS', IIF(val.nCveEmp=6, 'OFG',IIF(val.nCveEmp=8, 'ATL',0))))) As Empresa, val.nfolbit as Bitacora, 'dEntVal' as Fecha, val.dEntVal as Fecha_, val.ccveuni as Unidad, val.niduni as IdUnidad, " +
                            "det.ccodprd as Codigo, prd.cDesPrd as Producto, det.npreval as Precio, det.nctdval as Cantidad, det.nctdval * npreval as Importe, 'det.ncveum' as Tipo, det.ncveum as Tipo_ " +
                            "from((vales val " +
                            "inner join valesdetalle det on val.nnumval = det.nnumval) " +
                            "inner join Productos prd on det.cCodPrd = prd.cCodPrd) " +
                            "where val.nEdoVal=2 and val.dEntVal>=#" + dDesde.ToString("MM-dd-yyyy") + "# And val.dEntVal<=#" + dHasta.ToString("MM-dd-yyyy") + "# ";

                        OleDbCommand commandLlantas = new OleDbCommand(SQL, connectionLla);

                        OleDbDataReader readerLlantas = commandLlantas.ExecuteReader();

                        dtLlantas.Load(readerLlantas);

                        connectionLla.Close();

                        foreach (DataColumn col in dtLlantas.Columns)
                            col.ReadOnly = false;

                        MaxLlantas = dtLlantas.Rows.Count;
                        PorcLlantas = 0;
                        pbReportes.Maximum = MaxLlantas;
                        pbReportes.Minimum = 0;
                        pbReportes.Value = PorcLlantas;

                        foreach (DataRow item in dtLlantas.Rows)
                        {
                            try
                            {
                                DateTime dFecha = DateTime.Parse(item["Fecha_"].ToString()!);
                                item["Fecha"] = dFecha.ToString("dd/MM/yyyy");

                                int nTipo = Convert.ToInt32(item["Tipo_"]);
                                switch (nTipo)
                                {
                                    case 1:
                                        item["Tipo"] = "Nueva";
                                        break;
                                    case 2:
                                        item["Tipo"] = "Renovada";
                                        break;
                                    case 3:
                                        item["Tipo"] = "Primer Renovado";
                                        break;
                                }

                                int bita = Convert.ToInt32(item["Bitacora"]);

                                string qryBita = "Select IIF(cSrvSrv='1','Terranova',IIF(cSrvSrv='2','Galaxy',IIF(cSrvSrv='3','Astro New',IIF(cSrvSrv='4','Sierra',IIF(cSrvSrv='5','Admvo',IIF(cSrvSrv='6','F.Tour',IIF(cSrvSrv='7','Urbano',IIF(cSrvSrv='9','Astro Plus', IIF(cSrvSrv='10','NT'))))))))) as Servicio, cCveUni as Unidad, nNumInt as ID, IIF(nCveEmp=1, 'APV', IIF(nCveEmp=2, 'EA', IIF(nCveEmp=3, 'OCS', IIF(nCveEmp=6, 'OFG', IIF(nCveEmp=8, 'ATL',0))))) As Empresa From OrdenMto Where nFolBit=" + bita;

                                string servicio = "Sin Servicio";

                                using (OleDbConnection connectionBita = new OleDbConnection(strMantto))
                                {
                                    connectionBita.Open();

                                    OleDbCommand commandBita = new OleDbCommand(qryBita, connectionBita);

                                    OleDbDataReader readerBita = commandBita.ExecuteReader();

                                    DataTable dtBita = new DataTable();
                                    dtBita.Load(readerBita);

                                    if (dtBita.Rows.Count > 0)
                                    {
                                        servicio = dtBita.Rows[0]["Servicio"].ToString()!;
                                        item["Servicio"] = servicio;
                                    }

                                    connectionBita.Close();
                                }

                                DateTime dtmes = DateTime.Parse(item["Fecha"].ToString()!);
                                int nmes = Convert.ToInt32(dtmes.ToString("MM"));
                                item["nmes"] = nmes;
                                string mes = dtmes.ToString("MMMM");
                                item["mes"] = mes;
                                int ano = Convert.ToInt32(dtmes.ToString("yyyy"));
                                item["ano"] = ano;
                            }
                            catch (Exception ex)
                            {
                            }
                            PorcLlantas += 1;
                            pbReportes.Value = PorcLlantas;
                        }

                        DataColumnCollection columns = dtLlantas.Columns;

                        if (columns.Contains("Fecha_"))
                            if (columns.CanRemove(columns["Fecha_"]))
                                columns.Remove("Fecha_");

                        if (columns.Contains("Tipo_"))
                            if (columns.CanRemove(columns["Tipo_"]))
                                columns.Remove("Tipo_");

                        ggcLlantas.DataSource = null;
                        ggcLlantas.DataSource = dtLlantas;

                        foreach (GridColumnDescriptor col in ggcLlantas.TableDescriptor.Columns)
                        {
                            col.AllowFilter = true;
                        }

                        GridDynamicFilter dynamicFilter = new GridDynamicFilter();
                        dynamicFilter.WireGrid(ggcLlantas);

                        ggcLlantas.TableDescriptor.AllowNew = false;
                        ggcLlantas.TableDescriptor.AllowEdit = false;
                        ggcLlantas.TableDescriptor.AllowRemove = false;

                        ggcLlantas.TableDescriptor.Appearance.AnySummaryCell.BackColor = Color.Green;
                        ggcLlantas.TableDescriptor.Appearance.AnySummaryCell.TextColor = Color.White;
                        ggcLlantas.TableDescriptor.Appearance.AnySummaryCell.Font.Bold = true;

                        GridSummaryColumnDescriptor summaryColumnDescriptor = new GridSummaryColumnDescriptor("Sum", SummaryType.DoubleAggregate, "Importe", "{Sum:#}");
                        GridSummaryRowDescriptor summaryRowDescriptor = new GridSummaryRowDescriptor("Sum", "Total Importe", summaryColumnDescriptor);

                        summaryRowDescriptor.Appearance.AnyCell.BackColor = Color.Green;
                        summaryRowDescriptor.Appearance.AnyCell.TextColor = Color.White;
                        summaryRowDescriptor.Appearance.AnyCell.CellType = GridCellTypeName.Static;
                        ggcLlantas.TableDescriptor.SummaryRows.Add(summaryRowDescriptor);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("cargarDatos.Llantas " + ex.Message);
                }
            }

            if (tabSeleccionada == "ComprasLlantas")
            {
                try
                {
                    int PorcCompraLlantas = 0;
                    int MaxCompraLlantas = 0;

                    DataTable dtCompraLlantas = new DataTable();

                    using (OleDbConnection connectionLla = new OleDbConnection(strLlantas))
                    {
                        connectionLla.Open();

                        SQL = "Select ord.nNumOrd as Orden,IIF(ord.nCveEmp=1, 'APV',IIF(ord.nCveEmp=2, 'EA', IIF(ord.nCveEmp=3, " +
                            "'OCS', IIF(ord.nCveEmp = 6, 'OFG', 0)))) As Empresa, det.cPrvOrd as Clave_Proveedor, 'Proveedor' as Proveedor, 'dFecOrd' as Fecha_Orden, dFecOrd as Fecha_Orden_, IIF(ord.nEdoOrd = 1, 'EMITIDO', " +
                            "IIF(ord.nEdoOrd = 2, 'ENTREGADO', IIF(ord.nEdoOrd = 3, 'CANCELADO', 0))) as Estado_Orden, " +
                            "ord.cFacOrd as Factura, 'ord.dFecFac' as Fecha_Factura, ord.dFecFac as Fecha_Factura_, ord.nTpgOrd as Tipo_Pago, " +
                            "det.nCtdOrd as Cantidad, det.cCodPrd as Codigo, prd.cDesPrd as Producto, " +
                            "det.nCtoOrd as Costo, det.nCtdOrd*det.nCtoOrd as Importe, 'Entregado' as Estado_Partida, " +
                            "ord.cFolFis as Folio_Fiscal, prd.cPtePrd as Tipo_Llanta, med.cMedLla as Tipo_Hule from(((orden ord " +
                            "inner join ordendetalle det on ord.nNumOrd = det.nNumOrd) " +
                            "inner join Productos prd on det.cCodPrd = prd.cCodPrd) " +
                            "inner join Medidas med on det.nCveMed = med.nCveMed) " +
                            "Where ord.dFecFac>=#" + dDesde.ToString("MM-dd-yyyy") + "# And ord.dFecFac<=#" + dHasta.ToString("MM-dd-yyyy") + "#";

                        OleDbCommand commandCompraLlantas = new OleDbCommand(SQL, connectionLla);

                        OleDbDataReader readerCompraLlantas = commandCompraLlantas.ExecuteReader();

                        dtCompraLlantas.Load(readerCompraLlantas);

                        connectionLla.Close();

                        foreach (DataColumn col in dtCompraLlantas.Columns)
                            col.ReadOnly = false;

                        MaxCompraLlantas = dtCompraLlantas.Rows.Count;
                        PorcCompraLlantas = 0;
                        pbReportes.Maximum = MaxCompraLlantas;
                        pbReportes.Minimum = 0;
                        pbReportes.Value = PorcCompraLlantas;

                        foreach (DataRow item in dtCompraLlantas.Rows)
                        {
                            try
                            {
                                DateTime dFechaOrden = DateTime.Parse(item["Fecha_Orden_"].ToString()!);
                                item["Fecha_Orden"] = dFechaOrden.ToString("dd/MM/yyyy");

                                DateTime dFechaFactura = DateTime.Parse(item["Fecha_Factura_"].ToString()!);
                                item["Fecha_Factura"] = dFechaFactura.ToString("dd/MM/yyyy");

                                string cCvePro = item["Clave_Proveedor"].ToString()!;

                                string qryProv = "select cDesCon From conc2 where ccuecon='" + cCvePro + "'";

                                using (OleDbConnection connectionTeso = new OleDbConnection(strTesoreria))
                                {
                                    connectionTeso.Open();

                                    OleDbCommand commandProv = new OleDbCommand(qryProv, connectionTeso);

                                    OleDbDataReader readerProv = commandProv.ExecuteReader();

                                    DataTable dtProv = new DataTable();
                                    dtProv.Load(readerProv);

                                    if (dtProv.Rows.Count > 0)
                                    {
                                        item["Proveedor"] = dtProv.Rows[0]["cDesCon"].ToString();
                                    }
                                }

                                DateTime dtmes = DateTime.Parse(item["Fecha_Factura"].ToString()!);
                                int nmes = Convert.ToInt32(dtmes.ToString("MM"));
                                item["nmes"] = nmes;
                                string mes = dtmes.ToString("MMMM");
                                item["mes"] = mes;
                                int ano = Convert.ToInt32(dtmes.ToString("yyyy"));
                                item["ano"] = ano;
                            }
                            catch (Exception ex)
                            {
                            }
                            PorcCompraLlantas += 1;
                            pbReportes.Value = PorcCompraLlantas;
                        }

                        DataColumnCollection columns = dtCompraLlantas.Columns;

                        if (columns.Contains("Fecha_Orden_"))
                            if (columns.CanRemove(columns["Fecha_Orden_"]))
                                columns.Remove("Fecha_Orden_");

                        if (columns.Contains("Fecha_Factura_"))
                            if (columns.CanRemove(columns["Fecha_Factura_"]))
                                columns.Remove("Fecha_Factura_");

                        ggcComprasLLantas.DataSource = null;
                        ggcComprasLLantas.DataSource = dtCompraLlantas;

                        foreach (GridColumnDescriptor col in ggcComprasLLantas.TableDescriptor.Columns)
                        {
                            col.AllowFilter = true;
                        }

                        GridDynamicFilter dynamicFilter = new GridDynamicFilter();
                        dynamicFilter.WireGrid(ggcComprasLLantas);

                        ggcComprasLLantas.TableDescriptor.AllowNew = false;
                        ggcComprasLLantas.TableDescriptor.AllowEdit = false;
                        ggcComprasLLantas.TableDescriptor.AllowRemove = false;

                        ggcComprasLLantas.TableDescriptor.Appearance.AnySummaryCell.BackColor = Color.Green;
                        ggcComprasLLantas.TableDescriptor.Appearance.AnySummaryCell.TextColor = Color.White;
                        ggcComprasLLantas.TableDescriptor.Appearance.AnySummaryCell.Font.Bold = true;

                        GridSummaryColumnDescriptor summaryColumnDescriptor = new GridSummaryColumnDescriptor("Sum", SummaryType.DoubleAggregate, "Importe", "{Sum:#}");
                        GridSummaryRowDescriptor summaryRowDescriptor = new GridSummaryRowDescriptor("Sum", "Total Importe", summaryColumnDescriptor);

                        summaryRowDescriptor.Appearance.AnyCell.BackColor = Color.Green;
                        summaryRowDescriptor.Appearance.AnyCell.TextColor = Color.White;
                        summaryRowDescriptor.Appearance.AnyCell.CellType = GridCellTypeName.Static;
                        ggcComprasLLantas.TableDescriptor.SummaryRows.Add(summaryRowDescriptor);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("cargarDatos.ComprasLlantas " + ex.Message);
                }
            }

            if (tabSeleccionada == "Diesel")
            {
                try
                {
                    int PorcDiesel = 0;
                    int MaxDiesel = 0;

                    SQL = "SELECT  Vale, Folio, Fecha, IdUnidad, LitrosVale, Costo, (LitrosVale * Costo) as Importe, Unidad, Tipo, EmpresaPertenece Empresa, Zona, Servicio, KmsVale, KmSig, nMes, Mes, Ano, LectHubAnt, LectHubAct, Mirilla, Hora, Operador,  Capturo, Bitacora, SerieBitacora, '0' as Ruta  " +
                        "FROM vw_ValesDiesel_Reporte_Rend " +
                        "WHERE (Fecha >= '" + dDesde.ToString("yyyyMMdd") + " 00:00') AND(Fecha <= '" + dHasta.ToString("yyyyMMdd") + " 23:59') ";

                    DataTable dtDiesel = csConex.select(SQL);

                    MaxDiesel = dtDiesel.Rows.Count;
                    PorcDiesel = 0;
                    pbReportes.Maximum = MaxDiesel;
                    pbReportes.Minimum = 0;
                    pbReportes.Value = PorcDiesel;

                    foreach (DataRow item in dtDiesel.Rows)
                    {
                        string Ruta = "0";
                        int nFolBit = Convert.ToInt32(item["Bitacora"]);
                        string cSerBit = item["SerieBitacora"].ToString()!;

                        string serie = cSerBit.Replace("0", "");

                        if (serie == "ATL")
                        {
                            Ruta = "TLACOTENGO";
                        }
                        else
                        {
                            SQL = "Select Ruta from vw_tbBitacoras Where Folio = " + nFolBit + " And Serie = '" + serie + "'";

                            DataTable dtRuta = csConex2.select(SQL);

                            if (dtRuta.Rows.Count > 0)
                            {
                                Ruta = dtRuta.Rows[0]["Ruta"].ToString()!;
                            }

                        }

                        item["Ruta"] = Ruta;

                        PorcDiesel += 1;
                        pbReportes.Value = PorcDiesel;
                    }

                    csConex.cerrarconex();
                    csConex2.cerrarconex();


                    ggcDiesel.DataSource = null;
                    ggcDiesel.DataSource = dtDiesel;

                    foreach (GridColumnDescriptor col in ggcDiesel.TableDescriptor.Columns)
                    {
                        col.AllowFilter = true;
                    }

                    GridDynamicFilter dynamicFilter = new GridDynamicFilter();
                    dynamicFilter.WireGrid(ggcDiesel);

                    ggcDiesel.TableDescriptor.AllowNew = false;
                    ggcDiesel.TableDescriptor.AllowEdit = false;
                    ggcDiesel.TableDescriptor.AllowRemove = false;

                    ggcDiesel.TableDescriptor.Appearance.AnySummaryCell.BackColor = Color.Green;
                    ggcDiesel.TableDescriptor.Appearance.AnySummaryCell.TextColor = Color.White;
                    ggcDiesel.TableDescriptor.Appearance.AnySummaryCell.Font.Bold = true;

                    GridSummaryColumnDescriptor summaryColumnDescriptor = new GridSummaryColumnDescriptor("Sum", SummaryType.DoubleAggregate, "Importe", "{Sum:#}");
                    GridSummaryRowDescriptor summaryRowDescriptor = new GridSummaryRowDescriptor("Sum", "Total Importe", summaryColumnDescriptor);

                    summaryRowDescriptor.Appearance.AnyCell.BackColor = Color.Green;
                    summaryRowDescriptor.Appearance.AnyCell.TextColor = Color.White;
                    summaryRowDescriptor.Appearance.AnyCell.CellType = GridCellTypeName.Static;
                    ggcDiesel.TableDescriptor.SummaryRows.Add(summaryRowDescriptor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("cargarDatos.Diesel " + ex.Message);
                }
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            cargaDatos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            GroupingGridExcelConverterControl converter = new GroupingGridExcelConverterControl();
            converter.ExportGroupPlusMinus = true;

            if (tabSeleccionada == "Vales")
            {
                converter.GroupingGridToExcel(this.ggcVales, "E:\\ReporteadorVales.xls", ConverterOptions.Visible);
                MessageBox.Show("Archivo creado");
            }
            if (tabSeleccionada == "DevolucionesVale")
            {
                converter.GroupingGridToExcel(this.ggcDevolucionVale, "E:\\ReporteadorDevolucionesVale.xls", ConverterOptions.Visible);
                MessageBox.Show("Archivo creado");
            }
            if (tabSeleccionada == "Compras")
            {
                converter.GroupingGridToExcel(this.ggcCompras, "E:\\ReporteadorCompras.xls", ConverterOptions.Visible);
                MessageBox.Show("Archivo creado");
            }
            if (tabSeleccionada == "Llantas")
            {
                converter.GroupingGridToExcel(this.ggcLlantas, "E:\\ReporteadorLlantas.xls", ConverterOptions.Visible);
                MessageBox.Show("Archivo creado");
            }
            if (tabSeleccionada == "ComprasLlantas")
            {
                converter.GroupingGridToExcel(this.ggcComprasLLantas, "E:\\ReporteadorComprasLlantas.xls", ConverterOptions.Visible);
                MessageBox.Show("Archivo creado");
            }
            if (tabSeleccionada == "Diesel")
            {
                converter.GroupingGridToExcel(this.ggcDiesel, "E:\\ReporteadorDiesel.xls", ConverterOptions.Visible);
                MessageBox.Show("Archivo creado");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabReporteador_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabSeleccionada = tabReporteador.SelectedTab.Text;
            if (tabSeleccionada == "Compras")
            {
                ggcCompras.DataSource = null;
                pbReportes.Value = 0;
            }

            if (tabSeleccionada == "DevolucionesVale")
            {
                ggcDevolucionVale.DataSource = null;
                pbReportes.Value = 0;
            }

            if (tabSeleccionada == "Vales")
            {
                ggcVales.DataSource = null;
                pbReportes.Value = 0;
            }

            if (tabSeleccionada == "Llantas")
            {
                ggcLlantas.DataSource = null;
                pbReportes.Value = 0;
            }

            if (tabSeleccionada == "ComprasLlantas")
            {
                ggcComprasLLantas.DataSource = null;
                pbReportes.Value = 0;
            }

            if (tabSeleccionada == "Diesel")
            {
                ggcDiesel.DataSource = null;
                pbReportes.Value = 0;
            }
        }

    }
}
