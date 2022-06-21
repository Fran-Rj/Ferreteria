using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Ferreteria.Models
{
    public class ClsArticulo
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; }
        public int Existencias { get; set; }
    }
}