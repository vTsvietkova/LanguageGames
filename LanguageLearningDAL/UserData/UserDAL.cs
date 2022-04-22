using System.Text;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using LanguageLearningLogic.DataInterfaces;
using LanguageLearningLogic.UserClasses;
using LanguageLearningLogic;
using System.Diagnostics;

namespace Data.UserData
{
    public class UserDAL : IUserDAL
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
                while (dr.Read())
                {

                    string username = dr.GetString("username");
                    string password = dr.GetString("password");
                    string email = dr.GetString("email");
                    int xp = dr.GetInt32("xp");

                    string value = dr[5].ToString();
                    Role role;
                    if(string.IsNullOrEmpty(value))
                    {
                        role = Role.User;
                    }
                    else
                    {
                        role = (Role)Enum.Parse(typeof(Role), value);
                    }
                    user = new(username, id, password, email, xp, role);
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

        public bool CanBeRenamed(User user)
        {
            string sql = "select EXISTS(select id from user where user.id != @id and (user.username = @username or user.email = @mail));";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@id", user.Id);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@mail", user.Email);
            bool canBeRenamed = false;
            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    canBeRenamed = !dr.GetBoolean(0);
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
            return canBeRenamed;
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
            string sql = "INSERT INTO `user`(`username`, `password`, `email`, `xp`, `role`, salt) VALUES (@username, @password, @email, 0, @role, @salt);";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@username", user.Username);
            var newSalt = GenerateSalt();
            var hashedPassword = ComputeHash(Encoding.UTF8.GetBytes(user.Password), Encoding.UTF8.GetBytes(newSalt));
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            cmd.Parameters.AddWithValue("@salt", newSalt);
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
            string sql = "UPDATE `user` SET `username`=@username, `email`=@email WHERE id = @id;";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@username", user.Username);
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

        public void ChangePassword(User user)
        {
            string sql = "UPDATE `user` SET password = @password, salt = @salt WHERE id = @id;";
            MySqlCommand cmd = new(sql, connection);
            var newSalt = GenerateSalt();
            var hashedPassword = ComputeHash(Encoding.UTF8.GetBytes(user.Password), Encoding.UTF8.GetBytes(newSalt));
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            cmd.Parameters.AddWithValue("@salt", newSalt);
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

        public void AddXPPoints(int id, int xp)
        {
            string sql = "UPDATE `user` SET xp=xp+@xp WHERE id = @id;";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@xp", xp);
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

        public bool IsGoodPassword(string password)
        {
            bool goodPassword = true;
            try
            {
                string[] lines = File.ReadAllLines(@"wwwroot/Passwords.txt");
                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    if (password.ToLower() == line)
                    {
                        goodPassword = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return goodPassword;
        }

        public bool CrededentialsTaken(User user)
        {
            MySqlConnection connection = new(ConnectionString.str);
            bool exists = false;
            string sql = "select id from user where id=@id and `username` = @username or `email` = @email";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@id", user.Id);

            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                exists = dr.HasRows;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return exists;
        }

        public int Login(string username, string password)
        {
            int id = 0;
            string sql = "select id, password, salt from user where `username` = @login or `email` = @login";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@login", username);
            try
            {
                connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var newSalt = dr.GetString("salt");
                        var hashedPassword = ComputeHash(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(newSalt));
                        if (hashedPassword == dr.GetString("password"))
                        {
                            id = dr.GetInt32("id");
                        }
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
            return id;
        }
        //https://www.automationmission.com/2020/09/17/hashing-and-salting-passwords-in-c/
        public string ComputeHash(byte[] bytesToHash, byte[] salt)
        {
            var byteResult = new Rfc2898DeriveBytes(bytesToHash, salt, 10000);
            return Convert.ToBase64String(byteResult.GetBytes(24));
        }
        public string GenerateSalt()
        {
            var bytes = new byte[128 / 8];
            RandomNumberGenerator.Fill(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
