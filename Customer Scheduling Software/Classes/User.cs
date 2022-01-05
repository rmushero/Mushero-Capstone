using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Consultant_Scheduling_Mushero
{
    public class User
    {
        private int userId;
        private string userName;
        private string password;
        private bool active;



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


        public int Active
        {
            get; set;
        }



        public User()
        {

        }

      


        /// <summary>
        /// Finder user account. If present return an integer;
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int FindUserAccount(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

            int userID = 0;
            string command = $"SELECT UserId from user where UserName = '{username}' and Password = '{password}' and Active = 1";

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {
                    try
                    {
                        cnn.Open();
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {

                            userID = int.Parse(result.ToString());
                        }



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



        // get all appointments for the user with all columns
        public DataTable getAppointments()
        {
            string command = "SELECT * FROM appointment a WHERE UserId = " + UserID + " order by start asc";
            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            DataTable appointments = new DataTable();
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {

                    try
                    {
                        cnn.Open();

                        appointments.Load(cmd.ExecuteReader());

                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("get_Appointment(): ->Error " + ex.Number + " \nMessage: " + ex.Message); ;
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }

                }


            }

            return appointments;
        }



    }
}
