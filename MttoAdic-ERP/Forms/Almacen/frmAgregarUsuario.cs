using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MttoAdic_ERP; // Asegúrate de que este namespace contenga tu clase csConexionSQL
using MttoAdic_ERP.Models; // Si GlobalVariables está en Models

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmAgregarUsuario : MetroForm
    {
        // La instancia de la conexión SQL debe venir de GlobalVariables
        private csConexionSQL Conex;
        // Diccionario para mapear el texto visible a su valor numérico
        private Dictionary<string, int> nivelUsuarioMapping;
        private bool isDragging = false; // Indica si el arrastre está activo
        private Point lastCursorPos;

        public bool IsConnectionValid { get; private set; }
        public frmAgregarUsuario()
        {
            InitializeComponent();
            cboNivelUsuario.AllowNewText = false;
            if (GlobalVariables.ConexionSQL != null)
            {
                this.Conex = GlobalVariables.ConexionSQL;
                this.IsConnectionValid = true; // Connection is valid
            }
            else
            {
                // Set flag to false and show message. The form will NOT close itself here.
                MessageBox.Show("No se pudo obtener la conexión a la base de datos. Asegúrese de haber iniciado sesión en el formulario principal.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.IsConnectionValid = false; // Connection is not valid
                                                // Do NOT call this.Close() here
                                                // Instead, the calling form (frmLoginUrea) will decide what to do
            }
            // Inicializa el diccionario en el constructor
            nivelUsuarioMapping = new Dictionary<string, int>();
            CargarNivelesUsuario();
            if (this.IsConnectionValid && cboNivelUsuario.Items.Count > 0)
            {
                cboNivelUsuario.SelectedIndex = 0;
            }

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
        private void CargarNivelesUsuario()
        {
            // Limpia el ComboBox y el diccionario por si se llama más de una vez
            cboNivelUsuario.Items.Clear();
            nivelUsuarioMapping.Clear();

            // Añade los elementos al ComboBox y al diccionario
            // Asegúrate de que los valores numéricos coincidan con tu base de datos

            nivelUsuarioMapping.Add("Almacen", 5);
            cboNivelUsuario.Items.Add("Almacen");

            nivelUsuarioMapping.Add("Urea", 1);
            cboNivelUsuario.Items.Add("Urea");


            // Agrega todos los demás niveles que necesites
        }
        private void frmAgregarUsuario_Load(object sender, EventArgs e)
        {
            // Cualquier lógica de carga inicial para el formulario
        }




        private void btnVolverLogin_Click(object sender, EventArgs e)
        {
            // Establece el DialogResult para indicar que el usuario quiere volver al login
            this.DialogResult = DialogResult.Cancel; // O cualquier otro DialogResult que no sea OK
            this.Close(); // Cierra el formulario de registro
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // 1. Validación de campos
            if (string.IsNullOrWhiteSpace(loginTextbox1.Text) || // cClaveEmpleado
                string.IsNullOrWhiteSpace(loginTextbox2.Text) || // cUsuario
                string.IsNullOrWhiteSpace(loginTextbox3.Text) || // cClaveUsuario
                cboNivelUsuario.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, rellene la información.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener los valores de los controles
            string cClaveEmpleado = loginTextbox1.Text.Trim();
            string cUsuario = loginTextbox3.Text.Trim();
            string cClaveUsuario = loginTextbox2.Text.Trim(); // Contraseña del usuario

            int nNivelUsuario;

            string selectedLevelText = cboNivelUsuario.SelectedItem.ToString();
            // Obtener el valor numérico del diccionario usando el texto seleccionado
            if (nivelUsuarioMapping.ContainsKey(selectedLevelText))
            {
                nNivelUsuario = nivelUsuarioMapping[selectedLevelText];
            }
            else
            {
                // Esto no debería ocurrir si llenas el diccionario y el ComboBox juntos
                MessageBox.Show("Error: El nivel de usuario seleccionado no se encuentra en la lista de mapeo.", "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string query = $"INSERT INTO tbUsuarios (cClaveEmpleado, cUsuario, cClaveUsuario, nNivelUsuario) VALUES ('{cClaveEmpleado}', '{cUsuario}', '{cClaveUsuario}', {nNivelUsuario})";

            try
            {
                // 4. Ejecutar la sentencia SQL usando ejecSql
                // ejecSql devuelve true si la operación fue exitosa, false en caso contrario
                bool registroExitoso = Conex.ejecSql(query);

                if (registroExitoso)
                {
                    MessageBox.Show("Usuario registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // 5. Limpiar los campos después de un registro exitoso
                    loginTextbox1.Text = string.Empty;
                    loginTextbox2.Text = string.Empty;
                    loginTextbox3.Text = string.Empty;
                    cboNivelUsuario.SelectedIndex = 0; // Restablecer a la primera opción
                    loginTextbox1.Focus(); // Pone el foco en el primer campo
                    this.DialogResult = DialogResult.OK; // Establece el resultado del diálogo a OK
                    this.Close(); // Cierra frmAgregarUsuario
                }
                else
                {
                    // ejecSql ya muestra un MessageBox si hay un error SQL,
                    // pero este else se activa si ejecSql retorna false por alguna razón.
                    MessageBox.Show("No se pudo registrar el usuario. Verifique los datos e inténtelo de nuevo.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Este catch manejaría cualquier error que no haya sido capturado por ejecSql
                MessageBox.Show($"Ocurrió un error inesperado al registrar el usuario: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario al hacer clic en la etiqueta
        }

        private void panelPersonalizado1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}