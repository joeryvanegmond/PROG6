using BOEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BOEF.Repository
{
    public class BeestRepository : IBeestRepository
    {
        private BOEFEntities _db;

        #region Constructor
        public BeestRepository(BOEFEntities db)
        {
            _db = db;
        }
        #endregion

        #region Methods
        public void AddBeest(Beest beest)
        {
            _db.Beest.Add(beest);
            _db.SaveChanges();
        }

        public List<Beest> GetAll()
        {
            return _db.Beest.ToList();
        }

        public Beest FindID(int? id)
        {
            Beest beest = _db.Beest.Find(id);
            return beest;
        }

        public void EditBeest(Beest beest)
        {
            _db.Set<Beest>().AddOrUpdate(beest);
            _db.SaveChanges();
        }

        public void DeleteBeest(int id)
        {
            Beest beest = _db.Beest.Find(id);

            var accessoires = _db.Accessoires.Where(a => a.IdBeest == id).ToList();
            if (accessoires != null)
            {

                //kijken welke accessoire er bij hoort
                foreach (var item in accessoires)
                {
                    _db.Accessoires.Remove(item);
                }
            }
            _db.Beest.Remove(beest);
            _db.SaveChanges();
        }

        public List<BeestImage> GetAllBeestImages()
        {
            return _db.BeestImage.ToList();
        }
        #endregion
    }
}