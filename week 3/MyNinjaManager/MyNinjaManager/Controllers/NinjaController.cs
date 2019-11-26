using MyNinjaManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyNinjaManager.Controllers
{
    public class NinjaController : Controller
    {
        private MyNinjaManagerEntities context = new MyNinjaManagerEntities();

        // GET: Ninja
        public ActionResult Index()
        {
            List<Ninja> ninjas;

            ninjas =  context.Ninja.ToList();


            return View(ninjas);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ninja ninja = context.Ninja.Find(id);
            if (ninja == null)
            {
                return HttpNotFound();
            }
            return View(ninja);
        }
    }
}