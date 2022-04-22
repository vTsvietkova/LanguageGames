using System.ComponentModel.DataAnnotations;

namespace LanguageLearningLogic.UserClasses
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

        [Required, RegularExpression(@"^[\w\.@]+$")]
        public string Username { get; set; }
        [Required, RegularExpression(@"^\w*$")]
        public string Password { get; set; }
    }
}
