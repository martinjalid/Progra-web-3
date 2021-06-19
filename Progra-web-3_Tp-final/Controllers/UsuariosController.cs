using Microsoft.AspNetCore.Mvc;
using Progra_web_3_Tp_final.Models;
using Microsoft.AspNetCore.Http;
using Progra_web_3_Tp_final.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progra_web_3_Tp_final.Controllers
{
    public class UsuariosController : Controller
    {
        _20211CTPContext context;
        private IUsuariosServicio _usuariosServicio;


        public UsuariosController()
        {
            context = new _20211CTPContext();
            _usuariosServicio = new UsuariosServicio(context);
        }

        public IActionResult Index()
        {
            var mensaje = HttpContext.Session.GetString("MensajeIndex");

            if (!string.IsNullOrEmpty(mensaje))
            {
            }

            return View(context.Usuarios.ToList());
        }


        public IActionResult NuevoUsuario()
        {
            return View();
        }

       
        public IActionResult CrearNuevo(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
            
                _usuariosServicio.CrearNuevo(usuario);

                TempData["Mensaje"] = "TODO OK";

                HttpContext.Session.SetString("MensajeIndex", "El Resultado fue satisfactorio");

                return RedirectToAction("Index");

            }
            return Redirect("/Usuarios");
        }
        public IActionResult EditarUsuario()
        {
            return View();
        }

      /*  public ActionResult EditarUsuario(int id)
        {
            Usuario user = _usuariosServicio.ObtenerPorId(id);
            _usuariosServicio.EditarUsuario(user);
            return Redirect("/Usuarios/EditarUsuario");
        }
      */

    }
}
