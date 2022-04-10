using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Validators
{
    class GoodPasswordAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Your password is vulnerable. The best way to improve it is by combining three short memorable words";
        }

        public override bool IsValid(object? value)
        {
            bool exists = false;
            if (value is null)
            {
                return false;
            }
            try
            {
                string[] lines = File.ReadAllLines(@"wwwroot/Passwords.txt");
                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    if (((string)value).ToLower() == line)
                    {
                        exists = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {

            }
            return !exists;
        }
    }
}
