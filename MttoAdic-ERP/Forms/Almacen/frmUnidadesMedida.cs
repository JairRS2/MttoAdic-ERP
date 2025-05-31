using Syncfusion.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms; 

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmUnidadesMedida : MetroForm
    {
        string SQL = string.Empty;

        public csConexionSQL conexMedidas;
        public csConexionSQL ConexMedidas { set { this.conexMedidas = value; } }

        public frmUnidadesMedida()
        {
            InitializeComponent();
            ApplyModernStyle(); // Llamamos a la función para redondear el formulario
         
        }

        private void frmUnidadesMedida_Load(object sender, EventArgs e)
        {
            try
            {
                txtDescripcion.Enabled = false;
                btnNuevo.Enabled = true;
                btnDeshacer.Enabled = false;
                btnGrabar.Enabled = false;
                btnSalir.Enabled = true;
                ConfigureControls();
                CargaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUnidadesMedida_Load " + ex.Message);
            }
        }

        private void ApplyModernStyle()
        {
            // Crear región con bordes redondeados
            var path = new GraphicsPath();
            int radius = 20;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }
        private void ConfigureControls()
        {

            dgvMedida.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedida.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private int GeneraId()
        {
            int FolioSiguiente = 1;

            try
            {
                SQL = "Select Top 1 nCveUM From tbUnidadMedida Order by nCveUm desc";

                DataTable dtultimoNumero = conexMedidas.select(SQL);
                if (dtultimoNumero.Rows.Count > 0)
                {
                    int UltimoFolio = Convert.ToInt32(dtultimoNumero.Rows[0]["nCveUM"]);
                    FolioSiguiente = UltimoFolio + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GeneraId " + ex.Message);
            }

            return FolioSiguiente;
        }

        private void CargaGrid()
        {
            try
            {

                SQL = "SELECT nCveUm as Id, cDesUM as Descripcion FROM tbUnidadMedida ORDER BY nCveUm";
                DataTable dtMedidas = conexMedidas.select(SQL);

                dgvMedida.DataSource = null;
                dgvMedida.DataSource = dtMedidas;

                dgvMedida.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaGrid " + ex.Message);
            }
        }

        private bool BuscaExisteMedida()
        {
            bool Existe = false;

            try
            {

                SQL = "Select nCveUM From tbUnidadMedida Where cDesUM='" + txtDescripcion.Text + "'";
                DataTable dtExiste = conexMedidas.select(SQL);
                if (dtExiste.Rows.Count > 0)
                {
                    Existe = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BuscaExisteMedida " + ex.Message);
            }

            return Existe;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                btnNuevo.Enabled = false;
                btnSalir.Enabled = false;
                btnGrabar.Enabled = true;
                btnDeshacer.Enabled = true;
                int nNuevoId = GeneraId();
                txtId.Text = nNuevoId.ToString();
                txtDescripcion.Text = string.Empty;
                txtDescripcion.Enabled = true;
                txtDescripcion.Focus();
                dgvMedida.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnNuevo_Click " + ex.Message);
            }
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtDescripcion.Enabled = false;
                dgvMedida.Enabled = true;
                btnNuevo.Enabled = true;
                btnDeshacer.Enabled = false;
                btnGrabar.Enabled = false;
                btnSalir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDeshacer_Click " + ex.Message);
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else if ((char)e.KeyChar == '-')
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
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtDescripcion.Text != "")
                    {
                        if (BuscaExisteMedida())
                        {
                            MessageBox.Show("Esta descripción ya está capturada");
                            txtDescripcion.Focus();
                            txtDescripcion.SelectAll();
                            return;
                        }
                        else
                        {
                            btnGrabar.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtDescripcion_KeyPress " + ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcion.Text != string.Empty && txtId.Text != string.Empty)
                {
                    if (BuscaExisteMedida())
                    {
                        MessageBox.Show("Esta descripción ya está capturada");
                        txtDescripcion.Focus();
                        txtDescripcion.Select();
                        return;
                    }
                    else
                    {
                        byte nId = Convert.ToByte(txtId.Text);

                        SQL = "Insert Into tbUnidadMedida (nCveUM, cDesUM) " +
                            "Values(" + nId + ",'" + txtDescripcion.Text + "')";

                        bool bInserta = conexMedidas.ejecSql(SQL);

                        if (bInserta)
                        {
                            MessageBox.Show("Registro grabado");
                        }

                        CargaGrid();
                        txtId.Text = string.Empty;
                        txtDescripcion.Text = string.Empty;
                        txtDescripcion.Enabled = false;
                        dgvMedida.Enabled = true;
                        btnNuevo.Enabled = true;
                        btnSalir.Enabled = true;
                        btnDeshacer.Enabled = false;
                        btnGrabar.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnGrabar_Click " + ex.Message);
            }
        }
    }
}