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

        public List<Appointment> appointmentsLst = new List<Appointment>();

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
                $"VALUES('{CustomerID}', '{UserID}', '{Title}', '{Description}','{Location}','{Contact}', '{Type}', '{Url}', {Start}, {End}, now(),'{username }','{username}')";

            int rowsAffected;
            try
            {
                using (MySqlConnection cnn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                    {

                        try
                        {
                            cnn.Open();
                            rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                appointmentCreated = true;

                            }


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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return appointmentCreated;
        }


        // Get appointments

        public void getAppointments(int userID)
        {
            string command = "SELECT * FROM appointment a WHERE userId = " + userID + " order by start asc";


            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {

                    try
                    {
                        cnn.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Appointment appointment = new Appointment();
                                    appointment.AppointmentId = Convert.ToInt32(reader["appointmentId"]);
                                    appointment.UserID = Convert.ToInt32(reader["userId"]);
                                    appointment.CustomerID = Convert.ToInt32(reader["customerId"]);
                                    appointment.Title = reader["title"].ToString();
                                    appointment.Description = reader["description"].ToString();
                                    appointment.Location = reader["location"].ToString();
                                    appointment.Contact = reader["contact"].ToString();
                                    appointment.Type = reader["type"].ToString();
                                    appointment.Url = reader["url"].ToString();
                                    appointment.Start = Convert.ToDateTime(reader["start"]);
                                    appointment.End = Convert.ToDateTime(reader["end"]);
                                    appointment.CreatedBy = reader["createdBy"].ToString();
                                    appointment.LastUpdateBy = reader["lastUpdateBy"].ToString();
                                    appointmentsLst.Add(appointment);
                                }
                            }

                        }

                        cnn.Close();
                        cnn.Dispose();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }

                }


            }
        }


        public bool Update_Appointment()
        {

            bool aptUpdated = false;

            string command = $"UPDATE appointment SET appointment.title = {title},  " +
                $"appointment.description = {description},  " +
                $"appointment.location = {location}, " +
                $"appointment.contact = {contact}, " +
                $"appointment.type = {type}, " +
                $"appointment.url = {url}, " +
                $"appointment.start = {start}, " +
                $"appointment.end = {end}, " +
                $"appointment.lastUpdateBy = {lastUpdateBy}" +
                $" where appointment.appointmentId = {appointmentId}; ";

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
            string sql = "SELECT COUNT(appointmentId)FROM appointment WHERE START BETWEEN '" + Start + "' AND '" + End + "';";

            int count = 0;

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, cnn))
                {
                    cnn.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();


                        count = int.Parse(cmd.ExecuteScalar().ToString());


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

            return count;

        }
    }
}
