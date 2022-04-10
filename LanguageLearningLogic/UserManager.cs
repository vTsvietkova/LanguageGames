using System;
using System.Collections.Generic;
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
        private IUserDAL DAL;

        public UserManager()
        {
            DAL = new UserDAL();
        }

        public UserManager(IUserDAL dAL)
        {
            DAL = dAL;
        }

        public int Login(User user)
        {
            return DAL.Login(user.Username, user.Password);
        }

        public int Login(Login login)
        {
            return DAL.Login(login.Username, login.Password);
        }

        public void Create(User user)
        {
            DAL.Create(user);
        }

        public User Get(int id)
        {
            return DAL.Get(id);
        }

        public List<User> GetAll() => DAL.GetAll();

        public void Update(User user) => DAL.Update(user);

        public void Delete(int id)
        {
            DAL.Delete(id);
        }
    }
}
