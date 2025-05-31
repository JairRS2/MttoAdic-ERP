using Syncfusion.GridExcelConverter;
using Syncfusion.GridHelperClasses;
using Syncfusion.Grouping;
using Syncfusion.GroupingGridExcelConverter;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System.Data;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmBuscaVales : Form
    {
        public int nNumVale = 0;

        string SQL = string.Empty;

        public csConexionSQL conexBuscaVale;
        public csConexionSQL ConexBuscaVale { set { this.conexBuscaVale = value; } }

        public frmBuscaVales()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            DateTime dDesde = dtpDesde.Value;
            DateTime dHasta = dtpHasta.Value;
            try
            {
                SQL = "select det.nnumval as Vale, det.cCodPrd as Codigo, cDesPrd as Producto, nCtdVal as Cantidad, nPreVal as Precio, dEntVal as Fecha " +
                    "From ((tbValeDetalle det " +
                    "inner join tbVale val on det.nNumVal = val.nNumVal) " +
                    "inner join tbProducto prod on det.cCodPrd = prod.cCodPrd) " +
                    "Where det.nEdoVal = 2 and dEntVal >= '" + dDesde.ToString("yyyyMMdd") + "' and dEntVal <= '" + dHasta.ToString("yyyyMMdd") + "'";

                DataTable dtVales = conexBuscaVale.select(SQL);

                ggcVales.DataSource = null;
                ggcVales.DataSource = dtVales;

                ggcVales.TableDescriptor.Columns["Vale"].Width = 150;
                ggcVales.TableDescriptor.Columns["Codigo"].Width = 150;
                ggcVales.TableDescriptor.Columns["Producto"].Width = 500;
                ggcVales.TableDescriptor.Columns["Cantidad"].Width = 100;
                ggcVales.TableDescriptor.Columns["Precio"].Width = 100;
                ggcVales.TableDescriptor.Columns["Fecha"].Width = 150;

                foreach (GridColumnDescriptor col in ggcVales.TableDescriptor.Columns)
                {
                    col.AllowFilter = true;
                }

                GridDynamicFilter dynamicFilter = new GridDynamicFilter();
                dynamicFilter.WireGrid(ggcVales);

                ggcVales.TableDescriptor.AllowNew = false;
                ggcVales.TableDescriptor.AllowEdit = false;
                ggcVales.TableDescriptor.AllowRemove = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnCargar_Click " + ex.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            GridGroupingExcelConverterControl ExcelConverter = new GridGroupingExcelConverterControl();

            ExcelConverter.ExportMode = GridGroupingExcelConverterBase.ExportingMode.Text;
            ExcelConverter.ShowGridLines = true;

            ExcelExportingOptions exportingOptions = new ExcelExportingOptions();

            ExcelConverter.ExportToExcel(this.ggcVales, "E:\\BuscaVales.xls", exportingOptions);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBuscaVales_Load(object sender, EventArgs e)
        {
            ggcVales.GridGroupDropArea.DragColumnHeaderText = "Arraste el campo para agrupar";
        }

        private void ggcVales_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            Record currentRecord = ggcVales.Table.CurrentRecord;
            if (currentRecord != null)
            {
                nNumVale = Convert.ToInt32(currentRecord["Vale"]);
                this.Close();
            }
        }
    }
}