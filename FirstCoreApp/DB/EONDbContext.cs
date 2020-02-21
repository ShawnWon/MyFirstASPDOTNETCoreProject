using EONtestEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace EONtestEF.DB
{
    public class EONDbContext : DbContext
    {
        public EONDbContext(DbContextOptions<EONDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-MBSGJ0P; Database=EONtestCore;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
        
        }
        public DbSet<Users> users { get; set; }

    }
}