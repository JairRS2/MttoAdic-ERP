namespace MttoAdic_ERP.Forms.Almacen.Productos
{
    partial class frmProductosIndex
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductosIndex));
            panel1 = new Panel();
            label1 = new Label();
            lblcodigo = new Label();
            cbxEstado = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            btnActualizar = new Button();
            cbxExistencia = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            cbxLinea = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtBuscar = new TextBox();
            panel2 = new Panel();
            panel4 = new Panel();
            dgvProductos = new DataGridView();
            panel3 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            label6 = new Label();
            btnAjuste = new Button();
            btnLinea = new Button();
            label2 = new Label();
            label5 = new Label();
            btnTraspaso = new Button();
            btnMedida = new Button();
            label3 = new Label();
            label4 = new Label();
            btnKardex = new Button();
            panel5 = new Panel();
            button1 = new Button();
            btnAgregar = new Button();
            btnInventario = new Button();
            btnExportar = new Button();
            btnEstado = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cbxEstado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbxExistencia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbxLinea).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblcodigo);
            panel1.Controls.Add(cbxEstado);
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(cbxExistencia);
            panel1.Controls.Add(cbxLinea);
            panel1.Controls.Add(txtBuscar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1648, 55);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1160, 21);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 11;
            label1.Text = "Seleccionado :";
            // 
            // lblcodigo
            // 
            lblcodigo.AutoSize = true;
            lblcodigo.Location = new Point(1265, 21);
            lblcodigo.Name = "lblcodigo";
            lblcodigo.Size = new Size(38, 15);
            lblcodigo.TabIndex = 10;
            lblcodigo.Text = "label1";
            // 
            // cbxEstado
            // 
            cbxEstado.BackColor = Color.FromArgb(0, 73, 173);
            cbxEstado.BeforeTouchSize = new Size(121, 23);
            cbxEstado.Border3DStyle = Border3DStyle.RaisedOuter;
            cbxEstado.ForeColor = Color.White;
            cbxEstado.Location = new Point(449, 16);
            cbxEstado.MetroBorderColor = Color.DodgerBlue;
            cbxEstado.MetroColor = Color.DodgerBlue;
            cbxEstado.Name = "cbxEstado";
            cbxEstado.Size = new Size(121, 23);
            cbxEstado.TabIndex = 9;
            cbxEstado.SelectedIndexChanged += cbxEstado_SelectedIndexChanged;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.DodgerBlue;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Image = Properties.Resources.update24;
            btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnActualizar.Location = new Point(291, 19);
            btnActualizar.Margin = new Padding(0);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(90, 20);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.TextAlign = ContentAlignment.MiddleRight;
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // cbxExistencia
            // 
            cbxExistencia.BackColor = Color.FromArgb(0, 73, 173);
            cbxExistencia.BeforeTouchSize = new Size(121, 23);
            cbxExistencia.Border3DStyle = Border3DStyle.RaisedOuter;
            cbxExistencia.ForeColor = Color.White;
            cbxExistencia.Location = new Point(709, 16);
            cbxExistencia.MetroBorderColor = Color.DodgerBlue;
            cbxExistencia.MetroColor = Color.DodgerBlue;
            cbxExistencia.Name = "cbxExistencia";
            cbxExistencia.Size = new Size(121, 23);
            cbxExistencia.TabIndex = 7;
            cbxExistencia.SelectedIndexChanged += cbxExistencia_SelectedIndexChanged;
            // 
            // cbxLinea
            // 
            cbxLinea.BackColor = Color.FromArgb(0, 73, 173);
            cbxLinea.BeforeTouchSize = new Size(121, 23);
            cbxLinea.Border3DStyle = Border3DStyle.RaisedOuter;
            cbxLinea.ForeColor = Color.White;
            cbxLinea.Location = new Point(579, 16);
            cbxLinea.MetroBorderColor = Color.DodgerBlue;
            cbxLinea.MetroColor = Color.DodgerBlue;
            cbxLinea.Name = "cbxLinea";
            cbxLinea.Size = new Size(121, 23);
            cbxLinea.TabIndex = 4;
            cbxLinea.SelectedIndexChanged += cbxLinea_SelectedIndexChanged;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(29, 19);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar producto...";
            txtBuscar.Size = new Size(259, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(1648, 646);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvProductos);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1500, 646);
            panel4.TabIndex = 16;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.DarkGray;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.LightPink;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkViolet;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.Violet;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.GridColor = SystemColors.ControlLight;
            dgvProductos.Location = new Point(0, 0);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Pink;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkViolet;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(1500, 646);
            dgvProductos.TabIndex = 3;
            dgvProductos.CellClick += dgvProductos_CellClick;
            dgvProductos.CellDoubleClick += dgvProductos_CellDoubleClick;
            dgvProductos.DataBindingComplete += dgvProductos_DataBindingComplete;
            dgvProductos.RowEnter += dgvProductos_RowEnter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1500, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(148, 646);
            panel3.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel7);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 245);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(5, 0, 5, 5);
            panel6.Size = new Size(148, 401);
            panel6.TabIndex = 16;
            // 
            // panel7
            // 
            panel7.BackColor = Color.LightSkyBlue;
            panel7.Controls.Add(label6);
            panel7.Controls.Add(btnAjuste);
            panel7.Controls.Add(btnLinea);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(label5);
            panel7.Controls.Add(btnTraspaso);
            panel7.Controls.Add(btnMedida);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(btnKardex);
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(5, 260);
            panel7.Name = "panel7";
            panel7.Size = new Size(138, 136);
            panel7.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(27, 8);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 19;
            label6.Text = "Lineas";
            // 
            // btnAjuste
            // 
            btnAjuste.BackColor = Color.SteelBlue;
            btnAjuste.FlatStyle = FlatStyle.Flat;
            btnAjuste.Image = (Image)resources.GetObject("btnAjuste.Image");
            btnAjuste.Location = new Point(5, 109);
            btnAjuste.Name = "btnAjuste";
            btnAjuste.Size = new Size(20, 20);
            btnAjuste.TabIndex = 3;
            btnAjuste.UseVisualStyleBackColor = false;
            // 
            // btnLinea
            // 
            btnLinea.BackColor = Color.SteelBlue;
            btnLinea.FlatStyle = FlatStyle.Flat;
            btnLinea.Image = (Image)resources.GetObject("btnLinea.Image");
            btnLinea.Location = new Point(5, 7);
            btnLinea.Name = "btnLinea";
            btnLinea.Size = new Size(20, 20);
            btnLinea.TabIndex = 18;
            btnLinea.UseVisualStyleBackColor = false;
            btnLinea.Click += btnLinea_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(27, 110);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 11;
            label2.Text = "Ajustes";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(27, 34);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 17;
            label5.Text = "Unidad Medida";
            // 
            // btnTraspaso
            // 
            btnTraspaso.BackColor = Color.SteelBlue;
            btnTraspaso.FlatStyle = FlatStyle.Flat;
            btnTraspaso.Image = (Image)resources.GetObject("btnTraspaso.Image");
            btnTraspaso.Location = new Point(5, 84);
            btnTraspaso.Name = "btnTraspaso";
            btnTraspaso.Size = new Size(20, 20);
            btnTraspaso.TabIndex = 12;
            btnTraspaso.UseVisualStyleBackColor = false;
            // 
            // btnMedida
            // 
            btnMedida.BackColor = Color.SteelBlue;
            btnMedida.FlatStyle = FlatStyle.Flat;
            btnMedida.Image = (Image)resources.GetObject("btnMedida.Image");
            btnMedida.Location = new Point(5, 33);
            btnMedida.Name = "btnMedida";
            btnMedida.Size = new Size(20, 20);
            btnMedida.TabIndex = 16;
            btnMedida.UseVisualStyleBackColor = false;
            btnMedida.Click += btnMedida_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(27, 85);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 13;
            label3.Text = "Traspaso Almacen";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(27, 59);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 15;
            label4.Text = "Genera Kardex";
            // 
            // btnKardex
            // 
            btnKardex.BackColor = Color.SteelBlue;
            btnKardex.FlatStyle = FlatStyle.Flat;
            btnKardex.Image = (Image)resources.GetObject("btnKardex.Image");
            btnKardex.Location = new Point(5, 58);
            btnKardex.Name = "btnKardex";
            btnKardex.Size = new Size(20, 20);
            btnKardex.TabIndex = 14;
            btnKardex.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(button1);
            panel5.Controls.Add(btnAgregar);
            panel5.Controls.Add(btnInventario);
            panel5.Controls.Add(btnExportar);
            panel5.Controls.Add(btnEstado);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(148, 245);
            panel5.TabIndex = 15;
            // 
            // button1
            // 
            button1.BackColor = Color.LightCoral;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkRed;
            button1.Image = Properties.Resources.close24;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(5, 180);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(138, 27);
            button1.TabIndex = 15;
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.LightGreen;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.DarkGreen;
            btnAgregar.Image = Properties.Resources.nuevo24;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(5, 14);
            btnAgregar.Margin = new Padding(0);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(138, 27);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar Producto";
            btnAgregar.TextAlign = ContentAlignment.MiddleRight;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnInventario
            // 
            btnInventario.BackColor = Color.Gold;
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInventario.ForeColor = Color.Chocolate;
            btnInventario.Image = (Image)resources.GetObject("btnInventario.Image");
            btnInventario.ImageAlign = ContentAlignment.MiddleLeft;
            btnInventario.Location = new Point(5, 130);
            btnInventario.Margin = new Padding(0);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(138, 27);
            btnInventario.TabIndex = 14;
            btnInventario.Text = "Inventario             ";
            btnInventario.TextAlign = ContentAlignment.MiddleRight;
            btnInventario.UseVisualStyleBackColor = false;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.LightGray;
            btnExportar.FlatAppearance.BorderSize = 0;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportar.ForeColor = Color.Black;
            btnExportar.Image = (Image)resources.GetObject("btnExportar.Image");
            btnExportar.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportar.Location = new Point(5, 92);
            btnExportar.Margin = new Padding(0);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(138, 27);
            btnExportar.TabIndex = 13;
            btnExportar.Text = "Exportar Excel      ";
            btnExportar.TextAlign = ContentAlignment.MiddleRight;
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnEstado
            // 
            btnEstado.BackColor = Color.LightCoral;
            btnEstado.FlatAppearance.BorderSize = 0;
            btnEstado.FlatStyle = FlatStyle.Flat;
            btnEstado.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEstado.ForeColor = Color.DarkRed;
            btnEstado.Image = (Image)resources.GetObject("btnEstado.Image");
            btnEstado.ImageAlign = ContentAlignment.MiddleLeft;
            btnEstado.Location = new Point(5, 53);
            btnEstado.Margin = new Padding(0);
            btnEstado.Name = "btnEstado";
            btnEstado.Size = new Size(138, 27);
            btnEstado.TabIndex = 12;
            btnEstado.Text = "Cambiar Estado    ";
            btnEstado.TextAlign = ContentAlignment.MiddleRight;
            btnEstado.UseVisualStyleBackColor = false;
            btnEstado.Click += btnEstado_Click;
            // 
            // frmProductosIndex
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            CaptionBarColor = Color.FromArgb(0, 120, 212);
            CaptionFont = new Font("Century Gothic", 14.25F);
            CaptionForeColor = Color.White;
            ClientSize = new Size(1648, 701);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmProductosIndex";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo de Productos";
            Load += frmMetroProductos_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cbxEstado).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbxExistencia).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbxLinea).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox txtBuscar;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cbxLinea;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cbxExistencia;
        private Button btnActualizar;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cbxEstado;
        private Panel panel3;
        private Button btnEstado;
        private Button btnAgregar;
        private Label lblcodigo;
        private Button btnExportar;
        private Button btnInventario;
        private Label label1;
        private Panel panel4;
        private DataGridView dgvProductos;
        private Panel panel6;
        private Panel panel5;
        private Label label4;
        private Button btnKardex;
        private Label label3;
        private Button btnTraspaso;
        private Label label2;
        private Button btnAjuste;
        private Label label6;
        private Button btnLinea;
        private Label label5;
        private Button btnMedida;
        private Panel panel7;
        private Button button1;
    }
}