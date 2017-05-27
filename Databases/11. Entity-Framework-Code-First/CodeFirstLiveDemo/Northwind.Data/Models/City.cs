using System.Collections.Generic;

namespace Northwind.Data.Models
{
    public class City
    {
        public City()
        {
            this.Teachers = new HashSet<Teacher>()
;        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
