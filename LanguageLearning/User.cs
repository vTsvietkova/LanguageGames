using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning
{
    class User
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

        public User(string username, int id, string password, string email, int xp)
        {
            this.username = username;
            this.id = id;
            this.password = password;
            this.email = email;
            this.xp = xp;
        }

        public string Username { get => username; set => username = value; }
        public int Id { get => id; set => id = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Level { get
            {
                return 0;
            }
        }
    }
}
