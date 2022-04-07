using Many_To_ManyRelationship_Simple;
using Many_To_ManyRelationship_Simple.Models;

Console.WriteLine("***** Many-To-Many Relationship *****");

List<Student> students = new List<Student>();
students.Add(new Student { Name = "Marcus" });
students.Add(new Student { Name = "Alice" });
students.Add(new Student { Name = "Tom" });

List<Course> courses = new List<Course>();
courses.Add(new Course { Name = "CLR" });
courses.Add(new Course { Name = "Patterns" });

courses[1].Students.Add(students[0]);
courses[1].Students.Add(students[1]);
courses[0].Students.Add(students[0]);
courses[0].Students.Add(students[2]);

Utils.CreateTable(students, courses);
Utils.ShowTable();
Utils.UpdateTable("Alice", "Patterns", "CLR");
Utils.ShowTable();
Utils.DeletionExample("Tom", "CLR");
Utils.ShowTable();