using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Viventium.Data.DbContext.Models;

namespace Viventium.Data.DbContext
{
    public class CompanyDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //public DbSet<CompanyHeader> CompanyHeaders { get; set; }
        //-- This requirement is unclear--does this need to be stored in the database?
        //-- I elected not to.
        //-- If so, since the only difference is a one-to-many table,
        //-- why not just use this as an API model?
        //-- Navigation properties aren't populated on initial pull, so there is no real difference
        //-- until it is returned to the client.
        //--

        public DbSet<Company> Companies { get; set; }
        public DbSet<EmployeeHeader> EmployeeHeaders { get; set; }

        
        public required string DbPath { get; set; }
        
        public CompanyDbContext()
        {
            DbPath = "Viventium.sqlite";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Perhaps I'm misunderstanding the instructions for this table's inheritance structure.
            //If so, I'd configure it here to map to the other table.

            //modelBuilder.Entity<Company>(i =>
            //{
            //    i.ToTable("CompanyHeaders");
            //});


        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
