using Syncfusion.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing.Drawing2D;

using System.Runtime.InteropServices;


namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmProveedores : MetroForm
    {
        string strTesoreria = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\srv2kas\\Base Datos Administra_R\\Tesoreria.mdb;Jet OLEDB:Database Password=a9TnX13HHOo;";
        string SQL = string.Empty;
        private int nFilaGrid = 0;
        bool bNuevo = false;
        bool bModifica = false;
        private string filtroLinea = "";
        private Color originalColorBtnNuevo;
        private Color originalColorBtnModificar;
        private Color originalColorBtnGrabar;
        private Color originalColorBtnDeshacer;
        private Color originalColorBtnSalir;

        public csConexionSQL conexProveedor;
        public csConexionSQL ConexProveedor { set { this.conexProveedor = value; } }
        public bool FiltrarLineasUrea { get; set; } = false;
        DataTable dtLineas = new DataTable();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        int m = 0, mx, my;

        public frmProveedores()
        {
            InitializeComponent();
            ConfigureModernUI();
        }

        private void ConfigureModernUI()
        {
            // Guardar colores originales
            originalColorBtnNuevo = btnNuevo.BackColor;
            originalColorBtnGrabar = btnGrabar.BackColor;
            originalColorBtnDeshacer = btnDeshacer.BackColor;
            originalColorBtnSalir = btnSalir.BackColor;

            // Configurar DataGridView
            dgvProveedores.BorderStyle = BorderStyle.None;
            dgvProveedores.BackgroundColor = Color.White;
            dgvProveedores.EnableHeadersVisualStyles = false;

            // Estilo para encabezados de columnas
            dgvProveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvProveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Estilo para filas
            dgvProveedores.RowsDefaultCellStyle.BackColor = Color.White;
            dgvProveedores.RowsDefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // Configurar controles de entrada
            ConfigureInputControls();
        }



        private void ConfigureInputControls()
        {
            // Configurar estilo de los TextBox
            var textBoxes = new[] { txtProveedor, txtClave, txtAbreviatura, txtContacto, txtDias, txtLimite };
            foreach (var txt in textBoxes)
            {
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 10);
            }

            // Configurar ComboBox
            cboLinea.Font = new Font("Segoe UI", 10);
            cboLinea.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                originalColorBtnNuevo = btnNuevo.BackColor;
                originalColorBtnGrabar = btnGrabar.BackColor;
                originalColorBtnDeshacer = btnDeshacer.BackColor;
                originalColorBtnSalir = btnSalir.BackColor;

                CargaLineas();
                HabilitaControles(1);
                HabilitaBotones(1);

                // Cargar proveedores al inicio, aplicando el filtro si existe
                CargaProveedores(filtroLinea);
                filtroLinea = ""; // Limpiar el filtro después de la carga inicial

                //Movimiento de ventana de panel de encabezado
                panelTop.MouseDown += panelTop_MouseDown;
                panelTop.MouseMove += panelTop_MouseMove;
                panelTop.MouseUp += panelTop_MouseUp;

                lblCatalogoProv.MouseDown += panelTop_MouseDown;
                lblCatalogoProv.MouseMove += panelTop_MouseMove;
                lblCatalogoProv.MouseUp += panelTop_MouseUp;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmParametros_Load " + ex.Message);
            }
        }
        void HabilitaControles(int opcion)
        {
            try
            {
                if (opcion == 1)
                {
                    dgvProveedores.Enabled = true;
                    txtProveedor.Text = string.Empty;
                    txtProveedor.Enabled = false;
                    txtClave.Text = string.Empty;
                    txtClave.Enabled = false;
                    txtAbreviatura.Text = string.Empty;
                    txtAbreviatura.Enabled = false;
                    cboLinea.SelectedIndex = -1;
                    cboLinea.Enabled = false;
                    txtContacto.Text = string.Empty;
                    txtContacto.Enabled = false;
                    txtDias.Text = string.Empty;
                    txtDias.Enabled = false;
                    txtLimite.Enabled = false;
                    txtLimite.Text = string.Empty;
                }
                if (opcion == 2) //Nuevo
                {
                    dgvProveedores.Enabled = false;
                    txtProveedor.Text = string.Empty;
                    txtProveedor.Enabled = true;
                    txtClave.Text = string.Empty;
                    txtClave.Enabled = true;
                    txtAbreviatura.Text = string.Empty;
                    txtAbreviatura.Enabled = true;
                    cboLinea.SelectedIndex = -1;
                    cboLinea.Enabled = true;
                    txtContacto.Text = string.Empty;
                    txtContacto.Enabled = true;
                    txtDias.Text = string.Empty;
                    txtDias.Enabled = true;
                    txtLimite.Text = string.Empty;
                    txtLimite.Enabled = true;
                }
                if (opcion == 3) //Modificar
                {
                    dgvProveedores.Enabled = true;
                    txtProveedor.Enabled = true;
                    txtClave.Enabled = false;
                    txtAbreviatura.Enabled = true;
                    cboLinea.Enabled = true;
                    txtContacto.Enabled = true;
                    txtDias.Enabled = true;
                    txtLimite.Enabled = true;
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
                    btnGrabar.Enabled = false;
                    btnGrabar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnDeshacer.Enabled = false;
                    btnDeshacer.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnSalir.Enabled = true;
                    btnSalir.BackColor = originalColorBtnSalir;
                }
                if (opcion == 2) //Nuevo 
                {
                    btnNuevo.Enabled = false;
                    btnNuevo.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnGrabar.Enabled = true;
                    btnGrabar.BackColor = originalColorBtnGrabar;
                    btnDeshacer.Enabled = true;
                    btnDeshacer.BackColor = originalColorBtnDeshacer;
                    btnSalir.Enabled = false;
                    btnSalir.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
                if (opcion == 3) //Modificar 
                {
                    btnNuevo.Enabled = true;
                    btnNuevo.BackColor = originalColorBtnNuevo;
                    btnGrabar.Enabled = true;
                    btnGrabar.BackColor = originalColorBtnGrabar;
                    btnDeshacer.Enabled = false;
                    btnDeshacer.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnSalir.Enabled = true;
                    btnSalir.BackColor = originalColorBtnSalir;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HabilitaBotones " + ex.Message);
            }
        }

        void CargaLineas()
        {
            try
            {
                SQL = "SELECT nCveLin, cDesLin from dbAlmacen.dbo.tbLinea ";

                if (FiltrarLineasUrea)
                {
                    SQL += "WHERE nCveLin = 21 ";
                }

                SQL += "order by cDesLin asc";

                dtLineas = conexProveedor.select(SQL);
                cboLinea.DataSource = null;
                cboLinea.DataSource = dtLineas;
                cboLinea.DisplayMember = "cDesLin";
                cboLinea.ValueMember = "nCveLin";
                cboLinea.SelectedIndex = -1;

                // Opcionalmente, podrías establecer la línea de Urea como seleccionada por defecto
                if (FiltrarLineasUrea && dtLineas.Rows.Count > 0)
                {
                    cboLinea.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaLineas " + ex.Message);
            }
        }
        public void FiltrarPorLinea(int linea)
        {
            filtroLinea = linea.ToString();
            // Si el formulario ya está visible, recarga los datos con el filtro
            if (this.Visible)
            {
                CargaProveedores(filtroLinea);
                filtroLinea = ""; // Limpiar el filtro después de recargar
            }
        }
        void CargaProveedores()
        {
            CargaProveedores(null); // Llama a la sobrecarga sin filtro
        }

        void CargaProveedores(string lineaFiltro)
        {
            try
            {
                SQL = "SELECT p.cCvePrv as Clave, p.cNomPrv as Nombre, p.nDiaPrv as Dias, p.nLimPrv as Limite_Credito, p.cConPrv as Contacto, p.cAbrePrv as Abreviatura, p.nLinPrv, l.cDesLin as Linea " +
                      "FROM dbProveedores.dbo.tbProveedor p LEFT JOIN dbAlmacen.dbo.tbLinea l ON p.nLinPrv = l.nCveLin ";

                if (!string.IsNullOrEmpty(lineaFiltro))
                {
                    SQL += $"WHERE p.nLinPrv = '{lineaFiltro}' ";
                }

                SQL += "ORDER BY cNomPrv ASC;";

                DataTable dtProv = conexProveedor.select(SQL);

                dgvProveedores.DataSource = null;

                if (dtProv.Rows.Count > 0)
                {
                    dgvProveedores.DataSource = dtProv;
                    // Ocultar columnas específicas
                    dgvProveedores.Columns["nLinPrv"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaProveedores " + ex.Message);
            }
        }

        void UbicarFoco_dgvProveedor(string claveProveedor)
        {
            try
            {
                // Verificar si el DataTable tiene registros
                if (dgvProveedores.DataSource != null)
                {
                    // Buscar la fila con la clave proporcionada
                    var fila = dgvProveedores.Rows.Cast<DataGridViewRow>()
                        .FirstOrDefault(r => r.Cells["Clave"].Value.ToString() == claveProveedor);

                    if (fila != null)
                    {
                        // Seleccionar la fila y establecer el foco en la primera celda de esa fila
                        fila.Selected = true;
                        dgvProveedores.CurrentCell = fila.Cells[0]; // Establecer foco en la primera celda

                        nFilaGrid = dgvProveedores.CurrentCell.RowIndex;

                        txtClave.Text = dgvProveedores.Rows[nFilaGrid].Cells["Clave"].Value.ToString();
                        txtProveedor.Text = dgvProveedores.Rows[nFilaGrid].Cells["Nombre"].Value.ToString();
                        txtContacto.Text = dgvProveedores.Rows[nFilaGrid].Cells["Contacto"].Value.ToString();
                        txtAbreviatura.Text = dgvProveedores.Rows[nFilaGrid].Cells["Abreviatura"].Value.ToString();
                        cboLinea.SelectedValue = dgvProveedores.Rows[nFilaGrid].Cells["nLinPrv"].Value;
                        txtDias.Text = dgvProveedores.Rows[nFilaGrid].Cells["Dias"].Value.ToString();
                        txtLimite.Text = dgvProveedores.Rows[nFilaGrid].Cells["Limite_Credito"].Value.ToString();

                        HabilitaControles(3);
                        HabilitaBotones(3);

                        btnGrabar.Text = "Modificar";// Cambiar el texto 
                        btnGrabar.Image = Properties.Resources.update24; // Aquí "miLogo" es el nombre de la imagen

                        bNuevo = false;
                        bModifica = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ubicar el foco: " + ex.Message);
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
                HabilitaControles(2);
                HabilitaBotones(2);
                bNuevo = true;
                bModifica = false;
                txtProveedor.Focus();
                btnGrabar.Text = "Grabar";
                btnGrabar.Image = Properties.Resources.save24; // Aquí "miLogo" es el nombre de la imagen
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnNuevo_Click " + ex.Message);
            }
        }

        private void LlenaComboProveedor()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(strTesoreria))
                {
                    connection.Open();

                    string qryProv = "SELECT cCueCon as Clave, cDesCon as Nombre FROM CONC2 Where cPadCon= '2102000000' ORDER BY cDesCon";

                    OleDbCommand commandProv = new OleDbCommand(qryProv, connection);

                    OleDbDataReader readerProv = commandProv.ExecuteReader();

                    DataTable dtProv = new DataTable();
                    dtProv.Load(readerProv);

                    connection.Close();

                    /*cboProveedor.DataSource = null;
                    cboProveedor.DataSource = dtProv;
                    cboProveedor.DisplayMember = "Nombre";
                    cboProveedor.ValueMember = "Clave";
                    cboProveedor.SelectedIndex = -1;*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LlenaComboProveedor " + ex.Message);
            }
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            try
            {

                btnGrabar.Text = "Grabar"; // Cambiar el texto 
                btnGrabar.Image = Properties.Resources.save24; // Aquí "miLogo" es el nombre de la imagen
                HabilitaControles(1);
                HabilitaBotones(1);

                bNuevo = false;
                bModifica = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDeshacer_Click " + ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProveedor.Text != string.Empty && txtClave.Text != string.Empty && txtContacto.Text != string.Empty && txtDias.Text != "" && txtLimite.Text != "")
                {
                    if (bNuevo)
                    {
                        bool Existe = ExisteProveedor(txtClave.Text);

                        if (Existe)
                        {
                            MessageBox.Show("Este proveedor ya fue capturado");
                            return;
                        }
                    }

                    string Clave = txtClave.Text;
                    string Nombre = txtProveedor.Text;
                    string Contacto = txtContacto.Text;
                    int Dias = Convert.ToInt32(txtDias.Text);
                    decimal Limite = Convert.ToDecimal(txtLimite.Text);
                    string Abreviatura = txtAbreviatura.Text;
                    string LineaPrv = "0";

                    if (cboLinea.Text != "")
                    {
                        LineaPrv = cboLinea.SelectedValue!.ToString()!;
                    }


                    if (bNuevo)
                    {
                        SQL = "Insert Into dbProveedores.dbo.tbProveedor(cCvePrv,cNomPrv,nDiaPrv,nLimPrv,cConPrv, cAbrePrv, nLinPrv) " +
                            "Values('" + Clave + "','" + Nombre + "'," + Dias + "," + Limite + ",'" + Contacto + "','" + Abreviatura + "','" + LineaPrv + "')";
                        conexProveedor.ejecSql(SQL);
                    }


                    if (bModifica)
                    {
                        if (MessageBox.Show("Esta seguro que desea actualizar este proveeedor???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            SQL = "Update dbProveedores.dbo.tbProveedor set cNomPrv = '" + Nombre + "' ,nDiaPrv = " + Dias + ", nLimPrv = " + Limite + ", cConPrv = '" + Contacto + "', cAbrePrv = '" + Abreviatura + "', nLinPrv = " + LineaPrv + " Where cCvePrv = '" + Clave + "'";
                            conexProveedor.ejecSql(SQL);
                        }
                        else
                        {
                            return;
                        }

                    }


                    MessageBox.Show("Registro grabado correctamente");

                    CargaProveedores();
                    UbicarFoco_dgvProveedor(Clave);
                }
                else
                {
                    MessageBox.Show("Falta algún dato por capturar");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnGrabar_Click " + ex.Message);
            }
        }

        private bool ExisteProveedor(string clave)
        {
            bool Existe = false;

            try
            {
                SQL = "SELECT * FROM dbProveedores.dbo.tbProveedor Where cCvePrv = '" + clave + "'";

                DataTable dtExiste = conexProveedor.select(SQL);

                if (dtExiste.Rows.Count > 0)
                {
                    Existe = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ExisteProveedor " + ex.Message);
            }

            return Existe;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
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
                else if ((char)e.KeyChar == '`')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '\'')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '"')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '´')
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Space)
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtDias.Text != "")
                    {
                        txtLimite.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtDias_KeyPress " + ex.Message);
            }
        }

        private void txtLimite_KeyPress(object sender, KeyPressEventArgs e)
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
                else if ((char)e.KeyChar == '`')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '\'')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '"')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '´')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '.')
                {
                    if (txtLimite.Text.Contains("."))
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
                    if (txtContacto.Text != "" && txtDias.Text != "" && txtLimite.Text != "")
                    {
                        btnGrabar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtLimite_KeyPress " + ex.Message);
            }
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else if ((char)e.KeyChar == '`')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '\'')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '"')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '´')
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtContacto.Text != "")
                    {
                        txtDias.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtContacto_KeyPress " + ex.Message);
            }
        }

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else if ((char)e.KeyChar == '`')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '\'')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '"')
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '´')
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtProveedor.Text != "")
                    {
                        if (txtClave.Enabled == false)
                        {
                            txtAbreviatura.Focus();
                        }
                        else
                        {
                            txtClave.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtContacto_KeyPress " + ex.Message);
            }

        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == '`')
            {
                e.Handled = true;
            }
            else if ((char)e.KeyChar == '\'')
            {
                e.Handled = true;
            }
            else if ((char)e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else if ((char)e.KeyChar == '´')
            {
                e.Handled = true;
            }
            else if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (txtClave.Text != "")
                {
                    txtAbreviatura.Focus();
                }
            }
        }

        private void txtAbreviatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            else if ((char)e.KeyChar == '`')
            {
                e.Handled = true;
            }
            else if ((char)e.KeyChar == '\'')
            {
                e.Handled = true;
            }
            else if ((char)e.KeyChar == '"')
            {
                e.Handled = true;
            }
            else if ((char)e.KeyChar == '´')
            {
                e.Handled = true;
            }
            else if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (txtAbreviatura.Text != "")
                {
                    cboLinea.Focus();
                }
            }
        }

        private void cboLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvProveedores_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // Verificar que no sea el encabezado
                if (e.RowIndex < 0 || dgvProveedores.Rows.Count == 0)
                {
                    return;
                }

                nFilaGrid = e.RowIndex;

                txtClave.Text = dgvProveedores.Rows[nFilaGrid].Cells["Clave"].Value.ToString();
                txtProveedor.Text = dgvProveedores.Rows[nFilaGrid].Cells["Nombre"].Value.ToString();
                txtContacto.Text = dgvProveedores.Rows[nFilaGrid].Cells["Contacto"].Value.ToString();
                txtAbreviatura.Text = dgvProveedores.Rows[nFilaGrid].Cells["Abreviatura"].Value.ToString();

                // Manejar posible valor nulo en la línea
                var lineaValue = dgvProveedores.Rows[nFilaGrid].Cells["nLinPrv"].Value;
                cboLinea.SelectedValue = lineaValue != null ? lineaValue : DBNull.Value;

                txtDias.Text = dgvProveedores.Rows[nFilaGrid].Cells["Dias"].Value.ToString();
                txtLimite.Text = dgvProveedores.Rows[nFilaGrid].Cells["Limite_Credito"].Value.ToString();

                btnGrabar.Text = "Modificar";
                btnGrabar.Image = Properties.Resources.update24;

                HabilitaControles(3);
                HabilitaBotones(3);
                bNuevo = false;
                bModifica = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar proveedor: " + ex.Message);
            }
        }

        //Movimiento de ventana de panel de encabezado
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            Point punto = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
            mx = punto.X - this.Location.X;
            my = punto.Y - this.Location.Y;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}