using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace Consultant_Scheduling_Mushero
{
    public partial class Reports : Form
    {

        public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public Reports()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method shows each appointment by month name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportOneBtn_Click(object sender, EventArgs e)
        {
            string command = "SELECT MONTHNAME(start) AS MONTH,COUNT(appointmentId) AS 'Appointments' from Appointment group by MONTH";
            runReport(command);


        }

        /// <summary>
        /// this method takes in a command and outputs the result to a datatable
        /// </summary>
        /// <param name="command"></param>
        private void runReport(string command)
        {
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

        /// <summary>
        /// This method shows the schedule for Each consultant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportTwoBtn_Click(object sender, EventArgs e)
        {
            string command = "select UserName, count(AppointmentID) as 'Count' from Appointment right join User on Appointment.UserID = User.UserID where Appointment.UserID > 0 group by UserName";
            runReport(command);
        }

        /// <summary>
        /// This method returns the number of customers by user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportThreeBtn_Click(object sender, EventArgs e)
        {
            string command = "select  CreatedBy as 'Created By', count(CustomerID) as 'Total Customers'from Customer where CreatedBy is not null " +
              "group by CreatedBy";

            runReport(command);


        }

        /// <summary>
        /// This method closes the form when the exit buton is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}