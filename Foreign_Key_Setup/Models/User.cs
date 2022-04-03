using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreign_Key_Setup.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string CompanyTitle{ get; set; }
        public Company? Company { get; set; }
    }
}
