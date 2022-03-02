using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageLearning.MockDB;

namespace LanguageLearning
{
    class UserManager
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
    }
}
