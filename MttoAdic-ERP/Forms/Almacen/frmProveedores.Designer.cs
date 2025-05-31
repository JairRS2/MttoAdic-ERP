namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmProveedores
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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            groupBox3 = new GroupBox();
            cboLinea = new ComboBox();
            label8 = new Label();
            txtAbreviatura = new TextBox();
            label6 = new Label();
            txtProveedor = new TextBox();
            label5 = new Label();
            txtLimite = new TextBox();
            label2 = new Label();
            txtDias = new TextBox();
            label7 = new Label();
            label4 = new Label();
            txtContacto = new TextBox();
            txtClave = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnSalir = new CustomRenderer.BotonRedondeado();
            btnDeshacer = new CustomRenderer.BotonRedondeado();
            btnGrabar = new CustomRenderer.BotonRedondeado();
            btnNuevo = new CustomRenderer.BotonRedondeado();
            dgvProveedores = new DataGridView();
            lblCatalogoProv = new Label();
            panelTop = new Panel();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cboLinea);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(txtAbreviatura);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(txtProveedor);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(txtLimite);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(txtDias);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(txtContacto);
            groupBox3.Controls.Add(txtClave);
            groupBox3.Controls.Add(label1);
            groupBox3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(9, 45);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(754, 142);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            // 
            // cboLinea
            // 
            cboLinea.FormattingEnabled = true;
            cboLinea.Location = new Point(241, 47);
            cboLinea.Name = "cboLinea";
            cboLinea.Size = new Size(123, 25);
            cboLinea.TabIndex = 53;
            cboLinea.KeyPress += cboLinea_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(189, 50);
            label8.Name = "label8";
            label8.Size = new Size(46, 17);
            label8.TabIndex = 52;
            label8.Text = "Linea :";
            // 
            // txtAbreviatura
            // 
            txtAbreviatura.Location = new Point(102, 50);
            txtAbreviatura.MaxLength = 10;
            txtAbreviatura.Name = "txtAbreviatura";
            txtAbreviatura.Size = new Size(68, 22);
            txtAbreviatura.TabIndex = 51;
            txtAbreviatura.KeyPress += txtAbreviatura_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 50);
            label6.Name = "label6";
            label6.Size = new Size(89, 17);
            label6.TabIndex = 50;
            label6.Text = "Abreviatura : ";
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(90, 18);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(414, 22);
            txtProveedor.TabIndex = 49;
            txtProveedor.KeyPress += txtProveedor_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(491, 50);
            label5.Name = "label5";
            label5.Size = new Size(117, 17);
            label5.TabIndex = 48;
            label5.Text = "Límite de Crédito :";
            // 
            // txtLimite
            // 
            txtLimite.Location = new Point(614, 50);
            txtLimite.MaxLength = 10;
            txtLimite.Name = "txtLimite";
            txtLimite.Size = new Size(91, 22);
            txtLimite.TabIndex = 47;
            txtLimite.KeyPress += txtLimite_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(383, 50);
            label2.Name = "label2";
            label2.Size = new Size(39, 17);
            label2.TabIndex = 46;
            label2.Text = "Días :";
            // 
            // txtDias
            // 
            txtDias.Location = new Point(428, 45);
            txtDias.MaxLength = 3;
            txtDias.Name = "txtDias";
            txtDias.Size = new Size(40, 22);
            txtDias.TabIndex = 45;
            txtDias.KeyPress += txtDias_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 21);
            label7.Name = "label7";
            label7.Size = new Size(77, 17);
            label7.TabIndex = 44;
            label7.Text = "Proveedor :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 99);
            label4.Name = "label4";
            label4.Size = new Size(72, 17);
            label4.TabIndex = 12;
            label4.Text = "Contacto :";
            // 
            // txtContacto
            // 
            txtContacto.Location = new Point(85, 96);
            txtContacto.MaxLength = 60;
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(628, 22);
            txtContacto.TabIndex = 11;
            txtContacto.KeyPress += txtContacto_KeyPress;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(614, 18);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(91, 22);
            txtClave.TabIndex = 8;
            txtClave.KeyPress += txtClave_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(558, 21);
            label1.Name = "label1";
            label1.Size = new Size(50, 17);
            label1.TabIndex = 7;
            label1.Text = "Clave :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSalir);
            groupBox2.Controls.Add(btnDeshacer);
            groupBox2.Controls.Add(btnGrabar);
            groupBox2.Controls.Add(btnNuevo);
            groupBox2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(769, 47);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(118, 317);
            groupBox2.TabIndex = 3;
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
            btnSalir.Location = new Point(6, 275);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(106, 36);
            btnSalir.TabIndex = 15;
            btnSalir.Text = "Salir";
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
            btnDeshacer.Location = new Point(6, 55);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(106, 36);
            btnDeshacer.TabIndex = 14;
            btnDeshacer.Text = "Deshacer";
            btnDeshacer.TextColor = Color.Chocolate;
            btnDeshacer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeshacer.UseVisualStyleBackColor = false;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // btnGrabar
            // 
            btnGrabar.BackColor = Color.CornflowerBlue;
            btnGrabar.BackgroundColor = Color.CornflowerBlue;
            btnGrabar.BorderColor = Color.PaleVioletRed;
            btnGrabar.BorderRadius = 15;
            btnGrabar.BorderSize = 0;
            btnGrabar.FlatAppearance.BorderSize = 0;
            btnGrabar.FlatStyle = FlatStyle.Flat;
            btnGrabar.ForeColor = Color.White;
            btnGrabar.Image = Properties.Resources.save24;
            btnGrabar.Location = new Point(6, 97);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(106, 36);
            btnGrabar.TabIndex = 13;
            btnGrabar.Text = "Grabar";
            btnGrabar.TextColor = Color.White;
            btnGrabar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGrabar.UseVisualStyleBackColor = false;
            btnGrabar.Click += btnGrabar_Click;
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
            btnNuevo.Location = new Point(6, 13);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(106, 36);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "Nuevo";
            btnNuevo.TextColor = Color.DarkGreen;
            btnNuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dgvProveedores
            // 
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AllowUserToDeleteRows = false;
            dgvProveedores.AllowUserToResizeColumns = false;
            dgvProveedores.AllowUserToResizeRows = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Window;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgvProveedores.DefaultCellStyle = dataGridViewCellStyle10;
            dgvProveedores.Location = new Point(9, 193);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(754, 171);
            dgvProveedores.TabIndex = 4;
            dgvProveedores.CellDoubleClick += dgvProveedores_CellDoubleClick_1;
            // 
            // lblCatalogoProv
            // 
            lblCatalogoProv.AutoSize = true;
            lblCatalogoProv.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCatalogoProv.ForeColor = Color.White;
            lblCatalogoProv.Location = new Point(339, 9);
            lblCatalogoProv.Name = "lblCatalogoProv";
            lblCatalogoProv.Size = new Size(201, 21);
            lblCatalogoProv.TabIndex = 10;
            lblCatalogoProv.Text = "Catálogo de Proveedores";
            // 
            // panelTop
            // 
            panelTop.AccessibleName = "panelTop";
            panelTop.BackColor = Color.FromArgb(33, 150, 243);
            panelTop.Controls.Add(lblCatalogoProv);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(892, 39);
            panelTop.TabIndex = 11;
            panelTop.MouseDown += panelTop_MouseDown;
            panelTop.MouseMove += panelTop_MouseMove;
            panelTop.MouseUp += panelTop_MouseUp;
            // 
            // frmProveedores
            // 
            AllowRoundedCorners = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(892, 374);
            ControlBox = false;
            Controls.Add(panelTop);
            Controls.Add(dgvProveedores);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmProveedores_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private Label label4;
        private TextBox txtContacto;
        private GroupBox groupBox2;
        private DataGridView dgvProveedores;
        private Label lblCatalogoProv;
        private TextBox txtClave;
        private Label label1;
        private Label label7;
        private Label label5;
        private TextBox txtLimite;
        private Label label2;
        private TextBox txtDias;
        private TextBox txtProveedor;
        private Label label8;
        private TextBox txtAbreviatura;
        private Label label6;
        private ComboBox cboLinea;
        private CustomRenderer.BotonRedondeado btnNuevo;
        private CustomRenderer.BotonRedondeado btnGrabar;
        private CustomRenderer.BotonRedondeado btnDeshacer;
        private CustomRenderer.BotonRedondeado btnSalir;
        private Panel panelTop;
    }
}