using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning
{
    public class Definition
    {
        private int id;
        private string definition;
        private int votes;
        private PartOfSpeach partOfSpeach;

        public Definition()
        {
        }

        public Definition(string definition)
        {
            this.definition = definition;
        }

        public Definition(int id, string definition, int votes, PartOfSpeach partOfSpeach)
        {
            this.id = id;
            this.definition = definition;
            this.votes = votes;
            this.partOfSpeach = partOfSpeach;
        }

        public int Id { get => id; set => id = value; }
        public string Defenition { get => definition; set => definition = value; }
        public int Votes { get => votes; set => votes = value; }
        internal PartOfSpeach PartOfSpeach { get => partOfSpeach; set => partOfSpeach = value; }
    }
}
