using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Data.Validators
{
    class UniqueUsernameOrEmail : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Username or Email already taken";
        }

        public override bool IsValid(object? value)
        {
            if(value is null)
            {
                return true;
            }
            MySqlConnection connection = new(ConnectionString.str);
            bool exists = false;
            string sql = "select id from user where `username` = @login or `email` = @login";
            MySqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@login", (string)value);
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
            return !exists;
        }
    }
}
