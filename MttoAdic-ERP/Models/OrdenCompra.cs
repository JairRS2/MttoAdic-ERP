using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MttoAdic_ERP.Models
{
    public class OrdenCompra
    {
        public int No_Orden { get; set; }
        public string Empresa { get; set; }
        public string Clave_Proveedor { get; set; }
        public string Proveedor { get; set; }
        public string Fecha_Orden { get; set; }
        public string Estado_Orden { get; set; }
        public string Factura { get; set; }
        public string Fecha_Factura { get; set; }
        public string Tipo_Pago { get; set; }
        public decimal Cantidad { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public decimal Costo { get; set; }
        public int Pedido { get; set; }
        public string Estado_Partida { get; set; }
        public int Bitacora { get; set; }
        public int nMes { get; set; }
        public string Mes { get; set; }
        public int Ano { get; set; }
        public string Tipo { get; set; }
        public string Linea { get; set; }
        public string Folio_Fiscal { get; set; }
    }
}
