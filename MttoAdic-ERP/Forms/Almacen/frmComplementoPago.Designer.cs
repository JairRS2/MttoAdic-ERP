namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmComplementoPago
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
            label2 = new Label();
            dtpFolio = new DateTimePicker();
            label8 = new Label();
            txtImporte = new TextBox();
            label9 = new Label();
            txtFolio = new TextBox();
            label1 = new Label();
            txtResto = new TextBox();
            panel1 = new Panel();
            label3 = new Label();
            btnNuevo = new CustomRenderer.BotonRedondeado();
            btnGrabar = new CustomRenderer.BotonRedondeado();
            btnSalir = new CustomRenderer.BotonRedondeado();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 53);
            label2.Name = "label2";
            label2.Size = new Size(78, 17);
            label2.TabIndex = 37;
            label2.Text = "Folio Fiscal :";
            // 
            // dtpFolio
            // 
            dtpFolio.Font = new Font("Century Gothic", 9F);
            dtpFolio.Format = DateTimePickerFormat.Short;
            dtpFolio.Location = new Point(102, 81);
            dtpFolio.Name = "dtpFolio";
            dtpFolio.Size = new Size(103, 22);
            dtpFolio.TabIndex = 39;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(11, 87);
            label8.Name = "label8";
            label8.Size = new Size(85, 17);
            label8.TabIndex = 38;
            label8.Text = "Fecha Pago :";
            // 
            // txtImporte
            // 
            txtImporte.BorderStyle = BorderStyle.None;
            txtImporte.Font = new Font("Century Gothic", 9F);
            txtImporte.Location = new Point(424, 86);
            txtImporte.Name = "txtImporte";
            txtImporte.Size = new Size(80, 15);
            txtImporte.TabIndex = 41;
            txtImporte.KeyPress += txtImporte_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 9F);
            label9.Location = new Point(357, 84);
            label9.Name = "label9";
            label9.Size = new Size(61, 17);
            label9.TabIndex = 40;
            label9.Text = "Importe :";
            // 
            // txtFolio
            // 
            txtFolio.BorderStyle = BorderStyle.None;
            txtFolio.Font = new Font("Century Gothic", 9F);
            txtFolio.Location = new Point(95, 53);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(409, 15);
            txtFolio.TabIndex = 50;
            txtFolio.KeyPress += txtFolio_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F);
            label1.Location = new Point(217, 84);
            label1.Name = "label1";
            label1.Size = new Size(47, 17);
            label1.TabIndex = 51;
            label1.Text = "Resto :";
            // 
            // txtResto
            // 
            txtResto.Font = new Font("Century Gothic", 9F);
            txtResto.Location = new Point(270, 82);
            txtResto.Name = "txtResto";
            txtResto.ReadOnly = true;
            txtResto.Size = new Size(75, 22);
            txtResto.TabIndex = 52;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 120, 212);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(516, 39);
            panel1.TabIndex = 53;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(11, 9);
            label3.Name = "label3";
            label3.Size = new Size(194, 21);
            label3.TabIndex = 0;
            label3.Text = "Complemento de Pago";
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
            btnNuevo.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.DarkGreen;
            btnNuevo.Image = Properties.Resources.nuevo24;
            btnNuevo.Location = new Point(12, 126);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(98, 32);
            btnNuevo.TabIndex = 54;
            btnNuevo.Text = "Nuevo";
            btnNuevo.TextColor = Color.DarkGreen;
            btnNuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
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
            btnGrabar.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGrabar.ForeColor = Color.Navy;
            btnGrabar.Image = Properties.Resources.grabar24;
            btnGrabar.Location = new Point(217, 126);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(98, 32);
            btnGrabar.TabIndex = 55;
            btnGrabar.Text = "Grabar";
            btnGrabar.TextColor = Color.Navy;
            btnGrabar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGrabar.UseVisualStyleBackColor = false;
            btnGrabar.Click += btnGrabar_Click;
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
            btnSalir.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.DarkRed;
            btnSalir.Image = Properties.Resources.close24;
            btnSalir.Location = new Point(406, 126);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(98, 32);
            btnSalir.TabIndex = 56;
            btnSalir.Text = "Salir";
            btnSalir.TextColor = Color.DarkRed;
            btnSalir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmComplementoPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(516, 178);
            ControlBox = false;
            Controls.Add(btnSalir);
            Controls.Add(btnGrabar);
            Controls.Add(btnNuevo);
            Controls.Add(panel1);
            Controls.Add(txtResto);
            Controls.Add(label1);
            Controls.Add(txtFolio);
            Controls.Add(txtImporte);
            Controls.Add(label9);
            Controls.Add(dtpFolio);
            Controls.Add(label8);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmComplementoPago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Complemento de Pago";
            Load += frmComplementoPago_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private DateTimePicker dtpFolio;
        private Label label8;
        private TextBox txtImporte;
        private Label label9;
        private TextBox txtFolio;
        private Label label1;
        private TextBox txtResto;
        private Panel panel1;
        private Label label3;
        private CustomRenderer.BotonRedondeado btnNuevo;
        private CustomRenderer.BotonRedondeado btnGrabar;
        private CustomRenderer.BotonRedondeado btnSalir;
    }
}