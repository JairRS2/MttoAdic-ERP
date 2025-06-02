namespace MttoAdic_ERP.Forms
{
    partial class frmLoginUrea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginUrea));
            panelPersonalizado1 = new panelPersonalizado();
            label2 = new Label();
            label4 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            loginTextbox1 = new loginTextbox();
            loginTextbox2 = new loginTextbox();
            label5 = new Label();
            btnLogin = new Button();
            pictureBox2 = new PictureBox();
            panelLogin2 = new PanelLogin();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panelPersonalizado1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelLogin2.SuspendLayout();
            SuspendLayout();
            // 
            // panelPersonalizado1
            // 
            panelPersonalizado1.BackColor = Color.White;
            panelPersonalizado1.Controls.Add(label2);
            panelPersonalizado1.Controls.Add(label4);
            panelPersonalizado1.Controls.Add(label1);
            panelPersonalizado1.Controls.Add(pictureBox1);
            panelPersonalizado1.gradientBottom = Color.FromArgb(33, 145, 245);
            panelPersonalizado1.gradientTop = Color.FromArgb(9, 74, 158);
            panelPersonalizado1.Location = new Point(0, 0);
            panelPersonalizado1.Name = "panelPersonalizado1";
            panelPersonalizado1.Size = new Size(427, 592);
            panelPersonalizado1.TabIndex = 0;
            panelPersonalizado1.Paint += panelPersonalizado1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(131, 218);
            label2.Name = "label2";
            label2.Size = new Size(112, 30);
            label2.TabIndex = 2;
            label2.Text = "SISTEMA!";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(171, 168);
            label4.Name = "label4";
            label4.Size = new Size(39, 30);
            label4.TabIndex = 8;
            label4.Text = "AL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(99, 120);
            label1.Name = "label1";
            label1.Size = new Size(166, 30);
            label1.TabIndex = 1;
            label1.Text = "¡BIENVENIDOS";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(88, 274);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(199, 187);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(368, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(111, 592);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(30, 70, 120);
            label3.Location = new Point(583, 56);
            label3.Name = "label3";
            label3.Size = new Size(170, 30);
            label3.TabIndex = 2;
            label3.Text = "INICIA SESION!";
            // 
            // loginTextbox1
            // 
            loginTextbox1.BackColor = Color.FromArgb(33, 145, 245);
            loginTextbox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            loginTextbox1.ForeColor = Color.FromArgb(30, 70, 120);
            loginTextbox1.IsPassword = false;
            loginTextbox1.Label = "Usuario:";
            loginTextbox1.Location = new Point(517, 218);
            loginTextbox1.Name = "loginTextbox1";
            loginTextbox1.NormalTextColor = SystemColors.WindowFrame;
            loginTextbox1.Padding = new Padding(0, 0, 0, 1);
            loginTextbox1.PlaceholderText = "Tú Clave de Empleado";
            loginTextbox1.Size = new Size(289, 63);
            loginTextbox1.TabIndex = 1;
            loginTextbox1.Tag = "";
            // 
            // loginTextbox2
            // 
            loginTextbox2.BackColor = Color.FromArgb(33, 145, 245);
            loginTextbox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            loginTextbox2.ForeColor = Color.FromArgb(30, 70, 120);
            loginTextbox2.IsPassword = true;
            loginTextbox2.Label = "Contraseña:";
            loginTextbox2.Location = new Point(517, 314);
            loginTextbox2.Name = "loginTextbox2";
            loginTextbox2.NormalTextColor = SystemColors.WindowFrame;
            loginTextbox2.Padding = new Padding(0, 0, 0, 1);
            loginTextbox2.PlaceholderText = "Escriba ";
            loginTextbox2.Size = new Size(289, 55);
            loginTextbox2.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(30, 70, 120);
            label5.Location = new Point(368, 9);
            label5.Name = "label5";
            label5.Size = new Size(27, 30);
            label5.TabIndex = 6;
            label5.Text = "X";
            label5.Click += label5_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(33, 145, 245);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Bahnschrift", 12F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(517, 413);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(289, 48);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Entrar";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(621, 99);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(91, 90);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // panelLogin2
            // 
            panelLogin2.BackColor = Color.Transparent;
            panelLogin2.Controls.Add(label5);
            panelLogin2.gradientBottom = Color.Empty;
            panelLogin2.gradientTop = Color.Empty;
            panelLogin2.Location = new Point(476, 0);
            panelLogin2.Name = "panelLogin2";
            panelLogin2.Size = new Size(407, 53);
            panelLogin2.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(759, 115);
            button1.Name = "button1";
            button1.Size = new Size(97, 23);
            button1.TabIndex = 10;

            button1.Text = "TEST MASTER";



            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 

            button2.Location = new Point(759, 155);
            button2.Name = "button2";
            button2.Size = new Size(97, 23);
            button2.TabIndex = 11;
            button2.Text = "Master";

            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(759, 189);
            button3.Name = "button3";
            button3.Size = new Size(97, 23);
            button3.TabIndex = 12;
            button3.Text = "RamaMerge";
            button3.UseVisualStyleBackColor = true;
            // 
            // frmLoginUrea
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(883, 591);
            ControlBox = false;
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panelLogin2);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(btnLogin);
            Controls.Add(loginTextbox2);
            Controls.Add(loginTextbox1);
            Controls.Add(label3);
            Controls.Add(panelPersonalizado1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLoginUrea";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLoginUrea";
            Load += frmLoginUrea_Load_1;
            panelPersonalizado1.ResumeLayout(false);
            panelPersonalizado1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelLogin2.ResumeLayout(false);
            panelLogin2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PanelLogin panelLogin1;
        private panelPersonalizado panelPersonalizado1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private loginTextbox loginTextbox1;
        private loginTextbox loginTextbox2;
        private PictureBox pictureBox3;
        private Label label4;
        private Label label5;
        private Button btnLogin;
        private PictureBox pictureBox2;
        private PanelLogin panelLogin2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}