using LanguageLearningLogic.WordClasses;
using System.ComponentModel.DataAnnotations;

namespace LanguageLearningLogic.UserClasses
{
    public class User
    {
        private int id;
        private string username;
        private string password;
        private string email;
        private int xp;

        public User() { }

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
            Role = role;
        }
        [Required, RegularExpression(@"^\w*$")]
        public string Username { get => username; set => username = value; }
        public int Id { get => id; set => id = value; }
        [Required, RegularExpression(@"^\w*$")]
        public string Password { get => password; set => password = value; }
        [Required]
        [RegularExpression(@"(^((\w+)(\.)?){1,4}@){1}(([a-z]+)\.)+(nl|com|fm|net)$", ErrorMessage = "Not a valid email")]
        public string Email { get => email; set => email = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Level
        {
            get
            {
                return Xp/200;
            }
        }
        public Role Role { get; set; }
    }
}
