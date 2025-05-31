using System.Data;
using System.Drawing.Printing;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmPedidos : Form
    {
        DataTable dtPersonal = new DataTable();
        DataTable dtProductosGrid = new DataTable();
        DataTable dtPedidoModificar = new DataTable();
        DataTable dtDetalleModificar = new DataTable();

        bool bNuevo = false;
        bool bModifica = false;

        private PrintDocument PD = new PrintDocument();
        private PrintPreviewDialog PPD = new PrintPreviewDialog();

        string SQL = string.Empty;
        string CodigoBuscar = string.Empty;

        public csConexionSQL conexPedidos;
        public csConexionSQL ConexPedidos { set { this.conexPedidos = value; } }

        private Color originalColorBtnNuevo;
        private Color originalColorBtnModificar;
        private Color originalColorBtnGrabar;
        private Color originalColorBtnDeshacer;
        private Color originalColorBtnCancelar;
        private Color originalColorBtnImprimir;
        private Color originalColorBtnSalir;

        public frmPedidos()
        {
            try
            {
                InitializeComponent();
                PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmPedidos " + ex.Message);
            }
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            try
            {
                originalColorBtnNuevo = btnNuevo.BackColor;
                originalColorBtnModificar = btnModificar.BackColor;
                originalColorBtnGrabar = btnGrabar.BackColor;
                originalColorBtnDeshacer = btnDeshacer.BackColor;
                originalColorBtnCancelar = btnCancelar.BackColor;
                originalColorBtnImprimir = btnImprimir.BackColor;
                originalColorBtnSalir = btnSalir.BackColor;

                CargaPersonal();
                HabilitaControles(1);
                HabilitaBotones(1);

                dtProductosGrid.Columns.Add("Cantidad", typeof(decimal));
                dtProductosGrid.Columns.Add("Codigo", typeof(string));
                dtProductosGrid.Columns.Add("Pedido", typeof(int));
                dtProductosGrid.Columns.Add("Estado", typeof(string));
                dtProductosGrid.Columns.Add("Orden", typeof(int));
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmPedidos_Load " + ex.Message);
            }
        }

        private void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Font fontTitulo = new Font("Arial", 18, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel);
                StringFormat formCentrado = new StringFormat();
                formCentrado.Alignment = StringAlignment.Center;
                formCentrado.LineAlignment = StringAlignment.Center;
                e.Graphics!.DrawString("Pedido de refacciones", fontTitulo, Brushes.Black, new RectangleF(150, 20, 500, 30), formCentrado);
                e.Graphics.DrawString(txtEstado.Text, fontTitulo, Brushes.Black, new RectangleF(600, 20, 200, 30), formCentrado);

                Pen PenPedido = new Pen(Brushes.Black);
                PenPedido.Width = 1.0F;
                e.Graphics.DrawRectangle(PenPedido, new Rectangle(20, 52, 780, 1));

                Font fontPedido = new Font("Times New Roman", 14, FontStyle.Bold, GraphicsUnit.Pixel);
                StringFormat formPedido = new StringFormat();
                formPedido.Alignment = StringAlignment.Near;
                formPedido.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Pedido : " + txtNumeroPedido.Text, fontPedido, Brushes.Black, new RectangleF(20, 54, 150, 30), formPedido);
                e.Graphics.DrawString("Fecha : " + dtpPedido.Value.ToString("dd/MM/yyyy"), fontPedido, Brushes.Black, new RectangleF(180, 54, 200, 30), formPedido);
                e.Graphics.DrawString("Elaborado por : " + cboSolicita.SelectedValue!.ToString() + " " + cboSolicita.Text, fontPedido, Brushes.Black, new RectangleF(350, 54, 500, 30), formPedido);

                StringFormat formCantidad = new StringFormat();
                formCantidad.Alignment = StringAlignment.Center;
                formCantidad.LineAlignment = StringAlignment.Center;
                Font fontCantidad = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Cantidad", fontCantidad, Brushes.Black, new RectangleF(120, 90, 100, 30), formCantidad);

                StringFormat formCodigo = new StringFormat();
                formCodigo.Alignment = StringAlignment.Center;
                formCodigo.LineAlignment = StringAlignment.Center;
                Font fontCodigo = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Código", fontCodigo, Brushes.Black, new RectangleF(20, 90, 100, 30), formCodigo);

                StringFormat formDescripcion = new StringFormat();
                formDescripcion.Alignment = StringAlignment.Center;
                formDescripcion.LineAlignment = StringAlignment.Center;
                Font fontDescripcion = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Descripción", fontDescripcion, Brushes.Black, new RectangleF(220, 90, 300, 30), formDescripcion);

                StringFormat formEstado = new StringFormat();
                formEstado.Alignment = StringAlignment.Center;
                formEstado.LineAlignment = StringAlignment.Center;
                Font fontEstado = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Estado", fontEstado, Brushes.Black, new RectangleF(520, 90, 150, 30), formEstado);

                StringFormat formOrden = new StringFormat();
                formOrden.Alignment = StringAlignment.Center;
                formOrden.LineAlignment = StringAlignment.Center;
                Font fontOrden = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString("Orden", fontOrden, Brushes.Black, new RectangleF(680, 90, 100, 30), formOrden);

                e.Graphics.DrawRectangle(PenPedido, new Rectangle(20, 118, 780, 1));

                StringFormat formIzquierda = new StringFormat();
                formIzquierda.Alignment = StringAlignment.Near;
                formIzquierda.LineAlignment = StringAlignment.Center;

                StringFormat formDerecha = new StringFormat();
                formDerecha.Alignment = StringAlignment.Far;
                formDerecha.LineAlignment = StringAlignment.Center;

                int Detalle = 120;

                foreach (DataRow fila in dtProductosGrid.Rows)
                {
                    string codigo = fila["Codigo"].ToString()!;
                    e.Graphics.DrawString(codigo, fontCodigo, Brushes.Black, new RectangleF(25, Detalle, 100, 30), formIzquierda);
                    decimal ncantidad = Convert.ToDecimal(fila["Cantidad"]);
                    string cantidad = ncantidad.ToString("F2");
                    e.Graphics.DrawString(cantidad, fontCantidad, Brushes.Black, new RectangleF(120, Detalle, 90, 30), formDerecha);
                    string descripcion = fila["Descripcion"].ToString()!;
                    e.Graphics.DrawString(descripcion, fontDescripcion, Brushes.Black, new RectangleF(225, Detalle, 400, 30), formIzquierda);
                    string estado = fila["Estado"].ToString()!;
                    e.Graphics.DrawString(estado, fontEstado, Brushes.Black, new RectangleF(520, Detalle, 150, 30), formCentrado);
                    string orden = fila["orden"].ToString()!;
                    e.Graphics.DrawString(orden, fontOrden, Brushes.Black, new RectangleF(680, Detalle, 100, 30), formCentrado);
                    Detalle += 15;
                }

                e.Graphics.DrawRectangle(PenPedido, new Rectangle(20, Detalle + 15, 780, 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show("PD_PrintPage " + ex.Message);
            }
        }

        void CargaPersonal()
        {
            try
            {
                SQL = "SELECT per.cCvePer, per.cNomPer, org.nCvePue, per.nEdoPer FROM dbRelacionesLaborales.dbo.tbPersonal AS per " +
                    "INNER JOIN dbRelacionesLaborales.dbo.tbOrgPer AS org ON per.nCveOrg = org.nCveOrg " +
                    "WHERE (per.nEdoPer <> 7) AND (org.nCvePue IN (16, 66, 20)) " +
                    "ORDER BY per.cNomPer";

                dtPersonal = conexPedidos.select(SQL);
                cboSolicita.DataSource = null;
                cboSolicita.DataSource = dtPersonal;
                cboSolicita.DisplayMember = "cNomPer";
                cboSolicita.ValueMember = "cCvePer";
                cboSolicita.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaPersonal " + ex.Message);
            }
        }

        void HabilitaControles(int opcion)
        {
            try
            {
                if (opcion == 1) //Deshabilita Todos menos la busqueda
                {
                    txtNumeroPedido.Enabled = false;
                    dtpPedido.Enabled = false;
                    cboSolicita.Enabled = false;
                    txtProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    dgvProductos.Enabled = false;
                    txtBuscar.Enabled = true;
                }
                if (opcion == 2) //nuevo - modifica
                {
                    txtNumeroPedido.Enabled = true;
                    dtpPedido.Enabled = true;
                    cboSolicita.Enabled = true;
                    txtProducto.Enabled = true;
                    txtCantidad.Enabled = true;
                    btnAgregar.Enabled = true;
                    btnQuitar.Enabled = true;
                    dgvProductos.Enabled = true;
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
                    btnNuevo.BackColor = originalColorBtnNuevo;
                    btnModificar.Enabled = false;
                    btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnGrabar.Enabled = false;
                    btnGrabar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnDeshacer.Enabled = false;
                    btnDeshacer.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnCancelar.Enabled = false;
                    btnCancelar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnImprimir.Enabled = false;
                    btnImprimir.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnSalir.Enabled = true;
                    btnSalir.BackColor = originalColorBtnSalir;
                }
                if (opcion == 2) //Nuevo-modificar
                {
                    btnNuevo.Enabled = false;
                    btnNuevo.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnModificar.Enabled = false;
                    btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnGrabar.Enabled = true;
                    btnGrabar.BackColor = originalColorBtnGrabar;
                    btnDeshacer.Enabled = true;
                    btnDeshacer.BackColor = originalColorBtnDeshacer;
                    btnCancelar.Enabled = false;
                    btnCancelar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnImprimir.Enabled = false;
                    btnImprimir.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnSalir.Enabled = false;
                    btnSalir.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
                if (opcion == 3)  //Buscar
                {
                    btnNuevo.Enabled = true;
                    btnNuevo.BackColor = originalColorBtnNuevo;
                    btnModificar.Enabled = true;
                    btnModificar.BackColor = originalColorBtnModificar;
                    btnCancelar.Enabled = true;
                    btnCancelar.BackColor = originalColorBtnCancelar;
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
                txtNumeroPedido.Text = string.Empty;
                txtEstado.Text = string.Empty;
                cboSolicita.SelectedIndex = -1;
                dgvProductos.DataSource = null;
                txtProducto.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtExistencia.Text = string.Empty;
                txtEnVales.Text = string.Empty;
                txtDisponible.Text = string.Empty;
                dtpPedido.Value = DateTime.Now.Date;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LimpiarControles " + ex.Message);
            }
        }

        private DataTable CargaPedidos(int nNumPed)
        {
            DataTable dtPedidos = new DataTable();

            try
            {
                SQL = "SELECT nNumPed as Pedido, dFecPed as Fecha, cSolPed as Solicita, nEdoPed as Estado FROM Pedido where nNumPed=" + nNumPed;

                dtPedidos = conexPedidos.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaPedidos " + ex.Message);
            }

            return dtPedidos;
        }

        private DataTable CargaPedidosDetalle(int nNumPed)
        {
            DataTable dtPedidosDetalle = new DataTable();

            try
            {
                SQL = "Select nNumPed as Pedido, nCtdPed as Cantidad, det.cCodPrd as Codigo, cDesprd as Descripcion, nEdoPed as nEdoPed, " +
                    "iif(nEdoPed =1, 'Emitido', iif(nEdoPed = 2, 'Entregado', iif(nEdoPed = 3, 'Cancelado', iif(nEdoPed = 4, 'En Proceso','otros')))) as Estado, " +
                    "nNumOrd as Orden " +
                    "From PedidoDetalle det inner join productos prd on det.cCodPrd = prd.cCodPrd  " +
                    "Where nNumPed=" + nNumPed + " " +
                    "Order by det.cCodPrd";

                dtPedidosDetalle = conexPedidos.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaPedidosDetalle " + ex.Message);
            }

            return dtPedidosDetalle;
        }

        private int NuevoNumeroPedido()
        {
            int FolioSiguiente = 1;

            try
            {
                DataTable dtultimoNumero = new DataTable();

                SQL = "Select Top (1) nNumPed From tbPedido Order by nNumPed desc";

                dtultimoNumero = conexPedidos.select(SQL);

                if (dtultimoNumero.Rows.Count > 0)
                {
                    int UltimoFolio = Convert.ToInt32(dtultimoNumero.Rows[0]["nNumPed"]);
                    FolioSiguiente = UltimoFolio + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NuevoNumeroPedido " + ex.Message);
            }

            return FolioSiguiente;
        }

        private DataTable CargaProductos(string cCodPrd)
        {
            DataTable dtProductos = new DataTable();
            try
            {
                SQL = "SELECT cCodPrd, cDesPrd, nPrePrd, nInvAPrd, nUltPrd, nUniPrd FROM tbProducto WHERE cCodPrd='" + cCodPrd + "'";

                dtProductos = conexPedidos.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaProductos " + ex.Message);
            }

            return dtProductos;
        }

        private decimal ChecaOtrosPedidos(string cCodPrd)
        {
            decimal EnOtrosPedidos = 0;
            try
            {
                DataTable dtOtrosPedidos = new DataTable();

                SQL = "select sum(nCtdPed) as cantidad from tbPedidoDetalle where nedoPed=1 and cCodPrd='" + cCodPrd + "'";

                dtOtrosPedidos = conexPedidos.select(SQL);

                if (dtOtrosPedidos.Rows.Count > 0)
                {
                    var res = dtOtrosPedidos.Rows[0]["cantidad"].ToString();

                    if (res == null || res == "")
                    { }
                    else
                    {
                        EnOtrosPedidos = Convert.ToDecimal(dtOtrosPedidos.Rows[0]["cantidad"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ChecaOtrosPedidos " + ex.Message);
            }

            return EnOtrosPedidos;
        }

        private int ValidaNumeroPedido(int nNumPed)
        {
            int PedidoBuscado = 0;

            try
            {
                DataTable dtPedido = new DataTable();

                SQL = "select nNumPed from Pedido where nNumPed = " + nNumPed;

                dtPedido = conexPedidos.select(SQL);

                if (dtPedido.Rows.Count > 0)
                {
                    PedidoBuscado = Convert.ToInt32(dtPedido.Rows[0]["nNumPed"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ValidaNumeroPedido " + ex.Message);
            }

            return PedidoBuscado;
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
                bNuevo = true;
                bModifica = false;

                int Folio = NuevoNumeroPedido();
                txtNumeroPedido.Text = Folio.ToString();
                txtProducto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnNuevo_Click " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeroPedido.Text != "" && dgvProductos.Rows.Count > 0 && cboSolicita.SelectedIndex > -1)
                {
                    bModifica = true;
                    bNuevo = false;

                    int nNumPed = Convert.ToInt32(txtNumeroPedido.Text);

                    dtPedidoModificar = CargaPedidos(nNumPed);

                    if (dtPedidoModificar.Rows.Count > 0)
                    {
                        byte nEdoPed = Convert.ToByte(dtPedidoModificar.Rows[0]["Estado"]);
                        if (nEdoPed == 1)
                        {
                            dtDetalleModificar = CargaPedidosDetalle(nNumPed);
                            HabilitaControles(2);
                            HabilitaBotones(2);
                        }
                        else
                        {
                            MessageBox.Show("Solo se puede modificar un pedido Emitido");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo consultar el pedido correctamente o no hay conexión al servidor");
                    }
                }
                else
                {
                    MessageBox.Show("No ha seleccionado el pedido o falta en cargar algun dato");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnModificar_Click " + ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bNuevo)
                {
                    if (txtNumeroPedido.Text != "" && dgvProductos.Rows.Count > 0 && cboSolicita.SelectedIndex > -1)
                    {
                        if (MessageBox.Show("Ya reviso que estén correctos los datos de su pedido???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            int nNumPed = Convert.ToInt32(txtNumeroPedido.Text);
                            DateTime dFecPed = dtpPedido.Value;
                            DateTime tHorPed = DateTime.Now.ToLocalTime();
                            int nFolBit = 0;
                            string cSolPed = cboSolicita.SelectedValue!.ToString()!;
                            byte nEdoPed = 1;
                            byte nCveEmp = 2;
                            byte npriOri = 3;

                            int nExistePedido = ValidaNumeroPedido(nNumPed);

                            if (nNumPed == nExistePedido)
                            {
                                MessageBox.Show("Este número de pedido ya existe");
                                return;
                            }

                            //graba en tabla vales
                            SQL = "Insert Into Pedido (nNumPed, dFecPed, tHorPed, nFolBit, cSolPed, nEdoPed, nCveEmp, nPriOri) " +
                                "Values (" + nNumPed + ",'" + dFecPed.ToString("yyyyMMdd") + "','" + DateTime.Now.ToString("yyyyMMdd") +
                                "'," + nFolBit + ",'" + cSolPed + "'," + nEdoPed + "," + nCveEmp + "," + npriOri + ")";

                            bool bInsertPedido = conexPedidos.ejecSql(SQL);

                            if (bInsertPedido)
                            {
                                foreach (DataRow item in dtProductosGrid.Rows)
                                {
                                    string cCodPrd = item["Codigo"].ToString()!;
                                    decimal nCtdPed = Convert.ToDecimal(item["Cantidad"].ToString());
                                    int nNumVal = 0;
                                    int nNumOrd = 0;
                                    string cTipCpa = "CN";

                                    //graba en tabla valesdetalle
                                    SQL = "Insert Into PedidoDetalle (nNumPed, nFolBit, cCodPrd, nCtdPed, nEdoPed, nNumVal, nNumOrd, cTipCpa, dFecPed) " +
                                        "Values(" + nNumPed + "," + nFolBit + ",'" + cCodPrd + "'," + nCtdPed + "," + nEdoPed + "," + nNumVal + "," + nNumOrd + ",'" + cTipCpa + "','" + dFecPed.ToString("yyyyMMdd") + "')";

                                    conexPedidos.ejecSql(SQL);
                                }
                            }

                            //valida registros grabados
                            bool bExistePedido = false;
                            bool bExisteDetalle = false;

                            try
                            {
                                SQL = "SELECT nNumPed as Pedido, dFecPed as Fecha, cSolPed, nEdoPed FROM Pedido where nNumPed = " + nNumPed; ;

                                DataTable dtPedido = conexPedidos.select(SQL);

                                if (dtPedido.Rows.Count > 0)
                                {
                                    bExistePedido = true;
                                }

                                SQL = "Select nNumPed, nCtdPed, cCodPrd, nEdoPed, nNumOrd From PedidoDetalle Where nNumPed=" + nNumPed;
                                DataTable dtDetalle = conexPedidos.select(SQL);

                                int nDetalle = dtDetalle.Rows.Count;

                                if (nDetalle == dtProductosGrid.Rows.Count)
                                {
                                    bExisteDetalle = true;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            if (bExistePedido && bExisteDetalle)
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
                    int nNumPed = Convert.ToInt32(dtPedidoModificar.Rows[0]["Pedido"]);
                    byte nEdoPed = Convert.ToByte(dtPedidoModificar.Rows[0]["Estado"]);

                    if (nEdoPed == 1)
                    {
                        if (txtNumeroPedido.Text != "" && dgvProductos.Rows.Count > 0 && cboSolicita.SelectedIndex > -1)
                        {
                            if (MessageBox.Show("Ya reviso que estén correctos los datos de su pedido???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                //primero borra los datos actuales y despues inserta el vale ya corregido
                                SQL = "Delete from PedidoDetalle where nNumPed=" + nNumPed;
                                bool bEliminaDetalle = conexPedidos.ejecSql(SQL);

                                SQL = "Delete from Pedido where nNumPed=" + nNumPed;
                                bool bEliminaPedido = conexPedidos.ejecSql(SQL);

                                if (!bEliminaDetalle || !bEliminaPedido)
                                {
                                    MessageBox.Show("No se puede realizar la modificación correctamente");
                                    return;
                                }

                                DateTime dFecPed = dtpPedido.Value;
                                DateTime tHorPed = DateTime.Now.ToLocalTime();
                                int nFolBit = 0;
                                string cSolPed = cboSolicita.SelectedValue!.ToString()!;
                                byte nCveEmp = 2;
                                byte npriOri = 3;

                                //graba en tabla vales
                                SQL = "Insert Into Pedido (nNumPed, dFecPed, tHorPed, nFolBit, cSolPed, nEdoPed, nCveEmp, nPriOri) " +
                                    "Values (" + nNumPed + ",'" + dFecPed.ToString("yyyyMMdd") + "','" + DateTime.Now.ToString("yyyyMMdd") +
                                    "'," + nFolBit + ",'" + cSolPed + "'," + nEdoPed + "," + nCveEmp + "," + npriOri + ")";

                                bool bInsertPedido = conexPedidos.ejecSql(SQL);

                                if (bInsertPedido)
                                {
                                    foreach (DataRow item in dtProductosGrid.Rows)
                                    {
                                        string cCodPrd = item["Codigo"].ToString()!;
                                        decimal nCtdPed = Convert.ToDecimal(item["Cantidad"].ToString());
                                        int nNumVal = 0;
                                        int nNumOrd = 0;
                                        string cTipCpa = "CN";

                                        //graba en tabla valesdetalle
                                        SQL = "Insert Into PedidoDetalle (nNumPed, nFolBit, cCodPrd, nCtdPed, nEdoPed, nNumVal, nNumOrd, cTipCpa, dFecPed) " +
                                            "Values(" + nNumPed + "," + nFolBit + ",'" + cCodPrd + "'," + nCtdPed + "," + nEdoPed + "," + nNumVal + "," + nNumOrd + ",'" + cTipCpa + "','" + dFecPed.ToString("yyyyMMdd") + "')";

                                        conexPedidos.ejecSql(SQL);
                                    }
                                }

                                //valida registros grabados
                                bool bExistePedido = false;
                                bool bExisteDetalle = false;

                                try
                                {
                                    string SQLPedido = "SELECT nNumPed as Pedido, dFecPed as Fecha, cSolPed, nEdoPed FROM Pedido where nNumPed = " + nNumPed; ;

                                    DataTable dtPedido = conexPedidos.select(SQL);

                                    if (dtPedido.Rows.Count > 0)
                                    {
                                        bExistePedido = true;
                                    }

                                    string SQLDetalle = "Select nNumPed, nCtdPed, cCodPrd, nEdoPed, nNumOrd From PedidoDetalle Where nNumPed=" + nNumPed;

                                    DataTable dtDetalle = conexPedidos.select(SQL);

                                    int nDetalle = dtDetalle.Rows.Count;

                                    if (nDetalle == dtProductosGrid.Rows.Count)
                                    {
                                        bExisteDetalle = true;
                                    }
                                }
                                catch (Exception ex)
                                {
                                }

                                if (bExistePedido && bExisteDetalle)
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
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta capturar algun valor");
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

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarControles();
                HabilitaControles(1);
                HabilitaBotones(1);
                dtProductosGrid.Clear();
                dtPedidoModificar.Clear();
                dtDetalleModificar.Clear();
                bNuevo = false;
                bModifica = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDeshacer_Click " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeroPedido.Text != "" && dgvProductos.Rows.Count > 0 && cboSolicita.SelectedIndex > -1)
                {
                    int nNumPed = Convert.ToInt32(txtNumeroPedido.Text);

                    DataTable dtCancelaPedido = new DataTable();
                    dtCancelaPedido = CargaPedidos(nNumPed);

                    DataTable dtCancelaDetalle = new DataTable();
                    dtCancelaDetalle = CargaPedidosDetalle(nNumPed);
                    int nDetalle = dtCancelaDetalle.Rows.Count;

                    if (dtCancelaPedido.Rows.Count > 0)
                    {
                        Byte nEdoVal = Convert.ToByte(dtCancelaPedido.Rows[0]["Estado"]);

                        if (nEdoVal != 1)
                        {
                            MessageBox.Show("El Pedido no puede ser cancelado porque no esta activo");
                            return;
                        }
                        if (MessageBox.Show("Está seguro de cancelar este pedido???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            SQL = "update pedido set nedoped=3 where nnumped= " + nNumPed;

                            bool bCancelaPedido = conexPedidos.ejecSql(SQL);

                            SQL = "update pedidodetalle set nedoped=3 where nnumped= " + nNumPed;

                            bool bCancelaDetalle = conexPedidos.ejecSql(SQL);

                            if (bCancelaPedido && bCancelaDetalle)
                            {
                                MessageBox.Show("Pedido cancelado correctamente");
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

        private void btnProducto_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtProducto = new DataTable();
                CodigoBuscar = string.Empty;
                frmBuscaProducto modalBusca = new frmBuscaProducto(this);
                modalBusca.conexBuscaProd = conexPedidos;
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

                        decimal nOtrosVales = ChecaOtrosPedidos(CodigoBuscar);
                        txtEnVales.Text = nOtrosVales.ToString();

                        decimal nDisponible = nInvAPrd - nOtrosVales;
                        txtDisponible.Text = nDisponible.ToString();

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeroPedido.Text != "" && txtProducto.Text != "" && txtCantidad.Text != "" && txtDescripcion.Text != "")
                {
                    int No_Vale = Convert.ToInt32(txtNumeroPedido.Text);
                    string Codigo = txtProducto.Text;
                    decimal Cantidad = Convert.ToDecimal(txtCantidad.Text);

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
                        txtProducto.Focus();

                        return;
                    }

                    DataRow rowProducto = dtProductosGrid.NewRow();
                    rowProducto["Pedido"] = No_Vale;
                    rowProducto["Codigo"] = Codigo;
                    rowProducto["Cantidad"] = Cantidad;
                    rowProducto["Estado"] = 1;
                    rowProducto["Orden"] = 0;

                    dtProductosGrid.Rows.Add(rowProducto);

                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = dtProductosGrid;
                    dgvProductos.Columns["Pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Orden"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (dtProductosGrid.Rows.Count > 0)
                    {
                        btnQuitar.Enabled = true;
                    }

                    txtProducto.Text = string.Empty;
                    txtCantidad.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtExistencia.Text = string.Empty;
                    txtEnVales.Text = string.Empty;
                    txtDisponible.Text = string.Empty;
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
                    dgvProductos.Columns["Pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Orden"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (dtProductosGrid.Rows.Count > 0)
                    {
                        btnQuitar.Enabled = true;
                    }
                    else
                    {
                        btnQuitar.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnQuitar_Click " + ex.Message);
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

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataTable dtPedido = new DataTable();
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
                        int nNumPed = Convert.ToInt32(txtBuscar.Text);

                        dtPedido.Clear();
                        dtPedido = CargaPedidos(nNumPed);

                        if (dtPedido.Rows.Count > 0)
                        {
                            txtNumeroPedido.Text = nNumPed.ToString();
                            DateTime dtFecPed = DateTime.Parse(dtPedido.Rows[0]["Fecha"].ToString()!);
                            dtpPedido.Value = dtFecPed;
                            string cSolPed = dtPedido.Rows[0]["Solicita"].ToString()!;
                            cboSolicita.SelectedValue = cSolPed;
                            byte nEdoPed = Convert.ToByte(dtPedido.Rows[0]["Estado"]);
                            if (nEdoPed == 1)
                            {
                                txtEstado.Text = "Emitido";
                            }
                            if (nEdoPed == 2)
                            {
                                txtEstado.Text = "Entregado";
                            }
                            if (nEdoPed == 3)
                            {
                                txtEstado.Text = "Cancelado";
                            }
                            if (nEdoPed == 4)
                            {
                                txtEstado.Text = "En Proceso";
                            }

                            dtProductosGrid.Rows.Clear();
                            dtProductosGrid = CargaPedidosDetalle(nNumPed);
                            dgvProductos.DataSource = null;
                            dgvProductos.DataSource = dtProductosGrid;
                            dgvProductos.Columns["Cantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Pedido"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Estado"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Orden"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["nEdoPed"].Visible = false;

                            HabilitaBotones(3);

                            txtBuscar.Text = string.Empty;
                            dgvProductos.Enabled = true;

                            if (nEdoPed == 1)
                            {
                                btnModificar.Enabled = true;
                                btnModificar.BackColor = originalColorBtnModificar;
                                btnCancelar.Enabled = true;
                                btnCancelar.BackColor = originalColorBtnCancelar;
                            }
                            else if (nEdoPed > 1)
                            {
                                btnModificar.Enabled = false;
                                btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                                btnCancelar.Enabled = false;
                                btnCancelar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                            }
                        }
                        else
                        {
                            LimpiarControles();
                            MessageBox.Show("Folio de pedido incorrecto");
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

                            decimal nOtrosVales = ChecaOtrosPedidos(cCodPrd);
                            txtEnVales.Text = nOtrosVales.ToString();

                            decimal nDisponible = nInvAPrd - nOtrosVales;
                            txtDisponible.Text = nDisponible.ToString();

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
                    if (txtProducto.Text != "" && txtExistencia.Text != "" && txtEnVales.Text != "" && txtDisponible.Text != "" && txtCantidad.Text != "0" && txtCantidad.Text != "")
                    {
                        btnAgregar.Enabled = true;
                        btnAgregar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtCantidad_KeyPress " + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
