using LanguageLearningLogic.WordClasses;

namespace LanguageLearningLogic.Games
{
    public class LettersGame : GameBase
    {
        public LettersGame(Word word) : base(word)
        {
        }

        public LettersGame(WordManager wordManager) : base(wordManager)
        {
        }

        public LettersGame(Word word, List<string> guesses) : base(word, guesses)
        {
        }

        public LettersGame(Word word, WordManager manager) : base(word, manager)
        {
        }

        public LettersGame(Word word, List<string> guesses, WordManager manager) : base(word, guesses, manager)
        {
        }

        public override int CalculateScore()
        {
            return Guesses.Count * 20;
        }
    }
}
