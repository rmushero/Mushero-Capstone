using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


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

            System.Timers.Timer timer = new System.Timers.Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(checkAppointmentSoon);
            timer.Start();

        }

        /// <summary>
        /// This method gets the current time difference between current location and GMT
        /// </summary>
        /// <returns></returns>
        public TimeSpan getCurrentOffset()
        {
            // Initialize the offset to convert analyzed meetings to current local
            // This is the current time
            DateTime rightNow = DateTime.Now;
            TimeSpan offset;
            offset = TimeZone.CurrentTimeZone.GetUtcOffset(rightNow);
            return offset;

        }



        /// <summary>
        /// This method periodically checks if there is an appointment within the next 15 minutes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void checkAppointmentSoon(object sender, System.Timers.ElapsedEventArgs e)
        {

            TimeSpan offset = getCurrentOffset();

            // This is the time in 15 minutes
            DateTime soon = DateTime.Now.AddMinutes(15);

            foreach (DataRow apt in appointments.Rows)
            {

                DateTime appointmentTime = Convert.ToDateTime(apt["Start"]);
                appointmentTime = appointmentTime - offset;


                if (appointmentTime.ToString("yyyy-mm-dd hh:mm") == soon.ToString("yyyy-mm-dd hh:mm"))
                {
                    string title = apt["Title"].ToString();
                    string message = $"You have an appointment at {Convert.ToDateTime(apt["Start"]).Add(getCurrentOffset())}";

                    MessageBox.Show(message, title);

                }
                else
                {

                }
            }
        }

        // Form Interactions


        /// <summary>
        /// This closes the program when the form is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }

        /// <summary>
        /// this closes the program when the exit button is used 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// This launches the customer form which allows users to add a new customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CustomerForm launch = new CustomerForm(CurrentUser.UserID);
            launch.Show();
            this.Show();

        }

        /// <summary>
        /// This launches the appointment form which allows users to create new appointments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new AppointmentForm(CurrentUser).Show();

            this.Show();

        }


        /// <summary>
        /// this method is used to launch a modified version of the customer form, this form will contain all the data for the
        /// selected customer for modifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customerTable.Rows.Count >= 1)
            {
                int selectedrowindex = customerTable.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = customerTable.Rows[selectedrowindex];
                int id = Int32.Parse(selectedRow.Cells["CustomerID"].Value.ToString());
                const string message = "Would you like to Edit this information?";
                string caption = $"Edit User?";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {

                }
                else
                {
                    if (customerTable.SelectedCells.Count > 0)
                    {

                        CustomerForm updateCustomer = new CustomerForm(CurrentUser.Username, id);
                        updateCustomer.Show();

                    }
                }
            }

           ;
            this.Show();

        }


        /// <summary>
        /// This method calls the modification form for the appointments 
        /// it passes the data from the datatable to the form which presents the appointment 
        /// data for modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (appointmentTable.Rows.Count >= 1)
            {
                int selectedrowindex = appointmentTable.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = appointmentTable.Rows[selectedrowindex];
                int id = Int32.Parse(selectedRow.Cells["AppointmentID"].Value.ToString());
                const string message = "Would you like to modify this appointment?";
                string caption = "Edit appointment?";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {

                }
                else
                {
                    if (appointmentTable.SelectedCells.Count > 0)
                    {

                        AppointmentForm modifyAppointment = new AppointmentForm(id, CurrentUser);
                        modifyAppointment.Show();

                    }
                }
            }
            else
            {

            }

            this.Show();
        }


        /// <summary>
        /// This method refreshes the customer tabl
        /// </summary>
        public void custTableRefresh()
        {
            DataTable temp = new DataTable();
            Customer customer = new Customer();
            temp = customer.getCustomersforTable(CurrentUser.UserID);
            customerTable.DataSource = temp;
            customerTable.Update();
            customerTable.Refresh();
        }

        /// <summary>
        /// this method refreshes the appointment table
        /// </summary>
        public void aptTableRefresh()
        {

            Appointment appointment = new Appointment();
            appointments = appointment.getAppointments(CurrentUser.UserID);
            appointmentTable.DataSource = appointments;
            appointmentTable.Update();
            appointmentTable.Refresh();
        }

        /// <summary>
        /// This launches the calendar view 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalendarVw newView = new CalendarVw(CurrentUser);

            newView.Show();
            refreshTables();
            this.Show();

        }

        /// <summary>
        /// This launches the reports form 
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



        /// <summary>
        /// this method deletes the currently selected appointment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAppointmentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (appointmentTable.Rows.Count >= 1)
            {
                int selectedrowindex = appointmentTable.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = appointmentTable.Rows[selectedrowindex];
                int id = Int32.Parse(selectedRow.Cells["AppointmentID"].Value.ToString());
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

        /// <summary>
        /// this method deletes the currently selected customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customerTable.Rows.Count >= 1)
            {
                int selectedrowindex = customerTable.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = customerTable.Rows[selectedrowindex];
                int id = Int32.Parse(selectedRow.Cells["CustomerID"].Value.ToString());
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

        /// <summary>
        /// this method refreshes both tables
        /// </summary>
        public void refreshTables()
        {
            aptTableRefresh();
            custTableRefresh();
        }

        /// <summary>
        /// this method calls the refreshTables() method when the refresh button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            refreshTables();
        }

        private void custRefBtn_Click(object sender, EventArgs e)
        {
            refreshTables();
        }

        private void custSrchBtn_Click(object sender, EventArgs e)
        {
            string searchStrinng = customerSrchBox.Text;
            Customer customer = new Customer();
            customerTable.DataSource = customer.searchCustomers(searchStrinng);
            customerTable.Update();
            customerTable.Refresh();



        }

        private void aptSrcBtn_Click(object sender, EventArgs e)
        {

            DateTime searchTime = aptPicker.Value.Date;
            Appointment appointment = new Appointment();
            appointmentTable.DataSource = appointment.AppointmentSearch(searchTime);
            appointmentTable.Update();
            appointmentTable.Refresh();




        }
    }
}