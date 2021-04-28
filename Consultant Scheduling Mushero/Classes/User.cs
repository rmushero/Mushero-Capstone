using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;

namespace Consultant_Scheduling_Mushero
{
    public class User
    {
        private int userId;
        private string userName;
        private string password;
        private int cityId;
        private int active;
        private string lastUpdateBy;


        public int UserID
        {
            get; set;
        }

        public string Username
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public int CityId
        { get; set; }

        public int Active
        {
            get; set;
        }
        public string LastUpdateBy
        {
            get; set;
        }


        public User()
        {

        }

        public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public int FindUserAccount(string username, string password)
        {
            int userID = 0;


            string command = "SELECT u.userID from user u where u.username = '" + username + "\' and u.password = '" + password + "\' and u.active = 1";
    
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {
                    try
                    {
                        cnn.Open();
                        userID = Int32.Parse(cmd.ExecuteScalar().ToString());

                        

                    }

                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("Error " + ex.Number + " \nMessage: " + ex.Message);
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }

            return userID;
        }

      






    }
}
