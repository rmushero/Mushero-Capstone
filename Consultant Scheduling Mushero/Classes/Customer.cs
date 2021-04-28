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

       // public List<Customer> customers = new List<Customer>();


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

        public bool checkCustomerExist(string customerName, string address1)
        {

            bool exists = false;


            string command = "SELECT customerId, customer.active FROM customer WHERE customer.customerName = '" + customerName + "\' ";

            try
            {
                using (MySqlConnection cnn = new MySqlConnection(connectionString))
                {

                    using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                    {
                        cnn.Open();


                        // run query 
                        cmd.ExecuteNonQuery();

                        var custId = int.Parse(cmd.Parameters["customerId"].Value.ToString());

                        var isActive = int.Parse(cmd.Parameters["active"].Value.ToString());

                        if (custId > 0 && isActive > 0)
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

        // CREATE 
        public int InsertCustomer(string username)
        {
            string command = $"INSERT INTO customer (customerName, addressId, " +
                $"active, createDate, createdBy, lastUpdateBy) " +
                $"Values('{customerName}', {AddressId}, {active}, " +
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

        public int getLastId()
        {
            string command = "SELECT last_insert_id()";
            int id = 0;

            try
            {
                using (MySqlConnection cnn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                    {
                        try
                        {
                            cnn.Open();

                            id = Convert.ToInt32(cmd.ExecuteScalar());

                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            Console.WriteLine("Error " + ex.Number + " \nMessage: " + ex.Message);
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
            return id;

        }

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
                        cnn.Close();
                        cnn.Dispose();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }

                }



            }
            return customers;
        }





        // UPDATE 
        public void UpdateCustomer(string Username)
        {
            string command = "UPDATE customer SET customerName = " + CustomerName + "\', active =" + active + ", lastUpdateBy = '" + Username + " \' WHERE customerId = " + CustomerId + "";

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

        public int deleteCustomer(int CustomerID)
        {
            int deleted = 0;
            string command = "DELETE from appointment where customerId =" + CustomerID + "";

            string command2 = "DELETE c, ad, ct, ctry " +
                "from customer c " +
                "inner join address ad on c.addressId = ad.addressID " +
                "inner join city ct on ad.cityId = ct.cityId " +
                "inner join country ctry on ct.countryId = ctry.countryId " +
                "where c.customerId = " + CustomerID + "";


            return deleted;

        }
        // DELETE
        public void deleteCustomerData(int CustomerID)
        {

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("deleteCustomer", cnn))
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

        public DataTable loadCustomerAppointments(int id)
        {

            DataTable table = new DataTable();
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("getCustomerAppointments", cnn))
                {
                    cnn.Open();


                    try
                    {

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            table.Load(reader);
                        }

                        cnn.Close();
                        cnn.Dispose();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                    return table;
                }
            }

        }



    }
}
