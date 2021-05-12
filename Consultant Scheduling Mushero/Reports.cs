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


        // Select appointments by month 
        private void reportOneBtn_Click(object sender, EventArgs e)
        {
            string command = "SELECT MONTHNAME(start) AS MONTH,COUNT(appointmentId) AS 'Appointments' from appointment group by MONTH";


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


        // Schedule for Each consultant
        private void reportTwoBtn_Click(object sender, EventArgs e)
        {
            string command = "select userName, count(appointmentId) as 'Count' from appointment right join user on appointment.userId = user.userId where appointment.userId > 0 group by userName";

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


        // Number of customers per consultant
        private void reportThreeBtn_Click(object sender, EventArgs e)
        {
            string command = "select  createdBy as 'Created By', count(customerId) as 'Total Customers'from customer where createdBy is not null " +
                "group by createdBy";

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

            reportsView.DataSource = returnedResults;
            reportsView.Refresh();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
