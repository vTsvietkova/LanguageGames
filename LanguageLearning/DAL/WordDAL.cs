using System;
using System.Collections.Generic;
using MySql.Data;
using MySql;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace LanguageLearning.DAL
{
    public class WordDAL : IWordDAL
    {
        MySqlConnection connection = new(ConnectionString.str);
        public int CreateWord(Word word)
        {
            string sql = "INSERT INTO `words`(`word`, `hits`) VALUES (@word, 0);";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@word", word.WordString);
            int lastinsId = 0;
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                lastinsId = ((int)cmd.LastInsertedId);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return lastinsId;
        }

        public void CreateDefinition(Definition definition, Word word)
        {
            string sql = "INSERT INTO `definition`(`word`, `partofspeech`, `definition`, `vote`) VALUES (@word, @partOfSpeach, @definition, @votes);";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@word", word.Id);
            cmd.Parameters.AddWithValue("@partofspeach", definition.PartOfSpeach);
            cmd.Parameters.AddWithValue("@definition", definition.Def);
            cmd.Parameters.AddWithValue("@votes", definition.Votes);
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

        public void DeleteDefinition(int id)
        {
            string sql = "DELETE FROM `definition` WHERE id = @id;";
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

        public void DeleteWord(int id)
        {
            string sql = "DELETE FROM `words` WHERE id = @id;";
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

        public Word Get(int id)
        {
            string sql = "SELECT w.id, d.id defid, w.word, w.hits, d.partofspeech, d.definition, d.vote definitionvotes FROM `definition` d inner join words w on d.word = w.id WHERE w.id = @id;";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            Word word = null;
            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if(word is null || word.Id != dr.GetInt32("id"))
                    {
                        word = new(dr.GetString("word"), dr.GetInt32("id"), dr.GetInt32("hits"));
                    }
                    word.Definitions.Add(new(dr.GetInt32("defid"), dr.GetString("definition"), dr.GetInt32("definitionvotes"), ((PartOfSpeach)Enum.Parse(typeof(PartOfSpeach),dr.GetString("partofspeech")))));
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
            return word;
        }

        public Word GetRandom(int q)
        {
            string sql = "SELECT w.id, d.id defid, w.word, w.hits, d.partofspeech, d.definition, d.vote definitionvotes FROM `definition` d inner join words w on d.word = w.id WHERE RAND()<(SELECT ((@number/COUNT(*))*10) FROM words) ORDER BY RAND() LIMIT @number;";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@number", q);
            Word word = new Word();
            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (word.Id != dr.GetInt32("id"))
                    {
                        word = new(dr.GetString("word"), dr.GetInt32("id"), dr.GetInt32("hits"));
                    }
                    word.Definitions.Add(new(dr.GetInt32("defid"), dr.GetString("definition"), dr.GetInt32("definitionvotes"), ((PartOfSpeach)Enum.Parse(typeof(PartOfSpeach), dr.GetString("partofspeech")))));
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
            return word;
        }

        public List<Word> GetAll()
        {
            string sql = "SELECT w.id, d.id defid, w.word, w.hits, d.partofspeech, d.definition, d.vote definitionvotes FROM `definition` d inner join words w on d.word = w.id;";
            MySqlCommand cmd = new(sql, connection);
            List<Word> words = new();
            Word word = new Word();
            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (word.Id != dr.GetInt32("id"))
                    {
                        word = new(dr.GetString("word"), dr.GetInt32("id"), dr.GetInt32("hits"));
                        words.Add(word);
                    }
                    word.Definitions.Add(new(dr.GetInt32("defid"), dr.GetString("definition"), dr.GetInt32("definitionvotes"), ((PartOfSpeach)Enum.Parse(typeof(PartOfSpeach), dr.GetString("partofspeech")))));
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
            return words;
        }

        public List<Word> GetOrphanedWords()
        {
            string sql = "SELECT * FROM `words` WHERE id not in (select distinct word from definition)";
            MySqlCommand cmd = new(sql, connection);
            List<Word> words = new();
            Word word = new Word();
            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    word = new(dr.GetString("word"), dr.GetInt32("id"), dr.GetInt32("hits"));
                    words.Add(word);
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
            return words;
        }

        public void UpdateWord(Word word)
        {
            string sql = "UPDATE `words` SET `word`=@word,`hits`=@hits WHERE id=@id;";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@word", word.WordString);
            cmd.Parameters.AddWithValue("@hits", word.NrOfHits);
            cmd.Parameters.AddWithValue("@id", word.Id);
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

        public void UpdateDefinition(Definition definition)
        {
            string sql = "UPDATE `definition` SET `partofspeech`=@partofspeach,`definition`=@definition, vote = @vote WHERE id = @id;";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@partofspeach", definition.PartOfSpeach.ToString());
            cmd.Parameters.AddWithValue("@definition", definition.Def);
            cmd.Parameters.AddWithValue("@vote", definition.Votes);
            cmd.Parameters.AddWithValue("@id", definition.Id);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}