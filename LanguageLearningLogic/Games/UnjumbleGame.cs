using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medallion;
using LanguageLearning.WordClasses;
using System.Text.RegularExpressions;

namespace LanguageLearningLogic.Games
{
    public class UnjumbleGame : IGame
    {
        private readonly WordManager WordManager = new();
        public Word InitialWord { get; set; }
        private List<string> Guesses { get; set; }
        public virtual int CalculateScore()
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
            //How many possible answers are there?
            int maxGuesses = 0;
            //Find number of all possible combinations of letters
            maxGuesses = Enumerable.Range(1, InitialWord.WordString.Length).Aggregate(1, (p, item) => p * item);
            //Get score based on how long it took you to arrive to the right answer

            if (correctAnswer == -1)
            {//you didn't
                return 0;
            }
            else if (correctAnswer == (0|1))
            {//in three or less tries, good job
                return 100;
            }
            else if (InitialWord.WordString.Length <= 3 && correctAnswer >= 3)
            {//simple word, took your time to get there
                return 40;
            }
            else if (correctAnswer < maxGuesses / 4 * 3)
            {//your time substracted from your score
                return 100 - 100 * correctAnswer / maxGuesses;
            }
            else
            {// this is intended to reward you for persistance, may adjust values later 
                return correctAnswer / maxGuesses;
            }
        }
        public virtual string? JumbledLetters { get; set; }

        public bool AddAnswer(string guess)
        {
            string regex = @"^([@word]){0,@count}$";
            regex = regex.Replace("@word", InitialWord.WordString);
            regex = regex.Replace("@count", InitialWord.WordString.Length.ToString());
            if(!Regex.IsMatch(guess, regex))
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

        public UnjumbleGame()
        {
            InitialWord = WordManager.GetRandom(1);
            Guesses = new();
            JumbledLetters = this.Jumble(InitialWord.WordString).ToString();
        }

        public UnjumbleGame(Word word)
        {
            InitialWord = word;
            JumbledLetters = this.Jumble(InitialWord.WordString).ToString();
            Guesses = new();
        }

        public UnjumbleGame(Word word, List<string> guesses)
        {
            InitialWord = word;
            JumbledLetters = this.Jumble(InitialWord.WordString).ToString();
            Guesses = guesses;
        }

        public virtual char[] Jumble(string word)
        {
            return word.ToArray().Shuffled().ToArray();
        }
    }
}
