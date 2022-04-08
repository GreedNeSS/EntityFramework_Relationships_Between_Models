using ComplexTypes;
using ComplexTypes.Models;

Console.WriteLine("***** Complex Types *****");

User tom = new User("TOM100", "1234qwer", new ProfileUser { Name = "Tom", Age = 12}, new City { Name = "Rome"});
User alice = new User("Alicesss", "asdfqwer", new ProfileUser { Name = "Alice", Age = 19}, new City { Name = "Moscow"});

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureCreated();
    db.Users.AddRange(tom, alice);
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    var users = db.Users.ToList();

    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}