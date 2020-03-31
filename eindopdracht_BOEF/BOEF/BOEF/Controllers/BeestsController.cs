using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOEF.Models;
using BOEF.Repository;
using BOEF.Repository.Interfaces;

namespace BOEF.Controllers
{
    public class BeestsController : Controller
    {
        private IBeestRepository _beestRepo = RepositoryLocator.Repositories.BeestRepository;
        private IBeestTypeRepository _beestTypeRepo = RepositoryLocator.Repositories.BeestTypeRepository;

        [HttpGet]
        public ActionResult Index()
        {
            Dictionary<Beest, String> beestWithImage = new Dictionary<Beest, String>();
            foreach (var item in _beestRepo.GetAll())
            {
                beestWithImage.Add(item, item.BeestImage.ImagePath);
            }

            return View(beestWithImage);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var beest = _beestRepo.FindID(id);

            if (beest == null)
            {
                return HttpNotFound();
            }
            return View(beest);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Type = new SelectList(_beestTypeRepo.GetAll(), "Type", "Type");
            ViewBag.Image = new SelectList(_beestRepo.GetAllBeestImages(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,Prijs,Image")] Beest beest)
        {
            if (ModelState.IsValid)
            {
                _beestRepo.AddBeest(beest);
                return RedirectToAction("Index");
            }

            ViewBag.Type = new SelectList(_beestTypeRepo.GetAll(), "Type", "Type", beest.Type);
            ViewBag.Image = new SelectList(_beestRepo.GetAllBeestImages(), "Id", "Name", beest.Image);
            return View(beest);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var beest = _beestRepo.FindID(id);

            if (beest == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = new SelectList(_beestTypeRepo.GetAll(), "Type", "Type", beest.Type);
            ViewBag.Image = new SelectList(_beestRepo.GetAllBeestImages(), "Id", "Name", beest.Image);
            return View(beest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Prijs,Image")] Beest beest)
        {
            if (ModelState.IsValid)
            {
                _beestRepo.EditBeest(beest);
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(_beestTypeRepo.GetAll(), "Type", "Type", beest.Type);
            ViewBag.Image = new SelectList(_beestRepo.GetAllBeestImages(), "Id", "Name", beest.Image);
            return View(beest);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var beest = _beestRepo.FindID(id);
            if (beest == null)
            {
                return HttpNotFound();
            }
            return View(beest);
        }

        // POST: Beests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _beestRepo.DeleteBeest(id);
            return RedirectToAction("Index");
        }
    }
}
