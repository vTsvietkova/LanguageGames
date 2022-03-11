using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning.DAL
{
    interface IGameDAL
    {
        public abstract void Save(IGame game);
        public abstract void Delete(int id);
        public abstract IGame Load(int id);
    }
}
