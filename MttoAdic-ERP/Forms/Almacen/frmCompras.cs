
using System.Data;
using System.Data.OleDb;
using System.Drawing.Printing;
using Syncfusion.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmCompras : MetroForm
    {
        string strTesoreria = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\srv2kas\\Base Datos Administra_R\\Tesoreria.mdb;Jet OLEDB:Database Password=a9TnX13HHOo;";
        string SQL = string.Empty;
        string CodigoBuscar = string.Empty;

        DataTable dtProveedores = new DataTable();
        DataTable dtProductosGrid = new DataTable();
        DataTable dtOrdenModificar = new DataTable();
        DataTable dtDetalleModificar = new DataTable();

        bool bNuevo = false;
        bool bModifica = false;
        bool bTermina = false;

        private PrintDocument PD = new PrintDocument();
        private PrintPreviewDialog PPD = new PrintPreviewDialog();

        decimal IsrRetenido = 0;

        public csConexionSQL conexCompras;
        public csConexionSQL ConexCompras { set { this.conexCompras = value; } }

        public frmCompras()
        {
            try
            {
                InitializeComponent();
                PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmCompras() " + ex.Message);
            }
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            try
            {
                CargaProveedores();

                dtProductosGrid.Columns.Add("Orden", typeof(int));
                dtProductosGrid.Columns.Add("Codigo", typeof(string));
                dtProductosGrid.Columns.Add("Descripcion", typeof(string));
                dtProductosGrid.Columns.Add("Cantidad", typeof(decimal));
                dtProductosGrid.Columns.Add("Costo", typeof(decimal));
                dtProductosGrid.Columns.Add("Importe", typeof(decimal));
                dtProductosGrid.Columns.Add("Pedido", typeof(int));

                cboTipo.Items.Add("Contado");
                cboTipo.Items.Add("Credito");
                cboTipo.SelectedIndex = -1;

                cboMetodo.Items.Add("Pago en Una Exhibición");
                cboMetodo.Items.Add("Pago Por Definir");
                cboMetodo.SelectedIndex = -1;

                HabilitaControles(1);
                HabilitaBotones(1);

                CargaValorIsrRetenido();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmCompras_Load " + ex.Message);
            }
        }
        private void ApplyModernStyle()
        {
            // Crear región con bordes redondeados
            var path = new GraphicsPath();
            int radius = 20;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }
        private void CargaValorIsrRetenido()
        {
            try
            {
                SQL = "SELECT nIdPar, cNomPar, nValPar from tbParametro Where nIdPar = 1";

                DataTable dtRetencion = conexCompras.select(SQL);

                if (dtRetencion.Rows.Count > 0)
                {
                    IsrRetenido = Convert.ToDecimal(dtRetencion.Rows[0]["nValpar"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaValorIsrRetenido " + ex.Message);
            }
        }

        private void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                StringFormat formSub = new StringFormat();
                formSub.Alignment = StringAlignment.Center;
                formSub.LineAlignment = StringAlignment.Center;
                Font fontSub = new Font("Arial", 24, FontStyle.Bold, GraphicsUnit.Pixel);
                e.Graphics!.DrawString("Orden de Compra", fontSub, Brushes.Black, new RectangleF(250, 20, 300, 30), formSub);

                StringFormat formEstado = new StringFormat();
                formEstado.Alignment = StringAlignment.Center;
                formEstado.LineAlignment = StringAlignment.Center;
                Font fontEstado = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);
                e.Graphics.DrawString(txtEstado.Text, fontEstado, Brushes.Black, new RectangleF(550, 20, 200, 30), formEstado);

                StringFormat formOrden = new StringFormat();
                formOrden.Alignment = StringAlignment.Near;
                formOrden.LineAlignment = StringAlignment.Center;
                Font fontOrden = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Número : " + txtNumero.Text, fontOrden, Brushes.Black, new RectangleF(20, 50, 300, 30), formOrden);

                StringFormat formFechaOrden = new StringFormat();
                formFechaOrden.Alignment = StringAlignment.Center;
                formFechaOrden.LineAlignment = StringAlignment.Center;
                Font fontFechaOrden = new Font("Times New Roman", 18, FontStyle.Bold, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Fecha : " + dtpOrden.Value.ToString("dd/MM/yyyy"), fontFechaOrden, Brushes.Black, new RectangleF(300, 50, 200, 30), formFechaOrden);

                StringFormat formTipo = new StringFormat();
                formTipo.Alignment = StringAlignment.Center;
                formTipo.LineAlignment = StringAlignment.Center;
                Font fontTipo = new Font("Arial", 22, FontStyle.Bold, GraphicsUnit.Pixel);
                e.Graphics.DrawString(cboTipo.Text, fontTipo, Brushes.Black, new RectangleF(550, 50, 200, 30), formTipo);

                StringFormat formProv = new StringFormat();
                formProv.Alignment = StringAlignment.Near;
                formProv.LineAlignment = StringAlignment.Far;
                Font fontProv = new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Proveedor : " + cboProveedor.SelectedValue!.ToString() + " " + cboProveedor.Text, fontProv, Brushes.Black, new RectangleF(20, 80, 800, 30), formProv);

                StringFormat formFactura = new StringFormat();
                formFactura.Alignment = StringAlignment.Center;
                formFactura.LineAlignment = StringAlignment.Far;
                Font fontFactura = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Factura : " + txtFactura.Text, fontFactura, Brushes.Black, new RectangleF(550, 80, 300, 30), formFactura);

                Pen Pen = new Pen(Brushes.Black);
                Pen.Width = 1.0F;
                e.Graphics.DrawRectangle(Pen, new Rectangle(20, 113, 780, 1));

                StringFormat formCodigo = new StringFormat();
                formCodigo.Alignment = StringAlignment.Center;
                formCodigo.LineAlignment = StringAlignment.Center;
                Font fontCodigo = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Código", fontCodigo, Brushes.Black, new RectangleF(20, 114, 100, 30), formCodigo);

                StringFormat formCantidad = new StringFormat();
                formCantidad.Alignment = StringAlignment.Center;
                formCantidad.LineAlignment = StringAlignment.Center;
                Font fontCantidad = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Cantidad", fontCantidad, Brushes.Black, new RectangleF(120, 114, 100, 30), formCantidad);

                StringFormat formDescripcion = new StringFormat();
                formDescripcion.Alignment = StringAlignment.Center;
                formDescripcion.LineAlignment = StringAlignment.Center;
                Font fontDescripcion = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Descripción", fontDescripcion, Brushes.Black, new RectangleF(220, 114, 300, 30), formDescripcion);

                StringFormat formPedido = new StringFormat();
                formPedido.Alignment = StringAlignment.Center;
                formPedido.LineAlignment = StringAlignment.Center;
                Font fontPedido = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Pedido", fontPedido, Brushes.Black, new RectangleF(500, 114, 100, 30), formPedido);

                StringFormat formCosto = new StringFormat();
                formCosto.Alignment = StringAlignment.Far;
                formCosto.LineAlignment = StringAlignment.Center;
                Font fontCosto = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Costo", fontCosto, Brushes.Black, new RectangleF(580, 114, 100, 30), formCosto);

                StringFormat formImporte = new StringFormat();
                formImporte.Alignment = StringAlignment.Far;
                formImporte.LineAlignment = StringAlignment.Center;
                Font fontImporte = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Importe", fontImporte, Brushes.Black, new RectangleF(680, 114, 100, 30), formImporte);

                e.Graphics.DrawRectangle(Pen, new Rectangle(20, 136, 780, 1));

                int Detalle = 140;

                StringFormat formIzquierda = new StringFormat();
                formIzquierda.Alignment = StringAlignment.Near;
                formIzquierda.LineAlignment = StringAlignment.Center;

                StringFormat formDerecha = new StringFormat();
                formDerecha.Alignment = StringAlignment.Far;
                formDerecha.LineAlignment = StringAlignment.Center;

                StringFormat formCentro = new StringFormat();
                formCentro.Alignment = StringAlignment.Center;
                formCentro.LineAlignment = StringAlignment.Center;

                foreach (DataRow fila in dtProductosGrid.Rows)
                {
                    string codigo = fila["Codigo"].ToString()!;
                    e.Graphics.DrawString(codigo, fontCodigo, Brushes.Black, new RectangleF(25, Detalle, 100, 30), formCentro);
                    decimal ncantidad = Convert.ToDecimal(fila["Cantidad"]);
                    string cantidad = ncantidad.ToString("F2");
                    e.Graphics.DrawString(cantidad, fontCantidad, Brushes.Black, new RectangleF(120, Detalle, 90, 30), formDerecha);
                    string descripcion = fila["Descripcion"].ToString()!;
                    e.Graphics.DrawString(descripcion, fontDescripcion, Brushes.Black, new RectangleF(225, Detalle, 300, 30), formIzquierda);
                    string pedido = fila["Pedido"].ToString()!;
                    e.Graphics.DrawString(pedido, fontCodigo, Brushes.Black, new RectangleF(500, Detalle, 100, 30), formCentro);
                    decimal nPrecio = Convert.ToDecimal(fila["Costo"]);
                    string precio = nPrecio.ToString("F2");
                    e.Graphics.DrawString(precio, fontCosto, Brushes.Black, new RectangleF(580, Detalle, 100, 30), formDerecha);
                    decimal nImporte = Convert.ToDecimal(fila["Importe"]);
                    string importe = nImporte.ToString("F2");
                    e.Graphics.DrawString(importe, fontImporte, Brushes.Black, new RectangleF(680, Detalle, 100, 30), formDerecha);
                    Detalle += 15;
                }

                Pen PenFinDetalle = new Pen(Brushes.Black);
                PenFinDetalle.Width = 1.0F;
                e.Graphics.DrawRectangle(PenFinDetalle, new Rectangle(20, Detalle + 10, 780, 1));

                Font fontTotal = new Font("Times New Roman", 18, FontStyle.Bold, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Subtotal : ", fontTotal, Brushes.Black, new RectangleF(550, Detalle + 10, 150, 30), formIzquierda);
                e.Graphics.DrawString(txtTotal.Text, fontTotal, Brushes.Black, new RectangleF(700, Detalle + 10, 100, 30), formDerecha);

                e.Graphics.DrawString("Iva : ", fontTotal, Brushes.Black, new RectangleF(550, Detalle + 35, 150, 30), formIzquierda);
                e.Graphics.DrawString(txtIva.Text, fontTotal, Brushes.Black, new RectangleF(700, Detalle + 35, 100, 30), formDerecha);

                e.Graphics.DrawString("ISR Retenido : ", fontTotal, Brushes.Black, new RectangleF(550, Detalle + 60, 150, 30), formIzquierda);
                e.Graphics.DrawString(txtResico.Text, fontTotal, Brushes.Black, new RectangleF(700, Detalle + 60, 100, 30), formDerecha);

                e.Graphics.DrawString("Total : ", fontTotal, Brushes.Black, new RectangleF(550, Detalle + 85, 150, 30), formIzquierda);
                e.Graphics.DrawString(txtTotal.Text, fontTotal, Brushes.Black, new RectangleF(700, Detalle + 85, 100, 30), formDerecha);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PD_PrintPage " + ex.Message);
            }
        }
        //Metodo para cargar los productos y poder utilizar los registros de los productos
        private DataTable CargaProductos(string cCodPrd)
        {
            DataTable dtProductos = new DataTable();
            try
            {
                SQL = "SELECT cCodPrd, cDesPrd FROM tbProducto WHERE cCodPrd='" + cCodPrd + "'";

                dtProductos = conexCompras.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaProductos " + ex.Message);
            }

            return dtProductos;
        }
        //Metodo para cargar los proveedores y poder utilizar los regitros de los proveedores
        void CargaProveedores()
        {
            try
            {
                SQL = "SELECT cCvePrv, cNomPrv from dbProveedores.dbo.tbProveedor ORDER BY cNomPrv";

                dtProveedores = conexCompras.select(SQL);
                cboProveedor.DataSource = null;
                cboProveedor.DataSource = dtProveedores;
                cboProveedor.DisplayMember = "cNomPrv";
                cboProveedor.ValueMember = "cCvePrv";
                cboProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaProveedores " + ex.Message);
            }
        }

        void LimpiarControles()
        {
            try
            {
                txtNumero.Text = string.Empty;
                txtEstado.Text = string.Empty;
                txtTotal.Text = string.Empty;
                txtSubtotal.Text = string.Empty;
                txtIva.Text = string.Empty;
                txtResico.Text = string.Empty;
                cboProveedor.SelectedIndex = -1;
                dgvProductos.DataSource = null;
                txtProducto.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtCosto.Text = string.Empty;
                dtpOrden.Value = DateTime.Now.Date;
                txtFactura.Text = string.Empty;
                dtpFactura.Value = DateTime.Now.Date;
                txtPorcentaje.Text = string.Empty;
                txtFolioFiscal.Text = string.Empty;
                cboTipo.SelectedIndex = -1;
                cboMetodo.SelectedIndex = -1;
                chkResico.Checked = false;
                dgvPagos.DataSource = null;
                txtTotalPagos.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LimpiarControles " + ex.Message);
            }
        }

        void HabilitaControles(int opcion)
        {
            try
            {
                if (opcion == 1) //Deshabilita Todos menos la busqueda
                {
                    dtpOrden.Enabled = false;
                    cboProveedor.Enabled = false;

                    txtProducto.Enabled = false;
                    btnProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    txtCosto.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    btnPedidos.Enabled = false;
                    dgvProductos.Enabled = false;

                    txtFactura.Enabled = false;
                    dtpFactura.Enabled = false;
                    cboTipo.Enabled = false;
                    txtPorcentaje.Enabled = false;
                    txtFolioFiscal.Enabled = false;
                    cboMetodo.Enabled = false;
                    chkResico.Enabled = false;

                    btnAgregarPago.Enabled = false;
                    txtBuscar.Enabled = true;
                }
                if (opcion == 2) //nuevo - modifica
                {
                    dtpOrden.Enabled = true;
                    cboProveedor.Enabled = true;

                    txtProducto.Enabled = true;
                    btnProducto.Enabled = true;
                    txtCantidad.Enabled = true;
                    txtCosto.Enabled = true;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = true;
                    btnPedidos.Enabled = true;
                    dgvProductos.Enabled = true;
                    cboTipo.Enabled = true;
                    btnAplicar.Enabled = true;
                    txtPorcentaje.Enabled = true;
                    cboMetodo.Enabled = true;
                    chkResico.Enabled = true;

                    txtFactura.Enabled = false;
                    dtpFactura.Enabled = false;
                    txtFolioFiscal.Enabled = false;

                    btnAgregarPago.Enabled = false;
                    txtBuscar.Enabled = false;
                }
                if (opcion == 3) //Termina
                {
                    dtpOrden.Enabled = false;
                    cboProveedor.Enabled = false;

                    txtProducto.Enabled = false;
                    btnProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    txtCosto.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    btnPedidos.Enabled = false;
                    dgvProductos.Enabled = false;
                    cboTipo.Enabled = false;
                    btnAplicar.Enabled = false;
                    txtPorcentaje.Enabled = false;
                    cboMetodo.Enabled = false;
                    chkResico.Enabled = false;

                    txtFactura.Enabled = true;
                    dtpFactura.Enabled = true;
                    txtFolioFiscal.Enabled = true;

                    btnAgregarPago.Enabled = false;
                    txtBuscar.Enabled = false;
                }
                if (opcion == 4) //Pagos
                {
                    dtpOrden.Enabled = false;
                    cboProveedor.Enabled = false;

                    txtProducto.Enabled = false;
                    btnProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    txtCosto.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    btnPedidos.Enabled = false;
                    dgvProductos.Enabled = false;
                    cboTipo.Enabled = false;
                    txtPorcentaje.Enabled = false;
                    btnAplicar.Enabled = false;

                    txtFactura.Enabled = false;
                    dtpFactura.Enabled = false;
                    txtFolioFiscal.Enabled = false;
                    cboMetodo.Enabled = false;
                    chkResico.Enabled = false;

                    txtBuscar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HabilitaControles " + ex.Message);
            }
        }

        void HabilitaBotones(int opcion)
        {
            try
            {
                if (opcion == 1)
                {
                    btnNuevo.Enabled = true;
                    btnModificar.Enabled = false;
                    btnTerminar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnDeshacer.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnSalir.Enabled = true;
                }
                if (opcion == 2) //Nuevo-modificar
                {
                    btnNuevo.Enabled = false;
                    btnModificar.Enabled = false;
                    btnTerminar.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnDeshacer.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnSalir.Enabled = false;
                }
                if (opcion == 3)  //Buscar
                {
                    btnNuevo.Enabled = true;
                    btnModificar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnImprimir.Enabled = true;
                    btnSalir.Enabled = true;
                    btnTerminar.Enabled = true;
                }
                if (opcion == 4) //terminar
                {
                    btnNuevo.Enabled = false;
                    btnModificar.Enabled = false;
                    btnTerminar.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnDeshacer.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnSalir.Enabled = false;
                }
                if (opcion == 5)
                {
                    btnNuevo.Enabled = false;
                    btnModificar.Enabled = false;
                    btnTerminar.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnDeshacer.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnSalir.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HabilitaBotones " + ex.Message);
            }
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            try
            {
                PPD.Document = PD;
                (PPD as Form).WindowState = FormWindowState.Maximized;
                PPD.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Imprimir " + ex.Message);
            }
        }

        private int ValidaNumeroOrden(int nNumOrd)
        {
            int OrdenBuscado = 0;

            try
            {
                SQL = "select nNumOrd from tbOrden where nNumOrd = " + nNumOrd;

                DataTable dtOrden = conexCompras.select(SQL);

                if (dtOrden.Rows.Count > 0)
                {
                    OrdenBuscado = Convert.ToInt32(dtOrden.Rows[0]["nNumOrd"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ValidaNumeroOrden " + ex.Message);
            }

            return OrdenBuscado;
        }

        private DataTable UltimoKardex(string cCodPrd)
        {
            DataTable dtKardex = new DataTable();

            try
            {
                SQL = "select Top 1 cCodPrd, nNumKdx, nExiKdx, nSdoKdx From tbKardex where cCodPrd = '" + cCodPrd + "' order by nNumKdx desc";
                dtKardex = conexCompras.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("UltimoKardex " + ex.Message);
            }

            return dtKardex;
        }

        private DataTable CargaOrdenes(int nNumOrd)
        {
            DataTable dtOrdenes = new DataTable();

            try
            {
                SQL = "SELECT nNumOrd as Orden, dFecOrd as Fecha, nEdoOrd as Estado, cPrvOrd, nSubOrd, nIvaOrd, nTotOrd, cFacord, dFecFac, cFolFis, nTpgOrd FROM tbOrden " +
                    "where nNumOrd=" + nNumOrd;

                dtOrdenes = conexCompras.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaOrdenes " + ex.Message);
            }

            return dtOrdenes;
        }

        private DataTable CargaOrdenesDetalle(int nNumOrd)
        {
            SQL = "Select nNumOrd as Orden, nCtdOrd as Cantidad, det.cCodPrd as Codigo, cDesPrd as Descripcion, nCtoOrd as Costo, nCtdOrd * nCtoOrd as Importe, nNumPed as Pedido " +
                "From tbOrdenDetalle det inner join tbProducto prd on det.cCodPrd = prd.cCodPrd  " +
                "Where nNumOrd=" + nNumOrd + " " +
                "Order by det.cCodPrd";

            DataTable dtOrdenesDetalle = conexCompras.select(SQL);

            return dtOrdenesDetalle;
        }

        private DataTable CargaPagos(int nNumOrd)
        {
            DataTable dtPagos = new DataTable();

            try
            {
                SQL = "SELECT dFecPago as Fecha, nImpPago as Importe, cFolFisPago as FolioFiscal FROM tbComplementoPago " +
                    "where nNumOrd=" + nNumOrd;

                dtPagos = conexCompras.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaPagos " + ex.Message);
            }

            return dtPagos;
        }

        private DataTable CargaResico(int nNumOrd)
        {
            DataTable dtResico = new DataTable();

            try
            {
                SQL = "SELECT nMetPago, nImpResico, nPorcResico FROM tbOrdenResico " +
                    "where nNumOrd=" + nNumOrd;

                dtResico = conexCompras.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaResico " + ex.Message);
            }

            return dtResico;
        }

        private int NuevoNumeroOrden()
        {
            int FolioSiguiente = 1;

            try
            {
                SQL = "Select Top 1 nNumOrd From tbOrden Order by nNumOrd desc";

                DataTable dtultimoNumero = conexCompras.select(SQL);

                if (dtultimoNumero.Rows.Count > 0)
                {
                    int UltimoFolio = Convert.ToInt32(dtultimoNumero.Rows[0]["nNumOrd"]);
                    FolioSiguiente = UltimoFolio + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NuevoNumeroOrden " + ex.Message);
            }

            return FolioSiguiente;
        }

        private string BuscaFolioFiscal(string ffiscal)
        {
            string FolioFiscal = string.Empty;

            try
            {
                SQL = "Select cFolFis From tbOrden Where cFolFis='" + ffiscal + "'";

                DataTable dtFolioFiscal = conexCompras.select(SQL);

                if (dtFolioFiscal.Rows.Count > 0)
                {
                    FolioFiscal = dtFolioFiscal.Rows[0]["cFolFis"].ToString()!;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BuscaFolioFiscal " + ex.Message);
            }

            return FolioFiscal;
        }

        private bool BuscaFactura(string Factura, string Proveedor)
        {
            bool Existe = false;

            try
            {
                SQL = "Select cNumFac From tbFacturacion Where cNumFac='" + Factura + "' and cPrvFac='" + Proveedor + "'";

                DataTable dtFactura = conexCompras.select(SQL);

                if (dtFactura.Rows.Count > 0)
                {
                    Existe = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BuscaFactura " + ex.Message);
            }

            return Existe;
        }

        private byte DiasProveedor(string Proveedor)
        {
            byte Dias = 0;

            try
            {
                SQL = "Select cCvePrv, nDiaPrv From dbProveedores.dbo.tbProveedor Where cCvePrv = '" + Proveedor + "'";

                DataTable dtDias = conexCompras.select(SQL);

                if (dtDias.Rows.Count > 0)
                {
                    Dias = Convert.ToByte(dtDias.Rows[0]["nDiaPrv"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DiasProveedor " + ex.Message);
            }

            return Dias;
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                btnAgregar.Enabled = false;
                txtDescripcion.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtCosto.Text = string.Empty;
                DataTable dtProducto = new DataTable();
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else if ((char)e.KeyChar == '-')
                {
                }
                else if (char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '*')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '+')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '/')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '.')
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Space)
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtProducto.Text != "")
                    {
                        string cCodPrd = txtProducto.Text;
                        dtProducto.Clear();
                        dtProducto = CargaProductos(cCodPrd);

                        if (dtProducto.Rows.Count > 0)
                        {
                            string cDesPrd = dtProducto.Rows[0]["cDesPrd"].ToString()!;
                            txtDescripcion.Text = cDesPrd;

                            txtCantidad.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Producto no encontrado");
                            txtDescripcion.Text = string.Empty;
                            txtCantidad.Text = string.Empty;
                            txtCosto.Text = string.Empty;
                            txtProducto.Focus();
                            txtProducto.SelectAll();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtProducto_KeyPress " + ex.Message);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                btnAgregar.Enabled = false;
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '-')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '*')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '+')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '/')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '.')
                {
                    if (txtCantidad.Text.Contains("."))
                    {
                        e.Handled = true;
                    }
                }
                else if ((Keys)e.KeyChar == Keys.Space)
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtProducto.Text != "" && txtDescripcion.Text != "" && txtCantidad.Text != "0" && txtCantidad.Text != "")
                    {
                        txtCosto.Text = string.Empty;
                        txtCosto.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtCantidad_KeyPress " + ex.Message);
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataTable dtOrden = new DataTable();
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '*')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '+')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '-')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '/')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '.')
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Space)
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtBuscar.Text != "")
                    {
                        int nNumOrd = Convert.ToInt32(txtBuscar.Text);

                        dtOrden.Clear();
                        dtOrden = CargaOrdenes(nNumOrd);

                        if (dtOrden.Rows.Count > 0)
                        {
                            txtNumero.Text = nNumOrd.ToString();
                            DateTime dtFecOrd = DateTime.Parse(dtOrden.Rows[0]["Fecha"].ToString()!);
                            dtpOrden.Value = dtFecOrd;
                            string cPrvOrd = dtOrden.Rows[0]["cPrvOrd"].ToString()!;
                            cboProveedor.SelectedValue = cPrvOrd;
                            int nEdoVal = Convert.ToInt32(dtOrden.Rows[0]["Estado"]);
                            if (nEdoVal == 1)
                            {
                                txtEstado.Text = "Emitido";
                            }
                            if (nEdoVal == 2)
                            {
                                txtEstado.Text = "Entregado";
                            }
                            if (nEdoVal == 3)
                            {
                                txtEstado.Text = "Cancelado";
                            }
                            if (nEdoVal == 4)
                            {
                                txtEstado.Text = "Traspaso";
                            }
                            if (nEdoVal == 5)
                            {
                                txtEstado.Text = "Devolucion Prov";
                            }

                            dtProductosGrid.Rows.Clear();
                            dtProductosGrid = CargaOrdenesDetalle(nNumOrd);
                            dgvProductos.DataSource = null;
                            dgvProductos.DataSource = dtProductosGrid;
                            dgvProductos.Columns["Orden"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Cantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Costo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Importe"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Descripcion"].Visible = false;

                            string Factura = dtOrden.Rows[0]["cFacOrd"].ToString()!;
                            txtFactura.Text = Factura;
                            DateTime dFecFac = DateTime.Parse(dtOrden.Rows[0]["dFecFac"].ToString()!);
                            dtpFactura.Value = dFecFac;

                            int Tipo = Convert.ToInt32(dtOrden.Rows[0]["nTpgOrd"]);
                            cboTipo.SelectedIndex = Tipo - 1;

                            txtFolioFiscal.Text = dtOrden.Rows[0]["cFolFis"].ToString()!;

                            decimal Subtotal = Convert.ToDecimal(dtOrden.Rows[0]["nSubOrd"]);
                            txtSubtotal.Text = Subtotal.ToString("F2");

                            decimal Iva = Convert.ToDecimal(dtOrden.Rows[0]["nIvaOrd"]);
                            txtIva.Text = Iva.ToString("F2");

                            decimal Total = Convert.ToDecimal(dtOrden.Rows[0]["nTotOrd"]);
                            txtTotal.Text = Total.ToString("F2");

                            DataTable dtResico = new DataTable();
                            dtResico = CargaResico(nNumOrd);

                            if (dtResico.Rows.Count > 0)
                            {
                                int Metodo = Convert.ToInt32(dtResico.Rows[0]["nMetPago"]);
                                cboMetodo.SelectedIndex = Metodo;

                                if (Metodo == 0)
                                {
                                    chkResico.Checked = false;
                                }
                                if (Metodo == 1)
                                {
                                    chkResico.Checked = true;
                                }

                                decimal Resico = Convert.ToDecimal(dtResico.Rows[0]["nImpResico"]);
                                txtResico.Text = Resico.ToString("F2");

                                Total = Total - Resico;
                                txtTotal.Text = Total.ToString("F2");
                            }
                            else
                            {
                                cboMetodo.SelectedIndex = 0;
                                chkResico.Checked = false;
                                decimal Resico = 0;
                                txtResico.Text = Resico.ToString("F2");
                            }

                            DataTable dtPagos = new DataTable();
                            dtPagos = CargaPagos(nNumOrd);

                            dgvPagos.DataSource = null;

                            decimal TotalPagos = 0;
                            if (dtPagos.Rows.Count > 0)
                            {
                                dgvPagos.DataSource = dtPagos;
                                foreach (DataRow dr in dtPagos.Rows)
                                {
                                    decimal filaPago = Convert.ToDecimal(dr["Importe"]);
                                    TotalPagos = TotalPagos + filaPago;
                                }
                            }

                            txtTotalPagos.Text = TotalPagos.ToString("F2");

                            decimal TotalOrden = Convert.ToDecimal(txtTotal.Text);

                            if (TotalOrden > TotalPagos)
                                btnAgregarPago.Enabled = true;
                            if (TotalOrden == TotalPagos)
                                btnAgregarPago.Enabled = false;

                            HabilitaBotones(3);

                            txtBuscar.Text = string.Empty;
                            dgvProductos.Enabled = true;

                            if (nEdoVal == 1)
                            {
                                btnTerminar.Enabled = true;
                                btnModificar.Enabled = true;
                                btnCancelar.Enabled = true;
                            }
                            else if (nEdoVal > 1)
                            {
                                btnTerminar.Enabled = false;
                                btnModificar.Enabled = false;
                                btnCancelar.Enabled = false;
                            }
                        }
                        else
                        {
                            LimpiarControles();
                            MessageBox.Show("Folio de vale incorrecto");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtBuscar_KeyPress " + ex.Message);
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                btnAgregar.Enabled = false;
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '-')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '*')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '+')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '/')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '.')
                {
                    if (txtCantidad.Text.Contains("."))
                    {
                        e.Handled = true;
                    }
                }
                else if ((Keys)e.KeyChar == Keys.Space)
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtProducto.Text != "" && txtCantidad.Text != "0" && txtCantidad.Text != "" && txtCosto.Text != "0" && txtCosto.Text != "")
                    {
                        btnAgregar.Enabled = true;
                        btnAgregar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtCosto_KeyPress " + ex.Message);
            }
        }

        private void txtFolioFiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtFolioFiscal.Text != "")
                    {
                        string CadenaEntera = txtFolioFiscal.Text;
                        int index = CadenaEntera.IndexOf("id=");
                        string FolioFiscal = CadenaEntera.Substring(index + 3, 36);
                        txtFolioFiscal.Text = FolioFiscal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtFolioFiscal_KeyPress " + ex.Message);
            }
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtFactura_KeyPress " + ex.Message);
            }
        }

        private void chkResico_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkResico.Focused)
                {
                    if (dgvProductos.Rows.Count > 0 && txtSubtotal.Text != string.Empty && txtSubtotal.Text != "0")
                    {
                        if (chkResico.Checked)
                        {
                            decimal nSubTotal = Convert.ToDecimal(txtSubtotal.Text);
                            decimal nIva = Convert.ToDecimal(txtIva.Text);
                            decimal nResico = nSubTotal * IsrRetenido;
                            decimal Total = nSubTotal + nIva - nResico;
                            txtTotal.Text = Total.ToString("F2");
                            txtResico.Text = nResico.ToString("F2");
                        }
                        if (chkResico.Checked == false)
                        {
                            decimal nSubTotal = Convert.ToDecimal(txtSubtotal.Text);
                            decimal nIva = Convert.ToDecimal(txtIva.Text);
                            decimal Total = nSubTotal + nIva;
                            txtTotal.Text = Total.ToString("F2");
                            txtResico.Text = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("chkResico_CheckedChanged " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text != "" && txtProducto.Text != "" && txtCantidad.Text != "" && txtDescripcion.Text != "" && txtCosto.Text != "")
                {
                    int Orden = Convert.ToInt32(txtNumero.Text);
                    string Codigo = txtProducto.Text;
                    decimal Cantidad = Convert.ToDecimal(txtCantidad.Text);
                    string Descripcion = txtDescripcion.Text;
                    decimal Costo = Convert.ToDecimal(txtCosto.Text);
                    decimal Importe = Costo * Cantidad;

                    bool bExisteProducto = false;
                    foreach (DataGridViewRow fila in dgvProductos.Rows)
                    {
                        string codigoFila = fila.Cells["codigo"].Value.ToString()!;

                        if (codigoFila == Codigo)
                        {
                            bExisteProducto = true;
                            break;
                        }
                    }

                    if (bExisteProducto)
                    {
                        MessageBox.Show("Producto ya agregado");
                        txtProducto.Text = string.Empty;
                        txtCantidad.Text = string.Empty;
                        txtDescripcion.Text = string.Empty;
                        txtCosto.Text = string.Empty;
                        txtProducto.Focus();

                        return;
                    }

                    DataRow rowProducto = dtProductosGrid.NewRow();
                    rowProducto["orden"] = Orden;
                    rowProducto["Cantidad"] = Cantidad;
                    rowProducto["Codigo"] = Codigo;
                    rowProducto["Descripcion"] = Descripcion;
                    rowProducto["Costo"] = Costo;
                    rowProducto["Importe"] = Importe;
                    rowProducto["Pedido"] = 0;

                    dtProductosGrid.Rows.Add(rowProducto);

                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = dtProductosGrid;
                    dgvProductos.Columns["Orden"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvProductos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvProductos.Columns["Pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    Decimal nSubTotal = 0;
                    foreach (DataRow dr in dtProductosGrid.Rows)
                    {
                        nSubTotal = nSubTotal + Convert.ToDecimal(dr["Importe"]);
                    }

                    if (dtProductosGrid.Rows.Count > 0)
                    {
                        btnQuitar.Enabled = true;
                    }

                    txtSubtotal.Text = nSubTotal.ToString("F2");
                    decimal nIva = nSubTotal * Convert.ToDecimal(0.16);
                    txtIva.Text = nIva.ToString("F2");
                    decimal Total = nSubTotal + nIva;
                    txtTotal.Text = Total.ToString("F2");
                    txtResico.Text = "0";

                    txtProducto.Text = string.Empty;
                    txtCantidad.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtCosto.Text = string.Empty;
                    txtProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregar_Click " + ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                printDocument1.PrinterSettings = ps;
                printDocument1.PrintPage += Imprimir;
                printDocument1.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnImprimir_Click " + ex.Message);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int FilaSeleccionadaGrid = dgvProductos.CurrentRow.Index;
                string cCodPrd = dgvProductos.Rows[FilaSeleccionadaGrid].Cells["Codigo"].Value.ToString()!;

                if (MessageBox.Show("Esta seguro de quitar este producto???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataRow filaEliminar = dtProductosGrid.Select("Codigo ='" + cCodPrd + "'").FirstOrDefault()!;
                    dtProductosGrid.Rows.Remove(filaEliminar);

                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = dtProductosGrid;
                    dgvProductos.Columns["Orden"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvProductos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    Decimal nSubTotal = 0;
                    foreach (DataRow dr in dtProductosGrid.Rows)
                    {
                        nSubTotal = nSubTotal + Convert.ToDecimal(dr["Importe"]);
                    }

                    if (dtProductosGrid.Rows.Count > 0)
                    {
                        btnQuitar.Enabled = true;
                    }
                    else
                    {
                        btnQuitar.Enabled = false;
                    }

                    txtSubtotal.Text = nSubTotal.ToString("F2");

                    decimal nIva = 0;
                    decimal nTotal = 0;
                    if (nSubTotal > 0)
                    {
                        nIva = nSubTotal * Convert.ToDecimal(0.16);
                        nTotal = nSubTotal + nIva;
                    }

                    txtIva.Text = nIva.ToString("F2");
                    txtTotal.Text = nTotal.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnQuitar_Click " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text != "" && dgvProductos.Rows.Count > 0 && cboProveedor.SelectedIndex > -1)
                {
                    int nNumOrd = Convert.ToInt32(txtNumero.Text);

                    DataTable dtCancelaOrden = new DataTable();
                    dtCancelaOrden = CargaOrdenes(nNumOrd);

                    DataTable dtCancelaDetalle = new DataTable();
                    dtCancelaDetalle = CargaOrdenesDetalle(nNumOrd);
                    int nDetalle = dtCancelaDetalle.Rows.Count;

                    if (dtCancelaDetalle.Rows.Count > 0)
                    {
                        Byte nEdoOrd = Convert.ToByte(dtCancelaDetalle.Rows[0]["nEdoord"]);

                        if (nEdoOrd != 1)
                        {
                            MessageBox.Show("La orden no puede ser cancelada porque no esta activa");
                            return;
                        }
                        if (MessageBox.Show("Está seguro de cancelar esta orden???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {

                            SQL = "update tbOrden set nedoord=3 where nnumord= " + nNumOrd;

                            bool bCancelaOrden = conexCompras.ejecSql(SQL);

                            SQL = "update tbOrdenDetalle set nedoord=3 where nnumord= " + nNumOrd;

                            bool bCancelaDetalle = conexCompras.ejecSql(SQL);

                            foreach (DataRow dr in dtCancelaDetalle.Rows)
                            {
                                string cCodPrd = dr["Codigo"].ToString()!;
                                int nNumPed = Convert.ToInt32(dr["Pedido"].ToString());

                                if (nNumPed > 0)
                                {
                                    SQL = "Update tbPedidoDetalle Set nEdoPed = 1, nNumOrd = 0 Where nNumPed = " + nNumPed + " And cCodPrd='" + cCodPrd + "'";
                                    conexCompras.ejecSql(SQL);
                                }
                            }

                            if (bCancelaOrden && bCancelaDetalle)
                            {
                                MessageBox.Show("Orden cancelada correctamente");
                                LimpiarControles();
                                HabilitaBotones(1);
                                HabilitaControles(1);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo cancelar correctamente la orden");
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnCancelar_Click " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text != "" && dgvProductos.Rows.Count > 0 && cboProveedor.SelectedIndex > -1)
                {
                    bModifica = true;
                    bNuevo = false;
                    bTermina = false;

                    int nNumOrd = Convert.ToInt32(txtNumero.Text);

                    dtOrdenModificar = CargaOrdenes(nNumOrd);

                    if (dtOrdenModificar.Rows.Count > 0)
                    {
                        int nEdoOrd = Convert.ToInt32(dtOrdenModificar.Rows[0]["Estado"]);
                        if (nEdoOrd == 1)
                        {
                            dtDetalleModificar = CargaOrdenesDetalle(nNumOrd);
                            HabilitaControles(2);
                            HabilitaBotones(2);
                        }
                        else
                        {
                            MessageBox.Show("Solo se puede modificar una orden Emitida");
                            return;
                        }
                        txtProducto.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo consultar la orden correctamente o no hay conexión al servidor");
                    }
                }
                else
                {
                    MessageBox.Show("No ha seleccionado la orden o falta en cargar algun dato");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnModificar_Click " + ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarControles();
                HabilitaControles(2);
                HabilitaBotones(2);
                txtEstado.Text = "Emitido";
                int Folio = NuevoNumeroOrden();
                txtNumero.Text = Folio.ToString();
                dtProductosGrid.Clear();
                btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;
                bNuevo = true;
                bModifica = false;
                bTermina = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnNuevo_Click " + ex.Message);
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                bTermina = true;
                bNuevo = false;
                bModifica = false;
                HabilitaBotones(4);
                HabilitaControles(3);
                txtFolioFiscal.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnTerminar_Click " + ex.Message);
            }
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarControles();
                HabilitaControles(1);
                HabilitaBotones(1);
                dtProductosGrid.Clear();
                dtOrdenModificar.Clear();
                dtDetalleModificar.Clear();
                bTermina = false;
                bNuevo = false;
                bModifica = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDeshacer_Click " + ex.Message);
            }
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtProducto = new DataTable();

                CodigoBuscar = string.Empty;
                frmBuscaProducto modalBusca = new frmBuscaProducto(this);
                modalBusca.ConexBuscaProd = conexCompras;
                modalBusca.ShowDialog();
                CodigoBuscar = modalBusca.Codigo;

                if (CodigoBuscar != "")
                {
                    txtProducto.Text = CodigoBuscar;
                    dtProducto.Clear();
                    dtProducto = CargaProductos(CodigoBuscar);

                    if (dtProducto.Rows.Count > 0)
                    {
                        string cDesPrd = dtProducto.Rows[0]["cDesPrd"].ToString()!;
                        txtDescripcion.Text = cDesPrd;

                        txtCantidad.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado");
                        txtDescripcion.Text = string.Empty;
                        txtCantidad.Text = string.Empty;
                        txtCosto.Text += string.Empty;
                        txtProducto.Focus();
                        txtProducto.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnProducto_Click " + ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bNuevo)
                {
                    if (txtNumero.Text != "" && dgvProductos.Rows.Count > 0 && cboProveedor.SelectedIndex > -1 && cboTipo.SelectedIndex > -1 && cboMetodo.SelectedIndex > -1)
                    {
                        if (MessageBox.Show("Ya reviso que estén correctos los datos de su orden???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            int nNumOrd = Convert.ToInt32(txtNumero.Text);
                            byte nCveEmp = 2;
                            string cPrvOrd = cboProveedor.SelectedValue!.ToString()!;
                            DateTime dFecOrd = dtpOrden.Value;
                            decimal nSubOrd = Convert.ToDecimal(txtSubtotal.Text);
                            decimal nIvaOrd = Convert.ToDecimal(txtIva.Text);
                            decimal nTotOrd = nSubOrd + nIvaOrd;
                            int nEdoOrd = 1;
                            string cFacOrd = "0";
                            DateTime dFecFac = dtpOrden.Value;
                            byte nPgoOrd = Convert.ToByte(cboTipo.SelectedIndex + 1);
                            byte nTpgOrd = Convert.ToByte(cboTipo.SelectedIndex + 1);
                            int nPolPol = 0;
                            string cFolFis = "0";
                            string cObsOrd = "Sin Observaciones";

                            int nExisteOrden = ValidaNumeroOrden(nNumOrd);

                            if (nNumOrd == nExisteOrden)
                            {
                                nNumOrd = nNumOrd + 1;
                            }

                            //graba en tabla orden
                            SQL = "Insert Into tbOrden (nNumOrd, nCveEmp, cPrvOrd, dFecOrd, nSubOrd, nIvaOrd, nTotOrd, nEdoOrd, cFacOrd, dFecFac, nPgoOrd, nTpgOrd, nPolPol, cFolFis, cObsOrd) " +
                                "Values (" + nNumOrd + "," + nCveEmp + ",'" + cPrvOrd + "','" + dFecOrd.ToString("yyyyMMdd") + "'," + nSubOrd + "," + nIvaOrd +
                                ", " + nTotOrd + "," + nEdoOrd + ",'" + cFacOrd + "','" + dFecFac.ToString("yyyyMMdd") +
                                "'," + nPgoOrd + "," + nTpgOrd + "," + nPolPol + ",'" + cFolFis + "','" + cObsOrd + "')";

                            bool bInsertOrden = conexCompras.ejecSql(SQL);

                            if (bInsertOrden)
                            {
                                foreach (DataRow item in dtProductosGrid.Rows)
                                {
                                    decimal nCtdOrd = Convert.ToDecimal(item["Cantidad"].ToString());
                                    string cCodPrd = item["Codigo"].ToString()!;
                                    decimal nCtoOrd = Convert.ToDecimal(item["Costo"].ToString());
                                    int nNumPed = Convert.ToInt32(item["Pedido"].ToString());
                                    string cSerOrd = "0";
                                    int nFolBit = 0;

                                    //graba en tabla valesdetalle
                                    SQL = "Insert Into tbOrdenDetalle (nNumOrd, cPrvOrd, nCtdOrd, cCodPrd, nCtoOrd, nNumPed, cSerOrd, nFolBit, nEdoOrd, cFacOrd, dFecFac) " +
                                        "Values(" + nNumOrd + ",'" + cPrvOrd + "'," + nCtdOrd + ",'" + cCodPrd + "'," + nCtoOrd + "," + nNumPed + ",'" + cSerOrd + "'," + nFolBit + "," + nEdoOrd + ",'" + cFacOrd + "','" + dFecFac.ToString("yyyyMMdd") + "')";

                                    conexCompras.ejecSql(SQL);
                                }

                                if (chkResico.Checked)
                                {
                                    decimal nResico = Convert.ToDecimal(txtResico.Text);

                                    SQL = "Insert Into tbOrdenResico(nNumOrd, nMetPago, nImpResico, nPorcResico) " +
                                        "Values(" + nNumOrd + ",1," + nResico + "," + IsrRetenido + ")";

                                    conexCompras.ejecSql(SQL);
                                }
                            }


                            //valida registros grabados
                            bool bExisteOrden = false;
                            bool bExisteDetalle = false;

                            try
                            {
                                DataTable dtOrden = new DataTable();
                                SQL = "SELECT nNumOrd, dFecOrd, nEdoOrd, cPrvOrd, nSubOrd, nIvaOrd, nTotOrd FROM tbOrden where nNumOrd=" + nNumOrd;

                                dtOrden = conexCompras.select(SQL);

                                if (dtOrden.Rows.Count > 0)
                                {
                                    bExisteOrden = true;
                                }

                                SQL = "SELECT nNumOrd, cCodPrd, nCtdOrd, nEdoOrd  FROM tbOrdenDetalle where nNumOrd=" + nNumOrd;

                                DataTable dtDetalle = conexCompras.select(SQL);

                                int nDetalle = dtDetalle.Rows.Count;

                                if (nDetalle == dtProductosGrid.Rows.Count)
                                {
                                    bExisteDetalle = true;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            if (bExisteOrden && bExisteDetalle)
                            {
                                MessageBox.Show("Registros grabados correctamente");
                            }
                            else
                            {
                                MessageBox.Show("Los registros no se grabaron correctamente");
                            }

                            foreach (DataRow dr in dtProductosGrid.Rows)
                            {
                                string cCodPrd = dr["Codigo"].ToString()!;
                                int nNumPed = Convert.ToInt32(dr["Pedido"].ToString());

                                if (nNumPed > 0)
                                {
                                    string SQLTerminaPedido = "Update tbPedidoDetalle Set nEdoPed = 5, nNumOrd = " + nNumOrd + " Where nNumPed = " + nNumPed + " And cCodPrd='" + cCodPrd + "'";
                                    conexCompras.ejecSql(SQL);
                                }
                            }

                            LimpiarControles();
                            HabilitaBotones(1);
                            HabilitaControles(1);
                            bModifica = false;
                            bNuevo = false;
                            bTermina = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta capturar algún dato");
                        return;
                    }
                }

                if (bModifica)
                {
                    int nNumOrd = Convert.ToInt32(dtOrdenModificar.Rows[0]["Orden"]);
                    int nEdoOrd = Convert.ToInt32(dtOrdenModificar.Rows[0]["Estado"]);

                    if (nEdoOrd == 1)
                    {
                        if (txtNumero.Text != "" && dgvProductos.Rows.Count > 0 && cboProveedor.SelectedIndex > -1 && cboTipo.SelectedIndex > -1)
                        {
                            if (MessageBox.Show("Ya reviso que estén correctos los datos de su orden???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                //primero borra los datos actuales y despues inserta el vale ya corregido
                                SQL = "Delete from tbOrdendetalle where nnumord=" + nNumOrd;
                                bool bEliminaDetalle = conexCompras.ejecSql(SQL);

                                SQL = "Delete from tbOrden where nnumord=" + nNumOrd;
                                bool bEliminaOrden = conexCompras.ejecSql(SQL);

                                if (!bEliminaDetalle || !bEliminaOrden)
                                {
                                    MessageBox.Show("No se puede realizar la modificación correctamente");
                                    return;
                                }

                                DataTable dtModificaDetalle = new DataTable();
                                dtModificaDetalle = CargaOrdenesDetalle(nNumOrd);

                                foreach (DataRow dr in dtModificaDetalle.Rows)
                                {
                                    string cCodPrd = dr["Codigo"].ToString()!;
                                    int nNumPed = Convert.ToInt32(dr["Pedido"].ToString());

                                    if (nNumPed > 0)
                                    {
                                        SQL = "Update tbPedidoDetalle Set nEdoPed = 1, nNumOrd = 0 Where nNumPed = " + nNumPed + " And cCodPrd='" + cCodPrd + "'";
                                        conexCompras.ejecSql(SQL);
                                    }
                                }

                                byte nCveEmp = 2;
                                string cPrvOrd = cboProveedor.SelectedValue!.ToString()!;
                                DateTime dFecOrd = dtpOrden.Value;
                                decimal nSubOrd = Convert.ToDecimal(txtSubtotal.Text);
                                decimal nIvaOrd = Convert.ToDecimal(txtIva.Text);
                                decimal nTotOrd = nSubOrd + nIvaOrd;
                                string cFacOrd = "0";
                                DateTime dFecFac = dtpOrden.Value;
                                byte nPgoOrd = Convert.ToByte(cboTipo.SelectedIndex + 1);
                                byte nTpgOrd = Convert.ToByte(cboTipo.SelectedIndex + 1);
                                int nPolPol = 0;
                                string cFolFis = "0";
                                string cObsOrd = "Sin Observaciones";

                                int nExisteOrden = ValidaNumeroOrden(nNumOrd);

                                if (nNumOrd == nExisteOrden)
                                {
                                    nNumOrd = nNumOrd + 1;
                                }

                                //graba en tabla orden
                                SQL = "Insert Into tbOrden (nNumOrd, nCveEmp, cPrvOrd, dFecOrd, nSubOrd, nIvaOrd, nTotOrd, nEdoOrd, cFacOrd, dFecFac, nPgoOrd, nTpgOrd, nPolPol, cFolFis, cObsOrd) " +
                                    "Values (" + nNumOrd + "," + nCveEmp + ",'" + cPrvOrd + "','" + dFecOrd.ToString("yyyyMMdd") + "'," + nSubOrd + "," + nIvaOrd +
                                    ", " + nTotOrd + "," + nEdoOrd + ",'" + cFacOrd + "','" + dFecFac.ToString("yyyyMMdd") +
                                    "'," + nPgoOrd + "," + nTpgOrd + "," + nPolPol + ",'" + cFolFis + "','" + cObsOrd + "')";

                                bool bInsertOrden = conexCompras.ejecSql(SQL);

                                if (bInsertOrden)
                                {
                                    foreach (DataRow item in dtProductosGrid.Rows)
                                    {
                                        decimal nCtdOrd = Convert.ToDecimal(item["Cantidad"].ToString());
                                        string cCodPrd = item["Codigo"].ToString()!;
                                        decimal nCtoOrd = Convert.ToDecimal(item["Costo"].ToString());
                                        int nNumPed = Convert.ToInt32(item["Pedido"].ToString());
                                        string cSerOrd = "0";
                                        int nFolBit = 0;

                                        //graba en tabla valesdetalle
                                        SQL = "Insert Into tbOrdenDetalle (nNumOrd, cPrvOrd, nCtdOrd, cCodPrd, nCtoOrd, nNumPed, cSerOrd, nFolBit, nEdoOrd, cFacOrd, dFecFac) " +
                                            "Values(" + nNumOrd + ",'" + cPrvOrd + "'," + nCtdOrd + ",'" + cCodPrd + "'," + nCtoOrd + "," + nNumPed + ",'" + cSerOrd + "'," + nFolBit + "," + nEdoOrd + ",'" + cFacOrd + "','" + dFecFac.ToString("yyyyMMdd") + "')";

                                        conexCompras.ejecSql(SQL);
                                    }

                                    if (chkResico.Checked)
                                    {
                                        decimal nResico = Convert.ToDecimal(txtResico.Text);

                                        SQL = "Insert Into tbOrdenResico(nNumOrd, nMetPago, nImpResico, nPorcResico) " +
                                            "Values(" + nNumOrd + ",1," + nResico + "," + IsrRetenido + ")";
                                        conexCompras.ejecSql(SQL);
                                    }
                                }

                                //valida registros grabados
                                bool bExisteOrden = false;
                                bool bExisteDetalle = false;

                                try
                                {

                                    SQL = "SELECT nNumOrd, dFecOrd, nEdoOrd, cPrvOrd, nSubOrd, nIvaOrd, nTotOrd FROM tbOrden where nNumOrd=" + nNumOrd;

                                    DataTable dtOrden = conexCompras.select(SQL);

                                    if (dtOrden.Rows.Count > 0)
                                    {
                                        bExisteOrden = true;
                                    }

                                    SQL = "SELECT nNumOrd, cCodPrd, nCtdOrd, nEdoOrd FROM tbOrdenDetalle where nNumOrd=" + nNumOrd;

                                    DataTable dtDetalle = conexCompras.select(SQL);

                                    int nDetalle = dtDetalle.Rows.Count;

                                    if (nDetalle == dtProductosGrid.Rows.Count)
                                    {
                                        bExisteDetalle = true;
                                    }
                                }
                                catch (Exception ex)
                                {
                                }

                                if (bExisteOrden && bExisteDetalle)
                                {
                                    MessageBox.Show("Registros modificados correctamente");
                                }
                                else
                                {
                                    MessageBox.Show("Los registros no se modificaron correctamente");
                                }

                                LimpiarControles();
                                HabilitaBotones(1);
                                HabilitaControles(1);
                                bModifica = false;
                                bNuevo = false;
                                bTermina = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("falta capturar algún dato");
                            return;
                        }
                    }
                }

                if (bTermina)
                {
                    if (txtNumero.Text != "" && dgvProductos.Rows.Count > 0 && cboProveedor.SelectedIndex > -1 && txtFactura.Text != "0" && txtFactura.Text != string.Empty && txtFolioFiscal.Text != "0" && txtFolioFiscal.Text != string.Empty)
                    {
                        if (MessageBox.Show("Está seguro de Terminar esta orden???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            if (txtFolioFiscal.Text.Length != 36)
                            {
                                MessageBox.Show("El formato del folio fiscal no es correcto");
                                return;
                            }

                            string cValidaFolio = BuscaFolioFiscal(txtFolioFiscal.Text);
                            if (cValidaFolio == txtFolioFiscal.Text)
                            {
                                MessageBox.Show("El folio fiscal ya fue capturado anteriormente");
                                return;
                            }

                            bool cValidaFactura = BuscaFactura(txtFactura.Text, cboProveedor.SelectedValue!.ToString()!);
                            if (cValidaFactura)
                            {
                                MessageBox.Show("El folio de factura ya fue capturado anteriormente");
                                return;
                            }

                            if (dtpFactura.Value > DateTime.Now.Date)
                            {
                                MessageBox.Show("La fecha de factura no puede ser mayor a la actual");
                                return;
                            }

                            int nNumOrd = Convert.ToInt32(txtNumero.Text);

                            DataTable dtTerminaOrden = new DataTable();
                            dtTerminaOrden = CargaOrdenes(nNumOrd);

                            if (dtTerminaOrden.Rows.Count > 0)
                            {
                                byte nEdoOrd = Convert.ToByte(dtTerminaOrden.Rows[0]["Estado"]);
                                string cPrvOrd = dtTerminaOrden.Rows[0]["cPrvOrd"].ToString()!;
                                string cFacOrd = txtFactura.Text;
                                DateTime dFecFac = dtpFactura.Value;

                                if (dFecFac.Date.ToString("dd/MM/yyyy") == "01/01/1900")
                                {
                                    MessageBox.Show("No ha seleccionado la fecha de la factura");
                                    return;
                                }

                                byte nCveEmp = 2;

                                if (nEdoOrd == 1)
                                {
                                    DataTable dtTerminaDetalle = new DataTable();
                                    dtTerminaDetalle = CargaOrdenesDetalle(nNumOrd);

                                    int nFilasDetalle = dtTerminaDetalle.Rows.Count;
                                    int nFilasGrid = dgvProductos.Rows.Count;

                                    if (nFilasDetalle == nFilasGrid)
                                    {
                                        foreach (DataRow dr in dtTerminaDetalle.Rows)
                                        {
                                            string cCodPrd = dr["Codigo"].ToString()!;
                                            decimal nCtdOrd = Convert.ToDecimal(dr["Cantidad"].ToString());
                                            decimal nCtoOrd = Convert.ToDecimal(dr["Costo"].ToString());
                                            decimal nImporte = nCtdOrd * nCtoOrd;
                                            byte nTpoKdx = 1;
                                            int nNumPed = Convert.ToInt32(dr["Pedido"].ToString());

                                            int NumeroSiguiente = 0;
                                            decimal SaldoSiguiente = 0;
                                            decimal ExistenciaSiguiente = 0;

                                            int UltimoNumero = 0;
                                            decimal UltimoSaldo = 0;
                                            decimal UltimaExistencia = 0;

                                            DataTable dtUltimoKardex = new DataTable();
                                            dtUltimoKardex = UltimoKardex(cCodPrd);

                                            if (dtUltimoKardex.Rows.Count > 0)
                                            {
                                                UltimoNumero = Convert.ToInt32(dtUltimoKardex.Rows[0]["nNumKdx"]);
                                                UltimoSaldo = Convert.ToDecimal(dtUltimoKardex.Rows[0]["nSdoKdx"]);
                                                UltimaExistencia = Convert.ToDecimal(dtUltimoKardex.Rows[0]["nExiKdx"]);

                                                NumeroSiguiente = UltimoNumero + 1;
                                                SaldoSiguiente = UltimoSaldo + nImporte;
                                                ExistenciaSiguiente = UltimaExistencia + nCtdOrd;
                                                decimal nCostoNuevo = SaldoSiguiente / ExistenciaSiguiente;

                                                SQL = "Insert Into tbKardex (cCodPrd, cDocKdx, nCtdKdx, dFecKdx, nCveEmp, cPrvKdx, nCtoKdx, nTpoKdx, nSdoKdx, nExiKdx, nNumKdx, nNumPed) " +
                                                    "Values ('" + cCodPrd + "','" + nNumOrd.ToString() + "'," + nCtdOrd + ",'" + dFecFac.ToString("yyyyMMdd") + "'," + nCveEmp + ",'" + cPrvOrd + "'," + nCtoOrd + "," + nTpoKdx + "," + SaldoSiguiente + "," + ExistenciaSiguiente + "," + NumeroSiguiente + "," + nNumPed + ")";

                                                conexCompras.ejecSql(SQL);

                                                SQL = "update tbProducto Set nInvAPrd=" + ExistenciaSiguiente + ", nUltPrd=" + nCtoOrd + ", nPrePrd=" + nCostoNuevo + ", dUltPrd = '" + dFecFac.ToString("yyyyMMdd") + "', cPrv1Prd = '" + cPrvOrd + "' Where cCodPrd = '" + cCodPrd + "'";
                                                bool bActualizaInventario = conexCompras.ejecSql(SQL);

                                                if (!bActualizaInventario)
                                                {
                                                    MessageBox.Show("No fue posible actualizar el inventario del producto =" + cCodPrd);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("El producto " + cCodPrd + " No tiene movimientos en el kardex");
                                            }
                                        }
                                        SQL = "select cDocKdx, cCodPrd from tbkardex where cdockdx='" + nNumOrd.ToString() + "'";

                                        DataTable dtKardex = conexCompras.select(SQL);

                                        int nKardex = dtKardex.Rows.Count;
                                        if (nKardex != nFilasDetalle)
                                        {
                                            MessageBox.Show("No se actualizaron correctamente los datos en el kardex");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No coinciden los datos del grid de productos con el de la base de datos");
                                        return;
                                    }

                                    SQL = "Update tbOrdenDetalle Set nEdoOrd = 2, cFacOrd = '" + cFacOrd + "',dFecFac = '" + dFecFac.ToString("yyyyMMdd") + "'  Where nNumOrd = " + nNumOrd;
                                    int nTerminaDetalle = conexCompras.ejecSql(SQL, 0);

                                    if (nFilasDetalle != nTerminaDetalle)
                                    {
                                        MessageBox.Show("No se terminó correctamente el detalle de la orden");
                                        return;
                                    }

                                    string FolioF = txtFolioFiscal.Text;
                                    SQL = "Update tbOrden Set nEdoOrd = 2, cFacOrd = '" + cFacOrd + "', dFecFac = '" + dFecFac.ToString("yyyyMMdd") + "', cFolFis ='" + FolioF + "'   Where nNumOrd = " + nNumOrd;
                                    conexCompras.ejecSql(SQL);

                                    SQL = "INSERT INTO tbFacturacion (nCveEmp, cNumFac, dFecFac, cTipFac, dFecIni, dFecFin, cPrvFac, nTotFac) " +
                                        "Values(2,'" + txtFactura.Text + "', '" + dFecFac.ToString("yyyyMMdd") + "','CD', " +
                                        "'" + dFecFac.ToString("yyyyMMdd") + "', '" + dFecFac.ToString("yyyyMMdd") +
                                        "#,'" + cboProveedor.SelectedValue.ToString() + "'," + Convert.ToDecimal(txtTotal.Text) + ")";

                                    conexCompras.ejecSql(SQL);

                                    using (OleDbConnection connectionTeso = new OleDbConnection(strTesoreria))
                                    {
                                        connectionTeso.Open();

                                        byte nDiasCredito = DiasProveedor(cboProveedor.SelectedValue.ToString()!);

                                        DateTime dVence = dtpFactura.Value.AddDays(nDiasCredito);

                                        decimal nSubtotalADEFA = Convert.ToDecimal(txtTotal.Text) / Convert.ToDecimal(1.16);
                                        decimal nIvaADEFA = Convert.ToDecimal(txtTotal.Text) - nSubtotalADEFA;

                                        string SQLTeso = "INSERT INTO ADEFA2 (cProAde, cFacAde, dFecAde, nImpAde, dVenAde, nIvaAde, nDesAde, nPagAde, cTipAde, dFpgAde, cCheAde, nTPoAde, nTipFac, nEdoRec, nNordCo) " +
                                            "VALUES('" + cboProveedor.SelectedValue.ToString() + "','" + txtFactura.Text + "','" + dFecFac.ToString("yyyyMMdd") + "'," + nSubtotalADEFA + ",'" + dVence.ToString("yyyyMMdd") + "'," + nIvaADEFA + ",0,0,'1','" + dVence.ToString("yyyyMMdd") + "','0',1,1,0," + nNumOrd + ")";

                                        OleDbCommand commandAdefa = new OleDbCommand(SQLTeso, connectionTeso);
                                        int nAdefa = commandAdefa.ExecuteNonQuery();

                                        connectionTeso.Close();
                                    }

                                    foreach (DataRow dr in dtTerminaDetalle.Rows)
                                    {
                                        string cCodPrd = dr["Codigo"].ToString()!;
                                        int nNumPed = Convert.ToInt32(dr["Pedido"].ToString());

                                        if (nNumPed > 0)
                                        {
                                            SQL = "Update tbPedidoDetalle Set nEdoPed = 5, nNumOrd = " + nNumOrd + " Where nNumPed = " + nNumPed + " And cCodPrd='" + cCodPrd + "'";
                                            conexCompras.ejecSql(SQL);

                                            SQL = "Update tbPedido Set nEdoPed = 4 Where nNumPed = " + nNumPed;
                                            conexCompras.ejecSql(SQL);
                                        }
                                    }

                                    MessageBox.Show("Orden terminada");

                                    LimpiarControles();
                                    HabilitaBotones(1);
                                    HabilitaControles(1);
                                    bModifica = false;
                                    bNuevo = false;
                                    bTermina = false;
                                }
                                else
                                {
                                    MessageBox.Show("La orden no tiene estado emitido");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("falta capturar algún dato");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnGrabar_Click " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaProductoEnPedidos modalPedidos = new frmBuscaProductoEnPedidos();
                modalPedidos.ConexBuscaProd = conexCompras;
                modalPedidos.ShowDialog();

                int Orden = Convert.ToInt32(txtNumero.Text);
                int Pedido = modalPedidos.Pedido;
                string Codigo = modalPedidos.Codigo;
                string Descripcion = modalPedidos.Descripcion;
                decimal Cantidad = modalPedidos.Cantidad;
                decimal Costo = modalPedidos.Costo;
                decimal Importe = Costo * Cantidad;

                if (Pedido != 0 && Codigo != string.Empty && Descripcion != string.Empty && Cantidad != 0 && Costo != 0)
                {
                    bool bExisteProducto = false;
                    foreach (DataGridViewRow fila in dgvProductos.Rows)
                    {
                        string codigoFila = fila.Cells["codigo"].Value.ToString()!;

                        if (codigoFila == Codigo)
                        {
                            bExisteProducto = true;
                            break;
                        }
                    }

                    if (bExisteProducto)
                    {
                        MessageBox.Show("Producto ya agregado");
                        txtProducto.Text = string.Empty;
                        txtCantidad.Text = string.Empty;
                        txtDescripcion.Text = string.Empty;
                        txtCosto.Text = string.Empty;
                        txtProducto.Focus();

                        return;
                    }

                    DataRow rowProducto = dtProductosGrid.NewRow();
                    rowProducto["orden"] = Orden;
                    rowProducto["Cantidad"] = Cantidad;
                    rowProducto["Codigo"] = Codigo;
                    rowProducto["Descripcion"] = Descripcion;
                    rowProducto["Costo"] = Costo;
                    rowProducto["Importe"] = Importe;
                    rowProducto["Pedido"] = Pedido;

                    dtProductosGrid.Rows.Add(rowProducto);

                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = dtProductosGrid;
                    dgvProductos.Columns["Orden"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvProductos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvProductos.Columns["Pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    Decimal nSubTotal = 0;
                    foreach (DataRow dr in dtProductosGrid.Rows)
                    {
                        nSubTotal = nSubTotal + Convert.ToDecimal(dr["Importe"]);
                    }

                    if (dtProductosGrid.Rows.Count > 0)
                    {
                        btnQuitar.Enabled = true;
                    }

                    txtSubtotal.Text = nSubTotal.ToString("F2");
                    decimal nIva = nSubTotal * Convert.ToDecimal(0.16);
                    txtIva.Text = nIva.ToString("F2");
                    decimal Total = nSubTotal + nIva;
                    txtTotal.Text = Total.ToString("F2");
                    txtResico.Text = "0";

                    txtProducto.Text = string.Empty;
                    txtCantidad.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtCosto.Text = string.Empty;
                    txtProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnPedidos_Click " + ex.Message);
            }
        }

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text != "" && txtFolioFiscal.Text != "" && txtFactura.Text != "")
                {
                    int Orden = Convert.ToInt32(txtNumero.Text);
                    string FolioFiscal = txtFolioFiscal.Text;
                    string Factura = txtFactura.Text;
                    decimal ImporteFactura = Convert.ToDecimal(txtTotal.Text);
                    decimal ImportePagos = Convert.ToDecimal(txtTotalPagos.Text);
                    frmComplementoPago frmComplementoPago = new frmComplementoPago(Orden, Factura, FolioFiscal, ImporteFactura, ImportePagos);
                    frmComplementoPago.ShowDialog();

                    DataTable dtPagos = new DataTable();
                    dtPagos = CargaPagos(Orden);

                    dgvPagos.DataSource = null;

                    decimal TotalPagos = 0;
                    if (dtPagos.Rows.Count > 0)
                    {
                        dgvPagos.DataSource = dtPagos;
                        foreach (DataRow dr in dtPagos.Rows)
                        {
                            decimal filaPago = Convert.ToDecimal(dr["Importe"]);
                            TotalPagos = TotalPagos + filaPago;
                        }
                    }

                    txtTotalPagos.Text = TotalPagos.ToString("F2");
                    if (ImporteFactura == TotalPagos)
                    {
                        btnAgregarPago.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregarPago_Click " + ex.Message);
            }
        }

        private void botonRedondeado1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (txtNumero.Text != "" && txtFolioFiscal.Text != "" && txtFactura.Text != "")
                    {
                        int Orden = Convert.ToInt32(txtNumero.Text);
                        string FolioFiscal = txtFolioFiscal.Text;
                        string Factura = txtFactura.Text;
                        decimal ImporteFactura = Convert.ToDecimal(txtTotal.Text);
                        decimal ImportePagos = Convert.ToDecimal(txtTotalPagos.Text);
                        frmComplementoPago frmComplementoPago = new frmComplementoPago(Orden, Factura, FolioFiscal, ImporteFactura, ImportePagos);
                        frmComplementoPago.ShowDialog();

                        DataTable dtPagos = new DataTable();
                        dtPagos = CargaPagos(Orden);

                        dgvPagos.DataSource = null;

                        decimal TotalPagos = 0;
                        if (dtPagos.Rows.Count > 0)
                        {
                            dgvPagos.DataSource = dtPagos;
                            foreach (DataRow dr in dtPagos.Rows)
                            {
                                decimal filaPago = Convert.ToDecimal(dr["Importe"]);
                                TotalPagos = TotalPagos + filaPago;
                            }
                        }

                        txtTotalPagos.Text = TotalPagos.ToString("F2");
                        if (ImporteFactura == TotalPagos)
                        {
                            btnAgregarPago.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("btnAgregarPago_Click " + ex.Message);
                }
            }

        }
    }
}