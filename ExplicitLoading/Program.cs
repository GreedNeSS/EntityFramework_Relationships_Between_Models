using ExplicitLoading;
using ExplicitLoading.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("***** Explicit Loading *****");

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    Company microsoft = new Company { Title = "Microsoft" };
    Company apple = new Company { Title = "Apple" };
    db.Companies.AddRange(microsoft, apple);
    db.Users.AddRange(new User { Name = "GreedNeSS", Company = microsoft },
        new User { Name = "Marcus", Company = microsoft },
        new User { Name = "Henry", Company = apple });
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\n=>  db.Users.Where(u => u.CompanyId == company.Id).Load()");

    Company? company = db.Companies.FirstOrDefault();

    if (company is not null)
    {
        db.Users.Where(u => u.CompanyId == company.Id).Load();

        Console.WriteLine($"Company: {company.Title}");
        foreach (var user in company.Users)
            Console.WriteLine(user);
    }
}

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\n=>  db.Entry(company).Collection(c => c.Users).Load()");

    Company? company = db.Companies.FirstOrDefault();

    if (company is not null)
    {
        db.Entry(company).Collection(c => c.Users).Load();

        Console.WriteLine($"Company: {company.Title}");
        foreach (var user in company.Users)
            Console.WriteLine(user);
    }
}

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\n=>  db.Entry(user).Reference(u => u.Company).Load();)");

    User? user = db.Users.FirstOrDefault();

    if (user is not null)
    {
        db.Entry(user).Reference(u => u.Company).Load();

        Console.WriteLine(user);
    }
}