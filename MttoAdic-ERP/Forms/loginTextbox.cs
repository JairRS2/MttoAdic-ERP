using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MttoAdic_ERP.Forms
{
    public partial class loginTextbox : UserControl
    {
        // Campos privados para almacenar valores predeterminados
        public string label = "default value";
        public bool _isPassword = false;
        private string _placeholderText = ""; // Nuevo campo para el texto de marcador de posición
        private Color _placeholderColor = SystemColors.GrayText; // Color para el texto de marcador de posición
        private Color _normalTextColor = SystemColors.WindowText; // Color normal del texto

        // Propiedad pública para obtener o establecer el texto de la etiqueta
        public string Label
        {
            get { return label; }
            set { label = value; Invalidate(); } // Invalidate para que se redibuje el control
        }

        // Propiedad pública para obtener o establecer si el textbox debe actuar como campo de contraseña
        public bool IsPassword
        {
            get { return _isPassword; }
            set
            {
                _isPassword = value;
                if (_isPassword)
                {
                    textBox1.UseSystemPasswordChar = true;
                }
                else
                {
                    // Si deja de ser contraseña, restauramos el comportamiento normal
                    textBox1.UseSystemPasswordChar = false;
                    // Y re-evaluamos el placeholder si está vacío
                    HandlePlaceholder();
                }
                Invalidate();
            }
        }

        // ******************************************************************
        // Propiedad para el texto de MARCADOR DE POSICIÓN (Placeholder)
        // ******************************************************************
        [Category("Custom Properties")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PlaceholderText
        {
            get { return _placeholderText; }
            set { _placeholderText = value; HandlePlaceholder(); } // Llamamos a HandlePlaceholder cuando se cambia
        }

        // ******************************************************************
        // Propiedad para el color del texto normal (útil si hay placeholder)
        // ******************************************************************
        [Category("Custom Properties")]
        [Browsable(true)]
        public Color NormalTextColor
        {
            get { return _normalTextColor; }
            set { _normalTextColor = value; if (!IsPlaceholderActive()) textBox1.ForeColor = value; }
        }


        // ******************************************************************
        // Propiedad que ya tenías para exponer el texto del TextBox interno
        // ******************************************************************
        [Category("Custom Properties")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new string Text // Usamos 'new' porque System.Windows.Forms.Control ya tiene una propiedad Text
        {
            get
            {
                // Si el placeholder está activo, devolvemos una cadena vacía
                if (IsPlaceholderActive())
                {
                    return "";
                }
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                HandlePlaceholder(); // Llama a HandlePlaceholder cuando se establece el texto programáticamente
            }
        }

        public loginTextbox()
        {
            InitializeComponent();
            // Asegúrate de que el evento Paint se llama una vez
            this.Paint += loginTextbox_Paint;

            // Suscribirse a los eventos del TextBox interno
            textBox1.Enter += TextBox1_Enter;
            textBox1.Leave += TextBox1_Leave;
            textBox1.TextChanged += TextBox1_TextChanged; // Para manejar cambios de texto

            // Inicializar el color del texto normal del textbox interno
            _normalTextColor = textBox1.ForeColor; // Almacena el color original del texto

            // Llama a HandlePlaceholder al iniciar el control para mostrar el placeholder si es necesario
            HandlePlaceholder();
        }

        // Método para verificar si el placeholder está actualmente activo
        private bool IsPlaceholderActive()
        {
            return textBox1.Text == _placeholderText && textBox1.ForeColor == _placeholderColor;
        }


        // Método para manejar la lógica del placeholder
        private void HandlePlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrEmpty(_placeholderText) && !IsPassword)
            {
                // Si está vacío y hay placeholder y no es campo de contraseña
                textBox1.Text = _placeholderText;
                textBox1.ForeColor = _placeholderColor;
            }
            else if (IsPlaceholderActive() && !string.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text != _placeholderText)
            {
                // Si el placeholder estaba activo pero el usuario empezó a escribir
                textBox1.ForeColor = _normalTextColor;
            }
            else if (textBox1.Text == _placeholderText && textBox1.ForeColor == _placeholderColor && !string.IsNullOrEmpty(_placeholderText) && !IsPassword)
            {
                // Si el texto es el placeholder y no se ha enfocado aún
                // No hacer nada, ya está correcto.
            }
            else if (!IsPassword && textBox1.ForeColor != _normalTextColor && textBox1.Text != _placeholderText)
            {
                // Si el texto no es el placeholder y no es contraseña, debe tener el color normal
                textBox1.ForeColor = _normalTextColor;
            }
        }


        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (IsPlaceholderActive())
            {
                textBox1.Text = "";
                textBox1.ForeColor = _normalTextColor;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            HandlePlaceholder(); // Vuelve a aplicar la lógica del placeholder al perder el foco
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Este evento es importante para que el placeholder se "desactive"
            // si el usuario empieza a escribir después de que el control ya tenía foco
            // o si el texto se cambia programáticamente.
            if (IsPlaceholderActive() && !string.IsNullOrEmpty(textBox1.Text) && textBox1.Text != _placeholderText)
            {
                textBox1.ForeColor = _normalTextColor;
            }
            // Asegúrate de que la propiedad Text de tu UserControl refleje el cambio
            // No necesitas hacer nada aquí directamente, ya que la propiedad `Text`
            // de tu UserControl ya lee de `textBox1.Text`.
        }


        private void loginTextbox_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = label;
            // La lógica de IsPassword ya la movemos a la propiedad IsPassword para que se actualice al momento
            // y no solo en el Paint.
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Deja este vacío a menos que quieras dibujar algo específico en el panel
        }
    }
}