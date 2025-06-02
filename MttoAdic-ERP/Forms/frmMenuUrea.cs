using Microsoft.AspNetCore.SignalR.Client;
using MttoAdic_ERP.Forms.Almacen;
using MttoAdic_ERP.Forms.Almacen.SeccionesUrea;
using MttoAdic_ERP.Models;
using Syncfusion.Windows.Forms;
using System.Data;
using System.Security.Policy;
using Timer = System.Windows.Forms.Timer;

namespace MttoAdic_ERP.Forms
{
    public partial class frmMenuUrea : MetroForm
    {
        // Conexión SignalR
        private HubConnection _hubConnection;
        private string _usuarioActual;

        // Diccionario para almacenar el color de cada usuario
        private Dictionary<string, Color> _usuarioColores = new Dictionary<string, Color>();
        private static readonly List<Color> _coloresDisponibles = new List<Color>
        {
            Color.FromArgb(34, 139, 34),     // Green (más oscuro)
            Color.FromArgb(65, 105, 225),    // DarkBlue
            Color.FromArgb(85, 26, 139),    // DarkViolet (más oscuro)
            Color.FromArgb(139, 69, 19),    // SaddleBrown
            Color.FromArgb(0, 128, 128),    // Teal (original)
            Color.FromArgb(101, 67, 33),    // Café oscuro
            Color.FromArgb(128, 0, 128),    // Purple (oscuro)
            Color.FromArgb(34, 139, 34),    // ForestGreen
            Color.FromArgb(72, 61, 139),    // DarkSlateBlue
            Color.FromArgb(139, 0, 0),      // DarkRed
            Color.FromArgb(47, 79, 79),     // DarkSlateGray
            Color.FromArgb(153, 50, 204)    // DarkOrchid
        };
        private int _indiceColorActual = 0;


        // Formularios y componentes existentes

        private frmProveedores frmProveedores = new frmProveedores();
        private frmCompraUrea frmCompraUrea = new frmCompraUrea();
        private frmInventarioUrea frmInventarioUrea = new frmInventarioUrea();
        private frmValesUrea frmValesUrea = new frmValesUrea();
        private frmReportesUrea frmReportesUrea = new frmReportesUrea();
        private string SQL = string.Empty;
        public csConexionSQL conexMenuUrea;
        public csConexionSQL ConexMenuUrea { set { this.conexMenuUrea = value; } }

        private Color originalColorBtnEntradaCompra;
        private Color originalColorBtnInventario;
        private Color originalColorBtnVales;
        private Color originalColorBtnReportes;
        private Color originalColorBtnProveedores;
        private Color originalColorBtnZonas;

        // Nuevos controles para el chat de notificaciones
        private Panel pnlChatNotificaciones;
        private RichTextBox rtbNotificaciones;
        private TextBox txtNuevaNotificacion;
        private NotifyIcon notifyIcon;

        private bool _eventosConfigurados = false; // Variable para controlar el registro de eventos  
        seccionCompras seccionCompras = new seccionCompras();

        public frmMenuUrea()
        {
            InitializeComponent();
            _usuarioActual = Environment.UserName;
            //StyleComprasUreaDataGridView();
            InitializeChatNotificaciones();
            InitializeSignalRAsync();
        }
        public frmMenuUrea(string usuarioLogueado, csConexionSQL conexionBD)
        {
            InitializeComponent();
            _usuarioActual = usuarioLogueado;
            this.conexMenuUrea = conexionBD;
            InitializeSignalRAsync();
            InitializeChatNotificaciones();
            // La inicialización de SignalR y datos se moverá al evento Load
        }

        private void frmMenuUrea_Load(object sender, EventArgs e)
        {
            originalColorBtnEntradaCompra = btnEntradaCompra.BackColor;
            originalColorBtnInventario = btnInventarioUrea.BackColor;
            originalColorBtnVales = btnVales.BackColor;
            originalColorBtnReportes = btnReportes.BackColor;
            originalColorBtnProveedores = btnProveedores.BackColor;
            originalColorBtnZonas = btnZonas.BackColor;
            AbrirSeccionCompra();
            ActualizarTotalesUreaDiariosUI();
            ActualizarTotalesUreaMensualesUI();
            ActualizarTotalesComprasDiariosUI();
            ActualizarTotalesComprasMensualesUI();
        }

        private void AbrirSeccionCompra()
        {
            if (seccionCompras != null)
            {
                seccionCompras.Dispose(); // Libera la instancia anterior si ya existe
            }

            seccionCompras = new seccionCompras();
            seccionCompras.ConexSeccionCompras = conexMenuUrea;
            seccionCompras.HubConnection = _hubConnection; // Asigna la conexión SignalR
            seccionCompras.UsuarioActual = _usuarioActual;
            pnlSeccionUrea.Controls.Clear();


            seccionCompras.TopLevel = false;
            seccionCompras.FormBorderStyle = FormBorderStyle.None; // Para evitar bordes innecesarios
            seccionCompras.Dock = DockStyle.Fill;

            pnlSeccionUrea.Controls.Add(seccionCompras);
            pnlSeccionUrea.Tag = seccionCompras;

            seccionCompras.Show();

            cambioColorBotonCompras();
        }

        private void AbrirSeccionVales()
        {
            if (seccionCompras != null)
            {
                seccionCompras.Dispose(); // Libera la instancia anterior si ya existe
            }

            frmValesUrea = new frmValesUrea();
            frmValesUrea.ConexValesUrea = conexMenuUrea;

            pnlSeccionUrea.Controls.Clear(); // Limpia el panel antes de cargar el nuevo formulario

            frmValesUrea.TopLevel = false; // el formulario no será una ventana independiente
            frmValesUrea.FormBorderStyle = FormBorderStyle.None; // Quita los bordes
            frmValesUrea.Dock = DockStyle.Fill; // Para que se ajuste al tamaño del panel

            pnlSeccionUrea.Controls.Add(frmValesUrea); // Agrega el formulario al panel
            pnlSeccionUrea.Tag = frmValesUrea; // Opcional: puedes usarlo para control futuro
            frmValesUrea.Show(); // Muestra el formulario   
            cambioColorBotonVales();
        }

        private void InitializeChatNotificaciones()
        {
            // Panel contenedor principal
            pnlChatNotificaciones = new Panel();
            pnlChatNotificaciones.Dock = DockStyle.Right;
            pnlChatNotificaciones.Width = 320; //Un poco mas ancho para la visualizacion
            pnlChatNotificaciones.BackColor = Color.FromArgb(240, 240, 240);
            pnlChatNotificaciones.Padding = new Padding(0);

            // Título del panel
            var lblTitulo = new Label();
            lblTitulo.Text = "NOTIFICACIONES";
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.BackColor = Color.SteelBlue;
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Height = 35;
            lblTitulo.Padding = new Padding(0, 5, 0, 0);

            // Panel contenedor de notificaciones con scroll
            var pnlContenedorNotificaciones = new Panel();
            pnlContenedorNotificaciones.Dock = DockStyle.Fill;
            pnlContenedorNotificaciones.BackColor = Color.White;
            pnlContenedorNotificaciones.AutoScroll = true;
            pnlContenedorNotificaciones.Padding = new Padding(5);

            // Panel para organizar las notificaciones (FlowLayoutPanel)
            var flowPanel = new FlowLayoutPanel();
            flowPanel.Dock = DockStyle.Top;
            flowPanel.AutoSize = true;
            flowPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.WrapContents = false;
            flowPanel.BackColor = Color.White;
            flowPanel.Padding = new Padding(0, 0, 15, 0); // Espacio para el scroll

            // Configurar el contenedor
            pnlContenedorNotificaciones.Controls.Add(flowPanel);
            pnlChatNotificaciones.Controls.Add(pnlContenedorNotificaciones);
            pnlChatNotificaciones.Controls.Add(lblTitulo);
            this.Controls.Add(pnlChatNotificaciones);

            // Guardar referencia al flowPanel para usarlo después
            this.Tag = flowPanel;

            // Ajustar el DataGridView
            //dgvUrea.Width = this.ClientSize.Width - pnlChatNotificaciones.Width - 20;
        }


        private async Task InitializeSignalRAsync()
        {
            try
            {
                _hubConnection = new HubConnectionBuilder()
                  .WithUrl("http://pruebasdesarrollo.ddns.net:5182/chatHub")
                  .WithAutomaticReconnect()
                  .Build();

                // Configurar eventos solo una vez al inicio
                if (!_eventosConfigurados)
                {
                    ConfigureHubEvents();
                    _eventosConfigurados = true;
                }

                await _hubConnection.StartAsync();
                await _hubConnection.InvokeAsync("RegistrarUsuario", _usuarioActual);
                await CargarNotificacionesHistoricas();
            }
            catch (Exception ex)
            {
                MostrarError($"Error de conexión: {ex.Message}");
            }

            // Manejo de reconexión - no volver a configurar eventos aquí
            _hubConnection.Reconnected += async (connectionId) =>
            {
                AgregarNotificacionSistema("Reconectado al servidor", Color.Green);
                await CargarNotificacionesHistoricas();
            };
        }
        private void ConfigureHubEvents()
        {
            _hubConnection.Remove("NuevaNotificacion");
            _hubConnection.Remove("UsuarioConectado");
            _hubConnection.Remove("UsuarioDesconectado");

            _hubConnection.On<Notificacion>("NuevaNotificacion", (notif) =>
            {
                this.Invoke((MethodInvoker)(() => MostrarNotificacionEnUI(notif)));
            });

            _hubConnection.On<string>("UsuarioConectado", (usuario) =>
            {
                this.Invoke((MethodInvoker)(() =>
                    AgregarNotificacionSistema($"{usuario} se ha conectado", Color.DarkBlue)));
            });

            _hubConnection.On<string>("UsuarioDesconectado", (usuario) =>
            {
                this.Invoke((MethodInvoker)(() =>
                    AgregarNotificacionSistema($"{usuario} se ha desconectado", Color.DarkOrange)));
            });

            _hubConnection.On("ActualizarReportesUrea", () =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    ActualizarTotalesUreaDiariosUI();
                    ActualizarTotalesUreaMensualesUI();
                }));
            });
            _hubConnection.On("ActualizarReportesCompras", () =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    ActualizarTotalesComprasDiariosUI();
                    ActualizarTotalesComprasMensualesUI();
                }));
            });
        }
        private async Task CargarNotificacionesHistoricas()
        {
            try
            {
                var historico = await _hubConnection.InvokeAsync<List<Notificacion>>(
                  "ObtenerNotificaciones", 20, null);

                var flowPanel = this.Tag as FlowLayoutPanel;
                if (flowPanel == null) return;

                this.Invoke((MethodInvoker)(() =>
                {
                    // Limpiar todas las notificaciones existentes
                    flowPanel.Controls.Clear();

                    // Mostrar las históricas ordenadas por fecha (más antiguas primero)
                    foreach (var notif in historico.OrderBy(n => n.Fecha))
                    {
                        MostrarNotificacionEnUI(notif);
                    }

                    // Asegurarse de que solo tenemos 20 notificaciones
                    while (flowPanel.Controls.Count > 20)
                    {
                        var ultimo = flowPanel.Controls[flowPanel.Controls.Count - 1];
                        flowPanel.Controls.Remove(ultimo);
                        ultimo.Dispose();
                    }
                }));
            }
            catch (Exception ex)
            {
                MostrarError($"Error cargando histórico: {ex.Message}");
            }
        }

        private void MostrarNotificacionEnUI(Notificacion notificacion)
        {
            var flowPanel = this.Tag as FlowLayoutPanel;
            if (flowPanel == null) return;

            bool esNueva = (DateTime.Now - notificacion.Fecha).TotalMinutes <= 2;

            Color colorUsuario;
            if (notificacion.Usuario == "Sistema")
            {
                colorUsuario = Color.Gray;
            }
            else
            {
                if (!_usuarioColores.ContainsKey(notificacion.Usuario))
                {
                    colorUsuario = ObtenerColorParaUsuario(notificacion.Usuario);

                }
                else
                {
                    colorUsuario = _usuarioColores[notificacion.Usuario];
                }
            }

            // Configurar estilos según si es nueva o histórica 
            Color colorTexto = esNueva ? Color.Black : Color.FromArgb(100, 100, 100);
            Color colorFondo = esNueva ? Color.White : Color.FromArgb(250, 250, 250);
            Color colorBorde = esNueva ? colorUsuario : Color.LightGray;
            int grosorBorde = esNueva ? 2 : 1;
            FontStyle estilo = esNueva ? FontStyle.Bold : FontStyle.Regular;

            // Crear el contenedor de la notificación
            Panel pnlNotificacion = new Panel();
            pnlNotificacion.Width = flowPanel.Width - 25; // Ajustar para el scroll
            pnlNotificacion.Height = 70; // Altura fija por notificación
            pnlNotificacion.BackColor = colorFondo;
            pnlNotificacion.Margin = new Padding(0, 0, 0, 5);
            pnlNotificacion.Padding = new Padding(5);

            // Dibujar borde personalizado
            pnlNotificacion.Paint += (sender, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, pnlNotificacion.ClientRectangle,
                           colorBorde, grosorBorde, ButtonBorderStyle.Solid,
                           colorBorde, grosorBorde, ButtonBorderStyle.Solid,
                           colorBorde, grosorBorde, ButtonBorderStyle.Solid,
                           colorBorde, grosorBorde, ButtonBorderStyle.Solid);
            };

            // Avatar usando un Label con carácter Unicode de persona
            Label lblAvatar = new Label();
            lblAvatar.Text = "👤"; // Persona simple
            lblAvatar.Font = new Font("Segoe UI", 12);
            lblAvatar.ForeColor = colorUsuario;
            lblAvatar.Size = new Size(30, 30);
            lblAvatar.Location = new Point(5, 5);
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // Usuario
            Label lblUsuario = new Label();
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(40, 5);
            lblUsuario.Font = new Font("Segoe UI", 9, estilo);
            lblUsuario.ForeColor = colorUsuario;
            lblUsuario.Text = notificacion.Usuario;

            // Fecha y módulo
            Label lblInfo = new Label();
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(40, 25);
            lblInfo.Font = new Font("Segoe UI", 7);
            lblInfo.ForeColor = Color.DimGray;
            lblInfo.Text = $"{notificacion.Fecha:dd/MM/yy HH:mm} [{notificacion.Modulo}]";

            // Mensaje
            Label lblMensaje = new Label();
            lblMensaje.AutoSize = false;
            lblMensaje.Size = new Size(pnlNotificacion.Width - 45, 30);
            lblMensaje.Location = new Point(40, 40);
            lblMensaje.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            lblMensaje.ForeColor = colorTexto;
            lblMensaje.Text = notificacion.Mensaje;

            // Agregar controles al panel
            pnlNotificacion.Controls.Add(lblAvatar);
            pnlNotificacion.Controls.Add(lblUsuario);
            pnlNotificacion.Controls.Add(lblInfo);
            pnlNotificacion.Controls.Add(lblMensaje);

            // Insertar al principio (las nuevas arriba)
            flowPanel.Controls.Add(pnlNotificacion);
            flowPanel.Controls.SetChildIndex(pnlNotificacion, 0);

            // Mantener máximo 20 notificaciones
            while (flowPanel.Controls.Count > 20)
            {
                var ultimo = flowPanel.Controls[flowPanel.Controls.Count - 1];
                flowPanel.Controls.Remove(ultimo);
                ultimo.Dispose();
            }

            // Auto-scroll para nuevas notificaciones
            if (esNueva)
            {
                flowPanel.ScrollControlIntoView(pnlNotificacion);

                // Efecto visual para notificaciones nuevas
                Timer highlightTimer = new Timer();
                highlightTimer.Interval = 100;
                int flashes = 0;
                Color originalColor = pnlNotificacion.BackColor;

                highlightTimer.Tick += (sender, e) =>
                {
                    flashes++;
                    if (flashes <= 3) // Parpadear 3 veces
                    {
                        pnlNotificacion.BackColor = (pnlNotificacion.BackColor == originalColor)
                          ? Color.FromArgb(230, 230, 255)
                          : originalColor;
                    }
                    else
                    {
                        pnlNotificacion.BackColor = originalColor;
                        highlightTimer.Stop();
                        highlightTimer.Dispose();
                    }
                };
                highlightTimer.Start();


            }
        }
        private Color ObtenerColorParaUsuario(string usuario)
        {
            // Para el sistema usamos gris
            if (usuario == "Sistema") return Color.Gray;

            // Si yatenemos color asignado, lo devolvemos
            if (_usuarioColores.TryGetValue(usuario, out Color colorExistente))
            {
                return colorExistente;
            }

            // Generar color consistente basado en hash del usuario
            int hash = usuario.GetHashCode();
            int index = Math.Abs(hash) % _coloresDisponibles.Count;
            Color nuevoColor = _coloresDisponibles[index];

            // Guardar para futuras referencias
            _usuarioColores[usuario] = nuevoColor;

            return nuevoColor;
        }


        private void AgregarNotificacionSistema(string mensaje, string modulo, Color colorSistema)
        {
            var flowPanel = this.Tag as FlowLayoutPanel;
            if (flowPanel == null) return;

            // Crear notificación del sistema
            var notificacion = new Notificacion
            {
                Usuario = "Sistema",
                Mensaje = mensaje,
                Modulo = modulo,
                Fecha = DateTime.Now
            };
            MostrarNotificacionEnUI(notificacion);

        }

        // Sobrecarga para mantener compatibilidad
        private void AgregarNotificacionSistema(string mensaje, Color colorSistema)
        {
            AgregarNotificacionSistema(mensaje, "Sistema", colorSistema);


        }

        private void MostrarError(string mensaje)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AgregarNotificacionSistema(mensaje, Color.Red);
            }));
        }

        private void btnEntradaCompra_Click(object sender, EventArgs e)
        {
            AbrirSeccionCompra();
        }

        private void dgvUrea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (!frmCompraUrea.Created)
            {
                int orden = Convert.ToInt32(dgvUrea.Rows[e.RowIndex].Cells["Orden"].Value);
                frmCompraUrea = new frmCompraUrea(orden);
                frmCompraUrea.ConexComprasUrea = conexMenuUrea;
            }

            cambioColorBotonCompras();
            frmCompraUrea.Show();

            _ = _hubConnection.InvokeAsync("EnviarNotificacion", new Notificacion
            {
                Usuario = _usuarioActual,
                Mensaje = $"Está editando la orden: {dgvUrea.Rows[e.RowIndex].Cells["Orden"].Value}",
                Modulo = "Compras"
            });


        }

        private void btnInventarioUrea_Click(object sender, EventArgs e)
        {
            if (!frmInventarioUrea.Created)
            {
                frmInventarioUrea = new frmInventarioUrea();
                frmInventarioUrea.ConexInventarioUrea = conexMenuUrea;
            }

            btnInventarioUrea.Enabled = false;
            btnInventarioUrea.BackColor = Color.White;

            frmInventarioUrea.FormClosed += (s, args) =>
            {
                btnInventarioUrea.Enabled = true;
                btnInventarioUrea.BackColor = originalColorBtnInventario;
            };

            frmInventarioUrea.Show();

            _ = _hubConnection.InvokeAsync("EnviarNotificacion", new Notificacion
            {
                Usuario = _usuarioActual,
                Mensaje = "Abrió el módulo de Inventario de Urea",
                Modulo = "Inventario"
            });


        }

        private void cambioColorBotonCompras()
        {
            btnEntradaCompra.Enabled = false;
            btnEntradaCompra.BackColor = Color.White;
            btnVales.Enabled = true;
            btnVales.BackColor = originalColorBtnVales;
        }

        private void cambioColorBotonVales()
        {
            btnVales.Enabled = false;
            btnVales.BackColor = Color.White;
            btnEntradaCompra.Enabled = true;
            btnEntradaCompra.BackColor = originalColorBtnEntradaCompra;
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

                dtOrdenes = conexMenuUrea.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaOrdenes " + ex.Message);
            }

            return dtOrdenes;
        }

        private void carga_dgvComprasUrea()
        {
            DataTable dtOrdenes = new DataTable();
            dtOrdenes.Clear();
            dtOrdenes = CargaOrdenes();
            dgvUrea.DataSource = null;
            dgvUrea.Columns.Clear();

            if (dtOrdenes.Rows.Count > 0)
            {
                dgvUrea.DataSource = dtOrdenes;
                dgvUrea.Columns["Orden"].HeaderText = "Orden";
                dgvUrea.Columns["Fecha"].HeaderText = "Fecha";
                dgvUrea.Columns["Estado"].HeaderText = "Estado";
                dgvUrea.Columns["Nombre_Proveedor"].HeaderText = "Proveedor";
                dgvUrea.Columns["Subtotal"].HeaderText = "Subtotal";
                dgvUrea.Columns["Iva"].HeaderText = "IVA";
                dgvUrea.Columns["Total"].HeaderText = "Total";
                dgvUrea.Columns["Factura"].HeaderText = "Factura";
                dgvUrea.Columns["Folio_Fiscal"].HeaderText = "Folio Fiscal";
                dgvUrea.Columns["Tipo_Pago"].HeaderText = "Tipo Pago";
                dgvUrea.Columns["Litros"].HeaderText = "Litros";
                dgvUrea.Columns["Costo"].HeaderText = "Costo";



                // 1. Configuración básica de formato
                FormatColumn("Litros", "N2", DataGridViewContentAlignment.MiddleCenter);
                FormatColumn("Costo", "N2", DataGridViewContentAlignment.MiddleCenter);
                FormatMonetaryColumns();

                // 2. Configuración responsive
                ConfigureResponsiveColumns();

                // 3. Manejo de redimensionamiento
                dgvUrea.SizeChanged += (s, e) => AdjustColumnsForSize();
                AdjustColumnsForSize();
            }
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

        private void AdjustColumnsForSize()
        {
            bool isSmallWindow = dgvUrea.Width < 1000;

            // Ajustar visibilidad de columnas menos importantes
            dgvUrea.Columns["Subtotal"].Visible = !isSmallWindow;
            dgvUrea.Columns["Iva"].Visible = !isSmallWindow;

            if (isSmallWindow)
            {
                dgvUrea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                // Ajustar anchos mínimos para evitar que se compriman demasiado
                dgvUrea.Columns["Nombre_Proveedor"].MinimumWidth = 120;
                dgvUrea.Columns["Folio_Fiscal"].MinimumWidth = 100;
                dgvUrea.Columns["Factura"].MinimumWidth = 80;

                // Ajustar AutoSizeMode para que las columnas visibles se ajusten al contenido
                foreach (DataGridViewColumn column in dgvUrea.Columns)
                {
                    if (column.Visible && column.AutoSizeMode != DataGridViewAutoSizeColumnMode.Fill)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    }
                }
                // Forzar a que las columnas con FillWeight ocupen el espacio restante (si hay)
                if (dgvUrea.Columns["Nombre_Proveedor"].Visible) dgvUrea.Columns["Nombre_Proveedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (dgvUrea.Columns["Folio_Fiscal"].Visible) dgvUrea.Columns["Folio_Fiscal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                dgvUrea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Restablecer anchos mínimos
                dgvUrea.Columns["Nombre_Proveedor"].MinimumWidth = 150;
                dgvUrea.Columns["Folio_Fiscal"].MinimumWidth = 120;
                dgvUrea.Columns["Factura"].MinimumWidth = 100;
            }
        }

        private void SetColumnPriority(string columnName, int width)
        {
            if (dgvUrea.Columns.Contains(columnName))
            {
                dgvUrea.Columns[columnName].Width = width;
                dgvUrea.Columns[columnName].MinimumWidth = width;
                dgvUrea.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }

        private void SetFillWeightColumn(string columnName, int fillWeight)
        {
            if (dgvUrea.Columns.Contains(columnName))
            {
                dgvUrea.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvUrea.Columns[columnName].FillWeight = fillWeight;
                dgvUrea.Columns[columnName].MinimumWidth = 50; // Asegurar un ancho mínimo
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

        private void FormatColumn(string columnName, string format, DataGridViewContentAlignment alignment)
        {
            if (dgvUrea.Columns.Contains(columnName))
            {
                dgvUrea.Columns[columnName].DefaultCellStyle.Format = format;
                dgvUrea.Columns[columnName].DefaultCellStyle.Alignment = alignment;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (_hubConnection?.State == HubConnectionState.Connected)
            {
                _hubConnection.StopAsync().Wait(1000);
                _hubConnection.DisposeAsync().AsTask().Wait(1000);
            }

            notifyIcon?.Dispose();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            if (!frmProveedores.Created)
            {
                frmProveedores = new frmProveedores();
                frmProveedores.ConexProveedor = conexMenuUrea;
            }

            // Indica al formulario que debe filtrar los proveedores por la línea 21
            frmProveedores.FiltrarPorLinea(21);

            // Indica al formulario que debe filtrar las líneas del ComboBox para mostrar solo Urea
            frmProveedores.FiltrarLineasUrea = true;

            btnProveedores.Enabled = false;
            btnProveedores.BackColor = Color.White;

            frmProveedores.FormClosed += (s, args) =>
            {
                btnProveedores.Enabled = true;
                btnProveedores.BackColor = originalColorBtnInventario;

                // Restablecer la propiedad para la próxima vez que se abra el formulario
                frmProveedores.FiltrarLineasUrea = false;
            };

            frmProveedores.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (!frmReportesUrea.Created || frmReportesUrea.IsDisposed)
            {
                frmReportesUrea = new frmReportesUrea();
                frmReportesUrea.conexReportesUrea = conexMenuUrea; // Asignar la conexión ANTES de ShowDialog()
                frmReportesUrea.HubConnection = _hubConnection; // Pasar la conexión
                frmReportesUrea.UsuarioActual = _usuarioActual;
            }
            btnReportes.Enabled = false;
            btnReportes.BackColor = Color.White;
            frmReportesUrea.FormClosed += (s, args) =>
            {
                btnReportes.Enabled = true;
                btnReportes.BackColor = originalColorBtnReportes;
            };
            _ = _hubConnection.InvokeAsync("EnviarNotificacion", new Notificacion
            {
                Usuario = _usuarioActual,
                Mensaje = "Abrió el módulo de Resportes de Urea",
                Modulo = "Reportes"
            });
            frmReportesUrea.Show();
        }
        //metodo para actualizar los totales de urea diarios en la interfaz de usuario
        private void ActualizarTotalesUreaDiariosUI()
        {
            var totales = ObtenerTotalesUreaDiarios();
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    lblTotalLitrosDiario.Text = $" {totales["TotalLitrosDiario"]:N2} Lts";
                    lblTotalCostoDiario.Text = $"${totales["TotalCostoDiario"]:N2}";
                }));
            }
            else
            {
                lblTotalLitrosDiario.Text = $"{totales["TotalLitrosDiario"]:N2} Lts";
                lblTotalCostoDiario.Text = $"${totales["TotalCostoDiario"]:N2}";
            }
        }
        //metodo para obtener los totales de urea diarios
        private Dictionary<string, decimal> ObtenerTotalesUreaDiarios()
        {
            string query = @"
                SELECT
                    ROUND(SUM(nLitrosDespachados), 2) AS TotalLitrosDiario,
                    ROUND(SUM(nLitrosDespachados * 20), 2) AS TotalCostoDiario
                FROM dbUrea.dbo.tbDespUrea
                WHERE CONVERT(date, dtFecReg) = CONVERT(date, GETDATE());";
            DataTable data = conexMenuUrea.select(query);
            var totales = new Dictionary<string, decimal>
            {
                { "TotalLitrosDiario", 0m },
                { "TotalCostoDiario", 0m }
            };
            if (data != null && data.Rows.Count > 0)
            {
                if (data.Rows[0]["TotalLitrosDiario"] != DBNull.Value)
                    totales["TotalLitrosDiario"] = Convert.ToDecimal(data.Rows[0]["TotalLitrosDiario"]);
                if (data.Rows[0]["TotalCostoDiario"] != DBNull.Value)
                    totales["TotalCostoDiario"] = Convert.ToDecimal(data.Rows[0]["TotalCostoDiario"]);
            }
            return totales;
        }
        //metodo para actualizar los totales de urea mensuales en la interfaz de usuario
        private void ActualizarTotalesUreaMensualesUI()
        {
            var totales = ObtenerTotalesUreaMensuales();
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    lblTotalLitrosMes.Text = $" {totales["TotalLitrosMes"]:N2} Lts";
                    lblTotalCostoMes.Text = $"${totales["TotalCostoMes"]:N2}";
                }));
            }
            else
            {
                lblTotalLitrosMes.Text = $"{totales["TotalLitrosMes"]:N2} Lts";
                lblTotalCostoMes.Text = $"${totales["TotalCostoMes"]:N2}";
            }
        }
        //metodo para obtener los totales de urea mensuales
        private Dictionary<string, decimal> ObtenerTotalesUreaMensuales()
        {
            string query = @"
                SELECT
                    ROUND(SUM(nLitrosDespachados), 2) AS TotalLitrosMes,
                    ROUND(SUM(nLitrosDespachados * 20), 2) AS TotalCostoMes
                FROM dbUrea.dbo.tbDespUrea
                WHERE YEAR(dtFecReg) = YEAR(GETDATE())
                  AND MONTH(dtFecReg) = MONTH(GETDATE());";
            DataTable data = conexMenuUrea.select(query);
            var totales = new Dictionary<string, decimal>
            {
                { "TotalLitrosMes", 0m },
                { "TotalCostoMes", 0m }
            };
            if (data != null && data.Rows.Count > 0)
            {
                if (data.Rows[0]["TotalLitrosMes"] != DBNull.Value)
                    totales["TotalLitrosMes"] = Convert.ToDecimal(data.Rows[0]["TotalLitrosMes"]);
                if (data.Rows[0]["TotalCostoMes"] != DBNull.Value)
                    totales["TotalCostoMes"] = Convert.ToDecimal(data.Rows[0]["TotalCostoMes"]);
            }
            return totales;
        }

        private void ActualizarTotalesComprasDiariosUI()
        {
            var totales = ObtenerTotalesComprasDiarios();
            if (totales["SinRegistros"] == 1m)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        lblTotalLitrosDiarioC.Text = $"{totales["TotalLitrosCompradosDiario"]:N2} Lts";
                        lblTotalCostoDiarioC.Text = $"${totales["TotalComprasDiario"]:N2}";
                    }));
                }
                else
                {
                    lblTotalLitrosDiarioC.Text = $"{totales["TotalLitrosCompradosDiario"]:N2} Lts";
                    lblTotalCostoDiarioC.Text = $"${totales["TotalComprasDiario"]:N2}";
                }
                return;
            }
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    lblTotalCostoDiarioC.Text = $"${totales["TotalComprasDiario"]:N2}";
                    lblTotalLitrosDiarioC.Text = $"{totales["TotalLitrosCompradosDiario"]:N2} Lts";
                }));
            }
            else
            {
                lblTotalCostoDiarioC.Text = $"${totales["TotalComprasDiario"]:N2}";
                lblTotalLitrosDiarioC.Text = $"{totales["TotalLitrosCompradosDiario"]:N2} Lts";
            }
        }

        private Dictionary<string, decimal> ObtenerTotalesComprasDiarios()
        {
            string query = @"
                SELECT
                    SUM(nTotOrd) AS TotalComprasDiario,
                    SUM(nLtsOrd) AS TotalLitrosCompradosDiario
                FROM dbUrea.dbo.tbOrden
                WHERE CONVERT(date, dFecOrd) = CONVERT(date, GETDATE());";
            DataTable data = conexMenuUrea.select(query);
            var totales = new Dictionary<string, decimal>
            {
                { "TotalComprasDiario", 0m },
                { "TotalLitrosCompradosDiario", 0m },
                { "SinRegistros", 0m }
            };
            if (data == null || data.Rows.Count == 0 ||
                (data.Rows[0]["TotalComprasDiario"] == DBNull.Value &&
                 data.Rows[0]["TotalLitrosCompradosDiario"] == DBNull.Value))
            {
                totales["SinRegistros"] = 1m;
                return totales;
            }
            if (data.Rows[0]["TotalComprasDiario"] != DBNull.Value)
                totales["TotalComprasDiario"] = Convert.ToDecimal(data.Rows[0]["TotalComprasDiario"]);
            if (data.Rows[0]["TotalLitrosCompradosDiario"] != DBNull.Value)
                totales["TotalLitrosCompradosDiario"] = Convert.ToDecimal(data.Rows[0]["TotalLitrosCompradosDiario"]);
            return totales;
        }

        private void ActualizarTotalesComprasMensualesUI()
        {
            var totales = ObtenerTotalesComprasMensuales();
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    lblTotalCostoMesC.Text = $"${totales["TotalComprasMes"]:N2}";
                    lblTotalLitrosMesC.Text = $"{totales["TotalLitrosCompradosMes"]:N2} Lts";
                }));
            }
            else
            {
                lblTotalCostoMesC.Text = $"${totales["TotalComprasMes"]:N2}";
                lblTotalLitrosMesC.Text = $"{totales["TotalLitrosCompradosMes"]:N2} Lts";
            }
        }

        private Dictionary<string, decimal> ObtenerTotalesComprasMensuales()
        {
            string query = @"
                SELECT
                    SUM(nTotOrd) AS TotalComprasMes,
                    SUM(nLtsOrd) AS TotalLitrosCompradosMes
                FROM dbUrea.dbo.tbOrden
                WHERE YEAR(dFecOrd) = YEAR(GETDATE())
                  AND MONTH(dFecOrd) = MONTH(GETDATE());";
            DataTable data = conexMenuUrea.select(query);
            var totales = new Dictionary<string, decimal>
            {
                { "TotalComprasMes", 0m },
                { "TotalLitrosCompradosMes", 0m }
            };
            if (data != null && data.Rows.Count > 0)
            {
                if (data.Rows[0]["TotalComprasMes"] != DBNull.Value)
                    totales["TotalComprasMes"] = Convert.ToDecimal(data.Rows[0]["TotalComprasMes"]);
                if (data.Rows[0]["TotalLitrosCompradosMes"] != DBNull.Value)
                    totales["TotalLitrosCompradosMes"] = Convert.ToDecimal(data.Rows[0]["TotalLitrosCompradosMes"]);
            }
            return totales;
        }
        private void btnVales_Click(object sender, EventArgs e)
        {
            AbrirSeccionVales();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotalLitrosDiarioC_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
