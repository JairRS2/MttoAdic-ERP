namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmVales
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
            dtpEntrega = new DateTimePicker();
            label21 = new Label();
            txtIdUnidad = new TextBox();
            txtCveEmpresa = new TextBox();
            txtBitacora = new TextBox();
            txtUnidad = new TextBox();
            txtEmpresa = new TextBox();
            txtEstado = new TextBox();
            label3 = new Label();
            txtObservaciones = new TextBox();
            chkContingencia = new CheckBox();
            dtpVale = new DateTimePicker();
            dtpSolicitud = new DateTimePicker();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            txtNumeroVale = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtPrecio = new TextBox();
            txtProducto = new TextBox();
            txtTotal = new TextBox();
            label14 = new Label();
            dgvProductos = new DataGridView();
            btnQuitar = new Button();
            btnAgregar = new Button();
            btnProducto = new Button();
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
            groupBox3 = new GroupBox();
            cboEntrega = new ComboBox();
            label20 = new Label();
            cboAutoriza = new ComboBox();
            cboSolicita = new ComboBox();
            label16 = new Label();
            label15 = new Label();
            groupBox4 = new GroupBox();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnGrabar = new Button();
            btnImprimir = new Button();
            btnSalir = new Button();
            btnCancelar = new Button();
            btnDeshacer = new Button();
            btnTerminar = new Button();
            txtBuscar = new TextBox();
            label19 = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpEntrega);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(txtIdUnidad);
            groupBox1.Controls.Add(txtCveEmpresa);
            groupBox1.Controls.Add(txtBitacora);
            groupBox1.Controls.Add(txtUnidad);
            groupBox1.Controls.Add(txtEmpresa);
            groupBox1.Controls.Add(txtEstado);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtObservaciones);
            groupBox1.Controls.Add(chkContingencia);
            groupBox1.Controls.Add(dtpVale);
            groupBox1.Controls.Add(dtpSolicitud);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtNumeroVale);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(555, 201);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // dtpEntrega
            // 
            dtpEntrega.Format = DateTimePickerFormat.Short;
            dtpEntrega.Location = new Point(467, 54);
            dtpEntrega.Name = "dtpEntrega";
            dtpEntrega.Size = new Size(77, 23);
            dtpEntrega.TabIndex = 32;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(379, 62);
            label21.Name = "label21";
            label21.Size = new Size(87, 15);
            label21.TabIndex = 31;
            label21.Text = "Fecha Entrega :";
            // 
            // txtIdUnidad
            // 
            txtIdUnidad.Location = new Point(364, 61);
            txtIdUnidad.Name = "txtIdUnidad";
            txtIdUnidad.ReadOnly = true;
            txtIdUnidad.Size = new Size(20, 23);
            txtIdUnidad.TabIndex = 30;
            txtIdUnidad.Visible = false;
            // 
            // txtCveEmpresa
            // 
            txtCveEmpresa.Location = new Point(525, 29);
            txtCveEmpresa.Name = "txtCveEmpresa";
            txtCveEmpresa.ReadOnly = true;
            txtCveEmpresa.Size = new Size(20, 23);
            txtCveEmpresa.TabIndex = 29;
            txtCveEmpresa.Visible = false;
            // 
            // txtBitacora
            // 
            txtBitacora.Location = new Point(105, 86);
            txtBitacora.Name = "txtBitacora";
            txtBitacora.Size = new Size(82, 23);
            txtBitacora.TabIndex = 28;
            txtBitacora.KeyPress += txtBitacora_KeyPress;
            // 
            // txtUnidad
            // 
            txtUnidad.Location = new Point(246, 84);
            txtUnidad.Name = "txtUnidad";
            txtUnidad.ReadOnly = true;
            txtUnidad.Size = new Size(37, 23);
            txtUnidad.TabIndex = 27;
            txtUnidad.TextAlign = HorizontalAlignment.Center;
            // 
            // txtEmpresa
            // 
            txtEmpresa.Location = new Point(346, 86);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.ReadOnly = true;
            txtEmpresa.Size = new Size(199, 23);
            txtEmpresa.TabIndex = 26;
            txtEmpresa.TextAlign = HorizontalAlignment.Center;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(414, 21);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(131, 23);
            txtEstado.TabIndex = 25;
            txtEstado.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 128);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 24;
            label3.Text = "Observaciones :";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(102, 120);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(443, 70);
            txtObservaciones.TabIndex = 23;
            txtObservaciones.KeyPress += txtObservaciones_KeyPress;
            // 
            // chkContingencia
            // 
            chkContingencia.AutoSize = true;
            chkContingencia.Location = new Point(206, 25);
            chkContingencia.Name = "chkContingencia";
            chkContingencia.Size = new Size(142, 19);
            chkContingencia.TabIndex = 21;
            chkContingencia.Text = "Vale por Contingencia";
            chkContingencia.UseVisualStyleBackColor = true;
            // 
            // dtpVale
            // 
            dtpVale.Format = DateTimePickerFormat.Short;
            dtpVale.Location = new Point(280, 54);
            dtpVale.Name = "dtpVale";
            dtpVale.Size = new Size(77, 23);
            dtpVale.TabIndex = 20;
            dtpVale.KeyPress += dtpVale_KeyPress;
            // 
            // dtpSolicitud
            // 
            dtpSolicitud.Format = DateTimePickerFormat.Short;
            dtpSolicitud.Location = new Point(105, 56);
            dtpSolicitud.Name = "dtpSolicitud";
            dtpSolicitud.Size = new Size(82, 23);
            dtpSolicitud.TabIndex = 18;
            dtpSolicitud.KeyPress += dtpSolicitud_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(282, 94);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 14;
            label7.Text = "Empresa :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(195, 94);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 12;
            label6.Text = "Unidad :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 94);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 10;
            label5.Text = "Bitácora :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(206, 62);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 8;
            label4.Text = "Fecha Vale :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 62);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 4;
            label2.Text = "Fecha Solicitud :";
            // 
            // txtNumeroVale
            // 
            txtNumeroVale.Location = new Point(106, 25);
            txtNumeroVale.Name = "txtNumeroVale";
            txtNumeroVale.Size = new Size(81, 23);
            txtNumeroVale.TabIndex = 3;
            txtNumeroVale.KeyPress += txtNumeroVale_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 33);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 2;
            label1.Text = "Número de Vale :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPrecio);
            groupBox2.Controls.Add(txtProducto);
            groupBox2.Controls.Add(txtTotal);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(dgvProductos);
            groupBox2.Controls.Add(btnQuitar);
            groupBox2.Controls.Add(btnAgregar);
            groupBox2.Controls.Add(btnProducto);
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
            groupBox2.Location = new Point(12, 202);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(555, 220);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(540, 36);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(12, 23);
            txtPrecio.TabIndex = 39;
            txtPrecio.TextAlign = HorizontalAlignment.Center;
            txtPrecio.Visible = false;
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(11, 36);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(104, 23);
            txtProducto.TabIndex = 38;
            txtProducto.KeyPress += txtProducto_KeyPress;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(466, 188);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(79, 23);
            txtTotal.TabIndex = 37;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(378, 191);
            label14.Name = "label14";
            label14.Size = new Size(79, 15);
            label14.TabIndex = 36;
            label14.Text = "Total Vale ($) :";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToOrderColumns = true;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(87, 65);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(457, 117);
            dgvProductos.TabIndex = 35;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(8, 132);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(73, 23);
            btnQuitar.TabIndex = 34;
            btnQuitar.Text = "<<Quitar";
            btnQuitar.TextAlign = ContentAlignment.MiddleRight;
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(8, 84);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(73, 23);
            btnAgregar.TabIndex = 33;
            btnAgregar.Text = "Agregar>>";
            btnAgregar.TextAlign = ContentAlignment.MiddleLeft;
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnProducto
            // 
            btnProducto.Location = new Point(120, 35);
            btnProducto.Name = "btnProducto";
            btnProducto.Size = new Size(21, 25);
            btnProducto.TabIndex = 31;
            btnProducto.Text = "?";
            btnProducto.UseVisualStyleBackColor = true;
            btnProducto.Click += btnProducto_Click;
            // 
            // txtDisponible
            // 
            txtDisponible.Location = new Point(496, 36);
            txtDisponible.Name = "txtDisponible";
            txtDisponible.ReadOnly = true;
            txtDisponible.Size = new Size(42, 23);
            txtDisponible.TabIndex = 30;
            txtDisponible.TextAlign = HorizontalAlignment.Center;
            // 
            // txtEnVales
            // 
            txtEnVales.Location = new Point(448, 36);
            txtEnVales.Name = "txtEnVales";
            txtEnVales.ReadOnly = true;
            txtEnVales.Size = new Size(43, 23);
            txtEnVales.TabIndex = 29;
            txtEnVales.TextAlign = HorizontalAlignment.Center;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(142, 36);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(34, 23);
            txtCantidad.TabIndex = 28;
            txtCantidad.KeyPress += txtCantidad_KeyPress;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(178, 36);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(211, 23);
            txtDescripcion.TabIndex = 27;
            txtDescripcion.TextAlign = HorizontalAlignment.Center;
            // 
            // txtExistencia
            // 
            txtExistencia.Location = new Point(397, 36);
            txtExistencia.Name = "txtExistencia";
            txtExistencia.ReadOnly = true;
            txtExistencia.Size = new Size(43, 23);
            txtExistencia.TabIndex = 26;
            txtExistencia.TextAlign = HorizontalAlignment.Center;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(482, 18);
            label13.Name = "label13";
            label13.Size = new Size(63, 15);
            label13.TabIndex = 8;
            label13.Text = "Disponible";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(448, 18);
            label12.Name = "label12";
            label12.Size = new Size(33, 15);
            label12.TabIndex = 7;
            label12.Text = "Vales";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(385, 18);
            label11.Name = "label11";
            label11.Size = new Size(59, 15);
            label11.TabIndex = 6;
            label11.Text = "Existencia";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(202, 18);
            label10.Name = "label10";
            label10.Size = new Size(69, 15);
            label10.TabIndex = 5;
            label10.Text = "Descripción";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(128, 18);
            label9.Name = "label9";
            label9.Size = new Size(55, 15);
            label9.TabIndex = 4;
            label9.Text = "Cantidad";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 18);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 3;
            label8.Text = "Producto";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cboEntrega);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(cboAutoriza);
            groupBox3.Controls.Add(cboSolicita);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(label15);
            groupBox3.Location = new Point(11, 423);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(555, 112);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            // 
            // cboEntrega
            // 
            cboEntrega.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEntrega.FormattingEnabled = true;
            cboEntrega.Location = new Point(108, 73);
            cboEntrega.Name = "cboEntrega";
            cboEntrega.Size = new Size(439, 23);
            cboEntrega.TabIndex = 36;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(5, 80);
            label20.Name = "label20";
            label20.Size = new Size(88, 15);
            label20.TabIndex = 35;
            label20.Text = "Entregado por :";
            // 
            // cboAutoriza
            // 
            cboAutoriza.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAutoriza.FormattingEnabled = true;
            cboAutoriza.Location = new Point(108, 45);
            cboAutoriza.Name = "cboAutoriza";
            cboAutoriza.Size = new Size(439, 23);
            cboAutoriza.TabIndex = 34;
            cboAutoriza.SelectedIndexChanged += cboAutoriza_SelectedIndexChanged;
            // 
            // cboSolicita
            // 
            cboSolicita.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSolicita.FormattingEnabled = true;
            cboSolicita.Location = new Point(108, 17);
            cboSolicita.Name = "cboSolicita";
            cboSolicita.Size = new Size(439, 23);
            cboSolicita.TabIndex = 33;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(5, 26);
            label16.Name = "label16";
            label16.Size = new Size(86, 15);
            label16.TabIndex = 5;
            label16.Text = "Solicitado por :";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 54);
            label15.Name = "label15";
            label15.Size = new Size(92, 15);
            label15.TabIndex = 4;
            label15.Text = "Autorizado por :";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnNuevo);
            groupBox4.Controls.Add(btnModificar);
            groupBox4.Controls.Add(btnGrabar);
            groupBox4.Controls.Add(btnImprimir);
            groupBox4.Controls.Add(btnSalir);
            groupBox4.Controls.Add(btnCancelar);
            groupBox4.Controls.Add(btnDeshacer);
            groupBox4.Controls.Add(btnTerminar);
            groupBox4.Location = new Point(574, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(112, 244);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LightGreen;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.ForeColor = Color.DarkGreen;
            btnNuevo.Image = Properties.Resources.nuevo24;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(6, 16);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(99, 23);
            btnNuevo.TabIndex = 47;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.CornflowerBlue;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.ForeColor = Color.White;
            btnModificar.Image = Properties.Resources.update24;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(6, 44);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(99, 23);
            btnModificar.TabIndex = 46;
            btnModificar.Text = "     Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGrabar
            // 
            btnGrabar.BackColor = Color.DeepSkyBlue;
            btnGrabar.FlatStyle = FlatStyle.Flat;
            btnGrabar.ForeColor = Color.Navy;
            btnGrabar.Image = Properties.Resources.grabar24;
            btnGrabar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGrabar.Location = new Point(5, 98);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(99, 23);
            btnGrabar.TabIndex = 45;
            btnGrabar.Text = "Grabar";
            btnGrabar.UseVisualStyleBackColor = false;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.CornflowerBlue;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Image = Properties.Resources.imprimir18;
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(6, 177);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(99, 23);
            btnImprimir.TabIndex = 44;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.LightCoral;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.DarkRed;
            btnSalir.Image = Properties.Resources.close24;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(6, 214);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(99, 23);
            btnSalir.TabIndex = 43;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(5, 151);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(99, 23);
            btnCancelar.TabIndex = 42;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnDeshacer
            // 
            btnDeshacer.BackColor = Color.Gold;
            btnDeshacer.FlatStyle = FlatStyle.Flat;
            btnDeshacer.ForeColor = Color.Chocolate;
            btnDeshacer.Image = Properties.Resources.deshacer24;
            btnDeshacer.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeshacer.Location = new Point(5, 125);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(99, 23);
            btnDeshacer.TabIndex = 41;
            btnDeshacer.Text = "   Deshacer";
            btnDeshacer.UseVisualStyleBackColor = false;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // btnTerminar
            // 
            btnTerminar.Location = new Point(5, 71);
            btnTerminar.Name = "btnTerminar";
            btnTerminar.Size = new Size(99, 23);
            btnTerminar.TabIndex = 40;
            btnTerminar.Text = "Terminar";
            btnTerminar.UseVisualStyleBackColor = true;
            btnTerminar.Click += btnTerminar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(575, 296);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(112, 29);
            txtBuscar.TabIndex = 30;
            txtBuscar.TextAlign = HorizontalAlignment.Center;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(578, 272);
            label19.Name = "label19";
            label19.Size = new Size(105, 21);
            label19.TabIndex = 29;
            label19.Text = "Buscar Vale :";
            // 
            // frmVales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CaptionBarColor = Color.FromArgb(33, 150, 243);
            CaptionFont = new Font("Century Gothic", 14.25F);
            CaptionForeColor = Color.White;
            ClientSize = new Size(694, 540);
            ControlBox = false;
            Controls.Add(txtBuscar);
            Controls.Add(label19);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmVales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vales de Refacciones (Elaboración)";
            Load += frmElaboracionVales_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private TextBox txtNumeroVale;
        private Label label1;
        private Label label7;
        private DateTimePicker dtpSolicitud;
        private DateTimePicker dtpVale;
        private Label label3;
        private TextBox txtObservaciones;
        private CheckBox chkContingencia;
        private TextBox txtEmpresa;
        private TextBox txtEstado;
        private GroupBox groupBox2;
        private TextBox txtExistencia;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox txtDescripcion;
        private Button btnQuitar;
        private Button btnAgregar;
        private Button btnProducto;
        private TextBox txtDisponible;
        private TextBox txtEnVales;
        private TextBox txtCantidad;
        private DataGridView dgvProductos;
        private TextBox txtTotal;
        private Label label14;
        private GroupBox groupBox3;
        private ComboBox cboAutoriza;
        private ComboBox cboSolicita;
        private Label label16;
        private Label label15;
        private GroupBox groupBox4;
        private Button btnTerminar;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnGrabar;
        private Button btnImprimir;
        private Button btnSalir;
        private Button btnCancelar;
        private Button btnDeshacer;
        private TextBox txtUnidad;
        private TextBox txtBitacora;
        private TextBox txtBuscar;
        private Label label19;
        private TextBox txtProducto;
        private TextBox txtPrecio;
        private TextBox txtCveEmpresa;
        private TextBox txtIdUnidad;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private ComboBox cboEntrega;
        private Label label20;
        private DateTimePicker dtpEntrega;
        private Label label21;
    }
}