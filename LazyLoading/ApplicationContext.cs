using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LazyLoading.Models;

namespace LazyLoading
{
    internal class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=Employee.db");
        }
    }
}
