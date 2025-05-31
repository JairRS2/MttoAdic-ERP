using Syncfusion.GridHelperClasses;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System.Data;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmBuscaDevolucionCompra : MetroForm
    {
        public int nNumDev = 0;

        string SQL = string.Empty;

        public csConexionSQL conexDevCompras;
        public csConexionSQL ConexDevCompras { set { this.conexDevCompras = value; } }

        public frmBuscaDevolucionCompra()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            DataTable dtDevolucion = new DataTable();

            DateTime dDesde = dtpDesde.Value;
            DateTime dHasta = dtpHasta.Value;
            try
            {
                SQL = "select nNumDvp as Devolucion,  cFacDvp as Factura, cCodPrd as Codigo, cDesPrd as Producto, " +
                    "nCtdDvp as Cantidad, nCtoDvp as Costo, FORMAT(dFecDvp, 'dd-MM-yyyy') as Fecha " +
                    "from tbDevolucionCompra " + 
                    "Where dFecDvp >= '" + dDesde.ToString("yyyyMMdd") + "' and dFecDvp <= '" + dHasta.ToString("yyyyMMdd") + "' " +
                    "Order by nNumDvp";

                dtDevolucion = conexDevCompras.select(SQL);

                ggcDevoluciones.DataSource = null;
                ggcDevoluciones.DataSource = dtDevolucion;

                ggcDevoluciones.TableDescriptor.Columns["Devolucion"].Width = 150;
                ggcDevoluciones.TableDescriptor.Columns["Codigo"].Width = 150;
                ggcDevoluciones.TableDescriptor.Columns["Producto"].Width = 500;
                ggcDevoluciones.TableDescriptor.Columns["Cantidad"].Width = 100;
                ggcDevoluciones.TableDescriptor.Columns["Costo"].Width = 100;
                ggcDevoluciones.TableDescriptor.Columns["Fecha"].Width = 150;

                foreach (GridColumnDescriptor col in ggcDevoluciones.TableDescriptor.Columns)
                {
                    col.AllowFilter = true;
                }

                GridDynamicFilter dynamicFilter = new GridDynamicFilter();
                dynamicFilter.WireGrid(ggcDevoluciones);

                ggcDevoluciones.TableDescriptor.AllowNew = false;
                ggcDevoluciones.TableDescriptor.AllowEdit = false;
                ggcDevoluciones.TableDescriptor.AllowRemove = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaDevolucion " + ex.Message);
            }
        }

        private void ggcDevoluciones_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            Record currentRecord = ggcDevoluciones.Table.CurrentRecord;
            if (currentRecord != null)
            {
                nNumDev = Convert.ToInt32(currentRecord["Devolucion"]);
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBuscaDevoluciones_Load(object sender, EventArgs e)
        {
            ggcDevoluciones.GridGroupDropArea.DragColumnHeaderText = "Arraste el campo para agrupar";
        }
    }
}