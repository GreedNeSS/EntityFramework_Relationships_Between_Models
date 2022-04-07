using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Many_To_ManyRelationship_CreateIntermediateTable.Models;
using Microsoft.EntityFrameworkCore;

namespace Many_To_ManyRelationship_CreateIntermediateTable
{
    public static class Utils
    {
        public static void ShowTable()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var c in db.Courses.Include(c => c.Students).ToList())
                {
                    Console.WriteLine($"\nCourse: {c.Name}\n");

                    foreach (var student in c.Students)
                        Console.WriteLine($"Student: {student.Name}\n");

                    Console.WriteLine("-------------------");
                }
            }
        }

        public static void CreateTable(List<Student> students, List<Course> courses)
        {
            Console.WriteLine("\n=> CreateTable():\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.Students.AddRange(students);
                db.Courses.AddRange(courses);
                db.SaveChanges();
            }
        }

        public static void UpdateTable(string studentName, string oldCourseName, string newCourseName)
        {
            Console.WriteLine("\n=> UpdateTable():\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                Student? student = db.Students.Include(s => s.Courses).FirstOrDefault(s => s.Name == studentName);
                Course? oldCourse = db.Courses.FirstOrDefault(c => c.Name == oldCourseName);
                Course? newCourse = db.Courses.FirstOrDefault(c => c.Name == newCourseName);

                if (student != null && oldCourse != null && newCourse != null)
                {
                    student.Courses.Remove(oldCourse);
                    student.Courses.Add(newCourse);
                    db.SaveChanges();
                }
            }
        }

        public static void DeletionExample(string studentName, string courseName)
        {
            Console.WriteLine("\n=> DeletionExample():\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                Student? student = db.Students.FirstOrDefault(s => s.Name == studentName);

                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }

                Course? course = db.Courses.FirstOrDefault(c => c.Name == courseName);

                if (course != null)
                {
                    db.Courses.Remove(course);
                    db.SaveChanges();
                }
            }
        }
    }
}
