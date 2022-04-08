using HierarchicalData;

Console.WriteLine("***** Hierarchical Data *****");

using (ApplicationContext db = new ApplicationContext())
{
    MenuItem file = new MenuItem { Title = "File" };
    MenuItem edit = new MenuItem { Title = "Edit" };
    
    MenuItem open = new MenuItem { Title = "Open", Parent = file };
    MenuItem save = new MenuItem { Title = "Save", Parent = file };
    
    MenuItem copy = new MenuItem { Title = "Copy", Parent = edit };
    MenuItem paste = new MenuItem { Title = "Paste", Parent = edit };

    db.MenuItems.AddRange(file, edit, open, save, copy, paste);
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\n=> All items:");

    foreach (var item in db.MenuItems.ToList())
    {
        Console.WriteLine(item.Title);
    }

    var file = db.MenuItems.FirstOrDefault(i => i.Title == "File");
    var edit = db.MenuItems.FirstOrDefault(i => i.Title == "Edit");

    ShowChildren(file);
    ShowChildren(edit);
}

void ShowChildren(MenuItem? item)
{
    if (item is not null)
    {
        Console.WriteLine($"\n=>{item?.Title}:");

        foreach (var i in item.Chidren)
        {
            Console.WriteLine($"- {i.Title}");
        }
    }
}