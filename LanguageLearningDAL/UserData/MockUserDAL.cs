using LanguageLearningLogic;
using LanguageLearningLogic.DataInterfaces;
using LanguageLearningLogic.UserClasses;
using System.ComponentModel.DataAnnotations;

namespace Data.UserData
{
    public class MockUserDAL : IUserDAL
    {
        public List<User> Users;

        public void AddXPPoints(int id, int xp)
        {
            User user = Get(id);
            if(user is not null)
            {
                user.Xp+=xp;
            }
        }

        public bool CanBeRenamed(User user)
        {
            foreach (User User in Users)
            {
                if(User.Username == user.Username || User.Email== user.Email)
                {
                    return false;
                }
            }
            return true;
        }

        public void ChangePassword(User user)
        {
            User User = Get(user.Id);
            if(User is not null)
            {
                User.Password = user.Password;
            }
        }

        public void Create(User user)
        {
            user.Id = Users.Last().Id;
            Users.Add(user);
        }

        public void Delete(int id)
        {
            if(Get(id) != null)
            {
                Users.Remove(Get(id));
            }
        }

        public User Get(int id)
        {
            foreach(User user in Users)
            {
                if(user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetAll()
        {

            if (Users is null)
            {
                User[] arrayOfUsers = new User[] { new("user", 1, "24022022", "user@mail.com", 200, Role.User),
                new("admin", 2, "24022022", "admin@mail.com", 1995, Role.Admin),
                new("editor", 3, "24022022", "editor@mail.com", 250, Role.Editor),
                new("seriousPlayer", 4, "24022022", "sp@mail.com", 1000, Role.User)};
                Users = new();
                Users.AddRange(arrayOfUsers);
            }
            return Users;
        }



        public int Login(string username, string password)
        {
            foreach (User item in Users)
            {
                if((item.Username==username || item.Email == username) && item.Password==password)
                {
                    return item.Id;
                }
            }
            return 0;
        }

        public void Update(User user)
        {
            User u = Get(user.Id);
            if(u != null)
            {
                u=user;
            }
        }
    }
}
