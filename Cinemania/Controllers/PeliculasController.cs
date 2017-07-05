using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinemania.Controllers
{
    public class PeliculasController : Controller
    {

        Context db = new Context();
        // GET: Reservas
        


        public ActionResult Reservas()
        {
            var listaReservas = db.Reservas.ToList();
            ViewBag.listaReservas = new SelectList(db.Reservas, "IdReserva");

            return View(listaReservas);
        }




        // GET: Reserva/NuevaReserva

        public ActionResult NuevaReserva()
        {
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre");
            ViewBag.IdSede = new SelectList(db.Sedes, "IdSede", "Nombre");
            ViewBag.HoraReserva = new SelectList(db.Carteleras, "IdCartelera", "HoraInicio");






            return View();

        }





        [HttpPost]
        public ActionResult NuevaReserva(Reservas Reserva)
        {
            Reservas res = new Reservas();
            res.IdVersion = Reserva.IdVersion;
            res.IdSede = Reserva.IdSede;
            res.FechaHoraInicio = Reserva.FechaHoraInicio;
            
            



            if (ModelState.IsValid)
            {



                db.Reservas.Add(res);
                db.SaveChanges();

                return RedirectToAction("Reservas"); // Retorna a la vista "Peliculas"
            }
            return View();
        }

    }
}