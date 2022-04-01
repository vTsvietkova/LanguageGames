using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageLearning.Validators;

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
        [Required, RegularExpression(@"^\w*$"), UniqueUsernameOrEmail]
        public string Username { get => username; set => username = value; }
        public int Id { get => id; set => id = value; }
        [Required, RegularExpression(@"^\w*$"), GoodPassword]
        public string Password { get => password; set => password = value; }
        [Required, UniqueUsernameOrEmail]
        [RegularExpression(@"(^((\w+)(\.)?){1,4}@){1}(([a-z]+)\.)+(nl|com|fm|net)$", ErrorMessage = "Not a valid email")]
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
