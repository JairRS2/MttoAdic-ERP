#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.ListView;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MttoAdic_ERP.Forms
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            imageListAdv1 = new ImageListAdv(components);
            gradientPanel1 = new GradientPanel();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            navigationDrawer1 = new NavigationDrawer();
            header = new DrawerHeader();
            dmiInicio = new DrawerMenuItem();
            dmiAlmacen = new DrawerMenuItem();
            dmiMantenimiento = new DrawerMenuItem();
            dmiLlantas = new DrawerMenuItem();
            dmiExternos = new DrawerMenuItem();
            dmiDiesel = new DrawerMenuItem();
            dmiReporteador = new DrawerMenuItem();
            dmiUrea = new DrawerMenuItem();
            dmiUsuarios = new DrawerMenuItem();
            dmiSalir = new DrawerMenuItem();
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).BeginInit();
            gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // imageListAdv1
            // 
            imageListAdv1.Images.AddRange(new Image[] { (Image)resources.GetObject("imageListAdv1.Images"), (Image)resources.GetObject("imageListAdv1.Images1"), (Image)resources.GetObject("imageListAdv1.Images2"), (Image)resources.GetObject("imageListAdv1.Images3"), (Image)resources.GetObject("imageListAdv1.Images4"), (Image)resources.GetObject("imageListAdv1.Images5"), (Image)resources.GetObject("imageListAdv1.Images6"), (Image)resources.GetObject("imageListAdv1.Images7"), (Image)resources.GetObject("imageListAdv1.Images8"), (Image)resources.GetObject("imageListAdv1.Images9"), (Image)resources.GetObject("imageListAdv1.Images10"), (Image)resources.GetObject("imageListAdv1.Images11"), (Image)resources.GetObject("imageListAdv1.Images12"), (Image)resources.GetObject("imageListAdv1.Images13"), (Image)resources.GetObject("imageListAdv1.Images14"), (Image)resources.GetObject("imageListAdv1.Images15"), (Image)resources.GetObject("imageListAdv1.Images16"), (Image)resources.GetObject("imageListAdv1.Images17"), (Image)resources.GetObject("imageListAdv1.Images18"), (Image)resources.GetObject("imageListAdv1.Images19"), (Image)resources.GetObject("imageListAdv1.Images20"), (Image)resources.GetObject("imageListAdv1.Images21"), (Image)resources.GetObject("imageListAdv1.Images22"), (Image)resources.GetObject("imageListAdv1.Images23"), (Image)resources.GetObject("imageListAdv1.Images24"), (Image)resources.GetObject("imageListAdv1.Images25"), (Image)resources.GetObject("imageListAdv1.Images26"), (Image)resources.GetObject("imageListAdv1.Images27"), (Image)resources.GetObject("imageListAdv1.Images28"), (Image)resources.GetObject("imageListAdv1.Images29"), (Image)resources.GetObject("imageListAdv1.Images30"), (Image)resources.GetObject("imageListAdv1.Images31"), (Image)resources.GetObject("imageListAdv1.Images32"), (Image)resources.GetObject("imageListAdv1.Images33"), (Image)resources.GetObject("imageListAdv1.Images34"), (Image)resources.GetObject("imageListAdv1.Images35"), (Image)resources.GetObject("imageListAdv1.Images36"), (Image)resources.GetObject("imageListAdv1.Images37"), (Image)resources.GetObject("imageListAdv1.Images38"), (Image)resources.GetObject("imageListAdv1.Images39"), (Image)resources.GetObject("imageListAdv1.Images40"), (Image)resources.GetObject("imageListAdv1.Images41"), (Image)resources.GetObject("imageListAdv1.Images42"), (Image)resources.GetObject("imageListAdv1.Images43") });
            // 
            // gradientPanel1
            // 
            gradientPanel1.BackColor = Color.White;
            gradientPanel1.BorderStyle = BorderStyle.FixedSingle;
            gradientPanel1.Controls.Add(label7);
            gradientPanel1.Controls.Add(pictureBox1);
            gradientPanel1.Dock = DockStyle.Top;
            gradientPanel1.Location = new Point(0, 0);
            gradientPanel1.Margin = new Padding(4, 3, 4, 3);
            gradientPanel1.Name = "gradientPanel1";
            gradientPanel1.Size = new Size(1209, 39);
            gradientPanel1.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(38, 8);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(109, 16);
            label7.TabIndex = 1;
            label7.Text = "Menu Principal";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.Icon_menu_Colorful;
            pictureBox1.Location = new Point(4, 3);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(gradientPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(10, 10);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1209, 860);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(navigationDrawer1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 39);
            panel3.Name = "panel3";
            panel3.Size = new Size(1209, 821);
            panel3.TabIndex = 6;
            // 
            // navigationDrawer1
            // 
            navigationDrawer1.BackColor = Color.FromArgb(255, 255, 255);
            navigationDrawer1.Dock = DockStyle.Fill;
            navigationDrawer1.DrawerWidth = 250;
            navigationDrawer1.Font = new Font("Arial Narrow", 12F);
            navigationDrawer1.Items.Add(header);
            navigationDrawer1.Items.Add(dmiInicio);
            navigationDrawer1.Items.Add(dmiAlmacen);
            navigationDrawer1.Items.Add(dmiMantenimiento);
            navigationDrawer1.Items.Add(dmiLlantas);
            navigationDrawer1.Items.Add(dmiExternos);
            navigationDrawer1.Items.Add(dmiDiesel);
            navigationDrawer1.Items.Add(dmiReporteador);
            navigationDrawer1.Items.Add(dmiUrea);
            navigationDrawer1.Items.Add(dmiUsuarios);
            navigationDrawer1.Items.Add(dmiSalir);
            navigationDrawer1.Location = new Point(0, 0);
            navigationDrawer1.Margin = new Padding(4, 3, 4, 3);
            navigationDrawer1.Name = "navigationDrawer1";
            navigationDrawer1.Size = new Size(1209, 821);
            navigationDrawer1.Style = NavigationDrawerStyle.Office2016Colorful;
            navigationDrawer1.TabIndex = 1;
            navigationDrawer1.Text = "navigationDrawer1";
            navigationDrawer1.ThemeName = "Office2016Colorful";
            navigationDrawer1.Click += navigationDrawer1_Click;
            // 
            // header
            // 
            header.BackColor = Color.FromArgb(1, 115, 199);
            header.Font = new Font("Arial Narrow", 12F);
            header.HeaderText = "header";
            header.Location = new Point(2, 0);
            header.Margin = new Padding(0);
            header.Name = "header";
            header.Size = new Size(250, 138);
            header.TabIndex = 0;
            header.Text = "header";
            header.TextColor = Color.FromArgb(255, 255, 255);
            // 
            // dmiInicio
            // 
            dmiInicio.BackColor = Color.White;
            dmiInicio.DefaultColor = Color.FromArgb(238, 238, 238);
            dmiInicio.Font = new Font("Segoe UI", 12F);
            dmiInicio.HoverColor = Color.FromArgb(230, 241, 250);
            dmiInicio.ItemText = "Inicio";
            dmiInicio.Location = new Point(2, 138);
            dmiInicio.Margin = new Padding(0);
            dmiInicio.MinimumSize = new Size(233, 58);
            dmiInicio.Name = "dmiInicio";
            dmiInicio.SelectionColor = Color.FromArgb(224, 224, 224);
            dmiInicio.Size = new Size(250, 58);
            dmiInicio.TabIndex = 8;
            dmiInicio.Text = "Inicio";
            dmiInicio.TextColor = Color.FromArgb(42, 42, 42);
            dmiInicio.Click += dmiInicio_Click;
            // 
            // dmiAlmacen
            // 
            dmiAlmacen.BackColor = Color.White;
            dmiAlmacen.DefaultColor = Color.FromArgb(238, 238, 238);
            dmiAlmacen.Font = new Font("Segoe UI", 12F);
            dmiAlmacen.HoverColor = Color.FromArgb(230, 241, 250);
            dmiAlmacen.ItemText = "Almacen";
            dmiAlmacen.Location = new Point(2, 196);
            dmiAlmacen.Margin = new Padding(0);
            dmiAlmacen.MinimumSize = new Size(233, 58);
            dmiAlmacen.Name = "dmiAlmacen";
            dmiAlmacen.SelectionColor = Color.FromArgb(224, 224, 224);
            dmiAlmacen.Size = new Size(250, 58);
            dmiAlmacen.TabIndex = 0;
            dmiAlmacen.Text = "Almacen";
            dmiAlmacen.TextColor = Color.FromArgb(42, 42, 42);
            dmiAlmacen.Click += dmiAlmacen_Click;
            // 
            // dmiMantenimiento
            // 
            dmiMantenimiento.BackColor = Color.White;
            dmiMantenimiento.DefaultColor = Color.FromArgb(238, 238, 238);
            dmiMantenimiento.Font = new Font("Segoe UI", 12F);
            dmiMantenimiento.HoverColor = Color.FromArgb(230, 241, 250);
            dmiMantenimiento.ItemText = "Mantenimiento";
            dmiMantenimiento.Location = new Point(2, 254);
            dmiMantenimiento.Margin = new Padding(0);
            dmiMantenimiento.MinimumSize = new Size(233, 58);
            dmiMantenimiento.Name = "dmiMantenimiento";
            dmiMantenimiento.SelectionColor = Color.FromArgb(224, 224, 224);
            dmiMantenimiento.Size = new Size(250, 58);
            dmiMantenimiento.TabIndex = 2;
            dmiMantenimiento.Text = "Mantenimiento";
            dmiMantenimiento.TextColor = Color.FromArgb(42, 42, 42);
            dmiMantenimiento.Click += dmiMantenimiento_Click;
            // 
            // dmiLlantas
            // 
            dmiLlantas.BackColor = Color.White;
            dmiLlantas.DefaultColor = Color.FromArgb(238, 238, 238);
            dmiLlantas.Font = new Font("Segoe UI", 12F);
            dmiLlantas.HoverColor = Color.FromArgb(230, 241, 250);
            dmiLlantas.ItemText = "Llantas";
            dmiLlantas.Location = new Point(2, 312);
            dmiLlantas.Margin = new Padding(0);
            dmiLlantas.MinimumSize = new Size(233, 58);
            dmiLlantas.Name = "dmiLlantas";
            dmiLlantas.SelectionColor = Color.FromArgb(224, 224, 224);
            dmiLlantas.Size = new Size(250, 58);
            dmiLlantas.TabIndex = 3;
            dmiLlantas.Text = "Llantas";
            dmiLlantas.TextColor = Color.FromArgb(42, 42, 42);
            dmiLlantas.Click += dmiLlantas_Click;
            // 
            // dmiExternos
            // 
            dmiExternos.BackColor = Color.White;
            dmiExternos.DefaultColor = Color.FromArgb(238, 238, 238);
            dmiExternos.Font = new Font("Segoe UI", 12F);
            dmiExternos.HoverColor = Color.FromArgb(230, 241, 250);
            dmiExternos.ItemText = "Servicio Externo";
            dmiExternos.Location = new Point(2, 370);
            dmiExternos.Margin = new Padding(0);
            dmiExternos.MinimumSize = new Size(233, 58);
            dmiExternos.Name = "dmiExternos";
            dmiExternos.SelectionColor = Color.FromArgb(224, 224, 224);
            dmiExternos.Size = new Size(250, 58);
            dmiExternos.TabIndex = 4;
            dmiExternos.Text = "Externos";
            dmiExternos.TextColor = Color.FromArgb(42, 42, 42);
            dmiExternos.Click += dmiExternos_Click;
            // 
            // dmiDiesel
            // 
            dmiDiesel.BackColor = Color.White;
            dmiDiesel.DefaultColor = Color.FromArgb(238, 238, 238);
            dmiDiesel.Font = new Font("Segoe UI", 12F);
            dmiDiesel.HoverColor = Color.FromArgb(230, 241, 250);
            dmiDiesel.ItemText = "Diesel";
            dmiDiesel.Location = new Point(2, 428);
            dmiDiesel.Margin = new Padding(0);
            dmiDiesel.MinimumSize = new Size(233, 58);
            dmiDiesel.Name = "dmiDiesel";
            dmiDiesel.SelectionColor = Color.FromArgb(224, 224, 224);
            dmiDiesel.Size = new Size(250, 58);
            dmiDiesel.TabIndex = 6;
            dmiDiesel.Text = "Diesel";
            dmiDiesel.TextColor = Color.FromArgb(42, 42, 42);
            dmiDiesel.Click += dmiDiesel_Click;
            // 
            // dmiReporteador
            // 
            dmiReporteador.BackColor = Color.White;
            dmiReporteador.DefaultColor = Color.FromArgb(238, 238, 238);
            dmiReporteador.Font = new Font("Segoe UI", 12F);
            dmiReporteador.HoverColor = Color.FromArgb(230, 241, 250);
            dmiReporteador.ItemText = "Reporteador";
            dmiReporteador.Location = new Point(2, 486);
            dmiReporteador.Margin = new Padding(0);
            dmiReporteador.MinimumSize = new Size(233, 58);
            dmiReporteador.Name = "dmiReporteador";
            dmiReporteador.SelectionColor = Color.FromArgb(224, 224, 224);
            dmiReporteador.Size = new Size(250, 58);
            dmiReporteador.TabIndex = 1;
            dmiReporteador.Text = "Reporteador";
            dmiReporteador.TextColor = Color.FromArgb(42, 42, 42);
            dmiReporteador.Click += dmiReporteador_Click;
            // 
            // dmiUrea
            // 
            dmiUrea.BackColor = Color.White;
            dmiUrea.DefaultColor = Color.FromArgb(238, 238, 238);
            dmiUrea.Font = new Font("Segoe UI", 12F);
            dmiUrea.HoverColor = Color.FromArgb(230, 241, 250);
            dmiUrea.ItemText = "Urea";
            dmiUrea.Location = new Point(2, 544);
            dmiUrea.Margin = new Padding(0);
            dmiUrea.MinimumSize = new Size(233, 58);
            dmiUrea.Name = "dmiUrea";
            dmiUrea.SelectionColor = Color.FromArgb(224, 224, 224);
            dmiUrea.Size = new Size(250, 58);
            dmiUrea.TabIndex = 9;
            dmiUrea.Text = "Urea";
            dmiUrea.TextColor = Color.FromArgb(42, 42, 42);
            dmiUrea.Click += dmiUrea_Click;
            // 
            // dmiUsuarios
            // 
            dmiUsuarios.BackColor = Color.White;
            dmiUsuarios.DefaultColor = Color.FromArgb(238, 238, 238);
            dmiUsuarios.Font = new Font("Segoe UI", 12F);
            dmiUsuarios.HoverColor = Color.FromArgb(230, 241, 250);
            dmiUsuarios.ItemText = "Usuarios";
            dmiUsuarios.Location = new Point(2, 602);
            dmiUsuarios.Margin = new Padding(0);
            dmiUsuarios.Name = "dmiUsuarios";
            dmiUsuarios.Size = new Size(250, 50);
            dmiUsuarios.TabIndex = 10;
            dmiUsuarios.Text = "Usuarios";
            dmiUsuarios.TextColor = Color.FromArgb(42, 42, 42);
            dmiUsuarios.Click += dmiUsuarios_Click;
            // 
            // dmiSalir
            // 
            dmiSalir.BackColor = Color.White;
            dmiSalir.DefaultColor = Color.FromArgb(238, 238, 238);
            dmiSalir.Font = new Font("Segoe UI", 12F);
            dmiSalir.HoverColor = Color.FromArgb(230, 241, 250);
            dmiSalir.ItemText = "Salir";
            dmiSalir.Location = new Point(2, 652);
            dmiSalir.Margin = new Padding(0);
            dmiSalir.MinimumSize = new Size(233, 58);
            dmiSalir.Name = "dmiSalir";
            dmiSalir.SelectionColor = Color.FromArgb(224, 224, 224);
            dmiSalir.Size = new Size(250, 58);
            dmiSalir.TabIndex = 5;
            dmiSalir.Text = "Salir";
            dmiSalir.TextColor = Color.FromArgb(42, 42, 42);
            dmiSalir.Click += dmiSalir_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1229, 880);
            ControlBox = false;
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Mantenimiento Adic";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).EndInit();
            gradientPanel1.ResumeLayout(false);
            gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

      

        #endregion
        private ImageListAdv imageListAdv1;
        private GradientPanel gradientPanel1;
        private Panel panel2;
        private Label label7;
        private PictureBox pictureBox1;
        private Panel panel3;
        private NavigationDrawer navigationDrawer1;
        private DrawerMenuItem dmiInicio;
        private DrawerMenuItem dmiAlmacen;
        private DrawerMenuItem dmiMantenimiento;
        private DrawerMenuItem dmiLlantas;
        private DrawerMenuItem dmiExternos;
        private DrawerMenuItem dmiDiesel;
        private DrawerMenuItem dmiReporteador;
        private DrawerMenuItem dmiSalir;
        private DrawerHeader header;
        private DrawerMenuItem dmiUrea;
        private DrawerMenuItem dmiUsuarios;
    }
}

