using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary
{
    public class User
    {
        public string Login { get; set; }
        private int passwordHashCode { get; set; }

        public User(string login, int hashcode)
        {
            Login = login;
            passwordHashCode = hashcode;
        }

        public bool IsPasswordCorrect(string password) =>
            password.GetHashCode() == passwordHashCode;

        public static Dictionary<string, User> CreateUsersFromArrays(string[] logins, int[] hashcodes) =>
            logins
                .Zip(hashcodes, (x, y) => (Login: x, Code: y))
                .ToDictionary(p => p.Login, x => new User(x.Login, x.Code));
    }
}
