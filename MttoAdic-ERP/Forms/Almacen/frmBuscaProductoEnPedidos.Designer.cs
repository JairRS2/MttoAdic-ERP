namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmBuscaProductoEnPedidos
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
            groupBox5 = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtPedido = new TextBox();
            txtCodigo = new TextBox();
            txtCosto = new TextBox();
            label2 = new Label();
            txtCantidad = new TextBox();
            label1 = new Label();
            txtDescripcion = new TextBox();
            label3 = new Label();
            btnSalir = new Button();
            btnAgregar = new Button();
            dgvProductos = new DataGridView();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label6);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(label4);
            groupBox5.Controls.Add(txtPedido);
            groupBox5.Controls.Add(txtCodigo);
            groupBox5.Controls.Add(txtCosto);
            groupBox5.Controls.Add(label2);
            groupBox5.Controls.Add(txtCantidad);
            groupBox5.Controls.Add(label1);
            groupBox5.Controls.Add(txtDescripcion);
            groupBox5.Controls.Add(label3);
            groupBox5.Controls.Add(btnSalir);
            groupBox5.Controls.Add(btnAgregar);
            groupBox5.Controls.Add(dgvProductos);
            groupBox5.Location = new Point(8, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(695, 236);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(361, 17);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 63;
            label6.Text = "Producto";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(178, 16);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 62;
            label5.Text = "Codigo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(118, 16);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 61;
            label4.Text = "Pedido";
            // 
            // txtPedido
            // 
            txtPedido.Location = new Point(109, 34);
            txtPedido.Name = "txtPedido";
            txtPedido.ReadOnly = true;
            txtPedido.Size = new Size(60, 23);
            txtPedido.TabIndex = 60;
            txtPedido.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(174, 34);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(60, 23);
            txtCodigo.TabIndex = 59;
            txtCodigo.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(627, 34);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(53, 23);
            txtCosto.TabIndex = 58;
            txtCosto.TextAlign = HorizontalAlignment.Center;
            txtCosto.KeyPress += txtCosto_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(631, 18);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 57;
            label2.Text = "Costo";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(569, 34);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.ReadOnly = true;
            txtCantidad.Size = new Size(53, 23);
            txtCantidad.TabIndex = 56;
            txtCantidad.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(568, 17);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 55;
            label1.Text = "Cantidad";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(239, 34);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(325, 23);
            txtDescripcion.TabIndex = 54;
            txtDescripcion.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 36);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 53;
            label3.Text = "Seleccionado :";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(14, 201);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(81, 23);
            btnSalir.TabIndex = 52;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(13, 119);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(81, 41);
            btnAgregar.TabIndex = 51;
            btnAgregar.Text = "Agregar a Orden";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(109, 66);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(573, 157);
            dgvProductos.TabIndex = 36;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // frmModalProductosEnPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 246);
            ControlBox = false;
            Controls.Add(groupBox5);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmModalProductosEnPedidos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos en Pedidos";
            Load += frmProductosEnPedidos_Load;
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox5;
        private Button btnAgregar;
        private DataGridView dgvProductos;
        private Button btnSalir;
        private Label label3;
        private TextBox txtCantidad;
        private Label label1;
        private TextBox txtDescripcion;
        private TextBox txtCosto;
        private Label label2;
        private TextBox txtCodigo;
        private TextBox txtPedido;
        private Label label5;
        private Label label4;
        private Label label6;
    }
}