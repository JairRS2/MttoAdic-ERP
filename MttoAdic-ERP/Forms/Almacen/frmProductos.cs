using Syncfusion.Windows.Forms;
using System.Data;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmProductos : MetroForm
    {
        string SQL = string.Empty;
        bool bNuevo = false;
        bool bModifica = false;
        private int nFilaGrid = 0;
        DataTable dtProductos = new DataTable();
        DataTable dtMedidas = new DataTable();
        DataTable dtLineas = new DataTable();
        DataTable dtProveedor1 = new DataTable();
        DataTable dtProveedor2 = new DataTable();

        private Color originalColorBtnNuevo;
        private Color originalColorBtnModificar;
        private Color originalColorBtnGrabar;
        private Color originalColorBtnDeshacer;
        private Color originalColorBtnSalir;

        public csConexionSQL conexProductos;
        public csConexionSQL ConexProductos { set { this.conexProductos = value; } }
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            originalColorBtnNuevo = btnNuevo.BackColor;
            originalColorBtnModificar = btnModificar.BackColor;
            originalColorBtnGrabar = btnGrabar.BackColor;
            originalColorBtnDeshacer = btnDeshacer.BackColor;
            originalColorBtnSalir = btnSalir.BackColor;

            CargaProductos();
            LlenaMedida();
            LlenaLinea();
            CargaProveedores();
            HabilitaBotones(1);
            HabilitaControles(1);
        }

        void CargaProductos()
        {
            SQL = "SELECT cCodPrd as Codigo, cDesPrd as Descripcion FROM tbProducto Where cPosPrd <> 'BAJA' ORDER BY cCodPrd";

            dtProductos = conexProductos.select(SQL);

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = dtProductos;
        }

        void LlenaMedida()
        {
            SQL = "SELECT nCveUM, cDesUM FROM tbUnidadMedida ORDER BY cDesUM";

            dtMedidas = conexProductos.select(SQL);

            cboMedida.DataSource = null;
            cboMedida.DataSource = dtMedidas;
            cboMedida.DisplayMember = "cDesUM";
            cboMedida.ValueMember = "nCveUM";
            cboMedida.SelectedIndex = -1;
        }

        void LlenaLinea()
        {
            SQL = "SELECT nCveLin, cDesLin FROM tbLinea ORDER BY cDesLin";
            dtLineas = conexProductos.select(SQL);

            cboLinea.DataSource = null;
            cboLinea.DataSource = dtLineas;
            cboLinea.DisplayMember = "cDesLin";
            cboLinea.ValueMember = "nCveLin";
            cboLinea.SelectedIndex = -1;
        }

        void CargaProveedores()
        {
            try
            {
                SQL = "SELECT cCvePrv, cNomPrv from dbProveedores.dbo.tbProveedor ORDER BY cNomPrv";

                dtProveedor1 = conexProductos.select(SQL);
                cboProveedor1.DataSource = null;
                cboProveedor1.DataSource = dtProveedor1;
                cboProveedor1.DisplayMember = "cNomPrv";
                cboProveedor1.ValueMember = "cCvePrv";
                cboProveedor1.SelectedIndex = -1;

                dtProveedor2 = conexProductos.select(SQL);
                cboProveedor2.DataSource = null;
                cboProveedor2.DataSource = dtProveedor2;
                cboProveedor2.DisplayMember = "cNomPrv";
                cboProveedor2.ValueMember = "cCvePrv";
                cboProveedor2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaProductos " + ex.Message);
            }
        }

        void LimpiarControles()
        {
            try
            {
                txtCodigo.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                cboMedida.SelectedIndex = -1;
                txtMinimo.Text = string.Empty;
                txtMaximo.Text = string.Empty;
                cboLinea.SelectedIndex = -1;
                txtPosicion.Text = string.Empty;
                dtpFechaAlta.Value = DateTime.Now;
                cboProveedor1.SelectedIndex = -1;
                cboProveedor2.SelectedIndex = -1;
                txtInicial.Text = string.Empty;
                txtMarca.Text = string.Empty;
                txtCosto.Text = string.Empty;
                txtInventario.Text = string.Empty;
                txtPrecioVenta.Text = string.Empty;
                dtpFechaCompra.Value = DateTime.Now;
                txtCostoCompra.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LimpiarControles" + ex.Message);
            }
        }

        void HabilitaControles(int opcion)
        {
            try
            {
                if (opcion == 1) //Deshabilita Todos menos la busqueda
                {
                    txtCodigo.Enabled = false;
                    txtDescripcion.Enabled = false;
                    cboMedida.Enabled = false;
                    txtMinimo.Enabled = false;
                    txtMaximo.Enabled = false;
                    cboLinea.Enabled = false;
                    txtPosicion.Enabled = false;
                    dtpFechaAlta.Enabled = false;
                    cboProveedor1.Enabled = false;
                    cboProveedor2.Enabled = false;
                    txtInicial.Enabled = false;
                    txtMarca.Enabled = false;
                    txtCosto.Enabled = false;
                    txtInventario.Enabled = false;
                    txtPrecioVenta.Enabled = false;
                    dtpFechaCompra.Enabled = false;
                    txtCostoCompra.Enabled = false;
                    txtBuscaNombre.Enabled = true;
                    txtBuscaCodigo.Enabled = true;
                    dgvProductos.Enabled = true;
                }
                if (opcion == 2) //nuevo
                {
                    txtCodigo.Enabled = true;
                    txtDescripcion.Enabled = true;
                    cboMedida.Enabled = true;
                    txtMinimo.Enabled = true;
                    txtMaximo.Enabled = true;
                    cboLinea.Enabled = true;
                    txtPosicion.Enabled = true;
                    dtpFechaAlta.Enabled = true;
                    cboProveedor1.Enabled = true;
                    cboProveedor2.Enabled = true;
                    txtInicial.Enabled = false;
                    txtMarca.Enabled = true;
                    txtCosto.Enabled = true;
                    txtInventario.Enabled = false;
                    txtPrecioVenta.Enabled = false;
                    dtpFechaCompra.Enabled = false;
                    txtCostoCompra.Enabled = false;
                    txtBuscaNombre.Enabled = false;
                    txtBuscaCodigo.Enabled = false;
                    dgvProductos.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HabilitaControles " + ex.Message);
            }
        }

        void HabilitaBotones(int opcion)
        {
            try
            {
                if (opcion == 1)
                {
                    btnNuevo.Enabled = true;
                    btnNuevo.BackColor = originalColorBtnNuevo;
                    btnModificar.Enabled = false;
                    btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnGrabar.Enabled = false;
                    btnGrabar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnDeshacer.Enabled = false;
                    btnDeshacer.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnSalir.Enabled = true;
                    btnSalir.BackColor = originalColorBtnSalir;
                }
                if (opcion == 2) //Nuevo-modificar
                {
                    btnNuevo.Enabled = false;
                    btnNuevo.BackColor= ColorTranslator.FromHtml("#FFFFFF");
                    btnModificar.Enabled = false;
                    btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    btnGrabar.Enabled = true;
                    btnGrabar.BackColor = originalColorBtnGrabar;
                    btnDeshacer.Enabled = true;
                    btnDeshacer.BackColor= originalColorBtnDeshacer;
                    btnSalir.Enabled = false;
                    btnSalir.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HabilitaBotones " + ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            HabilitaControles(2);
            HabilitaBotones(2);
            bNuevo = true;
            bModifica = false;
            txtPrecioVenta.Text = "0";
            txtCosto.Text = "0";
            txtCostoCompra.Text = "0";
            txtInicial.Text = "0";
            txtInventario.Text = "0";
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            HabilitaControles(1);
            HabilitaBotones(1);
            bNuevo = false;
            bModifica = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            HabilitaControles(2);
            HabilitaBotones(2);
            bNuevo = false;
            bModifica = true;
            txtCodigo.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtDescripcion.Text != "" && cboLinea.SelectedIndex > -1 && txtMinimo.Text != ""
                && txtMinimo.Text != "0" && txtMaximo.Text != "" && txtMaximo.Text != "0" && cboLinea.SelectedIndex > -1
                && txtPosicion.Text != "" && dtpFechaAlta.Value.Date <= DateTime.Now.Date
                && cboProveedor1.SelectedIndex > -1 && cboProveedor2.SelectedIndex > -1 && txtMarca.Text != "")
            {
                if (MessageBox.Show("Ya reviso que estén correctos los datos???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (bNuevo)
                    {
                        bool ExCodigo = ValidaCodigo(txtCodigo.Text);
                        if (ExCodigo)
                        {
                            MessageBox.Show("Este código de producto ya existe");
                            return;
                        }

                        bool ExDescripcion = ValidaDescripcionIns(txtDescripcion.Text);
                        if (ExDescripcion)
                        {
                            MessageBox.Show("Esta descripción de producto ya existe con otro codigo");
                            return;
                        }

                        if (dtpFechaAlta.Value.Date > DateTime.Now.Date)
                        {
                            MessageBox.Show("No puede poner una fecha mayor a la actual");
                            return;
                        }

                        SQL = "Insert Into tbProducto (cCodPrd, cDesPrd, nUniPrd, nMinPrd, nMaxPrd, " +
                            "dAltPrd, dUltPrd, nLinPrd, nCosPrd, nPrePrd, nInvIPrd, nInvAPrd, nUltPrd, cPosPrd, " +
                            "cPtePrd, cPrv1Prd, cPrv2Prd) " +
                            "Values('" + txtCodigo.Text + "','" + txtDescripcion.Text + "'," + Convert.ToByte(cboMedida.SelectedValue) +
                            "," + Convert.ToDecimal(txtMinimo.Text) + "," + Convert.ToDecimal(txtMaximo.Text) + ",'" + dtpFechaAlta.Value.ToString("yyyyMMdd") +
                            "','" + DateTime.Now.ToString("yyyyMMdd") + "'," + Convert.ToByte(cboLinea.SelectedValue) +
                            ",0,0,0,0,0,'" + txtPosicion.Text + "','" + txtMarca.Text + "','" + cboProveedor1.SelectedValue + "','" + cboProveedor2.SelectedValue + "')";

                        bool bInsertado = conexProductos.ejecSql(SQL);

                        if (bInsertado)
                        {
                            MessageBox.Show("Registro insertado correctamente");
                        }
                        else
                        {
                            MessageBox.Show("No se inserto correctamente el registro");
                        }
                    }
                    if (bModifica)
                    {
                        bool ExDescripcion = ValidaDescripcionUpd(txtCodigo.Text, txtDescripcion.Text);
                        if (ExDescripcion)
                        {
                            MessageBox.Show("Esta descripción de producto ya existe con otro codigo");
                            return;
                        }

                        if (dtpFechaAlta.Value > DateTime.Now.Date)
                        {
                            MessageBox.Show("No puede poner una fecha mayor a la actual");
                            return;
                        }

                        SQL = "Update tbProducto Set cDesPrd='" + txtDescripcion.Text + "',nUniPrd=" + Convert.ToByte(cboMedida.SelectedValue) +
                            ",nMinPrd=" + Convert.ToDecimal(txtMinimo.Text) + ",nMaxPrd=" + Convert.ToDecimal(txtMaximo.Text) + ", nLinPrd=" + Convert.ToByte(cboLinea.SelectedValue) +
                            ",cPosPrd='" + txtPosicion.Text + "',cPtePrd='" + txtMarca.Text + "',cPrv1Prd='" + cboProveedor1.SelectedValue +
                            "',cPrv2Prd='" + cboProveedor2.SelectedValue + "' Where cCodPrd='" + txtCodigo.Text + "'";

                        bool bModificado = conexProductos.ejecSql(SQL);

                        if (bModificado)
                        {
                            MessageBox.Show("Registro modificado correctamente");
                        }
                        else
                        {
                            MessageBox.Show("No se modifico correctamente el registro");
                        }
                    }
                }
                CargaProductos();
            }
            else
            {
                MessageBox.Show("Falta algún dato por capturar");
                return;
            }

            LimpiarControles();
            HabilitaControles(1);
            HabilitaBotones(1);
            bNuevo = false;
            bModifica = false;
        }

        private bool ValidaCodigo(string codigo)
        {
            SQL = "Select cCodPrd from tbProducto where cCodPrd='" + codigo + "'";

            dtProductos = conexProductos.select(SQL);

            if (dtProductos.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private bool ValidaDescripcionUpd(string codigo, string descripcion)
        {
            SQL = "Select cCodPrd from tbProducto where cDesPrd='" + descripcion + "' and cCodPrd<>'" + codigo + "'";

            dtProductos = conexProductos.select(SQL);

            if (dtProductos.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private bool ValidaDescripcionIns(string descripcion)
        {
            SQL = "Select cCodPrd from tbProducto where cDesPrd='" + descripcion + "'";

            dtProductos = conexProductos.select(SQL);

            if (dtProductos.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtDescripcion.Text != "")
                    {
                        if (bNuevo)
                        {
                            if (ValidaDescripcionIns(txtDescripcion.Text))
                            {
                                MessageBox.Show("Esta descripción ya está capturada");
                                txtDescripcion.Focus();
                                txtDescripcion.SelectAll();
                                return;
                            }

                            cboMedida.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtDescripcion_KeyPress " + ex.Message);
            }
        }

        private void txtMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '-')
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
                    if (txtMinimo.Text.Contains("."))
                    {
                        e.Handled = true;
                    }
                }
                else if ((Keys)e.KeyChar == Keys.Space)
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtMinimo.Text != "" && txtMinimo.Text != "0")
                    {
                        txtMaximo.Focus();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtMinimo_KeyPress " + ex.Message);
            }
        }

        private void txtMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if ((char)e.KeyChar == '-')
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
                    if (txtMaximo.Text.Contains("."))
                    {
                        e.Handled = true;
                    }
                }
                else if ((Keys)e.KeyChar == Keys.Space)
                {
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtMaximo.Text != "" && txtMaximo.Text != "0")
                    {
                        cboLinea.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtMaximo_KeyPress " + ex.Message);
            }
        }

        private void txtPosicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else if ((char)e.KeyChar == '-')
                {
                    //e.Handled = true;
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
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtPosicion.Text != "")
                    {
                        dtpFechaAlta.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtPosicion_KeyPress " + ex.Message);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else if (char.IsLetter(e.KeyChar))
                {
                    //e.Handled = true;
                }
                else if ((char)e.KeyChar == '-')
                {
                    //e.Handled = true;
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
                    e.Handled = true;
                }
                else if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtCodigo.Text != "")
                    {
                        txtDescripcion.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtCodigo_KeyPress " + ex.Message);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductos.Rows.Count == 0)
                { return; }

                nFilaGrid = dgvProductos.CurrentCell.RowIndex;

                string Codigo = dgvProductos.Rows[nFilaGrid].Cells["Codigo"].Value.ToString()!;
                MuestraRegistro(Codigo);
                btnModificar.Enabled = true;
                btnModificar.BackColor = originalColorBtnModificar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("dgvParametros_CellClick");
            }
        }

        private void MuestraRegistro(string Codigo)
        {
            SQL = "SELECT cCodPrd, cDesPrd, nUniPrd, nMinPrd, nMaxPrd, dAltPrd, dUltPrd, nLinPrd, nCosPrd, " +
                "nPrePrd, nInvIPrd, nInvAPrd, nUltPrd, cPosPrd, cPtePrd, cPrv1Prd, cPrv2Prd FROM tbProducto Where cCodPrd='" + Codigo + "'";

            dtProductos = conexProductos.select(SQL);

            if (dtProductos.Rows.Count > 0)
            {
                txtCodigo.Text = dtProductos.Rows[0]["cCodPrd"].ToString();
                txtDescripcion.Text = dtProductos.Rows[0]["cDesPrd"].ToString();
                dtpFechaAlta.Value = DateTime.Parse(dtProductos.Rows[0]["dAltPrd"].ToString()!);
                cboMedida.SelectedValue = Convert.ToInt32(dtProductos.Rows[0]["nUniPrd"]);
                txtMinimo.Text = dtProductos.Rows[0]["nMinPrd"].ToString();
                txtMaximo.Text = dtProductos.Rows[0]["nMaxPrd"].ToString();
                cboLinea.SelectedValue = Convert.ToInt32(dtProductos.Rows[0]["nLinPrd"]);
                txtPosicion.Text = dtProductos.Rows[0]["cPosPrd"].ToString();
                txtInicial.Text = dtProductos.Rows[0]["nInvIPrd"].ToString();
                txtMarca.Text = dtProductos.Rows[0]["cPtePrd"].ToString();
                txtCosto.Text = dtProductos.Rows[0]["nCosPrd"].ToString();
                cboProveedor1.SelectedValue = dtProductos.Rows[0]["cPrv1Prd"];
                cboProveedor2.SelectedValue = dtProductos.Rows[0]["cPrv2Prd"];
                txtInventario.Text = dtProductos.Rows[0]["nInvAPrd"].ToString();
                txtPrecioVenta.Text = dtProductos.Rows[0]["nPrePrd"].ToString();
                dtpFechaCompra.Value = DateTime.Parse(dtProductos.Rows[0]["dUltPrd"].ToString()!);
                txtCostoCompra.Text = dtProductos.Rows[0]["nUltPrd"].ToString();
            }
        }

        private void txtBuscaNombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvProductos.DataSource;
                bs.Filter = "Descripcion like '%" + txtBuscaNombre.Text + "%'";
                dgvProductos.DataSource = bs.DataSource;
                btnModificar.Enabled = false;
                btnModificar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtBuscaNombre_TextChanged " + ex.Message);
            }
        }

        private void txtBuscaCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvProductos.DataSource;
                bs.Filter = "Codigo like '%" + txtBuscaCodigo.Text + "%'";
                dgvProductos.DataSource = bs.DataSource;
                btnModificar.Enabled = true;
                btnModificar.BackColor = originalColorBtnModificar;
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtBuscaNombre_TextChanged " + ex.Message);
            }
        }

        private void txtBuscaNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txtBuscaCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void txtMarca_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
    }
}
