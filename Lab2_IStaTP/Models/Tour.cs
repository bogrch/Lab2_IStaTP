using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_IStaTP.Models
{
    public class Tour
    {
        public Tour()
        {
            Sells = new List<Sell>();
        }
        public int TourID { get; set; }
        public string TourNaming { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfFinish { get; set; }

        public int CountryID { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }


    }
}
