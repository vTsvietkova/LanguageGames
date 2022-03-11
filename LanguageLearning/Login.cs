using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning
{
    public class Login
    {
        public Login()
        {
        }

        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required, RegularExpression(@"^\w*$")]
        public string Username { get; set; }
        [Required, RegularExpression(@"^\w*$")]
        public string Password { get; set; }
    }
}
