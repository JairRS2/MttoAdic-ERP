using Syncfusion.Windows.Forms;
using System.Data;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmDevolucionCompra : MetroForm
    {
        string SQL = string.Empty;

        DataTable dtProdFactura = new DataTable();
        DataTable dtProdFacturaOrig = new DataTable();
        DataTable dtAgregados = new DataTable();

        public csConexionSQL conexDevCompra;
        public csConexionSQL ConexDevCompra { set { this.conexDevCompra = value; } }

        public frmDevolucionCompra()
        {
            InitializeComponent();
        }

        private void frmDevolucionCompra_Load(object sender, EventArgs e)
        {
            CargaProveedor();
            this.Width = 500;
            this.Height = 400;
            dtProdFactura.Columns.Add("Orden", typeof(int));
            dtProdFactura.Columns.Add("Codigo", typeof(string));
            dtProdFactura.Columns.Add("Producto", typeof(string));
            dtProdFactura.Columns.Add("Cantidad", typeof(decimal));
            dtProdFactura.Columns.Add("Costo", typeof(decimal));
            dtProdFactura.Columns.Add("Importe", typeof(decimal));

            dtAgregados.Columns.Add("Orden", typeof(int));
            dtAgregados.Columns.Add("Codigo", typeof(string));
            dtAgregados.Columns.Add("Producto", typeof(string));
            dtAgregados.Columns.Add("Cantidad", typeof(decimal));
            dtAgregados.Columns.Add("Costo", typeof(decimal));
            dtAgregados.Columns.Add("Importe", typeof(decimal));
        }

        private void CargaProveedor()
        {
            try
            {
                SQL = "SELECT ccveprv, cnomprv FROM dbProveedores.dbo.tbProveedor ORDER BY cnomprv";

                DataTable dtProveedor = conexDevCompra.select(SQL);

                cboProveedor.DataSource = null;
                cboProveedor.DataSource = dtProveedor;
                cboProveedor.DisplayMember = "cNomPrv";
                cboProveedor.ValueMember = "cCvePrv";
                cboProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaProveedor " + ex.Message);
            }
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
                            txtFactura.Text = dtDevolucion.Rows[0]["Factura"].ToString();
                            DateTime dtFecDev = DateTime.Parse(dtDevolucion.Rows[0]["Fecha"].ToString()!);
                            txtFecha.Text = dtFecDev.ToString("dd-MM-yyyy");
                            txtProveedor.Text = dtDevolucion.Rows[0]["Proveedor"].ToString();
                            decimal Total = Convert.ToDecimal(dtDevolucion.Rows[0]["Total"]);
                            txtTotalDev.Text = Total.ToString("N2");

                            dgvProductos.DataSource = null;
                            dgvProductos.DataSource = dtDevolucion;

                            dgvProductos.Columns["Cantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Producto"].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgvProductos.Columns["Costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgvProductos.Columns["Fecha"].Visible = false;
                            dgvProductos.Columns["Proveedor"].Visible = false;
                            dgvProductos.Columns["Total"].Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Folio de Devolución incorrecto");
                        }
                    }
                }
                else
                {
                    txtFactura.Text = string.Empty;
                    txtFecha.Text = string.Empty;
                    txtProveedor.Text = string.Empty;
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
                SQL = "select nNumDvp as Devolucion, cFacDvp as Factura, cPrvDvp + '--' + cNomDvp as Proveedor, cCodPrd as Codigo, cDesPrd as Producto, " +
                    "nCtdDvp as Cantidad, nCtoDvp as Costo, nCtdDvp * nCtoDvp as Importe, dFecDvp as Fecha, nTotDvp as Total " +
                    "from tbDevolucionCompra " +
                    "Where nNumDvp = " + nNumDev + " " +
                    "Order by cCodPrd";

                dtDevolucion = conexDevCompra.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaDevolucion " + ex.Message);
            }

            return dtDevolucion;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Width = 1130;
            this.Height = 400;
            txtNumero.Text = string.Empty;
            txtNumero.Enabled = false;
            dgvProductos.DataSource = null;
            txtFactura.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtProveedor.Text = string.Empty;
            btnNuevo.Enabled = false;
            btnBuscar.Enabled = false;
            btnSalir.Enabled = false;

            int FolioNuevo = GeneraNuevoFolio();
            txtFolioNvo.Text = FolioNuevo.ToString();
            cboProveedor.SelectedIndex = -1;
            cboFactura.DataSource = null;
            dgvProdFactura.DataSource = null;
            dgvProdDev.DataSource = null;
            btnGrabar.Enabled = true;
            btnSalirNuevo.Enabled = true;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;
            dgvProdFactura.Enabled = true;
            dgvProdDev.Enabled = true;
        }

        private int GeneraNuevoFolio()
        {
            DataTable dtUltimoFolio = new DataTable();
            int nNuevoFolio = 1;
            try
            {
                SQL = "select Top 1 nNumDvp " +
                    "from tbDevolucionCompra " +
                    "Order by nNumDvp Desc";

                dtUltimoFolio = conexDevCompra.select(SQL);

                if (dtUltimoFolio.Rows.Count > 0)
                {
                    int Nuevo = Convert.ToInt32(dtUltimoFolio.Rows[0]["nNumDvp"]);

                    nNuevoFolio = Nuevo + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GeneraNuevoFolio " + ex.Message);
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

            dgvProdFactura.DataSource = null;
            dgvProdDev.DataSource = null;
            dtProdFactura.Clear();
            dtAgregados.Clear();
            txtTotal.Text = "0";
        }

        private DataTable CargaCompra(string Proveedor, string Factura)
        {
            DataTable dtCompra = new DataTable();

            try
            {
                SQL = "Select nNumOrd as Orden, det.cCodPrd as Codigo, cDesPrd as Producto, nCtdOrd as Cantidad, nCtoOrd as Costo, nCtdOrd * nCtoOrd as Importe " +
                    "From OrdenDetalle det Inner Join Productos prd on det.cCodPrd = prd.cCodPrd " +
                    "Where det.nEdoOrd = 2 And det.cFacOrd = '" + Factura + "' and cPrvOrd='" + Proveedor + "'";

                dtCompra = conexDevCompra.select(SQL);

                dtProdFacturaOrig = conexDevCompra.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaCompra " + ex.Message);
            }

            return dtCompra;
        }

        private void cboFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFactura.Focused)
            {
                if (cboFactura.SelectedIndex > -1)
                {
                    DataTable dtFactura = new DataTable();

                    string cFactura = cboFactura.Text;
                    string cProveedor = cboProveedor.SelectedValue!.ToString()!;

                    dtFactura.Clear();
                    dtFactura = CargaCompra(cProveedor, cFactura);

                    dtProdFactura = dtFactura;
                    dtAgregados.Clear();

                    if (dtFactura.Rows.Count > 0)
                    {
                        dgvProdFactura.DataSource = null;
                        dgvProdFactura.DataSource = dtFactura;

                        dgvProdFactura.Columns["Cantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dgvProdFactura.Columns["Codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dgvProdFactura.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvProdFactura.Columns["Costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else
                    {
                        MessageBox.Show("Productos no encontrados de esta factura");
                    }
                    txtTotal.Text = "0";
                }
            }
        }

        private bool ValidaFolio(int folioNvo)
        {
            bool Existe = false;

            SQL = "SELECT nNumDvp FROM tbDevolucionCompra WHERE nNumDvp=" + folioNvo;

            DataTable dtFolio = conexDevCompra.select(SQL);

            if (dtFolio.Rows.Count > 0)
            {
                Existe = true;
            }

            return Existe;
        }

        private void cboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProveedor.Focused)
            {
                if (cboProveedor.SelectedIndex > -1)
                {
                    CargaFacturas(cboProveedor.SelectedValue!.ToString()!);

                    dgvProdFactura.DataSource = null;
                    dgvProdDev.DataSource = null;
                    dtProdFactura.Clear();
                    dtAgregados.Clear();
                }
            }
        }

        private void CargaFacturas(string proveedor)
        {
            try
            {
                SQL = "SELECT cNumFac FROM tbFacturacion WHERE cPrvFac='" + proveedor + "'";

                DataTable dtFacturas = conexDevCompra.select(SQL);
                cboFactura.DataSource = null;
                cboFactura.DataSource = dtFacturas;
                cboFactura.DisplayMember = "cNumFac";
                cboFactura.ValueMember = "cNumFac";
                cboFactura.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaFacturas " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int FilaSeleccionadaGrid = -1;
            if (dgvProdFactura.Rows.Count > 0)
            {
                FilaSeleccionadaGrid = dgvProdFactura.CurrentRow.Index;
            }

            if (FilaSeleccionadaGrid > -1)
            {
                string cCodPrd = dgvProdFactura.Rows[FilaSeleccionadaGrid].Cells["Codigo"].Value.ToString()!;

                DataRow[] dataRow = dtProdFactura.Select("Codigo='" + cCodPrd + "'");
                var x = dtProdFacturaOrig;

                if (dataRow != null)
                {
                    foreach (DataRow row in dataRow)
                    {
                        DataRow rowAgrega = dtAgregados.NewRow();
                        rowAgrega["Orden"] = Convert.ToInt32(row["Orden"]);
                        rowAgrega["Codigo"] = row["Codigo"].ToString();
                        rowAgrega["Producto"] = row["Producto"];
                        rowAgrega["Cantidad"] = Convert.ToDecimal(row["Cantidad"]);
                        rowAgrega["Costo"] = Convert.ToDecimal(row["Costo"]);
                        rowAgrega["Importe"] = Convert.ToDecimal(row["Importe"]);
                        dtAgregados.Rows.Add(rowAgrega);

                        dtProdFactura.Rows.Remove(row);
                    }
                }

                dgvProdFactura.DataSource = null;
                dgvProdFactura.DataSource = dtProdFactura;

                dgvProdDev.DataSource = null;
                dgvProdDev.DataSource = dtAgregados;
                dgvProdDev.Columns["Orden"].ReadOnly = true;
                dgvProdDev.Columns["Codigo"].ReadOnly = true;
                dgvProdDev.Columns["Costo"].ReadOnly = true;
                dgvProdDev.Columns["Producto"].ReadOnly = true;
                dgvProdDev.Columns["Cantidad"].ReadOnly = false;

                decimal nTotal = 0;
                foreach (DataRow row in dtAgregados.Rows)
                {
                    decimal Cantidad = Convert.ToDecimal(row["Cantidad"]);
                    decimal Precio = Convert.ToDecimal(row["Costo"]);
                    decimal Importe = Cantidad * Precio;
                    nTotal += Importe;
                }
                txtTotal.Text = nTotal.ToString("N2");
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
                        DataRow rowQuitar = dtProdFactura.NewRow();
                        rowQuitar["Orden"] = Convert.ToInt32(row["Orden"]);
                        rowQuitar["Codigo"] = row["Codigo"].ToString();
                        rowQuitar["Producto"] = row["Producto"];
                        rowQuitar["Cantidad"] = Convert.ToDecimal(row["Cantidad"]);
                        rowQuitar["Costo"] = Convert.ToDecimal(row["Costo"]);
                        rowQuitar["Importe"] = Convert.ToDecimal(row["Importe"]);
                        dtProdFactura.Rows.Add(rowQuitar);

                        dtAgregados.Rows.Remove(row);
                    }
                }

                dgvProdFactura.DataSource = null;
                dgvProdFactura.DataSource = dtProdFactura;

                dgvProdDev.DataSource = null;
                dgvProdDev.DataSource = dtAgregados;

                decimal nTotal = 0;
                foreach (DataRow row in dtAgregados.Rows)
                {
                    decimal Cantidad = Convert.ToDecimal(row["Cantidad"]);
                    decimal Costo = Convert.ToDecimal(row["Costo"]);
                    decimal Importe = Cantidad * Costo;
                    nTotal += Importe;
                }
                txtTotal.Text = nTotal.ToString("N2");
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtFolioNvo.Text != "" && cboProveedor.SelectedIndex > -1 && cboFactura.SelectedIndex > -1 && dgvProdDev.Rows.Count > 0)
            {
                int nNumDev = Convert.ToInt32(txtFolioNvo.Text);
                bool cValidaNuevo = ValidaFolio(nNumDev);
                if (cValidaNuevo)
                {
                    MessageBox.Show("El folio ya existe.");
                    return;
                }

                string cFacDev = cboFactura.SelectedValue!.ToString()!;
                DateTime dFecDev = DateTime.Now.Date;
                string cPrvDvp = cboProveedor.SelectedValue!.ToString()!;
                string cNomDvp = cboProveedor.Text;
                byte nCveEmp = 2;

                foreach (DataRow dr in dtAgregados.Rows)
                {
                    string cCodPrd = dr["Codigo"].ToString()!;
                    string cDesPrd = dr["Producto"].ToString()!;
                    decimal nCtdDvp = Convert.ToDecimal(dr["Cantidad"].ToString());
                    decimal nCtoDvp = Convert.ToDecimal(dr["Costo"].ToString());
                    decimal nImporte = nCtdDvp * nCtoDvp;

                    SQL = "Insert Into tbDevolucionCompra (nNumDvp, dFecDvp, cPrvDvp, cNomDvp, nCtdDvp, cCodPrd, nCveEmp, nTotDvp, cDesPrd, nCtoDvp, cFacDvp) " +
                        "Values (" + nNumDev + ",'" + dFecDev.ToString("yyyyMMdd") + "','" + cPrvDvp + "','" + cNomDvp + "'," + nCtdDvp + ",'" + cCodPrd + "'," + nCveEmp + "," + nImporte + ",'" + cDesPrd + "'," + nCtoDvp + ",'" + cFacDev + "')";

                    conexDevCompra.ejecSql(SQL);

                    byte nTpoKdx = 8;
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
                        SaldoSiguiente = UltimoSaldo - nImporte;
                        ExistenciaSiguiente = UltimaExistencia - nCtdDvp;
                        decimal nCostoNuevo = SaldoSiguiente / ExistenciaSiguiente;

                        SQL = "Insert Into tbKardex (cCodPrd, cDocKdx, nCtdKdx, dFecKdx, nCveEmp, cPrvKdx, nCtoKdx, nTpoKdx, nSdoKdx, nExiKdx, nNumKdx, nNumPed) " +
                            "Values ('" + cCodPrd + "','" + nNumDev.ToString() + "'," + nCtdDvp + ",'" + dFecDev.ToString("yyyyMMdd") + "'," + nCveEmp + ",'0'," + nCtoDvp + "," + nTpoKdx + "," + SaldoSiguiente + "," + ExistenciaSiguiente + "," + NumeroSiguiente + "," + nNumPed + ")";

                        bool bInsertaKardex = conexDevCompra.ejecSql(SQL);

                        if (!bInsertaKardex)
                        {
                            MessageBox.Show("No fue posible actualizar el kardex del producto =" + cCodPrd);
                        }

                        SQL = "update tbProducto Set nInvAPrd=" + ExistenciaSiguiente + ", nPrePrd=" + nCostoNuevo + " Where cCodPrd = '" + cCodPrd + "'";
                        bool bActualizaInventario = conexDevCompra.ejecSql(SQL);

                        if (!bActualizaInventario)
                        {
                            MessageBox.Show("No fue posible actualizar el inventario del producto =" + cCodPrd);
                        }

                        int nNumOrd = Convert.ToInt32(dr["Orden"]);
                        SQL = "Update tbOrdenDetalle set nEdoOrd=5 where cCodPrd = '" + cCodPrd + "' and nNumOrd=" + nNumOrd;

                        bool bActualizaDetalleVale = conexDevCompra.ejecSql(SQL);

                        if (!bActualizaDetalleVale)
                        {
                            MessageBox.Show("No fue posible actualizar el Detalle del la orden del producto =" + cCodPrd);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto " + cCodPrd + " No tiene movimientos en el kardex");
                    }
                }
                SQL = "select cDocKdx, cCodPrd from tbkardex where cdockdx='" + nNumDev.ToString() + "' And nTpoKdx=8";

                DataTable dtKardex = conexDevCompra.select(SQL);

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
            cboProveedor.SelectedIndex = -1;
            cboFactura.SelectedIndex = -1;
            dgvProdFactura.DataSource = null;
            dgvProdDev.DataSource = null;
            btnGrabar.Enabled = false;
            btnSalirNuevo.Enabled = false;
        }

        private DataTable UltimoKardex(string cCodPrd)
        {
            DataTable dtKardex = new DataTable();

            try
            {
                SQL = "select Top 1 cCodPrd, nNumKdx, nExiKdx, nSdoKdx From tbKardex where cCodPrd = '" + cCodPrd + "' order by nNumKdx desc";

                dtKardex = conexDevCompra.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("UltimoKardex " + ex.Message);
            }

            return dtKardex;
        }

        private void dgvProdDev_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                int FilaSeleccionadaGrid = dgvProdDev.CurrentCell.RowIndex;
                decimal testDecimal;
                if (e.ColumnIndex == 3)
                {
                    if (e.FormattedValue!.ToString()!.Length != 0)
                    {
                        if (!decimal.TryParse(e.FormattedValue.ToString(), out testDecimal))
                        {
                            dgvProdDev.Rows[e.RowIndex].ErrorText = "Dato no Valido";
                            e.Cancel = true;
                        }
                        else
                        {
                            dgvProdDev.Rows[e.RowIndex].ErrorText = string.Empty;
                            e.Cancel = false;

                            decimal nvoCantidad = Convert.ToDecimal(e.FormattedValue.ToString());

                            string Codigo = dgvProdDev.Rows[FilaSeleccionadaGrid].Cells["Codigo"].Value.ToString()!;
                            int Orden = Convert.ToInt32(dgvProdDev.Rows[FilaSeleccionadaGrid].Cells["Orden"].Value);

                            DataRow[] RowOrig = dtProdFacturaOrig.Select("Orden=" + Orden + " and Codigo='" + Codigo + "'");

                            decimal CantOrig = Convert.ToDecimal(RowOrig[0]["Cantidad"]);

                            if (nvoCantidad != CantOrig)
                            {
                                if (nvoCantidad < CantOrig)
                                {
                                    dgvProdDev.Rows[FilaSeleccionadaGrid].Cells[3].Style.BackColor = Color.Red;
                                }
                                if (nvoCantidad > CantOrig)
                                {
                                    dgvProdDev.Rows[e.RowIndex].ErrorText = "Cantidad mayor a la compra";
                                    e.Cancel = true;
                                }
                                if (nvoCantidad == 0)
                                {
                                    dgvProdDev.Rows[e.RowIndex].ErrorText = "Cantidad incorrecta";
                                    e.Cancel = true;
                                }
                            }
                            else
                            {
                                dgvProdDev.Rows[FilaSeleccionadaGrid].Cells[3].Style.BackColor = Color.White;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("dgvProdDev_CellValidating");
            }
        }

        private void dgvProdDev_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int FilaSeleccionadaGrid = dgvProdDev.CurrentCell.RowIndex;
            decimal nCosto = Convert.ToDecimal(dgvProdDev.Rows[FilaSeleccionadaGrid].Cells[4].Value);
            decimal nCantidad = Convert.ToDecimal(dgvProdDev.Rows[FilaSeleccionadaGrid].Cells[3].Value);
            decimal nImporte = nCosto * nCantidad;
            dgvProdDev.Rows[FilaSeleccionadaGrid].Cells[5].Value = nImporte;

            decimal nTotal = 0;
            foreach (DataGridViewRow item in dgvProdDev.Rows)
            {
                nTotal += Convert.ToDecimal(item.Cells["Importe"].Value);
            }
            txtTotal.Text = nTotal.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscaDevolucionCompra frmBuscaDevoluciones = new frmBuscaDevolucionCompra();
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
                    txtFactura.Text = dtDevolucion.Rows[0]["Factura"].ToString();
                    DateTime dtFecDev = DateTime.Parse(dtDevolucion.Rows[0]["Fecha"].ToString()!);
                    txtFecha.Text = dtFecDev.ToString("dd-MM-yyyy");
                    txtProveedor.Text = dtDevolucion.Rows[0]["Proveedor"].ToString();

                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = dtDevolucion;

                    dgvProductos.Columns["Cantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvProductos.Columns["Codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvProductos.Columns["Producto"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvProductos.Columns["Devolucion"].Visible = false;
                    dgvProductos.Columns["Fecha"].Visible = false;
                    dgvProductos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvProductos.Columns["Costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    MessageBox.Show("Folio de Devolución incorrecto");
                }
            }
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

