using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearning
{
    class UnjumbleGame : IGame
    {
        public Word InitialWord { get; set; }
        public List<string> Answers { get; set; }
        public int CalculateScore(int gameid)
        {
            return Answers[0] == this.InitialWord.WordString ? 100 : 0;
        }

        public UnjumbleGame()
        {

        }

        public void LoadGame(int gameid)
        {
            throw new NotImplementedException();
        }

        public void SaveGame(int gameid)
        {
            throw new NotImplementedException();
        }

        public virtual char[] GetCharacters(string word) 
        {
            return word.ToArray();
        }
    }
}
