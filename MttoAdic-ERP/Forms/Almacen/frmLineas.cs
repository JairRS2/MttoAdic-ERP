using Syncfusion.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmLineas : MetroForm
    {
        string SQL = string.Empty;
        public csConexionSQL conexLineas;

        private Color originalColorBtnNuevo = Color.FromArgb(0, 120, 215);
        private Color originalColorBtnSalir = Color.FromArgb(220, 53, 69);
        private Color originalColorBtnGrabar = Color.FromArgb(40, 167, 69);
        private Color originalColorBtnDeshacer = Color.FromArgb(255, 193, 7);

        public csConexionSQL ConexLineas { set { this.conexLineas = value; } }

     public frmLineas()
        {
            InitializeComponent();


        }

        private void frmLineas_Load(object sender, EventArgs e)
        {
            try
            {
                // Configuración inicial de controles
                ConfigureControls();
                CargaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureControls()
        {
         
            dgvLineas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLineas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

 

        private int GeneraId()
        {
            int FolioSiguiente = 1;
            try
            {
                SQL = "Select Top 1 nCveLin From tbLinea Order by nCveLin desc";
                DataTable dtultimoNumero = conexLineas.select(SQL);
                if (dtultimoNumero.Rows.Count > 0)
                {
                    FolioSiguiente = Convert.ToInt32(dtultimoNumero.Rows[0]["nCveLin"]) + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar ID: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return FolioSiguiente;
        }

        private void CargaGrid()
        {
            try
            {
                SQL = "SELECT nCveLin as Id, cDesLin as Descripción FROM tbLinea ORDER BY nCveLin";
                DataTable dtLineas = conexLineas.select(SQL);
                dgvLineas.DataSource = dtLineas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool BuscaExisteLinea()
        {
            try
            {
                SQL = "Select nCveLin From tbLinea Where cDesLin='" + txtDescripcion.Text + "'";
                return conexLineas.select(SQL).Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar línea: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                txtId.Text = GeneraId().ToString();
                txtDescripcion.Text = string.Empty;
                txtDescripcion.Enabled = true;
                txtDescripcion.Focus();
                dgvLineas.Enabled = false;

                btnNuevo.Enabled = false;
                btnSalir.Enabled = false;
                btnGrabar.Enabled = true;
                btnDeshacer.Enabled = true;

                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar nuevo registro: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtId.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtDescripcion.Enabled = false;
            dgvLineas.Enabled = true;

            btnNuevo.Enabled = true;
            btnDeshacer.Enabled = false;
            btnGrabar.Enabled = false;
            btnSalir.Enabled = true;

            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            btnNuevo.BackColor = btnNuevo.Enabled ? originalColorBtnNuevo : Color.LightGray;
            btnSalir.BackColor = btnSalir.Enabled ? originalColorBtnSalir : Color.LightGray;
            btnGrabar.BackColor = btnGrabar.Enabled ? originalColorBtnGrabar : Color.LightGray;
            btnDeshacer.BackColor = btnDeshacer.Enabled ? originalColorBtnDeshacer : Color.LightGray;
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else if (e.KeyChar == '-' || char.IsPunctuation(e.KeyChar) ||
                         e.KeyChar == '*' || e.KeyChar == '+' ||
                         e.KeyChar == '/' || e.KeyChar == '.')
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    if (BuscaExisteLinea())
                    {
                        MessageBox.Show("Esta descripción ya está registrada", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDescripcion.Focus();
                        txtDescripcion.SelectAll();
                    }
                    else
                    {
                        btnGrabar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar entrada: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (BuscaExisteLinea())
                {
                    MessageBox.Show("Esta descripción ya está registrada", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescripcion.Focus();
                    txtDescripcion.SelectAll();
                    return;
                }

                SQL = $"Insert Into tbLinea (nCveLin, cDesLin) Values({Convert.ToByte(txtId.Text)}, '{txtDescripcion.Text}')";

                if (conexLineas.ejecSql(SQL))
                {
                    MessageBox.Show("Registro guardado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargaGrid();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar registro: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}