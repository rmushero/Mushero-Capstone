using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Consultant_Scheduling_Mushero
{
    public class Customer
    {
        private int customerId;
        private string customerName;
        private int addressId;
        private sbyte active;

        public int CustomerID
        {
            get; set;
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public int AddressID
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
            CustomerID = customerId;

        }

        public Customer(string customerName, int addressID, int active, string lastUpdatedBy)
        {

        }

        public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;





        /// <summary>
        /// this method inserts customer data in to the database
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int insertCustomer(int userID)
        {
            string command = $"INSERT INTO customer (CustomerName, AddressID, " +
                $"Active, CreateDate, CreatedBy, LastUpdatedBy) " +
                $"Values('{customerName}', {AddressID}, {Active}, " +
                $"'{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}', '{userID}', '{userID}')";
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
                            CustomerID = Convert.ToInt32(cmd.LastInsertedId);
                            Console.WriteLine($"Insertion Successful Customer Id: {CustomerID}");
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
            return CustomerID;
        }


        /// <summary>
        /// this method gets customer data from the database using the customer ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public int getCustomerData(int customerId)
        {
            CustomerID = customerId;
            string command = $"SELECT CustomerName, AddressID, Active FROM customer where CustomerId = {customerId}";

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

                                    CustomerName = dr["CustomerName"].ToString();
                                    AddressID = Convert.ToInt32(dr["AddressID"]);
                                    Active = Convert.ToSByte(dr["Active"]);

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

            return AddressID;
        }


        /// <summary>
        /// This method gets the customer information for the customers table 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataTable getCustomersforTable(int userID)
        {



            DataTable customers = new DataTable();


            string command = $"SELECT c.CustomerID as CustomerID, c.CustomerName as Name , c.Active as 'Active', a.Address as 'Address'," +
               $" a.Address2 as 'Address 2', a.PostalCode as 'Postal Code', a.Phone as 'Phone', ci.CityName as 'City', co.CountryName as 'Country'" +
               $"FROM customer c right join address a on c.AddressID = a.AddressID " +
               $"right join city ci on a.CityId = ci.CityId " +
               $"right join country co on co.CountryId = ci.CountryId " +
               $"where c.CreatedBy = '{userID}'";



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
        public void updateCustomer(int userID)
        {
            string command = $"UPDATE customer SET CustomerName = '{CustomerName}', Active ={Active}," +
                $" LastUpdatedBy = '{userID}' WHERE CustomerID = {CustomerID }";

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
            string command2 = $"DELETE from appointment where CustomerID ={CustomerID}";

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


            // delete from weakest table to strongest table
            string command = $"DELETE c, ad from customer c inner join address ad on c.AddressID = ad.AddressID where c.CustomerID = {CustomerID}";

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

        public DataTable searchCustomers(string name)
        {
            DataTable customers = new DataTable();


            string command = $"SELECT CustomerID, CustomerName, Active FROM customer WHERE CustomerName LIKE '{name}' ";



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
                        Console.WriteLine($"Search Users Error: {ex.Message.ToString()}");
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
    }
}






