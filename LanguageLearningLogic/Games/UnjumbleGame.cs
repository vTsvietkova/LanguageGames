using LanguageLearningLogic.WordClasses;
using Medallion;

namespace LanguageLearningLogic.Games
{
    public class UnjumbleGame : GameBase
    {

        public UnjumbleGame(Word word) : base(word)
        {
        }

        public UnjumbleGame(Word word, List<string> guesses) : base(word, guesses)
        {
        }

        public UnjumbleGame(Word word, WordManager manager) : base(word, manager)
        {
        }

        public UnjumbleGame(Word word, List<string> guesses, WordManager manager) : base(word, guesses, manager)
        {
        }

        public UnjumbleGame(WordManager wordManager) : base(wordManager)
        {
        }

        public override int CalculateScore()
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
            else if (correctAnswer == 0 || correctAnswer == 1)
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
        public virtual string? JumbledLetters { get => new string(InitialWord.WordString.ToArray().Shuffled().ToArray());}

        public override bool AddAnswer(string guess)
        {
            if(guess.Length == InitialWord.WordString.Length)
            {
                return base.AddAnswer(guess);
            }
            else
            {
                return false;
            }
        }
    }
}
