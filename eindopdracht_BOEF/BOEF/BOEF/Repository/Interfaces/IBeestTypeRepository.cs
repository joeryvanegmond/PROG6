using BOEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOEF.Repository.Interfaces
{
    public interface IBeestTypeRepository
    {
        List<BeestType> GetAll();
    }
}