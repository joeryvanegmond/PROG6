using BOEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOEF.Repository
{
    public interface IBeestRepository
    {
        List<Beest> GetAll();
        void AddBeest(Beest beest);
        Beest FindID(int? id);
        void EditBeest(Beest beest);
        void DeleteBeest(int id);
        List<BeestImage> GetAllBeestImages();
    }
}