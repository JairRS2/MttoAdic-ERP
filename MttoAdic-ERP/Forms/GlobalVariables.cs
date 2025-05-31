
namespace MttoAdic_ERP.Models
{
    public static class GlobalVariables
    {
        public static int NivelAcceso { get; set; }
        public static string ClaveEmpleado { get; set; }
        public static string UsuarioLogueado { get; set; }

        // se añade la conexion sql como variable global
        public static csConexionSQL ConexionSQL { get; set; }
    }
}
