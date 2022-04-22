using LanguageLearningLogic.DataInterfaces;
using LanguageLearningLogic.WordClasses;
using System.Text.RegularExpressions;

namespace LanguageLearningLogic.Games
{
    public class GameBase
    {
        protected readonly WordManager WordManager;
        public Word InitialWord { get; set; }
        public List<string> GetGuesses { get => Guesses; }
        protected List<string> Guesses { get; set; }
        public int Id { get => id; set => id=value; }

        private int id;

        public GameBase(WordManager wordManager)
        {
            WordManager = wordManager;
            InitialWord = wordManager.GetRandom(1);
        }
        public GameBase(Word word)
        {
            InitialWord = word;
            Guesses = new();
        }

        public GameBase(Word word, List<string> guesses)
        {
            InitialWord = word;
            Guesses = guesses;
        }

        public GameBase(Word word, WordManager manager)
        {
            InitialWord = word;
            WordManager = manager;
            Guesses = new();
        }

        public GameBase(Word word, List<string> guesses, WordManager manager)
        {
            InitialWord = word;
            Guesses = guesses;
            WordManager = manager;
        }

        public virtual bool AddAnswer(string guess)
        {
            string regex = @"^([@word]){0,@count}$";
            regex = regex.Replace("@word", InitialWord.WordString);
            regex = regex.Replace("@count", InitialWord.WordString.Length.ToString());
            if (!Regex.IsMatch(guess, regex))
            {
                return false;
            }
            if (!Guesses.Contains(guess))
            {
                Guesses.Add(guess);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual int CalculateScore()
        {
            return 0;
        }
    }
}