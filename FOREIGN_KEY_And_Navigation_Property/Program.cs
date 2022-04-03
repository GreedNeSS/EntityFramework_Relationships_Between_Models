using FOREIGN_KEY_And_Navigation_Property;
using FOREIGN_KEY_And_Navigation_Property.Modeles;

Console.WriteLine("***** FOREIGN KEY And Navigation Property *****");

Console.WriteLine("\nПервый пример: ");

using (ApplicationContext db = new ApplicationContext())
{
    Company microsoft = new Company { Title = "Microsoft" };
    Company apple = new Company { Title = "Apple" };
    db.Companies.AddRange(microsoft, apple);
    db.SaveChanges();

    db.Users.AddRange(new User { Name = "Ruslan", Company = microsoft },
        new User { Name = "Marcus", Company = microsoft },
        new User { Name = "Henry", Company = apple });
    db.SaveChanges();

    List<Company> companies = db.Companies.ToList();
    foreach (var company in companies)
    {
        List<string>? names = company.Users?.Select(u => u?.Name ?? "Имя отсутствует").ToList<string>();

        if (names is not null)
        {
            Console.WriteLine($"\nCompany: {company.Title}, " +
            $"\nEmployee: {string.Join(", ", names)}");
        }
    }
}

Console.WriteLine("\nВторой пример: ");

using (ApplicationContext db = new ApplicationContext())
{
    User ruslan = new User { Name = "Ruslan" };
    User marcus = new User { Name = "Marcus" };
    User henry = new User { Name = "Henry" };

    Company yandex = new Company { Title = "Yandex", Users = { ruslan, marcus } };
    Company jetBrains = new Company { Title = "JetBrains", Users = { henry } };
    db.Companies.AddRange(yandex, jetBrains);
    db.Users.AddRange(ruslan, marcus, henry);
    db.SaveChanges();

    List<User> users = db.Users.ToList();
    foreach (var user in users)
    {
        Console.WriteLine($"\n{user.Name} работает в компании {user?.Company?.Title ?? "unknown"}");
    }
}