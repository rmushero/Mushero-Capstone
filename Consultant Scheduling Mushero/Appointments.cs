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
        Dictionary<int, string> customers = new Dictionary<int, string>();
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
            
            customerSelection.DisplayMember = "Value";
            customerSelection.ValueMember = "Key";
            populateCustomer(currentUser.Username);
            customerSelection.DataSource = new BindingSource(customers, null);
            endDateTime.Value = startDateTime.Value.AddMinutes(30);
            

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
            Customer customer = new Customer();
            customer.getCustomerData(newApt.CustomerID);
            customerSelection.Visible = false;
            customerName.Text = $"{customer.CustomerName}";  
           
        }

        public void populateCustomer(string username)
        {
            string command = "Select customerId, customerName from customer where createdBy = '" + username + "\'";

           

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(command, cnn))
                {
                    cnn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                            {

                        
                        try
                        {
                            while (dr.Read())
                            {
                                customers.Add(Convert.ToInt32(dr["customerId"]), dr["customerName"].ToString());
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
          startDateTime.Value = newApt.Start.AddHours(getOffSet());

            //Set End Time
           endDateTime.Value = newApt.End.AddHours(getOffSet());
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
            if(validateForm() == true)
            {
                if(modificationMode == true)
                {
                    if (updateAppointment() == true)
                    {
                        string message = "Appointment Updated Created";
                        this.Close();
                        MessageBox.Show(message);
                    }

                }
                else
                {
                    
                        if (createAppointment() == true)
                        {
                            string message = "Appointment Successfully Created";
                        this.Close();
                            MessageBox.Show(message);

                        }
                    
                }           
                

            }
           

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
            int count = 0;
            bool validated = false;
            // Ensure all fields are filled out
            foreach (var control in Controls.Cast<Control>().Where(c => c is TextBox))
            {
                if (string.IsNullOrEmpty(control.Text.ToString()))
                {
                    count++;

                }
                else
                {
                    validated = true;
                }
            }

            if(count > 0)
            {
                MessageBox.Show("Please fill out all fields");
                validated = false;
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

            if (startDateTime.Value <= DateTime.Now)
            {
                const string message = "You cannot create an appointment in the past. \n Please select a Future Date";
                MessageBox.Show(message);
            }
            else if (endDateTime.Value < DateTime.Now || DateTime.Parse(endDateTime.Value.ToString()) <= DateTime.Parse(startDateTime.Value.ToString()))
            {
                const string message = "You cannot end an appointment in the past. \n Please select a Future Date";
                MessageBox.Show(message);

            }
            else if (startDateTime.Value.Hour < 09 || endDateTime.Value.Hour > 17 )
            {
                const string message = "You cannot book an appointment outside of business hours \n 9:00 AM - 5:00 PM local time";
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

            DateTime tempStart = startDateTime.Value.AddHours(getOnSet());
            DateTime tempEnd = endDateTime.Value.AddHours(getOnSet());

          

            if (newApt.checkAvailability(tempStart, tempEnd) > 0)
            {
                MessageBox.Show("You cannot create an appointment that overlaps other appointments. Check your Calendar and try again.");
            }
            else
            {
                newApt.Start = tempStart;
                newApt.End = tempEnd;
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

        /// <summary>
        /// This method collects data from the form and submits it to the database
        /// </summary>
        /// <returns></returns>

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
            newApt.Start = startDateTime.Value.AddHours(getOnSet());
            newApt.End = endDateTime.Value.AddHours(getOnSet());
            newApt.CustomerID = Convert.ToInt32(customerSelection.SelectedValue);
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



        /// <summary>
        /// Method used to collect data from appointment form and updates the existing appointment
        /// </summary>
        /// <returns></returns>
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
            newApt.Start =startDateTime.Value.AddHours(getOnSet()); 
            newApt.End = endDateTime.Value.AddHours(getOnSet()); 
            newApt.CustomerID = Convert.ToInt32(customerSelection.SelectedValue);

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
            int offset = 0;

            foreach (KeyValuePair<string, double> selection in dataSource)
            {
                if (locationComboBx.Text == selection.Key)
                {
                    offset = Convert.ToInt32(selection.Value);
                }
            }
            return offset;

        }

        public double getOnSet()
        {
            int offset = 0;

            foreach (KeyValuePair<string, double> selection in dataSource)
            {
                if (locationComboBx.Text == selection.Key)
                {
                  double  temp = selection.Value;
                    offset = Convert.ToInt32(temp = selection.Value *-1);
                }
            }
            return offset;

        }



    }

}
