using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning.MockDB
{
    class UserDAL : IUserDAL
    {
        public User Get(int id)
        {
            User user = new User("tester", id, "12345678", "tester@mail.com", 70, Role.User);
            IWordDAL dal = new MockWordDAL();
            user.LearnedWords = dal.GetAll();
            return user;
        }

        public List<User> GetAll()
        {
            List<User> users = new();
            users.Add(new User("tester", 1, "12345678", "tester@mail.com", 70, Role.User));
            users.Add(new User("user", 2, "12345678", "user@mail.com", 60, Role.User));
            users.Add(new User("admin", 3, "12345678", "admin@mail.com", 0, Role.Administrator));
            return users;
        }

        public void Create(User user)
        {
            ValidationContext context = new(user);
            List<ValidationResult> errors = new();

            if (!Validator.TryValidateObject(user, context, errors))
            {
                throw new Exception(errors.ToString());
            }
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

        public void Delete(int id)
        {
            
        }
    }
}
