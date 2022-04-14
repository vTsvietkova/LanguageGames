using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguageLearningLogic.Games;

namespace Tests_Language
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void AddValidAnswer()
        {
            UnjumbleGame game = new(new LanguageLearning.WordClasses.Word("words"));
            
            Assert.AreEqual(true, game.AddAnswer("sword"));
        }
        [TestMethod]
        public void AddInvalidAnswer()
        {
            UnjumbleGame game = new(new LanguageLearning.WordClasses.Word("words"));

            Assert.AreEqual(false, game.AddAnswer("bread"));
        }
        [TestMethod]
        public void AddAnswerTwice()
        {
            UnjumbleGame game = new(new LanguageLearning.WordClasses.Word("words"));
            game.AddAnswer("sword");
            Assert.IsFalse(game.AddAnswer("sword"));
        }

        [TestMethod]
        public void JumbleLetters()
        {
            UnjumbleGame game = new(new LanguageLearning.WordClasses.Word("words"));
            Assert.IsFalse(game.JumbledLetters == "words");
        }

        [TestMethod]
        public void CalculateScoreUnjumbleNeverGuessed()
        {
            UnjumbleGame game = new(new LanguageLearning.WordClasses.Word("words"));
            game.AddAnswer("sword");
            Assert.AreEqual(0, game.CalculateScore());
        }
        [TestMethod]
        public void CalculateScoreUnjumbleFirstGuess()
        {
            UnjumbleGame game = new(new LanguageLearning.WordClasses.Word("words"));
            game.AddAnswer("words");
            Assert.AreEqual(100, game.CalculateScore());
        }

        [TestMethod]
        public void CalculateScoreUnjumbleFourthGuessShortWord()
        {
            UnjumbleGame game = new(new LanguageLearning.WordClasses.Word("cat"));
            game.AddAnswer("act");
            game.AddAnswer("atc");
            game.AddAnswer("tac");
            game.AddAnswer("cat");
            Assert.AreEqual(40, game.CalculateScore());
        }
        [TestMethod]
        public void CalculateScoreUnjumbleOrderMatters()
        {
            UnjumbleGame game = new(new LanguageLearning.WordClasses.Word("cat"));
            game.AddAnswer("act");
            game.AddAnswer("cat");
            game.AddAnswer("atc");
            game.AddAnswer("tac");
            Assert.AreEqual(100, game.CalculateScore());
        }
        [TestMethod]
        public void CalculateScoreUnjumbleLongWordManyGuesses()
        {
            UnjumbleGame game = new(new LanguageLearning.WordClasses.Word("words"));
            game.AddAnswer("sword");
            game.AddAnswer("dows");
            game.AddAnswer("rows");
            game.AddAnswer("do");
            game.AddAnswer("so");
            game.AddAnswer("words");
            Assert.AreNotEqual(100, game.CalculateScore());
        }
    }
}
