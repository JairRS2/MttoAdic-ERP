
using System.Data;
using System.Data.OleDb;
using System.Drawing.Printing;
using Syncfusion.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.DocIO.DLS;
using Syncfusion.XlsIO;
using System.Data.SqlClient;


namespace MttoAdic_ERP.Forms.Almacen.Productos
{
    public partial class frmProductosIndex : MetroForm
    {
        public csConexionSQL conexMetroProductos;
        public csConexionSQL ConexMetroProductos { set { this.conexMetroProductos = value; } }

        DataTable dtProductos = new DataTable();

        string SQL = string.Empty;
        string Codigo = string.Empty;
        string Estado = string.Empty;

        decimal Existencias = 0;

        bool bInventario = false;

        public frmProductosIndex()
        {
            InitializeComponent();

            StyleDataGridView();

        }

        private void StyleDataGridView()
        {
            // Configuración de bordes
          
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Configuración de fuentes
            dgvProductos.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Configuración de colores
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.GridColor = Color.FromArgb(230, 230, 230);

            // Estilo de cabeceras
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(47, 84, 150); // Azul corporativo
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProductos.ColumnHeadersHeight = 35;
            dgvProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(47, 84, 150); // Mismo azul
            dgvProductos.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(47, 84, 150); // 
            // Estilo de filas
            dgvProductos.RowsDefaultCellStyle.BackColor = Color.White;
            dgvProductos.RowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvProductos.RowTemplate.Height = 28;

            // Selección
            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Otras configuraciones
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
      
            dgvProductos.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        }
        private void frmMetroProductos_Load(object sender, EventArgs e)
        {
            CargaLineas();

            cbxEstado.Items.Add("Estado(All)");
            cbxEstado.Items.Add("ACTIVO");
            cbxEstado.Items.Add("BAJA");
            cbxEstado.SelectedIndex = 0;

            cbxExistencia.Items.Add("Existencia(All)");
            cbxExistencia.Items.Add("Con Existencia");
            cbxExistencia.Items.Add("Sin Existencia");
            cbxExistencia.SelectedIndex = 0;

            CargaProductos();
        }


        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!bInventario)
            {
                if (e.RowIndex > -1)
                {
                    DataGridViewCell cell = (DataGridViewCell)
                        dgvProductos.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    lblcodigo.Text = dgvProductos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString()!;

                    Estado = dgvProductos.Rows[e.RowIndex].Cells["Estado"].Value.ToString()!;
                    Codigo = dgvProductos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString()!;
                    Existencias = Convert.ToDecimal(dgvProductos.Rows[e.RowIndex].Cells["Existencias"].Value);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string strfilter = string.Empty;
            if (txtBuscar.Focused)
            {
                if (txtBuscar.Text != "")
                { }
                strfilter = "Descripcion like '%" + txtBuscar.Text + "%'";
                if (cbxEstado.Text != "Estado(All)")
                {
                    if (strfilter != "")
                        strfilter = strfilter + " And Estado ='" + cbxEstado.Text + "'";
                    else
                        strfilter = " Estado ='" + cbxEstado.Text + "'";
                }
                if (cbxLinea.Text != "Linea(All)")
                {
                    if (strfilter != "")
                        strfilter = strfilter + " And Linea ='" + cbxLinea.Text + "'";
                    else
                        strfilter = " Linea ='" + cbxLinea.Text + "'";
                }
                if (cbxExistencia.Text != "Existencia(All)")
                {
                    string strExist = cbxExistencia.Text;

                    if (strfilter != "")
                    {
                        if (strExist == "Con Existencia")
                            strfilter = strfilter + " And Existencias >0";
                        else
                            strfilter = strfilter + " And Existencias <1";
                    }
                    else
                    {
                        if (strExist == "Con Existencia")
                            strfilter = " Existencias >0";
                        else
                            strfilter = " Existencias <1";
                    }
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = dgvProductos.DataSource;
                bs.Filter = strfilter;
                dgvProductos.DataSource = bs.DataSource;

                Codigo = string.Empty;
                Estado = string.Empty;
                Existencias = 0;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargaProductos();
            txtBuscar.Text = string.Empty;
            cbxEstado.SelectedIndex = 0;
            cbxLinea.SelectedValue = 0;
            cbxExistencia.SelectedIndex = 0;

            Codigo = string.Empty;
            Estado = string.Empty;
            Existencias = 0;
        }

        private void CargaProductos()
        {
            try
            {
                SQL = "SELECT cCodPrd as Codigo, cDesPrd as Descripcion, cPosPrd as Posicion, nCosPrd as Costo, nPrePrd as Precio, nInvAPrd as Existencias, cDesLin as Linea, IIF(nEdoPrd=1,'ACTIVO', 'BAJA') as Estado FROM tbProducto as prod " +
            "Inner Join tbLinea lin on prod.nLinPrd = lin.nCveLin " +
            "ORDER BY cCodPrd";

                dtProductos = conexMetroProductos.select(SQL);

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = dtProductos;

                dgvProductos.Columns["Codigo"].Width = 100;
                dgvProductos.Columns["Descripcion"].Width = 500;
                dgvProductos.Columns["Posicion"].Width = 100;
                dgvProductos.RowHeadersDefaultCellStyle.BackColor = Color.White;
                dgvProductos.Columns["Codigo"].DisplayIndex = 0;
                dgvProductos.Columns["Descripcion"].DisplayIndex = 1;
                dgvProductos.Columns["Posicion"].DisplayIndex = 2;
                dgvProductos.Columns["Costo"].DisplayIndex = 3;
                dgvProductos.Columns["Precio"].DisplayIndex = 4;
                dgvProductos.Columns["Existencias"].DisplayIndex = 5;
                dgvProductos.Columns["Existencias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProductos.Columns["Costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProductos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProductos.Columns["Existencias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvProductos.Columns["Linea"].DisplayIndex = 6;
                dgvProductos.Columns["Estado"].DisplayIndex = 7;
                dgvProductos.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Codigo = string.Empty;
                Estado = string.Empty;
                Existencias = 0;

                bInventario = false;
            }
            catch (SqlException ex)
            {
            }
            catch (Exception ex)
            {

            }
        }

        private void CargaLineas()
        {
            SQL = "Select nCveLin, cDesLin From tbLinea Order By nCveLin";
            DataTable dtLinea = conexMetroProductos.select(SQL);
            dtLinea.Rows.Add(0, "Linea(All)");
            cbxLinea.DataSource = null;

            if (dtLinea.Rows.Count > 0)
            {
                cbxLinea.DataSource = dtLinea;
                cbxLinea.DisplayMember = "cDesLin";
                cbxLinea.ValueMember = "nCveLin";
                cbxLinea.SelectedValue = 0;
            }
        }

        private void cbxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strfilter = string.Empty;
            if (cbxEstado.Focused)
            {
                if (cbxEstado.Text != "Estado(All)")
                {
                    strfilter = "Estado = '" + cbxEstado.Text + "'";
                    if (txtBuscar.Text != "")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Descripcion like '%" + txtBuscar.Text + "%'";
                        else
                            strfilter = " Descripcion like '%" + txtBuscar.Text + "%'";
                    }
                    if (cbxLinea.Text != "Linea(All)")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Linea ='" + cbxLinea.Text + "'";
                        else
                            strfilter = " Linea ='" + cbxLinea.Text + "'";
                    }
                    if (cbxExistencia.Text != "Existencia(All)")
                    {
                        string strExist = cbxExistencia.Text;

                        if (strfilter != "")
                        {
                            if (strExist == "Con Existencia")
                                strfilter = strfilter + " And Existencias >0";
                            else
                                strfilter = strfilter + " And Existencias <1";
                        }
                        else
                        {
                            if (strExist == "Con Existencia")
                                strfilter = " Existencias >0";
                            else
                                strfilter = " Existencias <1";
                        }
                    }
                }
                else
                {
                    if (txtBuscar.Text != "")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Descripcion like '%" + txtBuscar.Text + "%'";
                        else
                            strfilter = " Descripcion like '%" + txtBuscar.Text + "%'";
                    }
                    if (cbxLinea.Text != "Linea(All)")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Linea ='" + cbxLinea.Text + "'";
                        else
                            strfilter = " Linea ='" + cbxLinea.Text + "'";
                    }
                    if (cbxExistencia.Text != "Existencia(All)")
                    {
                        string strExist = cbxExistencia.Text;

                        if (strfilter != "")
                        {
                            if (strExist == "Con Existencia")
                                strfilter = strfilter + " And Existencias >0";
                            else
                                strfilter = strfilter + " And Existencias <1";
                        }
                        else
                        {
                            if (strExist == "Con Existencia")
                                strfilter = " Existencias >0";
                            else
                                strfilter = " Existencias <1";
                        }
                    }
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvProductos.DataSource;
                bs.Filter = strfilter;
                dgvProductos.DataSource = bs.DataSource;

                Codigo = string.Empty;
                Estado = string.Empty;
                Existencias = 0;
            }
        }

        private void cbxLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strfilter = string.Empty;
            if (cbxLinea.Focused)
            {
                if (cbxLinea.Text != "Linea(All)")
                {
                    strfilter = "Linea = '" + cbxLinea.Text + "'";
                    if (txtBuscar.Text != "")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Descripcion like '%" + txtBuscar.Text + "%'";
                        else
                            strfilter = " Descripcion like '%" + txtBuscar.Text + "%'";
                    }
                    if (cbxEstado.Text != "Estado(All)")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Estado ='" + cbxEstado.Text + "'";
                        else
                            strfilter = " Estado ='" + cbxEstado.Text + "'";
                    }
                    if (cbxExistencia.Text != "Existencia(All)")
                    {
                        string strExist = cbxExistencia.Text;

                        if (strfilter != "")
                        {
                            if (strExist == "Con Existencia")
                                strfilter = strfilter + " And Existencias >0";
                            else
                                strfilter = strfilter + " And Existencias <1";
                        }
                        else
                        {
                            if (strExist == "Con Existencia")
                                strfilter = " Existencias >0";
                            else
                                strfilter = " Existencias <1";
                        }
                    }

                    BindingSource bs = new BindingSource();
                    bs.DataSource = dgvProductos.DataSource;
                    bs.Filter = strfilter;
                    dgvProductos.DataSource = bs.DataSource;
                }
                else
                {
                    if (txtBuscar.Text != "")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Descripcion like '%" + txtBuscar.Text + "%'";
                        else
                            strfilter = " Descripcion like '%" + txtBuscar.Text + "%'";
                    }
                    if (cbxEstado.Text != "Estado(All)")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Estado ='" + cbxEstado.Text + "'";
                        else
                            strfilter = " Estado ='" + cbxEstado.Text + "'";
                    }
                    if (cbxExistencia.Text != "Existencia(All)")
                    {
                        string strExist = cbxExistencia.Text;

                        if (strfilter != "")
                        {
                            if (strExist == "Con Existencia")
                                strfilter = strfilter + " And Existencias >0";
                            else
                                strfilter = strfilter + " And Existencias <1";
                        }
                        else
                        {
                            if (strExist == "Con Existencia")
                                strfilter = " Existencias >0";
                            else
                                strfilter = " Existencias <1";
                        }
                    }

                    BindingSource bs = new BindingSource();
                    bs.DataSource = dgvProductos.DataSource;
                    bs.Filter = strfilter;
                    dgvProductos.DataSource = bs.DataSource;
                }

                Codigo = string.Empty;
                Estado = string.Empty;
                Existencias = 0;
            }
        }

        private void cbxExistencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strfilter = string.Empty;
            if (cbxExistencia.Focused)
            {
                string strExist = cbxExistencia.Text;
                if (cbxExistencia.Text != "Existencia(All)")
                {
                    if (strExist == "Con Existencia")
                        strfilter = " Existencias >0";
                    else
                        strfilter = " Existencias <1";

                    if (txtBuscar.Text != "")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Descripcion like '%" + txtBuscar.Text + "%'";
                        else
                            strfilter = " Descripcion like '%" + txtBuscar.Text + "%'";
                    }
                    if (cbxLinea.Text != "Linea(All)")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Linea ='" + cbxLinea.Text + "'";
                        else
                            strfilter = " Linea ='" + cbxLinea.Text + "'";
                    }
                    if (cbxEstado.Text != "Estado(All)")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Estado ='" + cbxEstado.Text + "'";
                        else
                            strfilter = " Estado ='" + cbxEstado.Text + "'";
                    }

                    BindingSource bs = new BindingSource();
                    bs.DataSource = dgvProductos.DataSource;
                    bs.Filter = strfilter;
                    dgvProductos.DataSource = bs.DataSource;
                }
                else
                {
                    if (txtBuscar.Text != "")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Descripcion like '%" + txtBuscar.Text + "%'";
                        else
                            strfilter = " Descripcion like '%" + txtBuscar.Text + "%'";
                    }
                    if (cbxEstado.Text != "Estado(All)")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Estado ='" + cbxEstado.Text + "'";
                        else
                            strfilter = " Estado ='" + cbxEstado.Text + "'";
                    }
                    if (cbxLinea.Text != "Linea(All)")
                    {
                        if (strfilter != "")
                            strfilter = strfilter + " And Linea ='" + cbxLinea.Text + "'";
                        else
                            strfilter = " Linea ='" + cbxLinea.Text + "'";
                    }

                    BindingSource bs = new BindingSource();
                    bs.DataSource = dgvProductos.DataSource;
                    bs.Filter = strfilter;
                    dgvProductos.DataSource = bs.DataSource;
                }

                Codigo = string.Empty;
                Estado = string.Empty;
                Existencias = 0;
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            if (Estado != string.Empty && Codigo != string.Empty)
            {
                if (Estado == "ACTIVO")
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Office2016Theme = Office2016Theme.White;
                    MessageBoxAdv.MetroColorTable.YesButtonBackColor = Color.LightGreen;
                    MessageBoxAdv.MetroColorTable.YesButtonForeColor = Color.SeaGreen;
                    MessageBoxAdv.MetroColorTable.NoButtonBackColor = Color.LightPink;
                    MessageBoxAdv.MetroColorTable.NoButtonForeColor = Color.DarkRed;

                    if (Existencias > 0)
                    {
                        MessageBoxAdv.Show("No se puede cambiar el estado a BAJA porque el producto aun tiene existencias", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBoxAdv.Show(this, "Esta seguro de deshabilitar el producto " + Codigo + "?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SQL = "Update tbProducto Set nEdoPrd = 0 Where cCodPrd='" + Codigo + "'";
                        conexMetroProductos.ejecSql(SQL);
                        MessageBoxAdv.Show("Producto Actualizado");
                    }
                    else
                    {
                        return;
                    }
                }
                if (Estado == "BAJA")
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Office2016Theme = Office2016Theme.White;
                    MessageBoxAdv.MetroColorTable.YesButtonBackColor = Color.LightGreen;
                    MessageBoxAdv.MetroColorTable.YesButtonForeColor = Color.SeaGreen;
                    MessageBoxAdv.MetroColorTable.NoButtonBackColor = Color.LightPink;
                    MessageBoxAdv.MetroColorTable.NoButtonForeColor = Color.DarkRed;
                    if (MessageBoxAdv.Show(this, "Esta seguro de habilitar el producto " + Codigo + "?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SQL = "Update tbProducto Set nEdoPrd = 1 Where cCodPrd='" + Codigo + "'";
                        conexMetroProductos.ejecSql(SQL);
                        MessageBoxAdv.Show("Producto Actualizado");
                    }
                    else
                    {
                        return;
                    }
                }
                CargaProductos();
            }
            else
            {
                MessageBoxAdv.Show("No ha seleccionado Producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProductos.ClearSelection();
            Codigo = string.Empty;
            Estado = string.Empty;

            lblcodigo.Text = string.Empty;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Excel2016;
                    IWorkbook workbook = application.Workbooks.Create(1);
                    IWorksheet worksheet = workbook.Worksheets[0];
                    //Adding text to a cell
                    for (int i = 1; i < dgvProductos.Columns.Count + 1; i++)
                    {
                        worksheet.Range[1, i].Text = dgvProductos.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgvProductos.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dgvProductos.Columns.Count; j++)
                        {
                            worksheet.Range[i + 2, j + 1].Text = dgvProductos.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    //Saving the workbook to disk in XLSX format
                    Stream excelstream = File.Create(Path.GetFullPath(@"Reporte_Productos_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".xlsx"));
                    workbook.SaveAs(excelstream);
                    excelstream.Dispose();
                }

                MessageBoxAdv.Show("Reporte Generado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            bInventario = true;

            SQL = "Select nCveAlm, cDesAlm From tbAlmacen";
            DataTable dtAlmacen = conexMetroProductos.select(SQL);

            SQL = "SELECT cCodPrd as Codigo, cDesPrd as Descripcion, cDesLin as Linea, nInvAPrd as Existencias FROM tbProducto as prod " +
                "Inner Join tbLinea lin on prod.nLinPrd = lin.nCveLin " +
                "Where nInvAPrd > 0 " +
                "ORDER BY cCodPrd";
            DataTable dtProductos = conexMetroProductos.select(SQL);

            SQL = "SELECT cCodPrd, alm.nCveAlm, nInvPrd, cPosPrd, cDesAlm FROM tbInventario inv " +
                "Inner Join tbAlmacen alm on inv.nCveAlm = alm.nCveAlm";

            DataTable dtInventario = conexMetroProductos.select(SQL);

            if (dtProductos.Rows.Count > 0)
            {
                foreach (DataRow drAlm in dtAlmacen.Rows)
                {
                    string cTemp = drAlm["cDesAlm"].ToString()!;
                    string cDes = cTemp.Replace(" ", "_");
                    string cExisAlm = "Existencias_" + cDes;

                    dtProductos.Columns.Add(cExisAlm, typeof(byte));
                }

                foreach (DataRow drInv in dtInventario.Rows)
                {
                    string cCod = drInv["cCodPrd"].ToString()!;
                    string cTemp = drInv["cDesAlm"].ToString()!;
                    string cDes = cTemp.Replace(" ", "_");
                    string cExisAlm = "Existencias_" + cDes;
                    decimal nInv = Convert.ToDecimal(drInv["nInvPrd"]);

                    DataRow filaModif = dtProductos.Select("Codigo='" + cCod + "'").FirstOrDefault()!;
                    if (filaModif != null)
                    {
                        filaModif[cExisAlm] = nInv;
                    }
                }
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = dtProductos;
            foreach (DataGridViewColumn column in dgvProductos.Columns)
            {
                string nombre = column.Name;

                if (nombre.Contains("Ex"))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void dgvProductos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!bInventario)
            {
                if (e.RowIndex > -1)
                {
                    DataGridViewCell cell = (DataGridViewCell)
                        dgvProductos.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    lblcodigo.Text = dgvProductos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString()!;

                    Estado = dgvProductos.Rows[e.RowIndex].Cells["Estado"].Value.ToString()!;
                    Codigo = dgvProductos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString()!;
                    Existencias = Convert.ToDecimal(dgvProductos.Rows[e.RowIndex].Cells["Existencias"].Value);
                }
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmProductosForm frmProductosForm = new frmProductosForm();
            frmProductosForm.ShowDialog();
        }

        private void btnLinea_Click(object sender, EventArgs e)
        {
            frmLineas frmLineas = new frmLineas();
            frmLineas.ConexLineas = conexMetroProductos;
            frmLineas.ShowDialog();
        }

        private void btnMedida_Click(object sender, EventArgs e)
        {
            frmUnidadesMedida frmUnidadesMedida = new frmUnidadesMedida();
            frmUnidadesMedida.ConexMedidas = conexMetroProductos;
            frmUnidadesMedida.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmProductos frmProductos = new frmProductos();
            frmProductos.ConexProductos = conexMetroProductos;
            frmProductos.ShowDialog();
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}