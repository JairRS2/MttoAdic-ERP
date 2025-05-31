using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MttoAdic_ERP.Models
{
    public class ValeAlmacen
    {
        public string Empresa { get; set; } 
        public string Servicio { get; set; }
        public string Unidad { get; set; }
        public int ID { get; set; }
        public int Vale { get; set; }
        public string Fecha { get; set; }
        public int Bitacora { get; set; }
        public double Cantidad { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public double Precio { get; set; }
        public double Importe { get; set; }
        public string Tipo { get; set; }
        public int nMes { get; set; }
        public string Mes { get; set; }
        public int Ano { get; set; }
        public string Linea { get; set; }
        public string Zona { get; set; }
        public string Observaciones { get; set; } 
    }
}
