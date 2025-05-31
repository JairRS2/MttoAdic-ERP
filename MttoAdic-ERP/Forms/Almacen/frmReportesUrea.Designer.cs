namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmReportesUrea
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
            lblTitulo = new Label();
            pnlEncabezado.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(33, 150, 243);
            pnlEncabezado.Controls.Add(btnMinimizar);
            pnlEncabezado.Controls.Add(btnSalir);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Margin = new Padding(3, 3, 3, 20);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(1110, 39);
            pnlEncabezado.TabIndex = 0;
            pnlEncabezado.MouseDown += pnlEncabezado_MouseDown;
            pnlEncabezado.MouseMove += pnlEncabezado_MouseMove;
            pnlEncabezado.MouseUp += pnlEncabezado_MouseUp;
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
            btnMinimizar.Location = new Point(1035, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(37, 39);
            btnMinimizar.TabIndex = 2;
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
            btnSalir.Location = new Point(1073, 0);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(37, 39);
            btnSalir.TabIndex = 1;
            btnSalir.TextColor = Color.White;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(507, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(117, 21);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Reportes Urea";
            // 
            // frmReportesUrea
            // 
            AllowRoundedCorners = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 558);
            Controls.Add(pnlEncabezado);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmReportesUrea";
            Text = "frmReportesUrea";
            Load += frmReportesUrea_Load;
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private CustomRenderer.BotonRedondeado btnSalir;
        private CustomRenderer.BotonRedondeado btnMinimizar;
    }
}