namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmUnidadesMedida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnidadesMedida));
            groupBox1 = new GroupBox();
            txtDescripcion = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnDeshacer = new Button();
            btnGrabar = new Button();
            btnNuevo = new Button();
            btnSalir = new Button();
            dgvMedida = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedida).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtId);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(259, 82);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = Color.White;
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.Location = new Point(89, 55);
            txtDescripcion.MaxLength = 25;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(159, 16);
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
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDeshacer);
            groupBox2.Controls.Add(btnGrabar);
            groupBox2.Controls.Add(btnNuevo);
            groupBox2.Controls.Add(btnSalir);
            groupBox2.Location = new Point(279, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(101, 152);
            groupBox2.TabIndex = 2;
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
            btnGrabar.FlatStyle = FlatStyle.Flat;
            btnGrabar.ForeColor = Color.Navy;
            btnGrabar.Image = Properties.Resources.grabar24;
            btnGrabar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGrabar.Location = new Point(6, 46);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(89, 23);
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
            btnNuevo.Image = Properties.Resources.nuevo24;
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
            btnSalir.Image = Properties.Resources.close24;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(6, 121);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(89, 23);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.TextAlign = ContentAlignment.BottomCenter;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // dgvMedida
            // 
            dgvMedida.AllowUserToAddRows = false;
            dgvMedida.AllowUserToDeleteRows = false;
            dgvMedida.AllowUserToResizeColumns = false;
            dgvMedida.AllowUserToResizeRows = false;
            dgvMedida.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMedida.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedida.Location = new Point(11, 100);
            dgvMedida.Name = "dgvMedida";
            dgvMedida.ReadOnly = true;
            dgvMedida.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedida.Size = new Size(249, 140);
            dgvMedida.TabIndex = 3;
            // 
            // frmUnidadesMedida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            CaptionBarColor = Color.FromArgb(33, 150, 243);
            CaptionFont = new Font("Century Gothic", 14.25F);
            CaptionForeColor = Color.White;
            ClientSize = new Size(391, 251);
            ControlBox = false;
            Controls.Add(dgvMedida);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmUnidadesMedida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Unidad de Medida";
            Load += frmUnidadesMedida_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMedida).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtDescripcion;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnDeshacer;
        private Button btnGrabar;
        private Button btnNuevo;
        private Button btnSalir;
        private DataGridView dgvMedida;
    }
}