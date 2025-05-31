namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmBuscaVales
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ggcVales = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            dtpDesde = new DateTimePicker();
            btnCargar = new Button();
            label1 = new Label();
            label2 = new Label();
            dtpHasta = new DateTimePicker();
            btnExportar = new Button();
            label3 = new Label();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)ggcVales).BeginInit();
            SuspendLayout();
            // 
            // ggcVales
            // 
            ggcVales.AllowDrop = true;
            ggcVales.AlphaBlendSelectionColor = Color.FromArgb(64, 0, 120, 215);
            ggcVales.BackColor = SystemColors.Window;
            ggcVales.Location = new Point(7, 97);
            ggcVales.Name = "ggcVales";
            ggcVales.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            ggcVales.ShowGroupDropArea = true;
            ggcVales.Size = new Size(1215, 455);
            ggcVales.TabIndex = 0;
            ggcVales.TableDescriptor.AllowEdit = false;
            ggcVales.TableDescriptor.AllowNew = false;
            ggcVales.TableDescriptor.AllowRemove = false;
            ggcVales.TableDescriptor.ChildGroupOptions.ShowFilterBar = false;
            ggcVales.TableDescriptor.ChildGroupOptions.ShowSummaries = true;
            ggcVales.TableDescriptor.FrozenColumn = "";
            ggcVales.TableDescriptor.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row;
            ggcVales.TableDescriptor.TopLevelGroupOptions.ShowFilterBar = true;
            ggcVales.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row;
            ggcVales.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            ggcVales.Text = "gridGroupingControl1";
            ggcVales.TopLevelGroupOptions.CaptionSummaryRow = "Registros ";
            ggcVales.TopLevelGroupOptions.ShowFilterBar = true;
            ggcVales.UseRightToLeftCompatibleTextBox = true;
            ggcVales.VersionInfo = "27.1.56";
            ggcVales.TableControlCellClick += ggcVales_TableControlCellClick;
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(61, 63);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(86, 23);
            dtpDesde.TabIndex = 1;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(310, 64);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(75, 23);
            btnCargar.TabIndex = 2;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 71);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 3;
            label1.Text = "Desde";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 71);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 5;
            label2.Text = "Hasta";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(207, 63);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(86, 23);
            dtpHasta.TabIndex = 4;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(402, 65);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(75, 23);
            btnExportar.TabIndex = 6;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 8);
            label3.Name = "label3";
            label3.Size = new Size(113, 25);
            label3.TabIndex = 7;
            label3.Text = "Busca Vales";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(494, 65);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmBuscaVales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 559);
            ControlBox = false;
            Controls.Add(btnSalir);
            Controls.Add(label3);
            Controls.Add(btnExportar);
            Controls.Add(label2);
            Controls.Add(dtpHasta);
            Controls.Add(label1);
            Controls.Add(btnCargar);
            Controls.Add(dtpDesde);
            Controls.Add(ggcVales);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmBuscaVales";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmBuscaVales_Load;
            ((System.ComponentModel.ISupportInitialize)ggcVales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggcVales;
        private DateTimePicker dtpDesde;
        private Button btnCargar;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpHasta;
        private Button btnExportar;
        private Label label3;
        private Button btnSalir;
    }
}
