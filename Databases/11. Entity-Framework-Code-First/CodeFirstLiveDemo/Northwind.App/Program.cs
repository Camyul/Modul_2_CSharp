using Northwind.Data;
using Northwind.Data.Models;
using Northwind.DataModels;
using Northwind.DataModels.Migrations;
using System.Data.Entity;
using System.Linq;

namespace Northwind.App
{
    class Program
    {
        static void Main()
        {
            //При всяка промяна взима базата от последната миграция
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NorthwindDbContext, Configuration>()); 


            var dbContext = new NorthwindDbContext();

            var country = dbContext.Countries.FirstOrDefault(c => c.Id == 1);

            System.Console.WriteLine(country.Name);
            //var newCountry = new Country()
            //{
            //    Name = "Bulgaria"
            //};

            //dbContext.Countries.Add(newCountry);

            //dbContext.SaveChanges();
        }
    }
}
