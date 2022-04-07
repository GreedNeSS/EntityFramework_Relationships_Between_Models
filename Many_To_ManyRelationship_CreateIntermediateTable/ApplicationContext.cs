using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Many_To_ManyRelationship_CreateIntermediateTable.Models;

namespace Many_To_ManyRelationship_CreateIntermediateTable
{
    internal class ApplicationContext: DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=College.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity<Enrollment>(
                    j => j
                        .HasOne(pt => pt.Student)
                        .WithMany(t => t.Enrollments)
                        .HasForeignKey(pt => pt.StudentId),
                    j => j
                        .HasOne(pt => pt.Course)
                        .WithMany(p => p.Enrollments)
                        .HasForeignKey(pt => pt.CourseId),
                    j =>
                    {
                        j.Property(pt => pt.Mark).HasDefaultValue(3);
                        j.HasKey(t => new { t.StudentId, t.CourseId });
                        j.ToTable("Enrollments");
                    });
        }
    }
}
