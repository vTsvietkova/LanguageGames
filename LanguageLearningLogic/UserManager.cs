using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.UserData;
using LanguageLearning.UserClasses;

namespace LanguageLearningLogic
{
    public class UserManager
    {
        private readonly IUserDAL DAL;

        public UserManager(IUserDAL dAL)
        {
            DAL = dAL;
        }

        public int Login(Login login)
        {
            int id = 0;
            ValidationContext context = new(login);
            List<ValidationResult> errors = new();
            if (!Validator.TryValidateObject(login, context, errors))
            {
                throw new Exception(errors.ToString());
            }
            else
            {
                id = DAL.Login(login.Username, login.Password);
            }
            return id;
        }

        public void Create(User user)
        {
            ValidationContext context = new(user);
            List<ValidationResult> errors = new();
            if (!Validator.TryValidateObject(user, context, errors))
            {
                throw new Exception(errors.ToString());
            }
            else
            {
                DAL.Create(user);
            }
        }

        public User Get(int id) => DAL.Get(id);

        public List<User> GetAll() => DAL.GetAll();

        public void Update(User user)
        {
            if(DAL.CanBeRenamed(user))
            {
                DAL.Update(user);
            }
        } 

        public void Delete(int id)
        {
            DAL.Delete(id);
        }
    }
}
