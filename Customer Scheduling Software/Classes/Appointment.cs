using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;


namespace Consultant_Scheduling_Mushero
{
   public class Appointment
    {

        private int customerID;
        private int userID;
        private int appointmentId;
        private string title;
        private string description;
        private string location;
        private string contact;
        private string type;
        private string url;
        private DateTime start;
        private DateTime end;
        private string createdBy;
        private string lastUpdatedBy;



        public int CustomerID
        {
            get; set;
        }
        public int UserID
        {
            get; set;
        }
        public int AppointmentID
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public string Location
        {
            get; set;
        }
        public string Contact
        {
            get; set;
        }
        public string Type
        {
            get; set;
        }
        public string Url
        {
            get; set;
        }
        public DateTime Start
        {
            get; set;
        }
        public DateTime End
        {
            get; set;
        }

        public int CreatedBy
        {
            get; set;
        }

        public int LastUpdatedBy
        {
            get; set;
        }


        public Appointment()
        {

        }

        public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;




        /// <summary>
        /// This method creates an appointment and inserts it into the database
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool Create_Appointment(int userID)
        {
            bool appointmentCreated = false;
            string command = $"INSERT INTO Appointment(CustomerID, UserID, Title, Description, Location, Contact, Type, Url, Start, End, CreateDate, CreatedBy, LastUpdatedBy)" +
                $"VALUES('{CustomerID}', '{UserID}', '{Title}', '{Description}','{Location}','{Contact}', '{Type}', '{Url}', '{Start.ToString("yyyy-MM-dd H:mm")}', '{End.ToString("yyyy-MM-dd H:mm")}', '{DateTime.Now.ToString("yyyy-MM-dd H:mm")}','{userID}','{userID}')";


            try
            {
                using (MySqlConnection cnn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                    {

                        try
                        {
                            cnn.Open();

                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                appointmentCreated = true;

                            }


                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            Console.WriteLine("Create Appointment: Error " + ex.Number + " \nMessage: " + ex.Message);
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

            return appointmentCreated;
        }


        /// <summary>
        /// this method gets the appointments under the current user id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>

        public DataTable getAppointments(int userID)
        {
            string command = "SELECT * FROM Appointment a WHERE UserID = " + userID + " order by Start asc";

            DataTable appointments = new DataTable();
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {

                    try
                    {
                        cnn.Open();

                        appointments.Load(cmd.ExecuteReader());

                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("get_Appointment(): ->Error " + ex.Number + " \nMessage: " + ex.Message); ;
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }

                }


            }

            return appointments;
        }

        /// <summary>
        /// this method updates the appointment that is being modified.
        /// </summary>
        /// <returns></returns>
        public bool Update_Appointment()
        {

            bool aptUpdated = false;

            string command = $"UPDATE Appointment a SET a.Title = '{Title}',  " +
                $"a.Description = '{Description}',  " +
                $"a.Location = '{Location}', " +
                $"a.Contact = '{Contact}', " +
                $"a.Type = '{Type}', " +
                $"a.Url = '{Url}', " +
                $"a.Start ='{Start.ToString("yyyy-MM-dd H:mm:ss")}', " +
                $"a.End = '{End.ToString("yyyy-MM-dd H:mm:ss")}', " +
                $"a.lastUpdatedBy = '{LastUpdatedBy}'" +
                $" where a.AppointmentID = {AppointmentID}; ";

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {
                    cnn.Open();

                    try
                    {

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            aptUpdated = true;
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("Update_Appointment(): ->Error " + ex.Number + " \nMessage: " + ex.Message);
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }
            return aptUpdated;
        }


        /// <summary>
        /// this method deletes the appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        public void Delete_Appointment(int appointmentId)
        {
            string command = "DELETE FROM Appointment WHERE AppointmentID =" + appointmentId + "";


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
                        Console.WriteLine("Delete_Appointment: Error " + ex.Number + " \nMessage: " + ex.Message);
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }


                }
            }
        }



        /// <summary>
        /// this method gets the currently selected appointment by ID
        /// </summary>
        /// <param name="appointmentID"></param>
        public void Get_Selected_Appointment(int appointmentID)
        {
            DataTable appointmentData = new DataTable();
            string sql = $"SELECT * FROM Appointment WHERE AppointmentID = {appointmentID}";
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, cnn))
                {
                    try
                    {
                        cnn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            appointmentData.Load(reader);
                        }

                        foreach (DataRow dr in appointmentData.Rows)
                        {
                            AppointmentID = Convert.ToInt32(dr["AppointmentID"]);
                            CustomerID = Convert.ToInt32(dr["CustomerID"]);
                            UserID = Convert.ToInt32(dr["UserID"]);
                            Title = Convert.ToString(dr["Title"]);
                            Description = Convert.ToString(dr["Description"]);
                            Location = Convert.ToString(dr["Location"]);
                            Contact = Convert.ToString(dr["Contact"]);
                            Type = Convert.ToString(dr["Type"]);
                            Url = Convert.ToString(dr["Url"]);
                            Start = Convert.ToDateTime(dr["Start"]);
                            End = Convert.ToDateTime(dr["End"]);
                            Start.Add(getCurrentOffset());
                            End.Add(getCurrentOffset());

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }
            }
        }

        /// <summary>
        ///  this method gets the current time span offset for current timezone vs gmt
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
        /// This method checks to see if an appointment is being modified within the restrictions
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>

        public int checkAvailability(DateTime start, DateTime end)
        {


            string sql = $"SELECT count(*) from Appointment where (Start <= '{start.Add(getCurrentOffset()).ToString("yyyy-MM-dd H:mm:ss")}' and End >= '{end.Add(getCurrentOffset()).ToString("yyyy-MM-dd H:mm:ss")}') or " +
                $"(Start <= '{end.Add(getCurrentOffset()).ToString("yyyy-MM-dd H: mm: ss")}' and End >= '{start.Add(getCurrentOffset()).ToString("yyyy-MM-dd hh:mm:ss")}') " +
                $"or (Start >= '{start.Add(getCurrentOffset()).ToString("yyyy-MM-dd H:mm:ss")}' and End <= '{end.Add(getCurrentOffset()).ToString("yyyy-MM-dd hh:mm:ss")}')";


            int count = 0;

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, cnn))
                {
                    cnn.Open();

                    try
                    {
                        count = int.Parse(cmd.ExecuteScalar().ToString());



                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("Check Availability: Error " + ex.Number + " \nMessage: " + ex.Message);
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }

            return count;

        }
        /// <summary>
        /// this method is used to search for appointments within business hours
        /// </summary>
        /// <param name="searchDate"></param>
        /// <returns></returns>

        public DataTable AppointmentSearch(DateTime searchDate)
        {
            string formattedDate = searchDate.Date.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss");
            string formattedDatePlustwelve = searchDate.Date.AddHours(10).ToString("yyyy-MM-dd HH:mm:ss");
            string command = $"SELECT * FROM Appointment a WHERE Start Between '{formattedDate}' and '{formattedDatePlustwelve} ' order by Start asc";

            DataTable appointments = new DataTable();
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {

                    try
                    {
                        cnn.Open();
                        appointments.Load(cmd.ExecuteReader());

                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine("AppointmentSearch(): ->Error " + ex.Number + " \nMessage: " + ex.Message); ;
                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }

                }


            }

            return appointments;
        }
    }
}
