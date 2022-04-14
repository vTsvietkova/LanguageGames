using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguageLearningLogic.Games;
using LanguageLearning.WordClasses;
using LanguageLearningLogic;
using Data.WordData;

namespace Tests_Language
{
    [TestClass]
    public class WordTests
    {
        [TestMethod]
        public void MostPopularDefinitionTest()
        {
            Word word = new Word();
            word.Definitions.Add(new(1, "second", 10, LanguageLearning.PartOfSpeach.noun));
            word.Definitions.Add(new(2, "first", 15, LanguageLearning.PartOfSpeach.verb));
            word.Definitions.Add(new(2, "third", 5, LanguageLearning.PartOfSpeach.noun));
            Assert.AreEqual("first", word.MostPopularDefinition.Def);
        }
        [TestMethod]
        public void PartsOfSpeach()
        {
            Word word = new Word();
            word.Definitions.Add(new(1, "second", 10, LanguageLearning.PartOfSpeach.noun));
            word.Definitions.Add(new(2, "first", 15, LanguageLearning.PartOfSpeach.verb));
            word.Definitions.Add(new(2, "third", 5, LanguageLearning.PartOfSpeach.noun));
            Assert.AreEqual("noun, verb", word.PartsOfSpeach);
        }
        [TestMethod]
        public void TestSearch()
        {
            WordManager manager = new(new MockWordDAL());
            manager.GetAllMatchingSearch("");
        }
    }
}
