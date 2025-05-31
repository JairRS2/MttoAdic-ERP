namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidos));
            groupBox1 = new GroupBox();
            txtEstado = new TextBox();
            dtpPedido = new DateTimePicker();
            label4 = new Label();
            txtNumeroPedido = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnProducto = new MttoAdic_ERP.CustomRenderer.BotonRedondeado();
            txtProducto = new TextBox();
            dgvProductos = new DataGridView();
            btnQuitar = new Button();
            btnAgregar = new Button();
            txtDisponible = new TextBox();
            txtEnVales = new TextBox();
            txtCantidad = new TextBox();
            txtDescripcion = new TextBox();
            txtExistencia = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            btnSalir = new MttoAdic_ERP.CustomRenderer.BotonRedondeado();
            btnDeshacer = new MttoAdic_ERP.CustomRenderer.BotonRedondeado();
            btnGrabar = new MttoAdic_ERP.CustomRenderer.BotonRedondeado();
            btnModificar = new MttoAdic_ERP.CustomRenderer.BotonRedondeado();
            btnNuevo = new MttoAdic_ERP.CustomRenderer.BotonRedondeado();
            groupBox3 = new GroupBox();
            cboSolicita = new ComboBox();
            label16 = new Label();
            groupBox4 = new GroupBox();
            btnImprimir = new MttoAdic_ERP.CustomRenderer.BotonRedondeado();
            btnCancelar = new MttoAdic_ERP.CustomRenderer.BotonRedondeado();
            txtBuscar = new TextBox();
            label19 = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            panel1 = new Panel();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtEstado);
            groupBox1.Controls.Add(dtpPedido);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtNumeroPedido);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(13, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(663, 55);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(274, 18);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(131, 22);
            txtEstado.TabIndex = 25;
            txtEstado.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpPedido
            // 
            dtpPedido.Format = DateTimePickerFormat.Short;
            dtpPedido.Location = new Point(548, 21);
            dtpPedido.Name = "dtpPedido";
            dtpPedido.Size = new Size(109, 22);
            dtpPedido.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(446, 23);
            label4.Name = "label4";
            label4.Size = new Size(96, 17);
            label4.TabIndex = 8;
            label4.Text = "Fecha Pedido :";
            // 
            // txtNumeroPedido
            // 
            txtNumeroPedido.Location = new Point(142, 18);
            txtNumeroPedido.Name = "txtNumeroPedido";
            txtNumeroPedido.ReadOnly = true;
            txtNumeroPedido.Size = new Size(65, 22);
            txtNumeroPedido.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 23);
            label1.Name = "label1";
            label1.Size = new Size(128, 17);
            label1.TabIndex = 2;
            label1.Text = "Número de Pedido  :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnProducto);
            groupBox2.Controls.Add(txtProducto);
            groupBox2.Controls.Add(dgvProductos);
            groupBox2.Controls.Add(btnQuitar);
            groupBox2.Controls.Add(btnAgregar);
            groupBox2.Controls.Add(txtDisponible);
            groupBox2.Controls.Add(txtEnVales);
            groupBox2.Controls.Add(txtCantidad);
            groupBox2.Controls.Add(txtDescripcion);
            groupBox2.Controls.Add(txtExistencia);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(13, 107);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(663, 221);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            // 
            // btnProducto
            // 
            btnProducto.BackColor = Color.DarkMagenta;
            btnProducto.BackgroundColor = Color.DarkMagenta;
            btnProducto.BorderColor = Color.PaleVioletRed;
            btnProducto.BorderRadius = 15;
            btnProducto.BorderSize = 0;
            btnProducto.FlatAppearance.BorderSize = 0;
            btnProducto.FlatStyle = FlatStyle.Flat;
            btnProducto.ForeColor = Color.White;
            btnProducto.Image = (Image)resources.GetObject("btnProducto.Image");
            btnProducto.Location = new Point(121, 40);
            btnProducto.Name = "btnProducto";
            btnProducto.Size = new Size(29, 23);
            btnProducto.TabIndex = 39;
            btnProducto.TextColor = Color.White;
            btnProducto.UseVisualStyleBackColor = false;
            btnProducto.Click += btnProducto_Click;
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(11, 41);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(104, 22);
            txtProducto.TabIndex = 38;
            txtProducto.KeyPress += txtProducto_KeyPress;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToOrderColumns = true;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(87, 82);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(570, 133);
            dgvProductos.TabIndex = 35;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(8, 150);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(73, 26);
            btnQuitar.TabIndex = 34;
            btnQuitar.Text = "<<Quitar";
            btnQuitar.TextAlign = ContentAlignment.MiddleRight;
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(8, 95);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(73, 26);
            btnAgregar.TabIndex = 33;
            btnAgregar.Text = "Agregar>>";
            btnAgregar.TextAlign = ContentAlignment.MiddleLeft;
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtDisponible
            // 
            txtDisponible.Location = new Point(598, 38);
            txtDisponible.Name = "txtDisponible";
            txtDisponible.ReadOnly = true;
            txtDisponible.Size = new Size(49, 22);
            txtDisponible.TabIndex = 30;
            txtDisponible.TextAlign = HorizontalAlignment.Center;
            // 
            // txtEnVales
            // 
            txtEnVales.Location = new Point(525, 39);
            txtEnVales.Name = "txtEnVales";
            txtEnVales.ReadOnly = true;
            txtEnVales.Size = new Size(43, 22);
            txtEnVales.TabIndex = 29;
            txtEnVales.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(173, 39);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(34, 22);
            txtCantidad.TabIndex = 28;
            txtCantidad.KeyPress += txtCantidad_KeyPress;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(221, 39);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(211, 22);
            txtDescripcion.TabIndex = 27;
            txtDescripcion.TextAlign = HorizontalAlignment.Center;
            // 
            // txtExistencia
            // 
            txtExistencia.Location = new Point(451, 39);
            txtExistencia.Name = "txtExistencia";
            txtExistencia.ReadOnly = true;
            txtExistencia.Size = new Size(43, 22);
            txtExistencia.TabIndex = 26;
            txtExistencia.TextAlign = HorizontalAlignment.Center;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(589, 18);
            label13.Name = "label13";
            label13.Size = new Size(70, 17);
            label13.TabIndex = 8;
            label13.Text = "Disponible";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(527, 18);
            label12.Name = "label12";
            label12.Size = new Size(41, 17);
            label12.TabIndex = 7;
            label12.Text = "Vales";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(441, 18);
            label11.Name = "label11";
            label11.Size = new Size(67, 17);
            label11.TabIndex = 6;
            label11.Text = "Existencia";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(285, 20);
            label10.Name = "label10";
            label10.Size = new Size(79, 17);
            label10.TabIndex = 5;
            label10.Text = "Descripción";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(156, 18);
            label9.Name = "label9";
            label9.Size = new Size(64, 17);
            label9.TabIndex = 4;
            label9.Text = "Cantidad";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(11, 21);
            label8.Name = "label8";
            label8.Size = new Size(63, 17);
            label8.TabIndex = 3;
            label8.Text = "Producto";
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
            btnSalir.Image = Properties.Resources.close18;
            btnSalir.ImageAlign = ContentAlignment.MiddleRight;
            btnSalir.Location = new Point(7, 249);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(115, 27);
            btnSalir.TabIndex = 40;
            btnSalir.Text = "Salir        ";
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
            btnDeshacer.Image = Properties.Resources.deshacer18;
            btnDeshacer.ImageAlign = ContentAlignment.MiddleRight;
            btnDeshacer.Location = new Point(7, 115);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(115, 27);
            btnDeshacer.TabIndex = 45;
            btnDeshacer.Text = "Deshacer";
            btnDeshacer.TextColor = Color.Chocolate;
            btnDeshacer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeshacer.UseVisualStyleBackColor = false;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // btnGrabar
            // 
            btnGrabar.BackColor = Color.DeepSkyBlue;
            btnGrabar.BackgroundColor = Color.DeepSkyBlue;
            btnGrabar.BorderColor = Color.PaleVioletRed;
            btnGrabar.BorderRadius = 15;
            btnGrabar.BorderSize = 0;
            btnGrabar.FlatAppearance.BorderSize = 0;
            btnGrabar.FlatStyle = FlatStyle.Flat;
            btnGrabar.ForeColor = Color.Navy;
            btnGrabar.Image = Properties.Resources.grabar18;
            btnGrabar.ImageAlign = ContentAlignment.MiddleRight;
            btnGrabar.Location = new Point(7, 82);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(115, 27);
            btnGrabar.TabIndex = 34;
            btnGrabar.Text = "Grabar     ";
            btnGrabar.TextColor = Color.Navy;
            btnGrabar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGrabar.UseVisualStyleBackColor = false;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.CornflowerBlue;
            btnModificar.BackgroundColor = Color.CornflowerBlue;
            btnModificar.BorderColor = Color.PaleVioletRed;
            btnModificar.BorderRadius = 15;
            btnModificar.BorderSize = 0;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.ForeColor = Color.White;
            btnModificar.Image = Properties.Resources.update18;
            btnModificar.ImageAlign = ContentAlignment.MiddleRight;
            btnModificar.Location = new Point(7, 49);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(115, 27);
            btnModificar.TabIndex = 34;
            btnModificar.Text = "Modificar";
            btnModificar.TextColor = Color.White;
            btnModificar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
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
            btnNuevo.Image = (Image)resources.GetObject("btnNuevo.Image");
            btnNuevo.ImageAlign = ContentAlignment.MiddleRight;
            btnNuevo.Location = new Point(7, 16);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(115, 27);
            btnNuevo.TabIndex = 40;
            btnNuevo.Text = "Nuevo     ";
            btnNuevo.TextColor = Color.DarkGreen;
            btnNuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cboSolicita);
            groupBox3.Controls.Add(label16);
            groupBox3.Location = new Point(12, 336);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(664, 58);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            // 
            // cboSolicita
            // 
            cboSolicita.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSolicita.FormattingEnabled = true;
            cboSolicita.Location = new Point(108, 19);
            cboSolicita.Name = "cboSolicita";
            cboSolicita.Size = new Size(550, 25);
            cboSolicita.TabIndex = 33;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(9, 22);
            label16.Name = "label16";
            label16.Size = new Size(98, 17);
            label16.TabIndex = 5;
            label16.Text = "Solicitado por :";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnSalir);
            groupBox4.Controls.Add(btnImprimir);
            groupBox4.Controls.Add(btnCancelar);
            groupBox4.Controls.Add(btnDeshacer);
            groupBox4.Controls.Add(btnGrabar);
            groupBox4.Controls.Add(btnModificar);
            groupBox4.Controls.Add(btnNuevo);
            groupBox4.Location = new Point(682, 46);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(128, 282);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.CornflowerBlue;
            btnImprimir.BackgroundColor = Color.CornflowerBlue;
            btnImprimir.BorderColor = Color.PaleVioletRed;
            btnImprimir.BorderRadius = 15;
            btnImprimir.BorderSize = 0;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Image = Properties.Resources.imprimir18;
            btnImprimir.ImageAlign = ContentAlignment.MiddleRight;
            btnImprimir.Location = new Point(7, 181);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(115, 27);
            btnImprimir.TabIndex = 46;
            btnImprimir.Text = "Imprimir  ";
            btnImprimir.TextColor = Color.White;
            btnImprimir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightCoral;
            btnCancelar.BackgroundColor = Color.LightCoral;
            btnCancelar.BorderColor = Color.PaleVioletRed;
            btnCancelar.BorderRadius = 15;
            btnCancelar.BorderSize = 0;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.DarkRed;
            btnCancelar.Image = Properties.Resources.cancel18;
            btnCancelar.ImageAlign = ContentAlignment.MiddleRight;
            btnCancelar.Location = new Point(7, 148);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(115, 27);
            btnCancelar.TabIndex = 40;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextColor = Color.DarkRed;
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(682, 365);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(128, 29);
            txtBuscar.TabIndex = 32;
            txtBuscar.TextAlign = HorizontalAlignment.Center;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(691, 344);
            label19.Name = "label19";
            label19.Size = new Size(113, 18);
            label19.TabIndex = 31;
            label19.Text = "Buscar Pedido";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 120, 212);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(822, 44);
            panel1.TabIndex = 33;
            panel1.Paint += panel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(13, 10);
            label2.Name = "label2";
            label2.Size = new Size(194, 21);
            label2.TabIndex = 0;
            label2.Text = "Pedidos de Refacciones";
            // 
            // frmPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(822, 408);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(txtBuscar);
            Controls.Add(label19);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmPedidos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedidos de Refacciones";
            Load += frmPedidos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtEstado;
        private DateTimePicker dtpPedido;
        private Label label4;
        private TextBox txtNumeroPedido;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox txtProducto;
        private DataGridView dgvProductos;
        private Button btnQuitar;
        private Button btnAgregar;
        private TextBox txtDisponible;
        private TextBox txtEnVales;
        private TextBox txtCantidad;
        private TextBox txtDescripcion;
        private TextBox txtExistencia;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private GroupBox groupBox3;
        private ComboBox cboSolicita;
        private Label label16;
        private GroupBox groupBox4;
        private TextBox txtBuscar;
        private Label label19;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Panel panel1;
        private Label label2;
        private CustomRenderer.BotonRedondeado btnProducto;
        private CustomRenderer.BotonRedondeado btnNuevo;
        private CustomRenderer.BotonRedondeado btnModificar;
        private CustomRenderer.BotonRedondeado btnGrabar;
        private CustomRenderer.BotonRedondeado btnDeshacer;
        private CustomRenderer.BotonRedondeado btnCancelar;
        private CustomRenderer.BotonRedondeado btnImprimir;
        private CustomRenderer.BotonRedondeado btnSalir;
    }
}