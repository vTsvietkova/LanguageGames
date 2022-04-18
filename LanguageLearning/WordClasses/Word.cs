using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LanguageLearning.WordClasses
{
    public class Word
    {
        private string word;
        private int id;
        private int nrOfHits;

        public Word()
        {
            Definitions = new();
        }

        public Word(string wordString)
        {
            WordString = wordString;
            Definitions = new();
        }

        public Word(string word, int id) : this(word)
        {
            this.id = id;
            Definitions = new();
        }

        public Word(string word, int id, int nrOfHits)
        {
            WordString = word;
            Id = id;
            NrOfHits = nrOfHits;
            Definitions = new();
        }
        [Required]
        public string WordString { get => word; set => word = value; }
        public int Id { get => id; set => id = value; }
        public int NrOfHits { get => nrOfHits; set => nrOfHits = value; }
        public List<Definition> Definitions { get; set; }

        /*public PartOfSpeach PartOfSpeach
        {
            get
            {
                PartOfSpeach partOfSpeach = 0;
                foreach (Definition def in Definitions)
                {
                    partOfSpeach = partOfSpeach | def.PartOfSpeach;
                }
                return partOfSpeach;
            }
        }*/
        public string PartsOfSpeach
        {
            get
            {
                PartOfSpeach partOfSpeach = 0;
                foreach (Definition def in Definitions)
                {
                    partOfSpeach = partOfSpeach | def.PartOfSpeach;
                }
                if (partOfSpeach == (PartOfSpeach)3)
                {
                    return "noun, verb";
                }
                else if (partOfSpeach == (PartOfSpeach)5)
                {
                    return "noun, adjective";
                }
                else if (partOfSpeach == (PartOfSpeach)6)
                {
                    return "adjective, verb";
                }
                else if (partOfSpeach == (PartOfSpeach)7)
                {
                    return "noun, adjective, verb";
                }
                return partOfSpeach.ToString();
            }
        }
        public Definition MostPopularDefinition
        {
            get
            {
                if (Definitions == null || Definitions.Count == 0)
                {
                    return null;
                }
                Definition definition = Definitions[0];
                if (Definitions.Count > 1)
                {
                    if (Definitions.Count == 2)
                    {
                        definition = Definitions[0].Votes >= Definitions[1].Votes ? definition : Definitions[1];
                    }
                    else
                    {
                        Definitions.Sort();
                        definition = Definitions[0];
                    }
                }
                if (definition.Votes < -2)
                {
                    definition = new("this word doesn't have a popular definition");
                }
                return definition;
            }
        }

        public override string ToString()
        {
            return word;
        }
    }
}
