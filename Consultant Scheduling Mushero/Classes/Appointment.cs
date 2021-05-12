using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;


namespace Consultant_Scheduling_Mushero
{
    class Appointment
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
        private string lastUpdateBy;

    

        public int CustomerID
        {
            get; set;
        }
        public int UserID
        {
            get; set;
        }
        public int AppointmentId
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

        public string CreatedBy
        {
            get; set;
        }

        public string LastUpdateBy
        {
            get; set;
        }


        public Appointment()
        {

        }

        public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;



        public bool Create_Appointment(string username)
        {
            bool appointmentCreated = false;
            string command = $"INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy)" +
                $"VALUES('{CustomerID}', '{UserID}', '{Title}', '{Description}','{Location}','{Contact}', '{Type}', '{Url}', '{Start.ToString("yyyy-MM-dd H:mm:ss")}', '{End.ToString("yyyy-MM-dd H:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}','{username }','{username}')";

            
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


        // Get appointments

        public DataTable getAppointments(int userID)
        {
            string command = "SELECT * FROM appointment a WHERE userId = " + userID + " order by start asc";

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


        public bool Update_Appointment()
        {

            bool aptUpdated = false;

            string command = $"UPDATE appointment SET appointment.title = '{Title}',  " +
                $"appointment.description = '{Description}',  " +
                $"appointment.location = '{Location}', " +
                $"appointment.contact = '{Contact}', " +
                $"appointment.type = '{Type}', " +
                $"appointment.url = '{Url}', " +
                $"appointment.start ='{Start.ToString("yyyy-MM-dd H:mm:ss")}', " +
                $"appointment.end = '{End.ToString("yyyy-MM-dd H:mm:ss")}', " +
                $"appointment.lastUpdateBy = '{LastUpdateBy}'" +
                $" where appointment.appointmentId = {AppointmentId}; ";

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

        public void Delete_Appointment(int appointmentId)
        {
            string command = "DELETE FROM appointment WHERE appointmentId =" + appointmentId + "";


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

        public void Get_Selected_Appointment(int appointmentID)
        {
            DataTable appointmentData = new DataTable();
            string sql = $"SELECT * FROM appointment WHERE appointmentId = {appointmentID}";
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
                            AppointmentId = Convert.ToInt32(dr["appointmentId"]);
                            CustomerID = Convert.ToInt32(dr["customerId"]);
                            UserID = Convert.ToInt32(dr["userId"]);
                            Title = Convert.ToString(dr["title"]);
                            Description = Convert.ToString(dr["description"]);
                            Location = Convert.ToString(dr["location"]);
                            Contact = Convert.ToString(dr["contact"]);
                            Type = Convert.ToString(dr["type"]);
                            Url = Convert.ToString(dr["url"]);
                            Start = Convert.ToDateTime(dr["start"]);
                            End = Convert.ToDateTime(dr["end"]);

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }
            }
        }


        public int checkAvailability(DateTime start, DateTime end)
        {
           

            string sql =$"SELECT count(*) from appointment where (start <= '{start.ToString("yyyy-MM -dd H:mm:ss")}' and end >= '{end.ToString("yyyy-MM-dd H:mm:ss")}') or " +
                $"(start <= '{end.ToString("yyyy-MM-dd H: mm: ss")}' and end >= '{start.ToString("yyyy-MM-dd hh:mm:ss")}') " +
                $"or (start >= '{start.ToString("yyyy-MM-dd H:mm:ss")}' and end <= '{end.ToString("yyyy-MM-dd hh:mm:ss")}')";
           

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
    }
}
