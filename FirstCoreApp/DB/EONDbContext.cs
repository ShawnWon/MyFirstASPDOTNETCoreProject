using FirstCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace FirstCoreApp.DB
{
    public class EONDbContext : DbContext
    {
        public EONDbContext(DbContextOptions<EONDbContext> options) : base(options)
        { }

        public EONDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-MBSGJ0P; Database=EONtestCore;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
        
        }
        public DbSet<Users> users { get; set; }
        public DbSet<CheckboxModel> boxes { get; set; }

    }
}