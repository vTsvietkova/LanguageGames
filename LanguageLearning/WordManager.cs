using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            ValidationContext context = new(word);
            List<ValidationResult> errors = new();

            if (!Validator.TryValidateObject(word, context, errors))
            {
                throw new Exception(errors.ToString());
            }
            else
            {
                DAL.CreateWord(word);
            }
        }

        public void Delete(int id)
        {
            DAL.DeleteWord(id);
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
            ValidationContext context = new(word);
            List<ValidationResult> errors = new();

            if (!Validator.TryValidateObject(word, context, errors))
            {
                throw new Exception(errors.ToString());
            }
            else
            {
                DAL.UpdateWord(word);
            }
        }

        public Word GetRandom()
        {
            int randomId = 2;
            return Get(randomId);
        }
    }
}
