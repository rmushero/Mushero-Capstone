using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows.Forms;


namespace Consultant_Scheduling_Mushero
{
    public partial class CalendarVw : Form
    {
        User currentUser = new User();
        Appointment tempAppointment = new Appointment();
        DataTable appointments = new DataTable();
        DataTable MonthAppointments = new DataTable();
        int weekOfTheYear;
        DataTable weeklyDataTable;
        DataTable monthlyDataTable;


        public CalendarVw(User user)
        {
            InitializeComponent();
            currentUser = user;
            MonthAppointments = tempAppointment.getAppointments(currentUser.UserID);
        
            setMonthlyCalendar();

           
            calendarManipulation();


        }
        public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;


        private void AppointmentsForDay(DateTime date)
        {
            apptDataGridView.DataSource = tempAppointment.AppointmentSearch(date);
        }
       

        /// <summary>
        /// populates a data table with this months dates and appointments
        /// </summary>
        private void setMonthlyCalendar()
        {


            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);

            monthlyDataTable = new DataTable();
            monthlyDataTable.Columns.Add("Start");

            foreach (DataRow row in MonthAppointments.Rows)
            {
                if (Convert.ToDateTime(row["Start"]) >= first || Convert.ToDateTime(row["Start"]) <= last)
                {
                    monthlyDataTable.Rows.Add(row["Start"]);
                    monthCalendar.AddBoldedDate(Convert.ToDateTime(row["Start"]));
                }
            }




        }



        /// <summary>
        /// this method gets the current week of year and creates the weekly calendar 
        /// </summary>
        private void calendarManipulation()
        {
            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;


            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            weekOfTheYear = myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW);
           
        }



        




        /// <summary>
        /// this method closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            appointments.Clear();
            DateTime tempDate = monthCalendar.SelectionStart.Date;
            Console.WriteLine(tempDate);
            AppointmentsForDay(tempDate);
            
            

        }
    }
}
