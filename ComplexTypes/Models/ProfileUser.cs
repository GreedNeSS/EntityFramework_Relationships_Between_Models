using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ComplexTypes.Models
{
    [Owned]
    public class ProfileUser
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
