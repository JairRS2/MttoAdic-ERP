using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D; // Necesario para LinearGradientBrush
using System.Drawing; // Necesario para Color, Graphics
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Necesario para Panel
using System.ComponentModel; // Necesario para los atributos de diseño

namespace MttoAdic_ERP
{
    internal class panelPersonalizado : Panel
    {
        [Category("Apariencia de Gradiente")]
        [Description("Color superior del gradiente.")]
        public Color gradientTop { get; set; } = Color.Black; // Valor por defecto

        [Category("Apariencia de Gradiente")]
        [Description("Color inferior del gradiente.")]
        public Color gradientBottom { get; set; } = Color.White; // Valor por defecto

        public panelPersonalizado()
        {
            // Inicializar colores por defecto si no se especifican en el diseñador
            if (gradientTop == Color.Empty) gradientTop = Color.Black;
            if (gradientBottom == Color.Empty) gradientBottom = Color.White;

            this.Resize += GradientPanel_Resize;
        }

        private void GradientPanel_Resize(object sender, EventArgs e)
        {
            this.Invalidate(); // Esto marca el control como necesitando ser redibujado
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Asegúrate de que los colores tengan valores válidos antes de usarlos
            Color topColor = gradientTop == Color.Empty ? Color.Black : gradientTop;
            Color bottomColor = gradientBottom == Color.Empty ? Color.White : gradientBottom;

            LinearGradientBrush linear = new LinearGradientBrush(
                this.ClientRectangle, // el área a rellenar con el gradiente
                topColor, // el color inicial (parte superior del gradiente)
                bottomColor, // el color final (parte inferior del gradiente)
                90F); // el ángulo del gradiente (90 grados = vertical)

            Graphics g = e.Graphics;
            g.FillRectangle(linear, this.ClientRectangle);

            // Asegúrate de liberar los recursos del pincel
            linear.Dispose();

            base.OnPaint(e);
        }
    }
}