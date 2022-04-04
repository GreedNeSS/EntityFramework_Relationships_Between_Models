using CascadeDelete;
using CascadeDelete.Models;

Console.WriteLine("***** Cascade Delete *****");

using (ApplicationContext db = new ApplicationContext())
{
    Company company1 = new Company { Title = "Microsoft" };
    Company company2 = new Company { Title = "Apple" };
    db.Companies.Add(company1);
    db.Companies.Add(company2);
    db.Users.Add(new User { Name = "Ruslan", Company = company1 });
    db.Users.Add(new User { Name = "Marcus", CompanyId = 1});
    db.Users.Add(new User { Name = "Bob", CompanyId = 2});
    db.Users.Add(new User { Name = "Terry", Company = company2});
    db.SaveChanges();

    List<User> users = db.Users.ToList();
    ShowUserList(users);

    var comp = db.Companies.FirstOrDefault();

    if (comp != null)
        db.Companies.Remove(comp);

    db.SaveChanges();

    Console.WriteLine("\nСписок пользователей после удаления.");

    users = db.Users.ToList();
    ShowUserList(users);
}

void ShowUserList(List<User> users)
{
    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}