using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace Consultant_Scheduling_Mushero
{
    public class City : Address
    {
        private int cityId;

        private string cityName;
        int countryId;

        public int CityID
        {
            get { return cityId; }
            set { cityId = value; }


        }
        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        public int CountryID
        {
            get; set;
        }

        public City()
        {

        }

        public City(int cityId)
        {
            CityID = cityId;
            getCityData(CityID);
        }

        public bool checkCityExist(string city)
        {
            bool exists = false;

            string command = $"SELECT CityId FROM City WHERE city.CityName = {city}; ";

            try
            {
                using (MySqlConnection cnn = new MySqlConnection(connectionString))
                {

                    using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                    {
                        cnn.Open();

                        // run query 
                        cmd.ExecuteNonQuery();

                        var cityId = int.Parse(cmd.Parameters["_CityId"].Value.ToString());


                        if (cityId > 0)
                        {
                            exists = true;
                        }
                        else
                        {
                            return false;
                        }

                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            return exists;
        }

        /// <summary>
        /// this method inserts the city into the database
        /// </summary>
        /// <param name="lastUpdateBy"></param>
        /// <returns></returns>
        public int insertCity(int userID)
        {


            string command = $"INSERT INTO City(CityName, CountryId, CreateDate," +
                $" CreatedBy, LastUpdatedBy) VALUES('{CityName}', {CountryID}," +
                $"'{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}','{userID}', '{userID}')";
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
                            CityID = Convert.ToInt32(cmd.LastInsertedId);
                            Console.WriteLine($"Insertion Successful City Id: {CityID}");
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            Console.WriteLine("Insert City: Error " + ex.Number + " \nMessage: " + ex.Message);
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
            return CityID;
        }




        /// <summary>
        /// this method updates the city
        /// </summary>
        /// <param name="username"></param>
        public void updateCity(int userID)
        {

            string command = $"UPDATE City set CityName = '{CityName}', LastUpdatedBy = '{userID}' where CityId = {CityID} ";


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
                        Console.WriteLine("Update City: Error " + ex.Number + " \nMessage: " + ex.Message);
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// this method gets the city based on the city ID
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public int getCityData(int cityId)
        {

            CityID = cityId;
            string command = $"SELECT CityName, CountryId FROM City where CityId = {cityId};";


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


                                    CityName = dr["CityName"].ToString();
                                    CountryID = Convert.ToInt32(dr["CountryId"]);




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
            return CountryID;
        }




    }
}




