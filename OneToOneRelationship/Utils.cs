using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneToOneRelationship.Models;
using Microsoft.EntityFrameworkCore;

namespace OneToOneRelationship
{
    public static class Utils
    {
        public static void ShowTable()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var user in db.Users.Include(u => u.Profile).ToList())
                {
                    Console.WriteLine($"Name: {user.Profile?.Name}, Age: {user.Profile?.Age}");
                    Console.WriteLine($"Login: {user.Login}, Password: {user.Password}\n");
                }
            }
        }

        public static void CreateTable(List<User> users, List<UserProfile> userProfiles)
        {
            Console.WriteLine("\n=> CreateTable():\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.Users.AddRange(users);
                db.UserProfiles.AddRange(userProfiles);
                db.SaveChanges();
            }
        }

        public static void UpdateTable(string firstUserPassword, string login, string newName)
        {
            Console.WriteLine("\n=> UpdateTable():\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                User? user = db.Users.FirstOrDefault();

                if (user != null)
                {
                    user.Password = firstUserPassword;
                    db.SaveChanges();
                }

                UserProfile? userProfile = db.UserProfiles.FirstOrDefault(p => p.User.Login == login);

                if (userProfile != null)
                {
                    userProfile.Name = newName;
                    db.SaveChanges();
                }
            }
        }

        public static void DeletionExample(string login)
        {
            Console.WriteLine("\n=> DelitionExample():\n");

            using (ApplicationContext db = new ApplicationContext())
            {
                User? user = db.Users.FirstOrDefault();

                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }

                UserProfile? userProfile = db.UserProfiles.FirstOrDefault(p => p.User.Login == login);

                if (userProfile != null)
                {
                    db.UserProfiles.Remove(userProfile);
                    db.SaveChanges();
                }
            }
        }
    }
}
