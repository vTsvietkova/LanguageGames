using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning.DAL
{
    public class MockUserDAL : IUserDAL
    {
        
        public void Create(User user)
        {
            ValidationContext context = new(user);
            List<ValidationResult> errors = new();

            if (!Validator.TryValidateObject(user, context, errors))
            {
                throw new Exception(errors.ToString());
            }
        }

        public void Delete(int id)
        {
        }

        public User Get(int id)
        {
            return new("User", 1, "24022022", "user@mail.com", 200, Role.User);
        }

        public List<User> GetAll()
        {
            List<User> users = new();
            users.Add(new("user", 1, "24022022", "user@mail.com", 200, Role.User));
            users.Add(new("admin", 2, "24022022", "admin@mail.com", 1995, Role.Administrator));
            users.Add(new("editor", 3, "24022022", "editor@mail.com", 250, Role.Editor));
            users.Add(new("seriousPlayer", 4, "24022022", "sp@mail.com", 1000, Role.User));
            return users;
        }

        public int Login(string username, string password)
        {
            return 1;
        }

        public void Update(User user)
        {
            ValidationContext context = new(user);
            List<ValidationResult> errors = new();

            if (!Validator.TryValidateObject(user, context, errors))
            {
                throw new Exception(errors.ToString());
            }
        }
    }
}
