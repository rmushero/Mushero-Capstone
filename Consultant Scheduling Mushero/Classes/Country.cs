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
    public class Country : City
    {
        private int countryId;

        private string country;

        public List<Country> countries = new List<Country>();

        public int CountryId
        {
            get; set;
        }
        public string Country_name
        {
            get { return country; }
            set { country = value; }
        }


        public Country()
        {

        }
        //public Country(int countryid, string country, int lastUpdateby)
        //{

        //}

        public Country(int countryId)
        {
            CountryId = countryId;
          
        }

      

      
        public int InsertCountry(string userName)
        {

           
          
            string command = $"INSERT INTO country(country, createDate," +
                $" createdBy, lastUpdateBy) Values('{Country_name}'," +
                $"'{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}', '{userName}', '{userName}');";
            
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                    {
                        try
                        {
                            cnn.Open();
                            cmd.ExecuteNonQuery();
                            CountryId = Convert.ToInt32(cmd.LastInsertedId);
                            
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            Console.WriteLine("Insert Country: Error " + ex.Number + " \nMessage: " + ex.Message);
                        }
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return CountryId;
        }

        public void getCountryData(int countryId)
        {

            CountryId = countryId;

            string command = $"SELECT country from country where countryId = {countryId}";

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
                                   
                                   
                                   Country_name = dr["country"].ToString();
                                    

                                }
                            }
                        }

                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("Error " + ex.Number + " \nMessage: " + ex.Message);
                    }


                }
            }
          

        }






        public void updateCountry(string username)
        {

            string command = $"UPDATE country c set c.country = '{Country_name}', c.lastUpdateBy = '{username}' where c. countryId = {CountryId} ";


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


