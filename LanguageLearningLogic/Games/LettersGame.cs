using LanguageLearning.WordClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningLogic.Games
{
    public class LettersGame : UnjumbleGame
    {
        public LettersGame() : base()
        {
        }

        public LettersGame(Word word) : base(word)
        {
        }

        public LettersGame(Word word, List<string> guesses) : base(word, guesses)
        {
        }

        public override int CalculateScore()
        {
            return base.CalculateScore();
        }
    }
}
