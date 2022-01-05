using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace Consultant_Scheduling_Mushero
{
    public class Country : City
    {
        private int countryId;

        private string countryName;



        public int CountryId
        {
            get; set;
        }
        public string CountryName
        {
            get { return countryName; }
            set { countryName = value; }
        }

        //Constructors

        public Country()
        {

        }

        public Country(int countryId)
        {
            CountryId = countryId;

        }



        /// <summary>
        /// This method inserts data into the country table
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>

        public int InsertCountry(int userID)
        {
            string command = $"INSERT INTO country(CountryName, CreateDate," +
                $" CreatedBy, LastUpdatedBy) Values('{CountryName}'," +
                $"'{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}', '{userID}', '{userID}');";


            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {
                    try
                    {
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        CountryId = Convert.ToInt32(cmd.LastInsertedId);
                        Console.WriteLine($"Insertion Successful Country ID: {CountryId}");

                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("Insert Country: Error " + ex.Number + " \nMessage: " + ex.Message);
                    }
                    cnn.Close();
                    cnn.Dispose();
                }
            }


            return CountryId;
        }

        /// <summary>
        /// this method executes a command to get information from the country table
        /// </summary>
        /// <param name="countryId"></param>

        public void getCountryData(int countryId)
        {

            CountryId = countryId;

            string command = $"SELECT CountryName from country where CountryId = {countryId}";

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {
                    cnn.Open();

                    try
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {


                                    CountryName = dr["CountryName"].ToString();


                                }
                            }
                        }

                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("Get Country Data Error " + ex.Number + " \nMessage: " + ex.Message);
                    }


                }
            }


        }



        /// <summary>
        /// This method executes a command to update the country table
        /// </summary>
        /// <param name="username"></param>


        public void updateCountry(int userID)
        {

            string command = $"UPDATE country c set c.CountryName = '{CountryName}', c.LastUpdatedBy = '{userID}' where c.CountryId = {CountryId} ";


            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {
                    cnn.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();


                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("Update Country: Error " + ex.Number + " \nMessage: " + ex.Message);
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }

                }
            }
        }
    }



}


