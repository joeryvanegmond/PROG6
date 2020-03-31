using BOEF.Models;
using BOEF.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BOEF.Repository
{
    public class AccessoiresRepository : IAccessoiresRepository
    {

        private BOEFEntities _db;

        #region Constructor
        public AccessoiresRepository(BOEFEntities db)
        {
            _db = db;
        }
        #endregion


        public void AddAccessoire(Accessoires accessoire)
        {

            _db.Accessoires.Add(accessoire);
            _db.SaveChanges();
        }

        public void DeleteAccessoire(int id)
        {
            Accessoires accessoires = _db.Accessoires.Find(id);
            _db.Accessoires.Remove(accessoires);
            _db.SaveChanges();
        }

        public void EditAccessoire(Accessoires accessoire)
        {
            _db.Set<Accessoires>().AddOrUpdate(accessoire);

            _db.SaveChanges();
        }

        public Accessoires FindID(int? id)
        {
            Accessoires accessoires = _db.Accessoires.Find(id);
            return accessoires;
        }

        public List<Accessoires> GetAll()
        {
            return _db.Accessoires.ToList();
        }

        public List<AccessoireImage> GetAccessoireImages()
        {
            return _db.AccessoireImage.ToList();
        }
    }
}