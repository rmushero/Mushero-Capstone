using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Consultant_Scheduling_Mushero
{
    public partial class Reports : Form
    {

        public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public Reports()
        {
            InitializeComponent();
        }

        private void reportOneBtn_Click(object sender, EventArgs e)
        {
            string command = "select createdBy, count(*) from customer Group By customer.createdBy";

            DataTable returnedResults = null;

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        try
                        {
                            returnedResults = new DataTable();
                            da.Fill(returnedResults);
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

            reportsView.DataSource = returnedResults;
            reportsView.Refresh();
        }

        private void reportTwoBtn_Click(object sender, EventArgs e)
        {
            string command = "select createdBy as 'User', count(*) as 'Customers' from customer Group By customer.createdBy";

            DataTable returnedResults = null;

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        try
                        {
                            returnedResults = new DataTable();
                            da.Fill(returnedResults);
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

        private void reportThreeBtn_Click(object sender, EventArgs e)
        {

        }

       
    }
}
