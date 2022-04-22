using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguageLearningLogic;
using System.Collections.Generic;
using LanguageLearningLogic.WordClasses;

namespace Tests_Language
{
    [TestClass]
    public class WordTests
    {
        [TestMethod]
        public void MostPopularDefinitionTest()
        {
            Word word = new Word();
            word.Definitions.Add(new(1, "second", 10, PartOfSpeach.noun));
            word.Definitions.Add(new(2, "first", 15, PartOfSpeach.noun));
            word.Definitions.Add(new(2, "third", 5, PartOfSpeach.verb));
            Assert.AreEqual("first", word.MostPopularDefinition.Def);
        }
        [TestMethod]
        public void PartsOfSpeach()
        {
            Word word = new Word();
            word.Definitions.Add(new(1, "second", 10, PartOfSpeach.noun));
            word.Definitions.Add(new(2, "first", 15, PartOfSpeach.verb));
            word.Definitions.Add(new(2, "third", 5, PartOfSpeach.noun));
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
