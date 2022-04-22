using LanguageLearningLogic.UserClasses;

namespace LanguageLearningLogic.DataInterfaces
{
    public interface IUserDAL
    {
        void Create(User user);
        public abstract void Delete(int id);
        public abstract User Get(int id);
        public abstract List<User> GetAll();
        public abstract void Update(User user);
        public abstract int Login(string username, string password);
        public bool CanBeRenamed(User user);
        void ChangePassword(User user);
        void AddXPPoints(int id, int xp);
        bool CrededentialsTaken(User user);
        bool IsGoodPassword(string password);
    }
}
