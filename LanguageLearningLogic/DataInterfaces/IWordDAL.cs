using LanguageLearningLogic.WordClasses;

namespace LanguageLearningLogic.DataInterfaces
{
    public interface IWordDAL
    {
        public abstract int CreateWord(Word word);
        public abstract void CreateDefinition(Definition definition, Word word);
        public abstract void DeleteWord(int id);
        public abstract void DeleteDefinition(int id);
        public abstract Word Get(int id);
        public abstract List<Word> GetAll();
        public abstract void UpdateWord(Word word);
        public abstract void UpdateDefinition(Definition definition);
        public abstract Word GetRandom(int q);
    }
}