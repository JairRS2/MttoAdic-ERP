using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.AspNetCore.SignalR.Client;
using Syncfusion.Windows.Forms;
using System.Data;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmReportesUrea : MetroForm
    {
        private CartesianChart chartDiario;
        private CartesianChart chartMensual;
        private DataGridView dgvDespachosUnidad;
        private Label lblCostoPorLitro;
        private decimal costoPorLitro = 20m;

        public csConexionSQL conexReportesUrea;
        public csConexionSQL ConexReporteUrea { set { this.conexReportesUrea = value; } }

        // Propiedades para SignalR
        private HubConnection _hubConnection; // No inicializar aquí, se asignará desde el formulario principal
        private bool _eventosConfigurados = false;
        public HubConnection HubConnection
        {
            get { return _hubConnection; }
            set
            {
                _hubConnection = value;
                // Llama a este método SOLO si la conexión se establece desde otro formulario
                if (_hubConnection != null && !_eventosConfigurados)
                {
                    ConfigureHubEvents(); // Configura los eventos UNA SOLA VEZ
                    _eventosConfigurados = true;
                }
            }
        }
        public string UsuarioActual { get; set; }

        int m = 0, mx, my;

        public frmReportesUrea()
        {
            InitializeComponent();
        }

        private void frmReportesUrea_Load(object sender, EventArgs e)
        {
            //Movimiento de ventana de panel de encabezado
            pnlEncabezado.MouseDown += pnlEncabezado_MouseDown;
            pnlEncabezado.MouseMove += pnlEncabezado_MouseMove;
            pnlEncabezado.MouseUp += pnlEncabezado_MouseUp;

            lblTitulo.MouseDown += pnlEncabezado_MouseDown;
            lblTitulo.MouseMove += pnlEncabezado_MouseMove;
            lblTitulo.MouseUp += pnlEncabezado_MouseUp;

            InicializarGraficosYTabla();
        }

        private void InicializarGraficosYTabla()
        {
            // Crear el TableLayoutPanel principal
            TableLayoutPanel layoutPanel = new TableLayoutPanel();
            layoutPanel.Dock = DockStyle.Fill;
            layoutPanel.ColumnCount = 2;
            layoutPanel.RowCount = 2;
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F)); // Altura para los gráficos
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Resto para el DataGridView
            layoutPanel.Padding = new Padding(0, 10, 0, 0);
            this.Controls.Add(layoutPanel);

            // Gráfico Diario
            chartDiario = new CartesianChart();
            chartDiario.Dock = DockStyle.Fill;
            chartDiario.Name = "chartDiario";
            layoutPanel.Controls.Add(chartDiario, 0, 0); // columna 0, fila 0

            // Gráfico Mensual
            chartMensual = new CartesianChart();
            chartMensual.Dock = DockStyle.Fill;
            chartMensual.Name = "chartMensual";
            layoutPanel.Controls.Add(chartMensual, 1, 0); // columna 1, fila 0

            // DataGridView
            dgvDespachosUnidad = new DataGridView();
            dgvDespachosUnidad.Dock = DockStyle.Fill;
            dgvDespachosUnidad.ReadOnly = true;
            dgvDespachosUnidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            layoutPanel.SetColumnSpan(dgvDespachosUnidad, 2); // ocupa ambas columnas
            layoutPanel.Controls.Add(dgvDespachosUnidad, 0, 1); // columna 0, fila 1

            StyleDespachosUnidadDataGridView(); // aplica estilo

            // Label de costo por litro (puedes anclarlo abajo o dejarlo flotante)
            lblCostoPorLitro = new Label();
            lblCostoPorLitro.AutoSize = true;
            lblCostoPorLitro.Text = $"Costo por Litro: ${costoPorLitro:N2}";
            lblCostoPorLitro.Location = new Point(10, this.ClientSize.Height - 30);
            lblCostoPorLitro.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.Controls.Add(lblCostoPorLitro);

            // Cargar datos
            ActualizarTodoElReporte();
        }

        private void ActualizarTodoElReporte()
        {
            MostrarGraficaConsumoDiario();
            MostrarGraficaConsumoMensual();
            MostrarDespachosPorUnidad();
        }

        private DataTable ObtenerConsumoDiario()
        {
            string query = @"
                            SELECT CAST(dtFecReg AS DATETIME) AS Hora, ROUND(SUM(nLitrosDespachados), 2) AS Cantidad
                            FROM dbUrea.dbo.tbDespUrea
                            WHERE CONVERT(date, dtFecReg) = CONVERT(date, GETDATE())
                            GROUP BY CAST(dtFecReg AS DATETIME)
                            ORDER BY CAST(dtFecReg AS DATETIME)";
            return conexReportesUrea.select(query);
        }

        private DataTable ObtenerConsumoMensual()
        {
            string query = @"
                            SELECT CONVERT(date, dtFecReg) AS Dia, ROUND(SUM(nLitrosDespachados), 2) AS CantidadTotal
                            FROM dbUrea.dbo.tbDespUrea
                            WHERE dtFecReg >= DATEADD(day, -30, GETDATE())
                            GROUP BY CONVERT(date, dtFecReg)
                            ORDER BY CONVERT(date, dtFecReg)";
            return conexReportesUrea.select(query);
        }

        private DataTable ObtenerDespachosPorUnidad()
        {
            string query = @"
                             SELECT 
                                cCveUni AS Unidad, 
                                ROUND(SUM(nLitrosDespachados), 2) AS CantidadDespachada,
                                ROUND(SUM(nLitrosDespachados) * 20, 2) AS CostoTotal
                            FROM dbUrea.dbo.tbDespUrea
                            WHERE CONVERT(date, dtFecReg) = CONVERT(date, GETDATE())
                            GROUP BY cCveUni
                            ORDER BY MAX(dtFecReg) DESC";
            return conexReportesUrea.select(query);
        }

        private void MostrarGraficaConsumoDiario()
        {
            DataTable data = ObtenerConsumoDiario();
            chartDiario.Series.Clear();

            if (data != null && data.Rows.Count > 0)
            {
                var columnSeries = new ColumnSeries
                {
                    Title = "Consumo Acumulado (Litros)",
                    Values = new ChartValues<decimal>(data.AsEnumerable()
                        .Select(row => decimal.Round(row.Field<decimal>("Cantidad"), 2))),
                    DataLabels = true,
                    // Configuración específica para el formato de las etiquetas
                    LabelPoint = point => point.Y.ToString("N2") // Formato con 2 decimales
                };


                columnSeries.Foreground = System.Windows.Media.Brushes.Black;
                columnSeries.FontSize = 10;

                chartDiario.Series.Add(columnSeries);

                chartDiario.AxisX.Clear();
                chartDiario.AxisX.Add(new Axis
                {
                    Title = "Hora del Día",
                    Labels = data.AsEnumerable().Select(row => row.Field<DateTime>("Hora").ToString("HH:mm")).ToArray(),
                    Separator = new LiveCharts.Wpf.Separator { Step = 1 }
                });

                chartDiario.AxisY.Clear();
                chartDiario.AxisY.Add(new Axis
                {
                    Title = "Litros",
                    LabelFormatter = value => value.ToString("N2") // Formato para los valores del eje Y
                });
            }
            else
            {
                chartDiario.Series.Add(new ColumnSeries
                {
                    Title = "Consumo Acumulado (Litros)",
                    Values = new ChartValues<decimal>(),
                    LabelPoint = point => point.Y.ToString("N2") // Mantener formato incluso sin datos
                });
                chartDiario.AxisX.Clear();
                chartDiario.AxisX.Add(new Axis { Title = "Hora del Día", Labels = new string[] { "Sin datos" } });
            }

            chartDiario.LegendLocation = LegendLocation.Bottom;
        }

        private void MostrarGraficaConsumoMensual()
        {
            DataTable data = ObtenerConsumoMensual();
            chartMensual.Series.Clear();

            if (data != null && data.Rows.Count > 0)
            {
                chartMensual.Series.Add(new LineSeries
                {
                    Title = "Consumo Total (Litros)",
                    Values = new ChartValues<decimal>(data.AsEnumerable().Select(row => row.Field<decimal>("CantidadTotal"))),
                    LineSmoothness = 0,
                    DataLabels = true,

                });

                chartMensual.AxisX.Clear();
                chartMensual.AxisX.Add(new Axis
                {
                    Title = "Día del Mes",
                    Labels = data.AsEnumerable().Select(row => row.Field<DateTime>("Dia").ToString("dd")).ToArray()
                });
            }
            else
            {
                chartMensual.Series.Add(new LineSeries { Title = "Consumo Total (Litros)", Values = new ChartValues<decimal>() });
                chartMensual.AxisX.Clear();
                chartMensual.AxisX.Add(new Axis { Title = "Día del Mes", Labels = new string[] { "Sin datos" } });
            }

            chartMensual.AxisY.Clear();
            chartMensual.AxisY.Add(new Axis
            {
                Title = "Litros"
            });
            chartMensual.LegendLocation = LegendLocation.Bottom;
        }

        private void MostrarDespachosPorUnidad()
        {
            DataTable data = ObtenerDespachosPorUnidad();
            dgvDespachosUnidad.DataSource = data;

            // Aplicar formato a las columnas numéricas
            if (dgvDespachosUnidad.Columns.Contains("CantidadDespachada"))
            {
                dgvDespachosUnidad.Columns["CantidadDespachada"].HeaderText = "Cantidad Despachada";
                dgvDespachosUnidad.Columns["CantidadDespachada"].DefaultCellStyle.Format = "N2";
            }
            if (dgvDespachosUnidad.Columns.Contains("CostoTotal"))
            {
                dgvDespachosUnidad.Columns["CostoTotal"].HeaderText = "Costo Total";
                dgvDespachosUnidad.Columns["CostoTotal"].DefaultCellStyle.Format = "N2";
            }
        }

        private void StyleDespachosUnidadDataGridView()
        {
            dgvDespachosUnidad.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDespachosUnidad.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDespachosUnidad.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvDespachosUnidad.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvDespachosUnidad.BackgroundColor = Color.White;
            dgvDespachosUnidad.GridColor = Color.FromArgb(230, 230, 230);
            dgvDespachosUnidad.EnableHeadersVisualStyles = false;
            dgvDespachosUnidad.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(47, 84, 150);
            dgvDespachosUnidad.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDespachosUnidad.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(47, 84, 150);
            dgvDespachosUnidad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDespachosUnidad.ColumnHeadersHeight = 35;
            dgvDespachosUnidad.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDespachosUnidad.RowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvDespachosUnidad.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvDespachosUnidad.RowTemplate.Height = 28;
            dgvDespachosUnidad.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dgvDespachosUnidad.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDespachosUnidad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDespachosUnidad.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(47, 84, 150);
            dgvDespachosUnidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDespachosUnidad.AllowUserToResizeRows = false;
            dgvDespachosUnidad.ReadOnly = true;
            dgvDespachosUnidad.RowHeadersVisible = false;
            dgvDespachosUnidad.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }

        private void ConfigureHubEvents()
        {
            // Agrega este handler para la señal "ActualizarReportesUrea"
            _hubConnection.On("ActualizarReportesUrea", () => // No espera parámetros
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    // Aquí es donde realmente quieres actualizar los reportes
                    ActualizarTodoElReporte();
                }));
            });
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void reportesUrea_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Detener la conexión de SignalR
            if (_hubConnection != null && _hubConnection.State != HubConnectionState.Disconnected)
            {
                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();
            }
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
    }
}
