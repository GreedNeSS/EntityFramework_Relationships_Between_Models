using Many_To_ManyRelationship_CreateIntermediateTable;
using Many_To_ManyRelationship_CreateIntermediateTable.Models;

Console.WriteLine("***** Many To ManyRelationship CreateIntermediateTable *****");

List<Student> students = new List<Student>();
students.Add(new Student { Name = "Marcus" });
students.Add(new Student { Name = "Alice" });
students.Add(new Student { Name = "Tom" });

List<Course> courses = new List<Course>();
courses.Add(new Course { Name = "CLR" });
courses.Add(new Course { Name = "Patterns" });

courses[1].Students.Add(students[0]);
courses[0].Students.Add(students[2]);
students[1].Enrollments.Add(new Enrollment { Course = courses[1] });
students[0].Enrollments.Add(new Enrollment { Course = courses[0] });

Utils.CreateTable(students, courses);
Utils.ShowTable();
Utils.UpdateTable("Alice", "Patterns", "CLR");
Utils.ShowTable();
Utils.DeletionExample("Tom", "CLR");
Utils.ShowTable();