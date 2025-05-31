namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmDevolucionCompra
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
            groupBox2 = new GroupBox();
            label10 = new Label();
            txtTotal = new TextBox();
            label8 = new Label();
            label5 = new Label();
            cboFactura = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            label7 = new Label();
            cboProveedor = new ComboBox();
            label6 = new Label();
            txtFolioNvo = new TextBox();
            btnQuitar = new Button();
            btnSalirNuevo = new Button();
            btnGrabar = new Button();
            btnAgregar = new Button();
            dgvProdDev = new DataGridView();
            dgvProdFactura = new DataGridView();
            label4 = new Label();
            groupBox1 = new GroupBox();
            label11 = new Label();
            txtTotalDev = new TextBox();
            btnImprimir = new Button();
            txtProveedor = new TextBox();
            label9 = new Label();
            btnSalir = new Button();
            btnBuscar = new Button();
            btnNuevo = new Button();
            dgvProductos = new DataGridView();
            label3 = new Label();
            txtFecha = new TextBox();
            label2 = new Label();
            txtFactura = new TextBox();
            label1 = new Label();
            txtNumero = new TextBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdDev).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProdFactura).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtTotal);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cboFactura);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(cboProveedor);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtFolioNvo);
            groupBox2.Controls.Add(btnQuitar);
            groupBox2.Controls.Add(btnSalirNuevo);
            groupBox2.Controls.Add(btnGrabar);
            groupBox2.Controls.Add(btnAgregar);
            groupBox2.Controls.Add(dgvProdDev);
            groupBox2.Controls.Add(dgvProdFactura);
            groupBox2.Location = new Point(505, 7);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(616, 354);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nuevo Registro";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(480, 324);
            label10.Name = "label10";
            label10.Size = new Size(38, 15);
            label10.TabIndex = 48;
            label10.Text = "Total :";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(527, 316);
            txtTotal.MaxLength = 7;
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(79, 23);
            txtTotal.TabIndex = 47;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(208, 32);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 46;
            label8.Text = "Fecha :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(439, 61);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 45;
            label5.Text = "Factura :";
            // 
            // cboFactura
            // 
            cboFactura.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFactura.FormattingEnabled = true;
            cboFactura.Location = new Point(493, 52);
            cboFactura.Name = "cboFactura";
            cboFactura.Size = new Size(111, 23);
            cboFactura.TabIndex = 44;
            cboFactura.SelectedIndexChanged += cboFactura_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(257, 23);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(101, 23);
            dateTimePicker1.TabIndex = 43;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 61);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 42;
            label7.Text = "Proveedor :";
            // 
            // cboProveedor
            // 
            cboProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Location = new Point(84, 52);
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new Size(325, 23);
            cboProveedor.TabIndex = 41;
            cboProveedor.SelectedIndexChanged += cboProveedor_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 32);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 40;
            label6.Text = "Folio :";
            // 
            // txtFolioNvo
            // 
            txtFolioNvo.Location = new Point(56, 24);
            txtFolioNvo.MaxLength = 7;
            txtFolioNvo.Name = "txtFolioNvo";
            txtFolioNvo.ReadOnly = true;
            txtFolioNvo.Size = new Size(79, 23);
            txtFolioNvo.TabIndex = 39;
            txtFolioNvo.TextAlign = HorizontalAlignment.Center;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(292, 195);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(31, 25);
            btnQuitar.TabIndex = 38;
            btnQuitar.Text = "<<";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnSalirNuevo
            // 
            btnSalirNuevo.BackColor = Color.LightCoral;
            btnSalirNuevo.FlatStyle = FlatStyle.Flat;
            btnSalirNuevo.ForeColor = Color.DarkRed;
            btnSalirNuevo.Image = Properties.Resources.close18;
            btnSalirNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalirNuevo.Location = new Point(530, 22);
            btnSalirNuevo.Name = "btnSalirNuevo";
            btnSalirNuevo.Size = new Size(75, 23);
            btnSalirNuevo.TabIndex = 37;
            btnSalirNuevo.Text = "Salir";
            btnSalirNuevo.UseVisualStyleBackColor = false;
            btnSalirNuevo.Click += btnSalirNuevo_Click;
            // 
            // btnGrabar
            // 
            btnGrabar.BackColor = Color.DeepSkyBlue;
            btnGrabar.FlatStyle = FlatStyle.Flat;
            btnGrabar.ForeColor = Color.Navy;
            btnGrabar.Image = Properties.Resources.grabar18;
            btnGrabar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGrabar.Location = new Point(444, 23);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(75, 23);
            btnGrabar.TabIndex = 36;
            btnGrabar.Text = "     Grabar";
            btnGrabar.UseVisualStyleBackColor = false;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(292, 166);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(31, 25);
            btnAgregar.TabIndex = 35;
            btnAgregar.Text = ">>";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvProdDev
            // 
            dgvProdDev.AllowUserToAddRows = false;
            dgvProdDev.AllowUserToDeleteRows = false;
            dgvProdDev.AllowUserToResizeColumns = false;
            dgvProdDev.AllowUserToResizeRows = false;
            dgvProdDev.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProdDev.BackgroundColor = Color.White;
            dgvProdDev.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdDev.GridColor = SystemColors.ControlDark;
            dgvProdDev.Location = new Point(325, 80);
            dgvProdDev.Name = "dgvProdDev";
            dgvProdDev.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvProdDev.Size = new Size(280, 229);
            dgvProdDev.TabIndex = 34;
            dgvProdDev.CellValidated += dgvProdDev_CellValidated;
            dgvProdDev.CellValidating += dgvProdDev_CellValidating;
            // 
            // dgvProdFactura
            // 
            dgvProdFactura.AllowUserToAddRows = false;
            dgvProdFactura.AllowUserToDeleteRows = false;
            dgvProdFactura.AllowUserToResizeColumns = false;
            dgvProdFactura.AllowUserToResizeRows = false;
            dgvProdFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProdFactura.BackgroundColor = Color.White;
            dgvProdFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdFactura.Location = new Point(11, 81);
            dgvProdFactura.Name = "dgvProdFactura";
            dgvProdFactura.ReadOnly = true;
            dgvProdFactura.RowHeadersVisible = false;
            dgvProdFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdFactura.Size = new Size(280, 227);
            dgvProdFactura.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 7);
            label4.Name = "label4";
            label4.Size = new Size(0, 21);
            label4.TabIndex = 14;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtTotalDev);
            groupBox1.Controls.Add(btnImprimir);
            groupBox1.Controls.Add(txtProveedor);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(btnSalir);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(btnNuevo);
            groupBox1.Controls.Add(dgvProductos);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtFecha);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtFactura);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNumero);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(12, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(479, 355);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Visualizar";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(341, 325);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 50;
            label11.Text = "Total :";
            // 
            // txtTotalDev
            // 
            txtTotalDev.Location = new Point(388, 317);
            txtTotalDev.MaxLength = 7;
            txtTotalDev.Name = "txtTotalDev";
            txtTotalDev.ReadOnly = true;
            txtTotalDev.Size = new Size(79, 23);
            txtTotalDev.TabIndex = 49;
            txtTotalDev.TextAlign = HorizontalAlignment.Right;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.CornflowerBlue;
            btnImprimir.FlatStyle = FlatStyle.Popup;
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Image = Properties.Resources.imprimir18;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(91, 321);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(82, 23);
            btnImprimir.TabIndex = 46;
            btnImprimir.Text = "    Imprimir";
            btnImprimir.TextAlign = ContentAlignment.BottomRight;
            btnImprimir.UseVisualStyleBackColor = false;
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(80, 46);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.ReadOnly = true;
            txtProveedor.Size = new Size(386, 23);
            txtProveedor.TabIndex = 45;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 55);
            label9.Name = "label9";
            label9.Size = new Size(67, 15);
            label9.TabIndex = 44;
            label9.Text = "Proveedor :";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.LightCoral;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.DarkRed;
            btnSalir.Image = Properties.Resources.close18;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(260, 321);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 10;
            btnSalir.Text = "   Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.SteelBlue;
            btnBuscar.FlatStyle = FlatStyle.Popup;
            btnBuscar.ForeColor = Color.Azure;
            btnBuscar.Image = Properties.Resources.search__1_;
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(179, 321);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "   Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LightGreen;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.ForeColor = Color.DarkGreen;
            btnNuevo.Image = Properties.Resources.nuevo24;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(12, 321);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "Nuevo";
            btnNuevo.TextAlign = ContentAlignment.BottomRight;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 80);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.Size = new Size(455, 225);
            dgvProductos.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 24);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 7;
            label3.Text = "Fecha :";
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(377, 18);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(89, 23);
            txtFecha.TabIndex = 6;
            txtFecha.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 23);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 5;
            label2.Text = "Factura :";
            // 
            // txtFactura
            // 
            txtFactura.Location = new Point(216, 17);
            txtFactura.Name = "txtFactura";
            txtFactura.ReadOnly = true;
            txtFactura.Size = new Size(74, 23);
            txtFactura.TabIndex = 4;
            txtFactura.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 23);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 3;
            label1.Text = "Folio :";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(49, 15);
            txtNumero.MaxLength = 5;
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(74, 23);
            txtNumero.TabIndex = 2;
            txtNumero.TextAlign = HorizontalAlignment.Center;
            txtNumero.TextChanged += txtNumero_TextChanged;
            txtNumero.KeyPress += txtNumero_KeyPress;
            // 
            // frmDevolucionCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CaptionBarColor = Color.FromArgb(0, 120, 212);
            CaptionFont = new Font("Century Gothic", 14.25F);
            CaptionForeColor = Color.White;
            ClientSize = new Size(1127, 385);
            ControlBox = false;
            Controls.Add(groupBox2);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Name = "frmDevolucionCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Devolución de Refacciones en Factura de Compra";
            Load += frmDevolucionCompra_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdDev).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProdFactura).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private Label label6;
        private TextBox txtFolioNvo;
        private Button btnQuitar;
        private Button btnSalirNuevo;
        private Button btnGrabar;
        private Button btnAgregar;
        private DataGridView dgvProdDev;
        private DataGridView dgvProdFactura;
        private Label label4;
        private GroupBox groupBox1;
        private Button btnSalir;
        private Button btnBuscar;
        private Button btnNuevo;
        private DataGridView dgvProductos;
        private Label label3;
        private TextBox txtFecha;
        private Label label2;
        private TextBox txtVale;
        private Label label1;
        private TextBox txtNumero;
        private ComboBox cboProveedor;
        private Label label8;
        private Label label5;
        private ComboBox cboFactura;
        private DateTimePicker dateTimePicker1;
        private Label label7;
        private Label label9;
        private TextBox txtProveedor;
        private Label label10;
        private TextBox txtTotal;
        private Button btnImprimir;
        private TextBox txtFactura;
        private Label label11;
        private TextBox txtTotalDev;
    }
}