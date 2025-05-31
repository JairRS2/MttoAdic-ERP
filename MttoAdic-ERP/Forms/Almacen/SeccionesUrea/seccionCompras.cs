using Microsoft.AspNetCore.SignalR.Client;
using MttoAdic_ERP.Models;
using Syncfusion.Windows.Forms;
using System.Data;

namespace MttoAdic_ERP.Forms.Almacen.SeccionesUrea
{
    public partial class seccionCompras : MetroForm
    {
        public HubConnection HubConnection { get; set; }
        public string UsuarioActual { get; set; }
        public Panel pnlChatNotificaciones;
        private string SQL = string.Empty;
        public csConexionSQL conexSeccionCompras;
        public csConexionSQL ConexSeccionCompras { set { this.conexSeccionCompras = value; } }
        private frmCompraUrea frmCompraUrea = new frmCompraUrea();
        private bool _formateandoFecha = false;
        private Color originalColorBtnNuevaCompra;

        public seccionCompras()
        {
            InitializeComponent();
        }

        private void seccionCompras_Load(object sender, EventArgs e)
        {
            originalColorBtnNuevaCompra = btnNuevaCompra.BackColor;

            txtBuscar.TextChanged += txtBuscar_TextChanged;
            cmbFiltro.SelectedIndexChanged += cmbFiltro_SelectedIndexChanged; // Conectar el evento del ComboBox
                                                                              // Configuración del ComboBox
            cmbFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltro.Items.AddRange(new string[] { "Orden", "Factura", "Fecha" });
            if (cmbFiltro.Items.Count > 0)
            {
                cmbFiltro.SelectedIndex = 0; // Establecer la selección por defecto
            }
            toolTipBuscar.SetToolTip(txtBuscar, "Ingrese texto para filtrar por la opción seleccionada.");
            StyleComprasUreaDataGridView();
            carga_dgvComprasUrea();
        }

        private void carga_dgvComprasUrea()
        {
            dgvComprasUrea.DataSource = null;
            dgvComprasUrea.Columns.Clear();

            DataTable dtOrdenes = CargaOrdenes();
            if (dtOrdenes.Rows.Count == 0)
                return;

            dgvComprasUrea.DataSource = dtOrdenes;

            // Encabezados personalizados
            var headers = new Dictionary<string, string>
            {
                ["Orden"] = "Orden",
                ["Fecha"] = "Fecha",
                ["Estado"] = "Estado",
                ["Nombre_Proveedor"] = "Proveedor",
                ["Subtotal"] = "Subtotal",
                ["Iva"] = "IVA",
                ["Total"] = "Total",
                ["Factura"] = "Factura",
                ["Folio_Fiscal"] = "Folio Fiscal",
                ["Tipo_Pago"] = "Tipo Pago",
                ["Litros"] = "Litros",
                ["Costo"] = "Costo"
            };

            foreach (var column in headers)
            {
                if (dgvComprasUrea.Columns.Contains(column.Key))
                    dgvComprasUrea.Columns[column.Key].HeaderText = column.Value;
            }

            // Formato de columnas numéricas
            FormatColumn("Litros", "N2", DataGridViewContentAlignment.MiddleCenter);
            FormatColumn("Costo", "N2", DataGridViewContentAlignment.MiddleCenter);
            FormatMonetaryColumns();

            // Configuración responsive
            ConfigureResponsiveColumns();

            // Evitar múltiples suscripciones al evento
            dgvComprasUrea.SizeChanged -= DgvComprasUrea_SizeChanged;
            dgvComprasUrea.SizeChanged += DgvComprasUrea_SizeChanged;

            AdjustColumnsForSize();
        }

        private void DgvComprasUrea_SizeChanged(object sender, EventArgs e)
        {
            AdjustColumnsForSize();
        }

        private DataTable CargaOrdenes()
        {
            DataTable dtOrdenes = new DataTable();

            try
            {
                SQL = "SELECT o.nNumOrd AS Orden, o.dFecOrd AS Fecha, " +
                  "CASE " +
                  "WHEN o.nEdoOrd = 1 " +
                  "THEN 'Emitido'  " +
                  "WHEN o.nEdoOrd = 2 " +
                  "THEN 'Terminado' " +
                  "ELSE 'Otro' END AS Estado, " +
                  " p.cNomPrv AS Nombre_Proveedor, o.nSubOrd AS Subtotal, o.nIvaOrd AS Iva, o.nTotOrd AS Total, " +
                  "o.cFacOrd AS Factura, o.cFolFis AS Folio_Fiscal, " +
                  "CASE " +
                  "WHEN o.nPgoOrd = 1 " +
                  "THEN 'Contado' " +
                  "WHEN o.nPgoOrd = 2 " +
                  "THEN 'Credito' " +
                  "ELSE 'Otro' END AS Tipo_Pago, " +
                  "o.nLtsOrd AS Litros, o.nCtoOrd AS Costo " +
                  "FROM dbUrea.dbo.tbOrden o INNER JOIN dbProveedores.dbo.tbProveedor p ON o.cPrvOrd = p.cCvePrv ORDER BY o.nNumOrd DESC;";

                dtOrdenes = conexSeccionCompras.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaOrdenes " + ex.Message);
            }

            return dtOrdenes;
        }

        private void FiltrarOrdenes()
        {
            string filtro = cmbFiltro.SelectedItem?.ToString();
            string textoBusqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(textoBusqueda) && string.IsNullOrEmpty(filtro))
            {
                carga_dgvComprasUrea();
                return;
            }

            DataTable dtOrdenes = CargaOrdenes();

            if (dtOrdenes != null)
            {
                DataTable dtFiltrado = dtOrdenes.Clone(); // Copiar estructura

                foreach (DataRow row in dtOrdenes.Rows)
                {
                    bool coincide = false;

                    switch (filtro)
                    {
                        case "Orden":
                            coincide = row["Orden"].ToString().IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0;
                            break;
                        case "Factura":
                            coincide = row["Factura"].ToString().IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0;
                            break;
                        case "Fecha":
                            if (DateTime.TryParseExact(textoBusqueda, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fechaBuscada))
                            {
                                DateTime fechaFila = Convert.ToDateTime(row["Fecha"]);
                                coincide = fechaFila.Date == fechaBuscada.Date;
                            }
                            break;
                        default:
                            carga_dgvComprasUrea();
                            return;
                    }

                    if (coincide)
                    {
                        dtFiltrado.ImportRow(row);
                    }
                }

                dgvComprasUrea.DataSource = dtFiltrado;
            }
        }

        private void FormatColumn(string columnName, string format, DataGridViewContentAlignment alignment)
        {
            if (dgvComprasUrea.Columns.Contains(columnName))
            {
                dgvComprasUrea.Columns[columnName].DefaultCellStyle.Format = format;
                dgvComprasUrea.Columns[columnName].DefaultCellStyle.Alignment = alignment;
            }
        }

        private void FormatMonetaryColumns()
        {
            string[] monetaryColumns = { "Subtotal", "Iva", "Total" };
            foreach (var col in monetaryColumns)
            {
                FormatColumn(col, "C2", DataGridViewContentAlignment.MiddleCenter);
            }
        }

        private void AdjustColumnsForSize()
        {
            bool isSmallWindow = dgvComprasUrea.Width < 1000;

            SetColumnVisibility("Subtotal", !isSmallWindow);
            SetColumnVisibility("Iva", !isSmallWindow);

            dgvComprasUrea.AutoSizeColumnsMode = isSmallWindow
                ? DataGridViewAutoSizeColumnsMode.None
                : DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar columnas específicas
            SetColumnMinimumWidth("Nombre_Proveedor", isSmallWindow ? 120 : 150);
            SetColumnMinimumWidth("Folio_Fiscal", isSmallWindow ? 100 : 120);
            SetColumnMinimumWidth("Factura", isSmallWindow ? 80 : 100);

            if (isSmallWindow)
            {
                foreach (DataGridViewColumn column in dgvComprasUrea.Columns)
                {
                    if (column.Visible)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    }
                }

                SetAutoSizeFill("Nombre_Proveedor");
                SetAutoSizeFill("Folio_Fiscal");
            }
        }

        private void SetColumnVisibility(string columnName, bool visible)
        {
            if (dgvComprasUrea.Columns.Contains(columnName))
                dgvComprasUrea.Columns[columnName].Visible = visible;
        }

        private void SetColumnMinimumWidth(string columnName, int width)
        {
            if (dgvComprasUrea.Columns.Contains(columnName))
                dgvComprasUrea.Columns[columnName].MinimumWidth = width;
        }

        private void SetAutoSizeFill(string columnName)
        {
            if (dgvComprasUrea.Columns.Contains(columnName) && dgvComprasUrea.Columns[columnName].Visible)
                dgvComprasUrea.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void StyleComprasUreaDataGridView()
        {
            // Configuración de bordes
            dgvComprasUrea.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvComprasUrea.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Configuración de fuentes
            dgvComprasUrea.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvComprasUrea.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Configuración de colores base
            dgvComprasUrea.BackgroundColor = Color.White;
            dgvComprasUrea.GridColor = Color.FromArgb(230, 230, 230);

            // Estilo de cabeceras (configuración clave)
            dgvComprasUrea.EnableHeadersVisualStyles = false;
            dgvComprasUrea.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(47, 84, 150); // Azul corporativo
            dgvComprasUrea.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvComprasUrea.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(47, 84, 150); // Mismo azul para selección
            dgvComprasUrea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvComprasUrea.ColumnHeadersHeight = 35;

            // Estilo de filas
            dgvComprasUrea.RowsDefaultCellStyle.BackColor = Color.White;
            dgvComprasUrea.RowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvComprasUrea.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvComprasUrea.RowTemplate.Height = 28;

            // Selección de filas
            dgvComprasUrea.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180); // Azul más claro para filas seleccionadas
            dgvComprasUrea.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvComprasUrea.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComprasUrea.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(47, 84, 150); // Encabezados de fila azules

            // Otras configuraciones
            dgvComprasUrea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvComprasUrea.AllowUserToResizeRows = false;
            dgvComprasUrea.ReadOnly = true;
            dgvComprasUrea.RowHeadersVisible = false; // Ocultar encabezados de fila si no son necesarios
            dgvComprasUrea.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }

        private void ConfigureResponsiveColumns()
        {
            // Columnas con ancho fijo inicial
            SetColumnPriority("Orden", 70);
            SetColumnPriority("Fecha", 90);
            SetColumnPriority("Estado", 90);
            SetColumnPriority("Tipo_Pago", 100);
            SetColumnPriority("Subtotal", 90);
            SetColumnPriority("Iva", 70);
            SetColumnPriority("Total", 90);
            SetColumnPriority("Litros", 70);
            SetColumnPriority("Costo", 80);
            SetColumnPriority("Factura", 100);

            // Columnas que se expandirán
            SetFillWeightColumn("Nombre_Proveedor", 25);
            SetFillWeightColumn("Folio_Fiscal", 20);
        }

        private void SetColumnPriority(string columnName, int width)
        {
            if (dgvComprasUrea.Columns.Contains(columnName))
            {
                dgvComprasUrea.Columns[columnName].Width = width;
                dgvComprasUrea.Columns[columnName].MinimumWidth = width;
                dgvComprasUrea.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }

        private void SetFillWeightColumn(string columnName, int fillWeight)
        {
            if (dgvComprasUrea.Columns.Contains(columnName))
            {
                dgvComprasUrea.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvComprasUrea.Columns[columnName].FillWeight = fillWeight;
                dgvComprasUrea.Columns[columnName].MinimumWidth = 50; // Asegurar un ancho mínimo
            }
        }

        private void cambioColorControlesCompras()
        {
            dgvComprasUrea.Enabled = false;
            dgvComprasUrea.ColumnHeadersDefaultCellStyle.BackColor = Color.White; // Azul corporativo
            dgvComprasUrea.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkGray;
            dgvComprasUrea.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White; // Mismo azul para selección
            dgvComprasUrea.RowsDefaultCellStyle.ForeColor = Color.DarkGray;
            dgvComprasUrea.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvComprasUrea.DefaultCellStyle.SelectionBackColor = Color.DarkGray; // Azul más claro para filas seleccionadas

            btnNuevaCompra.Enabled = false;
            btnNuevaCompra.BackColor = Color.White;
            txtBuscar.Enabled = false;
            cmbFiltro.Enabled = false;

            frmCompraUrea.Show();

            frmCompraUrea.FormClosed += (s, args) =>
            {
                dgvComprasUrea.Enabled = true;
                dgvComprasUrea.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(47, 84, 150); // Azul corporativo
                dgvComprasUrea.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvComprasUrea.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(47, 84, 150);
                dgvComprasUrea.RowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
                dgvComprasUrea.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                dgvComprasUrea.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180); // Azul más claro para filas seleccionadas

                btnNuevaCompra.Enabled = true;
                btnNuevaCompra.BackColor = originalColorBtnNuevaCompra;
                txtBuscar.Enabled = true;
                cmbFiltro.Enabled = true;
                carga_dgvComprasUrea();
            };
        }

        private void dgvComprasUrea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int orden = 0;

            if (!frmCompraUrea.Created)
            {
                orden = Convert.ToInt32(dgvComprasUrea.Rows[e.RowIndex].Cells["Orden"].Value);
                frmCompraUrea = new frmCompraUrea(orden);
                frmCompraUrea.ConexComprasUrea = conexSeccionCompras;
            }

            /*_ = _hubConnection.InvokeAsync("EnviarNotificacion", new Notificacion
            {
                Usuario = _usuarioActual,
                Mensaje = $"Está editando la orden: " + orden,
                Modulo = "Compras"
            });*/

            cambioColorControlesCompras();


        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedItem?.ToString() != "Fecha")
            {
                FiltrarOrdenes();
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

            FiltrarOrdenes();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarOrdenes();
        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            if (!frmCompraUrea.Created)
            {
                frmCompraUrea = new frmCompraUrea();
                frmCompraUrea.ConexComprasUrea = conexSeccionCompras;
                frmCompraUrea.HubConnection = HubConnection;
                frmCompraUrea.UsuarioActual = UsuarioActual;

            }
            frmCompraUrea.FiltrarProveedoresUrea = true;
            cambioColorControlesCompras();
            frmCompraUrea.Show();


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
