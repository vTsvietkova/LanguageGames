using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguageLearningLogic.Games;
using LanguageLearning.WordClasses;
using LanguageLearningLogic;
using Data.WordData;
using System.Collections.Generic;

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
            List<Word> words = manager.GetAllMatchingSearch("app");
            bool appriciate = words[1].WordString == "appreciate" || words[0].WordString == "appreciate";
            bool apprehend = words[1].WordString == "apprehend" || words[0].WordString == "apprehend";
            bool tworesults = words.Count == 2;
            Assert.IsTrue(apprehend && appriciate && tworesults);
        }
    }
}