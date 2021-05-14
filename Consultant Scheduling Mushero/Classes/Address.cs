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
    public class Address : Customer
    {

        private int addressID;
        private string address;
        private string address2;
        private int cityId;
        private string postalCode;
        private string phone;

        public List<Address> addresses = new List<Address>();

      



        public int AddressId
        {
            get; set;
        }
        public string Address1
        {
            get { return address; }
            set { address = value; }
        }
        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }

        public int CityId
        {
            get;set;
        }

        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value;}
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Address() { }



        public Address(int addressID)
        {
            AddressId = addressID;
            AddressId = addressID;
            getAddressData(addressID);
        }



        /// <summary>
        /// this method inserts the address into the database
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>

        public int insertAddress(string userName)
        {

            
            string command = $"INSERT INTO address (address, address2, cityID, " +
                $"postalCode, phone, createDate, createdBy, lastUpdateBy)" +
                $" VALUES('{Address1}', '{Address2}', {CityId}, " +
                $"'{PostalCode}', '{Phone}', '{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}','{userName}','{userName}')";

            
                using (MySqlConnection cnn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                    {
                        
                        try
                        {
                            cnn.Open();
                            cmd.ExecuteNonQuery();
                            AddressId = Convert.ToInt32(cmd.LastInsertedId);

                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            Console.WriteLine("Insert Address: Error " + ex.Number + " \nMessage: " + ex.Message);
                        }
                        finally
                        {
                            cnn.Close();
                            cnn.Dispose();
                        }
                        
                    }
                }
           

            return AddressId;
        }

        /// <summary>
        /// this method updates the current address
        /// </summary>
        /// <param name="userName"></param>
        public void updateAddress(string userName)
        {
            string command = $"UPDATE address SET address = '{Address1}', address2 = '{Address2}', postalCode = '{PostalCode}', phone = {Phone}, lastUpdateBy = '{userName}' WHERE addressId = {AddressId}";

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
                        Console.WriteLine("updateAddress: Error " + ex.Number + " \nMessage: " + ex.Message);
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
        /// this method gets address data using the Address ID
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>

        public int getAddressData(int addressId)
        {
            AddressId = addressId;

            string command = $"SELECT address, address2, postalCode, phone, cityId FROM address where addressId = '{addressId}'";

            
            

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
                                   
                                   
                                   Address1 = dr["address"].ToString();
                                   Address2 = dr["address2"].ToString();
                                   CityId = Convert.ToInt32(dr["cityId"]);
                                   PostalCode = dr["postalCode"].ToString();
                                   Phone = dr["phone"].ToString();
                                   
                                }
                            }
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("Get Address Data: Error " + ex.Number + " \nMessage: " + ex.Message);
                    }
                  
                    
                }
            }
            return CityId;
        }
    }
}

