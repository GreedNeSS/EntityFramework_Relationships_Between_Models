using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOREIGN_KEY_And_Navigation_Property.Modeles
{
    internal class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
