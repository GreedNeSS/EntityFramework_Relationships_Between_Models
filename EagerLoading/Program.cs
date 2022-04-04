using EagerLoading;
using EagerLoading.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("***** Eager Loading *****");


using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    Position manager = new Position { Name = "Manager" };
    Position developer = new Position { Name = "Developer" };
    db.Positions.AddRange(manager, developer);

    City moscow = new City { Name = "Moscow"};
    City washington = new City { Name = "Washington"};
    db.Cities.AddRange(moscow, washington);

    Country russia = new Country { Name = "Russia", Capital = moscow };
    Country usa = new Country { Name = "USA", Capital = washington };
    db.Countries.AddRange(russia, usa);

    Company microsoft = new Company { Name = "Microsoft", Country = usa };
    Company google = new Company { Name = "Google", Country = usa };
    Company yandex = new Company { Name = "Yandex", Country = russia };
    db.Companies.AddRange(microsoft, google, yandex);

    User tom = new User { Name = "Tom", Company = microsoft, Position = developer };
    User bob = new User { Name = "Bob", Company = google, Position = developer };
    User alice = new User { Name = "Alice", Company = microsoft, Position = manager };
    User kate = new User { Name = "Kate", Company = google, Position = manager };
    User ruslan = new User { Name = "Ruslan", Company = yandex, Position = developer };
    User marcus = new User { Name = "Marcus", Company = yandex, Position = developer };
    db.Users.AddRange(tom, bob, alice, kate, ruslan, marcus);
    db.SaveChanges();
}
using (ApplicationContext db = new ApplicationContext())
{
    var users = db.Users
                .Include(u => u.Company)
                    .ThenInclude(comp => comp!.Country)
                        .ThenInclude(c => c!.Capital)
                .Include(c => c.Position)
                .ToList();
    foreach (var user in users)
    { 
        Console.WriteLine($"{user.Name} - {user.Position?.Name}");
        Console.WriteLine($"{user.Company?.Name} - {user.Company?.Country?.Name} - {user.Company?.Country?.Capital?.Name}");
        Console.WriteLine("__________________________");
    }
}
