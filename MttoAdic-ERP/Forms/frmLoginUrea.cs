using MttoAdic_ERP.Forms.Almacen;
using MttoAdic_ERP.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MttoAdic_ERP.Forms
{
    public partial class frmLoginUrea : Form
    {
        csConexionSQL Conex;
        private bool isDragging = false; // Indica si el arrastre está activo
        private Point lastCursorPos;

        public frmLoginUrea()
        {
            InitializeComponent();

            this.Conex = new csConexionSQL("cadic.ddns.net", "dbAlmacen", "xhodaraoz", "XmaiN16xDt@@MA");

            // *** LÍNEA CRUCIAL: ASIGNAR LA CONEXIÓN A LA VARIABLE GLOBAL AQUÍ ***
            // Esto asegura que GlobalVariables.ConexionSQL esté disponible tan pronto como el formulario de login se inicializa.
            GlobalVariables.ConexionSQL = this.Conex;

            // Opcional: Puedes dejar las líneas de depuración que te sugerí anteriormente para confirmar esto.
            // if (this.Conex == null) { MessageBox.Show("... this.Conex es NULL ..."); }
            // if (GlobalVariables.ConexionSQL == null) { MessageBox.Show("... GlobalVariables.ConexionSQL es NULL ..."); }


            this.FormClosing += new FormClosingEventHandler(this.frmLoginUrea_FormClosing);
            this.panelPersonalizado1.MouseDown += new MouseEventHandler(this.panelPersonalizado1_MouseDown);
            this.panelPersonalizado1.MouseMove += new MouseEventHandler(this.panelPersonalizado1_MouseMove);
            this.panelPersonalizado1.MouseUp += new MouseEventHandler(this.panelPersonalizado1_MouseUp);
            this.pictureBox3.MouseDown += new MouseEventHandler(this.panelPersonalizado1_MouseDown);
            this.pictureBox3.MouseMove += new MouseEventHandler(this.panelPersonalizado1_MouseMove);
            this.pictureBox3.MouseUp += new MouseEventHandler(this.panelPersonalizado1_MouseUp);
            this.panelLogin2.MouseDown += new MouseEventHandler(this.panelPersonalizado1_MouseDown);
            this.panelLogin2.MouseMove += new MouseEventHandler(this.panelPersonalizado1_MouseMove);
            this.panelLogin2.MouseUp += new MouseEventHandler(this.panelPersonalizado1_MouseUp);
        }

        private void frmLoginUrea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void panelPersonalizado1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Solo si es el botón izquierdo del ratón
            {
                isDragging = true; // Activa el modo de arrastre
                lastCursorPos = new Point(e.X, e.Y); // Guarda la posición inicial del cursor dentro del panel
            }
        }

        private void panelPersonalizado1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging) // Si el arrastre está activo
            {
                // Calcula el desplazamiento del ratón desde la última posición
                int dx = e.X - lastCursorPos.X;
                int dy = e.Y - lastCursorPos.Y;

                // Mueve la posición del formulario
                this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
            }
        }

        private void panelPersonalizado1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; // Desactiva el modo de arrastre
        }

        private void colorPickerButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = loginTextbox1.Text.Trim();
            string password = loginTextbox2.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese el nombre de usuario y la contraseña.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultadoLogin = Conex.ValidarCredenciales(usuario, password);

            if (resultadoLogin.IsValid)
            {
                MessageBox.Show($"Bienvenido, {resultadoLogin.cUsuario}!", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GlobalVariables.NivelAcceso = resultadoLogin.NivelUsuario;
                GlobalVariables.ClaveEmpleado = resultadoLogin.ClaveEmpleado;
                GlobalVariables.UsuarioLogueado = resultadoLogin.cUsuario;
                // La siguiente línea ya no es necesaria aquí, ya que se asigna en el constructor.
                // GlobalVariables.ConexionSQL = this.Conex;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Por favor, verifique sus credenciales e inténtelo de nuevo.", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loginTextbox1.Text = string.Empty;
                loginTextbox2.Text = string.Empty;
                loginTextbox1.Focus();
            }
        }

        private void frmLoginUrea_Load_1(object sender, EventArgs e)
        {
            loginTextbox1.Text = string.Empty;
            loginTextbox2.Text = string.Empty;
            loginTextbox2.Focus();
        }

        private void panelPersonalizado1_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // En frmLoginUrea.cs
        private void lbRegistrarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                frmAgregarUsuario formRegistro = new frmAgregarUsuario();

                if (formRegistro.IsConnectionValid)
                {
                    this.Hide(); // Oculta el formulario de login

                    // Muestra el formulario de registro. El código de aquí abajo no se ejecutará hasta que formRegistro se cierre.
                    DialogResult registroResult = formRegistro.ShowDialog();

                    if (registroResult == DialogResult.OK)
                    {
                       
                        this.Show(); // Vuelve a mostrar el login si el registro fue exitoso o cancelado.
                    }
                    else
                    {
                        // Si el formulario de registro fue cerrado sin DialogResult.OK (ej. por la X o Cancelar)
                        this.Show(); // Vuelve a mostrar el login
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar abrir el formulario de registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show(); // Si ocurre un error, asegúrate de que el login vuelva a aparecer
            }
        }
    }
}