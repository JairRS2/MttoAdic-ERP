namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmAgregarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarUsuario));
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            btnRegistrar = new Button();
            cboNivelUsuario = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            label6 = new Label();
            panelPersonalizado1 = new panelPersonalizado();
            pictureBox4 = new PictureBox();
            loginTextbox1 = new loginTextbox();
            loginTextbox2 = new loginTextbox();
            loginTextbox3 = new loginTextbox();
            panelLogin2 = new PanelLogin();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboNivelUsuario).BeginInit();
            panelPersonalizado1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panelLogin2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(72, 111);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(306, 296);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(387, -3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(103, 634);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 15;
            pictureBox3.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(30, 70, 120);
            label3.Location = new Point(566, 56);
            label3.Name = "label3";
            label3.Size = new Size(240, 30);
            label3.TabIndex = 14;
            label3.Text = "REGISTRAR USUARIO!";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(621, 99);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(91, 90);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(33, 145, 245);
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Bahnschrift", 12F);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(517, 487);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(289, 48);
            btnRegistrar.TabIndex = 11;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // cboNivelUsuario
            // 
            cboNivelUsuario.AllowNewText = false;
            cboNivelUsuario.BackColor = Color.FromArgb(33, 150, 243);
            cboNivelUsuario.BeforeTouchSize = new Size(289, 23);
            cboNivelUsuario.Border3DStyle = Border3DStyle.Adjust;
            cboNivelUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNivelUsuario.FlatBorderColor = SystemColors.ActiveCaption;
            cboNivelUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cboNivelUsuario.ForeColor = Color.White;
            cboNivelUsuario.Location = new Point(517, 438);
            cboNivelUsuario.Name = "cboNivelUsuario";
            cboNivelUsuario.Size = new Size(289, 23);
            cboNivelUsuario.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(30, 70, 120);
            label6.Location = new Point(518, 418);
            label6.Name = "label6";
            label6.Size = new Size(137, 15);
            label6.TabIndex = 21;
            label6.Text = "Selecccione el modulo: ";
            // 
            // panelPersonalizado1
            // 
            panelPersonalizado1.BackColor = Color.Transparent;
            panelPersonalizado1.Controls.Add(pictureBox4);
            panelPersonalizado1.gradientBottom = Color.FromArgb(33, 145, 245);
            panelPersonalizado1.gradientTop = Color.FromArgb(9, 74, 158);
            panelPersonalizado1.Location = new Point(0, -3);
            panelPersonalizado1.Name = "panelPersonalizado1";
            panelPersonalizado1.Size = new Size(400, 634);
            panelPersonalizado1.TabIndex = 22;
            panelPersonalizado1.Paint += panelPersonalizado1_Paint;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(58, 102);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(306, 344);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // loginTextbox1
            // 
            loginTextbox1.BackColor = Color.FromArgb(33, 145, 245);
            loginTextbox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            loginTextbox1.ForeColor = Color.FromArgb(30, 70, 120);
            loginTextbox1.IsPassword = false;
            loginTextbox1.Label = "Clave:";
            loginTextbox1.Location = new Point(518, 195);
            loginTextbox1.Name = "loginTextbox1";
            loginTextbox1.NormalTextColor = SystemColors.WindowFrame;
            loginTextbox1.Padding = new Padding(0, 0, 0, 1);
            loginTextbox1.PlaceholderText = "";
            loginTextbox1.Size = new Size(289, 63);
            loginTextbox1.TabIndex = 23;
            loginTextbox1.Tag = "";
            // 
            // loginTextbox2
            // 
            loginTextbox2.BackColor = Color.FromArgb(33, 145, 245);
            loginTextbox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            loginTextbox2.ForeColor = Color.FromArgb(30, 70, 120);
            loginTextbox2.IsPassword = true;
            loginTextbox2.Label = "Contraseña:";
            loginTextbox2.Location = new Point(518, 264);
            loginTextbox2.Name = "loginTextbox2";
            loginTextbox2.NormalTextColor = SystemColors.WindowFrame;
            loginTextbox2.Padding = new Padding(0, 0, 0, 1);
            loginTextbox2.PlaceholderText = "";
            loginTextbox2.Size = new Size(289, 63);
            loginTextbox2.TabIndex = 24;
            loginTextbox2.Tag = "";
            // 
            // loginTextbox3
            // 
            loginTextbox3.BackColor = Color.FromArgb(33, 145, 245);
            loginTextbox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            loginTextbox3.ForeColor = Color.FromArgb(30, 70, 120);
            loginTextbox3.IsPassword = false;
            loginTextbox3.Label = "Nombre:";
            loginTextbox3.Location = new Point(518, 333);
            loginTextbox3.Name = "loginTextbox3";
            loginTextbox3.NormalTextColor = SystemColors.WindowFrame;
            loginTextbox3.Padding = new Padding(0, 0, 0, 1);
            loginTextbox3.PlaceholderText = "Nombre del Empleado...";
            loginTextbox3.Size = new Size(289, 63);
            loginTextbox3.TabIndex = 25;
            loginTextbox3.Tag = "";
            // 
            // panelLogin2
            // 
            panelLogin2.BackColor = Color.Transparent;
            panelLogin2.Controls.Add(label1);
            panelLogin2.gradientBottom = Color.Empty;
            panelLogin2.gradientTop = Color.Empty;
            panelLogin2.Location = new Point(479, 0);
            panelLogin2.Name = "panelLogin2";
            panelLogin2.Size = new Size(414, 53);
            panelLogin2.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(30, 70, 120);
            label1.Location = new Point(368, 9);
            label1.Name = "label1";
            label1.Size = new Size(27, 30);
            label1.TabIndex = 6;
            label1.Text = "X";
            label1.Click += label1_Click;
            // 
            // frmAgregarUsuario
            // 
            AcceptButton = btnRegistrar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 580);
            Controls.Add(panelLogin2);
            Controls.Add(loginTextbox3);
            Controls.Add(loginTextbox2);
            Controls.Add(loginTextbox1);
            Controls.Add(panelPersonalizado1);
            Controls.Add(label6);
            Controls.Add(cboNivelUsuario);
            Controls.Add(pictureBox3);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(btnRegistrar);
            ForeColor = Color.DodgerBlue;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmAgregarUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAgregarUsuario";
            Load += frmAgregarUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboNivelUsuario).EndInit();
            panelPersonalizado1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panelLogin2.ResumeLayout(false);
            panelLogin2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private loginTextbox loginTextbox2;
        private loginTextbox loginTextbox1;
        private Label label3;
        private Label label5;
        private PanelLogin panelLogin2;
        private PictureBox pictureBox2;
        private Button btnRegistrar;
        private loginTextbox loginTextbox3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboNivelUsuario;
        private Label label6;
        private panelPersonalizado panelPersonalizado1;
        private PictureBox pictureBox4;
        private Label label1;
    }
}