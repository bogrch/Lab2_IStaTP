using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_IStaTP.Models
{
    public class Employee
    {
        public Employee()
        {
            Sells = new List<Sell>();
        }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }
    }
}
