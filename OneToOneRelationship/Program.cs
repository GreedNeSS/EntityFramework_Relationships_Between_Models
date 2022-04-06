using OneToOneRelationship;
using OneToOneRelationship.Models;

Console.WriteLine("***** One To One Relationship *****");

List<User> users = new List<User>();
users.Add(new User { Login = "GreedNeSS#122", Password = "vlernkre21" });
users.Add(new User { Login = "Marc#223", Password = "Rome123?" });
users.Add(new User { Login = "Pro100Nagibator", Password = "nagib228" });

List<UserProfile> userProfiles = new List<UserProfile>();
userProfiles.Add(new UserProfile { Name = "Ruslan", Age = 30, User = users[0] });
userProfiles.Add(new UserProfile { Name = "Marcus", Age = 45, User = users[1] });
userProfiles.Add(new UserProfile { Name = "Henry", Age = 22, User = users[2] });

Utils.CreateTable(users, userProfiles);
Utils.ShowTable();
Utils.UpdateTable("newPassword1234!", "Pro100Nagibator", "Hen");
Utils.ShowTable();
Utils.DeletionExample("Marc#223");
Utils.ShowTable();