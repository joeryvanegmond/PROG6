using LeagueStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueStore.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Een actie die geen HTMl maar gewoon een berichtje terug stuurt
        /// </summary>
        /// <returns></returns>
        public ActionResult HelloWorld()
        {
            return Content("Hello world");
        }

        /// <summary>
        /// Een actie die een HTML pagina terug stuurt
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Een actie die een HTML pagina terug stuurt met data uit de ViewBag
        /// </summary>
        /// <returns></returns>
        public ActionResult News()
        {
            ViewBag.Titel = "SUPER MEGA KORTING";
            ViewBag.Bericht = "Alles nu 80% korting! Opruim weken bij de League store. ";
            ViewBag.DatumVan = DateTime.Now.ToShortDateString();
            ViewBag.DatumTot = DateTime.Now.AddDays(7).ToShortDateString();

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Naam = "winkel -leaguestore.nl";
            ViewBag.Adres = "Onderwijsboulevard 215";
            ViewBag.Telefoonnummer = "073 - 13371337";
            ViewBag.Email = "leaguestore@avans.nl";
            ViewBag.Datum = new DateTime(2009, 10, 27);

            List<Employee> employeed;

            using (var context = new MyContext())
            {
                employeed = context.Employees.ToList();
            }

            return View(employeed);
        }

        public ActionResult Bundel()
        {
            List<Bundle> Bundels;

            using (var context = new MyContext())
            {
                Bundels = context.Bundles.ToList();
            }

            return View(Bundels);
        }
    }
}