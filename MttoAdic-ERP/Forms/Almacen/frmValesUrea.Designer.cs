namespace MttoAdic_ERP.Forms
{
    partial class frmValesUrea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValesUrea));
            dgvValesUrea = new DataGridView();
            txtBuscar = new TextBox();
            cmbFiltro = new ComboBox();
            label2 = new Label();
            pnlEncabezado = new Panel();
            lblTitulo = new Label();
            btnNuevoVale = new CustomRenderer.BotonRedondeado();
            panel1 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvValesUrea).BeginInit();
            pnlEncabezado.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvValesUrea
            // 
            dgvValesUrea.AllowUserToAddRows = false;
            dgvValesUrea.AllowUserToDeleteRows = false;
            dgvValesUrea.AllowUserToResizeColumns = false;
            dgvValesUrea.AllowUserToResizeRows = false;
            dgvValesUrea.BackgroundColor = Color.WhiteSmoke;
            dgvValesUrea.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvValesUrea.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvValesUrea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvValesUrea.Dock = DockStyle.Fill;
            dgvValesUrea.GridColor = SystemColors.ControlLight;
            dgvValesUrea.Location = new Point(0, 0);
            dgvValesUrea.MultiSelect = false;
            dgvValesUrea.Name = "dgvValesUrea";
            dgvValesUrea.ReadOnly = true;
            dgvValesUrea.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvValesUrea.RowHeadersVisible = false;
            dgvValesUrea.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvValesUrea.Size = new Size(731, 472);
            dgvValesUrea.TabIndex = 0;
            dgvValesUrea.CellDoubleClick += dgvValesUrea_CellDoubleClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(5, 19);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(147, 22);
            txtBuscar.TabIndex = 46;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // cmbFiltro
            // 
            cmbFiltro.DisplayMember = "1";
            cmbFiltro.ForeColor = Color.FromArgb(0, 45, 84);
            cmbFiltro.FormattingEnabled = true;
            cmbFiltro.Location = new Point(5, 73);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(147, 22);
            cmbFiltro.TabIndex = 47;
            cmbFiltro.Text = "Seleccionar..";
            cmbFiltro.SelectedIndexChanged += cmbFiltro_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(6, 55);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 49;
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(226, 236, 248);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(896, 39);
            pnlEncabezado.TabIndex = 50;
            pnlEncabezado.MouseDown += pnlEncabezado_MouseDown;
            pnlEncabezado.MouseMove += pnlEncabezado_MouseMove;
            pnlEncabezado.MouseUp += pnlEncabezado_MouseUp;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(0, 45, 84);
            lblTitulo.Location = new Point(392, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(109, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Vales Urea";
            // 
            // btnNuevoVale
            // 
            btnNuevoVale.BackColor = Color.LightGreen;
            btnNuevoVale.BackgroundColor = Color.LightGreen;
            btnNuevoVale.BorderColor = Color.PaleVioletRed;
            btnNuevoVale.BorderRadius = 15;
            btnNuevoVale.BorderSize = 0;
            btnNuevoVale.FlatAppearance.BorderSize = 0;
            btnNuevoVale.FlatStyle = FlatStyle.Flat;
            btnNuevoVale.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevoVale.ForeColor = Color.DarkGreen;
            btnNuevoVale.Image = Properties.Resources.nuevo24;
            btnNuevoVale.Location = new Point(3, 117);
            btnNuevoVale.Name = "btnNuevoVale";
            btnNuevoVale.Size = new Size(158, 33);
            btnNuevoVale.TabIndex = 51;
            btnNuevoVale.Text = "   Nuevo";
            btnNuevoVale.TextColor = Color.DarkGreen;
            btnNuevoVale.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevoVale.UseVisualStyleBackColor = false;
            btnNuevoVale.Click += btnNuevoVale_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pnlEncabezado);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(896, 511);
            panel1.TabIndex = 51;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvValesUrea);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 39);
            panel3.Name = "panel3";
            panel3.Size = new Size(731, 472);
            panel3.TabIndex = 52;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(226, 236, 248);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(btnNuevoVale);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(731, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(165, 472);
            panel2.TabIndex = 51;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbFiltro);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(0, 45, 84);
            groupBox1.Location = new Point(4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(158, 107);
            groupBox1.TabIndex = 52;
            groupBox1.TabStop = false;
            groupBox1.Text = "Buscar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 55);
            label1.Name = "label1";
            label1.Size = new Size(41, 14);
            label1.TabIndex = 50;
            label1.Text = "Filtrar";
            // 
            // frmValesUrea
            // 
            AllowRoundedCorners = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CaptionBarColor = Color.FromArgb(0, 120, 212);
            CaptionButtonColor = Color.White;
            CaptionButtonHoverColor = Color.White;
            CaptionFont = new Font("Century Gothic", 14.25F);
            CaptionForeColor = Color.White;
            ClientSize = new Size(896, 511);
            ControlBox = false;
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmValesUrea";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vales Urea ";
            Load += ValesUrea_Load;
            ((System.ComponentModel.ISupportInitialize)dgvValesUrea).EndInit();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvValesUrea;
        private TextBox txtBuscar;
        private ComboBox cmbFiltro;
        private Label label2;
        private Panel pnlEncabezado;
        private Label lblTitulo;
        private CustomRenderer.BotonRedondeado btnNuevoVale;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private GroupBox groupBox1;
        private Label label1;
    }
}