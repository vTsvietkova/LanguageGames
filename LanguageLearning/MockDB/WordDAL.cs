using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning.MockDB
{
    class WordDAL : DALInterface
    {
        void DALInterface.Create(object o)
        {
            ValidationContext context = new((Word)o);
            List<ValidationResult> errors = new();

            if(!Validator.TryValidateObject(((Word)o), context, errors))
            {
                throw new Exception(errors.ToString());
            }
        }

        void DALInterface.Delete(int id)
        {
            
        }

        object DALInterface.Get(int id)
        {
            Word word = new Word("Dinosaur", id, 50);
            word.Definitions.Add(new Definition(1, "an ancient animal", 10, PartOfSpeach.noun));
            return word;
        }

        List<object> DALInterface.GetAll()
        {
            throw new NotImplementedException();
        }

        void DALInterface.Update(object o)
        {
            throw new NotImplementedException();
        }
    }
}
