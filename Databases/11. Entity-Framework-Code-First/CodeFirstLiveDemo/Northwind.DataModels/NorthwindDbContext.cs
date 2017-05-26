using Northwind.Data.Models;
using System.Data.Entity;

namespace Northwind.DataModels
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext() : base("NorthwindDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //прави връзка - много към много 
            modelBuilder.Entity<City>().HasKey(x => x.Id).HasMany(x => x.Teachers).WithRequired(x => x.City);

            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<Teacher> Teachers { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }
    }
}
