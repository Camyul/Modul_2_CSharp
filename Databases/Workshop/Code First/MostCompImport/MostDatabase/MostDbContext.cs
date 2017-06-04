using MostDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostDatabase
{
    public class MostDbContext : DbContext
    {
        public MostDbContext() : base("MostConnection")
        {

        }

        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Tablet> Tablets { get; set; }

        //public DbSet<Category> Categories { get; set; }
    }
}
