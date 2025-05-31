namespace MttoAdic_ERP.Forms.Almacen
{
    partial class frmBuscaDevolucionVale
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
            ggcDevoluciones = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            dtpDesde = new DateTimePicker();
            btnCargar = new Button();
            label1 = new Label();
            label2 = new Label();
            dtpHasta = new DateTimePicker();
            btnExportar = new Button();
            label3 = new Label();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)ggcDevoluciones).BeginInit();
            SuspendLayout();
            // 
            // ggcDevoluciones
            // 
            ggcDevoluciones.AllowDrop = true;
            ggcDevoluciones.AlphaBlendSelectionColor = Color.FromArgb(64, 0, 120, 215);
            ggcDevoluciones.BackColor = SystemColors.Window;
            ggcDevoluciones.Location = new Point(7, 97);
            ggcDevoluciones.Name = "ggcDevoluciones";
            ggcDevoluciones.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            ggcDevoluciones.ShowGroupDropArea = true;
            ggcDevoluciones.Size = new Size(803, 373);
            ggcDevoluciones.TabIndex = 0;
            ggcDevoluciones.TableDescriptor.AllowEdit = false;
            ggcDevoluciones.TableDescriptor.AllowNew = false;
            ggcDevoluciones.TableDescriptor.AllowRemove = false;
            ggcDevoluciones.TableDescriptor.ChildGroupOptions.ShowFilterBar = false;
            ggcDevoluciones.TableDescriptor.ChildGroupOptions.ShowSummaries = true;
            ggcDevoluciones.TableDescriptor.FrozenColumn = "";
            ggcDevoluciones.TableDescriptor.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row;
            ggcDevoluciones.TableDescriptor.TopLevelGroupOptions.ShowFilterBar = true;
            ggcDevoluciones.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row;
            ggcDevoluciones.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            ggcDevoluciones.Text = "gridGroupingControl1";
            ggcDevoluciones.TopLevelGroupOptions.CaptionSummaryRow = "Registros ";
            ggcDevoluciones.TopLevelGroupOptions.ShowFilterBar = true;
            ggcDevoluciones.UseRightToLeftCompatibleTextBox = true;
            ggcDevoluciones.VersionInfo = "27.1.56";
            ggcDevoluciones.TableControlCellClick += ggcDevoluciones_TableControlCellClick;
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
            label3.Size = new Size(264, 25);
            label3.TabIndex = 7;
            label3.Text = "Busca Devoluciones de Vales";
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
            // frmBuscaDevolucionVale
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 478);
            ControlBox = false;
            Controls.Add(btnSalir);
            Controls.Add(label3);
            Controls.Add(btnExportar);
            Controls.Add(label2);
            Controls.Add(dtpHasta);
            Controls.Add(label1);
            Controls.Add(btnCargar);
            Controls.Add(dtpDesde);
            Controls.Add(ggcDevoluciones);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmBuscaDevolucionVale";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmBuscaDevoluciones_Load;
            ((System.ComponentModel.ISupportInitialize)ggcDevoluciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggcDevoluciones;
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
