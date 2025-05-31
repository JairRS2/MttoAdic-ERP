namespace MttoAdic_ERP
{
    partial class frmMenuReporteador
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
            panel4 = new Panel();
            panel2 = new Panel();
            tabReporteador = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabVales = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ggcVales = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            tabDevolucionVale = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ggcDevolucionVale = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            tabCompras = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ggcCompras = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            tabLlantas = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ggcLlantas = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            tabComprasLlantas = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ggcComprasLLantas = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            tabDiesel = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ggcDiesel = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            tabDevolucionCompra = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            tabAceites = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            tabProductos = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            tabFacturas = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            tabBitacoras = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            panel3 = new Panel();
            panel5 = new Panel();
            pbReportes = new ProgressBar();
            label3 = new Label();
            panel1 = new Panel();
            btnSalir = new Button();
            dtpDesde = new DateTimePicker();
            btnCargar = new Button();
            label1 = new Label();
            dtpHasta = new DateTimePicker();
            btnExportar = new Button();
            label2 = new Label();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabReporteador).BeginInit();
            tabReporteador.SuspendLayout();
            tabVales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ggcVales).BeginInit();
            tabDevolucionVale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ggcDevolucionVale).BeginInit();
            tabCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ggcCompras).BeginInit();
            tabLlantas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ggcLlantas).BeginInit();
            tabComprasLlantas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ggcComprasLLantas).BeginInit();
            tabDiesel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ggcDiesel).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.Controls.Add(panel2);
            panel4.Controls.Add(panel3);
            panel4.Controls.Add(panel1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(984, 1050);
            panel4.TabIndex = 21;
            // 
            // panel2
            // 
            panel2.Controls.Add(tabReporteador);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(984, 964);
            panel2.TabIndex = 23;
            // 
            // tabReporteador
            // 
            tabReporteador.BeforeTouchSize = new Size(984, 964);
            tabReporteador.Controls.Add(tabVales);
            tabReporteador.Controls.Add(tabDevolucionVale);
            tabReporteador.Controls.Add(tabCompras);
            tabReporteador.Controls.Add(tabLlantas);
            tabReporteador.Controls.Add(tabComprasLlantas);
            tabReporteador.Controls.Add(tabDiesel);
            tabReporteador.Controls.Add(tabDevolucionCompra);
            tabReporteador.Controls.Add(tabAceites);
            tabReporteador.Controls.Add(tabProductos);
            tabReporteador.Controls.Add(tabFacturas);
            tabReporteador.Controls.Add(tabBitacoras);
            tabReporteador.Dock = DockStyle.Fill;
            tabReporteador.Location = new Point(0, 0);
            tabReporteador.Name = "tabReporteador";
            tabReporteador.Size = new Size(984, 964);
            tabReporteador.TabIndex = 18;
            tabReporteador.SelectedIndexChanged += tabReporteador_SelectedIndexChanged;
            // 
            // tabVales
            // 
            tabVales.Controls.Add(ggcVales);
            tabVales.Image = null;
            tabVales.ImageSize = new Size(16, 16);
            tabVales.Location = new Point(1, 27);
            tabVales.Name = "tabVales";
            tabVales.ShowCloseButton = true;
            tabVales.Size = new Size(981, 935);
            tabVales.TabIndex = 7;
            tabVales.Text = "Vales";
            tabVales.ThemesEnabled = false;
            // 
            // ggcVales
            // 
            ggcVales.AlphaBlendSelectionColor = Color.FromArgb(64, 0, 120, 215);
            ggcVales.BackColor = SystemColors.Window;
            ggcVales.Dock = DockStyle.Fill;
            ggcVales.Location = new Point(0, 0);
            ggcVales.Name = "ggcVales";
            ggcVales.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            ggcVales.ShowGroupDropArea = true;
            ggcVales.Size = new Size(981, 935);
            ggcVales.TabIndex = 18;
            ggcVales.TableDescriptor.FrozenColumn = "";
            ggcVales.TableDescriptor.TopLevelGroupOptions.ShowSummaries = true;
            ggcVales.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row;
            ggcVales.Text = "gridGroupingControl1";
            ggcVales.TopLevelGroupOptions.ShowFilterBar = true;
            ggcVales.UseRightToLeftCompatibleTextBox = true;
            ggcVales.VersionInfo = "27.1.57";
            // 
            // tabDevolucionVale
            // 
            tabDevolucionVale.Controls.Add(ggcDevolucionVale);
            tabDevolucionVale.Image = null;
            tabDevolucionVale.ImageSize = new Size(16, 16);
            tabDevolucionVale.Location = new Point(1, 27);
            tabDevolucionVale.Name = "tabDevolucionVale";
            tabDevolucionVale.ShowCloseButton = true;
            tabDevolucionVale.Size = new Size(981, 935);
            tabDevolucionVale.TabIndex = 10;
            tabDevolucionVale.Text = "DevolucionesVale";
            tabDevolucionVale.ThemesEnabled = false;
            // 
            // ggcDevolucionVale
            // 
            ggcDevolucionVale.AlphaBlendSelectionColor = Color.FromArgb(64, 0, 120, 215);
            ggcDevolucionVale.BackColor = SystemColors.Window;
            ggcDevolucionVale.Dock = DockStyle.Fill;
            ggcDevolucionVale.Location = new Point(0, 0);
            ggcDevolucionVale.Name = "ggcDevolucionVale";
            ggcDevolucionVale.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            ggcDevolucionVale.ShowGroupDropArea = true;
            ggcDevolucionVale.Size = new Size(981, 935);
            ggcDevolucionVale.TabIndex = 17;
            ggcDevolucionVale.TableDescriptor.ChildGroupOptions.CaptionText = "{Category} ";
            ggcDevolucionVale.TableDescriptor.FrozenColumn = "";
            ggcDevolucionVale.TableDescriptor.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            ggcDevolucionVale.TableDescriptor.TopLevelGroupOptions.ShowSummaries = true;
            ggcDevolucionVale.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row;
            ggcDevolucionVale.Text = "gridGroupingControl1";
            ggcDevolucionVale.TopLevelGroupOptions.ShowFilterBar = true;
            ggcDevolucionVale.UseRightToLeftCompatibleTextBox = true;
            ggcDevolucionVale.VersionInfo = "27.1.57";
            // 
            // tabCompras
            // 
            tabCompras.Controls.Add(ggcCompras);
            tabCompras.Image = null;
            tabCompras.ImageSize = new Size(16, 16);
            tabCompras.Location = new Point(1, 27);
            tabCompras.Name = "tabCompras";
            tabCompras.ShowCloseButton = true;
            tabCompras.Size = new Size(981, 935);
            tabCompras.TabIndex = 1;
            tabCompras.Text = "Compras";
            tabCompras.ThemesEnabled = false;
            // 
            // ggcCompras
            // 
            ggcCompras.AlphaBlendSelectionColor = Color.FromArgb(64, 0, 120, 215);
            ggcCompras.BackColor = SystemColors.Window;
            ggcCompras.Dock = DockStyle.Fill;
            ggcCompras.Location = new Point(0, 0);
            ggcCompras.Name = "ggcCompras";
            ggcCompras.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            ggcCompras.ShowGroupDropArea = true;
            ggcCompras.Size = new Size(981, 935);
            ggcCompras.TabIndex = 0;
            ggcCompras.TableDescriptor.AllowEdit = false;
            ggcCompras.TableDescriptor.AllowNew = false;
            ggcCompras.TableDescriptor.AllowRemove = false;
            ggcCompras.TableDescriptor.FrozenColumn = "";
            ggcCompras.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            ggcCompras.Text = "gridGroupingControl1";
            ggcCompras.TopLevelGroupOptions.ShowFilterBar = true;
            ggcCompras.UseRightToLeftCompatibleTextBox = true;
            ggcCompras.VersionInfo = "27.1.57";
            // 
            // tabLlantas
            // 
            tabLlantas.Controls.Add(ggcLlantas);
            tabLlantas.Image = null;
            tabLlantas.ImageSize = new Size(16, 16);
            tabLlantas.Location = new Point(1, 27);
            tabLlantas.Name = "tabLlantas";
            tabLlantas.ShowCloseButton = true;
            tabLlantas.Size = new Size(981, 935);
            tabLlantas.TabIndex = 3;
            tabLlantas.Text = "Llantas";
            tabLlantas.ThemesEnabled = false;
            // 
            // ggcLlantas
            // 
            ggcLlantas.AlphaBlendSelectionColor = Color.FromArgb(64, 0, 120, 215);
            ggcLlantas.BackColor = SystemColors.Window;
            ggcLlantas.Dock = DockStyle.Fill;
            ggcLlantas.Location = new Point(0, 0);
            ggcLlantas.Name = "ggcLlantas";
            ggcLlantas.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            ggcLlantas.ShowGroupDropArea = true;
            ggcLlantas.Size = new Size(981, 935);
            ggcLlantas.TabIndex = 19;
            ggcLlantas.TableDescriptor.FrozenColumn = "";
            ggcLlantas.TableDescriptor.TopLevelGroupOptions.ShowSummaries = true;
            ggcLlantas.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row;
            ggcLlantas.Text = "gridGroupingControl1";
            ggcLlantas.TopLevelGroupOptions.ShowFilterBar = true;
            ggcLlantas.UseRightToLeftCompatibleTextBox = true;
            ggcLlantas.VersionInfo = "27.1.57";
            // 
            // tabComprasLlantas
            // 
            tabComprasLlantas.Controls.Add(ggcComprasLLantas);
            tabComprasLlantas.Image = null;
            tabComprasLlantas.ImageSize = new Size(16, 16);
            tabComprasLlantas.Location = new Point(1, 27);
            tabComprasLlantas.Name = "tabComprasLlantas";
            tabComprasLlantas.ShowCloseButton = true;
            tabComprasLlantas.Size = new Size(981, 935);
            tabComprasLlantas.TabIndex = 6;
            tabComprasLlantas.Text = "ComprasLlantas";
            tabComprasLlantas.ThemesEnabled = false;
            // 
            // ggcComprasLLantas
            // 
            ggcComprasLLantas.AlphaBlendSelectionColor = Color.FromArgb(64, 0, 120, 215);
            ggcComprasLLantas.BackColor = SystemColors.Window;
            ggcComprasLLantas.Dock = DockStyle.Fill;
            ggcComprasLLantas.Location = new Point(0, 0);
            ggcComprasLLantas.Name = "ggcComprasLLantas";
            ggcComprasLLantas.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            ggcComprasLLantas.ShowGroupDropArea = true;
            ggcComprasLLantas.Size = new Size(981, 935);
            ggcComprasLLantas.TabIndex = 19;
            ggcComprasLLantas.TableDescriptor.FrozenColumn = "";
            ggcComprasLLantas.TableDescriptor.TopLevelGroupOptions.ShowSummaries = true;
            ggcComprasLLantas.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row;
            ggcComprasLLantas.Text = "gridGroupingControl1";
            ggcComprasLLantas.TopLevelGroupOptions.ShowFilterBar = true;
            ggcComprasLLantas.UseRightToLeftCompatibleTextBox = true;
            ggcComprasLLantas.VersionInfo = "27.1.57";
            // 
            // tabDiesel
            // 
            tabDiesel.Controls.Add(ggcDiesel);
            tabDiesel.Image = null;
            tabDiesel.ImageSize = new Size(16, 16);
            tabDiesel.Location = new Point(1, 27);
            tabDiesel.Name = "tabDiesel";
            tabDiesel.ShowCloseButton = true;
            tabDiesel.Size = new Size(981, 935);
            tabDiesel.TabIndex = 5;
            tabDiesel.Text = "Diesel";
            tabDiesel.ThemesEnabled = false;
            // 
            // ggcDiesel
            // 
            ggcDiesel.AlphaBlendSelectionColor = Color.FromArgb(64, 0, 120, 215);
            ggcDiesel.BackColor = SystemColors.Window;
            ggcDiesel.Dock = DockStyle.Fill;
            ggcDiesel.Location = new Point(0, 0);
            ggcDiesel.Name = "ggcDiesel";
            ggcDiesel.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            ggcDiesel.ShowGroupDropArea = true;
            ggcDiesel.Size = new Size(981, 935);
            ggcDiesel.TabIndex = 20;
            ggcDiesel.TableDescriptor.FrozenColumn = "";
            ggcDiesel.TableDescriptor.TopLevelGroupOptions.ShowSummaries = true;
            ggcDiesel.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Row;
            ggcDiesel.Text = "gridGroupingControl1";
            ggcDiesel.TopLevelGroupOptions.ShowFilterBar = true;
            ggcDiesel.UseRightToLeftCompatibleTextBox = true;
            ggcDiesel.VersionInfo = "27.1.57";
            // 
            // tabDevolucionCompra
            // 
            tabDevolucionCompra.Image = null;
            tabDevolucionCompra.ImageSize = new Size(16, 16);
            tabDevolucionCompra.Location = new Point(1, 27);
            tabDevolucionCompra.Name = "tabDevolucionCompra";
            tabDevolucionCompra.ShowCloseButton = true;
            tabDevolucionCompra.Size = new Size(981, 935);
            tabDevolucionCompra.TabIndex = 11;
            tabDevolucionCompra.Text = "DevolucionesCompra";
            tabDevolucionCompra.ThemesEnabled = false;
            // 
            // tabAceites
            // 
            tabAceites.Image = null;
            tabAceites.ImageSize = new Size(16, 16);
            tabAceites.Location = new Point(1, 27);
            tabAceites.Name = "tabAceites";
            tabAceites.ShowCloseButton = true;
            tabAceites.Size = new Size(981, 935);
            tabAceites.TabIndex = 2;
            tabAceites.Text = "Aceites";
            tabAceites.ThemesEnabled = false;
            // 
            // tabProductos
            // 
            tabProductos.Image = null;
            tabProductos.ImageSize = new Size(16, 16);
            tabProductos.Location = new Point(1, 27);
            tabProductos.Name = "tabProductos";
            tabProductos.ShowCloseButton = true;
            tabProductos.Size = new Size(981, 935);
            tabProductos.TabIndex = 8;
            tabProductos.Text = "Productos";
            tabProductos.ThemesEnabled = false;
            // 
            // tabFacturas
            // 
            tabFacturas.Image = null;
            tabFacturas.ImageSize = new Size(16, 16);
            tabFacturas.Location = new Point(1, 27);
            tabFacturas.Name = "tabFacturas";
            tabFacturas.ShowCloseButton = true;
            tabFacturas.Size = new Size(981, 935);
            tabFacturas.TabIndex = 9;
            tabFacturas.Text = "Facturas";
            tabFacturas.ThemesEnabled = false;
            // 
            // tabBitacoras
            // 
            tabBitacoras.Image = null;
            tabBitacoras.ImageSize = new Size(16, 16);
            tabBitacoras.Location = new Point(1, 27);
            tabBitacoras.Name = "tabBitacoras";
            tabBitacoras.ShowCloseButton = true;
            tabBitacoras.Size = new Size(981, 935);
            tabBitacoras.TabIndex = 12;
            tabBitacoras.Text = "Bitacoras";
            tabBitacoras.ThemesEnabled = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(pbReportes);
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 1008);
            panel3.Name = "panel3";
            panel3.Size = new Size(984, 42);
            panel3.TabIndex = 22;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(632, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(352, 42);
            panel5.TabIndex = 23;
            // 
            // pbReportes
            // 
            pbReportes.Location = new Point(174, 8);
            pbReportes.Name = "pbReportes";
            pbReportes.Size = new Size(427, 24);
            pbReportes.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 17);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 20;
            label3.Text = "Avance del reporte :";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(dtpDesde);
            panel1.Controls.Add(btnCargar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dtpHasta);
            panel1.Controls.Add(btnExportar);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 44);
            panel1.TabIndex = 21;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(488, 10);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 26);
            btnSalir.TabIndex = 31;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(55, 8);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(86, 23);
            dtpDesde.TabIndex = 25;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(304, 9);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(75, 26);
            btnCargar.TabIndex = 27;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 16);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 27;
            label1.Text = "Desde";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(201, 8);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(86, 23);
            dtpHasta.TabIndex = 26;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(396, 10);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(75, 26);
            btnExportar.TabIndex = 30;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(157, 16);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 29;
            label2.Text = "Hasta";
            // 
            // frmMenuReporteador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 1050);
            ControlBox = false;
            Controls.Add(panel4);
            Name = "frmMenuReporteador";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmReporteadorMenu_Load;
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tabReporteador).EndInit();
            tabReporteador.ResumeLayout(false);
            tabVales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ggcVales).EndInit();
            tabDevolucionVale.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ggcDevolucionVale).EndInit();
            tabCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ggcCompras).EndInit();
            tabLlantas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ggcLlantas).EndInit();
            tabComprasLlantas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ggcComprasLLantas).EndInit();
            tabDiesel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ggcDiesel).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel4;
        private Panel panel2;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabReporteador;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabVales;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggcVales;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabDevolucionVale;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggcDevolucionVale;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabCompras;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggcCompras;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabLlantas;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggcLlantas;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabComprasLlantas;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggcComprasLLantas;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabDevolucionCompra;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabDiesel;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabAceites;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabProductos;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabFacturas;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabBitacoras;
        private Panel panel3;
        private ProgressBar pbReportes;
        private Label label3;
        private Panel panel1;
        private Button btnSalir;
        private DateTimePicker dtpDesde;
        private Button btnCargar;
        private Label label1;
        private DateTimePicker dtpHasta;
        private Button btnExportar;
        private Label label2;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggcDiesel;
        private Panel panel5;
    }
}