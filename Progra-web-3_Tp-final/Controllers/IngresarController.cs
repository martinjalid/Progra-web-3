using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Progra_web_3_Tp_final.Models;
using Progra_web_3_Tp_final.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Controllers
{
    public class IngresarController : Controller
    {
        _20211CTPContext context;
        private IUsuariosServicio _usuariosServicio;

        public IActionResult Index()
        {
            return View();
        }
    }
}