using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Consultant_Scheduling_Mushero
{
    public class Customer
    {
        private int customerId;
        private string customerName;
        private int addressId;
        private sbyte active;

        
        


        public int CustomerId
        {
            get; set;
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public int AddressId
        {
            get;
            set;


        }
        public sbyte Active
        {
            get; set;
        }


        public Customer()
        {

        }


        public Customer(int customerId)
        {
            CustomerId = customerId;

        }

        public Customer(string customerName, int addressID, int active, string lastUpdateBy)
        {

        }

        public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;



       

        /// <summary>
        /// this method inserts customer data in to the database
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int insertCustomer(string username)
        {
            string command = $"INSERT INTO customer (customerName, addressId, " +
                $"active, createDate, createdBy, lastUpdateBy) " +
                $"Values('{customerName}', {AddressId}, {Active}, " +
                $"'{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}', '{username}', '{username}')";
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
                            CustomerId = Convert.ToInt32(cmd.LastInsertedId);
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            Console.WriteLine("Insert Customer: Error " + ex.Number + " \nMessage: " + ex.Message);
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
            return CustomerId;
        }


        /// <summary>
        /// this method gets customer data from the database using the customer ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public int getCustomerData(int customerId)
        {
            CustomerId = customerId;
            string command = $"SELECT customerName, addressID, active FROM customer where customerId = {customerId}";

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

                                    CustomerName = dr["customerName"].ToString();
                                    AddressId = Convert.ToInt32(dr["addressId"]);
                                    Active = Convert.ToSByte(dr["active"]);
                                    
                                }

                            }
                        }



                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("Get Customer Data: Error " + ex.Number + " \nMessage: " + ex.Message);
                    }

                }
            }

            return AddressId;
        }


        /// <summary>
        /// This method gets the customer information for the customers table 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataTable getCustomersforTable(string username)
        {



            DataTable customers = new DataTable();


            string command = $"SELECT c.customerID as ID, c.customerName as Name , c.active as 'Active', a.address as 'Address'," +
               $" a.address2 as 'Address 2', a.postalCode as 'Postal Code', a.phone as 'Phone', ci.city as 'City', co.country as 'Country'" +
               $"FROM customer c right join address a on c.addressId = a.addressId " +
               $"right join city ci on a.cityId = ci.cityId " +
               $"right join country co on co.countryId = ci.countryId " +
               $"where c.createdBy = '{username}'";



            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {

                    try
                    {

                        cnn.Open();

                        customers.Load(cmd.ExecuteReader());

                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();


                    }



                }
            }
            return customers;
        }

        /// <summary>
        /// This method updates the customer in the database
        /// </summary>
        /// <param name="Username"></param>
        public void updateCustomer(string Username)
        {
            string command = $"UPDATE customer SET customerName = '{CustomerName}', active ={Active}," +
                $" lastUpdateBy = '{Username}' WHERE customerId = {CustomerId }";

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
                            Console.WriteLine("Update Customer: Error " + ex.Number + " \nMessage: " + ex.Message);
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
        /// <summary>
        /// this method deletes the customer from the database
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public bool deleteCustomer(int CustomerID)
        {

            // Delete all appointments first 
            bool deleted = false;
            string command2 = "DELETE from appointment where customerId =" + CustomerID + "";

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command2, cnn))
                {
                    cnn.Open();

                    try
                    {
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            deleted = true;
                        }
                        else
                        {
                            Console.WriteLine("Delete customer failed");
                        }

                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("Update Customer: Error " + ex.Number + " \nMessage: " + ex.Message);
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }


            // delete from weakest table to strongest table
            string command = "DELETE c, ad, ct, ctry " +
            "from customer c " +
            "inner join address ad on c.addressId = ad.addressID " +
            "inner join city ct on ad.cityId = ct.cityId " +
            "inner join country ctry on ct.countryId = ctry.countryId " +
            "where c.customerId = " + CustomerID + "";

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
                        Console.WriteLine("Delete Customer: Error " + ex.Number + " \nMessage: " + ex.Message);
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }


            return deleted;

        }
    }
}
       

       



    