using System.Data;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmComplementoPago : Form
    {
        private Color originalColorBtnNuevo;
        private Color originalColorBtnGrabar;
        private Color originalColorBtnSalir;
        public int Orden { get; }
        public string Factura { get; } = null!;
        public string FolFisFactura { get; } = null!;
        
        string SQL = string.Empty;

        public decimal TotalFactura { get; }
        public decimal TotalPagos { get; }

        public decimal Resto { get; set; }

        public csConexionSQL conexComplemento;
        public csConexionSQL ConexComplemento { set { this.conexComplemento = value; } }

        public frmComplementoPago(int orden, string factura, string folfisfactura, decimal totalFactura, decimal totalPagos)
        {
            try
            {
                InitializeComponent();
                Orden = orden;
                Factura = factura;
                FolFisFactura = folfisfactura;
                TotalFactura = totalFactura;
                TotalPagos = totalPagos;
                Resto = totalFactura - totalPagos;
                txtResto.Text = Resto.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmComplementoPago " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFolio.Text != "" && txtImporte.Text != "")
                {
                    string Folio = txtFolio.Text;

                    if (Folio.Length != 36)
                    {
                        MessageBox.Show("El formato del folio fiscal no es correcto");
                        return;
                    }

                    string FolioBuscado = BuscaFolioFiscal(Folio);

                    if (FolioBuscado == Folio)
                    {
                        MessageBox.Show("Este folio fiscal ya esta capturado");
                        return;
                    } 

                    decimal Importe = Convert.ToDecimal(txtImporte.Text);

                    //validar 0
                    if(Importe <= 0)
                    {
                        MessageBox.Show("Valor Invalido, " + Importe );
                        return;
                    }

                    if (Importe > Resto) 
                    {
                        MessageBox.Show("El total de pagos no puede ser mayor al total de la factura");
                        return;

                    }
                    else
                    {
                        Resto = Resto - Importe;
                        txtResto.Text = Resto.ToString();
                    }                     

                    DateTime dFecha = dtpFolio.Value;

                    SQL = "Insert Into tbComplementoPago(nNumOrd, cFacOrd, cFolFisFac, cFolFisPago, dFecPago, nImpPago) " +
                        "Values(" + Orden + ",'" + Factura + "','" + FolFisFactura + "','" + Folio + "','" + dFecha.ToString("yyyyMMdd") + "'," + Importe + ")";

                    conexComplemento.ejecSql(SQL);
                    MessageBox.Show("Complemento de Pago registrado correctamente");
                    txtFolio.Text = string.Empty;
                    txtImporte.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnGrabar_Click " + ex.Message);
            }
        }

        private void frmComplementoPago_Load(object sender, EventArgs e)
        {
            try
            {
                originalColorBtnGrabar = btnGrabar.BackColor;
                originalColorBtnNuevo = btnNuevo.BackColor;
                btnGrabar.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                btnGrabar.Enabled = false;
                txtFolio.Enabled = false;
                txtImporte.Enabled = false;
                dtpFolio.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmComplementoPago_Load " + ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                btnNuevo.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                btnNuevo.Enabled = false;
                btnGrabar.BackColor = originalColorBtnGrabar;
                btnGrabar.Enabled = true;
                txtFolio.Text = string.Empty;
                txtImporte.Text = string.Empty;
                txtFolio.Enabled = true;
                txtImporte.Enabled = true;
                dtpFolio.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnNuevo_Click " + ex.Message);
            }
        }

        private string BuscaFolioFiscal(string ffiscal)
        {
            string FolioFiscal = string.Empty;

            try
            {
                SQL = "Select cFolFisPago From tbComplementoPago Where cFolFisPago='" + ffiscal + "'";

                DataTable dtFolioFiscal = conexComplemento.select(SQL);

                if (dtFolioFiscal.Rows.Count > 0)
                {
                    FolioFiscal = dtFolioFiscal.Rows[0]["cFolFisPago"].ToString()!;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BuscaFolioFiscal " + ex.Message);
            }

            return FolioFiscal;
        }

        private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (txtFolio.Text != "")
                    {
                        string CadenaEntera = txtFolio.Text;
                        int index = CadenaEntera.IndexOf("id=");
                        string FolioFiscal = CadenaEntera.Substring(index + 3, 36);
                        txtFolio.Text = FolioFiscal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtFolio_KeyPress " + ex.Message);
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (txtImporte.Text.Contains("."))
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("txtImporte_KeyPress " + ex.Message);
            }
        }
    }
}
