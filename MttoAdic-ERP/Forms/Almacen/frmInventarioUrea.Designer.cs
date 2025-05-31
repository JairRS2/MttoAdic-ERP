namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmInventarioUrea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioUrea));
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtExiMir = new TextBox();
            txtUltCos = new TextBox();
            label5 = new Label();
            txtPreProm = new TextBox();
            lblCapTan = new Label();
            groupBox1 = new GroupBox();
            pbxAlerta = new PictureBox();
            lblExiSis = new Label();
            pbxTanque = new PictureBox();
            pnlEncabezado = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            btnMinimizar = new Button();
            btnCerrar = new Button();
            lblTitulo = new Label();
            lbl = new Label();
            btnActualizar = new CustomRenderer.BotonRedondeado();
            txtUltFac = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxAlerta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxTanque).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEncabezado).BeginInit();
            pnlEncabezado.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 11.25F);
            label1.Location = new Point(12, 97);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 0;
            label1.Text = "Existencia Mirilla :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 11.25F);
            label3.Location = new Point(14, 159);
            label3.Name = "label3";
            label3.Size = new Size(172, 20);
            label3.TabIndex = 2;
            label3.Text = "Fecha Ultima Factura :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 11.25F);
            label4.Location = new Point(13, 210);
            label4.Name = "label4";
            label4.Size = new Size(109, 20);
            label4.TabIndex = 3;
            label4.Text = "Ultimo Costo :";
            // 
            // txtExiMir
            // 
            txtExiMir.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtExiMir.Location = new Point(14, 120);
            txtExiMir.Name = "txtExiMir";
            txtExiMir.Size = new Size(172, 26);
            txtExiMir.TabIndex = 5;
            // 
            // txtUltCos
            // 
            txtUltCos.Font = new Font("Courier New", 12F);
            txtUltCos.Location = new Point(14, 233);
            txtUltCos.Name = "txtUltCos";
            txtUltCos.Size = new Size(172, 26);
            txtUltCos.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 11.25F);
            label5.Location = new Point(13, 273);
            label5.Name = "label5";
            label5.Size = new Size(138, 20);
            label5.TabIndex = 9;
            label5.Text = "Precio Promedio :";
            // 
            // txtPreProm
            // 
            txtPreProm.Font = new Font("Courier New", 12F);
            txtPreProm.Location = new Point(14, 296);
            txtPreProm.Name = "txtPreProm";
            txtPreProm.Size = new Size(172, 26);
            txtPreProm.TabIndex = 10;
            // 
            // lblCapTan
            // 
            lblCapTan.BackColor = Color.MediumTurquoise;
            lblCapTan.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCapTan.ForeColor = Color.White;
            lblCapTan.Location = new Point(339, 114);
            lblCapTan.Name = "lblCapTan";
            lblCapTan.Size = new Size(30, 238);
            lblCapTan.TabIndex = 12;
            lblCapTan.Paint += lblCapTan_Paint;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pbxAlerta);
            groupBox1.Controls.Add(lblExiSis);
            groupBox1.Controls.Add(lblCapTan);
            groupBox1.Controls.Add(pbxTanque);
            groupBox1.Location = new Point(218, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(381, 397);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            // 
            // pbxAlerta
            // 
            pbxAlerta.Image = Properties.Resources.medidor;
            pbxAlerta.Location = new Point(314, 16);
            pbxAlerta.Name = "pbxAlerta";
            pbxAlerta.Size = new Size(61, 45);
            pbxAlerta.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxAlerta.TabIndex = 18;
            pbxAlerta.TabStop = false;
            // 
            // lblExiSis
            // 
            lblExiSis.BackColor = Color.FromArgb(32, 158, 178);
            lblExiSis.Font = new Font("Courier New", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExiSis.ForeColor = Color.White;
            lblExiSis.Location = new Point(115, 220);
            lblExiSis.Name = "lblExiSis";
            lblExiSis.Size = new Size(112, 23);
            lblExiSis.TabIndex = 14;
            lblExiSis.Text = "30000.00";
            lblExiSis.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbxTanque
            // 
            pbxTanque.Image = Properties.Resources.TanqueLleno;
            pbxTanque.Location = new Point(21, 16);
            pbxTanque.Name = "pbxTanque";
            pbxTanque.Size = new Size(339, 375);
            pbxTanque.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxTanque.TabIndex = 12;
            pbxTanque.TabStop = false;
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(33, 150, 243);
            pnlEncabezado.BorderStyle = BorderStyle.None;
            pnlEncabezado.Controls.Add(btnMinimizar);
            pnlEncabezado.Controls.Add(btnCerrar);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(613, 39);
            pnlEncabezado.TabIndex = 15;
            pnlEncabezado.MouseDown += pnlEncabezado_MouseDown;
            pnlEncabezado.MouseMove += pnlEncabezado_MouseMove;
            pnlEncabezado.MouseUp += pnlEncabezado_MouseUp;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.Image = Properties.Resources.minimizar2;
            btnMinimizar.Location = new Point(541, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(37, 39);
            btnMinimizar.TabIndex = 18;
            btnMinimizar.UseVisualStyleBackColor = true;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Image = Properties.Resources.close25;
            btnCerrar.Location = new Point(575, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(37, 39);
            btnCerrar.TabIndex = 17;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(132, 18);
            lblTitulo.TabIndex = 16;
            lblTitulo.Text = "Inventario Urea";
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl.Location = new Point(12, 57);
            lbl.Name = "lbl";
            lbl.Size = new Size(163, 18);
            lbl.TabIndex = 16;
            lbl.Text = "TALLER CORDOBA";
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.CornflowerBlue;
            btnActualizar.BackgroundColor = Color.CornflowerBlue;
            btnActualizar.BorderColor = Color.PaleVioletRed;
            btnActualizar.BorderRadius = 15;
            btnActualizar.BorderSize = 0;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Image = (Image)resources.GetObject("btnActualizar.Image");
            btnActualizar.Location = new Point(46, 341);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 79);
            btnActualizar.TabIndex = 18;
            btnActualizar.Text = "Actualizar ";
            btnActualizar.TextAlign = ContentAlignment.BottomCenter;
            btnActualizar.TextColor = Color.White;
            btnActualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtUltFac
            // 
            txtUltFac.Font = new Font("Courier New", 12F);
            txtUltFac.Location = new Point(14, 181);
            txtUltFac.Name = "txtUltFac";
            txtUltFac.Size = new Size(172, 26);
            txtUltFac.TabIndex = 19;
            // 
            // frmInventarioUrea
            // 
            AllowRoundedCorners = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 450);
            Controls.Add(txtUltFac);
            Controls.Add(btnActualizar);
            Controls.Add(lbl);
            Controls.Add(pnlEncabezado);
            Controls.Add(groupBox1);
            Controls.Add(txtPreProm);
            Controls.Add(label5);
            Controls.Add(txtUltCos);
            Controls.Add(txtExiMir);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInventarioUrea";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmInventarioUrea";
            Load += frmInventarioUrea_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxAlerta).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxTanque).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlEncabezado).EndInit();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox txtExiMir;
        private TextBox txtUltCos;
        private Label label5;
        private TextBox txtPreProm;
        private Label lblCapTan;
        private GroupBox groupBox1;
        private Label lblExiSis;
        private PictureBox pbxTanque;
        private Syncfusion.Windows.Forms.Tools.GradientPanel pnlEncabezado;
        private Label lblTitulo;
        private Button btnCerrar;
        private Label lbl;
        private PictureBox pbxAlerta;
        private CustomRenderer.BotonRedondeado btnActualizar;
        private TextBox txtUltFac;
        private Button btnMinimizar;
    }
}