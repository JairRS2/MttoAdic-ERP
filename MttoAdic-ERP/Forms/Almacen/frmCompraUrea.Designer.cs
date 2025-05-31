namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmCompraUrea
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompraUrea));
            groupBox1 = new GroupBox();
            cboProveedor = new ComboBox();
            label3 = new Label();
            dtpOrden = new DateTimePicker();
            txtEstado = new TextBox();
            label2 = new Label();
            txtNumero = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label19 = new Label();
            lblDescto = new Label();
            txtDescuento = new TextBox();
            label11 = new Label();
            btnAplicar = new CustomRenderer.BotonRedondeado();
            label12 = new Label();
            label10 = new Label();
            label9 = new Label();
            txtTotal = new TextBox();
            txtIva = new TextBox();
            txtSubtotal = new TextBox();
            txtPorcentaje = new TextBox();
            label7 = new Label();
            cboTipo = new ComboBox();
            label6 = new Label();
            txtCosto = new TextBox();
            label5 = new Label();
            txtLitros = new TextBox();
            label4 = new Label();
            groupBox3 = new GroupBox();
            label15 = new Label();
            txtFolioFiscal = new TextBox();
            dtpFactura = new DateTimePicker();
            label14 = new Label();
            txtFactura = new TextBox();
            label13 = new Label();
            groupBox4 = new GroupBox();
            txtPagoResto = new TextBox();
            label8 = new Label();
            btnAgregarPago = new CustomRenderer.BotonRedondeado();
            txtTotalPagos = new TextBox();
            label16 = new Label();
            dgvPagos = new DataGridView();
            groupBox5 = new GroupBox();
            btnSalir = new CustomRenderer.BotonRedondeado();
            btnImprimir = new CustomRenderer.BotonRedondeado();
            btnDeshacer = new CustomRenderer.BotonRedondeado();
            btnGrabar = new CustomRenderer.BotonRedondeado();
            btnModificar = new CustomRenderer.BotonRedondeado();
            btnNuevo = new CustomRenderer.BotonRedondeado();
            label17 = new Label();
            txtBuscar = new TextBox();
            pnlEncabezado = new Panel();
            btnMinimizar = new CustomRenderer.BotonRedondeado();
            lblTitulo = new Label();
            printCompraUrea = new System.Drawing.Printing.PrintDocument();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            groupBox5.SuspendLayout();
            pnlEncabezado.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboProveedor);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpOrden);
            groupBox1.Controls.Add(txtEstado);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtNumero);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(14, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(616, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // cboProveedor
            // 
            cboProveedor.BackColor = Color.White;
            cboProveedor.ForeColor = Color.Black;
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Location = new Point(88, 61);
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new Size(516, 25);
            cboProveedor.TabIndex = 6;
            cboProveedor.KeyPress += cboProveedor_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F);
            label3.Location = new Point(6, 69);
            label3.Name = "label3";
            label3.Size = new Size(77, 17);
            label3.TabIndex = 5;
            label3.Text = "Proveedor :";
            // 
            // dtpOrden
            // 
            dtpOrden.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpOrden.Format = DateTimePickerFormat.Short;
            dtpOrden.Location = new Point(496, 24);
            dtpOrden.Name = "dtpOrden";
            dtpOrden.Size = new Size(108, 22);
            dtpOrden.TabIndex = 4;
            // 
            // txtEstado
            // 
            txtEstado.BackColor = SystemColors.Control;
            txtEstado.Location = new Point(247, 22);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(121, 22);
            txtEstado.TabIndex = 3;
            txtEstado.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F);
            label2.Location = new Point(384, 28);
            label2.Name = "label2";
            label2.Size = new Size(110, 17);
            label2.TabIndex = 2;
            label2.Text = "Fecha de Orden :";
            // 
            // txtNumero
            // 
            txtNumero.BackColor = SystemColors.Control;
            txtNumero.Location = new Point(132, 22);
            txtNumero.Name = "txtNumero";
            txtNumero.ReadOnly = true;
            txtNumero.Size = new Size(94, 22);
            txtNumero.TabIndex = 1;
            txtNumero.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F);
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(120, 17);
            label1.TabIndex = 0;
            label1.Text = "Numero de Orden :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(lblDescto);
            groupBox2.Controls.Add(txtDescuento);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(btnAplicar);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtTotal);
            groupBox2.Controls.Add(txtIva);
            groupBox2.Controls.Add(txtSubtotal);
            groupBox2.Controls.Add(txtPorcentaje);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(cboTipo);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtCosto);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtLitros);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(14, 151);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(616, 150);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(255, 70);
            label19.Name = "label19";
            label19.Size = new Size(37, 16);
            label19.TabIndex = 33;
            label19.Text = "( % ) :";
            // 
            // lblDescto
            // 
            lblDescto.AutoSize = true;
            lblDescto.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescto.Location = new Point(490, 53);
            lblDescto.Name = "lblDescto";
            lblDescto.Size = new Size(37, 16);
            lblDescto.TabIndex = 32;
            lblDescto.Text = "( % ) :";
            // 
            // txtDescuento
            // 
            txtDescuento.BackColor = SystemColors.Control;
            txtDescuento.Location = new Point(534, 48);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.ReadOnly = true;
            txtDescuento.Size = new Size(70, 22);
            txtDescuento.TabIndex = 31;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 9F);
            label11.Location = new Point(433, 53);
            label11.Name = "label11";
            label11.Size = new Size(51, 17);
            label11.TabIndex = 24;
            label11.Text = "Descto";
            // 
            // btnAplicar
            // 
            btnAplicar.BackColor = Color.CornflowerBlue;
            btnAplicar.BackgroundColor = Color.CornflowerBlue;
            btnAplicar.BorderColor = Color.PaleVioletRed;
            btnAplicar.BorderRadius = 15;
            btnAplicar.BorderSize = 0;
            btnAplicar.FlatAppearance.BorderSize = 0;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAplicar.ForeColor = Color.White;
            btnAplicar.Location = new Point(347, 63);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(72, 23);
            btnAplicar.TabIndex = 23;
            btnAplicar.Text = "Aplicar";
            btnAplicar.TextColor = Color.White;
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 9F);
            label12.Location = new Point(433, 115);
            label12.Name = "label12";
            label12.Size = new Size(43, 17);
            label12.TabIndex = 16;
            label12.Text = "Total :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 9F);
            label10.Location = new Point(433, 86);
            label10.Name = "label10";
            label10.Size = new Size(33, 17);
            label10.TabIndex = 21;
            label10.Text = "Iva :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 9F);
            label9.Location = new Point(433, 28);
            label9.Name = "label9";
            label9.Size = new Size(65, 17);
            label9.TabIndex = 15;
            label9.Text = "Subtotal :";
            // 
            // txtTotal
            // 
            txtTotal.BackColor = SystemColors.Control;
            txtTotal.Location = new Point(490, 107);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(114, 22);
            txtTotal.TabIndex = 20;
            // 
            // txtIva
            // 
            txtIva.BackColor = SystemColors.Control;
            txtIva.Location = new Point(490, 78);
            txtIva.Name = "txtIva";
            txtIva.ReadOnly = true;
            txtIva.Size = new Size(114, 22);
            txtIva.TabIndex = 18;
            // 
            // txtSubtotal
            // 
            txtSubtotal.BackColor = SystemColors.Control;
            txtSubtotal.Location = new Point(514, 20);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(90, 22);
            txtSubtotal.TabIndex = 17;
            // 
            // txtPorcentaje
            // 
            txtPorcentaje.Location = new Point(294, 63);
            txtPorcentaje.Name = "txtPorcentaje";
            txtPorcentaje.Size = new Size(50, 22);
            txtPorcentaje.TabIndex = 12;
            txtPorcentaje.KeyPress += txtPorcentaje_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9F);
            label7.Location = new Point(206, 69);
            label7.Name = "label7";
            label7.Size = new Size(51, 17);
            label7.TabIndex = 11;
            label7.Text = "Descto";
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(79, 63);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(112, 25);
            cboTipo.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F);
            label6.Location = new Point(6, 70);
            label6.Name = "label6";
            label6.Size = new Size(72, 17);
            label6.TabIndex = 10;
            label6.Text = "Tipo Pago :";
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(313, 20);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(109, 22);
            txtCosto.TabIndex = 9;
            txtCosto.TextChanged += txtCosto_TextChanged;
            txtCosto.KeyPress += txtCosto_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F);
            label5.Location = new Point(206, 28);
            label5.Name = "label5";
            label5.Size = new Size(101, 17);
            label5.TabIndex = 8;
            label5.Text = "Costo por Litro :";
            // 
            // txtLitros
            // 
            txtLitros.BackColor = SystemColors.Window;
            txtLitros.Location = new Point(54, 20);
            txtLitros.Name = "txtLitros";
            txtLitros.Size = new Size(137, 22);
            txtLitros.TabIndex = 7;
            txtLitros.TextChanged += txtLitros_TextChanged;
            txtLitros.KeyPress += txtLitros_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F);
            label4.Location = new Point(6, 28);
            label4.Name = "label4";
            label4.Size = new Size(45, 17);
            label4.TabIndex = 7;
            label4.Text = "Litros :";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(txtFolioFiscal);
            groupBox3.Controls.Add(dtpFactura);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(txtFactura);
            groupBox3.Controls.Add(label13);
            groupBox3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(12, 307);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(618, 96);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Datos de factura";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(8, 63);
            label15.Name = "label15";
            label15.Size = new Size(78, 17);
            label15.TabIndex = 26;
            label15.Text = "Folio Fiscal :";
            // 
            // txtFolioFiscal
            // 
            txtFolioFiscal.Location = new Point(90, 58);
            txtFolioFiscal.Name = "txtFolioFiscal";
            txtFolioFiscal.Size = new Size(516, 22);
            txtFolioFiscal.TabIndex = 25;
            txtFolioFiscal.KeyPress += txtFolioFiscal_KeyPress;
            // 
            // dtpFactura
            // 
            dtpFactura.Format = DateTimePickerFormat.Short;
            dtpFactura.Location = new Point(250, 23);
            dtpFactura.Name = "dtpFactura";
            dtpFactura.Size = new Size(104, 22);
            dtpFactura.TabIndex = 7;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(193, 28);
            label14.Name = "label14";
            label14.Size = new Size(51, 17);
            label14.TabIndex = 24;
            label14.Text = "Fecha :";
            // 
            // txtFactura
            // 
            txtFactura.Location = new Point(72, 23);
            txtFactura.Name = "txtFactura";
            txtFactura.Size = new Size(104, 22);
            txtFactura.TabIndex = 23;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 28);
            label13.Name = "label13";
            label13.Size = new Size(60, 17);
            label13.TabIndex = 23;
            label13.Text = "Factura :";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtPagoResto);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(btnAgregarPago);
            groupBox4.Controls.Add(txtTotalPagos);
            groupBox4.Controls.Add(label16);
            groupBox4.Controls.Add(dgvPagos);
            groupBox4.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(12, 409);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(618, 156);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Complementos de Pago";
            // 
            // txtPagoResto
            // 
            txtPagoResto.BackColor = SystemColors.Control;
            txtPagoResto.Location = new Point(291, 122);
            txtPagoResto.Name = "txtPagoResto";
            txtPagoResto.ReadOnly = true;
            txtPagoResto.Size = new Size(100, 22);
            txtPagoResto.TabIndex = 30;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(174, 127);
            label8.Name = "label8";
            label8.Size = new Size(111, 17);
            label8.TabIndex = 29;
            label8.Text = "Pago Restante $ :";
            // 
            // btnAgregarPago
            // 
            btnAgregarPago.BackColor = Color.CornflowerBlue;
            btnAgregarPago.BackgroundColor = Color.CornflowerBlue;
            btnAgregarPago.BorderColor = Color.PaleVioletRed;
            btnAgregarPago.BorderRadius = 40;
            btnAgregarPago.BorderSize = 0;
            btnAgregarPago.FlatAppearance.BorderSize = 0;
            btnAgregarPago.FlatStyle = FlatStyle.Flat;
            btnAgregarPago.ForeColor = Color.White;
            btnAgregarPago.Image = (Image)resources.GetObject("btnAgregarPago.Image");
            btnAgregarPago.Location = new Point(8, 22);
            btnAgregarPago.Name = "btnAgregarPago";
            btnAgregarPago.Size = new Size(90, 91);
            btnAgregarPago.TabIndex = 28;
            btnAgregarPago.TextColor = Color.White;
            btnAgregarPago.UseVisualStyleBackColor = false;
            btnAgregarPago.Click += btnAgregarPago_Click;
            // 
            // txtTotalPagos
            // 
            txtTotalPagos.BackColor = SystemColors.Control;
            txtTotalPagos.Location = new Point(506, 122);
            txtTotalPagos.Name = "txtTotalPagos";
            txtTotalPagos.ReadOnly = true;
            txtTotalPagos.Size = new Size(100, 22);
            txtTotalPagos.TabIndex = 27;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(404, 127);
            label16.Name = "label16";
            label16.Size = new Size(92, 17);
            label16.TabIndex = 27;
            label16.Text = "Total Pagos $ :";
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.BackgroundColor = Color.White;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(112, 22);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.Size = new Size(494, 91);
            dgvPagos.TabIndex = 0;
            dgvPagos.CellContentClick += dgvPagos_CellContentClick;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnSalir);
            groupBox5.Controls.Add(btnImprimir);
            groupBox5.Controls.Add(btnDeshacer);
            groupBox5.Controls.Add(btnGrabar);
            groupBox5.Controls.Add(btnModificar);
            groupBox5.Controls.Add(btnNuevo);
            groupBox5.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox5.Location = new Point(636, 45);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(153, 358);
            groupBox5.TabIndex = 10;
            groupBox5.TabStop = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.LightCoral;
            btnSalir.BackgroundColor = Color.LightCoral;
            btnSalir.BorderColor = Color.PaleVioletRed;
            btnSalir.BorderRadius = 15;
            btnSalir.BorderSize = 0;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.DarkRed;
            btnSalir.Image = (Image)resources.GetObject("btnSalir.Image");
            btnSalir.Location = new Point(8, 314);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(134, 35);
            btnSalir.TabIndex = 29;
            btnSalir.Text = "Salir";
            btnSalir.TextColor = Color.DarkRed;
            btnSalir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.CornflowerBlue;
            btnImprimir.BackgroundColor = Color.CornflowerBlue;
            btnImprimir.BorderColor = Color.PaleVioletRed;
            btnImprimir.BorderRadius = 15;
            btnImprimir.BorderSize = 0;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Image = (Image)resources.GetObject("btnImprimir.Image");
            btnImprimir.Location = new Point(8, 181);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(134, 35);
            btnImprimir.TabIndex = 6;
            btnImprimir.Text = "Imprimir";
            btnImprimir.TextColor = Color.White;
            btnImprimir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnDeshacer
            // 
            btnDeshacer.BackColor = Color.Gold;
            btnDeshacer.BackgroundColor = Color.Gold;
            btnDeshacer.BorderColor = Color.PaleVioletRed;
            btnDeshacer.BorderRadius = 15;
            btnDeshacer.BorderSize = 0;
            btnDeshacer.FlatAppearance.BorderSize = 0;
            btnDeshacer.FlatStyle = FlatStyle.Flat;
            btnDeshacer.ForeColor = Color.Chocolate;
            btnDeshacer.Image = (Image)resources.GetObject("btnDeshacer.Image");
            btnDeshacer.Location = new Point(8, 140);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(134, 35);
            btnDeshacer.TabIndex = 4;
            btnDeshacer.Text = "Deshacer";
            btnDeshacer.TextColor = Color.Chocolate;
            btnDeshacer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeshacer.UseVisualStyleBackColor = false;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // btnGrabar
            // 
            btnGrabar.BackColor = Color.DeepSkyBlue;
            btnGrabar.BackgroundColor = Color.DeepSkyBlue;
            btnGrabar.BorderColor = Color.PaleVioletRed;
            btnGrabar.BorderRadius = 15;
            btnGrabar.BorderSize = 0;
            btnGrabar.FlatAppearance.BorderSize = 0;
            btnGrabar.FlatStyle = FlatStyle.Flat;
            btnGrabar.ForeColor = Color.Navy;
            btnGrabar.Image = (Image)resources.GetObject("btnGrabar.Image");
            btnGrabar.Location = new Point(8, 99);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(134, 35);
            btnGrabar.TabIndex = 3;
            btnGrabar.Text = "Grabar";
            btnGrabar.TextColor = Color.Navy;
            btnGrabar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGrabar.UseVisualStyleBackColor = false;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.CornflowerBlue;
            btnModificar.BackgroundColor = Color.CornflowerBlue;
            btnModificar.BorderColor = Color.PaleVioletRed;
            btnModificar.BorderRadius = 15;
            btnModificar.BorderSize = 0;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.ForeColor = Color.White;
            btnModificar.Image = (Image)resources.GetObject("btnModificar.Image");
            btnModificar.Location = new Point(8, 58);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(134, 35);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.TextColor = Color.White;
            btnModificar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LightGreen;
            btnNuevo.BackgroundColor = Color.LightGreen;
            btnNuevo.BorderColor = Color.PaleVioletRed;
            btnNuevo.BorderRadius = 15;
            btnNuevo.BorderSize = 0;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.ForeColor = Color.DarkGreen;
            btnNuevo.Image = (Image)resources.GetObject("btnNuevo.Image");
            btnNuevo.Location = new Point(8, 17);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(134, 35);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.TextColor = Color.DarkGreen;
            btnNuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(656, 514);
            label17.Name = "label17";
            label17.Size = new Size(113, 19);
            label17.TabIndex = 28;
            label17.Text = "Buscar Orden";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(636, 536);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(153, 29);
            txtBuscar.TabIndex = 28;
            txtBuscar.TextAlign = HorizontalAlignment.Center;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(33, 150, 243);
            pnlEncabezado.Controls.Add(btnMinimizar);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(801, 39);
            pnlEncabezado.TabIndex = 29;
            pnlEncabezado.MouseDown += pnlEncabezado_MouseDown;
            pnlEncabezado.MouseMove += pnlEncabezado_MouseMove;
            pnlEncabezado.MouseUp += pnlEncabezado_MouseUp;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Right;
            btnMinimizar.BackColor = Color.FromArgb(33, 150, 243);
            btnMinimizar.BackgroundColor = Color.FromArgb(33, 150, 243);
            btnMinimizar.BorderColor = Color.PaleVioletRed;
            btnMinimizar.BorderRadius = 0;
            btnMinimizar.BorderSize = 0;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.ForeColor = Color.White;
            btnMinimizar.Image = Properties.Resources.minimizar2;
            btnMinimizar.Location = new Point(764, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(37, 39);
            btnMinimizar.TabIndex = 1;
            btnMinimizar.TextColor = Color.White;
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.FromArgb(33, 150, 243);
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(327, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(133, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Compra de Urea";
            // 
            // frmCompraUrea
            // 
            AllowRoundedCorners = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BorderThickness = 5;
            ClientSize = new Size(801, 574);
            Controls.Add(pnlEncabezado);
            Controls.Add(txtBuscar);
            Controls.Add(label17);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCompraUrea";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compra de Urea";
            Load += frmCompra_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            groupBox5.ResumeLayout(false);
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtNumero;
        private Label label3;
        private DateTimePicker dtpOrden;
        private TextBox txtEstado;
        private Label label2;
        private ComboBox cboProveedor;
        private GroupBox groupBox2;
        private TextBox txtLitros;
        private Label label4;
        private ComboBox cboTipo;
        private Label label6;
        private TextBox txtCosto;
        private Label label5;
        private TextBox txtPorcentaje;
        private Label label7;
        private Label label9;
        private TextBox txtTotal;
        private TextBox txtIva;
        private TextBox txtSubtotal;
        private Label label12;
        private Label label10;
        private GroupBox groupBox3;
        private TextBox txtFactura;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox txtFolioFiscal;
        private DateTimePicker dtpFactura;
        private GroupBox groupBox4;
        private DataGridView dgvPagos;
        private TextBox txtTotalPagos;
        private Label label16;
        private GroupBox groupBox5;
        private Label label17;
        private TextBox txtBuscar;
        private CustomRenderer.BotonRedondeado btnNuevo;
        private CustomRenderer.BotonRedondeado btnSalir;
        private CustomRenderer.BotonRedondeado btnImprimir;
        private CustomRenderer.BotonRedondeado btnDeshacer;
        private CustomRenderer.BotonRedondeado btnGrabar;
        private CustomRenderer.BotonRedondeado btnModificar;
        private Panel pnlEncabezado;
        private Label lblTitulo;
        private CustomRenderer.BotonRedondeado btnAplicar;
        private CustomRenderer.BotonRedondeado btnAgregarPago;
        private Label label8;
        private TextBox txtPagoResto;
        private System.Drawing.Printing.PrintDocument printCompraUrea;
        private TextBox txtDescuento;
        private Label label11;
        private Label lblDescto;
        private Label label19;
        private CustomRenderer.BotonRedondeado btnMinimizar;
    }
}