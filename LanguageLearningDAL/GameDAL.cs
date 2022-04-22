using Data.WordData;
using LanguageLearningLogic;
using LanguageLearningLogic.DataInterfaces;
using LanguageLearningLogic.Games;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Data
{
    public class GameDAL : IGameDAL
    {
        MySqlConnection connection = new(ConnectionString.str);
        public override GameBase GetGame(int id)
        {
            string sql = "SELECT ga.answer, lg.id game, lg.`type`, w.word initialword, lg.`user` " +
                "FROM lettergames lg left join gameanswers ga on lg.id = ga.game left join words w on lg.initialword = w.id " +
                "WHERE lg.id = @id and finished = 0";
            MySqlCommand cmd = new(sql, connection);
            GameBase game = null;
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if(game == null || game.Id != dr.GetInt32("game"))
                    {
                        WordManager manager = new(new WordDAL());
                        if(dr.GetString("type") == "letters")
                        {
                            game = new LettersGame(new LanguageLearningLogic.WordClasses.Word(dr.GetString("initialword")), manager);
                        }
                        else
                        {
                            game = new UnjumbleGame(new LanguageLearningLogic.WordClasses.Word(dr.GetString("initialword")), manager);
                        }
                        game.Id = dr.GetInt32("game");
                    }
                    if(!dr.IsDBNull(0))
                    {
                        game.AddAnswer(dr.GetString("answer"));
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return game;
        }

        public override List<GameBase> GetAllGames(int userid)
        {
            string sql = "SELECT ga.answer, lg.id game, lg.`type`, w.word initialword, lg.`user` " +
                "FROM lettergames lg left join gameanswers ga on lg.id = ga.game left join words w on lg.initialword = w.id " +
                "WHERE finished = 0";
            MySqlCommand cmd = new(sql, connection);
            GameBase game = null;
            List<GameBase> games = new();

            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (game == null || game.Id != dr.GetInt32("game"))
                    {
                        WordManager manager = new(new WordDAL());
                        if (dr.GetString("type") == "letters")
                        {
                            game = new LettersGame(new LanguageLearningLogic.WordClasses.Word(dr.GetString("initialword")), manager);
                        }
                        else
                        {
                            game = new UnjumbleGame(new LanguageLearningLogic.WordClasses.Word(dr.GetString("initialword")), manager);
                        }
                        game.Id = dr.GetInt32("game");
                        games.Add(game);
                    }
                    if (!dr.IsDBNull(0))
                    {
                        game.AddAnswer(dr.GetString("answer"));
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return games;
        }

        public override bool AddAnswer(string answer, int gameid)
        {
            string sql = "INSERT INTO `gameanswers`(`game`, `answer`) VALUES (@game, @answer);";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@game", gameid);
            cmd.Parameters.AddWithValue("@answer", answer);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public override int CreateGame(GameBase game, int userid)
        {
            string sql = $"INSERT INTO `lettergames`(`type`, `initialword`, `user`, `finished`) VALUES (@gametype,@initialword,@user,0) on duplicate key update user = @user;";
            MySqlCommand cmd = new(sql, connection);
            int id;
            if(game is LettersGame)
            {
                cmd.Parameters.AddWithValue("@gametype", "letters");
            }
            else
            {
                cmd.Parameters.AddWithValue("@gametype", "unjumble");
            }
            cmd.Parameters.AddWithValue("@initialword", game.InitialWord.Id);
            cmd.Parameters.AddWithValue("@user", userid);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                id=((int)cmd.LastInsertedId);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return id;
        }

        public override void DeleteGame(int id)
        {
            string sql = "DELETE FROM `lettergames` WHERE id = @id;";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public override void FinishGame(int id)
        {
            string sql = "UPDATE `lettergames` SET `finished`=1 WHERE id=@id;";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
