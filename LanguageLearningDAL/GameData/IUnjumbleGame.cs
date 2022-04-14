using LanguageLearning.UserClasses;
using LanguageLearning.WordClasses;

namespace Data.GameData
{
    public interface IUnjumbleGame
    {
        public Word InitialWord { get; set; }
        public List<string> Guesses { get; set; }
        int CalculateScore(int gameid);
        public string JumbledLetters { get; set; }
        public User user { get; set; }
    }
}