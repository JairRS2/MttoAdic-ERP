using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MttoAdic_ERP.Servicios
{
    public static class ServicioApi
    {
        public static readonly HttpClient Client;

        static ServicioApi()
        {
            Client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(60) // Puedes ajustar este valor
            };
        }
    }
}
