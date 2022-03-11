using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageLearning.DAL;

namespace LanguageLearning
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

        public List<User> GetAll()
        {
            return DAL.GetAll();
        }

        public void Update(User user)
        {
            DAL.Update(user);
        }

        public void Delete(int id)
        {
            DAL.Delete(id);
        }
    }
}
