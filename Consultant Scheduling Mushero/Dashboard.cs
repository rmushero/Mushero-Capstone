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

        DataTable appointments = new DataTable();
       
        Dictionary<string, double> dataSource = new Dictionary<string, double>();






        public Dashboard(User _user, string username)
        {

            InitializeComponent();
            CurrentUser = _user;
            CurrentUser.Username = username;
            custTableRefresh();
            aptTableRefresh();
            var startTime = TimeSpan.Zero;
            var periodicTime = TimeSpan.FromMinutes(1);

            var timer = new System.Threading.Timer(e =>
                {
                    checkAppointmentSoon(CurrentUser.UserID);
                   
            }, null, startTime, periodicTime);
            

        }



        // Data Activity


        public void checkAppointmentSoon(int id)
        {
            DateTime rightNow = DateTime.Now;
            TimeSpan offset;
            offset = TimeZone.CurrentTimeZone.GetUtcOffset(rightNow);
            Console.WriteLine("It worked!");
            foreach(DataRow apt in appointments.Rows)
            {
                
              if (Convert.ToDateTime(apt["start"]).AddHours(Convert.ToDouble(offset)) == rightNow.AddMinutes(15))
                {
                    string title = apt["title"].ToString();
                    string message = $"You have an appointment at {apt["start"]}";
                    MessageBox.Show(title, message);

                }
            }


        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
          
            base.OnClosed(e);
            refreshTables();
        }


        // Form Interactions


        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }

        private void exitAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
            Customers launch = new Customers(CurrentUser.Username);
            launch.Show();
            this.Show();
         

        }

        

        private void addAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            new Appointments(CurrentUser).Show();
            
            this.Show();
            
            
            

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
                       
                        


                    }
                }
            }

           ;
            this.Show();

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
                       


                    }
                }
            }
            else
            {

            }
           
            this.Show();
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
            temp = appointment.getAppointments(CurrentUser.UserID);
            appointmentTable.DataSource = temp;
            appointmentTable.Update();
            appointmentTable.Refresh();
        }
        private void calendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalendarVw newView = new CalendarVw(CurrentUser);
           
            newView.Show();
            refreshTables();
            this.Show();
            
            
        }

      
      


        /// <summary>
        /// NEED TO FINISH REPORTS 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports reportWindow = new Reports();
            reportWindow.Show();
            refreshTables();
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
                    refreshTables();
                }
            }
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
                   
                }
            }

            refreshTables();


        }
        public void refreshTables()
        {
            aptTableRefresh();
            custTableRefresh();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            refreshTables();
        }
    }
}
