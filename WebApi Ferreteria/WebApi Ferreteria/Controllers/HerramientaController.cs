using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi_Ferreteria.Models;

namespace WebApi_Ferreteria.Controllers
{
    public class HerramientaController : ApiController
    {
        // GET: Herramienta
        [System.Web.Http.HttpPost]
        public IHttpActionResult Add(ClsArticulo articulo)
        {
            using (ferreteriaEntities db = new ferreteriaEntities())
            {

                Herramienta herramienta = new Herramienta();

                herramienta.nombre = articulo.Nombre;
                herramienta.precio = Convert.ToDecimal(articulo.Precio);
                herramienta.marca = articulo.Marca;
                herramienta.existencias = articulo.Existencias;

                db.Herramienta.Add(herramienta);
                db.SaveChanges();
            }

            return Ok("Registro agregado");
        }
    }
}