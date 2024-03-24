using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.DataModel
{
    public class User
    {
        public static List<User> users = new();


        public string? Name { get; set; }
        public string? Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public User()

        {
            Name = string.Empty;
            Username = string.Empty;
            PasswordHash = string.Empty;
            PasswordSalt = string.Empty;
        }
    }
}
