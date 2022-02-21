using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning.MockDB
{
    public interface DALInterface
    {
        public abstract object Get(int id);
        public abstract List<object> GetAll();
        public abstract void Create(object o);
        public abstract void Delete(int id);
        public abstract void Update(object o);
    }
}
