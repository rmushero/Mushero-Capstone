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
    public partial class Dashboard : Form
    {

        User CurrentUser = new User();

        List<Appointment> appointments = new List<Appointment>();
        List<Customer> customers = new List<Customer>();
        List<Address> addresses = new List<Address>();
        List<City> cities = new List<City>();
        List<Country> countries = new List<Country>();

       
        

      //  public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public Dashboard(User _user, string username)
        {

            InitializeComponent();
            CurrentUser = _user;
            CurrentUser.Username = username;

            custTableRefresh();
            aptTableRefresh();

        }



        // Data Activity


        public void checkAppointmentSoon(int id)
        {
            DateTime rightNow = DateTime.Now;
            foreach(Appointment apt in appointments)
            {
                if (Convert.ToDateTime(apt.Start) == rightNow.AddMinutes(15))
                {
                    MessageBox.Show("You have an appointment in 15 minutes");
                }
            }

        }


        // Form Interactions

        private void exitAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers launch = new Customers(CurrentUser.Username);
            launch.Show();
            this.Show();
            custTableRefresh();
            aptTableRefresh();

        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }

        private void addAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(CurrentUser.UserID.ToString());
            new Appointments(CurrentUser).Show();
            custTableRefresh();
            aptTableRefresh();


        }



        private void modifyCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customerTable.Rows.Count >= 1)
            {
                int selectedrowindex = customerTable.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = customerTable.Rows[selectedrowindex];
                int id = Int32.Parse(selectedRow.Cells["ID"].Value.ToString());
                const string message = "Would you like to Edit this information?";
                string caption = $"Edit User?{id}";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {


                }
                else
                {
                    if (customerTable.SelectedCells.Count > 0)
                    {


                        Customers updateCustomer = new Customers(CurrentUser.Username, id);
                        updateCustomer.Show();
                        custTableRefresh();
                        aptTableRefresh();
                        this.Show();


                    }
                }
            }
           
        }

        private void modifyAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (appointmentTable.Rows.Count >= 1)
            {
                int selectedrowindex = appointmentTable.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = appointmentTable.Rows[selectedrowindex];
                int id = Int32.Parse(selectedRow.Cells["appointmentId"].Value.ToString());
                const string message = "Would you like to modify this appointment?";
                string caption = "Edit appointment? " + id + "";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {


                }
                else
                {
                    if (appointmentTable.SelectedCells.Count > 0)
                    {


                        Appointments modifyAppointment = new Appointments(id, CurrentUser);
                        modifyAppointment.Show();
                        custTableRefresh();
                        aptTableRefresh();
                       
                        this.Show();


                    }
                }
            }
            else
            {

            }
        }



      

        public void deleteAppointment(int aptId)
        {
           
        }

        public void custTableRefresh()
        {
            DataTable temp = new DataTable();
            Customer customer = new Customer();
           temp = customer.getCustomersforTable(CurrentUser.Username);


           

           customerTable.DataSource = temp;
            

           
            customerTable.Update();
            customerTable.Refresh();
        }
        public void aptTableRefresh()
        {
            DataTable temp = new DataTable();
            Appointment appointment = new Appointment();
            temp = appointment.getAppointments(CurrentUser.UserID); ;
           

            appointmentTable.DataSource = temp;
            appointmentTable.Update();
            appointmentTable.Refresh();
        }
        private void calendarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void testCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers testCust = new Customers(CurrentUser.Username, "OK");
            custTableRefresh();
            aptTableRefresh();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports reportWindow = new Reports();
            reportWindow.Show();
            custTableRefresh();
            aptTableRefresh();
            this.Show();
        }

        // TODO: Fix Delete Appointments
        private void deleteAppointmentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (appointmentTable.Rows.Count >= 1)
            {
                int selectedrowindex = appointmentTable.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = appointmentTable.Rows[selectedrowindex];
                int id = Int32.Parse(selectedRow.Cells["appointmentId"].Value.ToString());
                const string message = "Would you like to deleted this appointment?";
                string caption = "Delete Appointment?";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {


                }
                else
                {
                    Appointment appointment = new Appointment();
                    appointment.Delete_Appointment(id);
                    aptTableRefresh();
                    custTableRefresh();
                }
            }
        }


        // This works
        private void genericAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appointments testAppointment = new Appointments(CurrentUser.Username, "OK");
            custTableRefresh();
            aptTableRefresh();
        }


        // This works now 
        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( customerTable.Rows.Count >= 1)
            {
                int selectedrowindex = customerTable.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = customerTable.Rows[selectedrowindex];
                int id = Int32.Parse(selectedRow.Cells["ID"].Value.ToString());
                const string message = "Would you like to deleted this customer?";
                string caption = "Delete Customer?";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {


                }
                else
                {
                    Customer customer = new Customer();
                    customer.deleteCustomer(id);
                    custTableRefresh();
                    aptTableRefresh();
                }
            }
        }


        // This works
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aptTableRefresh();
            custTableRefresh();
        }

    }
}
