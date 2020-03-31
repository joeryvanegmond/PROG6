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
    public class AccessoiresController : Controller
    {
        private IAccessoiresRepository _accessoireRepo = RepositoryLocator.Repositories.AccessoiresRepository;
        private IBeestRepository _beestRepo = RepositoryLocator.Repositories.BeestRepository;

        [HttpGet]
        public ActionResult Index()
        {
            return View(_accessoireRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var accessoires = _accessoireRepo.FindID(id);
            if (accessoires == null)
            {
                return HttpNotFound();
            }
            return View(accessoires);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdBeest = new SelectList(_beestRepo.GetAll(), "Id", "Name");
            ViewBag.Image = new SelectList(_accessoireRepo.GetAccessoireImages(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IdBeest,Price,Image")] Accessoires accessoires)
        {
            if (ModelState.IsValid)
            {
                _accessoireRepo.AddAccessoire(accessoires);

                return RedirectToAction("Index");
            }

            ViewBag.IdBeest = new SelectList(_beestRepo.GetAll(), "Id", "Name", accessoires.IdBeest);
            ViewBag.Image = new SelectList(_accessoireRepo.GetAccessoireImages(), "Id", "Name");
            return View(accessoires);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var accessoires = _accessoireRepo.FindID(id);
            if (accessoires == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBeest = new SelectList(_beestRepo.GetAll(), "Id", "Name", accessoires.IdBeest);
            ViewBag.Image = new SelectList(_accessoireRepo.GetAccessoireImages(), "Id", "Name", accessoires.Image);

            return View(accessoires);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IdBeest,Price,Image")] Accessoires accessoires)
        {
            if (ModelState.IsValid)
            {
                _accessoireRepo.EditAccessoire(accessoires);
                return RedirectToAction("Index");
            }
            ViewBag.IdBeest = new SelectList(_beestRepo.GetAll(), "Id", "Name", accessoires.IdBeest);
            ViewBag.Image = new SelectList(_accessoireRepo.GetAccessoireImages(), "Id", "Name",accessoires.Image);

            return View(accessoires);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var accessoires = _accessoireRepo.FindID(id);
            if (accessoires == null)
            {
                return HttpNotFound();
            }
            return View(accessoires);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _accessoireRepo.DeleteAccessoire(id);
            return RedirectToAction("Index");
        }

    }
}
