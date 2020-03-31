using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeagueStore.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=Local")
        {
            System.Data.Entity.Database.SetInitializer(new MyContextInitializer());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bundle> Bundles { get; set; }
    }
}