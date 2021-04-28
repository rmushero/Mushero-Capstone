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
    public partial class Appointments : Form
    {
        const string dataFmt = "{0,-30}{1}";
        User currentUser = new User();
        Dictionary<string, double> dataSource = new Dictionary<string, double>();
        Appointment newApt = new Appointment();
        DataTable customers = new DataTable();
        bool modificationMode = false;
        public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        /// <summary>
        /// New Appointment Form
        /// </summary>
        /// <param name="user"></param>
        public Appointments(User user)
        {
            populateLocations();
            // Set current user so we can get the customer list
            currentUser = user;
          
            InitializeComponent();
            customers = populateCustomer(currentUser.Username);
            customerSelection.DataSource = customers;
            customerSelection.DisplayMember = "customerName";
            customerSelection.ValueMember = "customerId";
            endDateTime.Value = startDateTime.Value.AddMinutes(30);
            

        }

        public Appointments(string username, string type)
        {
            InitializeComponent();
            currentUser.Username = username;
            createGenericApt();
        }

        // Modification Form 


        public Appointments(int id, User user)
        {
            InitializeComponent();
            // Set Modification
            modificationMode = true;
            // Populate Location List
            populateLocations();
            newApt.AppointmentId = id;
            currentUser = user;
            populateForm(newApt.AppointmentId);
            customers = populateCustomer(currentUser.Username);
            customerSelection.DataSource = customers;
            customerSelection.DisplayMember = "customerName";
            customerSelection.ValueMember = "customerId";
        }

        public DataTable populateCustomer(string username)
        {
            string command = "Select customerId, customerName from customer where createdBy = '" + username + "\'";

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

            return returnedResults;
        }

      


        public void populateForm(int appointmentID)
        {
            // Set the data for the appointment
            newApt.Get_Selected_Appointment(appointmentID);

            //Set the Title bot
            titleTxtBox.AppendText(Convert.ToString(newApt.Title));

            // Set the Description Box
            descriptionTxtBox.Text = newApt.Description.ToString();

            //Set the Location combo box
            locationComboBx.SelectedItem = newApt.Location.ToString();

            //Set Contact Box
            contactTxtBox.Text = newApt.Contact.ToString();

            //Set Type Box
            typeTxtBox.Text = newApt.Type.ToString();

            //Set URL Box
            urlTxtBox.Text = newApt.Url.ToString();

            //Set Start Time
         // startDateTime.Value = newApt.Start.ToString();

            //Set End Time
           // endDateTime.Value = newApt.End=ToString();
        }



        // EVENTS 

        private void populateLocations()
        {
            dataSource.Add("Phoenix, Arizona", -7);
            dataSource.Add("New York, New York", -5);
            dataSource.Add("London, England", 0);
        }

        /// <summary>
        /// Method for Action when Save Button is Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (validateForm() == true)
            {
                if(modificationMode == true)
                {
                    if (updateAppointment() == true)
                    {
                        string message = "Appointment Updated Created";
                        MessageBox.Show(message);
                    }

                }
                else
                {
                    if (createAppointment() == true)
                    {
                        string message = "Appointment Successfully Created";
                        MessageBox.Show(message);
                    }
                }

                


                
                this.Close();

            }
            else
            {
                string message = "Please enter all required information";
                MessageBox.Show(message);
            }

        }

        private void createGenericApt()
        {
            Appointment junkApt = new Appointment();

           
            junkApt.UserID = 1;
            junkApt.CustomerID = 8;
            junkApt.Title = "Automatically Generated Test Appointment";
            junkApt.Description = "Not needed";
            junkApt.Location = "New York, New York";
            junkApt.Contact = "test";
            junkApt.Type = "TEST";
            junkApt.Url = "test";
            junkApt.Start = DateTime.Now.AddMinutes(17);
            junkApt.End = DateTime.Now.AddMinutes(47);
            junkApt.CreatedBy = "test";
            junkApt.LastUpdateBy = "test";


            junkApt.Create_Appointment("test");
        }
        /// <summary>
        /// Method for action when cancel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cnclBtn_Click(object sender, EventArgs e)
        {

            const string message = "Are you sure you would like to close this form? \n No changes will be saved";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }


        /// <summary>
        /// Method to check when the start time changes. If it changes it will adjust the end time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void startDateTime_ValueChanged(object sender, EventArgs e)
        {
           
            endDateTime.Value = startDateTime.Value.AddMinutes(30);

            if (startDateTime.Value < DateTime.Now)
            {
                const string message = "You cannot create an appointment in the past. \n Please select a Future Date";
                MessageBox.Show(message);
            }
            else if (endDateTime.Value < DateTime.Now || endDateTime.Value > startDateTime.Value)
            {
                const string message = "You cannot end an appointment before your start it. \n Please select a Future Date";
                MessageBox.Show(message);
            }

        }

        // METHODS

       
        /// <summary>
        /// Method for Validating the Form 
        /// Checks each control to verify it's been properly filled ou
        /// </summary>
        /// <returns>True or False</returns>
        private bool validateForm()
        {
            bool validated = false;

            if (validateFields() == true)
            {

                if (validateExistingApts() == true)
                {
                    if (validateDates() == true)
                    {
                        if (validateLocation() == true)
                        {
                            validated = true;
                        }
                        else
                        {
                            return validated;
                        }
                    }
                    else
                    {
                        return validated;
                    }
                }
               else
                {
                    return validated;
                }
            }
            else
            {
                return validated;
            }

            return validated;
        }


        public bool validateFields()
        {
            bool validated = false;
            // Ensure all fields are filled out
            foreach (var control in Controls.Cast<Control>().Where(c => c is TextBox))
            {
                if (string.IsNullOrEmpty(control.Text.ToString()))
                {
                    MessageBox.Show("Please fill out all fields");

                }
                else
                {
                    validated = true;
                }
            }


            return validated;
        }

       
        /// <summary>
        /// Validate that the dates are not equal to each other and start is less than end time.
        /// </summary>
        /// <returns></returns>
        public bool validateDates()
        {
            bool validated = false;
            // Ensure no existing appointments are overlapping

            if (startDateTime.Value < DateTime.Now)
            {
                const string message = "You cannot create an appointment in the past. \n Please select a Future Date";
                MessageBox.Show(message);
            }
            else if (endDateTime.Value < DateTime.Now || DateTime.Parse(endDateTime.Value.ToString()) <= DateTime.Parse(startDateTime.Value.ToString()))
            {
                const string message = "You cannot create an appointment in the past. \n Please select a Future Date";
                MessageBox.Show(message);

            }
            else
            {
                newApt.Start = DateTime.Now;
                validated = true;

            }
            return validated;
        }

        public bool validateExistingApts()
        {
            bool validated = false;

            DateTime tempStart = startDateTime.Value.AddHours(getOffSet());
            DateTime tempEnd = startDateTime.Value.AddHours(getOffSet());

            if (newApt.checkAvailability(tempStart, tempEnd) > 0)
            {
                MessageBox.Show("You cannot create an appointment that overlaps other appointments. Check your Calendar and try again.");
            }
            else
            {
                validated = true;
            }

            return validated;
        }

        public bool validateLocation()
        {
            bool validated = false;

            if (locationComboBx.SelectedItem == null)
            {
                MessageBox.Show("Please Select a Location");
            }
            else
            {
                validated = true;
            }


            return validated;
        }


        public bool createAppointment()
        {
            bool aptCreated = false;

            newApt.UserID = currentUser.UserID;
            newApt.Title = titleTxtBox.Text.ToString();
            newApt.Description = descriptionTxtBox.Text.ToString();
            newApt.Location = locationComboBx.Text.ToString();
            newApt.Contact = contactTxtBox.Text.ToString();
            newApt.Type = typeTxtBox.Text.ToString();
            newApt.Url = urlTxtBox.Text.ToString();
            newApt.Start = startDateTime.Value;
            newApt.End = endDateTime.Value;
            


            Console.WriteLine(newApt.Start.ToString());
            try
            {
                if(newApt.Create_Appointment(currentUser.Username) == true)
                {
                    aptCreated = true;
                }
                

            } 
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " \nMessage: " + ex.Message);
            }

            return aptCreated;

        }


        public bool updateAppointment()
        {
            bool updated = false;

            newApt.UserID = currentUser.UserID;
            newApt.Title = titleTxtBox.Text.ToString();
            newApt.Description = descriptionTxtBox.Text.ToString();
            newApt.Location = locationComboBx.Text.ToString();
            newApt.Contact = contactTxtBox.Text.ToString();
            newApt.Type = typeTxtBox.Text.ToString();
            newApt.Url = urlTxtBox.Text.ToString();
            newApt.Start =startDateTime.Value;
            newApt.End = endDateTime.Value;

            try
            {
                if(newApt.Update_Appointment() == true)
                {
                    updated = true;
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " \nMessage: " + ex.Message);
            }

            return updated;

        }


        /// <summary>
        /// Gets the difference between GMT and currently selected location
        /// </summary>
        public double getOffSet()
        {
            double offset = 0;

            foreach (KeyValuePair<string, double> selection in dataSource)
            {
                if (locationComboBx.Text == selection.Key)
                {
                    offset = selection.Value;
                }
            }
            return offset;

        }



    }

}
