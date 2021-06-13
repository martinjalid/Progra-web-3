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
       
       public ActionResult Alta(Articulo art)
        {
            _articulosServicio.Alta(art);
            return Redirect("/Articulos");
        }


    }
}
