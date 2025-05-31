namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmDevolucionVale
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
            btnSalir = new Button();
            btnBuscar = new Button();
            btnNuevo = new Button();
            dgvProductos = new DataGridView();
            label3 = new Label();
            txtFecha = new TextBox();
            label2 = new Label();
            txtVale = new TextBox();
            label1 = new Label();
            txtNumero = new TextBox();
            groupBox2 = new GroupBox();
            txtCveEmpresa = new TextBox();
            txtUnidad = new TextBox();
            label8 = new Label();
            txtEmpresa = new TextBox();
            label7 = new Label();
            label6 = new Label();
            txtFolioNvo = new TextBox();
            btnQuitar = new Button();
            btnSalirNuevo = new Button();
            btnGrabar = new Button();
            btnAgregar = new Button();
            dgvProdDev = new DataGridView();
            dgvProdVale = new DataGridView();
            btnVale = new Button();
            label5 = new Label();
            txtBuscaVale = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdDev).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProdVale).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSalir);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(btnNuevo);
            groupBox1.Controls.Add(dgvProductos);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtFecha);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtVale);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNumero);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(479, 355);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Visualizar";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.LightCoral;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.DarkRed;
            btnSalir.Image = Properties.Resources.close24;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(393, 321);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 10;
            btnSalir.Text = "     Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.SteelBlue;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.Azure;
            btnBuscar.Image = Properties.Resources.search__1_;
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(207, 322);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.BottomRight;
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
            btnNuevo.Location = new Point(11, 321);
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
            label3.Location = new Point(400, 24);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 7;
            label3.Text = "Fecha";
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(376, 46);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(89, 23);
            txtFecha.TabIndex = 6;
            txtFecha.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(213, 23);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 5;
            label2.Text = "Vale";
            // 
            // txtVale
            // 
            txtVale.Location = new Point(193, 45);
            txtVale.Name = "txtVale";
            txtVale.ReadOnly = true;
            txtVale.Size = new Size(74, 23);
            txtVale.TabIndex = 4;
            txtVale.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 22);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 3;
            label1.Text = "Folio";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(11, 44);
            txtNumero.MaxLength = 5;
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(74, 23);
            txtNumero.TabIndex = 2;
            txtNumero.TextAlign = HorizontalAlignment.Center;
            txtNumero.KeyPress += txtNumero_KeyPress;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtCveEmpresa);
            groupBox2.Controls.Add(txtUnidad);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtEmpresa);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtFolioNvo);
            groupBox2.Controls.Add(btnQuitar);
            groupBox2.Controls.Add(btnSalirNuevo);
            groupBox2.Controls.Add(btnGrabar);
            groupBox2.Controls.Add(btnAgregar);
            groupBox2.Controls.Add(dgvProdDev);
            groupBox2.Controls.Add(dgvProdVale);
            groupBox2.Controls.Add(btnVale);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtBuscaVale);
            groupBox2.Location = new Point(505, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(616, 354);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nuevo Registro";
            // 
            // txtCveEmpresa
            // 
            txtCveEmpresa.Location = new Point(469, 53);
            txtCveEmpresa.MaxLength = 7;
            txtCveEmpresa.Name = "txtCveEmpresa";
            txtCveEmpresa.ReadOnly = true;
            txtCveEmpresa.Size = new Size(18, 23);
            txtCveEmpresa.TabIndex = 45;
            txtCveEmpresa.TextAlign = HorizontalAlignment.Center;
            txtCveEmpresa.Visible = false;
            // 
            // txtUnidad
            // 
            txtUnidad.Location = new Point(545, 55);
            txtUnidad.MaxLength = 7;
            txtUnidad.Name = "txtUnidad";
            txtUnidad.ReadOnly = true;
            txtUnidad.Size = new Size(60, 23);
            txtUnidad.TabIndex = 44;
            txtUnidad.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(487, 63);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 43;
            label8.Text = "Unidad :";
            // 
            // txtEmpresa
            // 
            txtEmpresa.Location = new Point(73, 53);
            txtEmpresa.MaxLength = 7;
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.ReadOnly = true;
            txtEmpresa.Size = new Size(393, 23);
            txtEmpresa.TabIndex = 42;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 61);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 41;
            label7.Text = "Empresa :";
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
            btnSalirNuevo.Image = Properties.Resources.close24;
            btnSalirNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalirNuevo.Location = new Point(530, 22);
            btnSalirNuevo.Name = "btnSalirNuevo";
            btnSalirNuevo.Size = new Size(75, 23);
            btnSalirNuevo.TabIndex = 37;
            btnSalirNuevo.Text = "    Salir";
            btnSalirNuevo.UseVisualStyleBackColor = false;
            btnSalirNuevo.Click += btnSalirNuevo_Click;
            // 
            // btnGrabar
            // 
            btnGrabar.BackColor = Color.DeepSkyBlue;
            btnGrabar.FlatStyle = FlatStyle.Flat;
            btnGrabar.ForeColor = Color.Navy;
            btnGrabar.Image = Properties.Resources.grabar24;
            btnGrabar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGrabar.Location = new Point(444, 23);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(75, 23);
            btnGrabar.TabIndex = 36;
            btnGrabar.Text = "Grabar";
            btnGrabar.TextAlign = ContentAlignment.BottomRight;
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
            dgvProdDev.Location = new Point(325, 83);
            dgvProdDev.Name = "dgvProdDev";
            dgvProdDev.ReadOnly = true;
            dgvProdDev.RowHeadersVisible = false;
            dgvProdDev.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdDev.Size = new Size(280, 260);
            dgvProdDev.TabIndex = 34;
            // 
            // dgvProdVale
            // 
            dgvProdVale.AllowUserToAddRows = false;
            dgvProdVale.AllowUserToDeleteRows = false;
            dgvProdVale.AllowUserToResizeColumns = false;
            dgvProdVale.AllowUserToResizeRows = false;
            dgvProdVale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProdVale.BackgroundColor = Color.White;
            dgvProdVale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdVale.Location = new Point(11, 85);
            dgvProdVale.Name = "dgvProdVale";
            dgvProdVale.ReadOnly = true;
            dgvProdVale.RowHeadersVisible = false;
            dgvProdVale.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdVale.Size = new Size(280, 257);
            dgvProdVale.TabIndex = 33;
            // 
            // btnVale
            // 
            btnVale.Location = new Point(341, 23);
            btnVale.Name = "btnVale";
            btnVale.Size = new Size(21, 25);
            btnVale.TabIndex = 32;
            btnVale.Text = "?";
            btnVale.UseVisualStyleBackColor = true;
            btnVale.Click += btnVale_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(212, 32);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 5;
            label5.Text = "Vale :";
            // 
            // txtBuscaVale
            // 
            txtBuscaVale.Location = new Point(259, 24);
            txtBuscaVale.MaxLength = 7;
            txtBuscaVale.Name = "txtBuscaVale";
            txtBuscaVale.Size = new Size(79, 23);
            txtBuscaVale.TabIndex = 4;
            txtBuscaVale.TextAlign = HorizontalAlignment.Center;
            txtBuscaVale.KeyPress += txtBuscaVale_KeyPress;
            // 
            // frmDevolucionVale
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CaptionBarColor = Color.FromArgb(0, 120, 212);
            CaptionFont = new Font("Century Gothic", 14.25F);
            CaptionForeColor = Color.White;
            ClientSize = new Size(1128, 399);
            ControlBox = false;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmDevolucionVale";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Devolución de Refacciones en Vales";
            Load += frmDevolucionVale_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdDev).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProdVale).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtNumero;
        private Label label3;
        private TextBox txtFecha;
        private Label label2;
        private TextBox txtVale;
        private Button btnBuscar;
        private Button btnNuevo;
        private DataGridView dgvProductos;
        private Button btnSalir;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox txtBuscaVale;
        private Button btnVale;
        private DataGridView dgvProdVale;
        private DataGridView dgvProdDev;
        private Button btnAgregar;
        private Button btnSalirNuevo;
        private Button btnGrabar;
        private Button btnQuitar;
        private Label label6;
        private TextBox txtFolioNvo;
        private TextBox txtEmpresa;
        private Label label7;
        private TextBox txtUnidad;
        private Label label8;
        private TextBox txtCveEmpresa;
    }
}