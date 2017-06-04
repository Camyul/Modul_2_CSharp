using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostDatabase.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public virtual ICollection<Category> Categories { get; set; }


    }
}
