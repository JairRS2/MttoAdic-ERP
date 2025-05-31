namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmParametros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametros));
            groupBox3 = new GroupBox();
            label4 = new Label();
            txtValor = new TextBox();
            txtDescripcion = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            button1 = new Button();
            btnDeshacer = new Button();
            btnGrabar = new Button();
            btnModificar = new Button();
            btnNuevo = new Button();
            btnSalir = new Button();
            dgvParametros = new DataGridView();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParametros).BeginInit();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(txtValor);
            groupBox3.Controls.Add(txtDescripcion);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(txtId);
            groupBox3.Controls.Add(label1);
            groupBox3.Location = new Point(9, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(360, 115);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 86);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 12;
            label4.Text = "Valor :";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(90, 78);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(44, 23);
            txtValor.TabIndex = 11;
            txtValor.KeyPress += txtValor_KeyPress;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(90, 49);
            txtDescripcion.MaxLength = 25;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(255, 23);
            txtDescripcion.TabIndex = 10;
            txtDescripcion.KeyPress += txtDescripcion_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 57);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 9;
            label2.Text = "Descripción :";
            // 
            // txtId
            // 
            txtId.Location = new Point(90, 20);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(43, 23);
            txtId.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 28);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 7;
            label1.Text = "Id :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(btnDeshacer);
            groupBox2.Controls.Add(btnGrabar);
            groupBox2.Controls.Add(btnModificar);
            groupBox2.Controls.Add(btnNuevo);
            groupBox2.Controls.Add(btnSalir);
            groupBox2.Location = new Point(375, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(103, 175);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.LightCoral;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.DarkRed;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(6, 146);
            button1.Name = "button1";
            button1.Size = new Size(89, 23);
            button1.TabIndex = 5;
            button1.Text = " Salir";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnDeshacer
            // 
            btnDeshacer.BackColor = Color.Gold;
            btnDeshacer.FlatStyle = FlatStyle.Flat;
            btnDeshacer.ForeColor = Color.Chocolate;
            btnDeshacer.Image = Properties.Resources.deshacer24;
            btnDeshacer.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeshacer.Location = new Point(6, 104);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(89, 23);
            btnDeshacer.TabIndex = 4;
            btnDeshacer.Text = "Deshacer";
            btnDeshacer.TextAlign = ContentAlignment.MiddleRight;
            btnDeshacer.UseVisualStyleBackColor = false;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // btnGrabar
            // 
            btnGrabar.BackColor = Color.DeepSkyBlue;
            btnGrabar.FlatStyle = FlatStyle.Flat;
            btnGrabar.ForeColor = Color.Navy;
            btnGrabar.Image = Properties.Resources.grabar24;
            btnGrabar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGrabar.Location = new Point(6, 75);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(89, 24);
            btnGrabar.TabIndex = 3;
            btnGrabar.Text = "      Grabar";
            btnGrabar.UseVisualStyleBackColor = false;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.CornflowerBlue;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI", 9F);
            btnModificar.ForeColor = Color.White;
            btnModificar.Image = Properties.Resources.update24;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(6, 46);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(89, 23);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.TextAlign = ContentAlignment.BottomRight;
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LightGreen;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.ForeColor = Color.DarkGreen;
            btnNuevo.Image = Properties.Resources.nuevo24;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(6, 18);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(89, 23);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "     Nuevo";
            btnNuevo.TextAlign = ContentAlignment.BottomCenter;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(6, 191);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // dgvParametros
            // 
            dgvParametros.AllowUserToAddRows = false;
            dgvParametros.AllowUserToDeleteRows = false;
            dgvParametros.AllowUserToResizeColumns = false;
            dgvParametros.AllowUserToResizeRows = false;
            dgvParametros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvParametros.BackgroundColor = Color.White;
            dgvParametros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParametros.Location = new Point(8, 123);
            dgvParametros.Name = "dgvParametros";
            dgvParametros.ReadOnly = true;
            dgvParametros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParametros.Size = new Size(361, 100);
            dgvParametros.TabIndex = 4;
            dgvParametros.CellClick += dgvParametros_CellClick;
            // 
            // frmParametros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            CaptionBarColor = Color.FromArgb(0, 120, 212);
            CaptionFont = new Font("Century Gothic", 14.25F);
            CaptionForeColor = Color.White;
            ClientSize = new Size(495, 254);
            ControlBox = false;
            Controls.Add(dgvParametros);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmParametros";
            Text = "Catálogo de Parámetros";
            Load += frmParametros_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvParametros).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private Label label4;
        private TextBox txtValor;
        private TextBox txtDescripcion;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnDeshacer;
        private Button btnGrabar;
        private Button btnModificar;
        private Button btnNuevo;
        private Button btnSalir;
        private DataGridView dgvParametros;
        private Button button1;
    }
}