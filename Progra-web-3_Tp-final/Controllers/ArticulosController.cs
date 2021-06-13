using Microsoft.AspNetCore.Mvc;
using Progra_web_3_Tp_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Controllers
{
    public class ArticulosController : Controller
    {
        _20211CTPContext context;

        public ArticulosController()
        {
            context = new _20211CTPContext();
        }

        public IActionResult Index()
        {
            return View(context.Articulos.ToList());
        }

        public IActionResult NuevoArticulo()
        {
            return View();
        }

    }
}
