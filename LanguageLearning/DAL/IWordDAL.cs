using System.Collections.Generic;

namespace LanguageLearning.MockDB
{
    public interface IWordDAL
    {
        public abstract void Create(Word word);
        public abstract void Delete(int id);
        public abstract Word Get(int id);
        public abstract List<Word> GetAll();
        public abstract void Update(Word word);
    }
}