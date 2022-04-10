using Data.WordData;
using LanguageLearning.WordClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningLogic
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

        public int Create(Word word)
        {
            ValidationContext context = new(word);
            List<ValidationResult> errors = new();
            int id = 0;
            if (!Validator.TryValidateObject(word, context, errors))
            {
                throw new Exception(errors.ToString());
            }
            else
            {
                id = DAL.CreateWord(word);
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
            return id;
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
            if (word is not null && word.Definitions is not null && word.Definitions.Count != 0)
            {
                word.Definitions.Sort();
            }

            return word;
        }

        public List<Word> GetAll()
        {
            return DAL.GetAll();
        }

        public void AddDefinition(Definition definition, Word word)
        {
            ValidationContext context = new(definition);
            List<ValidationResult> errors = new();

            if (!Validator.TryValidateObject(definition, context, errors))
            {
                throw new Exception(errors.ToString());
            }
            else
            {
                DAL.CreateDefinition(definition, word);
            }
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
