using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        public string _Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }

        public int CityID
        {
            get; set;
        }

        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
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

        public int insertAddress(int userID)
        {


            string command = $"INSERT INTO Address (Address, Address2, CityID, " +
                $"PostalCode, Phone, CreateDate, CreatedBy, LastUpdatedBy)" +
                $" VALUES('{_Address}', '{Address2}', {CityID}, " +
                $"'{PostalCode}', '{Phone}', '{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}','{userID}','{userID}')";


            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {

                    try
                    {
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        AddressId = Convert.ToInt32(cmd.LastInsertedId);
                        Console.WriteLine($"Insertion Successful Address Id: {AddressId}");

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
        public void updateAddress(int userID)
        {
            string command = $"UPDATE Address SET Address = '{_Address}', Address2 = '{Address2}', PostalCode = '{PostalCode}', Phone = {Phone}, LastUpdatedBy = '{userID}' WHERE AddressId = {AddressId}";

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

            string command = $"SELECT Address, Address2, PostalCode, Phone, CityID FROM Address where AddressID = '{addressId}'";




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


                                    _Address = dr["Address"].ToString();
                                    Address2 = dr["Address2"].ToString();
                                    CityID = Convert.ToInt32(dr["CityId"]);
                                    PostalCode = dr["PostalCode"].ToString();
                                    Phone = dr["Phone"].ToString();

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
            return CityID;
        }
    }
}

