using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinemania.Models;
using System.Runtime.Remoting.Contexts;

namespace Cinemania.Controllers
{
    public class HomeController : Controller
    {

        // BASE DE DATOS
        Context db = new Context();

        // GET: Home/Inicio
        public ActionResult Inicio()
        {

            var listaPeliculas = db.Peliculas.ToList();

            return View(listaPeliculas);
        }

        // GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidarLogin(FormCollection form)
        {
            var resultado = ValidarUsuario.Validar(form);

            if (resultado == null)
            {
                TempData["Validacion"] = "Datos inválidos";
                return RedirectToAction("../Home/Login");
            }

            return RedirectToAction("../Administracion/Inicio");          
        }



    }
}