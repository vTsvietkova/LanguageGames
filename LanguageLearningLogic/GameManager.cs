using LanguageLearningLogic.DataInterfaces;
using LanguageLearningLogic.Games;

namespace LanguageLearningLogic
{
    public class GameManager
    {
        private IGameDAL dal;
        private IWordDAL wordDAL;
        private IUserDAL userDAL;
        public GameManager(IGameDAL gameDAL, IWordDAL wordDAL)
        {
            this.dal=gameDAL;
            this.wordDAL=wordDAL;
        }

        public GameManager(IGameDAL gameDAL, IWordDAL wordDAL, IUserDAL userDAL)
        {
            this.dal=gameDAL;
            this.wordDAL=wordDAL;
            this.userDAL=userDAL;
        }

        public bool AddAnswer(string answer, GameBase game)
        {
            if(game.AddAnswer(answer))
            {
                dal.AddAnswer(answer, game.Id);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CreateGame(GameBase game, int userid)
        {
            dal.CreateGame(game, userid);
        }
        public GameBase CreateNewGame(bool letters, int userid)
        {
            GameBase game = null;
            WordManager wordManager = new WordManager(wordDAL);
            if(letters)
            {
                game = new LettersGame(wordManager);
            }
            else
            {
                game = new UnjumbleGame(wordManager);
            }
            game.Id = dal.CreateGame(game, userid);
            return game;
        }
        public void DeleteGame(int id)
        {
            dal.DeleteGame(id);
        }
        public void FinishGame(int gameid, int userid)
        {
            GameBase game = dal.GetGame(gameid);
            int score = game.CalculateScore();
            userDAL.AddXPPoints(userid, score);
            dal.FinishGame(gameid);
        }
        public GameBase GetGame(int id)
        {
            return dal.GetGame(id);
        }
        public List<GameBase> GetAllGames(int userid)
        {
            return dal.GetAllGames(userid);
        }
    }
}
