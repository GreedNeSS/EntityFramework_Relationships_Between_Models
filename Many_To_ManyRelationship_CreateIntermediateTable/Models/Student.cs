using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many_To_ManyRelationship_CreateIntermediateTable.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Course> Courses { get; set; } = new();
        public List<Enrollment> Enrollments { get; set; } = new();
    }
}
