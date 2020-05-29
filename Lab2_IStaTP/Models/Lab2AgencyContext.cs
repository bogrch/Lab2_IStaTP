using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Lab2_IStaTP.Models
{
    public class Lab2AgencyContext : DbContext
    {
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Client> Clients {get; set;}
        public virtual DbSet<Employee> Employees {get; set;}
        public virtual DbSet<Sell> Sells {get; set;}
        public virtual DbSet<Country> Countries {get; set;}

        public Lab2AgencyContext(DbContextOptions<Lab2AgencyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
