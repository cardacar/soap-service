using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmacenWebService.Models
{
    public class Product
    {

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public long Precio { get; set; }
        public int Cantidad { get; set; }
        public int IdAlmacen { get; set; }

    }
}