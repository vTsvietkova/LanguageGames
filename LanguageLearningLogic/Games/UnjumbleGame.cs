using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medallion;
using LanguageLearning.WordClasses;

namespace LanguageLearningLogic.Games
{
    class UnjumbleGame : IGame
    {
        private WordManager WordManager = new();
        public Word InitialWord { get; set; }
        public List<string> Guesses { get; set; }
        public virtual int CalculateScore(int gameid)
        {
            int correctAnswer = -1;
            //Check answers
            //Find out on which try the correct answer was found
            for (int i = 0; i < Guesses.Count; i++)
            {
                if (Guesses[i] == InitialWord.WordString)
                {
                    correctAnswer = i;
                    break;
                }
            }
            //TODO
            //put into the word class once done
            //How many possible answers are there?
            int maxGuesses = 0;
            //Find number of all possible combinations of letters
            maxGuesses = Enumerable.Range(1, InitialWord.WordString.Length).Aggregate(1, (p, item) => p * item);
            //Get score based on how long it took you to arrive to the right answer

            if (correctAnswer == -1)
            {//you didn't
                return 0;
            }
            else if (correctAnswer == (0|1|2))
            {//in three or less tries, good job
                return 100;
            }
            else if (InitialWord.WordString.Length <= 3 && correctAnswer > 3)
            {//simple word, took your time to get there
                return 40;
            }
            else if (correctAnswer < maxGuesses / 4 * 3)
            {//your time substracted from your score
                return 100 - 100 * correctAnswer / maxGuesses;
            }
            else
            {// this is intended to reward you for ppersistance, may adjust values later 
                return correctAnswer / maxGuesses;
            }
        }

        public UnjumbleGame()
        {
            InitialWord = WordManager.GetRandom(1);
            Guesses = new();
        }

        public UnjumbleGame(Word word)
        {
            InitialWord = word;
            Guesses = new();
        }

        public UnjumbleGame(Word word, List<string> guesses)
        {
            InitialWord = word;
            Guesses = guesses;
        }

        public void LoadGame(int gameid)
        {

        }

        public void SaveGame(int gameid)
        {

        }

        public static char[] GetCharacters(string word)
        {
            return word.ToArray();
        }
        public static char[] Jumble(char[] letters)
        {
            return letters.Shuffled().ToArray();
        }
        public static char[] Jumble(string word)
        {
            return word.ToArray().Shuffled().ToArray();
        }
    }
}
