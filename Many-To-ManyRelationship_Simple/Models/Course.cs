using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many_To_ManyRelationship_Simple.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Student> Students { get; set; } = new();
    }
}
