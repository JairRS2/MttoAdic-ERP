using Syncfusion.GridExcelConverter;
using Syncfusion.GridHelperClasses;
using Syncfusion.Grouping;
using Syncfusion.GroupingGridExcelConverter;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System.Data;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmBuscaDevolucionVale : Form
    {
        public int nNumDev = 0;

        string SQL = string.Empty;

        public csConexionSQL conexDevVales;
        public csConexionSQL ConexDevVales { set { this.conexDevVales = value; } }

        public frmBuscaDevolucionVale()
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
                SQL = "select nNumDev as Devolucion,  nNumVal as Vale, cCodPrd as Codigo, cDesPrd as Producto, " +
                    "nCtdPrd as Cantidad, nPrePrd as Precio, FORMAT(dFecDev, 'dd-MM-yyyy') as Fecha " +
                    "from tbDevolucionVale " +
                    "Where dFecDev >= '" + dDesde.ToString("yyyyMMdd") + "' and dFecDev <= '" + dHasta.ToString("yyyyMMdd") + "' " +
                    "Order by nNumDev";

                dtDevolucion = conexDevVales.select(SQL);

                ggcDevoluciones.DataSource = null;
                ggcDevoluciones.DataSource = dtDevolucion;

                ggcDevoluciones.TableDescriptor.Columns["Vale"].Width = 150;
                ggcDevoluciones.TableDescriptor.Columns["Codigo"].Width = 150;
                ggcDevoluciones.TableDescriptor.Columns["Producto"].Width = 500;
                ggcDevoluciones.TableDescriptor.Columns["Cantidad"].Width = 100;
                ggcDevoluciones.TableDescriptor.Columns["Precio"].Width = 100;
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            GridGroupingExcelConverterControl ExcelConverter = new GridGroupingExcelConverterControl();

            ExcelConverter.ExportMode = GridGroupingExcelConverterBase.ExportingMode.Text;
            ExcelConverter.ShowGridLines = true;

            ExcelExportingOptions exportingOptions = new ExcelExportingOptions();

            ExcelConverter.ExportToExcel(this.ggcDevoluciones, "E:\\BuscaDevoluciones.xls", exportingOptions);
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