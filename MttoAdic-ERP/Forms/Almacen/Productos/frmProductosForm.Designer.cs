namespace MttoAdic_ERP.Forms.Almacen.Productos
{
    partial class frmProductosForm
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
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            textBoxExt1 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            ((System.ComponentModel.ISupportInitialize)textBoxExt1).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(12, 14);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(52, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Código :";
            // 
            // textBoxExt1
            // 
            textBoxExt1.BeforeTouchSize = new Size(100, 23);
            textBoxExt1.Border3DStyle = Border3DStyle.Raised;
            textBoxExt1.BorderColor = Color.Orchid;
            textBoxExt1.BorderStyle = BorderStyle.FixedSingle;
            textBoxExt1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxExt1.ForeColor = Color.Black;
            textBoxExt1.Location = new Point(66, 7);
            textBoxExt1.MaxLength = 25;
            textBoxExt1.Name = "textBoxExt1";
            textBoxExt1.Size = new Size(100, 23);
            textBoxExt1.TabIndex = 1;
            // 
            // frmProductosForm
            // 
            AllowRoundedCorners = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 448);
            Controls.Add(textBoxExt1);
            Controls.Add(autoLabel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmProductosForm";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)textBoxExt1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt1;
    }
}