using BOEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOEF.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        int AddCustomer(Customer customer);
        Customer FindID(int? id);
        void EditCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}