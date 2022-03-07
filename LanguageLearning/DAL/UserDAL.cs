using System;
using System.Collections.Generic;
using MySql;
using MySql.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LanguageLearning.DAL;

namespace LanguageLearning.MockDB
{
    class UserDAL : IUserDAL
    {
        MySqlConnection connection = new(ConnectionString.str);
        public User Get(int id)
        {
            string sql = "SELECT `id`, `username`, `password`, `email`, `xp`, `role` FROM `user` WHERE id = @id;";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            User user = new User();
            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    user = new(dr.GetString("username"), id, dr.GetString("password"), dr.GetString("email"), dr.GetInt32("xp"), (Role)Enum.Parse(typeof(Role), dr.GetString("role")));
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
            return user;
        }

        public List<User> GetAll()
        {
            string sql = "SELECT `id`, `username`, `password`, `email`, `xp`, `role` FROM `user`;";
            MySqlCommand cmd = new(sql, connection);
            List<User> users = new();
            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    users.Add(new(dr.GetString("username"), dr.GetInt32("id"), dr.GetString("password"), dr.GetString("email"), dr.GetInt32("xp"), (Role)Enum.Parse(typeof(Role), dr.GetString("role"))));
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
            return users;
        }

        public void Create(User user)
        {
            string sql = "INSERT INTO `user`(`username`, `password`, `email`, `xp`, `role`) VALUES (@username, @password, @email, 0, @role);";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@role", user.Role.ToString());
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

        public void Update(User user)
        {
            string sql = "UPDATE `user` SET `username`=@username,`password`=@password,`email`=@email WHERE id = @id;";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@id", user.Id);
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

        public void Delete(int id)
        {
            string sql = "DELETE FROM `user` WHERE id = @id;";
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

        public int Login(string username, string password)
        {
            throw new NotImplementedException();
            int id = 0;
            string sql = "";
            MySqlCommand cmd = new(sql, connection);
            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
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
    }
}
