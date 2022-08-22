using flightModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace sqlServer
{
    public class ContosoPetsContext : DbContext
    {
        //private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=conto";

        public DbSet<user> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=conto;Integrated Security = SSPI");
        }

    }
}

