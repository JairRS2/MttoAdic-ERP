using Syncfusion.Windows.Forms;
using System.Data;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmInventarioUrea : MetroForm
    {
        private System.Windows.Forms.Timer inventarioTimer;
        string SQL = string.Empty;
        public csConexionSQL conexInventarioUrea;
        public csConexionSQL ConexInventarioUrea { set { this.conexInventarioUrea = value; } }

        int m = 0, mx, my;

        public frmInventarioUrea()
        {
            InitializeComponent();
        }

        private async void frmInventarioUrea_Load(object sender, EventArgs e)
        {
            //Movimiento de ventana de panel de encabezado
            pnlEncabezado.MouseDown += pnlEncabezado_MouseDown;
            pnlEncabezado.MouseMove += pnlEncabezado_MouseMove;
            pnlEncabezado.MouseUp += pnlEncabezado_MouseUp;

            lblTitulo.MouseDown += pnlEncabezado_MouseDown;
            lblTitulo.MouseMove += pnlEncabezado_MouseMove;
            lblTitulo.MouseUp += pnlEncabezado_MouseUp;

            //cargaDatosInventario();
            await cargaDatosInventarioAsync();
            inventarioTimer = new System.Windows.Forms.Timer();
            //inventarioTimer.Interval = 1 * 60 * 1000; // 1 minutos en milisegundos
            inventarioTimer.Interval = 10000; // 5 segundos en milisegundos
            inventarioTimer.Tick += InventarioTimer_Tick;
            inventarioTimer.Start();
        }

        private DataTable CargaInventario()
        {
            DataTable dtInventario = new DataTable();

            try
            {
                SQL = "SELECT nCveInv, cNomInv, nExiMir, nExiSis, dUltFac, nUltCos, nPreProm, nCapTan, nExiMin, nNivAlrt FROM dbUrea.dbo.tbInvUrea";

                dtInventario = conexInventarioUrea.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaInventario " + ex.Message);
            }

            return dtInventario;
        }

        private DataTable CargarCapacidadTanque()
        {
            DataTable dtInventario = new DataTable();

            try
            {
                SQL = "SELECT nCapTan FROM dbUrea.dbo.tbInvUrea";

                dtInventario = conexInventarioUrea.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaInventario " + ex.Message);
            }

            return dtInventario;
        }

        void cargaDatosInventario()
        {
            try
            {
                DataTable dtInventario = new DataTable();
                dtInventario.Clear();
                dtInventario = CargaInventario();
                if (dtInventario.Rows.Count > 0)
                {
                    decimal nCapTan = Convert.ToDecimal(dtInventario.Rows[0]["nCapTan"]);

                    decimal nExiSis = Convert.ToDecimal(dtInventario.Rows[0]["nExiSis"].ToString());
                    decimal divisionTanque = Convert.ToDecimal(dtInventario.Rows[0]["nCapTan"]) / 6;

                    decimal nCanNiv6_B = nCapTan - divisionTanque;
                    if (nExiSis > nCanNiv6_B)
                    {
                        pbxTanque.Image = Properties.Resources.TanqueLleno;
                        lblExiSis.ForeColor = ColorTranslator.FromHtml("#000000");
                        lblExiSis.BackColor = ColorTranslator.FromHtml("#209EB2");
                    }

                    decimal nCanNiv5_T = nCapTan - divisionTanque;
                    decimal nCanNiv5_B = nCapTan - divisionTanque * 2;

                    if (nExiSis <= nCanNiv5_T && nExiSis > nCanNiv5_B)
                    {
                        pbxTanque.Image = Properties.Resources.TanqueNv5;
                        lblExiSis.ForeColor = ColorTranslator.FromHtml("#000000");
                        lblExiSis.BackColor = ColorTranslator.FromHtml("#209EB2");
                    }

                    decimal nCanNiv4_T = nCapTan - divisionTanque * 2;
                    decimal nCanNiv4_B = nCapTan - divisionTanque * 3;

                    if (nExiSis <= nCanNiv4_T && nExiSis > nCanNiv4_B)
                    {
                        pbxTanque.Image = Properties.Resources.TanqueNv4;
                        lblExiSis.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                        lblExiSis.BackColor = ColorTranslator.FromHtml("#9FDE55");

                    }

                    decimal nCanNiv3_T = nCapTan - divisionTanque * 3;
                    decimal nCanNiv3_B = nCapTan - divisionTanque * 4;

                    if (nExiSis <= nCanNiv3_T && nExiSis > nCanNiv3_B)
                    {
                        pbxTanque.Image = Properties.Resources.TanqueNv3;
                        lblExiSis.ForeColor = ColorTranslator.FromHtml("#000000");
                        lblExiSis.BackColor = ColorTranslator.FromHtml("#FFFFFF");

                    }

                    decimal nCanNiv2_T = nCapTan - divisionTanque * 4;
                    decimal nCanNiv2_B = nCapTan - divisionTanque * 5;

                    if (nExiSis <= nCanNiv2_T && nExiSis > nCanNiv2_B)
                    {
                        pbxTanque.Image = Properties.Resources.TanqueNv2_Animacion;
                        lblExiSis.ForeColor = ColorTranslator.FromHtml("#000000");
                        lblExiSis.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }

                    decimal nCanNiv1_T = nCapTan - divisionTanque * 5;
                    decimal nCanNiv1_B = nCapTan - divisionTanque * 6;

                    if (nExiSis <= nCanNiv1_T && nExiSis > nCanNiv1_B)
                    {
                        pbxTanque.Image = Properties.Resources.TanqueNv1_Animacion;
                        lblExiSis.ForeColor = ColorTranslator.FromHtml("#000000");
                        lblExiSis.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }

                    if (nExiSis <= 0)
                    {
                        pbxTanque.Image = Properties.Resources.TanqueNv0_Animacion;
                        lblExiSis.ForeColor = ColorTranslator.FromHtml("#000000");
                        lblExiSis.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }

                    Decimal nNivAlrt = Convert.ToDecimal(dtInventario.Rows[0]["nNivAlrt"].ToString());
                    if (nExiSis <= nNivAlrt)
                    {
                        pbxAlerta.Image = Properties.Resources.nivelAlerta2;
                    }
                    else
                    {
                        pbxAlerta.Image = Properties.Resources.medidor;
                    }

                    lblExiSis.Text = nExiSis.ToString();
                    txtExiMir.Text = dtInventario.Rows[0]["nExiMir"].ToString();
                    DateTime dtUltFac = DateTime.Parse(dtInventario.Rows[0]["dUltFac"].ToString()!).Date;
                    txtUltFac.Text = dtUltFac.ToString("dd/MM/yyyy");
                    txtUltCos.Text = dtInventario.Rows[0]["nUltCos"].ToString();
                    txtPreProm.Text = dtInventario.Rows[0]["nPreProm"].ToString();
                }
                else
                {
                    MessageBox.Show("No se cargo correctamente el inventario");
                }

            }
            catch (Exception ex)
            {

            }
        }

        private async Task cargaDatosInventarioAsync()
        {
            try
            {
                // Si tu método cargaDatosInventario() es sincrónico y toca el UI,
                // lo mejor es simplemente llamarlo directamente aquí sin Task.Run
                cargaDatosInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error async: " + ex.Message);
            }
        }

        private void lblCapTan_Paint(object sender, PaintEventArgs e)
        {
            int nCapTan = 0;
            DataTable dtCapTan = new DataTable();
            dtCapTan.Clear();
            dtCapTan = CargarCapacidadTanque();
            if (dtCapTan.Rows.Count > 0)
            {
                nCapTan = Convert.ToInt32(Convert.ToDecimal(dtCapTan.Rows[0]["nCapTan"].ToString()));
            }

            //rotar la etiqueta de capacidad de tanque
            lblCapTan.BackColor = Color.White;
            Font miFuente = new Font("ARIAL", 14);
            Brush miBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(5, 230);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("Capacidad : " + nCapTan + " Litros", miFuente, miBrush, 0, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargaDatosInventario();
        }

        private async void InventarioTimer_Tick(object sender, EventArgs e)
        {
            await cargaDatosInventarioAsync();
        }

        private void pnlEncabezado_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
            Point punto = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
            mx = punto.X - this.Location.X;
            my = punto.Y - this.Location.Y;
        }

        private void pnlEncabezado_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void pnlEncabezado_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
