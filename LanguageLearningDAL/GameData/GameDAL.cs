using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.GameData
{
    class GameDAL
    {
        MySqlConnection connection = new(ConnectionString.str);
        public void SaveUnjumbleGame(IUnjumbleGame game)
        {
            string sql = "INSERT INTO `lettergames`(`type`,  `initialword`, `scrambledword`, `user`) VALUES (@type, @word, @scrambled, @user)" +
                ";";
            List<MySqlCommand> cmds = new();
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@type", "unjumble");
            cmd.Parameters.AddWithValue("@word", game.InitialWord.Id);
            cmd.Parameters.AddWithValue("@scrambled", game.JumbledLetters);
            cmd.Parameters.AddWithValue("@user", game.user.Id);
            cmds.Add(cmd);
            foreach (string answer in game.Guesses)
            {
                sql = "INSERT INTO `gameanswers`(`game`, `answer`) VALUES (@game, @answer);";
                cmd = new(sql, connection);
                cmd.Parameters.AddWithValue("@game", 0);
                cmd.Parameters.AddWithValue("@answer", answer);
                cmds.Add(cmd);
            }
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
        public void LoadUnjumbleGame(int id)
        {

        }
    }
}
