using OneToManyRelationship;
using OneToManyRelationship.Models;

Console.WriteLine("***** One To Many Relationship *****");

List<Company> companies = new List<Company>();
companies.Add(new Company { Title = "Microsoft" });
companies.Add(new Company { Title = "Apple" });

List<User> users = new List<User>();
users.Add(new User { Name = "GreedNeSS", Company = companies[0] });
users.Add(new User { Name = "Henry", Company = companies[1] });
users.Add(new User { Name = "Marcus", Company = companies[0] });
users.Add(new User { Name = "Bob", Company = companies[1] });

Utils.CreateTable(users, companies);
Utils.ShowTable();
Utils.UpdateTable("Apple", "Bob", "Terry");
Utils.ShowTable();
Utils.DeletionExample("Apple", "Marcus");
Utils.ShowTable();