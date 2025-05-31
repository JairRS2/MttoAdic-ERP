using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MttoAdic_ERP.Forms.Almacen
{
    public partial class VistaPreviaImagen : MetroForm
    {
        public VistaPreviaImagen(Image imagen)
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;

            PictureBox pb = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = imagen,
                SizeMode = PictureBoxSizeMode.CenterImage,
            };

            this.Controls.Add(pb);
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Maximized;

        }        
    }
}
