namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmAgrValeUrea
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
            pnlEncabezado = new Panel();
            btnMinimizar = new CustomRenderer.BotonRedondeado();
            btnSalir = new CustomRenderer.BotonRedondeado();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtKilometraje = new TextBox();
            label5 = new Label();
            txtLitDesp = new TextBox();
            label6 = new Label();
            txtNumPas = new TextBox();
            label7 = new Label();
            rtxObservaciones = new RichTextBox();
            label8 = new Label();
            groupBox1 = new GroupBox();
            pbFotoUnidad = new PictureBox();
            groupBox2 = new GroupBox();
            pbFotoKilometraje = new PictureBox();
            groupBox3 = new GroupBox();
            pbFotoTAC = new PictureBox();
            groupBox4 = new GroupBox();
            pbFotoCL = new PictureBox();
            groupBox5 = new GroupBox();
            pbFotoTDC = new PictureBox();
            cboDespachador = new ComboBox();
            cboOperador = new ComboBox();
            cboUnidad = new ComboBox();
            btnGrabar = new CustomRenderer.BotonRedondeado();
            pnlEncabezado.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFotoUnidad).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFotoKilometraje).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFotoTAC).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFotoCL).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFotoTDC).BeginInit();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(33, 150, 243);
            pnlEncabezado.Controls.Add(btnMinimizar);
            pnlEncabezado.Controls.Add(btnSalir);
            pnlEncabezado.Controls.Add(label1);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(637, 39);
            pnlEncabezado.TabIndex = 0;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Right;
            btnMinimizar.BackColor = Color.FromArgb(33, 150, 243);
            btnMinimizar.BackgroundColor = Color.FromArgb(33, 150, 243);
            btnMinimizar.BorderColor = Color.PaleVioletRed;
            btnMinimizar.BorderRadius = 0;
            btnMinimizar.BorderSize = 0;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.ForeColor = Color.White;
            btnMinimizar.Image = Properties.Resources.minimizar2;
            btnMinimizar.Location = new Point(548, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(43, 39);
            btnMinimizar.TabIndex = 1;
            btnMinimizar.TextColor = Color.White;
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Right;
            btnSalir.BackColor = Color.FromArgb(33, 150, 243);
            btnSalir.BackgroundColor = Color.FromArgb(33, 150, 243);
            btnSalir.BorderColor = Color.PaleVioletRed;
            btnSalir.BorderRadius = 0;
            btnSalir.BorderSize = 0;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Image = Properties.Resources.close25;
            btnSalir.Location = new Point(592, 0);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(43, 39);
            btnSalir.TabIndex = 2;
            btnSalir.TextColor = Color.White;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(304, 9);
            label1.Name = "label1";
            label1.Size = new Size(43, 21);
            label1.TabIndex = 0;
            label1.Text = "Vale";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 126);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 1;
            label2.Text = "Unidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(331, 53);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 3;
            label3.Text = "Operador";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(177, 126);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 5;
            label4.Text = "Kilometraje";
            // 
            // txtKilometraje
            // 
            txtKilometraje.Location = new Point(177, 144);
            txtKilometraje.Name = "txtKilometraje";
            txtKilometraje.Size = new Size(129, 23);
            txtKilometraje.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(337, 126);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 7;
            label5.Text = "Litros despachados";
            // 
            // txtLitDesp
            // 
            txtLitDesp.Location = new Point(337, 144);
            txtLitDesp.Name = "txtLitDesp";
            txtLitDesp.Size = new Size(129, 23);
            txtLitDesp.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(496, 126);
            label6.Name = "label6";
            label6.Size = new Size(94, 15);
            label6.TabIndex = 9;
            label6.Text = "Numero de Pase";
            // 
            // txtNumPas
            // 
            txtNumPas.Location = new Point(496, 144);
            txtNumPas.Name = "txtNumPas";
            txtNumPas.Size = new Size(129, 23);
            txtNumPas.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 186);
            label7.Name = "label7";
            label7.Size = new Size(84, 15);
            label7.TabIndex = 11;
            label7.Text = "Observaciones";
            // 
            // rtxObservaciones
            // 
            rtxObservaciones.Location = new Point(16, 204);
            rtxObservaciones.Name = "rtxObservaciones";
            rtxObservaciones.Size = new Size(609, 49);
            rtxObservaciones.TabIndex = 12;
            rtxObservaciones.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 53);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 13;
            label8.Text = "Despachador";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pbFotoUnidad);
            groupBox1.Location = new Point(16, 275);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(116, 176);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Unidad";
            // 
            // pbFotoUnidad
            // 
            pbFotoUnidad.BackColor = Color.Gainsboro;
            pbFotoUnidad.Location = new Point(6, 34);
            pbFotoUnidad.Name = "pbFotoUnidad";
            pbFotoUnidad.Size = new Size(104, 136);
            pbFotoUnidad.TabIndex = 0;
            pbFotoUnidad.TabStop = false;
            pbFotoUnidad.Click += pbFotoUnidad_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pbFotoKilometraje);
            groupBox2.Location = new Point(138, 275);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(116, 176);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kilometraje";
            // 
            // pbFotoKilometraje
            // 
            pbFotoKilometraje.BackColor = Color.Gainsboro;
            pbFotoKilometraje.Location = new Point(6, 34);
            pbFotoKilometraje.Name = "pbFotoKilometraje";
            pbFotoKilometraje.Size = new Size(104, 136);
            pbFotoKilometraje.TabIndex = 0;
            pbFotoKilometraje.TabStop = false;
            pbFotoKilometraje.Click += pbFotoKilometraje_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(pbFotoTAC);
            groupBox3.Location = new Point(260, 275);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(116, 176);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tablero Antes de Carga";
            // 
            // pbFotoTAC
            // 
            pbFotoTAC.BackColor = Color.Gainsboro;
            pbFotoTAC.Location = new Point(6, 34);
            pbFotoTAC.Name = "pbFotoTAC";
            pbFotoTAC.Size = new Size(104, 136);
            pbFotoTAC.TabIndex = 1;
            pbFotoTAC.TabStop = false;
            pbFotoTAC.Click += pbFotoTAC_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(pbFotoCL);
            groupBox4.Location = new Point(382, 275);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(116, 176);
            groupBox4.TabIndex = 16;
            groupBox4.TabStop = false;
            groupBox4.Text = "Cuenta Litros";
            // 
            // pbFotoCL
            // 
            pbFotoCL.BackColor = Color.Gainsboro;
            pbFotoCL.Location = new Point(6, 34);
            pbFotoCL.Name = "pbFotoCL";
            pbFotoCL.Size = new Size(104, 136);
            pbFotoCL.TabIndex = 18;
            pbFotoCL.TabStop = false;
            pbFotoCL.Click += pbFotoCL_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(pbFotoTDC);
            groupBox5.Location = new Point(504, 275);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(116, 176);
            groupBox5.TabIndex = 17;
            groupBox5.TabStop = false;
            groupBox5.Text = "Tablero Despues de Carga";
            // 
            // pbFotoTDC
            // 
            pbFotoTDC.BackColor = Color.Gainsboro;
            pbFotoTDC.Location = new Point(6, 34);
            pbFotoTDC.Name = "pbFotoTDC";
            pbFotoTDC.Size = new Size(104, 136);
            pbFotoTDC.TabIndex = 18;
            pbFotoTDC.TabStop = false;
            pbFotoTDC.Click += pbFotoTDC_Click;
            // 
            // cboDespachador
            // 
            cboDespachador.FormattingEnabled = true;
            cboDespachador.Location = new Point(12, 71);
            cboDespachador.Name = "cboDespachador";
            cboDespachador.Size = new Size(294, 23);
            cboDespachador.TabIndex = 18;
            cboDespachador.TextUpdate += cboDespachador_TextUpdate;
            cboDespachador.Leave += cboDespachador_Leave;
            // 
            // cboOperador
            // 
            cboOperador.FormattingEnabled = true;
            cboOperador.Location = new Point(331, 71);
            cboOperador.Name = "cboOperador";
            cboOperador.Size = new Size(294, 23);
            cboOperador.TabIndex = 19;
            cboOperador.TextUpdate += cboOperador_TextUpdate;
            cboOperador.Leave += cboOperador_Leave;
            // 
            // cboUnidad
            // 
            cboUnidad.FormattingEnabled = true;
            cboUnidad.Location = new Point(16, 144);
            cboUnidad.Name = "cboUnidad";
            cboUnidad.Size = new Size(129, 23);
            cboUnidad.TabIndex = 20;
            cboUnidad.TextUpdate += cboUnidad_TextUpdate;
            cboUnidad.Leave += cboUnidad_Leave;
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
            btnGrabar.Image = Properties.Resources.grabar24;
            btnGrabar.Location = new Point(260, 476);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(116, 40);
            btnGrabar.TabIndex = 21;
            btnGrabar.Text = "   Grabar";
            btnGrabar.TextColor = Color.Navy;
            btnGrabar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGrabar.UseVisualStyleBackColor = false;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // frmAgrValeUrea
            // 
            AllowRoundedCorners = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderColor = Color.FromArgb(128, 255, 255);
            ClientSize = new Size(637, 548);
            Controls.Add(btnGrabar);
            Controls.Add(cboUnidad);
            Controls.Add(cboOperador);
            Controls.Add(cboDespachador);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label8);
            Controls.Add(rtxObservaciones);
            Controls.Add(label7);
            Controls.Add(txtNumPas);
            Controls.Add(label6);
            Controls.Add(txtLitDesp);
            Controls.Add(label5);
            Controls.Add(txtKilometraje);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pnlEncabezado);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmAgrValeUrea";
            Text = "frmAgregarValeUrea";
            Load += frmAgrValeUrea_Load;
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbFotoUnidad).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbFotoKilometraje).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbFotoTAC).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbFotoCL).EndInit();
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbFotoTDC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEncabezado;
        private Label label1;
        private CustomRenderer.BotonRedondeado btnMinimizar;
        private CustomRenderer.BotonRedondeado btnSalir;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtKilometraje;
        private Label label5;
        private TextBox txtLitDesp;
        private Label label6;
        private TextBox txtNumPas;
        private Label label7;
        private RichTextBox rtxObservaciones;
        private Label label8;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private PictureBox pbFotoUnidad;
        private PictureBox pbFotoKilometraje;
        private PictureBox pbFotoTAC;
        private PictureBox pbFotoCL;
        private PictureBox pbFotoTDC;
        private ComboBox cboDespachador;
        private ComboBox cboOperador;
        private ComboBox cboUnidad;
        private CustomRenderer.BotonRedondeado btnGrabar;
    }
}