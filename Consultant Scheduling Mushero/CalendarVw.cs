using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace Consultant_Scheduling_Mushero
{
    public partial class CalendarVw : Form
    {
        User currentUser = new User();
        
        DataTable appointments = new DataTable();
        int weekOfTheYear;
        DataTable weeklyDataTable;
        DataTable monthlyDataTable;


        public CalendarVw(User user)
        {
            InitializeComponent();
            currentUser = user;
            appointments = currentUser.getAppointments();
            weekCalendar();
            setMonthlyCalendar();
            
            apptDataGridView.DataSource = appointments;
            calendarManipulation();
           

        }
        public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;


        

        public void weekCalendar()
        {
          

            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(7);

           
            weeklyDataTable = new DataTable();

            weeklyDataTable.Columns.Add("title");
            weeklyDataTable.Columns.Add("start");
            weeklyDataTable.Columns.Add("end");

            foreach(DataRow row in appointments.Rows)
            {
                if (Convert.ToDateTime(row["start"]) >= startOfWeek || Convert.ToDateTime(row["end"]) <= endOfWeek)
                {
                    weeklyDataTable.Rows.Add(row["title"], row["start"], row["end"]);
                }
            }






        }


        private void setMonthlyCalendar()
        {
           

            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);

            monthlyDataTable = new DataTable();
            monthlyDataTable.Columns.Add("start");
           
            foreach (DataRow row in appointments.Rows)
            {
                if (Convert.ToDateTime(row["start"]) >= first || Convert.ToDateTime(row["start"]) <= last)
                {
                    monthlyDataTable.Rows.Add(row["start"]);
                    monthCalendar.AddBoldedDate(Convert.ToDateTime(row["start"]));
                }
            }

           


        }



        private void calendarManipulation()
        {
            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;


            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            weekOfTheYear = myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW);
            setWeeklyCalendar();
        }


        private void setWeeklyCalendar()
        {
            DataTable newWeeklyDataTable = new DataTable();

            //If column does not exist, add column.
            if (!newWeeklyDataTable.Columns.Contains("SUN")) { newWeeklyDataTable.Columns.Add("SUN", typeof(string)); }
            if (!newWeeklyDataTable.Columns.Contains("MON")) { newWeeklyDataTable.Columns.Add("MON", typeof(string)); }
            if (!newWeeklyDataTable.Columns.Contains("TUE")) { newWeeklyDataTable.Columns.Add("TUE", typeof(string)); }
            if (!newWeeklyDataTable.Columns.Contains("WED")) { newWeeklyDataTable.Columns.Add("WED", typeof(string)); }
            if (!newWeeklyDataTable.Columns.Contains("THU")) { newWeeklyDataTable.Columns.Add("THU", typeof(string)); }
            if (!newWeeklyDataTable.Columns.Contains("FRI")) { newWeeklyDataTable.Columns.Add("FRI", typeof(string)); }
            if (!newWeeklyDataTable.Columns.Contains("SAT")) { newWeeklyDataTable.Columns.Add("SAT", typeof(string)); }
            weeklyDataGridView.DataSource = newWeeklyDataTable;


            DataRow dataRow;

            foreach (DataRow row in weeklyDataTable.Rows)
            {
                DateTime tempStart;
                tempStart = Convert.ToDateTime(row["start"]);


                switch (tempStart.DayOfWeek.ToString())
                {
                    case "Sunday":
                        dataRow = newWeeklyDataTable.Rows.Add();
                        dataRow[0] = row["Title"];
                        break;

                    case "Monday":
                        dataRow = newWeeklyDataTable.Rows.Add();
                        dataRow[1] = row["Title"];
                        break;
                    case "Tuesday":
                        dataRow = newWeeklyDataTable.Rows.Add();
                        dataRow[2] = row["Title"];
                        break;
                    case "Wednesday":
                        dataRow = newWeeklyDataTable.Rows.Add();
                        dataRow[3] = row["Title"];
                        break;
                    case "Thursday":
                        dataRow = newWeeklyDataTable.Rows.Add();
                        dataRow[4] = row["Title"];
                        break;
                    case "Friday":
                        dataRow = newWeeklyDataTable.Rows.Add();
                        dataRow[5] = row["Title"];
                        break;
                    case "Saturday":
                        dataRow = newWeeklyDataTable.Rows.Add();
                        dataRow[6] = row["Title"];
                        break;
                }

            }
        }


            
         
   

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        
        private void prevWeekButton_Click_1(object sender, EventArgs e)
        {
            if (weekOfTheYear > 0)
            {
                weekOfTheYear--;
                weekLabel.Text = "Week " + weekOfTheYear;
            }
            weeklyDataTable.Clear();
            setWeeklyCalendar();
        }

        private void nextWeekButton_Click_1(object sender, EventArgs e)
        {
            if (weekOfTheYear < 53)
            {
                weekOfTheYear++;
                weekLabel.Text = "Week " + weekOfTheYear;
            }
            weeklyDataTable.Clear();
            setWeeklyCalendar();
        }

        
    }
}
