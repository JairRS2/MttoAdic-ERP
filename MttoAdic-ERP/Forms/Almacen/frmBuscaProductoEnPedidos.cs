using System.Data;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmBuscaProductoEnPedidos : Form
    {
        string SQL = string.Empty;
        public string Codigo = string.Empty;
        public string Descripcion = string.Empty;

        public decimal Cantidad = 0;
        public decimal Costo = 0;

        int nFilaProd = 0;
        public int Pedido = 0;

        public csConexionSQL conexBuscaProd;
        public csConexionSQL ConexBuscaProd { set { this.conexBuscaProd = value; } }

        public frmBuscaProductoEnPedidos()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmBuscaProductoEnPedidos" + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Pedido = 0;
                Codigo = string.Empty;
                Descripcion = string.Empty;
                Cantidad = 0;
                Costo = 0;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnSalir_Click " + ex.Message);
            }
        }

        private void CargaProductos()
        {
            try
            {
                SQL = "select nNumPed as Pedido, ped.cCodPrd as Codigo, nCtdPed as Cantidad, cDesPrd as Descripcion From tbPedidoDetalle ped " +
                    "inner join tbProducto prd on ped.cCodPrd=prd.cCodPrd " +
                    "where nEdoPed=1 " +
                    "order by ped.cCodPrd";

                DataTable dtPedidos = conexBuscaProd.select(SQL);

                if (dtPedidos.Rows.Count > 0)
                {
                    dgvProductos.DataSource = dtPedidos;
                    dgvProductos.Columns["Pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    dgvProductos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaProductos " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPedido.Text != "" && txtCantidad.Text != "" && txtDescripcion.Text != "" && txtCodigo.Text != "" && txtCosto.Text != "0" && txtCosto.Text != "")
                {
                    if (MessageBox.Show("Es correcto el producto seleccionado???", "Confirmación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Pedido = Convert.ToInt32(dgvProductos.Rows[nFilaProd].Cells["Pedido"].Value);
                        Codigo = dgvProductos.Rows[nFilaProd].Cells["Codigo"].Value.ToString()!;
                        Descripcion = dgvProductos.Rows[nFilaProd].Cells["Descripcion"].Value.ToString()!;
                        Cantidad = Convert.ToDecimal(dgvProductos.Rows[nFilaProd].Cells["Cantidad"].Value);
                        Costo = Convert.ToDecimal(txtCosto.Text);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnAgregar_Click " + ex.Message);
            }
        }

        private void frmProductosEnPedidos_Load(object sender, EventArgs e)
        {
            try
            {
                CargaProductos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmProductosEnPedidos_Load " + ex.Message);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductos.Rows.Count == 0)
                { return; }

                nFilaProd = dgvProductos.CurrentCell.RowIndex;
                int nPedido = Convert.ToInt32(dgvProductos.Rows[nFilaProd].Cells["Pedido"].Value);
                txtPedido.Text = nPedido.ToString();
                string cCodigo = dgvProductos.Rows[nFilaProd].Cells["Pedido"].Value.ToString()!;
                txtCodigo.Text = cCodigo;
                string cDescripcion = dgvProductos.Rows[nFilaProd].Cells["Descripcion"].Value.ToString()!;
                txtDescripcion.Text = cDescripcion;
                decimal nCantidad = Convert.ToDecimal(dgvProductos.Rows[nFilaProd].Cells["Cantidad"].Value);
                txtCantidad.Text = nCantidad.ToString();
                txtCosto.Text = "0";
                txtCosto.Focus();
                txtCosto.SelectAll();
                btnAgregar.Enabled = false;
                Pedido = 0;
                Codigo = string.Empty;
                Descripcion = string.Empty;
                Cantidad = 0;
                Costo = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("dgvProductos_CellClick");
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                btnAgregar.Enabled = false;
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
                    if (txtCantidad.Text.Contains("."))
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
                    if (txtPedido.Text != "" && txtCantidad.Text != "" && txtDescripcion.Text != "" && txtCodigo.Text != "" && txtCosto.Text != "0")
                    {
                        btnAgregar.Enabled = true;
                        btnAgregar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtCosto_KeyPress " + ex.Message);
            }
        }
    }
}
