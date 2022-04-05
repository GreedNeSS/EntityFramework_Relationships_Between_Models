using LazyLoading;
using LazyLoading.Models;

Console.WriteLine("***** Lazy Loading *****");

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    Company microsoft = new Company { Title = "Microsoft" };
    Company apple = new Company { Title = "Apple" };
    db.Companies.AddRange(microsoft, apple);
    db.Users.AddRange(new User { Name = "GreedNeSS", Company = microsoft },
        new User { Name = "Marcus", Company = microsoft },
        new User { Name = "Terry", Company = microsoft },
        new User { Name = "Bob", Company = apple },
        new User { Name = "Henry", Company = apple });
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\n=>  db.Users.ToList()");

    var users = db.Users.ToList();

    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\n=>  db.Companies.ToList()");

    var companies = db.Companies.ToList();

    foreach (var company in companies)
    {
        Console.WriteLine($"\nCompany: {company.Title}");

        foreach (var user in company.Users)
        {
            Console.WriteLine(user);
        }

        Console.WriteLine();
    }
}