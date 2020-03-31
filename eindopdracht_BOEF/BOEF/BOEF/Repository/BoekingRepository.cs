using BOEF.Models;
using BOEF.Models.ViewModels;
using BOEF.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOEF.Repository
{
    public class BoekingRepository : IBoekingRepository
    {

        private BOEFEntities _db;

        #region Constructor
        public BoekingRepository(BOEFEntities db)
        {
            _db = db;
        }
        #endregion

        #region Methods
        public void AddBoeking(BoekingVM boekingVM)
        {
            var boeking = new Boeking();
            boeking.Date = boekingVM.Date;
            boeking.CustomerId = boekingVM.Customer.Id;
            boeking.Customer = boekingVM.Customer;
            boeking.Discount = boekingVM.TotalDiscount;
            boeking.totalPrice = boekingVM.TotalPrice;

            _db.Boeking.Add(boeking);
            _db.SaveChanges();

            boeking = _db.Boeking.OrderByDescending(b => b.Id).FirstOrDefault();

            //add beest(en) to boeking
            foreach (var beest in boekingVM.SelectedBeests.Keys)
            {
                beest.Boeking.Add(boeking);
                boeking.Beest.Add(beest);
            }

            //add accessoire(s) to boeking
            if (boekingVM.SelectedAccessoires.Count != 0)
            {
                foreach (var accessoire in boekingVM.SelectedAccessoires.Keys)
                {
                    accessoire.Boeking.Add(boeking);
                    boeking.Accessoires.Add(accessoire);
                }
            }

            _db.SaveChanges();
        }

        public void DeleteBoeking(int id)
        {
            var boeking = FindID(id);
            boeking.Accessoires.Clear();
            boeking.Beest.Clear();

            _db.Customer.Remove(_db.Customer.Find(boeking.Customer.Id));
            _db.Boeking.Remove(boeking);
            _db.SaveChanges();
        }

        public Boeking FindID(int? id)
        {
            return _db.Boeking.Find(id);
        }

        public List<Boeking> GetAll()
        {
            return _db.Boeking.ToList();
        }

        #endregion
    }
}