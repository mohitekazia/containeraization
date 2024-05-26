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
    }
}
