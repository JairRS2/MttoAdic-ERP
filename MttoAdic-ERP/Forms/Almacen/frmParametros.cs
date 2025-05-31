using Syncfusion.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmParametros : MetroForm 
    {
        string SQL = string.Empty;
        private int nFilaGrid = 0;
        bool bNuevo = false;
        bool bModifica = false;

        public csConexionSQL conexParametros;
        public csConexionSQL ConexParametros { set { this.conexParametros = value; } }



        public frmParametros()
        {
            try
            {
                InitializeComponent();
                ApplyModernStyle();
                this.Text = "Gestión de Parámetros";
                this.StartPosition = FormStartPosition.CenterScreen;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmParametros " + ex.Message);
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
        private void frmParametros_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigureControls();
                CargaParametros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmParametros_Load " + ex.Message);
            }
        }
        //Metodo para congifurar los estilos de los controles y poder un modal moderno
        private void ConfigureControls()
        {

            dgvParametros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParametros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
  
        }



        void CargaParametros()
        {
            try
            {
                SQL = "SELECT nIdPar as Id, cNomPar as Parametro, nValPar as Valor FROM tbParametro ORDER BY nIdPar";
                DataTable dtParam = conexParametros.select(SQL);
                dgvParametros.DataSource = dtParam;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaParametros " + ex.Message);
            }
        }

        private int GeneraIdNuevo()
        {
            int IdNuevo = 1;
            try
            {
                SQL = "SELECT Top 1 nIdPar FROM tbParametro ORDER BY nIdPar Desc";
                DataTable dtId = conexParametros.select(SQL);
                if (dtId.Rows.Count > 0)
                {
                    int UltId = Convert.ToInt32(dtId.Rows[0]["nIdPar"]);
                    IdNuevo = UltId + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GeneraIdNuevo " + ex.Message);
            }
            return IdNuevo;
        }

        private bool ExisteParametro(string param)
        {
            try
            {
                SQL = "SELECT * FROM tbParametro Where cNomPar = '" + param + "'";
                return conexParametros.select(SQL).Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ExisteParametro " + ex.Message);
                return false;
            }
        }

        private bool ExisteParametroOtros(string param, int Id)
        {
            try
            {
                SQL = "SELECT * FROM tbParametro Where cNomPar = '" + param + "' And nIdPar <> " + Id;
                return conexParametros.select(SQL).Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ExisteParametroOtros " + ex.Message);
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
                btnNuevo.Enabled = false;
                btnModificar.Enabled = false;
                btnGrabar.Enabled = true;
                btnDeshacer.Enabled = true;
                btnSalir.Enabled = false;
                dgvParametros.Enabled = false;
                txtDescripcion.Text = string.Empty;
                txtValor.Text = string.Empty;
                txtDescripcion.Enabled = true;
                txtValor.Enabled = true;
                int Id = GeneraIdNuevo();
                txtId.Text = Id.ToString();
                txtDescripcion.Focus();
                bNuevo = true;
                bModifica = false;
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
                btnNuevo.Enabled = true;
                btnModificar.Enabled = false;
                btnGrabar.Enabled = false;
                btnDeshacer.Enabled = false;
                btnSalir.Enabled = true;
                dgvParametros.Enabled = true;
                txtDescripcion.Text = string.Empty;
                txtValor.Text = string.Empty;
                txtDescripcion.Enabled = false;
                txtValor.Enabled = false;
                txtId.Text = string.Empty;
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
                if (txtDescripcion.Text != string.Empty && txtValor.Text != string.Empty)
                {
                    if (bNuevo)
                    {
                        bool Existe = ExisteParametro(txtDescripcion.Text);
                        if (Existe)
                        {
                            MessageBox.Show("Este parámetro ya fue capturado");
                            return;
                        }
                    }
                    if (bModifica)
                    {
                        bool Existe = ExisteParametroOtros(txtDescripcion.Text, Convert.ToInt32(txtId.Text));
                        if (Existe)
                        {
                            MessageBox.Show("Este parámetro ya fue capturado con otro Id");
                            return;
                        }
                    }

                    int Id = Convert.ToInt32(txtId.Text);
                    string Nombre = txtDescripcion.Text;
                    decimal Valor = Convert.ToDecimal(txtValor.Text);

                    if (bNuevo)
                        SQL = "Insert Into tbParametro(nIdPar, cNomPar, nValPar) " +
                              "Values(" + Id + ",'" + Nombre + "'," + Valor + ")";
                    if (bModifica)
                        SQL = "Update tbParametro set cNomPar = '" + Nombre + "', nValpar = " + Valor + " Where nIdPar = " + Id;

                    conexParametros.ejecSql(SQL);
                    bNuevo = false;
                    bModifica = false;

                    btnNuevo.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnModificar.Enabled = false;
                    btnDeshacer.Enabled = false;
                    btnSalir.Enabled = true;
                    txtId.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtValor.Text = string.Empty;
                    txtDescripcion.Enabled = false;
                    txtValor.Enabled = false;
                    dgvParametros.Enabled = true;
                    CargaParametros();
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

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '-') e.Handled = true;
                else if ((char)e.KeyChar == '*') e.Handled = true;
                else if ((char)e.KeyChar == '+') e.Handled = true;
                else if ((char)e.KeyChar == '/') e.Handled = true;
                else if ((char)e.KeyChar == '.')
                {
                    if (txtValor.Text.Contains("."))
                    {
                        e.Handled = true;
                    }
                }
                else if ((Keys)e.KeyChar == Keys.Space) e.Handled = true;
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtDescripcion.Text != "" && txtDescripcion.Text != "0" && txtValor.Text != "")
                    {
                        btnGrabar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtValor_KeyPress " + ex.Message);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtDescripcion_KeyPress " + ex.Message);
            }
        }

        private void dgvParametros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvParametros.Rows.Count == 0) return;
                nFilaGrid = dgvParametros.CurrentCell.RowIndex;
                txtId.Text = dgvParametros.Rows[nFilaGrid].Cells["Id"].Value.ToString();
                txtDescripcion.Text = dgvParametros.Rows[nFilaGrid].Cells["Parametro"].Value.ToString();
                txtValor.Text = dgvParametros.Rows[nFilaGrid].Cells["Valor"].Value.ToString();
                btnModificar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("dgvParametros_CellClick");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                btnNuevo.Enabled = false;
                btnModificar.Enabled = false;
                btnGrabar.Enabled = true;
                btnDeshacer.Enabled = true;
                btnSalir.Enabled = true;
                dgvParametros.Enabled = false;
                txtDescripcion.Enabled = true;
                txtValor.Enabled = true;
                txtDescripcion.Focus();
                bNuevo = false;
                bModifica = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnModificar_Click " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}