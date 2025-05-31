#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using MttoAdic_ERP.Forms.Almacen.Productos;
using NavigationDrawTile;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Controls;
using System.Runtime.InteropServices;
using MttoAdic_ERP.Models;
using System;
using MttoAdic_ERP.Forms.Almacen;
using System.Windows.Forms; // Required for MessageBox and Form.ShowDialog()
using System.Drawing; // Required for Color, Rectangle, Size

namespace MttoAdic_ERP.Forms
{
    public partial class MainForm : SfForm
    {
        [DllImport("user32.dll")]
        static extern bool LockWindowUpdate(IntPtr hWndLock);

        Panel inboxPanel = new Panel();
        Panel profilePanel = new Panel();

        int rowIndex = 0;
        Rectangle closeImageRect = new Rectangle();
        Rectangle flagImageRect = new Rectangle();
        int firstrowHeight = 25;
        int secondrowHeight = 20;
        int thirdrowHeight = 15;
        object mouseHoverItemData = null;
        TileControl profile1 = new TileControl();


        frmMenuReporteador frmMenuReporteador;
        frmMenuAlmacen frmMenuAlmacen;
        frmProductosIndex frmProductosIndex;
        frmMenuUrea frmMenuUrea;
        frmAgregarUsuario frmAgregarUsuario;

        // La conexión SQL la obtendremos de GlobalVariables
        csConexionSQL Conex;

        // Variables para almacenar el usuario y la conexión obtenidos de GlobalVariables
        private string _usuarioLogueado;
        private csConexionSQL _conexionSQL;

        public MainForm()
        {
            InitializeComponent();

            this.MinimumSize = new Size(795, 615);
            var filter = navigationDrawer1.GetType().GetField("filter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            dynamic navigationDrawerMouseMessageFilter = filter.GetValue(navigationDrawer1);
            NavigationDrawerMouseMessageFilter MouseMessageFilter = navigationDrawerMouseMessageFilter;
            Application.RemoveMessageFilter(MouseMessageFilter);

            if (this.navigationDrawer1.Items[0] is DrawerHeader)
            {
                (this.navigationDrawer1.Items[0] as DrawerHeader).HeaderImage = this.imageListAdv1.Images[1];
                (this.navigationDrawer1.Items[0] as DrawerHeader).HeaderText = "Sistemas";
            }
            inboxPanel.Dock = DockStyle.Fill;
            this.navigationDrawer1.ContentViewContainer.Controls.Add(inboxPanel);
            this.navigationDrawer1.ContentViewContainer.Controls.Add(profilePanel);
            this.profilePanel.Dock = DockStyle.Fill;
            this.profilePanel.BackColor = Color.Red;
            if (this.navigationDrawer1.Items[0] is DrawerHeader)
            {
                (this.navigationDrawer1.Items[0] as DrawerHeader).TextAlign = TextAlignment.Center;
            }
            this.navigationDrawer1.DrawerPanelContainer.BorderStyle = BorderStyle.None;
            this.navigationDrawer1.TouchThreshold = 500;

            AddControlsInProfilePanel();
            this.navigationDrawer1.DrawerHeight = this.navigationDrawer1.DisplayRectangle.Height;
            this.SizeChanged += MainForm_SizeChanged;
            SkinManager.SetVisualStyle(this, "Office2019Colorful");
            this.gradientPanel1.ThemeStyle.BackColor = Color.White;
            this.gradientPanel1.BorderColor = Color.FromArgb(210, 210, 210);
            this.gradientPanel1.BorderStyle = BorderStyle.None;


            _usuarioLogueado = GlobalVariables.UsuarioLogueado;
            _conexionSQL = GlobalVariables.ConexionSQL; // Asigna la conexión de GlobalVariables
            this.Conex = _conexionSQL; // Asigna también a la variable Conex de MainForm

            // Ocultar todos los ítems del menú por defecto
            if (dmiReporteador != null) dmiReporteador.Visible = false;
            if (dmiAlmacen != null) dmiAlmacen.Visible = false;
            if (dmiDiesel != null) dmiDiesel.Visible = false;
            if (dmiExternos != null) dmiExternos.Visible = false;
            if (dmiLlantas != null) dmiLlantas.Visible = false;
            if (dmiMantenimiento != null) dmiMantenimiento.Visible = false;
            if (dmiUrea != null) dmiUrea.Visible = false;
            if (dmiUsuarios != null) dmiUsuarios.Visible = false;

            // Ahora, aplica la lógica según el nivel de acceso
            switch (GlobalVariables.NivelAcceso)
            {
                case 5: // Nivel de Administrador
                    // Habilitar todas las opciones
                    if (dmiReporteador != null) dmiReporteador.Visible = true;
                    if (dmiAlmacen != null) dmiAlmacen.Visible = true;
                    if (dmiUrea != null) dmiUrea.Visible = true;
                    if (dmiDiesel != null) dmiDiesel.Visible = true;
                    if (dmiExternos != null) dmiExternos.Visible = true;
                    if (dmiLlantas != null) dmiLlantas.Visible = true;
                    if (dmiMantenimiento != null) dmiMantenimiento.Visible = true;
                    if (dmiUsuarios != null) dmiUsuarios.Visible = true; // Asegúrate de que este ítem exista

                    // Iniciar en el formulario de Almacén para administradores
                    dmiAlmacen_Click(dmiAlmacen, EventArgs.Empty);
                    break;

                case 1: // Nivel de Usuario Básico (ej. Solo Urea)
                    // Solo habilitar la opción de Urea
                    if (dmiUrea != null) dmiUrea.Visible = true;

                    // Iniciar en el formulario de Urea para usuarios de nivel 1
                    dmiUrea_Click(dmiUrea, EventArgs.Empty);
                    break;

                default: // Otros niveles
                    MessageBox.Show($"Nivel de acceso '{GlobalVariables.NivelAcceso}' no tiene configurado un perfil específico. Acceso limitado.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dmiInicio != null) dmiInicio.Visible = true;
                    dmiInicio_Click(dmiInicio, EventArgs.Empty);
                    break;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            this.navigationDrawer1.DrawerHeight = this.navigationDrawer1.DisplayRectangle.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.navigationDrawer1.ToggleDrawer();
        }

        public void AddControlsInProfilePanel()
        {
            profile1.HeaderText = "Bienvenido"; // Puedes cambiar esto para mostrar el usuario logueado
            profile1.TileImage = this.imageListAdv1.Images[1];
            profile1.PostionText = GlobalVariables.UsuarioLogueado; // Mostrar el usuario logueado aquí
            profile1.OrganizatonText = ""; // Puedes rellenar con datos del usuario si los tienes
            profile1.DOBText = "";
            profile1.LocationText = "";
            profile1.Height = 300;
            profile1.Dock = DockStyle.Top;
            profilePanel.Controls.Add(profile1);
            profilePanel.AutoScroll = true;
        }

        private void dmiReporteador_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            this.label7.Text = "Reporteador";
            this.profilePanel.Visible = false;
            this.inboxPanel.Visible = true;
            this.navigationDrawer1.ToggleDrawer();
            if (frmMenuReporteador == null || frmMenuReporteador.IsDisposed) // Verifica si es null o ya fue dispuesto
            {
                frmMenuReporteador = new frmMenuReporteador();

                frmMenuReporteador.TopLevel = false;
                inboxPanel.Controls.Add(frmMenuReporteador);
                frmMenuReporteador.Dock = DockStyle.Fill;
                frmMenuReporteador.Show();
                // Limpiar otros formularios
                if (inboxPanel.Controls.Contains(frmMenuAlmacen)) { inboxPanel.Controls.Remove(frmMenuAlmacen); frmMenuAlmacen.Dispose(); }
                if (inboxPanel.Controls.Contains(frmProductosIndex)) { inboxPanel.Controls.Remove(frmProductosIndex); frmProductosIndex.Dispose(); }
                if (inboxPanel.Controls.Contains(frmMenuUrea)) { inboxPanel.Controls.Remove(frmMenuUrea); frmMenuUrea.Dispose(); }
                LockWindowUpdate(IntPtr.Zero);
            }
        }


        private void dmiAlmacen_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            this.label7.Text = "Almacen";
            this.profilePanel.Visible = false;
            this.inboxPanel.Visible = true;
            this.navigationDrawer1.ToggleDrawer();
            if (frmMenuAlmacen == null || frmMenuAlmacen.IsDisposed)
            {
                frmMenuAlmacen = new frmMenuAlmacen();
                frmMenuAlmacen.ConexMenuAlmacen = _conexionSQL;

            }
            frmMenuAlmacen.TopLevel = false;
            inboxPanel.Controls.Add(frmMenuAlmacen);
            frmMenuAlmacen.Dock = DockStyle.Fill;
            frmMenuAlmacen.Show();
            // Limpiar otros formularios
            if (inboxPanel.Controls.Contains(frmMenuReporteador)) { inboxPanel.Controls.Remove(frmMenuReporteador); frmMenuReporteador.Dispose(); }
            if (inboxPanel.Controls.Contains(frmProductosIndex)) { inboxPanel.Controls.Remove(frmProductosIndex); frmProductosIndex.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuUrea)) { inboxPanel.Controls.Remove(frmMenuUrea); frmMenuUrea.Dispose(); }
            LockWindowUpdate(IntPtr.Zero);
        }

        private void dmiUrea_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            this.label7.Text = "Urea";
            this.profilePanel.Visible = false;
            this.inboxPanel.Visible = true;
            this.navigationDrawer1.ToggleDrawer();
            if (frmMenuUrea == null || frmMenuUrea.IsDisposed) // Verifica si es null o ya fue dispuesto
            {

                frmMenuUrea = new frmMenuUrea(_usuarioLogueado, _conexionSQL);
            }
            frmMenuUrea.TopLevel = false;
            inboxPanel.Controls.Add(frmMenuUrea);
            frmMenuUrea.Dock = DockStyle.Fill;
            frmMenuUrea.Show();
            // Limpiar otros formularios
            if (inboxPanel.Controls.Contains(frmMenuReporteador)) { inboxPanel.Controls.Remove(frmMenuReporteador); frmMenuReporteador.Dispose(); }
            if (inboxPanel.Controls.Contains(frmProductosIndex)) { inboxPanel.Controls.Remove(frmProductosIndex); frmProductosIndex.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuAlmacen)) { inboxPanel.Controls.Remove(frmMenuAlmacen); frmMenuAlmacen.Dispose(); }
            LockWindowUpdate(IntPtr.Zero);
        }

        private void dmiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dmiDiesel_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            this.label7.Text = "Diesel";
            this.navigationDrawer1.ToggleDrawer();
            // Limpiar otros formularios
            if (inboxPanel.Controls.Contains(frmMenuReporteador)) { inboxPanel.Controls.Remove(frmMenuReporteador); frmMenuReporteador.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuAlmacen)) { inboxPanel.Controls.Remove(frmMenuAlmacen); frmMenuAlmacen.Dispose(); }
            if (inboxPanel.Controls.Contains(frmProductosIndex)) { inboxPanel.Controls.Remove(frmProductosIndex); frmProductosIndex.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuUrea)) { inboxPanel.Controls.Remove(frmMenuUrea); frmMenuUrea.Dispose(); }
            LockWindowUpdate(IntPtr.Zero);
        }

        private void dmiExternos_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            this.label7.Text = "Servicios Externos";
            this.navigationDrawer1.ToggleDrawer();

            if (frmProductosIndex == null || frmProductosIndex.IsDisposed)
            {
                frmProductosIndex = new frmProductosIndex();
                frmProductosIndex.ConexMetroProductos = _conexionSQL; // Pasa la conexión
                                                                      // Si frmProductosIndex necesita el usuario, pásalo aquí
                                                                      // frmProductosIndex.UsuarioActual = _usuarioLogueado;
            }
            frmProductosIndex.TopLevel = false;
            inboxPanel.Controls.Add(frmProductosIndex);
            frmProductosIndex.Dock = DockStyle.Fill;
            frmProductosIndex.Show();

            // Limpiar otros formularios
            if (inboxPanel.Controls.Contains(frmMenuReporteador)) { inboxPanel.Controls.Remove(frmMenuReporteador); frmMenuReporteador.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuAlmacen)) { inboxPanel.Controls.Remove(frmMenuAlmacen); frmMenuAlmacen.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuUrea)) { inboxPanel.Controls.Remove(frmMenuUrea); frmMenuUrea.Dispose(); }
            LockWindowUpdate(IntPtr.Zero);
        }

        private void dmiInicio_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            this.label7.Text = "Menu Principal";
            this.navigationDrawer1.ToggleDrawer();
            // Limpiar otros formularios
            if (inboxPanel.Controls.Contains(frmMenuReporteador)) { inboxPanel.Controls.Remove(frmMenuReporteador); frmMenuReporteador.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuAlmacen)) { inboxPanel.Controls.Remove(frmMenuAlmacen); frmMenuAlmacen.Dispose(); }
            if (inboxPanel.Controls.Contains(frmProductosIndex)) { inboxPanel.Controls.Remove(frmProductosIndex); frmProductosIndex.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuUrea)) { inboxPanel.Controls.Remove(frmMenuUrea); frmMenuUrea.Dispose(); }

            LockWindowUpdate(IntPtr.Zero);
        }

        private void dmiLlantas_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            this.label7.Text = "Llantas";
            this.navigationDrawer1.ToggleDrawer();
            // Limpiar otros formularios
            if (inboxPanel.Controls.Contains(frmMenuReporteador)) { inboxPanel.Controls.Remove(frmMenuReporteador); frmMenuReporteador.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuAlmacen)) { inboxPanel.Controls.Remove(frmMenuAlmacen); frmMenuAlmacen.Dispose(); }
            if (inboxPanel.Controls.Contains(frmProductosIndex)) { inboxPanel.Controls.Remove(frmProductosIndex); frmProductosIndex.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuUrea)) { inboxPanel.Controls.Remove(frmMenuUrea); frmMenuUrea.Dispose(); }

            LockWindowUpdate(IntPtr.Zero);
        }

        private void dmiMantenimiento_Click(object sender, EventArgs e)
        {
            LockWindowUpdate(this.navigationDrawer1.ContentViewContainer.Handle);
            this.label7.Text = "Mantenimiento";
            this.navigationDrawer1.ToggleDrawer();
            // Limpiar otros formularios
            if (inboxPanel.Controls.Contains(frmMenuReporteador)) { inboxPanel.Controls.Remove(frmMenuReporteador); frmMenuReporteador.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuAlmacen)) { inboxPanel.Controls.Remove(frmMenuAlmacen); frmMenuAlmacen.Dispose(); }
            if (inboxPanel.Controls.Contains(frmProductosIndex)) { inboxPanel.Controls.Remove(frmProductosIndex); frmProductosIndex.Dispose(); }
            if (inboxPanel.Controls.Contains(frmMenuUrea)) { inboxPanel.Controls.Remove(frmMenuUrea); frmMenuUrea.Dispose(); }

            LockWindowUpdate(IntPtr.Zero);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(_usuarioLogueado))
            {
                profile1.HeaderText = "Bienvenido";
                profile1.PostionText = _usuarioLogueado;
            }
        }

        private void navigationDrawer1_Click(object sender, EventArgs e) { }


        private void dmiUsuarios_Click(object sender, EventArgs e)
        {
            // Toggle the navigation drawer. If it's open, this will close it.
            // If it's closed, this will open it (but we don't necessarily want it to open
            // if we're immediately opening a modal form).
            // It's often better to just call ToggleDrawer() once to ensure it's closed
            // before showing a modal dialog.
            this.navigationDrawer1.ToggleDrawer();

            // Create a new instance of the form if it doesn't exist or is disposed
            if (frmAgregarUsuario == null || frmAgregarUsuario.IsDisposed)
            {
                frmAgregarUsuario = new frmAgregarUsuario();
            }

            // Show the form as a modal dialog
            frmAgregarUsuario.ShowDialog();

            // The code after ShowDialog() will only execute after the modal form is closed.
            // You might want to refresh data or perform other actions here if needed.
        }

    }
}