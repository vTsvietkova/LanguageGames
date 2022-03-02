using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning
{
    public class User
    {
        private int id;
        private string username;
        private string password;
        private string email;
        private int xp;

        public User(){}

        public User(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public User(string username, int id, string password, string email, int xp, Role role)
        {
            this.username = username;
            this.id = id;
            this.password = password;
            this.email = email;
            this.xp = xp;
            this.Role = role;
        }
        [Required, RegularExpression(@"^\w*$")]
        public string Username { get => username; set => username = value; }
        public int Id { get => id; set => id = value; }
        [Required, RegularExpression(@"^\w*$")]
        public string Password { get => password; set => password = value; }
        [Required, RegularExpression(@"^(\w+)@(gmail.com|email.com|student.fontys.nl|ua.fm)$")]
        public string Email { get => email; set => email = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Level { get
            {
                return 0;
            }
        }
        public List<Word> LearnedWords { get; set; }

        public Role Role { get; set; }
    }
}
