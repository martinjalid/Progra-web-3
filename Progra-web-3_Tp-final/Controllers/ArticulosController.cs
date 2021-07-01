using Microsoft.AspNetCore.Mvc;
using Progra_web_3_Tp_final.Models;
using Progra_web_3_Tp_final.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Controllers
{
    public class ArticulosController : Controller
    {
        _20211CTPContext context;
        private IArticulosServicio _articulosServicio;

        public ArticulosController()
        {
            context = new _20211CTPContext();
            _articulosServicio = new ArticulosServicio(context);
        }

        public IActionResult Index()
        {
            return View(context.Articulos.ToList());
        }
        

        public ActionResult NuevoArticulo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoArticulo(Articulo art)
        {
            if (ModelState.IsValid)
            {
                _articulosServicio.Alta(art);
                return Redirect("/Articulos");
            }
            return View(art);
        }

        public ActionResult EditarArticulo(int id)
        {
            Articulo art = _articulosServicio.ObtenerPorId(id);
            return View(art);
        }

        [HttpPost]
       public ActionResult EditarArticulo(Articulo art)
        {
            _articulosServicio.Modificar(art);
            return Redirect("/Articulos");
        }

        public ActionResult Eliminar(int id)
        {
            Articulo art = _articulosServicio.ObtenerPorId(id);
            _articulosServicio.Eliminar(art);
            return Redirect("/Articulos");
        }




    }
}
