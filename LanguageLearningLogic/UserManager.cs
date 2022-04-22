using System.ComponentModel.DataAnnotations;
using LanguageLearningLogic.DataInterfaces;
using LanguageLearningLogic.UserClasses;

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
                if(DAL.IsGoodPassword(user.Password) && !DAL.CrededentialsTaken(user))
                {
                    DAL.Create(user);
                }
            }
        }

        public User Get(int id) => DAL.Get(id);

        public List<User> GetAll() => DAL.GetAll();

        public void Update(User user)
        {
            if(DAL.CanBeRenamed(user))
            {
                if(!DAL.CrededentialsTaken(user))
                {
                    DAL.Update(user);
                }
                if(!string.IsNullOrWhiteSpace(user.Password))
                {
                    DAL.ChangePassword(user);
                }
            }
        }

        public List<User> GetAllMatchingSearch(string search)
        {
            var words = DAL.GetAll();
            if (!String.IsNullOrEmpty(search))
            {
                words = words.Where(s => s.Username!.Contains(search)).ToList();
            }
            return words;
        }

        public void Delete(int id)
        {
            DAL.Delete(id);
        }
    }
}
