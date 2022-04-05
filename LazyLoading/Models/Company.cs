using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
