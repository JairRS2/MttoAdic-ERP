namespace MttoAdic_ERP.Forms.Almacen.SeccionesUrea
{
    partial class seccionCompras
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            panel4 = new Panel();
            dgvComprasUrea = new DataGridView();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            txtBuscar = new TextBox();
            cmbFiltro = new ComboBox();
            btnNuevaCompra = new MttoAdic_ERP.CustomRenderer.BotonRedondeado();
            panel2 = new Panel();
            label1 = new Label();
            toolTipBuscar = new ToolTip(components);
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComprasUrea).BeginInit();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(651, 322);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvComprasUrea);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 39);
            panel4.Name = "panel4";
            panel4.Size = new Size(486, 283);
            panel4.TabIndex = 3;
            // 
            // dgvComprasUrea
            // 
            dgvComprasUrea.AllowUserToAddRows = false;
            dgvComprasUrea.AllowUserToDeleteRows = false;
            dgvComprasUrea.AllowUserToResizeColumns = false;
            dgvComprasUrea.AllowUserToResizeRows = false;
            dgvComprasUrea.BackgroundColor = Color.WhiteSmoke;
            dgvComprasUrea.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvComprasUrea.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvComprasUrea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComprasUrea.Dock = DockStyle.Fill;
            dgvComprasUrea.GridColor = SystemColors.ControlLight;
            dgvComprasUrea.Location = new Point(0, 0);
            dgvComprasUrea.MultiSelect = false;
            dgvComprasUrea.Name = "dgvComprasUrea";
            dgvComprasUrea.ReadOnly = true;
            dgvComprasUrea.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvComprasUrea.RowHeadersVisible = false;
            dgvComprasUrea.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComprasUrea.Size = new Size(486, 283);
            dgvComprasUrea.TabIndex = 0;
            dgvComprasUrea.CellDoubleClick += dgvComprasUrea_CellDoubleClick;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(226, 236, 248);
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(btnNuevaCompra);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(486, 39);
            panel3.Name = "panel3";
            panel3.Size = new Size(165, 283);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(cmbFiltro);
            groupBox1.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(0, 45, 84);
            groupBox1.Location = new Point(2, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(158, 107);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Buscar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 61);
            label3.Name = "label3";
            label3.Size = new Size(41, 14);
            label3.TabIndex = 4;
            label3.Text = "Filtrar";
            // 
            // label2
            // 
            label2.Image = Properties.Resources.filtro1;
            label2.Location = new Point(6, 60);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 3;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(5, 22);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(147, 21);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // cmbFiltro
            // 
            cmbFiltro.ForeColor = Color.FromArgb(0, 45, 84);
            cmbFiltro.FormattingEnabled = true;
            cmbFiltro.Location = new Point(5, 78);
            cmbFiltro.Name = "cmbFiltro";
            cmbFiltro.Size = new Size(147, 22);
            cmbFiltro.TabIndex = 2;
            cmbFiltro.Text = "Seleccionar..";
            cmbFiltro.SelectedIndexChanged += cmbFiltro_SelectedIndexChanged;
            // 
            // btnNuevaCompra
            // 
            btnNuevaCompra.BackColor = Color.LightGreen;
            btnNuevaCompra.BackgroundColor = Color.LightGreen;
            btnNuevaCompra.BorderColor = Color.PaleVioletRed;
            btnNuevaCompra.BorderRadius = 15;
            btnNuevaCompra.BorderSize = 0;
            btnNuevaCompra.FlatAppearance.BorderSize = 0;
            btnNuevaCompra.FlatStyle = FlatStyle.Flat;
            btnNuevaCompra.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevaCompra.ForeColor = Color.DarkGreen;
            btnNuevaCompra.Image = Properties.Resources.nuevo24;
            btnNuevaCompra.Location = new Point(3, 119);
            btnNuevaCompra.Name = "btnNuevaCompra";
            btnNuevaCompra.Size = new Size(157, 33);
            btnNuevaCompra.TabIndex = 0;
            btnNuevaCompra.Text = "   Nuevo";
            btnNuevaCompra.TextColor = Color.DarkGreen;
            btnNuevaCompra.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevaCompra.UseVisualStyleBackColor = false;
            btnNuevaCompra.Click += btnNuevaCompra_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(226, 236, 248);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(651, 39);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 45, 84);
            label1.Location = new Point(226, 9);
            label1.Name = "label1";
            label1.Size = new Size(143, 22);
            label1.TabIndex = 0;
            label1.Text = "Compras Urea";
            // 
            // toolTipBuscar
            // 
            toolTipBuscar.ShowAlways = true;
            toolTipBuscar.ToolTipTitle = "Buscar";
            // 
            // seccionCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 322);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "seccionCompras";
            Text = "seccionCompras";
            Load += seccionCompras_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvComprasUrea).EndInit();
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvComprasUrea;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private CustomRenderer.BotonRedondeado btnNuevaCompra;
        private Label label1;
        private TextBox txtBuscar;
        private ComboBox cmbFiltro;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private ToolTip toolTipBuscar;
    }
}