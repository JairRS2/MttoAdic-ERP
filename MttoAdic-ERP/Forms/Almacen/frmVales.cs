
using Syncfusion.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmVales : MetroForm
    {
        DataTable dtEmpresa = new DataTable();
        DataTable dtPersonalSolicita = new DataTable();
        DataTable dtPersonalAutoriza = new DataTable();
        DataTable dtPersonalEntrega = new DataTable();
        DataTable dtBitacora = new DataTable();
        DataTable dtProductosGrid = new DataTable();
        DataTable dtValeModificar = new DataTable();
        DataTable dtDetalleModificar = new DataTable();

        bool bNuevo = false;
        bool bModifica = false;
        bool bTermina = false;

        private PrintDocument PD = new PrintDocument();
        private PrintPreviewDialog PPD = new PrintPreviewDialog();

        string SQL = string.Empty;
        string CodigoBuscar = string.Empty;

        public csConexionSQL conexVales;
        public csConexionSQL ConexVales { set { this.conexVales = value; } }

        public frmVales()
        {
            try
            {
                InitializeComponent();
                ApplyModernStyle();
                PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmVales " + ex.Message);
            }
        }

        private void frmElaboracionVales_Load(object sender, EventArgs e)
        {
            try
            {
                CargaEmpresas();
                CargaPersonal();
                HabilitaControles(1);
                HabilitaBotones(1);

                dtProductosGrid.Columns.Add("No_Vale", typeof(int));
                dtProductosGrid.Columns.Add("Cantidad", typeof(decimal));
                dtProductosGrid.Columns.Add("Codigo", typeof(string));
                dtProductosGrid.Columns.Add("Precio", typeof(decimal));
                dtProductosGrid.Columns.Add("Importe", typeof(decimal));
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmElaboracionVales_Load " + ex.Message);
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
                string Empresa = txtEmpresa.Text;
                Font fontTitulo = new Font("Arial", 18, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel);
                Rectangle rectTitulo = new Rectangle(150, 20, 500, 30);
                StringFormat formTitulo = new StringFormat();
                formTitulo.Alignment = StringAlignment.Center;
                formTitulo.LineAlignment = StringAlignment.Center;
                e.Graphics!.FillRectangle(Brushes.LightGray, rectTitulo);
                e.Graphics.DrawString(txtEmpresa.Text, fontTitulo, Brushes.Black, rectTitulo, formTitulo);

                StringFormat formSub = new StringFormat();
                formSub.Alignment = StringAlignment.Center;
                formSub.LineAlignment = StringAlignment.Center;
                Font fontSub = new Font("Arial", 16, FontStyle.Underline, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Entrega de refacciones", fontSub, Brushes.Black, new RectangleF(250, 50, 300, 30), formSub);

                Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
                e.Graphics.DrawRectangle(blackPen, 20, 90, 250, 30);
                Font fontNumVale = new Font("Times New Roman", 18, FontStyle.Bold, GraphicsUnit.Pixel);
                Rectangle rectNumVale = new Rectangle(20, 90, 250, 30);
                StringFormat formNumVale = new StringFormat();
                formNumVale.Alignment = StringAlignment.Center;
                formNumVale.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Número de Vale : " + txtNumeroVale.Text, fontNumVale, Brushes.Black, rectNumVale, formNumVale);

                StringFormat formBitacora = new StringFormat();
                formBitacora.Alignment = StringAlignment.Center;
                formBitacora.LineAlignment = StringAlignment.Center;
                Font fontBitacora = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Número de Bitácora : ", fontBitacora, Brushes.Black, new RectangleF(280, 90, 200, 30), formBitacora);

                StringFormat formNumBit = new StringFormat();
                formNumBit.Alignment = StringAlignment.Center;
                formNumBit.LineAlignment = StringAlignment.Center;
                Font fontNumBit = new Font("Times New Roman", 18, FontStyle.Bold, GraphicsUnit.Pixel);
                e.Graphics.DrawString(txtBitacora.Text, fontNumBit, Brushes.Black, new RectangleF(450, 90, 100, 30), formNumBit);

                StringFormat formUnidad = new StringFormat();
                formUnidad.Alignment = StringAlignment.Center;
                formUnidad.LineAlignment = StringAlignment.Center;
                Font fontUnidad = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Número de Unidad : ", fontUnidad, Brushes.Black, new RectangleF(550, 90, 200, 30), formUnidad);

                StringFormat formNumUni = new StringFormat();
                formNumUni.Alignment = StringAlignment.Center;
                formNumUni.LineAlignment = StringAlignment.Center;
                Font fontNumUni = new Font("Times New Roman", 18, FontStyle.Bold, GraphicsUnit.Pixel);
                e.Graphics.DrawString(txtUnidad.Text, fontNumUni, Brushes.Black, new RectangleF(700, 90, 100, 30), formNumUni);

                StringFormat formFecElab = new StringFormat();
                formFecElab.Alignment = StringAlignment.Near;
                formFecElab.LineAlignment = StringAlignment.Center;
                Font fontFecElab = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Fecha de Elaboración : ", fontFecElab, Brushes.Black, new RectangleF(20, 130, 200, 30), formFecElab);

                StringFormat formdtpElab = new StringFormat();
                formdtpElab.Alignment = StringAlignment.Center;
                formdtpElab.LineAlignment = StringAlignment.Center;
                Font fontdtpElab = new Font("Times New Roman", 18, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString(dtpSolicitud.Value.ToString("dd/MM/yyyy"), fontdtpElab, Brushes.Black, new RectangleF(200, 130, 100, 30), formdtpElab);

                StringFormat formFecVale = new StringFormat();
                formFecVale.Alignment = StringAlignment.Center;
                formFecVale.LineAlignment = StringAlignment.Center;
                Font fontFecVale = new Font("Times New Roman", 16, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Fecha del Vale : ", fontFecVale, Brushes.Black, new RectangleF(280, 130, 200, 30), formFecVale);

                StringFormat formdtpVale = new StringFormat();
                formdtpVale.Alignment = StringAlignment.Center;
                formdtpVale.LineAlignment = StringAlignment.Center;
                Font fontdtpVale = new Font("Times New Roman", 18, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Pixel);
                e.Graphics.DrawString(dtpVale.Value.ToString("dd/MM/yyyy"), fontdtpVale, Brushes.Black, new RectangleF(440, 130, 100, 30), formdtpVale);

                StringFormat formTituloEstado = new StringFormat();
                formTituloEstado.Alignment = StringAlignment.Center;
                formTituloEstado.LineAlignment = StringAlignment.Center;
                Font fontTituloEstado = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Estado", fontTituloEstado, Brushes.Black, new RectangleF(590, 130, 200, 30), formTituloEstado);

                StringFormat formFecEnt = new StringFormat();
                formFecEnt.Alignment = StringAlignment.Near;
                formFecEnt.LineAlignment = StringAlignment.Center;
                Font fontFecEnt = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Fecha de Entrega : ", fontFecEnt, Brushes.Black, new RectangleF(20, 160, 200, 30), formFecEnt);

                StringFormat formdtpEnt = new StringFormat();
                formdtpEnt.Alignment = StringAlignment.Center;
                formdtpEnt.LineAlignment = StringAlignment.Center;
                Font fontdtpEnt = new Font("Times New Roman", 18, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString(dtpEntrega.Value.ToString("dd/MM/yyyy"), fontdtpEnt, Brushes.Black, new RectangleF(200, 160, 100, 30), formdtpEnt);

                StringFormat formEstado = new StringFormat();
                formEstado.Alignment = StringAlignment.Center;
                formEstado.LineAlignment = StringAlignment.Center;
                Font fontEstado = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);
                e.Graphics.DrawString(txtEstado.Text, fontEstado, Brushes.Black, new RectangleF(590, 160, 200, 30), formEstado);

                StringFormat formCodigo = new StringFormat();
                formCodigo.Alignment = StringAlignment.Center;
                formCodigo.LineAlignment = StringAlignment.Center;
                Font fontCodigo = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Código", fontCodigo, Brushes.Black, new RectangleF(20, 200, 100, 30), formCodigo);

                StringFormat formCantidad = new StringFormat();
                formCantidad.Alignment = StringAlignment.Center;
                formCantidad.LineAlignment = StringAlignment.Center;
                Font fontCantidad = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Cantidad", fontCantidad, Brushes.Black, new RectangleF(120, 200, 100, 30), formCantidad);

                StringFormat formDescripcion = new StringFormat();
                formDescripcion.Alignment = StringAlignment.Center;
                formDescripcion.LineAlignment = StringAlignment.Center;
                Font fontDescripcion = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Descripción", fontDescripcion, Brushes.Black, new RectangleF(220, 200, 400, 30), formDescripcion);

                StringFormat formPrecio = new StringFormat();
                formPrecio.Alignment = StringAlignment.Far;
                formPrecio.LineAlignment = StringAlignment.Center;
                Font fontPrecio = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Precio", fontPrecio, Brushes.Black, new RectangleF(580, 200, 100, 30), formPrecio);

                StringFormat formImporte = new StringFormat();
                formImporte.Alignment = StringAlignment.Far;
                formImporte.LineAlignment = StringAlignment.Center;
                Font fontImporte = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Importe", fontImporte, Brushes.Black, new RectangleF(680, 200, 100, 30), formImporte);

                Pen PenInicioDetalle = new Pen(Brushes.Black);
                PenInicioDetalle.Width = 1.0F;
                e.Graphics.DrawRectangle(PenInicioDetalle, new Rectangle(20, 230, 780, 1));

                int Detalle = 232;

                StringFormat formIzquierda = new StringFormat();
                formIzquierda.Alignment = StringAlignment.Near;
                formIzquierda.LineAlignment = StringAlignment.Center;

                StringFormat formDerecha = new StringFormat();
                formDerecha.Alignment = StringAlignment.Far;
                formDerecha.LineAlignment = StringAlignment.Center;

                foreach (DataRow fila in dtProductosGrid.Rows)
                {
                    string codigo = fila["Codigo"].ToString()!;
                    e.Graphics.DrawString(codigo, fontCodigo, Brushes.Black, new RectangleF(25, Detalle, 100, 30), formIzquierda);
                    decimal ncantidad = Convert.ToDecimal(fila["Cantidad"]);
                    string cantidad = ncantidad.ToString("F2");
                    e.Graphics.DrawString(cantidad, fontCantidad, Brushes.Black, new RectangleF(120, Detalle, 90, 30), formDerecha);
                    string descripcion = fila["Descripcion"].ToString()!;
                    e.Graphics.DrawString(descripcion, fontDescripcion, Brushes.Black, new RectangleF(225, Detalle, 400, 30), formIzquierda);
                    decimal nPrecio = Convert.ToDecimal(fila["Precio"]);
                    string precio = nPrecio.ToString("F2");
                    e.Graphics.DrawString(precio, fontPrecio, Brushes.Black, new RectangleF(580, Detalle, 100, 30), formDerecha);
                    decimal nImporte = Convert.ToDecimal(fila["Importe"]);
                    string importe = nImporte.ToString("F2");
                    e.Graphics.DrawString(importe, fontImporte, Brushes.Black, new RectangleF(680, Detalle, 100, 30), formDerecha);
                    Detalle += 15;
                }

                Pen PenFinDetalle = new Pen(Brushes.Black);
                PenFinDetalle.Width = 1.0F;
                e.Graphics.DrawRectangle(PenFinDetalle, new Rectangle(20, Detalle + 8, 780, 1));

                Font fontTotal = new Font("Times New Roman", 18, FontStyle.Bold, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Total Vale : ", fontTotal, Brushes.Black, new RectangleF(440, Detalle + 10, 100, 30), formdtpVale);
                e.Graphics.DrawString(txtTotal.Text, fontTotal, Brushes.Black, new RectangleF(580, Detalle + 10, 100, 30), formDerecha);

                StringFormat formSolicita = new StringFormat();
                formSolicita.Alignment = StringAlignment.Center;
                formSolicita.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Solicita", fontCodigo, Brushes.Black, new RectangleF(40, Detalle + 50, 250, 30), formSolicita);
                e.Graphics.DrawString("Autoriza", fontCodigo, Brushes.Black, new RectangleF(290, Detalle + 50, 250, 30), formSolicita);
                e.Graphics.DrawString("Entrega", fontCodigo, Brushes.Black, new RectangleF(540, Detalle + 50, 250, 30), formSolicita);

                Pen PenSolicita = new Pen(Brushes.Black);
                PenSolicita.Width = 1.0F;
                e.Graphics.DrawRectangle(PenSolicita, new Rectangle(40, Detalle + 100, 230, 1));

                Pen PenAutoriza = new Pen(Brushes.Black);
                PenAutoriza.Width = 1.0F;
                e.Graphics.DrawRectangle(PenAutoriza, new Rectangle(290, Detalle + 100, 230, 1));

                Pen PenEntrega = new Pen(Brushes.Black);
                PenEntrega.Width = 1.0F;
                e.Graphics.DrawRectangle(PenEntrega, new Rectangle(540, Detalle + 100, 230, 1));

                Font fontNombres = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                string Solicita = cboSolicita.SelectedValue!.ToString()! + " " + cboSolicita.Text;
                e.Graphics.DrawString(Solicita, fontNombres, Brushes.Black, new RectangleF(40, Detalle + 105, 250, 30), formCodigo);
                string Autoriza = cboAutoriza.SelectedValue!.ToString()! + " " + cboAutoriza.Text;
                e.Graphics.DrawString(Autoriza, fontNombres, Brushes.Black, new RectangleF(290, Detalle + 105, 250, 30), formCodigo);
                string Entrega = string.Empty;
                if (cboEntrega.SelectedIndex > -1)
                {
                    Entrega = cboEntrega.SelectedValue!.ToString()! + " " + cboEntrega.Text;
                }
                else
                {
                    Entrega = cboAutoriza.SelectedValue!.ToString()! + " " + cboAutoriza.Text;
                }

                e.Graphics.DrawString(Entrega, fontNombres, Brushes.Black, new RectangleF(540, Detalle + 105, 250, 30), formCodigo);

                e.Graphics.DrawString("Nota : los costos no incluyen iva", fontNombres, Brushes.Black, new RectangleF(20, Detalle + 125, 250, 30), formCodigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PD_PrintPage " + ex.Message);
            }
        }

        void CargaEmpresas()
        {
            try
            {
                SQL = "SELECT nCveEmp,cNomEmp FROM dbRelacioneslaborales.dbo.tbEmpresa order by nCveEmp";
                dtEmpresa = conexVales.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaEmpresas " + ex.Message);
            }
        }

        void CargaPersonal()
        {
            try
            {
                SQL = "SELECT per.cCvePer, per.cNomPer, org.nCvePue, per.nEdoPer FROM dbRelacionesLaborales.dbo.tbPersonal AS per " +
                    "INNER JOIN dbRelacionesLaborales.dbo.tbOrgPer AS org ON per.nCveOrg = org.nCveOrg " +
                    "WHERE (per.nEdoPer <> 7) AND (org.nCvePue IN (16, 66, 34, 35, 36, 37, 38, 40, 41, 42, 47, 48, 49, 51, 52, 53, 55, 67, 70, 20)) " +
                    "ORDER BY per.cNomPer";

                dtPersonalSolicita = conexVales.select(SQL);
                cboSolicita.DataSource = null;
                cboSolicita.DataSource = dtPersonalSolicita;
                cboSolicita.DisplayMember = "cNomPer";
                cboSolicita.ValueMember = "cCvePer";
                cboSolicita.SelectedIndex = -1;

                dtPersonalAutoriza = conexVales.select(SQL);
                cboAutoriza.DataSource = null;
                cboAutoriza.DataSource = dtPersonalAutoriza;
                cboAutoriza.DisplayMember = "cNomPer";
                cboAutoriza.ValueMember = "cCvePer";
                cboAutoriza.SelectedIndex = -1;

                dtPersonalEntrega = conexVales.select(SQL);
                cboEntrega.DataSource = null;
                cboEntrega.DataSource = dtPersonalEntrega;
                cboEntrega.DisplayMember = "cNomPer";
                cboEntrega.ValueMember = "cCvePer";
                cboEntrega.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaPersonal " + ex.Message);
            }
        }

        private DataTable CargaProductos(string cCodPrd)
        {
            DataTable dtProductos = new DataTable();
            try
            {
                SQL = "SELECT cCodPrd, cDesPrd, nPrePrd, nInvAPrd, nUltPrd, nUniPrd FROM Productos WHERE cCodPrd='" + cCodPrd + "'";

                dtProductos = conexVales.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaProductos " + ex.Message);
            }

            return dtProductos;
        }

        private DataTable CargaVales(int nNumVal)
        {
            DataTable dtVales = new DataTable();

            try
            {
                SQL = "SELECT nNumVal as Vale, dFecVal as Fecha, nFolBit as Bitacora, cCveUni as Unidad, nIdUni as IDUnidad, dFecSol, nCveEmp, nTotVal, cObsVal, cSolVal, cAutVal, cEntVal, nEdoVal, nTipVal, dEntVal FROM Vales where nNumval=" + nNumVal;

                dtVales = conexVales.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaVales " + ex.Message);
            }

            return dtVales;
        }

        private DataTable CargaValesDetalle(int nNumVal)
        {
            DataTable dtValesDetalle = new DataTable();

            try
            {
                SQL = "Select nNumVal as No_Vale, nCtdVal as Cantidad, det.cCodPrd as Codigo, nPreVal as Precio, (nCtdVal*nPreVal) as Importe, cDesprd as Descripcion " +
                    "From ValesDetalle det inner join productos prd on det.ccodprd=prd.ccodprd " +
                    "Where nNumVal=" + nNumVal + " " +
                    "Order by det.cCodPrd";

                dtValesDetalle = conexVales.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaValesDetalle " + ex.Message);
            }

            return dtValesDetalle;
        }

        void LimpiarControles()
        {
            try
            {
                txtNumeroVale.Text = string.Empty;
                txtBitacora.Text = string.Empty;
                txtEstado.Text = string.Empty;
                txtEmpresa.Text = string.Empty;
                txtCveEmpresa.Text = string.Empty;
                txtUnidad.Text = string.Empty;
                txtIdUnidad.Text = string.Empty;
                txtObservaciones.Text = string.Empty;
                txtTotal.Text = string.Empty;
                cboSolicita.SelectedIndex = -1;
                cboAutoriza.SelectedIndex = -1;
                cboEntrega.SelectedIndex = -1;
                dgvProductos.DataSource = null;
                txtProducto.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtExistencia.Text = string.Empty;
                txtEnVales.Text = string.Empty;
                txtDisponible.Text = string.Empty;
                txtPrecio.Text = string.Empty;
                chkContingencia.Checked = false;
                dtpSolicitud.Value = DateTime.Now.Date;
                dtpEntrega.Value = DateTime.Now.Date;
                dtpVale.Value = DateTime.Now.Date;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LimpiarControles" + ex.Message);
            }
        }

        void HabilitaControles(int opcion)
        {
            try
            {
                if (opcion == 1) //Deshabilita Todos menos la busqueda
                {
                    txtNumeroVale.Enabled = false;
                    dtpSolicitud.Enabled = false;
                    dtpVale.Enabled = false;
                    dtpEntrega.Enabled = false;
                    txtBitacora.Enabled = false;
                    txtObservaciones.Enabled = false;
                    cboSolicita.Enabled = false;
                    cboAutoriza.Enabled = false;
                    cboEntrega.Enabled = false;
                    txtProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    dgvProductos.Enabled = false;
                    txtBuscar.Enabled = true;
                    chkContingencia.Enabled = false;
                }
                if (opcion == 2) //nuevo - modifica
                {
                    txtNumeroVale.Enabled = true;
                    dtpSolicitud.Enabled = true;
                    dtpVale.Enabled = true;
                    dtpEntrega.Enabled = true;
                    txtBitacora.Enabled = true;
                    txtObservaciones.Enabled = true;
                    cboSolicita.Enabled = true;
                    cboAutoriza.Enabled = true;
                    cboEntrega.Enabled = true;
                    txtProducto.Enabled = true;
                    txtCantidad.Enabled = true;
                    btnAgregar.Enabled = true;
                    btnQuitar.Enabled = true;
                    dgvProductos.Enabled = true;
                    txtBuscar.Enabled = false;
                    chkContingencia.Enabled = true;
                }
                if (opcion == 3) //Termina
                {
                    txtNumeroVale.Enabled = false;
                    dtpSolicitud.Enabled = false;
                    dtpVale.Enabled = false;
                    dtpEntrega.Enabled = true;
                    txtBitacora.Enabled = false;
                    txtObservaciones.Enabled = false;
                    cboSolicita.Enabled = false;
                    cboAutoriza.Enabled = false;
                    cboEntrega.Enabled = true;
                    txtProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    dgvProductos.Enabled = false;
                    txtBuscar.Enabled = false;
                    chkContingencia.Enabled = false;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("HabilitaBotones " + ex.Message);
            }
        }

        private decimal ChecaOtrosVales(string cCodPrd)
        {
            decimal PorEntregar = 0;
            try
            {
                DataTable dtPorEntregar = new DataTable();

                SQL = "select sum(nCtdVal) as cantidad from valesdetalle where nedoval=1 and cCodPrd='" + cCodPrd + "'";

                dtPorEntregar = conexVales.select(SQL);

                if (dtPorEntregar.Rows.Count > 0)
                {
                    var res = dtPorEntregar.Rows[0]["cantidad"].ToString();

                    if (res == null || res == "")
                    { }
                    else
                    {
                        PorEntregar = Convert.ToDecimal(dtPorEntregar.Rows[0]["cantidad"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ChecaOtrosVales " + ex.Message);
            }

            return PorEntregar;
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

        private int ValidaNumeroVale(int nNumVal)
        {
            int ValeBuscado = 0;

            try
            {
                SQL = "select nNumVal from vales where nNumVal = " + nNumVal;

                DataTable dtVale = conexVales.select(SQL);

                if (dtVale.Rows.Count > 0)
                {
                    ValeBuscado = Convert.ToInt32(dtVale.Rows[0]["nNumVal"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ValidaNumeroVale " + ex.Message);
            }

            return ValeBuscado;
        }

        private DataTable UltimoKardex(string cCodPrd)
        {
            DataTable dtKardex = new DataTable();

            try
            {
                SQL = "select Top 1 cCodPrd, nNumKdx, nExiKdx, nSdoKdx From Kardex where cCodPrd = '" + cCodPrd + "' order by nNumKdx desc";

                dtKardex = conexVales.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("UltimoKardex " + ex.Message);
            }

            return dtKardex;
        }

        private void txtBitacora_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    dtBitacora.Clear();
                    if (txtBitacora.Text != "")
                    {
                        int nFolBit = Convert.ToInt32(txtBitacora.Text);

                        SQL = "SELECT nFolBit, nCveEmp, cCveUni, nNumInt,  nEdoBit FROM OrdenMto Where nFolBit = " + nFolBit;

                        dtBitacora = conexVales.select(SQL);

                        if (dtBitacora.Rows.Count > 0)
                        {
                            int nEdoBit = Convert.ToInt32(dtBitacora.Rows[0]["nEdoBit"]);

                            if (nEdoBit == 1)
                            {
                                string cCveUni = dtBitacora.Rows[0]["cCveUni"].ToString()!;
                                txtUnidad.Text = cCveUni;
                                int nIdUni = Convert.ToInt32(dtBitacora.Rows[0]["nNumInt"]);
                                txtIdUnidad.Text = nIdUni.ToString();
                                int nBitaEmp = Convert.ToInt32(dtBitacora.Rows[0]["nCveEmp"]);

                                DataRow[] drEmp = dtEmpresa.Select("nCveEmp=" + Convert.ToInt32(nBitaEmp));
                                txtEmpresa.Text = drEmp[0][1].ToString();
                                txtCveEmpresa.Text = nBitaEmp.ToString();
                                txtObservaciones.Focus();
                            }
                            else
                            {
                                txtUnidad.Text = "0";
                                txtEmpresa.Text = "Sin Empresa";
                                MessageBox.Show("Bitacora no está activa");
                                txtBitacora.Focus();
                                txtBitacora.SelectAll();
                                return;
                            }
                        }
                        else
                        {
                            txtUnidad.Text = "0";
                            txtEmpresa.Text = "Sin Empresa";
                            MessageBox.Show("Bitacora no encontrada folio incorrecto");
                            txtBitacora.Focus();
                            txtBitacora.SelectAll();
                            return;
                        }
                    }
                }
                else
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtBitacora_KeyPress " + ex.Message);
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataTable dtVale = new DataTable();
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
                        int nNumval = Convert.ToInt32(txtBuscar.Text);

                        dtVale.Clear();
                        dtVale = CargaVales(nNumval);

                        if (dtVale.Rows.Count > 0)
                        {
                            txtNumeroVale.Text = nNumval.ToString();
                            DateTime dtFecVal = DateTime.Parse(dtVale.Rows[0]["Fecha"].ToString()!);
                            dtpVale.Value = dtFecVal;
                            DateTime dFecSol = DateTime.Parse(dtVale.Rows[0]["dFecSol"].ToString()!);
                            dtpSolicitud.Value = dFecSol;
                            DateTime dEntVal = DateTime.Parse(dtVale.Rows[0]["dEntVal"].ToString()!);
                            dtpEntrega.Value = dEntVal;
                            int nFolBit = Convert.ToInt32(dtVale.Rows[0]["Bitacora"]);
                            txtBitacora.Text = nFolBit.ToString();
                            int nCveEmp = Convert.ToInt32(dtVale.Rows[0]["nCveEmp"]);
                            DataRow[] drEmp = dtEmpresa.Select("nCveEmp=" + Convert.ToInt32(nCveEmp));
                            txtEmpresa.Text = drEmp[0][1].ToString();
                            txtCveEmpresa.Text = nCveEmp.ToString();
                            string cCveUni = dtVale.Rows[0]["Unidad"].ToString()!;
                            txtUnidad.Text = cCveUni.ToString();
                            int IDUnidad = Convert.ToInt32(dtVale.Rows[0]["IDUnidad"]);
                            txtIdUnidad.Text = IDUnidad.ToString();
                            Decimal nTotVal = Convert.ToDecimal(dtVale.Rows[0]["nTotVal"].ToString());
                            txtTotal.Text = nTotVal.ToString("C");
                            string cObsVal = dtVale.Rows[0]["cObsVal"].ToString()!;
                            txtObservaciones.Text = cObsVal.ToString();
                            string cSolVal = dtVale.Rows[0]["cSolVal"].ToString()!;
                            cboSolicita.SelectedValue = cSolVal;
                            string cAutVal = dtVale.Rows[0]["cAutVal"].ToString()!;
                            cboAutoriza.SelectedValue = cAutVal;
                            string cEntVal = dtVale.Rows[0]["cEntVal"].ToString()!;
                            cboEntrega.SelectedValue = cEntVal;
                            int nEdoVal = Convert.ToInt32(dtVale.Rows[0]["nEdoVal"]);
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
                                txtEstado.Text = "Devolucion";
                            }

                            int nTipVal = Convert.ToInt32(dtVale.Rows[0]["nTipVal"]);

                            if (nTipVal == 1)
                            {
                                chkContingencia.Checked = true;
                            }
                            if (nTipVal == 0)
                            {
                                chkContingencia.Checked = false;
                            }

                            dtProductosGrid.Rows.Clear();
                            dtProductosGrid = CargaValesDetalle(nNumval);
                            dgvProductos.DataSource = null;
                            dgvProductos.DataSource = dtProductosGrid;
                            dgvProductos.Columns["No_Vale"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Cantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Precio"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Importe"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Descripcion"].Visible = false;

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

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                btnAgregar.Enabled = false;
                txtDescripcion.Text = string.Empty;
                txtExistencia.Text = string.Empty;
                txtEnVales.Text = string.Empty;
                txtDisponible.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtPrecio.Text = string.Empty;
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

                            decimal nInvAPrd = Convert.ToDecimal(dtProducto.Rows[0]["nInvAPrd"]);
                            txtExistencia.Text = nInvAPrd.ToString();

                            decimal nOtrosVales = ChecaOtrosVales(cCodPrd);
                            txtEnVales.Text = nOtrosVales.ToString();

                            decimal nDisponible = nInvAPrd - nOtrosVales;
                            txtDisponible.Text = nDisponible.ToString();

                            decimal nPrecio = Convert.ToDecimal(dtProducto.Rows[0]["nPreprd"]);
                            txtPrecio.Text = nPrecio.ToString();

                            txtCantidad.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Producto no encontrado");
                            txtDescripcion.Text = string.Empty;
                            txtExistencia.Text = string.Empty;
                            txtEnVales.Text = string.Empty;
                            txtDisponible.Text = string.Empty;
                            txtCantidad.Text = string.Empty;
                            txtPrecio.Text += string.Empty;
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
                    if (txtProducto.Text != "" && txtExistencia.Text != "" && txtEnVales.Text != "" && txtDisponible.Text != "" && txtPrecio.Text != "" && txtCantidad.Text != "0" && txtCantidad.Text != "")
                    {
                        decimal nCantidad = Convert.ToDecimal(txtCantidad.Text);
                        decimal nDisponible = Convert.ToDecimal(txtDisponible.Text);

                        if (nCantidad > nDisponible)
                        {
                            MessageBox.Show("Excede el inventario disponible");
                            txtCantidad.Focus();
                            txtCantidad.SelectAll();
                            btnAgregar.Enabled = false;
                        }
                        else
                        {
                            btnAgregar.Enabled = true;
                            btnAgregar.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtCantidad_KeyPress " + ex.Message);
            }
        }

        private void txtNumeroVale_KeyPress(object sender, KeyPressEventArgs e)
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
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Space)
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtNumeroVale.Text != "")
                    {
                        if (bNuevo)
                        {
                            int nNumVal = Convert.ToInt32(txtNumeroVale.Text);

                            int nBuscaVale = ValidaNumeroVale(nNumVal);

                            if (nNumVal == nBuscaVale)
                            {
                                MessageBox.Show("Este número de vale ya existe");
                                txtNumeroVale.Focus();
                                txtNumeroVale.SelectAll();
                                return;
                            }
                        }
                        if (bModifica)
                        {
                            int nNumVal = Convert.ToInt32(dtValeModificar.Rows[0]["Vale"]);
                            int nNumValNuevo = Convert.ToInt32(txtNumeroVale.Text);

                            int nExisteVale = 0;
                            if (nNumVal != nNumValNuevo)
                            {
                                nExisteVale = ValidaNumeroVale(nNumValNuevo);
                            }

                            if (nNumValNuevo == nExisteVale)
                            {
                                MessageBox.Show("Este número de vale ya existe");
                                txtNumeroVale.Focus();
                                txtNumeroVale.SelectAll();
                                return;
                            }
                        }

                        dtpSolicitud.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtNumeroVale_KeyPress " + ex.Message);
            }
        }

        private void txtObservaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    txtProducto.Focus();
                }
                else if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtObservaciones_KeyPress " + ex.Message);
            }
        }

        private void dtpSolicitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    dtpVale.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("dtpSolicitud_KeyPress " + ex.Message);
            }
        }

        private void dtpVale_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    txtBitacora.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("dtpVale_KeyPress " + ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bNuevo)
                {
                    if (txtNumeroVale.Text != "" && txtBitacora.Text != "" && dgvProductos.Rows.Count > 0 && cboSolicita.SelectedIndex > -1 && cboAutoriza.SelectedIndex > -1 && cboEntrega.SelectedIndex > -1)
                    {
                        if (MessageBox.Show("Ya reviso que estén correctos los datos de su vale???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            byte nCveEmp = Convert.ToByte(txtCveEmpresa.Text);
                            int nFolBit = Convert.ToInt32(txtBitacora.Text);
                            DateTime dFecVal = dtpVale.Value;
                            DateTime tHorVal = DateTime.Now.ToLocalTime();
                            string cSolVal = cboSolicita.SelectedValue!.ToString()!;
                            string cAutVal = cboAutoriza.SelectedValue!.ToString()!;
                            string cEntVal = cboEntrega.SelectedValue!.ToString()!;

                            Decimal nTotal = 0;
                            foreach (DataRow dr in dtProductosGrid.Rows)
                            {
                                nTotal = nTotal + Convert.ToDecimal(dr["Importe"]);
                            }

                            int nEdoVal = 1;
                            DateTime dEntVal = dtpEntrega.Value;
                            DateTime tEntVal = DateTime.Now.ToLocalTime();
                            string cCveUni = txtUnidad.Text;
                            int nNumVal = Convert.ToInt32(txtNumeroVale.Text);

                            int nExisteVale = ValidaNumeroVale(nNumVal);

                            if (nNumVal == nExisteVale)
                            {
                                MessageBox.Show("Este número de vale ya existe");
                                txtNumeroVale.Focus();
                                txtNumeroVale.SelectAll();
                                return;
                            }

                            byte nModVal = 0;

                            byte nTipVal = 0;
                            if (chkContingencia.Checked == true)
                            {
                                nTipVal = 1;
                            }

                            string cObsVal = txtObservaciones.Text;
                            if (cObsVal == string.Empty)
                            {
                                cObsVal = "Sin observaciones";
                            }

                            int nIdUni = Convert.ToInt32(txtIdUnidad.Text);

                            DateTime dFecSol = dtpSolicitud.Value;

                            //graba en tabla vales
                            SQL = "Insert Into Vales (nCveEmp, nFolBit, dFecVal, tHorVal, cSolVal, cAutVal, cEntVal, nTotVal, nEdoVal, dEntVal, tEntVal, cCveUni, nNumval, nModVal, nTipVal, cObsVal, nIdUni, dFecSol) " +
                                "Values (" + nCveEmp + "," + nFolBit + ",'" + dFecVal.ToString("yyyyMMdd") + "','" + DateTime.Now.ToString("yyyyMMdd") +
                                "','" + cSolVal + "','" + cAutVal + "','" + cEntVal + "'," + nTotal + "," + nEdoVal + ",'" + dEntVal.ToString("yyyyMMdd") +
                                "','" + DateTime.Now.ToString("yyyyMMdd") + "','" + cCveUni + "'," + nNumVal + "," + nModVal + "," + nTipVal + ",'" + cObsVal +
                                "'," + nIdUni + ",'" + dFecSol.ToString("yyyyMMdd") + "')";

                            bool bInsertVale = conexVales.ejecSql(SQL);

                            if (bInsertVale)
                            {
                                foreach (DataRow item in dtProductosGrid.Rows)
                                {
                                    string cCodPrd = item["Codigo"].ToString()!;
                                    decimal nPreVal = Convert.ToDecimal(item["Precio"].ToString());
                                    decimal nCtdVal = Convert.ToDecimal(item["Cantidad"].ToString());
                                    int nNumPed = 0;
                                    string cTipCpa = "CN";
                                    string cNumFac = "0";
                                    string cFecFac = "19000101";

                                    //graba en tabla valesdetalle
                                    SQL = "Insert Into ValesDetalle (cCodPrd, nPreVal, nCtdVal, nFolBit, nEdoVal, nNumPed, cTipCpa, cNumFac, dFecFac, nNumVal) " +
                                        "Values('" + cCodPrd + "'," + nPreVal + "," + nCtdVal + "," + nFolBit + "," + nEdoVal + "," + nNumPed + ",'" + cTipCpa + "','" + cNumFac + "', '" + cFecFac + "'," + nNumVal + ")";

                                    conexVales.ejecSql(SQL);
                                }
                            }


                            //valida registros grabados
                            bool bExisteVale = false;
                            bool bExisteDetalle = false;

                            try
                            {

                                SQL = "SELECT nNumVal as Vale, dFecVal as Fecha, nFolBit as Bitacora, cCveUni as Unidad, nIdUni as IDUnidad, dFecSol, nCveEmp, nTotVal, cObsVal, cSolVal, cAutVal, nEdoVal FROM Vales where nNumval=" + nNumVal;

                                DataTable dtVale = conexVales.select(SQL);

                                if (dtVale.Rows.Count > 0)
                                {
                                    bExisteVale = true;
                                }


                                SQL = "SELECT nNumVal, cCodPrd, nCtdVal, nFolBit, nEdoVal  FROM ValesDetalle where nNumval=" + nNumVal;

                                DataTable dtDetalle = conexVales.select(SQL);
                                int nDetalle = dtDetalle.Rows.Count;

                                if (nDetalle == dtProductosGrid.Rows.Count)
                                {
                                    bExisteDetalle = true;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            if (bExisteVale && bExisteDetalle)
                            {
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
                    int nNumVal = Convert.ToInt32(dtValeModificar.Rows[0]["Vale"]);
                    int nEdoVal = Convert.ToInt32(dtValeModificar.Rows[0]["nEdoVal"]);
                    int nNumValNuevo = Convert.ToInt32(txtNumeroVale.Text);

                    if (nEdoVal == 1)
                    {
                        if (txtNumeroVale.Text != "" && txtBitacora.Text != "" && txtObservaciones.Text != "" && dgvProductos.Rows.Count > 0 && cboSolicita.SelectedIndex > -1 && cboAutoriza.SelectedIndex > -1 && cboEntrega.SelectedIndex > -1)
                        {
                            if (MessageBox.Show("Ya reviso que estén correctos los datos de su vale???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                //primero borra los datos actuales y despues inserta el vale ya corregido
                                SQL = "Delete from valesdetalle where nnumval=" + nNumVal;
                                conexVales.ejecSql(SQL);

                                SQL = "Delete from vales where nnumval=" + nNumVal;
                                conexVales.ejecSql(SQL);

                                byte nCveEmp = Convert.ToByte(txtCveEmpresa.Text);
                                int nFolBit = Convert.ToInt32(txtBitacora.Text);
                                DateTime dFecVal = dtpVale.Value;
                                DateTime tHorVal = DateTime.Now.ToLocalTime();
                                string cSolVal = cboSolicita.SelectedValue!.ToString()!;
                                string cAutVal = cboAutoriza.SelectedValue!.ToString()!;
                                string cEntVal = cboEntrega.SelectedValue!.ToString()!;

                                Decimal nTotal = 0;
                                foreach (DataRow dr in dtProductosGrid.Rows)
                                {
                                    nTotal = nTotal + Convert.ToDecimal(dr["Importe"]);
                                }

                                DateTime dEntVal = dtpEntrega.Value;
                                DateTime tEntVal = DateTime.Now.ToLocalTime();
                                string cCveUni = txtUnidad.Text;
                                byte nModVal = 0;

                                byte nTipVal = 0;
                                if (chkContingencia.Checked == true)
                                {
                                    nTipVal = 1;
                                }

                                string cObsVal = txtObservaciones.Text;
                                int nIdUni = Convert.ToInt32(txtIdUnidad.Text);

                                DateTime dFecSol = dtpSolicitud.Value;

                                //graba en tabla vales
                                SQL = "Insert Into Vales (nCveEmp, nFolBit, dFecVal, tHorVal, cSolVal, cAutVal, cEntVal, nTotVal, nEdoVal, dEntVal, tEntVal, cCveUni, nNumval, nModVal, nTipVal, cObsVal, nIdUni, dFecSol) " +
                                    "Values (" + nCveEmp + "," + nFolBit + ",#" + dFecVal.ToString("MM-dd-yyyy") + "#,#" + DateTime.Now.ToString("MM-dd-yyyy") +
                                    "#,'" + cSolVal + "','" + cAutVal + "','" + cEntVal + "'," + nTotal + "," + nEdoVal + ",#" + dEntVal.ToString("MM-dd-yyyy") +
                                    "#,#" + DateTime.Now.ToString("MM-dd-yyyy") + "#,'" + cCveUni + "'," + nNumValNuevo + "," + nModVal + "," + nTipVal + ",'" + cObsVal +
                                    "'," + nIdUni + ",#" + dFecSol.ToString("MM-dd-yyyy") + "#)";

                                bool bInsertVale = conexVales.ejecSql(SQL);

                                if (bInsertVale)
                                {
                                    foreach (DataRow item in dtProductosGrid.Rows)
                                    {
                                        string cCodPrd = item["Codigo"].ToString()!;
                                        decimal nPreVal = Convert.ToDecimal(item["Precio"].ToString());
                                        decimal nCtdVal = Convert.ToDecimal(item["Cantidad"].ToString());
                                        int nNumPed = 0;
                                        string cTipCpa = "CN";
                                        string cNumFac = "0";
                                        string cFecFac = "01-01-1900";

                                        //grava en tabla valesdetalle
                                        string SQLDetalle = "Insert Into ValesDetalle (cCodPrd, nPreVal, nCtdVal, nFolBit, nEdoVal, nNumPed, cTipCpa, cNumFac, dFecFac, nNumVal) " +
                                            "Values('" + cCodPrd + "'," + nPreVal + "," + nCtdVal + "," + nFolBit + "," + nEdoVal + "," + nNumPed + ",'" + cTipCpa + "','" + cNumFac + "', #" + cFecFac + "#," + nNumValNuevo + ")";

                                        conexVales.ejecSql(SQL);
                                    }
                                }


                                //valida registros grabados
                                bool bExisteVale = false;
                                bool bExisteDetalle = false;

                                try
                                {

                                    string SQLVale = "SELECT nNumVal as Vale, dFecVal as Fecha, nFolBit as Bitacora, cCveUni as Unidad, nIdUni as IDUnidad, dFecSol, nCveEmp, nTotVal, cObsVal, cSolVal, cAutVal, nEdoVal FROM Vales where nNumval=" + nNumValNuevo;

                                    DataTable dtVale = conexVales.select(SQL);

                                    if (dtVale.Rows.Count > 0)
                                    {
                                        bExisteVale = true;
                                    }


                                    string SQLDetalle = "SELECT nNumVal, cCodPrd, nCtdVal, nFolBit, nEdoVal  FROM ValesDetalle where nNumval=" + nNumValNuevo;

                                    DataTable dtDetalle = conexVales.select(SQL);

                                    int nDetalle = dtDetalle.Rows.Count;

                                    if (nDetalle == dtProductosGrid.Rows.Count)
                                    {
                                        bExisteDetalle = true;
                                    }
                                }
                                catch (Exception ex)
                                {
                                }

                                if (bExisteVale && bExisteDetalle)
                                {
                                    MessageBox.Show("Vale modificado correctamente");
                                }
                                else
                                {
                                    MessageBox.Show("Los registros no se grabaron correctamente");
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
                }

                if (bTermina)
                {
                    if (txtNumeroVale.Text != "" && txtBitacora.Text != "" && txtObservaciones.Text != "" && dgvProductos.Rows.Count > 0 && cboSolicita.SelectedIndex > -1 && cboAutoriza.SelectedIndex > -1 && cboEntrega.SelectedIndex > -1)
                    {
                        if (MessageBox.Show("Está seguro de Terminar este vale???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            int nNumVal = Convert.ToInt32(txtNumeroVale.Text);

                            DataTable dtTerminaVale = new DataTable();
                            dtTerminaVale = CargaVales(nNumVal);

                            if (dtTerminaVale.Rows.Count > 0)
                            {
                                byte nEdoVal = Convert.ToByte(dtTerminaVale.Rows[0]["nEdoVal"]);
                                byte nCveEmp = Convert.ToByte(dtTerminaVale.Rows[0]["nCveEmp"]);
                                string cEntVal = cboEntrega.SelectedValue!.ToString()!;
                                DateTime dEntVal = dtpEntrega.Value;
                                string cFecEnt = dEntVal.ToString("MM-dd-yyyy");

                                if (nEdoVal == 1)
                                {
                                    DataTable dtTerminaDetalle = new DataTable();
                                    dtTerminaDetalle = CargaValesDetalle(nNumVal);

                                    int nFilasDetalle = dtTerminaDetalle.Rows.Count;
                                    int nFilasGrid = dgvProductos.Rows.Count;

                                    if (nFilasDetalle == nFilasGrid)
                                    {
                                        foreach (DataRow dr in dtTerminaDetalle.Rows)
                                        {
                                            string cCodPrd = dr["Codigo"].ToString()!;
                                            decimal nCtdVal = Convert.ToDecimal(dr["Cantidad"].ToString());
                                            decimal nPreVal = Convert.ToDecimal(dr["Precio"].ToString());
                                            decimal nImporte = nCtdVal * nPreVal;
                                            byte nTpoKdx = 2;
                                            string cPrvKdx = "0";
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
                                                SaldoSiguiente = UltimoSaldo - nImporte;
                                                ExistenciaSiguiente = UltimaExistencia - nCtdVal;

                                                SQL = "Insert Into Kardex (cCodPrd, cDocKdx, nCtdKdx, dFecKdx, nCveEmp, cPrvKdx, nCtoKdx, nTpoKdx, nSdoKdx, nExiKdx, nNumKdx, nNumPed) " +
                                                    "Values ('" + cCodPrd + "','" + nNumVal.ToString() + "'," + nCtdVal + ",#" + cFecEnt + "#," + nCveEmp + ",'0'," + nPreVal + "," + nTpoKdx + "," + SaldoSiguiente + "," + ExistenciaSiguiente + "," + NumeroSiguiente + ",0)";

                                                conexVales.ejecSql(SQL);

                                                SQL = "update Productos Set nInvAPrd=" + ExistenciaSiguiente + " Where cCodPrd = '" + cCodPrd + "'";
                                                bool bActualizaInventario = conexVales.ejecSql(SQL);

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

                                        SQL = "select cDocKdx, cCodPrd from kardex where cdockdx='" + nNumVal.ToString() + "'";

                                        DataTable dtKardex = conexVales.select(SQL);

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

                                    SQL = "Update ValesDetalle Set nEdoVal = 2 Where nNumVal = " + nNumVal;
                                    bool bTerminaDetalle = conexVales.ejecSql(SQL);

                                    if (!bTerminaDetalle)
                                    {
                                        MessageBox.Show("No se terminó correctamente el detalle del vale");
                                        return;
                                    }

                                    SQL = "Update Vales Set nEdoVal = 2, cEntval = '" + cEntVal + "', dEntVal = #" + cFecEnt + "# Where nNumVal = " + nNumVal + "";
                                    conexVales.ejecSql(SQL);

                                    MessageBox.Show("Vale terminado");

                                    LimpiarControles();
                                    HabilitaBotones(1);
                                    HabilitaControles(1);
                                    bModifica = false;
                                    bNuevo = false;
                                    bTermina = false;
                                }
                                else
                                {
                                    MessageBox.Show("El vale no tiene estado emitido");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnGrabar_Click " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeroVale.Text != "" && txtProducto.Text != "" && txtCantidad.Text != "" && txtDescripcion.Text != "" && txtPrecio.Text != "")
                {
                    int No_Vale = Convert.ToInt32(txtNumeroVale.Text);
                    string Codigo = txtProducto.Text;
                    decimal Cantidad = Convert.ToDecimal(txtCantidad.Text);
                    decimal Precio = Convert.ToDecimal(txtPrecio.Text);
                    decimal Importe = Precio * Cantidad;

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
                        txtExistencia.Text = string.Empty;
                        txtEnVales.Text = string.Empty;
                        txtDisponible.Text = string.Empty;
                        txtPrecio.Text = string.Empty;
                        txtProducto.Focus();

                        return;
                    }

                    DataRow rowProducto = dtProductosGrid.NewRow();
                    rowProducto["No_Vale"] = No_Vale;
                    rowProducto["Codigo"] = Codigo;
                    rowProducto["Cantidad"] = Cantidad;
                    rowProducto["Precio"] = Precio;
                    rowProducto["Importe"] = Importe;

                    dtProductosGrid.Rows.Add(rowProducto);

                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = dtProductosGrid;
                    dgvProductos.Columns["No_Vale"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvProductos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    Decimal nTotal = 0;
                    foreach (DataRow dr in dtProductosGrid.Rows)
                    {
                        nTotal = nTotal + Convert.ToDecimal(dr["Importe"]);
                    }

                    if (dtProductosGrid.Rows.Count > 0)
                    {
                        btnQuitar.Enabled = true;
                    }

                    txtTotal.Text = nTotal.ToString();

                    txtProducto.Text = string.Empty;
                    txtCantidad.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtExistencia.Text = string.Empty;
                    txtEnVales.Text = string.Empty;
                    txtDisponible.Text = string.Empty;
                    txtPrecio.Text = string.Empty;
                    txtProducto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregar_Click " + ex.Message);
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
                    dgvProductos.Columns["No_Vale"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvProductos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    Decimal nTotal = 0;
                    foreach (DataRow dr in dtProductosGrid.Rows)
                    {
                        nTotal = nTotal + Convert.ToDecimal(dr["Importe"]);
                    }

                    if (dtProductosGrid.Rows.Count > 0)
                    {
                        btnQuitar.Enabled = true;
                    }

                    txtTotal.Text = nTotal.ToString();
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
                if (txtNumeroVale.Text != "" && txtBitacora.Text != "" && txtObservaciones.Text != "" && dgvProductos.Rows.Count > 0 && cboSolicita.SelectedIndex > -1 && cboAutoriza.SelectedIndex > -1 && cboEntrega.SelectedIndex > -1)
                {
                    int nNumVal = Convert.ToInt32(txtNumeroVale.Text);

                    DataTable dtCancelaVale = new DataTable();
                    dtCancelaVale = CargaVales(nNumVal);

                    DataTable dtCancelaDetalle = new DataTable();
                    dtCancelaDetalle = CargaValesDetalle(nNumVal);
                    int nDetalle = dtCancelaDetalle.Rows.Count;

                    if (dtCancelaVale.Rows.Count > 0)
                    {
                        Byte nEdoVal = Convert.ToByte(dtCancelaVale.Rows[0]["nEdoVal"]);

                        if (nEdoVal != 1)
                        {
                            MessageBox.Show("El Vale no puede ser cancelado porque no esta activo");
                            return;
                        }
                        if (MessageBox.Show("Está seguro de cancelar este vale???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            SQL = "update vales set nedoval=3 where nnumval= " + nNumVal;

                            bool bCancelaVale = conexVales.ejecSql(SQL);

                            SQL = "update valesdetalle set nedoval=3 where nnumval= " + nNumVal;

                            bool bCancelaDetalle = conexVales.ejecSql(SQL);

                            if (bCancelaVale && bCancelaDetalle)
                            {
                                MessageBox.Show("Vale cancelado correctamente");
                                LimpiarControles();
                                HabilitaBotones(1);
                                HabilitaControles(1);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo cancelar correctamente el vale");
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
                if (txtNumeroVale.Text != "" && txtBitacora.Text != "" && txtObservaciones.Text != "" && dgvProductos.Rows.Count > 0 && cboSolicita.SelectedIndex > -1 && cboAutoriza.SelectedIndex > -1 && cboEntrega.SelectedIndex > -1)
                {
                    bModifica = true;
                    bNuevo = false;
                    bTermina = false;

                    int nNumVal = Convert.ToInt32(txtNumeroVale.Text);

                    dtValeModificar = CargaVales(nNumVal);

                    if (dtValeModificar.Rows.Count > 0)
                    {
                        int nEdoVal = Convert.ToInt32(dtValeModificar.Rows[0]["nEdoVal"]);
                        if (nEdoVal == 1)
                        {
                            {
                                dtDetalleModificar = CargaValesDetalle(nNumVal);
                            }
                            HabilitaControles(2);
                            HabilitaBotones(2);
                        }
                        else
                        {
                            MessageBox.Show("Solo se puede modificar un vale Emitido");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo consultar el vale correctamente o no hay conexión al servidor");
                    }
                }
                else
                {
                    MessageBox.Show("No ha seleccionado el vale o falta en cargar algun dato");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnModificar_Click " + ex.Message);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarControles();
                HabilitaControles(2);
                HabilitaBotones(2);
                txtEstado.Text = "Emitido";
                dtProductosGrid.Clear();
                btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;
                cboEntrega.Enabled = false;
                dtpEntrega.Enabled = false;
                bNuevo = true;
                bModifica = false;
                bTermina = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnNuevo_Click " + ex.Message);
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
                dtValeModificar.Clear();
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

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                bTermina = true;
                bNuevo = false;
                bModifica = false;
                HabilitaBotones(4);
                HabilitaControles(3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnTerminar_Click " + ex.Message);
            }
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtProducto = new DataTable();
                CodigoBuscar = string.Empty;
                frmBuscaProducto modalBusca = new frmBuscaProducto(this);
                modalBusca.ConexBuscaProd = conexVales;
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

                        decimal nInvAPrd = Convert.ToDecimal(dtProducto.Rows[0]["nInvAPrd"]);
                        txtExistencia.Text = nInvAPrd.ToString();

                        decimal nOtrosVales = ChecaOtrosVales(CodigoBuscar);
                        txtEnVales.Text = nOtrosVales.ToString();

                        decimal nDisponible = nInvAPrd - nOtrosVales;
                        txtDisponible.Text = nDisponible.ToString();

                        decimal nPrecio = Convert.ToDecimal(dtProducto.Rows[0]["nPreprd"]);
                        txtPrecio.Text = nPrecio.ToString();

                        txtCantidad.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado");
                        txtDescripcion.Text = string.Empty;
                        txtExistencia.Text = string.Empty;
                        txtEnVales.Text = string.Empty;
                        txtDisponible.Text = string.Empty;
                        txtCantidad.Text = string.Empty;
                        txtPrecio.Text += string.Empty;
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

        private void cboAutoriza_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboAutoriza.Focused)
                {
                    if (cboAutoriza.SelectedIndex > -1)
                    {
                        string cAutoriza = cboAutoriza.SelectedValue!.ToString()!;

                        cboEntrega.SelectedValue = cAutoriza;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("cboAutoriza_SelectedIndexChanged " + ex.Message);
            }
        }
    }
}