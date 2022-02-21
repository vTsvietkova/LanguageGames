using System;
using System.Collections.Generic;

namespace LanguageLearning
{
    public class Word
    {
        private string word;
        private int id;
        private int nrOfHits;

        public Word()
        {
        }

        public Word(string wordString)
        {
            WordString = wordString;
        }

        public Word(string word, int id, int nrOfHits)
        {
            this.WordString = word;
            this.Id = id;
            this.NrOfHits = nrOfHits;
        }

        public string WordString { get => word; set => word = value; }
        public int Id { get => id; set => id = value; }
        public int NrOfHits { get => nrOfHits; set => nrOfHits = value; }
        public List<Definition> Definitions { get; set; }

        public string Conjugate()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
