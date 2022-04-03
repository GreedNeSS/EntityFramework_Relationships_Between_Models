using Foreign_Key_Setup;
using Foreign_Key_Setup.Models;

Console.WriteLine("***** Foreign Key Setup *****");

using (ApplicationContext db = new ApplicationContext())
{
    Company microsoft = new Company { Title = "Microsoft" };
    Company apple = new Company { Title = "Apple" };
    db.Companies.AddRange(microsoft, apple);
    db.SaveChanges();

    db.Users.AddRange(new User { Name = "Ruslan", Company = microsoft },
        new User { Name = "Marcus", CompanyTitle = "Microsoft" },
        new User { Name = "Henry", CompanyTitle = apple.Title });
    db.SaveChanges();

    List<User> users = db.Users.ToList();

    foreach (var user in users)
    {
        Console.WriteLine($"Пользователь {user.Name} работает в {user?.Company?.Title}");
    }
}