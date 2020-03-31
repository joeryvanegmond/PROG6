using BOEF.Models;
using BOEF.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOEF.Repository
{
    public class BeestTypeRepository : IBeestTypeRepository
    {

        private BOEFEntities _db;

        #region Constructor
        public BeestTypeRepository(BOEFEntities db)
        {
            _db = db;
        }
        #endregion

        public List<BeestType> GetAll()
        {
            return _db.BeestType.ToList();
        }
    }
}