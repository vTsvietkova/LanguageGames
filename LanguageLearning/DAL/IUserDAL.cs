﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning.DAL
{
    public interface IUserDAL
    {
        public abstract void Create(User user);
        public abstract void Delete(int id);
        public abstract User Get(int id);
        public abstract List<User> GetAll();
        public abstract void Update(User user);
        public abstract int Login(string username, string password); 
    }
}
