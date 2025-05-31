using MttoAdic_ERP.Forms.Almacen;
using MttoAdic_ERP.Forms.Almacen.Productos;
using Syncfusion.Windows.Forms;

namespace MttoAdic_ERP.Forms
{
    public partial class frmMenuAlmacen : MetroForm
    {
        public csConexionSQL conexMenuAlmacen;

        private Color originalColorTextolblEncabezado;

        private Color originalColorPnlInfo1;
        private Color originalColorPnlInfo2;
        private Color originalColorPnlInfo3;
        private Color originalColorPnlInfo4;

        //Colores de Etiqueta
        private Color originalColorlblTitulos;

        //Colores originales de Botones
        private Color originalColorBtnProducto;
        private Color originalColorBtnLineas;
        private Color originalColorBtnUnidades;
        private Color originalColorBtnAlmacenes;
        private Color originalColorBtnProveedores;
        private Color originalColorBtnParametros;

        private Color originalColorBtnElaboracionVales;
        private Color originalColorBtnDevolucionRefacciones;
        private Color originalColorBtnTraspasos;

        private Color originalColorBtnElaboracionPedidos;
        private Color originalColorBtnCapturaCompras;
        private Color originalColorBtnAutorizaPagos;

        private Color originalColorBtnDevolucionProveedores;
        private Color originalColorBtnSolicitudCheque;
        private Color originalColorBtnNotasCredito;
        private Color originalColorBtnNumeroSerie;



        public csConexionSQL ConexMenuAlmacen { set { this.conexMenuAlmacen = value; } }
        public frmMenuAlmacen()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            originalColorTextolblEncabezado = lblEncabezado.ForeColor;

            originalColorPnlInfo1 = pnlInfo1.BackColor;
            originalColorPnlInfo2 = pnlInfo2.BackColor;
            originalColorPnlInfo3 = pnlInfo3.BackColor;
            originalColorPnlInfo4 = pnlInfo4.BackColor;

            originalColorlblTitulos = lblCatalogos.BackColor;

            originalColorBtnProducto = btnProducto.BackColor;
            originalColorBtnLineas = btnLineas.BackColor;
            originalColorBtnUnidades = btnUnidades.BackColor;
            originalColorBtnAlmacenes = btnAlmacenes.BackColor;
            originalColorBtnProveedores = btnProveedores.BackColor;
            originalColorBtnParametros = btnParametros.BackColor;

            originalColorBtnElaboracionVales = btnElaboracionVales.BackColor;
            originalColorBtnDevolucionRefacciones = btnDevolucionRefacciones.BackColor;
            originalColorBtnTraspasos = btnTraspasos.BackColor;

            originalColorBtnElaboracionPedidos = btnElaboracionPedidos.BackColor;
            originalColorBtnCapturaCompras = btnCapturaCompras.BackColor;
            originalColorBtnAutorizaPagos = btnAutorizaPagos.BackColor;

            originalColorBtnDevolucionProveedores = btnDevolucionProveedores.BackColor;
            originalColorBtnSolicitudCheque = btnSolicitudCheque.BackColor;
            originalColorBtnNotasCredito = btnNotasCredito.BackColor;
            originalColorBtnNumeroSerie = btnNumeroSerie.BackColor;
        }

        private void cambioColorBotonesMenu(Form form)
        {
            string color = "#E4E3E1";

            //Paneles de Informacion
            lblEncabezado.ForeColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => lblEncabezado.ForeColor = originalColorTextolblEncabezado;  // Restaurar color cuando se cierra

            //Paneles de Informacion
            pnlInfo1.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => pnlInfo1.BackColor = originalColorPnlInfo1;  // Restaurar color cuando se cierra

            pnlInfo2.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => pnlInfo2.BackColor = originalColorPnlInfo2;  // Restaurar color cuando se cierra

            pnlInfo3.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => pnlInfo3.BackColor = originalColorPnlInfo3;  // Restaurar color cuando se cierra

            pnlInfo4.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => pnlInfo4.BackColor = originalColorPnlInfo4;  // Restaurar color cuando se cierra

            //etiquetas titulos
            lblCatalogos.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => lblCatalogos.BackColor = originalColorlblTitulos;  // Restaurar color cuando se cierra

            lblVales.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => lblVales.BackColor = originalColorlblTitulos;  // Restaurar color cuando se cierra

            lblCompras.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => lblCompras.BackColor = originalColorlblTitulos;  // Restaurar color cuando se cierra

            //botones
            btnProducto.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnProducto.BackColor = originalColorBtnProducto;  // Restaurar color cuando se cierra

            btnLineas.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnLineas.BackColor = originalColorBtnLineas;  // Restaurar color cuando se cierra

            btnUnidades.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnUnidades.BackColor = originalColorBtnUnidades;  // Restaurar color cuando se cierra

            btnAlmacenes.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnAlmacenes.BackColor = originalColorBtnAlmacenes;  // Restaurar color cuando se cierra

            btnProveedores.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnProveedores.BackColor = originalColorBtnProveedores;  // Restaurar color cuando se cierra

            btnParametros.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnParametros.BackColor = originalColorBtnParametros;  // Restaurar color cuando se cierra

            btnElaboracionVales.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnElaboracionVales.BackColor = originalColorBtnElaboracionVales;  // Restaurar color cuando se cierra

            btnDevolucionRefacciones.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnDevolucionRefacciones.BackColor = originalColorBtnDevolucionRefacciones;  // Restaurar color cuando se cierra

            btnTraspasos.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnTraspasos.BackColor = originalColorBtnTraspasos;  // Restaurar color cuando se cierra

            btnElaboracionPedidos.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnElaboracionPedidos.BackColor = originalColorBtnElaboracionPedidos;  // Restaurar color cuando se cierra

            btnCapturaCompras.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnCapturaCompras.BackColor = originalColorBtnCapturaCompras;  // Restaurar color cuando se cierra

            btnAutorizaPagos.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnAutorizaPagos.BackColor = originalColorBtnAutorizaPagos;  // Restaurar color cuando se cierra

            btnDevolucionProveedores.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnDevolucionProveedores.BackColor = originalColorBtnDevolucionProveedores;  // Restaurar color cuando se cierra

            btnSolicitudCheque.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnSolicitudCheque.BackColor = originalColorBtnSolicitudCheque;  // Restaurar color cuando se cierra

            btnNotasCredito.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnNotasCredito.BackColor = originalColorBtnNotasCredito;  // Restaurar color cuando se cierra

            btnNumeroSerie.BackColor = ColorTranslator.FromHtml(color);
            form.FormClosed += (s, args) => btnNumeroSerie.BackColor = originalColorBtnNumeroSerie;  // Restaurar color cuando se cierra

        }

        private void mnuProductos_Click(object sender, EventArgs e)
        {
            frmProductosIndex frmProductosIndex = new frmProductosIndex();
            cambioColorBotonesMenu(frmProductosIndex);
            frmProductosIndex.conexMetroProductos = conexMenuAlmacen;
            frmProductosIndex.ShowDialog();
        }

        private void mnuElaboracionVales_Click(object sender, EventArgs e)
        {
            frmVales frmElaboracionVales = new frmVales();
            frmElaboracionVales.ConexVales = conexMenuAlmacen;
            frmElaboracionVales.ShowDialog();
        }

        private void mnuElaboracionPedidos_Click(object sender, EventArgs e)
        {
            frmPedidos frmPedidos = new frmPedidos();
            frmPedidos.ConexPedidos = conexMenuAlmacen;
            frmPedidos.ShowDialog();
        }

        private void mnuCapturaCompras_Click(object sender, EventArgs e)
        {
            frmCompras frmCompras = new frmCompras();
            frmCompras.ConexCompras = conexMenuAlmacen;
            frmCompras.ShowDialog();
        }

        private void mnuParametros_Click(object sender, EventArgs e)
        {
            frmParametros frmParametros = new frmParametros();
            frmParametros.ConexParametros = conexMenuAlmacen;
            frmParametros.ShowDialog();
        }

        private void mnuUnidades_Click(object sender, EventArgs e)
        {
            frmUnidadesMedida frmUnidadesMedida = new frmUnidadesMedida();
            frmUnidadesMedida.ConexMedidas = conexMenuAlmacen;
            frmUnidadesMedida.ShowDialog();
        }

        private void mnuLineas_Click(object sender, EventArgs e)
        {
            frmLineas frmLineas = new frmLineas();
            frmLineas.ConexLineas = conexMenuAlmacen;
            frmLineas.ShowDialog();
        }

        private void mnuDevolucionRefacciones_Click(object sender, EventArgs e)
        {
            frmDevolucionVale frmDevolucionVale = new frmDevolucionVale();
            frmDevolucionVale.ConexDevVale = conexMenuAlmacen;
            frmDevolucionVale.ShowDialog();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuDevolucionProveedores_Click(object sender, EventArgs e)
        {
            frmDevolucionCompra frmDevolucionCompra = new frmDevolucionCompra();
            cambioColorBotonesMenu(frmDevolucionCompra);
            frmDevolucionCompra.ConexDevCompra = conexMenuAlmacen;
            frmDevolucionCompra.ShowDialog();
        }

        private void mnuProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores frmProveedores = new frmProveedores();
            cambioColorBotonesMenu(frmProveedores);
            frmProveedores.ConexProveedor = conexMenuAlmacen;
            frmProveedores.ShowDialog();
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            frmProductos frmProductos = new frmProductos();
            cambioColorBotonesMenu(frmProductos);
            frmProductos.ConexProductos = conexMenuAlmacen;
            frmProductos.ShowDialog();
        }

        private void btnLineas_Click(object sender, EventArgs e)
        {
            frmLineas frmLineas = new frmLineas();
            cambioColorBotonesMenu(frmLineas);
            frmLineas.ConexLineas = conexMenuAlmacen;
            frmLineas.ShowDialog();

            
        }

        private void btnUnidades_Click(object sender, EventArgs e)
        {
            frmUnidadesMedida frmUnidadesMedida = new frmUnidadesMedida();
            cambioColorBotonesMenu(frmUnidadesMedida);
            frmUnidadesMedida.ConexMedidas = conexMenuAlmacen;
            frmUnidadesMedida.ShowDialog();
        }

        private void btnParametros_Click(object sender, EventArgs e)
        {
            frmParametros frmParametros = new frmParametros();
            cambioColorBotonesMenu(frmParametros);
            frmParametros.ConexParametros = conexMenuAlmacen;
            frmParametros.ShowDialog();
        }

        private void btnElaboracionVales_Click(object sender, EventArgs e)
        {
            frmVales frmElaboracionVales = new frmVales();
            cambioColorBotonesMenu(frmElaboracionVales);
            frmElaboracionVales.ConexVales = conexMenuAlmacen;
            frmElaboracionVales.ShowDialog();
        }

        private void btnDevolucionRefacciones_Click(object sender, EventArgs e)
        {
            frmDevolucionVale frmDevolucionVale = new frmDevolucionVale();
            cambioColorBotonesMenu(frmDevolucionVale);
            frmDevolucionVale.ConexDevVale = conexMenuAlmacen;
            frmDevolucionVale.ShowDialog();
        }

        private void btnElaboracionPedidos_Click(object sender, EventArgs e)
        {
            frmPedidos frmPedidos = new frmPedidos();
            cambioColorBotonesMenu(frmPedidos);
            frmPedidos.ConexPedidos = conexMenuAlmacen;
            frmPedidos.ShowDialog();
        }

        private void btnCapturaCompras_Click(object sender, EventArgs e)
        {
            frmCompras frmCompras = new frmCompras();
            cambioColorBotonesMenu(frmCompras);
            frmCompras.ConexCompras = conexMenuAlmacen;
            frmCompras.ShowDialog();
        }

        private void btnDevolucionProveedores_Click(object sender, EventArgs e)
        {
            frmDevolucionCompra frmDevolucionCompra = new frmDevolucionCompra();
            cambioColorBotonesMenu(frmDevolucionCompra);
            frmDevolucionCompra.ConexDevCompra = conexMenuAlmacen;
            frmDevolucionCompra.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores frmProveedores = new frmProveedores();
            cambioColorBotonesMenu(frmProveedores);
            frmProveedores.ConexProveedor = conexMenuAlmacen;
            frmProveedores.ShowDialog();
        }
    }
}
