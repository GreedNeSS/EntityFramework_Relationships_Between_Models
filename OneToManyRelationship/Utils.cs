using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneToManyRelationship.Models;
using Microsoft.EntityFrameworkCore;

namespace OneToManyRelationship
{
    public static class Utils
    {
        public static void ShowTable()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\n*** Users Table ***\n");

                foreach (var user in db.Users.Include(u => u.Company).ToList())
                {
                    Console.WriteLine(user);
                }

                Console.WriteLine("\n*******************");

                Console.WriteLine("\n*** Company Table ***\n");

                foreach (var comp in db.Companies.Include(c => c.Users).ToList())
                {
                    Console.WriteLine(comp.Title + ":");

                    foreach (var user in comp.Users)
                    {
                        Console.WriteLine(user);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("**********************");
            }
        }

        public static void CreateTable(List<User> users, List<Company> companies)
        {
            Console.WriteLine("\n=> CreateTable():\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.Users.AddRange(users);
                db.Companies.AddRange(companies);
                db.SaveChanges();
            }
        }

        public static void UpdateTable(string companyName, string employeeName, string newName)
        {
            Console.WriteLine("\n=> UpdateTable():\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Companies.Include(c => c.Users).Load();
                Company? company = db.Companies.FirstOrDefault(c => c.Title == companyName);

                if (company != null)
                {
                    User? user = company.Users.FirstOrDefault(u => u.Name == employeeName);

                    if (user != null)
                    {
                        user.Name = newName;
                        db.SaveChanges();
                    }
                }
            }
        }

        public static void DeletionExample(string companyTitle, string employeeName)
        {
            Console.WriteLine("\n=> DeletionExample():\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                Company? company = db.Companies.FirstOrDefault(c => c.Title == companyTitle);

                if (company != null)
                {
                    db.Companies.Remove(company);
                    db.SaveChanges();
                }

                User? user = db.Users.FirstOrDefault(u => u.Name == employeeName);

                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }
    }
}
