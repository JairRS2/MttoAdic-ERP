using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MttoAdic_ERP
{
    public class PanelLogin : Panel
    {
        //Create a properties to define the colors for the gradient's top and bottom
        // reference
        public Color gradientTop { get; set; }
        // reference
        public Color gradientBottom { get; set; }

        //Create Constructor for the Gradient Panel Class
        public PanelLogin()
        {
            //Subscribe to the resize event to handle when the control's size changes.
            this.Resize += GradientPanel_Resize;
        }

        // reference
        private void GradientPanel_Resize(object sender, EventArgs e)
        {
            this.Invalidate(); //This marks the control as needing to be redrawn
        }

        //override the OnPaint method to draw a gradient background
        // reference
        protected override void OnPaint(PaintEventArgs e)
        {
            //create a linearGradientBrush with the specified top and bottom gradient colors
            LinearGradientBrush linear = new LinearGradientBrush(
                this.ClientRectangle, // this area to fill with the gradient
                this.gradientTop, // the starting color (top of the gradient)
                this.gradientBottom, // the ending color (bottom of the gradient)
                90F); // lastly the angle of the gradient (90 degrees = vertical)

            //get the graphics context for drawing
            Graphics g = e.Graphics;

            //Fill the entire control area with the gradient
            g.FillRectangle(linear, this.ClientRectangle);

            //last
            base.OnPaint(e);
        }
    }
}
