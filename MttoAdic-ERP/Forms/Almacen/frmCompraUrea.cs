using Microsoft.AspNetCore.SignalR.Client;
using MttoAdic_ERP.Models;
using Syncfusion.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmCompraUrea : MetroForm
    {
        private Color originalColorBtnNuevo;
        private Color originalColorBtnSalir;
        private Color originalColorBtnModificar;
        private Color originalColorBtnGrabar;
        private Color originalColorBtnDeshacer;
        private Color originalColorBtnImprimir;
        private Color originalColorBtnAplicar;
        private Color originalColorBtnAgregarPago;
        private Color originalColorTxtEstado;
        private Color originalForeColorTxtEstado;

        private int desctoPorcentaje;

        DataTable dtProveedores = new DataTable();
        DataTable dtOrdenModificar = new DataTable();

        string strPolizaDiario = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\\\srv2kas\\Base Deposito Polizas\\PolizasDiarioLP.mdb;Jet OLEDB:Database Password=a9TnX13HHOo;";
        string strProveedores = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\\\srv2kas\\Base Datos Proveedores_R\\ProveedoresLP.mdb;";
        string strTesoreria = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\\\srv2kas\\Base Datos Administra_R\\TesoreriaLP.mdb;Jet OLEDB:Database Password=a9TnX13HHOo;";

        string SQL = string.Empty;
        public csConexionSQL conexComprasUrea;
        public csConexionSQL ConexComprasUrea { set { this.conexComprasUrea = value; } }
        public HubConnection HubConnection { get; set; }
        public string UsuarioActual { get; set; }
        bool bNuevo = false;
        bool bModifica = false;

        string facturaTemporal = "";
        string folfisTemporal = "";

        private PrintDocument PD = new PrintDocument();
        private PrintPreviewDialog PPD = new PrintPreviewDialog();
        public bool FiltrarProveedoresUrea { get; set; } = false;
        public int ordenInicial { get; }

        int m = 0, mx, my;


        public frmCompraUrea()
        {
            InitializeComponent();
            ApplyModernStyle();
        }

        public frmCompraUrea(int orden)
        {
            InitializeComponent();
            ordenInicial = orden;
            PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);
        }

        private void frmCompra_Load(object sender, EventArgs e)
        {
            try
            {
                //Movimiento de ventana de panel de encabezado
                pnlEncabezado.MouseDown += pnlEncabezado_MouseDown;
                pnlEncabezado.MouseMove += pnlEncabezado_MouseMove;
                pnlEncabezado.MouseUp += pnlEncabezado_MouseUp;

                lblTitulo.MouseDown += pnlEncabezado_MouseDown;
                lblTitulo.MouseMove += pnlEncabezado_MouseMove;
                lblTitulo.MouseUp += pnlEncabezado_MouseUp;

                cboTipo.Items.Add("Contado");
                cboTipo.Items.Add("Credito");
                cboTipo.SelectedIndex = -1;

                originalColorBtnNuevo = btnNuevo.BackColor;
                originalColorBtnSalir = btnSalir.BackColor;
                originalColorBtnModificar = btnModificar.BackColor;
                originalColorBtnGrabar = btnGrabar.BackColor;
                originalColorBtnDeshacer = btnDeshacer.BackColor;
                originalColorBtnImprimir = btnImprimir.BackColor;
                originalColorBtnAplicar = btnAplicar.BackColor;
                originalColorBtnAgregarPago = btnAgregarPago.BackColor;
                originalColorTxtEstado = txtEstado.BackColor;
                originalForeColorTxtEstado = txtEstado.ForeColor;

                desctoPorcentaje = 0;

                CargaProveedores();
                HabilitaControles(1);
                HabilitaBotones(1);

                if (ordenInicial == 0)
                {
                    txtNumero.Text = "";
                }
                else
                {
                    cargaDatosOrden(ordenInicial);
                }
            }
            catch (Exception)
            {

                throw;
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
                e.Graphics.DrawString("Proveedor : " + cboProveedor.Text, fontProv, Brushes.Black, new RectangleF(20, 80, 800, 30), formProv);

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
                Font fontLitros = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Litros", fontLitros, Brushes.Black, new RectangleF(120, 114, 100, 30), formCantidad);

                StringFormat formDescripcion = new StringFormat();
                formDescripcion.Alignment = StringAlignment.Center;
                formDescripcion.LineAlignment = StringAlignment.Center;
                Font fontDescripcion = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Descripción", fontDescripcion, Brushes.Black, new RectangleF(220, 114, 300, 30), formDescripcion);

                StringFormat formCosto = new StringFormat();
                formCosto.Alignment = StringAlignment.Far;
                formCosto.LineAlignment = StringAlignment.Center;
                Font fontCosto = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Costo", fontCosto, Brushes.Black, new RectangleF(580, 114, 100, 30), formCosto);

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

                string codigo = "UR-001-30";
                e.Graphics.DrawString(codigo, fontCodigo, Brushes.Black, new RectangleF(21, Detalle, 100, 30), formCentro);
                decimal nLitros = Convert.ToDecimal(txtLitros.Text);
                string litros = nLitros.ToString("F2");
                e.Graphics.DrawString(litros, fontLitros, Brushes.Black, new RectangleF(95, Detalle, 90, 30), formDerecha);
                string descripcion = "UREA AUTOMOTRIZ";
                e.Graphics.DrawString(descripcion, fontDescripcion, Brushes.Black, new RectangleF(314, Detalle, 300, 30), formIzquierda);
                decimal nPrecio = Convert.ToDecimal(txtCosto.Text);
                string precio = nPrecio.ToString("F2");
                e.Graphics.DrawString(precio, fontCosto, Brushes.Black, new RectangleF(580, Detalle, 100, 30), formDerecha);

                Detalle += 15;

                Pen PenFinDetalle = new Pen(Brushes.Black);
                PenFinDetalle.Width = 1.0F;
                e.Graphics.DrawRectangle(PenFinDetalle, new Rectangle(20, Detalle + 10, 780, 1));

                decimal nImporte = Convert.ToDecimal(txtCosto.Text) * Convert.ToDecimal(txtLitros.Text);
                string importe = nImporte.ToString("F2");

                Font fontTotal = new Font("Times New Roman", 18, FontStyle.Bold, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Subtotal : ", fontTotal, Brushes.Black, new RectangleF(550, Detalle + 35, 150, 30), formIzquierda);
                e.Graphics.DrawString(importe, fontTotal, Brushes.Black, new RectangleF(700, Detalle + 35, 100, 30), formDerecha);

                e.Graphics.DrawString("Iva : ", fontTotal, Brushes.Black, new RectangleF(550, Detalle + 60, 150, 30), formIzquierda);
                e.Graphics.DrawString(txtIva.Text, fontTotal, Brushes.Red, new RectangleF(700, Detalle + 60, 100, 30), formDerecha);

                e.Graphics.DrawString("Total : ", fontTotal, Brushes.Black, new RectangleF(550, Detalle + 85, 150, 30), formIzquierda);
                e.Graphics.DrawString(txtTotal.Text, fontTotal, Brushes.Black, new RectangleF(700, Detalle + 85, 100, 30), formDerecha);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PD_PrintPage " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void cargaDatosOrden(int nNumOrd)
        {
            try
            {
                DataTable dtOrden = new DataTable();
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


                    decimal cLitros = Convert.ToDecimal(dtOrden.Rows[0]["nLtsOrd"]);
                    txtLitros.Text = cLitros.ToString("F2");
                    decimal Costo = Convert.ToDecimal(dtOrden.Rows[0]["nCtoOrd"]);
                    txtCosto.Text = Costo.ToString("F2");

                    string Factura = dtOrden.Rows[0]["cFacOrd"].ToString()!;
                    txtFactura.Text = Factura;
                    DateTime dFecFac = DateTime.Parse(dtOrden.Rows[0]["dFecFac"].ToString()!);
                    dtpFactura.Value = dFecFac;

                    int Tipo = Convert.ToInt32(dtOrden.Rows[0]["nPgoOrd"]);
                    cboTipo.SelectedIndex = Tipo - 1;

                    txtFolioFiscal.Text = dtOrden.Rows[0]["cFolFis"].ToString()!;

                    decimal Subtotal = Convert.ToDecimal(dtOrden.Rows[0]["nSubOrd"]);
                    txtSubtotal.Text = Subtotal.ToString("F2");

                    decimal Iva = Convert.ToDecimal(dtOrden.Rows[0]["nIvaOrd"]);
                    txtIva.Text = Iva.ToString("F2");

                    decimal Total = Convert.ToDecimal(dtOrden.Rows[0]["nTotOrd"]);
                    txtTotal.Text = Total.ToString("F2");

                    desctoPorcentaje = Convert.ToInt32(dtOrden.Rows[0]["nDesOrd"]);
                    lblDescto.Text = "(" + desctoPorcentaje.ToString() + " %)";

                    decimal Importe = Costo * cLitros;
                    Decimal descuento = Importe * desctoPorcentaje / 100;

                    txtDescuento.Text = descuento.ToString("F2");

                    DataTable dtPagos = new DataTable();
                    dtPagos.Clear();
                    dtPagos = CargaPagos(nNumOrd);

                    dgvPagos.DataSource = null;
                    dgvPagos.Columns.Clear();

                    decimal TotalPagos = 0;
                    bool existenPagos = false;
                    if (dtPagos.Rows.Count > 0)
                    {
                        existenPagos = true;
                        dgvPagos.DataSource = dtPagos;

                        // Elimina la columna 'btnEliminar' si ya existe antes de agregarla.
                        if (!dgvPagos.Columns.Contains("btnEliminar"))
                        {
                            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                            btnEliminar.Name = "btnEliminar";
                            btnEliminar.HeaderText = "";
                            btnEliminar.Text = "Eliminar";
                            btnEliminar.FlatStyle = FlatStyle.Flat;
                            btnEliminar.UseColumnTextForButtonValue = true;
                            btnEliminar.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F08080");  // Fondo rojo
                            btnEliminar.DefaultCellStyle.ForeColor = Color.DarkRed; // Texto blanco
                            dgvPagos.Columns.Add(btnEliminar);
                        }

                        // columna 'btnEliminar' siempre al final.
                        dgvPagos.Columns["btnEliminar"].DisplayIndex = dgvPagos.Columns.Count - 1;

                        foreach (DataRow dr in dtPagos.Rows)
                        {
                            decimal filaPago = Convert.ToDecimal(dr["Importe"]);
                            TotalPagos = TotalPagos + filaPago;
                        }
                    }

                    txtTotalPagos.Text = TotalPagos.ToString("F2");

                    decimal TotalOrden = Convert.ToDecimal(txtTotal.Text);

                    txtTotalPagos.Text = TotalPagos.ToString("F2");
                    decimal restoPago = TotalOrden - TotalPagos;
                    txtPagoResto.Text = restoPago.ToString();

                    if (TotalOrden > TotalPagos)
                    {
                        btnAgregarPago.Enabled = true;
                        btnAgregarPago.BackColor = originalColorBtnAgregarPago;
                    }

                    if (TotalOrden == TotalPagos)
                    {
                        btnAgregarPago.Enabled = false;
                        btnAgregarPago.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        dgvPagos.DataSource = null;
                        dgvPagos.Columns.Clear();
                        dgvPagos.DataSource = dtPagos;
                    }


                    HabilitaBotones(3);

                    txtBuscar.Text = string.Empty;

                    if (nEdoVal == 1)
                    {
                        btnModificar.Enabled = true;
                        btnModificar.BackColor = originalColorBtnModificar;
                        if (existenPagos)
                        {
                            btnModificar.Enabled = false;
                            btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        }

                        txtEstado.Text = "Emitido";
                        txtEstado.BackColor = originalColorTxtEstado;
                        txtEstado.ForeColor = originalForeColorTxtEstado;

                    }
                    else if (nEdoVal > 1)
                    {
                        btnModificar.Enabled = false;
                        btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        txtEstado.Text = "Terminado";
                        txtEstado.BackColor = Color.LightGreen;
                        txtEstado.ForeColor = Color.DarkGreen;

                    }
                }
                else
                {
                    LimpiarControles();
                    MessageBox.Show("Folio de vale incorrecto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al carga datos " + ex.Message);
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
                    txtLitros.Enabled = false;
                    txtCosto.Enabled = false;
                    txtFactura.Enabled = false;
                    dtpFactura.Enabled = false;
                    cboTipo.Enabled = false;
                    txtPorcentaje.Enabled = false;
                    txtFolioFiscal.Enabled = false;
                    btnAplicar.Enabled = false;
                    btnAgregarPago.Enabled = false;
                    txtBuscar.Enabled = true;

                    //Cambia el color de fondo cuando está deshabilitado
                    btnAplicar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnAgregarPago.BackColor = ColorTranslator.FromHtml("#FFFFFF");

                }
                if (opcion == 2) //nuevo
                {
                    txtPorcentaje.Enabled = true;
                    btnAplicar.Enabled = true;
                    btnAplicar.BackColor = originalColorBtnAplicar;

                    txtLitros.Enabled = true;
                    txtCosto.Enabled = true;
                    cboTipo.Enabled = true;
                    dtpOrden.Enabled = true;
                    cboProveedor.Enabled = true;
                    txtFactura.Enabled = true;
                    dtpFactura.Enabled = true;
                    txtFolioFiscal.Enabled = true;

                    btnAgregarPago.Enabled = false;
                    txtBuscar.Enabled = false;

                    btnAgregarPago.BackColor = ColorTranslator.FromHtml("#FFFFFF");

                    txtEstado.Text = "Emitido";
                    txtEstado.BackColor = originalColorTxtEstado;
                    txtEstado.ForeColor = originalForeColorTxtEstado;
                }
                if (opcion == 3) //modifica
                {
                    txtPorcentaje.Enabled = false;
                    btnAplicar.Enabled = false;
                    btnAplicar.BackColor = ColorTranslator.FromHtml("#FFFFFF");

                    txtLitros.Enabled = false;
                    txtCosto.Enabled = false;
                    cboTipo.Enabled = false;
                    dtpOrden.Enabled = false;
                    cboProveedor.Enabled = false;
                    txtFactura.Enabled = true;
                    dtpFactura.Enabled = true;
                    txtFolioFiscal.Enabled = true;

                    btnAgregarPago.Enabled = false;
                    txtBuscar.Enabled = false;

                    btnAgregarPago.BackColor = ColorTranslator.FromHtml("#FFFFFF");

                    txtEstado.Text = "Emitido";
                    txtEstado.BackColor = originalColorTxtEstado;
                    txtEstado.ForeColor = originalForeColorTxtEstado;
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
                    btnGrabar.Enabled = false;
                    btnDeshacer.Enabled = false;
                    btnImprimir.Enabled = false;
                    btnSalir.Enabled = true;

                    //Cambia el color de fondo cuando está deshabilitado
                    btnNuevo.BackColor = originalColorBtnNuevo;
                    btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnGrabar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnDeshacer.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnImprimir.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnSalir.BackColor = originalColorBtnSalir;
                }
                if (opcion == 2)
                {
                    btnNuevo.Enabled = false;
                    btnModificar.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnDeshacer.Enabled = true;
                    btnImprimir.Enabled = false;
                    btnSalir.Enabled = false; ;

                    //Cambia el color de fondo cuando está deshabilitado
                    btnNuevo.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnGrabar.BackColor = originalColorBtnGrabar;
                    btnDeshacer.BackColor = originalColorBtnDeshacer;
                    btnImprimir.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnSalir.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
                if (opcion == 3)  //Buscar
                {
                    btnNuevo.Enabled = true;
                    btnNuevo.BackColor = originalColorBtnNuevo;
                    btnModificar.Enabled = true;
                    btnModificar.BackColor = originalColorBtnModificar;
                    btnImprimir.Enabled = true;
                    btnImprimir.BackColor = originalColorBtnImprimir;
                    btnSalir.Enabled = true;
                    btnSalir.BackColor = originalColorBtnSalir;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("HabilitaBotones " + ex.Message);
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
                cboProveedor.SelectedIndex = -1;
                txtCosto.Text = string.Empty;
                dtpOrden.Value = DateTime.Now.Date;
                txtFactura.Text = string.Empty;
                dtpFactura.Value = DateTime.Now.Date;
                txtPorcentaje.Text = string.Empty;
                txtFolioFiscal.Text = string.Empty;
                cboTipo.SelectedIndex = -1;
                dgvPagos.DataSource = null;
                txtTotalPagos.Text = string.Empty;
                txtLitros.Text = string.Empty;
                txtPagoResto.Text = string.Empty;
                txtDescuento.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LimpiarControles " + ex.Message);
            }
        }

        private int NuevoNumeroOrden()
        {
            int FolioSiguiente = 1;

            try
            {
                SQL = "Select Top 1 nNumOrd From dbUrea.dbo.tbOrden Order by nNumOrd desc";

                DataTable dtultimoNumero = conexComprasUrea.select(SQL);

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



        void CargaProveedores()
        {
            try
            {
                SQL = "SELECT cCvePrv, cNomPrv from dbProveedores.dbo.tbProveedor ";

                if (FiltrarProveedoresUrea)
                {
                    SQL += "WHERE nLinPrv = 21 "; // Filtrar por la línea 21
                }

                SQL += "ORDER BY cNomPrv ASC";

                dtProveedores = conexComprasUrea.select(SQL);
                dtProveedores.Columns.Add("cCveNomPrv", typeof(string), "cCvePrv + ' - ' + cNomPrv");
                cboProveedor.DataSource = null;
                cboProveedor.DataSource = dtProveedores;
                cboProveedor.DisplayMember = "cCveNomPrv";
                cboProveedor.ValueMember = "cCvePrv";
                cboProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaProveedores " + ex.Message);
            }
        }


        private int ValidaNumeroOrden(int nNumOrd)
        {
            int OrdenBuscado = 0;

            try
            {
                SQL = "select nNumOrd from dbUrea.dbo.tbOrden where nNumOrd = " + nNumOrd;

                DataTable dtOrden = conexComprasUrea.select(SQL);

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

        private DataTable CargaOrdenes(int nNumOrd)
        {
            DataTable dtOrdenes = new DataTable();

            try
            {
                SQL = "SELECT nNumOrd as Orden, dFecOrd as Fecha, nEdoOrd as Estado, cPrvOrd, nSubOrd, nIvaOrd, nTotOrd, nDesOrd, cFacOrd, dFecFac, cFolFis, nPgoOrd, nPolPol, nLtsOrd, nCtoOrd FROM dbUrea.dbo.tbOrden " +
                    "where nNumOrd=" + nNumOrd;

                dtOrdenes = conexComprasUrea.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaOrdenes " + ex.Message);
            }

            return dtOrdenes;
        }


        private DataTable CargaPagos(int nNumOrd)
        {
            DataTable dtPagos = new DataTable();

            try
            {
                SQL = "SELECT dFecPago as Fecha, nImpPago as Importe, cFolFisPago as FolioFiscal FROM dbAlmacen.dbo.tbComplementoPago " +
                    "where nNumOrd=" + nNumOrd;

                dtPagos = conexComprasUrea.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaPagos " + ex.Message);
            }

            return dtPagos;
        }

        private void EliminarPago(string FolioFiscal)
        {
            try
            {
                SQL = "DELETE FROM dbAlmacen.dbo.tbComplementoPago " +
                    "where cFolFisPago='" + FolioFiscal + "'";

                conexComprasUrea.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el pago." + ex.Message);
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

        private int UltimaPoliza()
        {
            int PolizaSiguiente = 1;
            DataTable dtUltimaPoliza = new DataTable();
            using (OleDbConnection connectionPol = new OleDbConnection(strPolizaDiario))
            {
                connectionPol.Open();
                SQL = "Select Top 1 nPolPol From POLIG2 Order by nPolPol desc";

                OleDbCommand commandPoliza = new OleDbCommand(SQL, connectionPol);

                OleDbDataReader readerPoliza = commandPoliza.ExecuteReader();

                dtUltimaPoliza.Load(readerPoliza);
                if (dtUltimaPoliza.Rows.Count > 0)
                {
                    int UltimoFolio = Convert.ToInt32(dtUltimaPoliza.Rows[0]["nPolPol"]);
                    PolizaSiguiente = UltimoFolio + 1;
                }

                connectionPol.Close();
            }

            return PolizaSiguiente;
        }

        private bool GenerarPoliza()
        {
            bool bExistePoliza = false;
            try
            {
                int nPolPol = UltimaPoliza();
                int nTipPol = 3;
                string cConPol = "COMPRA DE UREA";
                decimal nDebPol = Convert.ToDecimal(txtTotal.Text);
                decimal nHabPol = Convert.ToDecimal(txtTotal.Text);
                string cAfePol = "NO";
                int nEmpPol = 2;
                int nContPol = 0;
                int nEdoPol = 0;
                int nOriPol = 2;

                int nNumOrd = Convert.ToInt32(txtNumero.Text);

                //Inserta poliza
                using (OleDbConnection connectionPol = new OleDbConnection(strPolizaDiario))
                {
                    connectionPol.Open();

                    string SQLPoliza = "Insert Into POLIG2 (nPolPol, nTipPol, cConPol, nDebPol, nHabPol, dFecPol, cAfePol, nEmpPol, nContPol, nEdoPol, nOriPol) " +
                                        "Values (" + nPolPol + "," + nTipPol + ",'" + cConPol + "'," + nDebPol + "," + nHabPol + ",#" + DateTime.Now.ToString("MM-dd-yyyy") + "#,'" + cAfePol + "'," + nEmpPol + "," + nContPol + "," + nEdoPol + "," + nOriPol + ")";

                    OleDbCommand commandPoliza = new OleDbCommand(SQLPoliza, connectionPol);

                    commandPoliza.ExecuteNonQuery();

                    connectionPol.Close();
                }

                using (OleDbConnection connectionPolValida = new OleDbConnection(strPolizaDiario))
                {
                    connectionPolValida.Open();

                    DataTable dtPoliza = new DataTable();
                    string SQLPoliza = "SELECT nPolPol FROM POLIG2 WHERE nPolPol = " + nPolPol;

                    OleDbCommand commandPoliza = new OleDbCommand(SQLPoliza, connectionPolValida);

                    OleDbDataReader readerPoliza = commandPoliza.ExecuteReader();

                    dtPoliza.Load(readerPoliza);

                    if (dtPoliza.Rows.Count > 0)
                    {
                        bExistePoliza = true;
                        //Actualiza la columna de poliza
                        SQL = "UPDATE dbUrea.dbo.tbOrden SET nPolPol = " + nPolPol + " WHERE nNumOrd = " + nNumOrd + "; ";
                        bool binserPolOrden = conexComprasUrea.ejecSql(SQL);

                        if (!binserPolOrden)
                        {
                            connectionPolValida.Close();
                            MessageBox.Show("Error, no se inserto la poliza en orden de compra");
                            return bExistePoliza = false;
                        }

                        // Para InventarioUreaDebe
                        bool bInventarioUreaDebe = InsertarPolizaDetalle(nPolPol, "1105012000", Convert.ToDecimal(txtSubtotal.Text), 0, 0);

                        // Para IvaUreaDebe
                        bool bIvaUreaDebe = InsertarPolizaDetalle(nPolPol, "1107002000", Convert.ToDecimal(txtIva.Text), 0, 1);

                        // Para ProveedorUreaHaber
                        bool bProveedorUreaHaber = InsertarPolizaDetalle(nPolPol, "2102040000", 0, Convert.ToDecimal(txtTotal.Text), 2);

                        if (!bInventarioUreaDebe || !bIvaUreaDebe || !bProveedorUreaHaber)
                        {
                            connectionPolValida.Close();
                            MessageBox.Show("Error, no se inserto detalle de la poliza");
                            return bExistePoliza = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, no se inserto la poliza correctamente");
                    }

                    connectionPolValida.Close();
                }

                return bExistePoliza;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnGeneraPoliza_Click " + ex.Message);
                return bExistePoliza;
            }
        }

        private bool InsertarPolizaDetalle(int nPolPol, string cCueCon, decimal nDebPol, decimal nHabPol, int nIdxPol)
        {
            bool binsercionRegistro = false;

            try
            {
                int nTipPol = 3;
                string cConPol = "FACTURA UREA " + txtFactura.Text;
                string cFolFis = txtFolioFiscal.Text;

                // Inserta póliza
                using (OleDbConnection connectionPol = new OleDbConnection(strPolizaDiario))
                {
                    connectionPol.Open();

                    string SQLPoliza = "INSERT INTO POLID2 (nPolPol, nTipPol, cConPol, cCueCon, nDebPol, nHabPol, nIdxPol, cFolFis) " +
                                       "VALUES (" + nPolPol + "," + nTipPol + ",'" + cConPol + "','" + cCueCon + "'," + nDebPol + "," + nHabPol + "," + nIdxPol + ",'" + cFolFis + "')";

                    OleDbCommand commandPoliza = new OleDbCommand(SQLPoliza, connectionPol);
                    commandPoliza.ExecuteNonQuery();

                    connectionPol.Close();
                }

                // Validar inserción
                using (OleDbConnection connectionPolValida = new OleDbConnection(strPolizaDiario))
                {
                    connectionPolValida.Open();

                    DataTable dtPoliza = new DataTable();
                    string SQLPoliza = "SELECT nPolPol, cConPol, cCueCon FROM POLID2 WHERE nPolPol = " + nPolPol +
                                       " AND cConPol = '" + cConPol + "' AND cCueCon = '" + cCueCon + "'";

                    OleDbCommand commandPoliza = new OleDbCommand(SQLPoliza, connectionPolValida);
                    OleDbDataReader readerPoliza = commandPoliza.ExecuteReader();

                    dtPoliza.Load(readerPoliza);

                    if (dtPoliza.Rows.Count > 0)
                    {
                        binsercionRegistro = true;
                    }
                    connectionPolValida.Close();
                }

                return binsercionRegistro;
            }
            catch (Exception)
            {
                return binsercionRegistro;
            }
        }

        private bool ActualizaPoliza()
        {
            bool bActualizaPoliza = false;
            int IActualizaPoliza = 0;
            try
            {
                int nPolPol = Convert.ToInt32(dtOrdenModificar.Rows[0]["nPolPol"]);
                decimal nDebPol = Convert.ToDecimal(txtTotal.Text);
                decimal nHabPol = Convert.ToDecimal(txtTotal.Text);

                //Inserta poliza
                using (OleDbConnection connectionPol = new OleDbConnection(strPolizaDiario))
                {
                    connectionPol.Open();

                    string SQLPoliza = "UPDATE POLIG2 SET nDebPol = " + nDebPol + ", nHabPol = " + nHabPol + "  WHERE nPolPol = " + nPolPol;

                    OleDbCommand commandPoliza = new OleDbCommand(SQLPoliza, connectionPol);

                    IActualizaPoliza = commandPoliza.ExecuteNonQuery();
                    connectionPol.Close();
                }

                // Para InventarioUreaDebe
                bool bInventarioUreaDebe = ActualizaPolizaDetalle(nPolPol, "1105012000", Convert.ToDecimal(txtSubtotal.Text), 0);
                // Para IvaUreaDebe
                bool bIvaUreaDebe = ActualizaPolizaDetalle(nPolPol, "1107002000", Convert.ToDecimal(txtIva.Text), 0);
                // Para ProveedorUreaHaber
                bool bProveedorUreaHaber = ActualizaPolizaDetalle(nPolPol, "2102040000", 0, Convert.ToDecimal(txtTotal.Text));

                if (IActualizaPoliza == 1 && bInventarioUreaDebe && bIvaUreaDebe && bProveedorUreaHaber)
                {
                    bActualizaPoliza = true;
                }

                return bActualizaPoliza;
            }
            catch (Exception ex)
            {
                return bActualizaPoliza;
            }
        }

        private bool ActualizaPolizaDetalle(int nPolPol, string cCueCon, decimal nDebPol, decimal nHabPol)
        {
            bool bActualizaRegistro = false;

            try
            {
                string cConPol = "FACTURA UREA " + txtFactura.Text;
                string cFolFis = txtFolioFiscal.Text;

                // Inserta póliza
                using (OleDbConnection connectionPol = new OleDbConnection(strPolizaDiario))
                {
                    connectionPol.Open();

                    string SQLPoliza = "UPDATE POLID2 SET cConPol = '" + cConPol + "', nDebPol = " + nDebPol + ", nHabPol = " + nHabPol + ", cFolFis = '" + cFolFis + "' WHERE nPolPol = " + nPolPol + " AND " + "cCueCon = '" + cCueCon + "'";

                    OleDbCommand commandPoliza = new OleDbCommand(SQLPoliza, connectionPol);
                    int IActualizaRegistro = commandPoliza.ExecuteNonQuery();

                    if (IActualizaRegistro == 1)
                    {
                        bActualizaRegistro = true;
                    }

                    connectionPol.Close();
                }

                return bActualizaRegistro;
            }
            catch (Exception)
            {
                return bActualizaRegistro;
            }
        }

        private int DiasCreditoProveedor()
        {
            int DiasCredito = 0;
            DataTable dtDiasCredito = new DataTable();
            using (OleDbConnection connectionPrv = new OleDbConnection(strProveedores))
            {
                connectionPrv.Open();
                SQL = "Select nDiaPrv From Proveedores where cCvePrv = '2102040000'";

                OleDbCommand commandPrv = new OleDbCommand(SQL, connectionPrv);

                OleDbDataReader readerPrv = commandPrv.ExecuteReader();

                dtDiasCredito.Load(readerPrv);
                if (dtDiasCredito.Rows.Count > 0)
                {
                    DiasCredito = Convert.ToInt32(dtDiasCredito.Rows[0]["nDiaPrv"]);

                }

                connectionPrv.Close();
            }

            return DiasCredito;
        }

        private bool InsertarADEFA2()
        {
            bool binsercionRegistro = false;

            try
            {
                string cProAde = "2102040000";
                string cFacAde = txtFactura.Text;
                DateTime dFecAde = dtpFactura.Value;
                decimal nImpAde = Convert.ToDecimal(txtSubtotal.Text);

                int DiasCredito = DiasCreditoProveedor();
                DateTime dVenAde = dtpFactura.Value.AddDays(DiasCredito);
                decimal nIvaAde = Convert.ToDecimal(txtIva.Text);
                decimal nDesAde = 0;
                if (txtDescuento.Text != "")
                {
                    nDesAde = Convert.ToDecimal(txtDescuento.Text);
                }
                int nPagAde = 0;
                string cTipAde = "1";
                DateTime dFpgAde = dVenAde;
                string cCheAde = "0";
                int nTPoAde = 1;
                int nTipFac = 1;
                int nEdoRec = 0;
                int nNOrdCo = Convert.ToInt32(txtNumero.Text);

                // Inserta póliza
                using (OleDbConnection connectionTes = new OleDbConnection(strTesoreria))
                {
                    connectionTes.Open();

                    string SQLADEFA2 = "INSERT INTO ADEFA2 (cProAde, cFacAde, dFecAde, nImpAde, dVenAde, nIvaAde, nDesAde, nPagAde, cTipAde, dFpgAde, cCheAde, nTPoAde, nTipFac, nEdoRec, nNOrdCo) " +
                                       "VALUES ('" + cProAde + "', '" + cFacAde + "', '" + dFecAde + "', " + nImpAde + ", '" + dVenAde + "', " + nIvaAde + ", " + nDesAde + ", " + nPagAde + ", '" + cTipAde + "', '" + dFpgAde + "', '" + cCheAde + "', " + nTPoAde + ", " + nTipFac + ", " + nEdoRec + ", " + nNOrdCo + ")";

                    OleDbCommand commandTes = new OleDbCommand(SQLADEFA2, connectionTes);
                    commandTes.ExecuteNonQuery();

                    connectionTes.Close();
                }

                // Validar inserción
                using (OleDbConnection connectionTes = new OleDbConnection(strTesoreria))
                {
                    connectionTes.Open();

                    DataTable dtAdefa = new DataTable();
                    string SQLADEFA2 = "SELECT cProAde, cFacAde FROM ADEFA2 WHERE cProAde = '" + cProAde +
                                       "' AND cFacAde = '" + cFacAde + "'";

                    OleDbCommand commandTes = new OleDbCommand(SQLADEFA2, connectionTes);
                    OleDbDataReader readerTes = commandTes.ExecuteReader();

                    dtAdefa.Load(readerTes);

                    if (dtAdefa.Rows.Count > 0)
                    {
                        binsercionRegistro = true;
                    }
                    connectionTes.Close();
                }

                return binsercionRegistro;
            }
            catch (Exception)
            {
                return binsercionRegistro;
            }
        }

        private bool ActualizaADEFA2()
        {
            bool bActualizaAdefa = false;
            int IActualizaAdefa = 0;
            try
            {
                string cProAde = "2102040000";
                string cFacAde = txtFactura.Text;
                DateTime dFecAde = dtpFactura.Value;
                decimal nImpAde = Convert.ToDecimal(txtSubtotal.Text);
                int DiasCredito = DiasCreditoProveedor();
                DateTime dVenAde = dtpFactura.Value.AddDays(DiasCredito);
                decimal nIvaAde = Convert.ToDecimal(txtIva.Text);
                decimal nDesAde = 0;
                if (txtDescuento.Text != "")
                {
                    nDesAde = Convert.ToDecimal(txtDescuento.Text);
                }

                DateTime dFpgAde = dVenAde;

                //Inserta poliza
                using (OleDbConnection connectionTes = new OleDbConnection(strTesoreria))
                {
                    connectionTes.Open();

                    string SQLADEFA2 = "UPDATE ADEFA2 SET cFacAde = '" + cFacAde + "', dFecAde = '" + dFecAde + "', nImpAde = " + nImpAde + ", dVenAde = '" + dVenAde + "', nIvaAde = " + nIvaAde + ", nDesAde = " + nDesAde + ", dFpgAde = '" + dFpgAde + "' WHERE cProAde = '" + cProAde + "' AND cFacAde = '" + facturaTemporal + "'";

                    OleDbCommand commandTes = new OleDbCommand(SQLADEFA2, connectionTes);

                    IActualizaAdefa = commandTes.ExecuteNonQuery();
                    connectionTes.Close();
                }

                if (IActualizaAdefa == 1)
                {
                    bActualizaAdefa = true;
                }

                return bActualizaAdefa;
            }
            catch (Exception ex)
            {
                return bActualizaAdefa;
            }
        }

        private bool existeFacturaOrden(string cFacAde)
        {
            string facturaBuscada = "";
            bool existe = false;

            try
            {
                SQL = "select cFacOrd from dbUrea.dbo.tbOrden where cFacOrd = '" + cFacAde + "'";

                DataTable dtOrden = conexComprasUrea.select(SQL);

                if (dtOrden.Rows.Count > 0)
                {
                    facturaBuscada = dtOrden.Rows[0]["cFacOrd"].ToString()!;

                    if (facturaBuscada == cFacAde)
                    {
                        existe = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, al consultar Factura - Orden" + ex.Message);
                existe = true;
            }

            return existe;
        }

        private bool existeFolFisOrden(string cFolFis)
        {
            string folfisBuscado = "";
            bool existe = false;

            try
            {
                SQL = "select cFolFis from dbUrea.dbo.tbOrden where cFolFis = '" + cFolFis + "'";

                DataTable dtOrden = conexComprasUrea.select(SQL);

                if (dtOrden.Rows.Count > 0)
                {
                    folfisBuscado = dtOrden.Rows[0]["cFolFis"].ToString()!;

                    if (folfisBuscado == cFolFis)
                    {
                        existe = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, al consultar folio fiscal en orden" + ex.Message);
                existe = true;
            }

            return existe;
        }

        private bool Existe_cConPol_POLID2(string cConPol)
        {
            DataTable dt_cConPol = new DataTable();
            string cConPol_Buscado = "";
            bool existe = false;
            cConPol = "FACTURA UREA " + cConPol;

            try
            {
                using (OleDbConnection connectionPol = new OleDbConnection(strPolizaDiario))
                {
                    connectionPol.Open();
                    string SQL = "SELECT cConPol FROM POLID2 WHERE cConPol = '" + cConPol + "'";

                    using (OleDbCommand commandPol = new OleDbCommand(SQL, connectionPol))
                    using (OleDbDataReader readerPol = commandPol.ExecuteReader())
                    {
                        dt_cConPol.Load(readerPol);
                    }
                    ;

                    if (dt_cConPol.Rows.Count > 0)
                    {
                        cConPol_Buscado = dt_cConPol.Rows[0]["cConPol"].ToString()!;
                        if (cConPol_Buscado == cConPol)
                        {
                            existe = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, al consultar factura en poliza");
                existe = true;
            }

            return existe;
        }

        private bool Existe_cFacAde_ADEFA2(string cFacAde)
        {
            DataTable dt_cFacAde = new DataTable();
            string cFacAde_Buscado = "";
            bool existe = false;

            try
            {
                using (OleDbConnection connectionTes = new OleDbConnection(strTesoreria))
                {
                    connectionTes.Open();
                    string SQL = "SELECT cFacAde FROM ADEFA2 WHERE cFacAde = '" + cFacAde + "'";

                    using (OleDbCommand commandTes = new OleDbCommand(SQL, connectionTes))
                    using (OleDbDataReader readerTes = commandTes.ExecuteReader())
                    {
                        dt_cFacAde.Load(readerTes);
                    }
                    ;

                    if (dt_cFacAde.Rows.Count > 0)
                    {
                        cFacAde_Buscado = dt_cFacAde.Rows[0]["cFacAde"].ToString()!;
                        if (cFacAde_Buscado == cFacAde)
                        {
                            existe = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, al consultar factura AD2_Tes");
                existe = true;
            }

            return existe;
        }

        private bool Existe_cFolFis_POLID2(string cFolFis)
        {
            DataTable dt_cFolFis = new DataTable();
            string cFolFis_Buscado = "";
            bool existe = false;

            try
            {
                using (OleDbConnection connectionPol = new OleDbConnection(strPolizaDiario))
                {
                    connectionPol.Open();
                    string SQL = "SELECT cFolFis FROM POLID2 WHERE cFolFis = '" + cFolFis + "'";

                    using (OleDbCommand commandPol = new OleDbCommand(SQL, connectionPol))
                    using (OleDbDataReader readerPol = commandPol.ExecuteReader())
                    {
                        dt_cFolFis.Load(readerPol);
                    }
                    ;

                    if (dt_cFolFis.Rows.Count > 0)
                    {
                        cFolFis_Buscado = dt_cFolFis.Rows[0]["cFolFis"].ToString()!;
                        if (cFolFis_Buscado == cFolFis)
                        {
                            existe = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, al consultar factura en poliza");
                existe = true;
            }

            return existe;
        }

        private bool actualizaExistenciaUrea(decimal nLtsOrd)
        {
            bool bActualizaExistencia = false;
            DataTable dtExistenciaActual = new DataTable();
            try
            {
                SQL = "select nExiSis, nExiMir from dbUrea.dbo.tbInvUrea where nCveInv = 1";
                dtExistenciaActual = conexComprasUrea.select(SQL);
                if (dtExistenciaActual.Rows.Count > 0)
                {
                    decimal nExiSis = Convert.ToDecimal(dtExistenciaActual.Rows[0]["nExiSis"]) + nLtsOrd;
                    decimal nExiMir = Convert.ToDecimal(dtExistenciaActual.Rows[0]["nExiMir"]) + nLtsOrd;

                    SQL = "UPDATE dbUrea.dbo.tbInvUrea SET nExiMir = " + nExiMir + ", nExiSis = " + nExiSis + "  WHERE nCveInv = 1";
                    bActualizaExistencia = conexComprasUrea.ejecSql(SQL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, no se actualizo correctamente la urea");
            }

            return bActualizaExistencia;
        }

        private bool Actualiza_UltFac_Cos()
        {

            bool bActualiza_UltFac_Cos = false;
            DateTime dUltFac = DateTime.Now;
            decimal nUltCos = 0;

            try
            {
                SQL = "select top 1 dFecFac, nCtoOrd from dbUrea.dbo.tbOrden order by dFecFac desc, nNumOrd desc";
                DataTable dtFac_Cos = conexComprasUrea.select(SQL);

                if (dtFac_Cos.Rows.Count > 0)
                {
                    dUltFac = DateTime.Parse(dtFac_Cos.Rows[0]["dFecFac"].ToString()!);
                    nUltCos = Convert.ToDecimal(dtFac_Cos.Rows[0]["nCtoOrd"]);
                }
                else
                {
                    return bActualiza_UltFac_Cos;
                }

                SQL = "UPDATE dbUrea.dbo.tbInvUrea SET dUltFac = '" + dUltFac.ToString("yyyyMMdd") + "', nUltCos = " + nUltCos + "  WHERE nCveInv = 1";
                bActualiza_UltFac_Cos = conexComprasUrea.ejecSql(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar ultima factura y costo." + ex.Message);
            }

            return bActualiza_UltFac_Cos;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bNuevo = true;
            bModifica = false;
            LimpiarControles();
            HabilitaControles(2);
            HabilitaBotones(2);
            txtEstado.Text = "Emitido";
            int Folio = NuevoNumeroOrden();
            txtNumero.Text = Folio.ToString();
            desctoPorcentaje = 0;
            lblDescto.Text = "( % )";
            txtBuscar.Text = string.Empty;
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            HabilitaControles(1);
            HabilitaBotones(1);
            facturaTemporal = "";
            folfisTemporal = "";

        }
        //pruebas git
        private async void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bNuevo)
                {
                    if (txtNumero.Text != "" && cboProveedor.SelectedIndex > -1 && cboTipo.SelectedIndex > -1 && txtLitros.Text != "" && txtLitros.Text != "0" && txtCosto.Text != "" && txtCosto.Text != "0" && txtSubtotal.Text != "" && txtSubtotal.Text != "0" && txtIva.Text != "" && txtIva.Text != "0" && txtTotal.Text != "" && txtTotal.Text != "0" && txtFactura.Text != "" && txtFolioFiscal.Text != "")
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
                            string cFacOrd = txtFactura.Text;
                            DateTime dFecFac = dtpFactura.Value;
                            byte nPgoOrd = Convert.ToByte(cboTipo.SelectedIndex + 1);
                            int nPolPol = 0;
                            string cFolFis = txtFolioFiscal.Text;
                            string cObsOrd = "Sin Observaciones";

                            string cCodPrd = "UR-001-30";
                            decimal nLtsOrd = Convert.ToDecimal(txtLitros.Text);
                            decimal nCtoOrd = Convert.ToDecimal(txtCosto.Text);

                            int nDesOrd = desctoPorcentaje;

                            int nExisteOrden = ValidaNumeroOrden(nNumOrd);

                            if (nNumOrd == nExisteOrden)
                            {
                                nNumOrd = nNumOrd + 1;
                            }

                            //Valida facturas si existen en sqlServer y Access

                            bool bExisteFacturaOrden = existeFacturaOrden(cFacOrd);
                            bool bExiste_cConPol_POLID2 = Existe_cConPol_POLID2(cFacOrd);
                            bool bExiste_cFacAde_ADEFA2 = Existe_cFacAde_ADEFA2(cFacOrd);

                            if (bExisteFacturaOrden || bExiste_cConPol_POLID2 || bExiste_cFacAde_ADEFA2)
                            {
                                MessageBox.Show("Ya existe la factura");
                                return;
                            }

                            //Valida Folio Fiscal si existen en SQLServer y Access
                            bool bExisteFolioFiscal = existeFolFisOrden(cFolFis);
                            bool bExiste_cFolFis_POLID2 = Existe_cFolFis_POLID2(cFolFis);
                            if (bExisteFolioFiscal || bExiste_cFolFis_POLID2)
                            {
                                MessageBox.Show("Ya existe el folio fiscal");
                                return;
                            }

                            //graba en tabla orden
                            SQL = "Insert Into dbUrea.dbo.tbOrden (nNumOrd, nCveEmp, cPrvOrd, dFecOrd, nSubOrd, nIvaOrd, nTotOrd, nDesOrd, nLtsOrd, nCtoOrd, cCodPrd, nEdoOrd, cFacOrd, dFecFac, nPgoOrd, nPolPol, cFolFis, cObsOrd) " +
                                "Values (" + nNumOrd + "," + nCveEmp + ",'" + cPrvOrd + "','" + dFecOrd.ToString("yyyyMMdd") + "'," + nSubOrd + "," + nIvaOrd +
                                ", " + nTotOrd + ", " + nDesOrd + ", " + nLtsOrd + "," + nCtoOrd + ",'" + cCodPrd +
                                "'," + nEdoOrd + ",'" + cFacOrd + "','" + dFecFac.ToString("yyyyMMdd") + "'," + nPgoOrd + "," + nPolPol + ", '" + cFolFis + "', '" + cObsOrd + "')";

                            conexComprasUrea.ejecSql(SQL);


                            //valida registros grabados
                            bool bExisteOrden = false;

                            try
                            {
                                DataTable dtOrden = new DataTable();
                                SQL = "SELECT nNumOrd, dFecOrd, nEdoOrd, cPrvOrd, nSubOrd, nIvaOrd, nTotOrd FROM dbUrea.dbo.tbOrden where nNumOrd=" + nNumOrd;

                                dtOrden = conexComprasUrea.select(SQL);

                                if (dtOrden.Rows.Count > 0)
                                {
                                    bExisteOrden = true;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            bool validaPolizaInsertada = GenerarPoliza();
                            bool validaRegistroAdefa = InsertarADEFA2();
                            bool validaActualizacionUrea = actualizaExistenciaUrea(nLtsOrd);
                            bool bActualiza_UltFac_Cos = Actualiza_UltFac_Cos();


                            if (bExisteOrden && validaPolizaInsertada && validaRegistroAdefa && validaActualizacionUrea && bActualiza_UltFac_Cos)
                            {
                                // NOTIFICACIÓN DE NUEVA ORDEN CREADA
                                if (HubConnection != null && HubConnection.State == HubConnectionState.Connected)
                                {
                                    string nombreProveedor = "";
                                    if (cboProveedor.SelectedItem != null)
                                    {
                                        // Acceder al DataRowView del elemento seleccionado
                                        DataRowView drv = (DataRowView)cboProveedor.SelectedItem;
                                        // Obtener el valor de la columna 'cNomPrv'
                                        nombreProveedor = drv["cNomPrv"].ToString();
                                    }
                                    await HubConnection.InvokeAsync("EnviarNotificacion", new Notificacion
                                    {
                                        Usuario = UsuarioActual,
                                        Mensaje = $"Nueva orden creada #{nNumOrd} - {nombreProveedor} - {nLtsOrd} litros",
                                        Modulo = "Compras"
                                    });
                                    // Envía una señal adicional para actualizar los reportes
                                    await HubConnection.InvokeAsync("NotificacionCompraRealizada");
                                }
                                MessageBox.Show("Registros grabados correctamente");
                            }
                            else
                            {
                                MessageBox.Show("Los registros no se grabaron correctamente");
                            }



                            LimpiarControles();
                            HabilitaBotones(1);
                            HabilitaControles(1);
                            bModifica = false;
                            bNuevo = false;
                            desctoPorcentaje = 0;
                            lblDescto.Text = "( % )";
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
                    int nPolPol = Convert.ToInt32(dtOrdenModificar.Rows[0]["nPolPol"]);

                    if (nEdoOrd == 1)
                    {
                        if (txtNumero.Text != "" && cboProveedor.SelectedIndex > -1 && cboTipo.SelectedIndex > -1)
                        {
                            if (MessageBox.Show("Ya reviso que estén correctos los datos de su orden???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                SQL = "Delete from dbUrea.dbo.tbOrden where nnumord=" + nNumOrd;
                                bool bEliminaOrden = conexComprasUrea.ejecSql(SQL);

                                if (!bEliminaOrden)
                                {
                                    MessageBox.Show("No se puede realizar la modificación correctamente");
                                    return;
                                }

                                byte nCveEmp = 2;
                                string cPrvOrd = cboProveedor.SelectedValue!.ToString()!;
                                DateTime dFecOrd = dtpOrden.Value;
                                decimal nSubOrd = Convert.ToDecimal(txtSubtotal.Text);
                                decimal nIvaOrd = Convert.ToDecimal(txtIva.Text);
                                decimal nTotOrd = nSubOrd + nIvaOrd;
                                string cFacOrd = txtFactura.Text;
                                DateTime dFecFac = dtpFactura.Value;
                                byte nPgoOrd = Convert.ToByte(cboTipo.SelectedIndex + 1);

                                string cFolFis = txtFolioFiscal.Text;
                                string cObsOrd = "Sin Observaciones";

                                string cCodPrd = "UR-001-30";
                                decimal nLtsOrd = Convert.ToDecimal(txtLitros.Text);
                                decimal nCtoOrd = Convert.ToDecimal(txtCosto.Text);

                                int nDesOrd = desctoPorcentaje;

                                int nExisteOrden = ValidaNumeroOrden(nNumOrd);

                                if (nNumOrd == nExisteOrden)
                                {
                                    nNumOrd = nNumOrd + 1;
                                }


                                //valida factura anterior con la factura nueva
                                if (cFacOrd != facturaTemporal)
                                {
                                    bool bExisteFacturaOrden = existeFacturaOrden(cFacOrd);
                                    bool bExiste_cConPol_POLID2 = Existe_cConPol_POLID2(cFacOrd);
                                    bool bExiste_cFacAde_ADEFA2 = Existe_cFacAde_ADEFA2(cFacOrd);
                                    if (bExisteFacturaOrden || bExiste_cConPol_POLID2 || bExiste_cFacAde_ADEFA2)
                                    {
                                        MessageBox.Show("Ya existe la factura");
                                        return;
                                    }
                                }

                                //valida folfis anterior con el nuevo
                                if (cFolFis != folfisTemporal)
                                {
                                    bool bExisteFolioFiscal = existeFolFisOrden(cFolFis);
                                    bool bExiste_cFolFis_POLID2 = Existe_cFolFis_POLID2(cFolFis);
                                    if (bExisteFolioFiscal || bExiste_cFolFis_POLID2)
                                    {
                                        MessageBox.Show("Ya existe el folio fiscal");
                                        return;
                                    }
                                }

                                //graba en tabla orden
                                SQL = "Insert Into dbUrea.dbo.tbOrden (nNumOrd, nCveEmp, cPrvOrd, dFecOrd, nSubOrd, nIvaOrd, nTotOrd, nDesOrd, nLtsOrd, nCtoOrd, cCodPrd, nEdoOrd, cFacOrd, dFecFac, nPgoOrd, nPolPol, cFolFis, cObsOrd) " +
                                "Values (" + nNumOrd + "," + nCveEmp + ",'" + cPrvOrd + "','" + dFecOrd.ToString("yyyyMMdd") + "'," + nSubOrd + "," + nIvaOrd +
                                ", " + nTotOrd + ", " + nDesOrd + ", " + nLtsOrd + "," + nCtoOrd + ",'" + cCodPrd +
                                "'," + nEdoOrd + ",'" + cFacOrd + "','" + dFecFac.ToString("yyyyMMdd") + "'," + nPgoOrd + "," + nPolPol + ", '" + cFolFis + "', '" + cObsOrd + "')";

                                conexComprasUrea.ejecSql(SQL);

                                //valida registros grabados
                                bool bExisteOrden = false;
                                bool bActualizaPoliza = false;
                                bool bActualizaAdefa2 = false;
                                bool bActualiza_UltFac_Cos = false;

                                try
                                {
                                    SQL = "SELECT nNumOrd, dFecOrd, nEdoOrd, cPrvOrd, nSubOrd, nIvaOrd, nTotOrd FROM dbUrea.dbo.tbOrden where nNumOrd=" + nNumOrd;

                                    DataTable dtOrden = conexComprasUrea.select(SQL);

                                    if (dtOrden.Rows.Count > 0)
                                    {
                                        bExisteOrden = true;
                                        bActualizaPoliza = ActualizaPoliza();
                                        bActualizaAdefa2 = ActualizaADEFA2();
                                        bActualiza_UltFac_Cos = Actualiza_UltFac_Cos();
                                        facturaTemporal = "";
                                        folfisTemporal = "";
                                    }
                                }
                                catch (Exception ex)
                                {
                                }

                                if (bExisteOrden && bActualizaPoliza && bActualizaAdefa2 && bActualiza_UltFac_Cos)
                                {
                                    // NOTIFICACIÓN DE ORDEN MODIFICADA
                                    if (HubConnection != null && HubConnection.State == HubConnectionState.Connected)
                                    {
                                        await HubConnection.InvokeAsync("EnviarNotificacion", new Notificacion
                                        {
                                            Usuario = UsuarioActual,
                                            Mensaje = $"Orden modificada #{nNumOrd} - Nuevo total: {nTotOrd:C}",
                                            Modulo = "Compras"
                                        });
                                    }
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
                                desctoPorcentaje = 0;
                                lblDescto.Text = "( % )";
                            }
                        }
                        else
                        {
                            MessageBox.Show("falta capturar algún dato");
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnGrabar_Click " + ex.Message);
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
                    if (txtLitros.Text.Contains("."))
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
                    if (txtLitros.Text != "0" && txtLitros.Text != "" && txtCosto.Text != "0" && txtCosto.Text != "")
                    {
                        int Orden = Convert.ToInt32(txtNumero.Text);
                        decimal Cantidad = Convert.ToDecimal(txtLitros.Text);
                        decimal Costo = Convert.ToDecimal(txtCosto.Text);
                        decimal Importe = Costo * Cantidad;

                        Decimal nSubTotal = 0;
                        nSubTotal = nSubTotal + Convert.ToDecimal(Importe);

                        txtSubtotal.Text = nSubTotal.ToString("F2");
                        decimal nIva = nSubTotal * Convert.ToDecimal(0.16);
                        txtIva.Text = nIva.ToString("F2");
                        decimal Total = nSubTotal + nIva;
                        txtTotal.Text = Total.ToString("F2");
                        txtDescuento.Text = string.Empty;
                        btnGrabar.Enabled = true;
                        btnGrabar.BackColor = originalColorBtnGrabar;
                        lblDescto.Text = "( % )";
                        txtPagoResto.Text = txtTotal.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtCosto_KeyPress " + ex.Message);
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


                            decimal cLitros = Convert.ToDecimal(dtOrden.Rows[0]["nLtsOrd"]);
                            txtLitros.Text = cLitros.ToString("F2");
                            decimal Costo = Convert.ToDecimal(dtOrden.Rows[0]["nCtoOrd"]);
                            txtCosto.Text = Costo.ToString("F2");

                            string Factura = dtOrden.Rows[0]["cFacOrd"].ToString()!;
                            txtFactura.Text = Factura;
                            DateTime dFecFac = DateTime.Parse(dtOrden.Rows[0]["dFecFac"].ToString()!);
                            dtpFactura.Value = dFecFac;

                            int Tipo = Convert.ToInt32(dtOrden.Rows[0]["nPgoOrd"]);
                            cboTipo.SelectedIndex = Tipo - 1;

                            txtFolioFiscal.Text = dtOrden.Rows[0]["cFolFis"].ToString()!;

                            decimal Subtotal = Convert.ToDecimal(dtOrden.Rows[0]["nSubOrd"]);
                            txtSubtotal.Text = Subtotal.ToString("F2");

                            decimal Iva = Convert.ToDecimal(dtOrden.Rows[0]["nIvaOrd"]);
                            txtIva.Text = Iva.ToString("F2");

                            decimal Total = Convert.ToDecimal(dtOrden.Rows[0]["nTotOrd"]);
                            txtTotal.Text = Total.ToString("F2");

                            desctoPorcentaje = Convert.ToInt32(dtOrden.Rows[0]["nDesOrd"]);
                            lblDescto.Text = "(" + desctoPorcentaje.ToString() + " %)";

                            decimal Importe = Costo * cLitros;
                            Decimal descuento = Importe * desctoPorcentaje / 100;

                            txtDescuento.Text = descuento.ToString("F2");




                            DataTable dtPagos = new DataTable();
                            dtPagos.Clear();
                            dtPagos = CargaPagos(nNumOrd);

                            dgvPagos.DataSource = null;
                            dgvPagos.Columns.Clear();

                            decimal TotalPagos = 0;
                            bool existenPagos = false;
                            if (dtPagos.Rows.Count > 0)
                            {
                                existenPagos = true;
                                dgvPagos.DataSource = dtPagos;

                                // Elimina la columna 'btnEliminar' si ya existe antes de agregarla.
                                if (!dgvPagos.Columns.Contains("btnEliminar"))
                                {
                                    DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                                    btnEliminar.Name = "btnEliminar";
                                    btnEliminar.HeaderText = "";
                                    btnEliminar.Text = "Eliminar";
                                    btnEliminar.FlatStyle = FlatStyle.Flat;
                                    btnEliminar.UseColumnTextForButtonValue = true;
                                    btnEliminar.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F08080");  // Fondo rojo
                                    btnEliminar.DefaultCellStyle.ForeColor = Color.DarkRed; // Texto blanco
                                    dgvPagos.Columns.Add(btnEliminar);
                                }

                                // columna 'btnEliminar' siempre al final.
                                dgvPagos.Columns["btnEliminar"].DisplayIndex = dgvPagos.Columns.Count - 1;

                                foreach (DataRow dr in dtPagos.Rows)
                                {
                                    decimal filaPago = Convert.ToDecimal(dr["Importe"]);
                                    TotalPagos = TotalPagos + filaPago;
                                }
                            }

                            txtTotalPagos.Text = TotalPagos.ToString("F2");

                            decimal TotalOrden = Convert.ToDecimal(txtTotal.Text);

                            txtTotalPagos.Text = TotalPagos.ToString("F2");
                            decimal restoPago = TotalOrden - TotalPagos;
                            txtPagoResto.Text = restoPago.ToString();

                            if (TotalOrden > TotalPagos)
                            {
                                btnAgregarPago.Enabled = true;
                                btnAgregarPago.BackColor = originalColorBtnAgregarPago;
                            }

                            if (TotalOrden == TotalPagos)
                            {
                                dgvPagos.DataSource = null;
                                dgvPagos.Columns.Clear();
                                dgvPagos.DataSource = dtPagos;
                                btnAgregarPago.Enabled = false;
                                btnAgregarPago.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                            }


                            HabilitaBotones(3);

                            txtBuscar.Text = string.Empty;

                            if (nEdoVal == 1)
                            {
                                btnModificar.Enabled = true;
                                btnModificar.BackColor = originalColorBtnModificar;
                                if (existenPagos)
                                {
                                    btnModificar.Enabled = false;
                                    btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                                }

                                txtEstado.Text = "Emitido";
                                txtEstado.BackColor = originalColorTxtEstado;
                                txtEstado.ForeColor = originalForeColorTxtEstado;

                            }
                            else if (nEdoVal > 1)
                            {
                                btnModificar.Enabled = false;
                                btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                                txtEstado.Text = "Terminado";
                                txtEstado.BackColor = Color.LightGreen;
                                txtEstado.ForeColor = Color.DarkGreen;

                            }
                        }
                        else
                        {
                            LimpiarControles();
                            btnModificar.Enabled = false;
                            btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                            btnImprimir.Enabled = false;
                            btnImprimir.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                            btnAgregarPago.Enabled = false;
                            btnAgregarPago.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                            MessageBox.Show("Folio de orden incorrecto");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtBuscar_KeyPress " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text != "" && cboProveedor.SelectedIndex > -1)
                {
                    bModifica = true;
                    bNuevo = false;

                    //toma el valor ya insertado en la base de datos cFacOrd
                    if (txtFactura.Text != "")
                    {
                        facturaTemporal = txtFactura.Text;
                    }

                    //toma el valor ya insertado en la base de datos cFolFis
                    if (txtFolioFiscal.Text != "")
                    {
                        folfisTemporal = txtFolioFiscal.Text;
                    }

                    int nNumOrd = Convert.ToInt32(txtNumero.Text);

                    dtOrdenModificar = CargaOrdenes(nNumOrd);

                    if (dtOrdenModificar.Rows.Count > 0)
                    {
                        int nEdoOrd = Convert.ToInt32(dtOrdenModificar.Rows[0]["Estado"]);
                        if (nEdoOrd == 1)
                        {
                            HabilitaControles(3);
                            HabilitaBotones(2);
                        }
                        else
                        {
                            MessageBox.Show("Solo se puede modificar una orden Emitida");
                            return;
                        }
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
                    frmComplementoPago.ConexComplemento = conexComprasUrea;
                    this.Visible = false;
                    frmComplementoPago.ShowDialog();
                    this.Visible = true;

                    DataTable dtPagos = new DataTable();
                    dtPagos.Clear();
                    dtPagos = CargaPagos(Orden);

                    dgvPagos.DataSource = null;
                    dgvPagos.Columns.Clear();

                    decimal TotalPagos = 0;
                    bool existenPagos = false;
                    if (dtPagos.Rows.Count > 0)
                    {
                        existenPagos = true;
                        dgvPagos.DataSource = dtPagos;

                        // Elimina la columna 'btnEliminar' si ya existe antes de agregarla.
                        if (!dgvPagos.Columns.Contains("btnEliminar"))
                        {
                            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                            btnEliminar.Name = "btnEliminar";
                            btnEliminar.HeaderText = "";
                            btnEliminar.Text = "Eliminar";
                            btnEliminar.FlatStyle = FlatStyle.Flat;
                            btnEliminar.UseColumnTextForButtonValue = true;
                            btnEliminar.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F08080");  // Fondo rojo
                            btnEliminar.DefaultCellStyle.ForeColor = Color.DarkRed; // Texto blanco
                            dgvPagos.Columns.Add(btnEliminar);
                        }

                        // columna 'btnEliminar' siempre al final.
                        dgvPagos.Columns["btnEliminar"].DisplayIndex = dgvPagos.Columns.Count - 1;

                        foreach (DataRow dr in dtPagos.Rows)
                        {
                            decimal filaPago = Convert.ToDecimal(dr["Importe"]);
                            TotalPagos = TotalPagos + filaPago;
                        }
                    }

                    txtTotalPagos.Text = TotalPagos.ToString("F2");
                    decimal restoPago = ImporteFactura - TotalPagos;
                    txtPagoResto.Text = restoPago.ToString();
                    if (ImporteFactura == TotalPagos)
                    {
                        btnAgregarPago.Enabled = false;
                        btnAgregarPago.BackColor = ColorTranslator.FromHtml("#FFFFFF");

                        SQL = "update dbUrea.dbo.tbOrden set nEdoOrd=2 where nNumOrd= " + Orden;
                        bool bActualizaOrden = conexComprasUrea.ejecSql(SQL);


                        if (bActualizaOrden)
                        {
                            dgvPagos.DataSource = null;
                            dgvPagos.Columns.Clear();
                            dgvPagos.DataSource = dtPagos;

                            txtEstado.Text = "Terminado";
                            txtEstado.BackColor = Color.LightGreen;
                            txtEstado.ForeColor = Color.DarkGreen;
                        }
                        else
                        {
                            MessageBox.Show("No se termino la orden correctamente");
                        }
                    }

                    if (existenPagos)
                    {
                        btnModificar.Enabled = false;
                        btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregarPago_Click " + ex.Message);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (txtLitros.Text != "0" && txtLitros.Text != "" && txtCosto.Text != "0" && txtCosto.Text != "")
            {
                int Orden = Convert.ToInt32(txtNumero.Text);
                decimal Cantidad = Convert.ToDecimal(txtLitros.Text);
                decimal Costo = Convert.ToDecimal(txtCosto.Text);
                decimal Importe = Costo * Cantidad;

                decimal descuento = 0;
                int porcentaje = 0;

                // Validamos si hay porcentaje válido
                if (!string.IsNullOrEmpty(txtPorcentaje.Text) && txtPorcentaje.Text != "0")
                {
                    porcentaje = Convert.ToInt32(txtPorcentaje.Text);
                    descuento = Importe * porcentaje / 100;
                    lblDescto.Text = $"({porcentaje} %)";
                    txtDescuento.Text = descuento.ToString("F2");
                }
                else
                {
                    lblDescto.Text = "( % )";
                    txtDescuento.Text = "";
                }

                decimal nSubTotal = Importe - descuento;
                txtSubtotal.Text = nSubTotal.ToString("F2");

                decimal nIva = nSubTotal * 0.16m;
                txtIva.Text = nIva.ToString("F2");

                decimal Total = nSubTotal + nIva;
                txtTotal.Text = Total.ToString("F2");

                desctoPorcentaje = porcentaje;
                txtPorcentaje.Text = string.Empty;
                txtPagoResto.Text = txtTotal.Text;
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                printCompraUrea = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                printCompraUrea.PrinterSettings = ps;
                printCompraUrea.PrintPage += Imprimir;
                printCompraUrea.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnImprimir_Click " + ex.Message);
            }
        }

        private void cboProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtLitros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                txtCosto.Focus();
            }
            else if (char.IsLetter(e.KeyChar))
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
                if (txtLitros.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            else if ((Keys)e.KeyChar == Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnAplicar.Focus();
            }
            else if (char.IsLetter(e.KeyChar))
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
                e.Handled = true;
            }
            else if ((char)e.KeyChar == ',')
            {
                e.Handled = true;
            }
            else if ((Keys)e.KeyChar == Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void dgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPagos.Columns.Contains("btnEliminar"))
            {
                // Verificar si se ha hecho clic en la columna de botones (btnEliminar)
                if (e.ColumnIndex == dgvPagos.Columns["btnEliminar"].Index)
                {
                    // Obtener el ID del registro que se va a eliminar
                    string FolioFiscalPago = dgvPagos.Rows[e.RowIndex].Cells["FolioFiscal"].Value.ToString()!;

                    // Llamar a un método para eliminar el registro de la base de datos
                    EliminarPago(FolioFiscalPago);

                    // Eliminar la fila correspondiente
                    dgvPagos.Rows.RemoveAt(e.RowIndex);

                    // Volver a cargar los datos para reflejar la eliminación
                    int orden = Convert.ToInt32(txtNumero.Text);
                    string FolioFiscal = txtFolioFiscal.Text;
                    string Factura = txtFactura.Text;
                    decimal ImporteFactura = Convert.ToDecimal(txtTotal.Text);
                    decimal ImportePagos = Convert.ToDecimal(txtTotalPagos.Text);

                    DataTable dtPagos = new DataTable();
                    dtPagos.Clear();
                    dtPagos = CargaPagos(orden);

                    dgvPagos.DataSource = null;
                    dgvPagos.Columns.Clear();

                    decimal TotalPagos = 0;
                    bool existenPagos = false;
                    if (dtPagos.Rows.Count > 0)
                    {
                        existenPagos = true;
                        dgvPagos.DataSource = dtPagos;

                        // Elimina la columna 'btnEliminar' si ya existe antes de agregarla.
                        if (!dgvPagos.Columns.Contains("btnEliminar"))
                        {
                            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                            btnEliminar.Name = "btnEliminar";
                            btnEliminar.HeaderText = "";
                            btnEliminar.Text = "Eliminar";
                            btnEliminar.FlatStyle = FlatStyle.Flat;
                            btnEliminar.UseColumnTextForButtonValue = true;
                            btnEliminar.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F08080");  // Fondo rojo
                            btnEliminar.DefaultCellStyle.ForeColor = Color.DarkRed; // Texto blanco
                            dgvPagos.Columns.Add(btnEliminar);
                        }

                        // columna 'btnEliminar' siempre al final.
                        dgvPagos.Columns["btnEliminar"].DisplayIndex = dgvPagos.Columns.Count - 1;

                        foreach (DataRow dr in dtPagos.Rows)
                        {
                            decimal filaPago = Convert.ToDecimal(dr["Importe"]);
                            TotalPagos = TotalPagos + filaPago;
                        }
                    }

                    txtTotalPagos.Text = TotalPagos.ToString("F2");
                    decimal restoPago = ImporteFactura - TotalPagos;
                    txtPagoResto.Text = restoPago.ToString();
                    if (ImporteFactura > TotalPagos)
                    {
                        btnAgregarPago.Enabled = true;
                        btnAgregarPago.BackColor = originalColorBtnAgregarPago;

                        SQL = "update dbUrea.dbo.tbOrden set nEdoOrd=1 where nNumOrd= " + orden;
                        bool bActualizaOrden = conexComprasUrea.ejecSql(SQL);


                        if (bActualizaOrden)
                        {
                            txtEstado.Text = "Emitido";
                            txtEstado.BackColor = originalColorTxtEstado;
                            txtEstado.ForeColor = originalForeColorTxtEstado;
                        }
                        else
                        {
                            MessageBox.Show("No se actualizo la orden correctamente");
                        }
                    }

                    //Desactiva el boton modificar si existen Pagos
                    if (existenPagos)
                    {
                        btnModificar.Enabled = false;
                        btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else
                    {
                        btnModificar.Enabled = true;
                        btnModificar.BackColor = originalColorBtnModificar;
                    }
                }
            }
        }

        private void txtLitros_TextChanged(object sender, EventArgs e)
        {
            btnGrabar.Enabled = false;
            btnGrabar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            txtSubtotal.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            txtIva.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtPagoResto.Text = string.Empty;
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            btnGrabar.Enabled = false;
            btnGrabar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            txtSubtotal.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            txtIva.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtPagoResto.Text = string.Empty;
        }

        private void pnlEncabezado_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            Point punto = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
            mx = punto.X - this.Location.X;
            my = punto.Y - this.Location.Y;
        }

        //Movimiento de ventana de panel encabezado
        private void pnlEncabezado_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void pnlEncabezado_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
