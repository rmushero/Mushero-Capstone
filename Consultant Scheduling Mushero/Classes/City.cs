﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;


namespace Consultant_Scheduling_Mushero
{
    public class City : Address
    {
        private int cityId;

        private string cityName;
        Country country;



        public List<City> cities = new List<City>();

        
        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }


        }
        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        public int CountryId
        {
            get; set;
        }

        public City()
        {

        }

        public City(int cityId)
        {
            CityId = cityId;
            getCityData(CityId);
        }

        

        public bool checkCityExist(string city)
        {
            bool exists = false;

            string command = $"SELECT cityId FROM city WHERE city.city = {city}; ";

            try
            {
                using (MySqlConnection cnn = new MySqlConnection(connectionString))
                {

                    using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                    {
                        cnn.Open();

                        // run query 
                        cmd.ExecuteNonQuery();

                        var cityId = int.Parse(cmd.Parameters["_cityId"].Value.ToString());


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
        public int InsertCity( string lastUpdateBy)
        {

            
            string command = $"INSERT INTO city(city, countryId, createDate," +
                $" createdBy, lastUpdateBy) VALUES('{CityName}', {CountryId}," +
                $"'{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}','{lastUpdateBy}', '{lastUpdateBy}')";
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
                            CityId = Convert.ToInt32(cmd.LastInsertedId);
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
            return CityId;
        }

        

        public void updateCity(string username)
        {

            string command = $"UPDATE city set city = '{CityName}', lastUpdateBy = '{username}' where cityId = {CityId} ";
            try
            {
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
                            Console.WriteLine("Error " + ex.Number + " \nMessage: " + ex.Message);
                        }
                        finally
                        {
                            cnn.Close();
                            cnn.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public void getCityData(int cityId)
        {
           

            string command = $"SELECT city, countryId FROM city where cityId = {cityId};";

            DataTable dataTable = new DataTable();
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
                                    City city = new City();
                                    city.CityId = cityId;
                                    city.CityName = dr["city"].ToString();
                                    city.CountryId = Convert.ToInt32(dr["countryId"]);
                                    cities.Add(city);
                                    Country country = new Country();
                                    country.getCountryData(CountryId);


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






    }
}



