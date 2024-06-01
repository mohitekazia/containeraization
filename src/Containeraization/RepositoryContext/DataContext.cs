using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace RepositoryContext
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(new Company { 
            Name="Regal",
            Id =1
            }, new Company {

            Name = "Hatil",
            Id = 2
            },new Company {

            Name = "Pertex",
            Id = 3
            });
        }
        
    }
}
