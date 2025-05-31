using System.Data;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmBuscaProducto : Form
    {
        private readonly Form _frmBuscador = null!;

        frmVales vales = new frmVales();
        frmPedidos pedidos = new frmPedidos();
        frmCompras compras = new frmCompras();

        public string Codigo = string.Empty;
        string SQL = string.Empty;

        DataTable dtProductos = new DataTable();

        public csConexionSQL conexBuscaProd;
        public csConexionSQL ConexBuscaProd { set { this.conexBuscaProd = value; } }

        public frmBuscaProducto(Form frmBuscador)
        {
            try
            {
                InitializeComponent();
                _frmBuscador = frmBuscador;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmBuscaProducto " + ex.Message);
            }
        }

        private void frmBuscaProducto_Load(object sender, EventArgs e)
        {
            try
            {
                CargaProductos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmBuscaProducto_Load " + ex.Message);
            }
        }

        private void CargaProductos()
        {
            try
            {
                if (_frmBuscador.Name == vales.Name)
                {
                    SQL = "SELECT cCodPrd as Codigo, cDesPrd as Producto FROM tbProducto WHERE nInvAPrd>0 order by cDesPrd";

                    dtProductos = conexBuscaProd.select(SQL);

                    if (dtProductos.Rows.Count > 0)
                    {
                        dgvProductos.DataSource = dtProductos;
                    }
                }
                if (_frmBuscador.Name == pedidos.Name)
                {
                    SQL = "SELECT cCodPrd as Codigo, cDesPrd as Producto FROM tbProducto order by cDesPrd";

                    dtProductos = conexBuscaProd.select(SQL);

                    if (dtProductos.Rows.Count > 0)
                    {
                        dgvProductos.DataSource = dtProductos;
                    }
                }
                if (_frmBuscador.Name == compras.Name)
                {
                    SQL = "SELECT cCodPrd as Codigo, cDesPrd as tbProducto FROM tbProducto order by cDesPrd";

                    dtProductos = conexBuscaProd.select(SQL);

                    if (dtProductos.Rows.Count > 0)
                    {
                        dgvProductos.DataSource = dtProductos;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaProductos " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvProductos.DataSource;
                bs.Filter = "Producto like '%" + txtBusca.Text + "%'";
                dgvProductos.DataSource = bs.DataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtBusca_TextChanged " + ex.Message);
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int FilaSeleccionadaGrid = dgvProductos.CurrentRow.Index;
                Codigo = dgvProductos.Rows[FilaSeleccionadaGrid].Cells["Codigo"].Value.ToString()!;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("dgvProductos_CellDoubleClick " + ex.Message);
            }
        }
    }
}
