using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageLearning.MockDB;

namespace LanguageLearning
{
    public class WordManager
    {
        IWordDAL DAL;

        public WordManager()
        {
            IWordDAL DAL = new WordDAL();
        }

        public WordManager(IWordDAL dAL)
        {
            DAL = dAL;
        }

        public void Create(Word word)
        {
            DAL.Create(word);
        }

        public void Delete(int id)
        {
            DAL.Delete(id);
        }

        public Word Get(int id)
        {
            Word word = DAL.Get(id);
            word.Definitions.Sort();
            return word;
        }

        public List<Word> GetAll()
        {
            return DAL.GetAll();
        }

        public void Update(Word word)
        {
            DAL.Update(word);
        }

        public Word GetRandom()
        {
            int randomId = 2;
            return Get(randomId);
        }
    }
}
