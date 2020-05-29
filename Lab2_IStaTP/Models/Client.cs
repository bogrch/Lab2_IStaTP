using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_IStaTP.Models
{
    public class Client
    {
        public Client()
        {
            Sells = new List<Sell>();
        }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public DateTime DateOfRegistration { get; set; }
        
        public virtual ICollection<Sell> Sells { get; set; }
    }
}
