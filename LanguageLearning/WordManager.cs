using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageLearning.DAL;

namespace LanguageLearning
{
    public class WordManager
    {
        IWordDAL DAL = new WordDAL();

        public WordManager()
        {
            
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
                DAL = new WordDAL();
                DAL.CreateWord(word);
                foreach (Definition def in word.Definitions)
                {
                    context = new(def);
                    if (!Validator.TryValidateObject(def, context, errors))
                    {
                        throw new Exception(errors.ToString());
                    }
                    else
                    {
                        DAL.CreateDefinition(def, word);
                    }
                }
            }
        }

        public void DeleteWord(int id)
        {
            DAL.DeleteWord(id);
        }

        public void DeleteDefinition(int id)
        {
            DAL.DeleteDefinition(id);
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

        public void AddDefinition(Definition definition, Word word)
        {
            DAL.CreateDefinition(definition, word);
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

        public void UpdateDefinition(Definition definition)
        {
            ValidationContext context = new(definition);
            List<ValidationResult> errors = new();

            if (!Validator.TryValidateObject(definition, context, errors))
            {
                throw new Exception(errors.ToString());
            }
            else
            {
                DAL.UpdateDefinition(definition);
            }
        }

        public Word GetRandom(int quantity)
        {
            return DAL.GetRandom(quantity);
        }
    }
}
