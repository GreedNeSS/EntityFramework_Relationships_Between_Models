using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ComplexTypes.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        [Required]
        public ProfileUser? Profile { get; set; }
        private City? City { get; set; }

        public User()
        {

        }

        public User(string login, string password, ProfileUser profile, City city)
        {
            Login = login;
            Password = password;
            Profile = profile;
            City = city;
        }

        public override string ToString()
        {
            return $"Name: {Profile?.Name}, Age: {Profile?.Age}, Login: {Login}, Password: {Password}, City: {City?.Name}";
        }
    }
}
