using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OneToOneRelationship.Models;

namespace OneToOneRelationship
{
    internal class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Accounts.db");
        }

        // Обьединение таблиц в БД

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasOne(u => u.Profile)
        //        .WithOne(p => p.User)
        //        .HasForeignKey<UserProfile>(p => p.Id);
        //    modelBuilder.Entity<UserProfile>().ToTable("Users");
        //    modelBuilder.Entity<User>().ToTable("Users");
        //}
    }
}
