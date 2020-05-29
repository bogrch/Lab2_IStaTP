using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_IStaTP.Models
{
    public class Country
    {
        public Country()
        {
            Tours = new List<Tour>();
        }
        public int CountryID { get; set; }
        public string CountryNaming { get; set; }

        public string Climate { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }

    }
}
