namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmLineas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLineas));
            dgvLineas = new DataGridView();
            groupBox2 = new GroupBox();
            btnDeshacer = new Button();
            btnGrabar = new Button();
            btnNuevo = new Button();
            btnSalir = new Button();
            groupBox1 = new GroupBox();
            txtDescripcion = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLineas).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvLineas
            // 
            dgvLineas.AllowUserToAddRows = false;
            dgvLineas.AllowUserToDeleteRows = false;
            dgvLineas.AllowUserToResizeColumns = false;
            dgvLineas.AllowUserToResizeRows = false;
            dgvLineas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLineas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLineas.Location = new Point(7, 89);
            dgvLineas.Name = "dgvLineas";
            dgvLineas.ReadOnly = true;
            dgvLineas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLineas.Size = new Size(374, 140);
            dgvLineas.TabIndex = 6;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDeshacer);
            groupBox2.Controls.Add(btnGrabar);
            groupBox2.Controls.Add(btnNuevo);
            groupBox2.Controls.Add(btnSalir);
            groupBox2.Location = new Point(388, 1);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(103, 152);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            // 
            // btnDeshacer
            // 
            btnDeshacer.BackColor = Color.Gold;
            btnDeshacer.FlatAppearance.BorderSize = 0;
            btnDeshacer.FlatStyle = FlatStyle.Flat;
            btnDeshacer.ForeColor = Color.Chocolate;
            btnDeshacer.Image = (Image)resources.GetObject("btnDeshacer.Image");
            btnDeshacer.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeshacer.Location = new Point(6, 75);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(89, 23);
            btnDeshacer.TabIndex = 4;
            btnDeshacer.Text = "Deshacer";
            btnDeshacer.TextAlign = ContentAlignment.BottomRight;
            btnDeshacer.UseVisualStyleBackColor = false;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // btnGrabar
            // 
            btnGrabar.BackColor = Color.DeepSkyBlue;
            btnGrabar.FlatAppearance.BorderSize = 0;
            btnGrabar.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 182, 185);
            btnGrabar.FlatStyle = FlatStyle.Flat;
            btnGrabar.ForeColor = Color.Navy;
            btnGrabar.Image = (Image)resources.GetObject("btnGrabar.Image");
            btnGrabar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGrabar.Location = new Point(6, 46);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(89, 24);
            btnGrabar.TabIndex = 3;
            btnGrabar.Text = "Grabar    ";
            btnGrabar.TextAlign = ContentAlignment.BottomRight;
            btnGrabar.UseVisualStyleBackColor = false;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LightGreen;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.ForeColor = Color.DarkGreen;
            btnNuevo.Image = (Image)resources.GetObject("btnNuevo.Image");
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(6, 18);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(89, 23);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo    ";
            btnNuevo.TextAlign = ContentAlignment.BottomRight;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.LightCoral;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.DarkRed;
            btnSalir.Image = (Image)resources.GetObject("btnSalir.Image");
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(8, 123);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(89, 23);
            btnSalir.TabIndex = 0;
            btnSalir.Text = " Salir";
            btnSalir.TextAlign = ContentAlignment.BottomCenter;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtId);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(8, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(372, 82);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = Color.White;
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.Location = new Point(89, 55);
            txtDescripcion.MaxLength = 90;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(272, 16);
            txtDescripcion.TabIndex = 7;
            txtDescripcion.KeyPress += txtDescripcion_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 55);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 6;
            label2.Text = "Descripción :";
            // 
            // txtId
            // 
            txtId.Location = new Point(89, 18);
            txtId.MaxLength = 2;
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(31, 23);
            txtId.TabIndex = 5;
            txtId.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Location = new Point(8, 26);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 4;
            label1.Text = "Id :";
            // 
            // frmLineas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            CaptionBarColor = Color.FromArgb(0, 120, 212);
            CaptionFont = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CaptionForeColor = Color.White;
            ClientSize = new Size(495, 254);
            ControlBox = false;
            Controls.Add(dgvLineas);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmLineas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lineas";
            Load += frmLineas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLineas).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvLineas;
        private GroupBox groupBox2;
        private Button btnDeshacer;
        private Button btnGrabar;
        private Button btnNuevo;
        private Button btnSalir;
        private GroupBox groupBox1;
        private TextBox txtDescripcion;
        private Label label2;
        private TextBox txtId;
        private Label label1;
    }
}