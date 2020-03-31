using BOEF.Models;
using BOEF.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BOEF.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private BOEFEntities _db;

        #region Constructor
        public CustomerRepository(BOEFEntities db)
        {
            _db = db;
        }
        #endregion


        public int AddCustomer(Customer customer)
        {
            _db.Customer.Add(customer);
            _db.SaveChanges();

            return 0;
        }

        public void DeleteCustomer(int id)
        {
            var customer = FindID(id);
            _db.Customer.Remove(customer);
            _db.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Modified;
        }

        public Customer FindID(int? id)
        {
            return _db.Customer.Find(id);
        }

        public List<Customer> GetAll()
        {
            return _db.Customer.ToList();
        }

    }
}