using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Sber1.Models
{
    class DbCont : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=testdb;Trusted_Connection=True;");
        }

        public DbSet<Auto> auto { get; set; }

        public DbSet<Seller> seller { get; set; }
    }
}
