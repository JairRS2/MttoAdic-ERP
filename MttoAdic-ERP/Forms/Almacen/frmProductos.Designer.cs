namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmProductos
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
            groupBox1 = new GroupBox();
            txtCosto = new TextBox();
            label13 = new Label();
            txtMarca = new TextBox();
            label12 = new Label();
            cboProveedor2 = new ComboBox();
            label11 = new Label();
            cboProveedor1 = new ComboBox();
            label10 = new Label();
            txtInicial = new TextBox();
            label9 = new Label();
            dtpFechaAlta = new DateTimePicker();
            label8 = new Label();
            label7 = new Label();
            txtPosicion = new TextBox();
            cboLinea = new ComboBox();
            label6 = new Label();
            cboMedida = new ComboBox();
            txtMaximo = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtMinimo = new TextBox();
            label3 = new Label();
            txtDescripcion = new TextBox();
            label2 = new Label();
            txtCodigo = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnSalir = new CustomRenderer.BotonRedondeado();
            btnDeshacer = new CustomRenderer.BotonRedondeado();
            btnGrabar = new CustomRenderer.BotonRedondeado();
            btnModificar = new CustomRenderer.BotonRedondeado();
            btnNuevo = new CustomRenderer.BotonRedondeado();
            groupBox3 = new GroupBox();
            txtCostoCompra = new TextBox();
            label18 = new Label();
            txtPrecioVenta = new TextBox();
            label17 = new Label();
            dtpFechaCompra = new DateTimePicker();
            label16 = new Label();
            txtInventario = new TextBox();
            label15 = new Label();
            dgvProductos = new DataGridView();
            txtBuscaNombre = new TextBox();
            label20 = new Label();
            label19 = new Label();
            label21 = new Label();
            txtBuscaCodigo = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCosto);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(txtMarca);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(cboProveedor2);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(cboProveedor1);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtInicial);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(dtpFechaAlta);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtPosicion);
            groupBox1.Controls.Add(cboLinea);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cboMedida);
            groupBox1.Controls.Add(txtMaximo);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtMinimo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(7, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(559, 233);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(446, 200);
            txtCosto.Name = "txtCosto";
            txtCosto.ReadOnly = true;
            txtCosto.Size = new Size(100, 22);
            txtCosto.TabIndex = 26;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(387, 203);
            label13.Name = "label13";
            label13.Size = new Size(49, 17);
            label13.TabIndex = 25;
            label13.Text = "Costo :";
            // 
            // txtMarca
            // 
            txtMarca.BackColor = Color.White;
            txtMarca.BorderStyle = BorderStyle.None;
            txtMarca.Location = new Point(65, 204);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(226, 15);
            txtMarca.TabIndex = 24;
            txtMarca.KeyPress += txtMarca_KeyPress_1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 203);
            label12.Name = "label12";
            label12.Size = new Size(53, 17);
            label12.TabIndex = 23;
            label12.Text = "Marca :";
            // 
            // cboProveedor2
            // 
            cboProveedor2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProveedor2.FormattingEnabled = true;
            cboProveedor2.Location = new Point(311, 168);
            cboProveedor2.Name = "cboProveedor2";
            cboProveedor2.Size = new Size(235, 25);
            cboProveedor2.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(223, 172);
            label11.Name = "label11";
            label11.Size = new Size(84, 17);
            label11.TabIndex = 21;
            label11.Text = "Proveedor2 :";
            // 
            // cboProveedor1
            // 
            cboProveedor1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProveedor1.FormattingEnabled = true;
            cboProveedor1.Location = new Point(311, 137);
            cboProveedor1.Name = "cboProveedor1";
            cboProveedor1.Size = new Size(235, 25);
            cboProveedor1.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(223, 143);
            label10.Name = "label10";
            label10.Size = new Size(84, 17);
            label10.TabIndex = 19;
            label10.Text = "Proveedor1 :";
            // 
            // txtInicial
            // 
            txtInicial.Location = new Point(119, 171);
            txtInicial.Name = "txtInicial";
            txtInicial.ReadOnly = true;
            txtInicial.Size = new Size(94, 22);
            txtInicial.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 173);
            label9.Name = "label9";
            label9.Size = new Size(113, 17);
            label9.TabIndex = 17;
            label9.Text = "Inventario Inicial :";
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.Format = DateTimePickerFormat.Short;
            dtpFechaAlta.Location = new Point(110, 138);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(103, 22);
            dtpFechaAlta.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 143);
            label8.Name = "label8";
            label8.Size = new Size(98, 17);
            label8.TabIndex = 15;
            label8.Text = "Fecha de Alta :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(268, 114);
            label7.Name = "label7";
            label7.Size = new Size(138, 17);
            label7.TabIndex = 14;
            label7.Text = "Posición en Almacén :";
            // 
            // txtPosicion
            // 
            txtPosicion.BackColor = Color.White;
            txtPosicion.BorderStyle = BorderStyle.None;
            txtPosicion.Location = new Point(407, 114);
            txtPosicion.Name = "txtPosicion";
            txtPosicion.Size = new Size(139, 15);
            txtPosicion.TabIndex = 13;
            txtPosicion.KeyPress += txtPosicion_KeyPress;
            // 
            // cboLinea
            // 
            cboLinea.BackColor = Color.White;
            cboLinea.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLinea.FormattingEnabled = true;
            cboLinea.Location = new Point(53, 106);
            cboLinea.Name = "cboLinea";
            cboLinea.Size = new Size(121, 25);
            cboLinea.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 114);
            label6.Name = "label6";
            label6.Size = new Size(46, 17);
            label6.TabIndex = 11;
            label6.Text = "Línea :";
            // 
            // cboMedida
            // 
            cboMedida.BackColor = Color.White;
            cboMedida.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMedida.FormattingEnabled = true;
            cboMedida.Location = new Point(119, 77);
            cboMedida.Name = "cboMedida";
            cboMedida.Size = new Size(129, 25);
            cboMedida.TabIndex = 10;
            // 
            // txtMaximo
            // 
            txtMaximo.BackColor = Color.White;
            txtMaximo.BorderStyle = BorderStyle.None;
            txtMaximo.Location = new Point(501, 81);
            txtMaximo.Name = "txtMaximo";
            txtMaximo.Size = new Size(45, 15);
            txtMaximo.TabIndex = 8;
            txtMaximo.KeyPress += txtMaximo_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(401, 80);
            label5.Name = "label5";
            label5.Size = new Size(98, 17);
            label5.TabIndex = 7;
            label5.Text = "Stock Máximo :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(254, 81);
            label4.Name = "label4";
            label4.Size = new Size(94, 17);
            label4.TabIndex = 6;
            label4.Text = "Stock Mínimo :";
            // 
            // txtMinimo
            // 
            txtMinimo.BackColor = Color.White;
            txtMinimo.BorderStyle = BorderStyle.None;
            txtMinimo.Location = new Point(351, 82);
            txtMinimo.Name = "txtMinimo";
            txtMinimo.Size = new Size(44, 15);
            txtMinimo.TabIndex = 5;
            txtMinimo.KeyPress += txtMinimo_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 81);
            label3.Name = "label3";
            label3.Size = new Size(107, 17);
            label3.TabIndex = 4;
            label3.Text = "Unidad/Medida :";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = Color.White;
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.Location = new Point(97, 52);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(449, 15);
            txtDescripcion.TabIndex = 3;
            txtDescripcion.KeyPress += txtDescripcion_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 51);
            label2.Name = "label2";
            label2.Size = new Size(85, 17);
            label2.TabIndex = 2;
            label2.Text = "Descripción :";
            // 
            // txtCodigo
            // 
            txtCodigo.BackColor = Color.White;
            txtCodigo.BorderStyle = BorderStyle.None;
            txtCodigo.Location = new Point(70, 24);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 15);
            txtCodigo.TabIndex = 1;
            txtCodigo.KeyPress += txtCodigo_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(58, 17);
            label1.TabIndex = 0;
            label1.Text = "Codigo :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSalir);
            groupBox2.Controls.Add(btnDeshacer);
            groupBox2.Controls.Add(btnGrabar);
            groupBox2.Controls.Add(btnModificar);
            groupBox2.Controls.Add(btnNuevo);
            groupBox2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(572, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(117, 187);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
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
            btnSalir.Image = Properties.Resources.close24;
            btnSalir.Location = new Point(6, 149);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(105, 32);
            btnSalir.TabIndex = 41;
            btnSalir.Text = "Salir          ";
            btnSalir.TextColor = Color.DarkRed;
            btnSalir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
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
            btnDeshacer.Image = Properties.Resources.deshacer24;
            btnDeshacer.Location = new Point(6, 114);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(105, 32);
            btnDeshacer.TabIndex = 40;
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
            btnGrabar.Image = Properties.Resources.grabar24;
            btnGrabar.Location = new Point(6, 81);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(105, 32);
            btnGrabar.TabIndex = 39;
            btnGrabar.Text = "Grabar     ";
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
            btnModificar.Image = Properties.Resources.update241;
            btnModificar.Location = new Point(6, 48);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(105, 32);
            btnModificar.TabIndex = 38;
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
            btnNuevo.Image = Properties.Resources.nuevo24;
            btnNuevo.Location = new Point(7, 14);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(104, 32);
            btnNuevo.TabIndex = 37;
            btnNuevo.Text = "Nuevo     ";
            btnNuevo.TextColor = Color.DarkGreen;
            btnNuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtCostoCompra);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(txtPrecioVenta);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(dtpFechaCompra);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(txtInventario);
            groupBox3.Controls.Add(label15);
            groupBox3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(7, 239);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(559, 89);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Datos Actualizables";
            // 
            // txtCostoCompra
            // 
            txtCostoCompra.BackColor = Color.White;
            txtCostoCompra.BorderStyle = BorderStyle.None;
            txtCostoCompra.Enabled = false;
            txtCostoCompra.Location = new Point(401, 62);
            txtCostoCompra.Name = "txtCostoCompra";
            txtCostoCompra.Size = new Size(145, 15);
            txtCostoCompra.TabIndex = 22;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(254, 61);
            label18.Name = "label18";
            label18.Size = new Size(141, 17);
            label18.TabIndex = 21;
            label18.Text = "Costo Última Compra :";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.BackColor = Color.White;
            txtPrecioVenta.BorderStyle = BorderStyle.None;
            txtPrecioVenta.Enabled = false;
            txtPrecioVenta.Location = new Point(401, 30);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(145, 15);
            txtPrecioVenta.TabIndex = 20;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(284, 29);
            label17.Name = "label17";
            label17.Size = new Size(111, 17);
            label17.TabIndex = 19;
            label17.Text = "Precio de Venta :";
            // 
            // dtpFechaCompra
            // 
            dtpFechaCompra.Enabled = false;
            dtpFechaCompra.Format = DateTimePickerFormat.Short;
            dtpFechaCompra.Location = new Point(154, 57);
            dtpFechaCompra.Name = "dtpFechaCompra";
            dtpFechaCompra.Size = new Size(94, 22);
            dtpFechaCompra.TabIndex = 18;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 60);
            label16.Name = "label16";
            label16.Size = new Size(142, 17);
            label16.TabIndex = 17;
            label16.Text = "Fecha última Compra :";
            // 
            // txtInventario
            // 
            txtInventario.BackColor = Color.White;
            txtInventario.BorderStyle = BorderStyle.None;
            txtInventario.Enabled = false;
            txtInventario.Location = new Point(130, 30);
            txtInventario.Name = "txtInventario";
            txtInventario.Size = new Size(94, 15);
            txtInventario.TabIndex = 3;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 30);
            label15.Name = "label15";
            label15.Size = new Size(118, 17);
            label15.TabIndex = 2;
            label15.Text = "Inventario Actual :";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(8, 334);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(558, 172);
            dgvProductos.TabIndex = 2;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // txtBuscaNombre
            // 
            txtBuscaNombre.BackColor = Color.White;
            txtBuscaNombre.BorderStyle = BorderStyle.None;
            txtBuscaNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscaNombre.Location = new Point(585, 255);
            txtBuscaNombre.MaxLength = 90;
            txtBuscaNombre.Name = "txtBuscaNombre";
            txtBuscaNombre.Size = new Size(92, 22);
            txtBuscaNombre.TabIndex = 34;
            txtBuscaNombre.TextAlign = HorizontalAlignment.Center;
            txtBuscaNombre.TextChanged += txtBuscaNombre_TextChanged;
            txtBuscaNombre.KeyPress += txtBuscaNombre_KeyPress;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(596, 203);
            label20.Name = "label20";
            label20.Size = new Size(60, 19);
            label20.TabIndex = 33;
            label20.Text = "Buscar";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Century Gothic", 9F);
            label19.Location = new Point(596, 234);
            label19.Name = "label19";
            label19.Size = new Size(62, 17);
            label19.TabIndex = 29;
            label19.Text = "Nombre :";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Century Gothic", 9F);
            label21.Location = new Point(596, 285);
            label21.Name = "label21";
            label21.Size = new Size(58, 17);
            label21.TabIndex = 35;
            label21.Text = "Codigo :";
            // 
            // txtBuscaCodigo
            // 
            txtBuscaCodigo.BackColor = Color.White;
            txtBuscaCodigo.BorderStyle = BorderStyle.None;
            txtBuscaCodigo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscaCodigo.Location = new Point(585, 306);
            txtBuscaCodigo.MaxLength = 25;
            txtBuscaCodigo.Name = "txtBuscaCodigo";
            txtBuscaCodigo.Size = new Size(92, 22);
            txtBuscaCodigo.TabIndex = 36;
            txtBuscaCodigo.TextAlign = HorizontalAlignment.Center;
            txtBuscaCodigo.TextChanged += txtBuscaCodigo_TextChanged;
            txtBuscaCodigo.KeyPress += txtBuscaCodigo_KeyPress;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            CaptionBarColor = Color.FromArgb(0, 120, 212);
            CaptionFont = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CaptionForeColor = Color.White;
            ClientSize = new Size(691, 512);
            ControlBox = false;
            Controls.Add(label21);
            Controls.Add(txtBuscaCodigo);
            Controls.Add(label19);
            Controls.Add(txtBuscaNombre);
            Controls.Add(label20);
            Controls.Add(dgvProductos);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo de Productos";
            Load += frmProductos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox txtMinimo;
        private Label label3;
        private TextBox txtDescripcion;
        private Label label2;
        private TextBox txtCodigo;
        private Label label1;
        private TextBox txtMaximo;
        private Label label5;
        private Label label4;
        private TextBox txtInicial;
        private Label label9;
        private DateTimePicker dtpFechaAlta;
        private Label label8;
        private Label label7;
        private TextBox txtPosicion;
        private ComboBox cboLinea;
        private Label label6;
        private ComboBox cboMedida;
        private ComboBox cboProveedor2;
        private Label label11;
        private ComboBox cboProveedor1;
        private Label label10;
        private TextBox txtCosto;
        private Label label13;
        private TextBox txtMarca;
        private Label label12;
        private TextBox txtInventario;
        private Label label15;
        private DateTimePicker dtpFechaCompra;
        private Label label16;
        private TextBox txtPrecioVenta;
        private Label label17;
        private TextBox txtCostoCompra;
        private Label label18;
        private DataGridView dgvProductos;
        private TextBox txtBuscaNombre;
        private Label label20;
        private Label label19;
        private Label label21;
        private TextBox txtBuscaCodigo;
        private CustomRenderer.BotonRedondeado btnNuevo;
        private CustomRenderer.BotonRedondeado btnModificar;
        private CustomRenderer.BotonRedondeado btnGrabar;
        private CustomRenderer.BotonRedondeado btnDeshacer;
        private CustomRenderer.BotonRedondeado btnSalir;
    }
}