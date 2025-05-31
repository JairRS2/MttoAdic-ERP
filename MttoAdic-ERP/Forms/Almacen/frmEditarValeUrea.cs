using Syncfusion.Windows.Forms;
using System.Data;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class frmEditarValeUrea : MetroForm
    {
        public csConexionSQL conexEditarValeUrea;
        public csConexionSQL ConexEditarValeUrea { set { this.conexEditarValeUrea = value; } }

        string dominio = "https://mantenimientoadic2.ddns.net/";

        public int valeInicial { get; }

        string SQL = string.Empty;

        int m, mx, my;
        public frmEditarValeUrea(int vale)
        {
            InitializeComponent();
            valeInicial = vale;
        }

        private void frmEditarValeUrea_Load(object sender, EventArgs e)
        {
            //Movimiento de ventana de panel de encabezado
            pnlEncabezado.MouseDown += pnlEncabezado_MouseDown;
            pnlEncabezado.MouseMove += pnlEncabezado_MouseMove;
            pnlEncabezado.MouseUp += pnlEncabezado_MouseUp;

            lblTitulo.MouseDown += pnlEncabezado_MouseDown;
            lblTitulo.MouseMove += pnlEncabezado_MouseMove;
            lblTitulo.MouseUp += pnlEncabezado_MouseUp;
            cargaDatosVale(valeInicial);
        }

        private DataTable CargaVales(int nNumVal)
        {
            DataTable dtVales = new DataTable();

            try
            {
                SQL = "SELECT d.nNumDesp, d.cCveUni, d.cCveOpe, per.cNomPer, d.nKilometraje, d.nLitrosDespachados, " +
                    "         emp.cNomEmp, d.nNumPase, d.Observaciones, d.cFoto_Unidad, d.cFoto_Kilometraje, cFoto_Tablero_Antes_Carga, " +
                    "         cFoto_Cuenta_Litros, cFoto_Tablero_Despues_Carga, d.dtFecReg " +
                    "  FROM dbUrea.dbo.tbDespUrea d " +
                    "  INNER JOIN dbUrea.dbo.tbDespachador emp ON d.cCveEmp = emp.cCveEmp " +
                    "  INNER JOIN dbRelacionesLaborales.dbo.tbPersonal per ON d.cCveOpe = per.cCvePer " +
                    "  WHERE nNumDesp = " + nNumVal;

                dtVales = conexEditarValeUrea.select(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CargaVales " + ex.Message);
            }

            return dtVales;
        }

        void cargaDatosVale(int vale)
        {
            try
            {
                DataTable dtVale = new DataTable();
                dtVale.Clear();
                dtVale = CargaVales(vale);

                if (dtVale.Rows.Count > 0)
                {
                    txtNumDesp.Text = dtVale.Rows[0]["nNumDesp"].ToString();
                    txtUnidad.Text = dtVale.Rows[0]["cCveUni"].ToString();
                    txtNumPase.Text = dtVale.Rows[0]["nNumPase"].ToString();
                    txtDespachador.Text = dtVale.Rows[0]["cNomEmp"].ToString();
                    txtOperador.Text = dtVale.Rows[0]["cCveOpe"].ToString() + " " + dtVale.Rows[0]["cNomPer"].ToString();
                    rtbObservaciones.Text = dtVale.Rows[0]["Observaciones"].ToString();
                    txtKilometraje.Text = dtVale.Rows[0]["nKilometraje"].ToString();
                    txtLitrosDesp.Text = dtVale.Rows[0]["nLitrosDespachados"].ToString();

                    pbFotoUnidad.ImageLocation = dominio + dtVale.Rows[0]["cFoto_Unidad"].ToString();
                    pbFotoKilometraje.ImageLocation = dominio + dtVale.Rows[0]["cFoto_Kilometraje"].ToString();
                    pbFotoTAC.ImageLocation = dominio + dtVale.Rows[0]["cFoto_Tablero_Antes_Carga"].ToString();
                    pbFotoCL.ImageLocation = dominio + dtVale.Rows[0]["cFoto_Cuenta_Litros"].ToString();
                    pbFotoTDC.ImageLocation = dominio + dtVale.Rows[0]["cFoto_Tablero_Despues_Carga"].ToString();

                    pbFotoUnidad.DoubleClick += PictureBox_DoubleClick;
                    pbFotoKilometraje.DoubleClick += PictureBox_DoubleClick;
                    pbFotoTAC.DoubleClick += PictureBox_DoubleClick;
                    pbFotoCL.DoubleClick += PictureBox_DoubleClick;
                    pbFotoTDC.DoubleClick += PictureBox_DoubleClick;

                }
            }
            catch (Exception ex) { }
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null && pb.Image != null)
            {
                using (VistaPreviaImagen vista = new VistaPreviaImagen(pb.Image))
                {
                    vista.ShowDialog(); // Modal
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlEncabezado_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
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
