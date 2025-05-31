namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompras));
            groupBox1 = new GroupBox();
            cboProveedor = new ComboBox();
            label2 = new Label();
            dtpOrden = new DateTimePicker();
            label8 = new Label();
            txtEstado = new TextBox();
            txtNumero = new TextBox();
            label1 = new Label();
            groupBox4 = new GroupBox();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnGrabar = new Button();
            btnImprimir = new Button();
            btnSalir = new Button();
            btnCancelar = new Button();
            btnDeshacer = new Button();
            btnTerminar = new Button();
            groupBox2 = new GroupBox();
            btnAplicar = new Button();
            txtPorcentaje = new TextBox();
            label7 = new Label();
            cboTipo = new ComboBox();
            label21 = new Label();
            btnPedidos = new Button();
            txtResico = new TextBox();
            label18 = new Label();
            groupBox3 = new GroupBox();
            txtFolioFiscal = new TextBox();
            label16 = new Label();
            dtpFactura = new DateTimePicker();
            label12 = new Label();
            txtFactura = new TextBox();
            label11 = new Label();
            txtTotal = new TextBox();
            label6 = new Label();
            txtIva = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtCosto = new TextBox();
            txtProducto = new TextBox();
            txtSubtotal = new TextBox();
            label14 = new Label();
            dgvProductos = new DataGridView();
            btnQuitar = new Button();
            btnAgregar = new Button();
            btnProducto = new Button();
            txtCantidad = new TextBox();
            txtDescripcion = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label3 = new Label();
            groupBox5 = new GroupBox();
            btnAgregarPago = new MttoAdic_ERP.CustomRenderer.BotonRedondeado();
            txtTotalPagos = new TextBox();
            label19 = new Label();
            dgvPagos = new DataGridView();
            txtBuscar = new TextBox();
            label20 = new Label();
            chkResico = new CheckBox();
            cboMetodo = new ComboBox();
            label17 = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboProveedor);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpOrden);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtEstado);
            groupBox1.Controls.Add(txtNumero);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(9, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(555, 90);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // cboProveedor
            // 
            cboProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Location = new Point(88, 53);
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new Size(454, 23);
            cboProveedor.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 62);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 35;
            label2.Text = "Proveedor :";
            // 
            // dtpOrden
            // 
            dtpOrden.Format = DateTimePickerFormat.Short;
            dtpOrden.Location = new Point(467, 22);
            dtpOrden.Name = "dtpOrden";
            dtpOrden.Size = new Size(77, 23);
            dtpOrden.TabIndex = 34;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(382, 30);
            label8.Name = "label8";
            label8.Size = new Size(80, 15);
            label8.TabIndex = 33;
            label8.Text = "Fecha Orden :";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(223, 20);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(131, 23);
            txtEstado.TabIndex = 25;
            txtEstado.TextAlign = HorizontalAlignment.Center;
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(116, 20);
            txtNumero.Name = "txtNumero";
            txtNumero.ReadOnly = true;
            txtNumero.Size = new Size(71, 23);
            txtNumero.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 2;
            label1.Text = "Número de Orden :";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnNuevo);
            groupBox4.Controls.Add(btnModificar);
            groupBox4.Controls.Add(btnGrabar);
            groupBox4.Controls.Add(btnImprimir);
            groupBox4.Controls.Add(btnSalir);
            groupBox4.Controls.Add(btnCancelar);
            groupBox4.Controls.Add(btnDeshacer);
            groupBox4.Controls.Add(btnTerminar);
            groupBox4.Location = new Point(571, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(112, 251);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LightGreen;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.ForeColor = Color.DarkGreen;
            btnNuevo.Image = Properties.Resources.nuevo24;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(6, 16);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(99, 23);
            btnNuevo.TabIndex = 47;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.CornflowerBlue;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.ForeColor = Color.White;
            btnModificar.Image = Properties.Resources.update24;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(6, 44);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(99, 23);
            btnModificar.TabIndex = 46;
            btnModificar.Text = "      Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGrabar
            // 
            btnGrabar.BackColor = Color.DeepSkyBlue;
            btnGrabar.FlatStyle = FlatStyle.Flat;
            btnGrabar.ForeColor = Color.Navy;
            btnGrabar.Image = Properties.Resources.grabar24;
            btnGrabar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGrabar.Location = new Point(5, 98);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(99, 23);
            btnGrabar.TabIndex = 45;
            btnGrabar.Text = "Grabar";
            btnGrabar.UseVisualStyleBackColor = false;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.CornflowerBlue;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Image = Properties.Resources.imprimir18;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(6, 177);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(99, 23);
            btnImprimir.TabIndex = 44;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.LightCoral;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.DarkRed;
            btnSalir.Image = Properties.Resources.close24;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(6, 220);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(99, 23);
            btnSalir.TabIndex = 43;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(6, 151);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(99, 23);
            btnCancelar.TabIndex = 42;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnDeshacer
            // 
            btnDeshacer.BackColor = Color.Gold;
            btnDeshacer.FlatStyle = FlatStyle.Flat;
            btnDeshacer.ForeColor = Color.Chocolate;
            btnDeshacer.Image = Properties.Resources.deshacer24;
            btnDeshacer.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeshacer.Location = new Point(5, 125);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(99, 23);
            btnDeshacer.TabIndex = 41;
            btnDeshacer.Text = "   Deshacer";
            btnDeshacer.UseVisualStyleBackColor = false;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // btnTerminar
            // 
            btnTerminar.Location = new Point(5, 71);
            btnTerminar.Name = "btnTerminar";
            btnTerminar.Size = new Size(99, 23);
            btnTerminar.TabIndex = 40;
            btnTerminar.Text = "Terminar";
            btnTerminar.UseVisualStyleBackColor = true;
            btnTerminar.Click += btnTerminar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAplicar);
            groupBox2.Controls.Add(txtPorcentaje);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(cboTipo);
            groupBox2.Controls.Add(label21);
            groupBox2.Controls.Add(btnPedidos);
            groupBox2.Controls.Add(txtResico);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(txtTotal);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtIva);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtCosto);
            groupBox2.Controls.Add(txtProducto);
            groupBox2.Controls.Add(txtSubtotal);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(dgvProductos);
            groupBox2.Controls.Add(btnQuitar);
            groupBox2.Controls.Add(btnAgregar);
            groupBox2.Controls.Add(btnProducto);
            groupBox2.Controls.Add(txtCantidad);
            groupBox2.Controls.Add(txtDescripcion);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(9, 93);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(555, 332);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            // 
            // btnAplicar
            // 
            btnAplicar.Location = new Point(302, 187);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(71, 23);
            btnAplicar.TabIndex = 56;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = true;
            // 
            // txtPorcentaje
            // 
            txtPorcentaje.Location = new Point(263, 187);
            txtPorcentaje.Name = "txtPorcentaje";
            txtPorcentaje.Size = new Size(34, 23);
            txtPorcentaje.TabIndex = 55;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(192, 196);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 54;
            label7.Text = "Descto (%) :";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(74, 188);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(97, 23);
            cboTipo.TabIndex = 53;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(7, 196);
            label21.Name = "label21";
            label21.Size = new Size(66, 15);
            label21.TabIndex = 52;
            label21.Text = "Tipo Pago :";
            // 
            // btnPedidos
            // 
            btnPedidos.Location = new Point(8, 148);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(73, 23);
            btnPedidos.TabIndex = 50;
            btnPedidos.Text = "Pedidos";
            btnPedidos.UseVisualStyleBackColor = true;
            btnPedidos.Click += btnPedidos_Click;
            // 
            // txtResico
            // 
            txtResico.Location = new Point(466, 264);
            txtResico.Name = "txtResico";
            txtResico.ReadOnly = true;
            txtResico.Size = new Size(79, 23);
            txtResico.TabIndex = 49;
            txtResico.TextAlign = HorizontalAlignment.Right;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(378, 270);
            label18.Name = "label18";
            label18.Size = new Size(69, 15);
            label18.TabIndex = 48;
            label18.Text = "Isr Retenido";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtFolioFiscal);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(dtpFactura);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(txtFactura);
            groupBox3.Controls.Add(label11);
            groupBox3.Location = new Point(10, 245);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(362, 79);
            groupBox3.TabIndex = 47;
            groupBox3.TabStop = false;
            groupBox3.Text = "Datos Factura";
            // 
            // txtFolioFiscal
            // 
            txtFolioFiscal.Location = new Point(73, 45);
            txtFolioFiscal.Name = "txtFolioFiscal";
            txtFolioFiscal.Size = new Size(280, 23);
            txtFolioFiscal.TabIndex = 47;
            txtFolioFiscal.KeyPress += txtFolioFiscal_KeyPress;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(7, 52);
            label16.Name = "label16";
            label16.Size = new Size(65, 15);
            label16.TabIndex = 46;
            label16.Text = "Folio Fiscal";
            // 
            // dtpFactura
            // 
            dtpFactura.Format = DateTimePickerFormat.Short;
            dtpFactura.Location = new Point(274, 17);
            dtpFactura.Name = "dtpFactura";
            dtpFactura.Size = new Size(77, 23);
            dtpFactura.TabIndex = 41;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(222, 26);
            label12.Name = "label12";
            label12.Size = new Size(44, 15);
            label12.TabIndex = 40;
            label12.Text = "Fecha :";
            // 
            // txtFactura
            // 
            txtFactura.Location = new Point(73, 17);
            txtFactura.Name = "txtFactura";
            txtFactura.Size = new Size(104, 23);
            txtFactura.TabIndex = 39;
            txtFactura.KeyPress += txtFactura_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(7, 24);
            label11.Name = "label11";
            label11.Size = new Size(52, 15);
            label11.TabIndex = 4;
            label11.Text = "Factura :";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(466, 300);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(79, 23);
            txtTotal.TabIndex = 44;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(378, 306);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 43;
            label6.Text = "Total :";
            // 
            // txtIva
            // 
            txtIva.Location = new Point(466, 226);
            txtIva.Name = "txtIva";
            txtIva.ReadOnly = true;
            txtIva.Size = new Size(79, 23);
            txtIva.TabIndex = 42;
            txtIva.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(378, 232);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 41;
            label5.Text = "Iva :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(463, 19);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 40;
            label4.Text = "Costo Unitario";
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(483, 36);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(60, 23);
            txtCosto.TabIndex = 39;
            txtCosto.KeyPress += txtCosto_KeyPress;
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(11, 36);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(104, 23);
            txtProducto.TabIndex = 38;
            txtProducto.KeyPress += txtProducto_KeyPress;
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(466, 188);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(79, 23);
            txtSubtotal.TabIndex = 37;
            txtSubtotal.TextAlign = HorizontalAlignment.Right;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(378, 194);
            label14.Name = "label14";
            label14.Size = new Size(57, 15);
            label14.TabIndex = 36;
            label14.Text = "Subtotal :";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToOrderColumns = true;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(87, 65);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(457, 117);
            dgvProductos.TabIndex = 35;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(8, 110);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(73, 23);
            btnQuitar.TabIndex = 34;
            btnQuitar.Text = "<<Quitar";
            btnQuitar.TextAlign = ContentAlignment.MiddleRight;
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(8, 80);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(73, 23);
            btnAgregar.TabIndex = 33;
            btnAgregar.Text = "Agregar>>";
            btnAgregar.TextAlign = ContentAlignment.MiddleLeft;
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnProducto
            // 
            btnProducto.Location = new Point(120, 35);
            btnProducto.Name = "btnProducto";
            btnProducto.Size = new Size(21, 25);
            btnProducto.TabIndex = 31;
            btnProducto.Text = "?";
            btnProducto.UseVisualStyleBackColor = true;
            btnProducto.Click += btnProducto_Click;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(142, 36);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(34, 23);
            txtCantidad.TabIndex = 28;
            txtCantidad.KeyPress += txtCantidad_KeyPress;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(180, 36);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(301, 23);
            txtDescripcion.TabIndex = 27;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(202, 18);
            label10.Name = "label10";
            label10.Size = new Size(69, 15);
            label10.TabIndex = 5;
            label10.Text = "Descripción";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(128, 18);
            label9.Name = "label9";
            label9.Size = new Size(55, 15);
            label9.TabIndex = 4;
            label9.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 18);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 3;
            label3.Text = "Producto";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btnAgregarPago);
            groupBox5.Controls.Add(txtTotalPagos);
            groupBox5.Controls.Add(label19);
            groupBox5.Controls.Add(dgvPagos);
            groupBox5.Location = new Point(9, 427);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(556, 149);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "Complementos de Pago";
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
            btnAgregarPago.Location = new Point(16, 32);
            btnAgregarPago.Name = "btnAgregarPago";
            btnAgregarPago.Size = new Size(65, 68);
            btnAgregarPago.TabIndex = 54;
            btnAgregarPago.TextColor = Color.White;
            btnAgregarPago.UseVisualStyleBackColor = false;
            btnAgregarPago.Click += botonRedondeado1_Click;
            // 
            // txtTotalPagos
            // 
            txtTotalPagos.Location = new Point(465, 114);
            txtTotalPagos.Name = "txtTotalPagos";
            txtTotalPagos.ReadOnly = true;
            txtTotalPagos.Size = new Size(79, 23);
            txtTotalPagos.TabIndex = 54;
            txtTotalPagos.TextAlign = HorizontalAlignment.Right;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(377, 120);
            label19.Name = "label19";
            label19.Size = new Size(82, 15);
            label19.TabIndex = 53;
            label19.Text = "Total Pagos $ :";
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.AllowUserToDeleteRows = false;
            dgvPagos.AllowUserToOrderColumns = true;
            dgvPagos.AllowUserToResizeColumns = false;
            dgvPagos.AllowUserToResizeRows = false;
            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPagos.BackgroundColor = Color.White;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(88, 20);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagos.Size = new Size(456, 91);
            dgvPagos.TabIndex = 36;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(571, 313);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(112, 29);
            txtBuscar.TabIndex = 32;
            txtBuscar.TextAlign = HorizontalAlignment.Center;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(571, 289);
            label20.Name = "label20";
            label20.Size = new Size(115, 21);
            label20.TabIndex = 31;
            label20.Text = "Buscar Orden ";
            // 
            // chkResico
            // 
            chkResico.AutoSize = true;
            chkResico.Location = new Point(311, 317);
            chkResico.Name = "chkResico";
            chkResico.Size = new Size(60, 19);
            chkResico.TabIndex = 53;
            chkResico.Text = "Resico";
            chkResico.UseVisualStyleBackColor = true;
            chkResico.CheckedChanged += chkResico_CheckedChanged;
            // 
            // cboMetodo
            // 
            cboMetodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMetodo.FormattingEnabled = true;
            cboMetodo.Location = new Point(121, 310);
            cboMetodo.Name = "cboMetodo";
            cboMetodo.Size = new Size(157, 23);
            cboMetodo.TabIndex = 52;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(18, 318);
            label17.Name = "label17";
            label17.Size = new Size(101, 15);
            label17.TabIndex = 51;
            label17.Text = "Metodo de Pago :";
            // 
            // frmCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            CaptionBarColor = Color.FromArgb(0, 120, 212);
            CaptionFont = new Font("Century Gothic", 14.25F);
            CaptionForeColor = Color.White;
            ClientSize = new Size(693, 579);
            ControlBox = false;
            Controls.Add(chkResico);
            Controls.Add(cboMetodo);
            Controls.Add(label17);
            Controls.Add(txtBuscar);
            Controls.Add(label20);
            Controls.Add(groupBox5);
            Controls.Add(groupBox2);
            Controls.Add(groupBox4);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmCompras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compras de Refacciones";
            Load += frmCompras_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtEstado;
        private TextBox txtNumero;
        private Label label1;
        private Label label8;
        private ComboBox cboProveedor;
        private Label label2;
        private GroupBox groupBox4;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnGrabar;
        private Button btnImprimir;
        private Button btnSalir;
        private Button btnCancelar;
        private Button btnDeshacer;
        private Button btnTerminar;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox txtCosto;
        private TextBox txtProducto;
        private TextBox txtSubtotal;
        private Label label14;
        private DataGridView dgvProductos;
        private Button btnQuitar;
        private Button btnAgregar;
        private Button btnProducto;
        private TextBox txtCantidad;
        private TextBox txtDescripcion;
        private Label label10;
        private Label label9;
        private Label label3;
        private TextBox txtIva;
        private Label label5;
        private GroupBox groupBox3;
        private DateTimePicker dtpFactura;
        private Label label12;
        private TextBox txtFactura;
        private Label label11;
        private TextBox txtFolioFiscal;
        private Label label16;
        private GroupBox groupBox5;
        private DataGridView dgvPagos;
        private TextBox txtResico;
        private Label label18;
        private Button btnPedidos;
        private TextBox txtTotalPagos;
        private Label label19;
        private TextBox txtBuscar;
        private Label label20;
        private TextBox txtTotal;
        private Label label6;
        private Button btnAplicar;
        private TextBox txtPorcentaje;
        private Label label7;
        private ComboBox cboTipo;
        private Label label21;
        private CheckBox chkResico;
        private ComboBox cboMetodo;
        private Label label17;
        private DateTimePicker dtpOrden;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private CustomRenderer.BotonRedondeado btnAgregarPago;
    }
}