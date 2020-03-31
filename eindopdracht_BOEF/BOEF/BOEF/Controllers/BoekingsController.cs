using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BOEF.Helpers;
using BOEF.Models;
using BOEF.Models.ViewModels;
using BOEF.Repository;
using BOEF.Repository.Interfaces;

namespace BOEF.Controllers
{
    public class BoekingsController : Controller
    {
        private IBeestRepository _beestRepo = RepositoryLocator.Repositories.BeestRepository;
        private IAccessoiresRepository _accessoireRepo = RepositoryLocator.Repositories.AccessoiresRepository;
        private IBoekingRepository _boekingRepo = RepositoryLocator.Repositories.BoekingRepository;
        private ICustomerRepository _customerRepo = RepositoryLocator.Repositories.CustomerRepository;

        [HttpGet]
        public ActionResult Index()
        {
            return View(_boekingRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var boeking = _boekingRepo.FindID(id);
            if (boeking == null)
            {
                return HttpNotFound();
            }
            return View(boeking);
        }

        #region Step 1

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DateTime date)
        {
            if (date < DateTime.Today)
            {
                ModelState.AddModelError("Date", "Datum mag niet in het verleden liggen!");
                return View();
            }

            if (ModelState.IsValid)
            {
                BoekingVM boekingVM = new BoekingVM()
                {
                    Date = date
                };
                Session["model"] = boekingVM;

                return RedirectToAction("SelectBeest");
            }

            return View();
        }
        #endregion

        #region Step 2

        [HttpGet]
        public ActionResult SelectBeest()
        {

            Dictionary<Beest, String> beestWithImage = new Dictionary<Beest, String>();
            foreach (var item in _beestRepo.GetAll())
            {
                beestWithImage.Add(item, item.BeestImage.ImagePath);
            }

            BoekingVM boekingVM = null;
            if (Session["model"] != null)
            {
                boekingVM = Session["model"] as BoekingVM;

                boekingVM.Beesten = beestWithImage;
            }
            else
            {
                return RedirectToAction("Create");
            }

            return View(new BoekingVM() { Date = boekingVM.Date, Beesten = beestWithImage });
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectBeest(int[] beestIds)
        {
            BoekingVM _boekingVM = null;
            if (Session["model"] != null)
            {
                _boekingVM = Session["model"] as BoekingVM;
            }

            if (beestIds != null)
            {

                _boekingVM.BeestIds = beestIds;

                foreach (var item in _boekingVM.BeestIds)
                {
                    var beest = _beestRepo.FindID(item);
                    _boekingVM.SelectedBeests.Add(_beestRepo.FindID(item), beest.BeestImage.ImagePath);
                }

                #region Validators
                CustomValidations validator = new CustomValidations();
                if (validator.SortWithTypeValidate(_boekingVM.SelectedBeests))
                {
                    ModelState.AddModelError(string.Empty, "Je kunt geen leeuw of ijsbeer met een boerderij dier selecteren (uit voorzorgsmaatregelen).");
                    _boekingVM.SelectedBeests.Clear();
                    return View(_boekingVM);
                }

                if (validator.BookingPinguinInWeeknd(_boekingVM.SelectedBeests, _boekingVM.Date))
                {
                    ModelState.AddModelError(string.Empty, "Je kunt geen pinguïn in het weekend boeken.");
                    _boekingVM.SelectedBeests.Clear();
                    return View(_boekingVM);
                }

                if (validator.TypeBetweenOctAndFeb(_boekingVM.SelectedBeests, _boekingVM.Date))
                {
                    ModelState.AddModelError(string.Empty, "Je kunt beesten van het type woestijn niet tussen oktober en februari boeken (te koud)");
                    _boekingVM.SelectedBeests.Clear();
                    return View(_boekingVM);
                }

                if (validator.TypeBetweenJuneAndAug(_boekingVM.SelectedBeests, _boekingVM.Date))
                {
                    ModelState.AddModelError(string.Empty, "Je kunt beesten van het type sneeuw niet tussen juni en augustus boeken (te warm).");
                    _boekingVM.SelectedBeests.Clear();
                    return View(_boekingVM);
                }

                #endregion

                return RedirectToAction("SelectAccessoire");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kies ten minste 1 beestje!");
                return View(_boekingVM);
            }

        }
        #endregion

        #region Step 3

        [HttpGet]
        public ActionResult SelectAccessoire()
        {
            BoekingVM _boekingVM = null;
            if (Session["model"] != null)
            {
                _boekingVM = Session["model"] as BoekingVM;

                if (_boekingVM.BeestIds != null)
                {
                    _boekingVM.Accessoires.Clear();
                    foreach (var accessoire in _accessoireRepo.GetAll())
                    {
                        foreach (var beest in _boekingVM.BeestIds)
                        {
                            if (accessoire.IdBeest == beest)
                            {

                                _boekingVM.Accessoires.Add(accessoire, accessoire.AccessoireImage.ImagePath);
 
                            }
                        }
                    }
                }
            }
            else
            {
                return RedirectToAction("Create");
            }

            return View(_boekingVM);
        }

        [HttpPost]
        public ActionResult SelectAccessoire(int[] accessoireIds)
        {
            if (ModelState.IsValid)
            {

                BoekingVM _boekingVM = null;
                if (Session["model"] != null)
                {
                    _boekingVM = Session["model"] as BoekingVM;
                }

                _boekingVM.AccessoireIds = accessoireIds;

                if (_boekingVM.AccessoireIds != null)
                {
                    foreach (var item in _boekingVM.AccessoireIds)
                    {
                        var accessoire = _accessoireRepo.FindID(item);
                        _boekingVM.SelectedAccessoires.Add(accessoire, accessoire.AccessoireImage.ImagePath);
                    }
                }

                return RedirectToAction("InsertCustomerData");
            }

            return View();
        }

        #endregion

        #region Step 4
        [HttpGet]
        public ActionResult InsertCustomerData()
        {
            BoekingVM _boekingVM = null;
            if (Session["model"] != null)
            {
                _boekingVM = Session["model"] as BoekingVM;
            }
            else
            {
                return RedirectToAction("Create");
            }

            return View(_boekingVM);
        }

        [HttpPost]
        public ActionResult InsertCustomerData(Customer customer)
        {
            BoekingVM boekingVM = null;
            if (Session["model"] != null)
            {
                boekingVM = Session["model"] as BoekingVM;
            }
            else
            {
                return RedirectToAction("Create");
            }

            if (ModelState.IsValid)
            {
                boekingVM.Customer = customer;

                return RedirectToAction("ConfirmBooking");
            }
            else
            {
                return View(boekingVM);
            }

        }

        #endregion

        #region Step 5
        [HttpGet]
        public ActionResult ConfirmBooking()
        {
            BoekingVM _boekingVM = null;
            if (Session["model"] != null)
            {
                _boekingVM = Session["model"] as BoekingVM;
            }
            else
            {
                return RedirectToAction("create");
            }

            SaleCalculator calc = new SaleCalculator();
            calc.CalculatePrice(_boekingVM);

            return View(_boekingVM);
        }

        [HttpPost]
        public ActionResult ConfirmBooking(BoekingVM boekingVM)
        {
            if (ModelState.IsValid)
            {
                BoekingVM _boekingVM = null;
                if (Session["model"] != null)
                {
                    _boekingVM = Session["model"] as BoekingVM;
                }
                else
                {
                    return RedirectToAction("Create");
                }

                _customerRepo.AddCustomer(_boekingVM.Customer);
                boekingVM.Customer = _customerRepo.GetAll().OrderByDescending(c => c.Id).FirstOrDefault();
                _boekingRepo.AddBoeking(_boekingVM);

                return RedirectToAction("create", "Boekings", "create");
            }

            return View();
        }
        #endregion

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boeking boeking = _boekingRepo.FindID(id);
            if (boeking == null)
            {
                return HttpNotFound();
            }
            return View(boeking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _boekingRepo.DeleteBoeking(id);
            return RedirectToAction("Index");
        }


    }
}
