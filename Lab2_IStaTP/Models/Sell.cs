using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_IStaTP.Models
{
    public class Sell
    {
        public int SellID { get; set; }
        public int TourID { get; set; }
        public int EmployeeID { get; set; }
        public int ClientID { get; set; }
        public string SellInfo { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
    

    }
}
