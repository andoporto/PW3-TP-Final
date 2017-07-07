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

            
            
            List<Sedes> totalSedes = new List<Sedes>();
            List<Versiones> totalVersiones = new List<Versiones>();
            using (Context dc = new Context())
            {
                totalSedes = dc.Sedes.OrderBy(a => a.IdSede).ToList();
            }
            // allState = db.Peliculas.OrderBy(a => a.IdPelicula).ToList();
            ViewBag.IdSede = new SelectList(totalSedes, "IdSede", "Nombre");
            ViewBag.IdVersion = new SelectList(db.Versiones, "IdVersion", "Nombre");

            //  ViewBag.HoraReserva = new SelectList(db.Carteleras, "IdCartelera", "HoraInicio");
            //   ViewBag.FechaInicio = new SelectList(db.Carteleras, "IdCartelera", "FechaInicio");

            dynamic FechaInicio = null;
            ViewBag.FechaInicio = FechaInicio;
            dynamic HoraInicio = null;
            ViewBag.HoraInicio = HoraInicio;
            return View();

            // var pel = db.Peliculas.Where(p => p.IdPelicula == IdPelicula).FirstOrDefault();

   


           

        }





        [HttpPost]
        public ActionResult NuevaReserva(Reservas Reserva)
        {
            Reservas res = new Reservas();
            res.IdVersion = Reserva.IdVersion;
            res.IdSede = Reserva.IdSede;

            string HoraInicio = Request["HoraInicio"];
            string FechaInicio = Request["FechaInicio"];
            string FechayHora = FechaInicio + " " + HoraInicio;

          //  string format = "ddd dd MMM yyyy h:mm tt zzz";

            Reserva.FechaHoraInicio = DateTime.Parse(FechayHora);
           // DateTime FechaHoraInicio = DateTime.ParseExact(FechayHora, format, provider);
           // res.FechaHoraInicio = FechaHoraInicio;
            /*
            List<Country> allCountry = new List<Country>();
            List<State> allState = new List<State>();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                allCountry = dc.Countries.OrderBy(a => a.CountryName).ToList();
                if (fb != null && fb.CountryID > 0)
                {
                    allState = dc.States.Where(a => a.CountryID.Equals(fb.CountryID)).OrderBy(a => a.StateName).ToList();
                }
            }

            ViewBag.CountryID = new SelectList(allCountry, "CountryID", "CountryName", fb.CountryID);
            ViewBag.StateID = new SelectList(allState, "StateID", "StateName", fb.StateID);


            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    dc.Feedbacks.Add(fb);
                    dc.SaveChanges();
                    ModelState.Clear();
                    fb = null;
                    ViewBag.Message = "Successfully submitted";
                }
            }
            else
            {
                ViewBag.Message = "Failed! Please try again";
            }
            return View(fb);*/



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