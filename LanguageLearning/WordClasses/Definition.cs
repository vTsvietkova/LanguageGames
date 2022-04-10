using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning.WordClasses
{
    public class Definition : IComparable
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

        public Definition(string definition, PartOfSpeach partOfSpeach)
        {
            this.definition = definition;
            votes = 0;
            this.partOfSpeach = partOfSpeach;
        }

        public int Id { get => id; set => id = value; }
        [Required, RegularExpression(@"^(\w+\s?)+$")]
        public string Def { get => definition; set => definition = value; }
        public int Votes { get => votes; set => votes = value; }
        public PartOfSpeach PartOfSpeach { get => partOfSpeach; set => partOfSpeach = value; }

        public int CompareTo(Definition definition)
        {
            if (partOfSpeach < definition.partOfSpeach)
            {
                return -1;
            }
            else if (partOfSpeach >= definition.partOfSpeach)
            {
                if (votes >= definition.votes)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }

            return 0;
        }

        public int CompareTo(object obj)
        {
            return CompareTo((Definition)obj);
        }

        public override string ToString()
        {
            return $"{id}-{definition}";
        }
    }
}
