using BOEF.Models;
using BOEF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOEF.Repository.Interfaces
{
    public interface IBoekingRepository
    {
        List<Boeking> GetAll();
        void AddBoeking(BoekingVM boekingVM);
        Boeking FindID(int? id);
        void DeleteBoeking(int id);

    }
}