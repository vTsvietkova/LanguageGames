using LanguageLearningLogic;
using LanguageLearningLogic.DataInterfaces;
using LanguageLearningLogic.WordClasses;

namespace Data.WordData
{
    public class MockWordDAL : IWordDAL
    {
        private List<Word> Words;
        public void CreateDefinition(Definition definition, Word word) 
        {

        }
        public void DeleteDefinition(int id) 
        {
            
        }

        public void UpdateDefinition(Definition definition) 
        {
            
        }

        void IWordDAL.DeleteWord(int id) 
        {
            Word w = Get(id);
            if(w != null)
            {
                Words.Remove(w);
            }
        }

        public Word Get(int id)
        {
            foreach (Word w in Words) 
            {
                if (w.Id == id)
                {
                    return w;
                }
            }
            return null;
        }

        public List<Word> GetAll()
        {
            if (Words is null)
            {
                List<Word> words = new();
                Word word = new("dinosaur", 1, 50);
                word.Definitions.Add(new Definition(1, "An ancient animal", 10, PartOfSpeach.noun));
                words.Add(word);
                word = new Word("appreciate", 2, 50);
                word.Definitions.Add(new Definition(2, "to recognize how good someone or something is and to value him, her, or it", 20, PartOfSpeach.verb));
                word.Definitions.Add(new Definition(3, "to understand a situation and realize that it is important", 15, PartOfSpeach.verb));
                word.Definitions.Add(new Definition(4, "to increase in value", 5, PartOfSpeach.verb));
                words.Add(word);
                word = new("apprehend", 3, 50);
                word.Definitions.Add(new(5, "to catch and arrest someone who has not obeyed the law", 20, PartOfSpeach.verb));
                word.Definitions.Add(new(6, "to understand", 19, PartOfSpeach.verb));
                words.Add(word);
                word = new("leave", 4, 50);
                word.Definitions.Add(new(7, "time allowed away from work for a holiday or illness", 25, PartOfSpeach.noun));
                word.Definitions.Add(new(8, "to go away from someone or something, for a short time or permanently", 20, PartOfSpeach.verb));
                words.Add(word);
                word = new("poison", 5, 50);
                word.Definitions.Add(new(9, "a fish", -5, PartOfSpeach.noun));
                word.Definitions.Add(new(10, "a substance that can make people or animals ill or kill them if they eat or drink it", 20, PartOfSpeach.noun));
                word.Definitions.Add(new(11, "to kill a person or animal or to make them very ill by giving them poison", 20, PartOfSpeach.verb));
                word.Definitions.Add(new(12, "to put poison in someone's food or drink", 226, PartOfSpeach.verb));
                word.Definitions.Add(new(13, "to add dangerous chemicals or other harmful substances to something such as water or air", 25, PartOfSpeach.verb));
                words.Add(word);
                Words = words;
            }
            return Words;
        }

        void IWordDAL.UpdateWord(Word word) 
        {
            Word uword = Get(word.Id);
            if (uword != null)
            {
                uword = word;
            }
        }



        public int CreateWord(Word word)
        {
            word.Id = Words.Last().Id + 1;
            Words.Add(word);
            return word.Id;
        }

        Word IWordDAL.GetRandom(int q)
        {
            Random random = new Random();
            return Words[random.Next(0, Words.Count)];
        }
    }
}
