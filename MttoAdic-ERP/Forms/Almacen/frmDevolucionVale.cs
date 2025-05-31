// tamaño normal es 500 x 400
// para agregar una devolucion aumenta tamaño 1130 x 400
using Syncfusion.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmDevolucionVale : MetroForm
    {
        string strTesoreria = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\srv2kas\\Base Datos Administra_R\\Tesoreria.mdb;Jet OLEDB:Database Password=a9TnX13HHOo;";
        string SQL = string.Empty;

        DataTable dtProdVale = new DataTable();
        DataTable dtAgregados = new DataTable();
        DataTable dtEmpresa = new DataTable();

        public csConexionSQL conexDevVale;
        public csConexionSQL ConexDevVale { set { this.conexDevVale = value; } }

        public frmDevolucionVale()
        {
            InitializeComponent();
        }

        private void frmDevolucionVale_Load(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 400;

            dtProdVale.Columns.Add("Codigo", typeof(string));
            dtProdVale.Columns.Add("Cantidad", typeof(decimal));
            dtProdVale.Columns.Add("Precio", typeof(decimal));
            dtProdVale.Columns.Add("Producto", typeof(string));

            dtAgregados.Columns.Add("Codigo", typeof(string));
            dtAgregados.Columns.Add("Cantidad", typeof(decimal));
            dtAgregados.Columns.Add("Precio", typeof(decimal));
            dtAgregados.Columns.Add("Producto", typeof(string));

            CargaEmpresas();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataTable dtDevolucion = new DataTable();
                if (char.IsLetter(e.KeyChar))
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
                else if ((char)e.KeyChar == '-')
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
                    if (txtNumero.Text != "")
                    {
                        int nNumDev = Convert.ToInt32(txtNumero.Text);

                        dtDevolucion.Clear();
                        dtDevolucion = CargaDevolucion(nNumDev);

                        if (dtDevolucion.Rows.Count > 0)
                        {
                            txtVale.Text = dtDevolucion.Rows[0]["Vale"].ToString();
                            DateTime dtFecDev = DateTime.Parse(dtDevolucion.Rows[0]["Fecha"].ToString()!);
                            txtFecha.Text = dtFecDev.ToString("dd-MM-yyyy");

                            dgvProductos.DataSource = null;
                            dgvProductos.DataSource = dtDevolucion;

                            dgvProductos.Columns["Cantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Producto"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Vale"].Visible = false;
                            dgvProductos.Columns["Fecha"].Visible = false;
                            dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgvProductos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else
                        {
                            MessageBox.Show("Folio de Devolución incorrecto");
                        }
                    }
                }
                else
                {
                    txtVale.Text = string.Empty;
                    txtFecha.Text = string.Empty;
                    dgvProductos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtNumero_KeyPress " + ex.Message);
            }
        }

        private DataTable CargaDevolucion(int nNumDev)
        {
            DataTable dtDevolucion = new DataTable();

            try
            {
                    SQL = "select nNumVal as Vale, cCodPrd as Codigo, cDesPrd as Producto, " +
                        "nCtdPrd as Cantidad, nPrePrd as Precio, dFecDev as Fecha " +
                        "from tbDevolucionVale " +
                        "Where nNumDev = " + nNumDev + " " +
                        "Order by cCodPrd";

                    dtDevolucion=conexDevVale.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaDevolucion " + ex.Message);
            }

            return dtDevolucion;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscaDevolucionVale frmBuscaDevoluciones = new frmBuscaDevolucionVale();
            frmBuscaDevoluciones.ShowDialog();

            int nNumeroDev = frmBuscaDevoluciones.nNumDev;

            if (nNumeroDev > 0)
            {
                DataTable dtDevolucion = new DataTable();

                dtDevolucion.Clear();
                dtDevolucion = CargaDevolucion(nNumeroDev);

                if (dtDevolucion.Rows.Count > 0)
                {
                    txtNumero.Text = nNumeroDev.ToString();
                    txtVale.Text = dtDevolucion.Rows[0]["Vale"].ToString();
                    DateTime dtFecDev = DateTime.Parse(dtDevolucion.Rows[0]["Fecha"].ToString()!);
                    txtFecha.Text = dtFecDev.ToString("dd-MM-yyyy");

                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = dtDevolucion;

                    dgvProductos.Columns["Cantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvProductos.Columns["Codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvProductos.Columns["Producto"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvProductos.Columns["Vale"].Visible = false;
                    dgvProductos.Columns["Fecha"].Visible = false;
                    dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvProductos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    MessageBox.Show("Folio de Devolución incorrecto");
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Width = 1130;
            this.Height = 400;
            txtNumero.Text = string.Empty;
            txtNumero.Enabled = false;
            dgvProductos.DataSource = null;
            txtVale.Text = string.Empty;
            txtFecha.Text = string.Empty;
            btnNuevo.Enabled = false;
            btnBuscar.Enabled = false;
            btnSalir.Enabled = false;

            int FolioNuevo =  GeneraNuevoFolio();
            txtFolioNvo.Text = FolioNuevo.ToString();
            txtBuscaVale.Enabled = true;
            btnVale.Enabled = true;
            btnGrabar.Enabled = true;
            btnSalirNuevo.Enabled = true;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;
            dgvProdVale.Enabled = true;
            dgvProdDev.Enabled = true;
        }

        private int GeneraNuevoFolio()
        {
            int nNuevoFolio = 1;

            try
            {
                SQL = "select Top 1 nNumDev " +
                    "from tbDevolucionVale " +
                    "Order by nNumDev Desc";

                DataTable dtUltimoFolio = conexDevVale.select(SQL);

                if (dtUltimoFolio.Rows.Count > 0)
                {
                    int Nuevo = Convert.ToInt32(dtUltimoFolio.Rows[0]["nNumDev"]);

                    nNuevoFolio = Nuevo + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaDevolucion " + ex.Message);
            }

            return nNuevoFolio;
        }

        private void btnSalirNuevo_Click(object sender, EventArgs e)
        {
            this.Width = 500;
            this.Height = 400;
            txtNumero.Enabled = true;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnSalir.Enabled = true;

            dgvProdVale.DataSource = null;
            dgvProdDev.DataSource = null;
            dtProdVale.Clear();
            dtAgregados.Clear();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtFolioNvo.Text != "" && txtBuscaVale.Text != "" && txtEmpresa.Text != "" && txtCveEmpresa.Text != "" && dgvProdDev.Rows.Count > 0)
            {
                int nNumDev = Convert.ToInt32(txtFolioNvo.Text);
                bool cValidaNuevo = ValidaFolio(nNumDev);
                if (cValidaNuevo)
                {
                    MessageBox.Show("El folio ya existe.");
                    return;
                }

                byte nCveEmp = Convert.ToByte(txtCveEmpresa.Text);
                int nNumVal = Convert.ToInt32(txtBuscaVale.Text);
                byte nEdoDev = 1;
                DateTime dFecDev = DateTime.Now.Date;
                string cFacDev = "0";

                foreach (DataRow dr in dtAgregados.Rows)
                {
                    string cCodPrd = dr["Codigo"].ToString()!;
                    string cDesPrd = dr["Producto"].ToString()!;
                    decimal nCtdPrd = Convert.ToDecimal(dr["Cantidad"].ToString());
                    decimal nPrePrd = Convert.ToDecimal(dr["Precio"].ToString());
                    decimal nImporte = nCtdPrd * nPrePrd;

                    SQL = "Insert Into tbDevolucionVale (nCveEmp, nNumDev, nNumVal, cCodPrd, cDesPrd, nCtdPrd, nPrePrd, dFecDev, nEdoDev, cFacDev) " +
                        "Values (" + nCveEmp + "," + nNumDev + "," + nNumVal + ",'" + cCodPrd + "','" + cDesPrd + "'," + nCtdPrd + "," + nPrePrd + ",'" + dFecDev.ToString("yyyyMMdd") + "'," + nEdoDev + ",'" + cFacDev + "')";

                    conexDevVale.ejecSql(SQL);

                    byte nTpoKdx = 3;
                    int nNumPed = 0;
                    int NumeroSiguiente = 0;

                    decimal SaldoSiguiente = 0;
                    decimal ExistenciaSiguiente = 0;

                    int UltimoNumero = 0;
                    decimal UltimoSaldo = 0;
                    decimal UltimaExistencia = 0;

                    DataTable dtUltimoKardex = new DataTable();
                    dtUltimoKardex = UltimoKardex(cCodPrd);

                    if (dtUltimoKardex.Rows.Count > 0)
                    {
                        UltimoNumero = Convert.ToInt32(dtUltimoKardex.Rows[0]["nNumKdx"]);
                        UltimoSaldo = Convert.ToDecimal(dtUltimoKardex.Rows[0]["nSdoKdx"]);
                        UltimaExistencia = Convert.ToDecimal(dtUltimoKardex.Rows[0]["nExiKdx"]);

                        NumeroSiguiente = UltimoNumero + 1;
                        SaldoSiguiente = UltimoSaldo + nImporte;
                        ExistenciaSiguiente = UltimaExistencia + nCtdPrd;
                        decimal nCostoNuevo = SaldoSiguiente / ExistenciaSiguiente;

                        SQL = "Insert Into tbKardex (cCodPrd, cDocKdx, nCtdKdx, dFecKdx, nCveEmp, cPrvKdx, nCtoKdx, nTpoKdx, nSdoKdx, nExiKdx, nNumKdx, nNumPed) " +
                            "Values ('" + cCodPrd + "','" + nNumDev.ToString() + "'," + nCtdPrd + ",'" + dFecDev.ToString("yyyyMMdd") + "'," + nCveEmp + ",'0'," + nPrePrd + "," + nTpoKdx + "," + SaldoSiguiente + "," + ExistenciaSiguiente + "," + NumeroSiguiente + "," + nNumPed + ")";

                        bool bInsertaKardex = conexDevVale.ejecSql(SQL);

                        if (!bInsertaKardex)
                        {
                            MessageBox.Show("No fue posible actualizar el kardex del producto =" + cCodPrd);
                        }

                        SQL = "update tbProducto Set nInvAPrd=" + ExistenciaSiguiente + ", nPrePrd=" + nCostoNuevo + " Where cCodPrd = '" + cCodPrd + "'";
                        bool bActualizaInventario = conexDevVale.ejecSql(SQL);

                        if (!bActualizaInventario)
                        {
                            MessageBox.Show("No fue posible actualizar el inventario del producto =" + cCodPrd);
                        }

                        SQL = "update tbValeDetalle Set nEdoVal=3 Where nNumVal = " + nNumVal + " And cCodPrd = '" + cCodPrd + "'";
                        bool bActualizaDetalleVale = conexDevVale.ejecSql(SQL);

                        if (!bActualizaDetalleVale)
                        {
                            MessageBox.Show("No fue posible actualizar el Detalle del Vale del producto =" + cCodPrd);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto " + cCodPrd + " No tiene movimientos en el kardex");
                    }
                }

                SQL = "select cDocKdx, cCodPrd from tbkardex where cdockdx='" + nNumDev.ToString() + "' And nTpoKdx=3";

                DataTable dtKardex = conexDevVale.select(SQL);

                int nKardex = dtKardex.Rows.Count;
                if (nKardex != dtAgregados.Rows.Count)
                {
                    MessageBox.Show("No se actualizaron correctamente los datos en el kardex");
                }
                else
                {
                    MessageBox.Show("Registro grabado correctamente");
                }
            }
            else
            {
                MessageBox.Show("Falta algun valor");
                return;
            }

            this.Width = 500;
            this.Height = 400;
            txtNumero.Enabled = true;
            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnSalir.Enabled = true;

            txtFolioNvo.Text = string.Empty;
            txtBuscaVale.Text = string.Empty;
            btnVale.Enabled = false;
            txtEmpresa.Text = string.Empty;
            txtCveEmpresa.Text = string.Empty;
            txtUnidad.Text = string.Empty;
            dgvProdVale.DataSource = null;
            dgvProdDev.DataSource = null;
            btnGrabar.Enabled = false;
            btnSalirNuevo.Enabled = false;
        }

        private bool ValidaFolio(int folioNvo)
        {
            bool Existe = false;

            return Existe;
        }

        private void btnVale_Click(object sender, EventArgs e)
        {
            frmBuscaVales frmBuscaVales = new frmBuscaVales();
            frmBuscaVales.ConexBuscaVale = conexDevVale;
            frmBuscaVales.ShowDialog();

            int nNumeroVale = frmBuscaVales.nNumVale;
            txtBuscaVale.Text = nNumeroVale.ToString();

            if (nNumeroVale > 0)
            {
                DataTable dtVale = new DataTable();

                dtVale.Clear();
                dtVale = CargaVale(nNumeroVale);

                dtProdVale = dtVale;
                dtAgregados.Clear();

                if (dtVale.Rows.Count > 0)
                {
                    string cCveUni = dtVale.Rows[0]["Unidad"].ToString()!;
                    txtUnidad.Text = cCveUni;
                    int nBitaEmp = Convert.ToInt32(dtVale.Rows[0]["nCveEmp"]);

                    DataRow[] drEmp = dtEmpresa.Select("nCveEmp=" + Convert.ToInt32(nBitaEmp));
                    txtEmpresa.Text = drEmp[0][1].ToString();
                    txtCveEmpresa.Text = nBitaEmp.ToString();

                    dgvProdVale.DataSource = null;
                    dgvProdVale.DataSource = dtVale;

                    dgvProdVale.Columns["Cantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvProdVale.Columns["Codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvProdVale.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvProdVale.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvProdVale.Columns["Unidad"].Visible = false;
                    dgvProdVale.Columns["nCveEmp"].Visible = false;
                }
                else
                {
                    MessageBox.Show("Folio de Vale incorrecto");
                }
            }
            else
            {
                txtEmpresa.Text = string.Empty;
                txtCveEmpresa.Text = string.Empty;
                txtUnidad.Text = string.Empty;
                dgvProdVale.DataSource = null;
                dgvProdDev.DataSource = null;
            }
        }

        private DataTable CargaVale(int nNumeroVale)
        {
            DataTable dtVales = new DataTable();

            try
            {
                SQL = "Select det.cCodPrd as Codigo, cDesPrd as Producto, nCtdVal as Cantidad, nPreVal as Precio, cCveUni as Unidad, nCveEmp " +
                    "From ((tbValeDetalle det inner join Vales val on det.nNumVal = val.nNumVal) " +
                    "Inner Join tbProducto prd on det.cCodPrd = prd.cCodPrd) " +
                    "Where det.nEdoVal=2 And det.nNumval=" + nNumeroVale;

                dtVales = conexDevVale.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaVale " + ex.Message);
            }

            return dtVales;
        }

        private void txtBuscaVale_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataTable dtVale = new DataTable();
                if (char.IsLetter(e.KeyChar))
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
                else if ((char)e.KeyChar == '-')
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
                    if (txtBuscaVale.Text != "")
                    {
                        int nNumVale = Convert.ToInt32(txtBuscaVale.Text);

                        dtVale.Clear();
                        dtVale = CargaVale(nNumVale);

                        dtProdVale = dtVale;
                        dtAgregados.Clear();

                        if (dtVale.Rows.Count > 0)
                        {
                            string cCveUni = dtVale.Rows[0]["Unidad"].ToString()!;
                            txtUnidad.Text = cCveUni;
                            int nBitaEmp = Convert.ToInt32(dtVale.Rows[0]["nCveEmp"]);

                            DataRow[] drEmp = dtEmpresa.Select("nCveEmp=" + Convert.ToInt32(nBitaEmp));
                            txtEmpresa.Text = drEmp[0][1].ToString();
                            txtCveEmpresa.Text = nBitaEmp.ToString();

                            dgvProdVale.DataSource = null;
                            dgvProdVale.DataSource = dtVale;

                            dgvProdVale.Columns["Cantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProdVale.Columns["Codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProdVale.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgvProdVale.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgvProdVale.Columns["Unidad"].Visible = false;
                            dgvProdVale.Columns["nCveEmp"].Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Folio de Vale incorrecto");
                        }
                    }
                }
                else
                {
                    dgvProdVale.DataSource = null;
                    dtProdVale.Rows.Clear();

                    dgvProdDev.DataSource = null;
                    dgvProdDev.Rows.Clear();

                    txtEmpresa.Text = string.Empty;
                    txtUnidad.Text= string.Empty;   
                    txtCveEmpresa.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtBuscar_KeyPress " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int FilaSeleccionadaGrid = -1;
            if (dgvProdVale.Rows.Count > 0)
            {
                FilaSeleccionadaGrid = dgvProdVale.CurrentRow.Index;
            }

            if (FilaSeleccionadaGrid > -1)
            {
                string cCodPrd = dgvProdVale.Rows[FilaSeleccionadaGrid].Cells["Codigo"].Value.ToString()!;

                DataRow[] dataRow = dtProdVale.Select("Codigo='" + cCodPrd + "'");
                if (dataRow != null)
                {
                    foreach (DataRow row in dataRow)
                    {
                        DataRow rowAgrega = dtAgregados.NewRow();
                        rowAgrega["Codigo"] = row["Codigo"].ToString();
                        rowAgrega["Cantidad"] = Convert.ToDecimal(row["Cantidad"]);
                        rowAgrega["Precio"] = Convert.ToDecimal(row["Precio"]);
                        rowAgrega["Producto"] = row["Producto"];
                        dtAgregados.Rows.Add(rowAgrega);

                        dtProdVale.Rows.Remove(row);
                    }
                }

                dgvProdVale.DataSource = null;
                dgvProdVale.DataSource = dtProdVale;
                dgvProdVale.Columns["Unidad"].Visible = false;
                dgvProdVale.Columns["nCveEmp"].Visible = false;

                dgvProdDev.DataSource = null;
                dgvProdDev.DataSource = dtAgregados;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int FilaSeleccionadaGrid = -1;
            if (dgvProdDev.Rows.Count > 0)
            {
                FilaSeleccionadaGrid = dgvProdDev.CurrentRow.Index;
            }

            if (FilaSeleccionadaGrid > -1)
            {
                string cCodPrd = dgvProdDev.Rows[FilaSeleccionadaGrid].Cells["Codigo"].Value.ToString()!;

                DataRow[] dataRow = dtAgregados.Select("Codigo='" + cCodPrd + "'");
                if (dataRow != null)
                {
                    foreach (DataRow row in dataRow)
                    {
                        DataRow rowQuitar = dtProdVale.NewRow();
                        rowQuitar["Codigo"] = row["Codigo"].ToString();
                        rowQuitar["Cantidad"] = Convert.ToDecimal(row["Cantidad"]);
                        rowQuitar["Precio"] = Convert.ToDecimal(row["Precio"]);
                        rowQuitar["Producto"] = row["Producto"];
                        dtProdVale.Rows.Add(rowQuitar);

                        dtAgregados.Rows.Remove(row);
                    }
                }

                dgvProdVale.DataSource = null;
                dgvProdVale.DataSource = dtProdVale;
                dgvProdVale.Columns["Unidad"].Visible = false;
                dgvProdVale.Columns["nCveEmp"].Visible = false;

                dgvProdDev.DataSource = null;
                dgvProdDev.DataSource = dtAgregados;
            }
        }

        private DataTable UltimoKardex(string cCodPrd)
        {
            DataTable dtKardex = new DataTable();

            try
            {
                SQL = "select Top 1 cCodPrd, nNumKdx, nExiKdx, nSdoKdx From Kardex where cCodPrd = '" + cCodPrd + "' order by nNumKdx desc";

                dtKardex = conexDevVale.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("UltimoKardex " + ex.Message);
            }

            return dtKardex;
        }

        void CargaEmpresas()
        {
            try
            {
                using (OleDbConnection connectionTeso = new OleDbConnection(strTesoreria))
                {
                    connectionTeso.Open();

                    SQL = "SELECT nCveEmp,cNomEmp FROM Empresa order by nCveEmp";

                    OleDbCommand commandEmpresa = new OleDbCommand(SQL, connectionTeso);

                    OleDbDataReader readerEmpresa = commandEmpresa.ExecuteReader();

                    dtEmpresa.Load(readerEmpresa);

                    connectionTeso.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaEmpresas " + ex.Message);
            }
        }
    }
}

