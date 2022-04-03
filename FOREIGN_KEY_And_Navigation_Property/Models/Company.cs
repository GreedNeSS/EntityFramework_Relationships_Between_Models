using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOREIGN_KEY_And_Navigation_Property.Models
{
    internal class Company
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
