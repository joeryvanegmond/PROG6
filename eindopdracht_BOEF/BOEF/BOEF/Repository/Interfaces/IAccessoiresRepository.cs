using BOEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOEF.Repository.Interfaces
{
    public interface IAccessoiresRepository
    {
        List<Accessoires> GetAll();
        void AddAccessoire(Accessoires accessoire);
        Accessoires FindID(int? id);
        void EditAccessoire(Accessoires accessoire);
        void DeleteAccessoire(int id);
        List<AccessoireImage> GetAccessoireImages();

    }
}