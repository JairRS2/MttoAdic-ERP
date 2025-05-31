using Microsoft.AspNetCore.SignalR.Client;
using MttoAdic_ERP.Forms.Almacen;
using Syncfusion.Windows.Forms;
using System.Data;

namespace MttoAdic_ERP.Forms
{
    public partial class frmValesUrea : MetroForm
    {
        private string SQL = string.Empty;
        public csConexionSQL conexValesUrea;
        public csConexionSQL ConexValesUrea { set { this.conexValesUrea = value; } }

        private frmEditarValeUrea frmEditarValeUrea = new frmEditarValeUrea(0);
        private frmAgrValeUrea frmAgregarValeUrea = new frmAgrValeUrea();


        // Declarar el nuevo formulario de edición como miembro de la clase
        //private frmEditarValeUrea formEditarValeUrea;
        private ToolTip toolTipBuscar; // Declarar un objeto ToolTip

        int m = 0, mx, my;
        private bool _formateandoFecha = false;

        public frmValesUrea()
        {
            InitializeComponent();
            // Asignar las instancias de los controles del diseñador a nuestras variables
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            cmbFiltro.SelectedIndexChanged += cmbFiltro_SelectedIndexChanged; // Conectar el evento del ComboBox
                                                                              // Configuración del ComboBox
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.Items.AddRange(new string[] { "Número de Despacho", "Despachador", "Clave de Unidad", "Fecha" });
            if (cmbFiltro.Items.Count > 0)
            {
                cmbFiltro.SelectedIndex = 0; // Establecer la selección por defecto
            }

            // Inicialización del ToolTip para txtBuscar
            toolTipBuscar = new ToolTip();
            toolTipBuscar.ToolTipTitle = "Buscar";
            toolTipBuscar.ShowAlways = true; // Para que se muestre incluso si la ventana no está activa
            toolTipBuscar.SetToolTip(txtBuscar, "Ingrese texto para filtrar por la opción seleccionada.");

            ApplyGridStyles();
            ApplyButtonStyle();
            //formEditarValeUrea = new frmEditarValeUrea(); // Inicializar el formulario de edición
        }

        private void ValesUrea_Load(object sender, EventArgs e)
        {
            //Movimiento de ventana de panel de encabezado
            pnlEncabezado.MouseDown += pnlEncabezado_MouseDown;
            pnlEncabezado.MouseMove += pnlEncabezado_MouseMove;
            pnlEncabezado.MouseUp += pnlEncabezado_MouseUp;

            lblTitulo.MouseDown += pnlEncabezado_MouseDown;
            lblTitulo.MouseMove += pnlEncabezado_MouseMove;
            lblTitulo.MouseUp += pnlEncabezado_MouseUp;
            CargarVales();
        }

        private void ApplyGridStyles()
        {
            // Configuración de bordes
            dgvValesUrea.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvValesUrea.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Configuración de fuentes
            dgvValesUrea.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvValesUrea.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Configuración de colores base
            dgvValesUrea.BackgroundColor = Color.White;
            dgvValesUrea.GridColor = Color.FromArgb(230, 230, 230);

            // Estilo de cabeceras
            dgvValesUrea.EnableHeadersVisualStyles = false;
            dgvValesUrea.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(47, 84, 150);
            dgvValesUrea.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvValesUrea.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(47, 84, 150);
            dgvValesUrea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvValesUrea.ColumnHeadersHeight = 35;

            // Estilo de filas
            dgvValesUrea.RowsDefaultCellStyle.BackColor = Color.White;
            dgvValesUrea.RowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvValesUrea.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvValesUrea.RowTemplate.Height = 28;

            // Selección de filas
            dgvValesUrea.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dgvValesUrea.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvValesUrea.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvValesUrea.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(47, 84, 150);

            // Otras configuraciones
            dgvValesUrea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvValesUrea.AllowUserToResizeRows = false;
            dgvValesUrea.ReadOnly = true;
            dgvValesUrea.RowHeadersVisible = false;
            dgvValesUrea.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }

        private void ApplyButtonStyle()
        {
            // Establecer la propiedad Anchor para que el botón se mueva con el formulario
            btnNuevoVale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoVale.Margin = new Padding(0, 10, 10, 0);
        }

        private DataTable ObtenerVales()
        {
            if (conexValesUrea == null)
            {

                return new DataTable(); // Retorna una tabla vacía para evitar errores
            }
            DataTable dtVales = new DataTable();
            try
            {
                SQL = "SELECT d.nNumDesp AS Numero_Despacho, d.cCveUni AS Clave_Unidad, emp.cNomEmp AS Despachador, d.nLitrosDespachados AS Litros_Despachados, " +
                    "         d.dtFecReg AS Fecha_Registro " +
                    "FROM dbUrea.dbo.tbDespUrea d " +
                    "INNER JOIN dbUrea.dbo.tbDespachador emp ON d.cCveEmp = emp.cCveEmp " +
                    "INNER JOIN dbRelacionesLaborales.dbo.tbPersonal per ON d.cCveOpe = per.cCvePer " +
                    "ORDER BY d.nNumDesp DESC;";
                dtVales = conexValesUrea.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los vales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtVales;
        }

        private void CargarVales()
        {
            DataTable dtVales = ObtenerVales();
            dgvValesUrea.DataSource = null;
            dgvValesUrea.Columns.Clear();
            if (dtVales.Rows.Count > 0)
            {
                dgvValesUrea.DataSource = dtVales;
            }
        }

        private void FiltrarVales()
        {
            string filtro = cmbFiltro.SelectedItem?.ToString();
            string textoBusqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(textoBusqueda) && string.IsNullOrEmpty(filtro))
            {
                CargarVales();
                return;
            }

            DataTable dtVales = ObtenerVales();

            if (dtVales != null)
            {
                DataTable dtFiltrado = dtVales.Clone(); // Copiar estructura

                foreach (DataRow row in dtVales.Rows)
                {
                    bool coincide = false;

                    switch (filtro)
                    {
                        case "Número de Despacho":
                            coincide = row["Numero_Despacho"].ToString().IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0;
                            break;
                        case "Despachador":
                            coincide = row["Despachador"].ToString().IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0;
                            break;
                        case "Clave de Unidad":
                            coincide = row["Clave_Unidad"].ToString().IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0;
                            break;
                        case "Fecha":
                            if (DateTime.TryParseExact(textoBusqueda, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fechaBuscada))
                            {
                                DateTime fechaFila = Convert.ToDateTime(row["Fecha_Registro"]);
                                coincide = fechaFila.Date == fechaBuscada.Date;
                            }
                            break;
                        default:
                            CargarVales();
                            return;
                    }

                    if (coincide)
                    {
                        dtFiltrado.ImportRow(row);
                    }
                }
                dgvValesUrea.DataSource = dtFiltrado;
            }
        }

        //Eventos        
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedItem?.ToString() != "Fecha")
            {
                FiltrarVales();
                return;
            }

            if (_formateandoFecha) return;

            _formateandoFecha = true;

            TextBox txt = (TextBox)sender;

            int cursorPos = txt.SelectionStart;
            int textoAnteriorLength = txt.Text.Length;

            string inputOriginal = txt.Text.ToLower();

            // Limpiar el texto de cualquier carácter que no sea letra o dígito
            string limpio = inputOriginal.Replace("/", "").Replace("-", "").Replace(" ", "");

            Dictionary<string, string> meses = new Dictionary<string, string>
            {
                {"ene", "01"}, {"feb", "02"}, {"mar", "03"}, {"abr", "04"},
                {"may", "05"}, {"jun", "06"}, {"jul", "07"}, {"ago", "08"},
                {"sep", "09"}, {"oct", "10"}, {"nov", "11"}, {"dic", "12"}
            };

            string nuevoTexto = limpio;
            //dia
            if (limpio.Length >= 3 && limpio.Length < 5)
            {
                nuevoTexto = limpio.Insert(2, "/");
            }
            //mes
            if (limpio.Length >= 5)
            {
                string dia = limpio.Substring(0, 2);
                string posibleMes = limpio.Substring(2, 3);

                if (meses.TryGetValue(posibleMes, out string mesNumerico))
                {
                    nuevoTexto = $"{dia}/{mesNumerico}";

                    if (limpio.Length > 5)
                    {
                        string anio = limpio.Substring(5);
                        nuevoTexto += $"/{anio}";
                    }
                }//año
                else if (limpio.Length >= 4 && limpio.Length <= 8 && limpio.All(char.IsDigit))
                {
                    string diaNum = limpio.Substring(0, 2);
                    string mesNumNumerico = limpio.Substring(2, 2);
                    nuevoTexto = $"{diaNum}/{mesNumNumerico}";

                    if (limpio.Length > 4)
                    {
                        string anio = limpio.Substring(4);
                        nuevoTexto += $"/{anio}";
                    }
                }
            }

            // Ajustar la posición del cursor para que no se salte o retroceda mal
            int diferenciaLongitud = nuevoTexto.Length - textoAnteriorLength;
            int nuevaPosicion = cursorPos + diferenciaLongitud;

            if (nuevaPosicion < 0) nuevaPosicion = 0;
            if (nuevaPosicion > nuevoTexto.Length) nuevaPosicion = nuevoTexto.Length;

            txt.Text = nuevoTexto;
            txt.SelectionStart = nuevaPosicion;

            _formateandoFecha = false;

            FiltrarVales();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarVales();
        }

        private void dgvValesUrea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (!frmEditarValeUrea.Created)
            {
                int orden = Convert.ToInt32(dgvValesUrea.Rows[e.RowIndex].Cells["Numero_Despacho"].Value);
                frmEditarValeUrea = new frmEditarValeUrea(orden);
                frmEditarValeUrea.ConexEditarValeUrea = conexValesUrea;
            }

            frmEditarValeUrea.Show();
        }

        private void pnlEncabezado_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
            Point punto = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
            mx = punto.X - this.Location.X;
            my = punto.Y - this.Location.Y;
        }

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

        private void btnNuevoVale_Click(object sender, EventArgs e)
        {
            if (!frmAgregarValeUrea.Created)
            {
                frmAgregarValeUrea = new frmAgrValeUrea();
                frmAgregarValeUrea.ConexValesUrea = conexValesUrea;
            }

            frmAgregarValeUrea.Show();
        }
    }
}
