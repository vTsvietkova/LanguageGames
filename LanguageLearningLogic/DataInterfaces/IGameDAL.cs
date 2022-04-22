using LanguageLearningLogic.Games;
namespace LanguageLearningLogic.DataInterfaces
{
    public abstract class IGameDAL
    {
        public abstract bool AddAnswer(string answer, int gameid);
        public abstract int CreateGame(GameBase game, int userid);
        public abstract void DeleteGame(int id);
        public abstract void FinishGame(int id);
        public abstract GameBase GetGame(int id);
        public abstract List<GameBase> GetAllGames(int userid);
    }
}
