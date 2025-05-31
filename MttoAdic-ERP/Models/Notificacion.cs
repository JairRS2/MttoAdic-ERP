using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MttoAdic_ERP.Models
{
    public class Notificacion
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Modulo { get; set; }
    }
}
