using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Consultant_Scheduling_Mushero
{
    public partial class CustomerForm : Form
    {

        int _userID;
        bool modification = false;


        Customer customer = new Customer();
        Address address = new Address();
        City city = new City();
        Country country = new Country();

        public CustomerForm(int userID)
        {
            InitializeComponent();
            this.Text = "Customer";


            _userID = userID;


        }


        // Modify Customer
        public CustomerForm(string username, int id)
        {
            InitializeComponent();
            this.Text = "Modify Customer";
            modification = true;

            populateForm(id);
        }

        /// <summary>
        /// This method checks if the form is being used for modification and then runs the appropriate method to save the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (modification == true)
            {
                updateExistingCustomer();
            }
            else
            {

                createNewCustomer();
            }


        }


        /// <summary>
        /// This method validates the form data and creates a new customer
        /// </summary>
        private void createNewCustomer()
        {
            if (validateFormData() == true)
            {

                createObject();
                MessageBox.Show("Customer Created Successfully");
                this.Close();
            }
        }


        /// <summary>
        /// This method validates the existing customer information and updated information and processes it through the database
        /// </summary>
        private void updateExistingCustomer()
        {
            if (validateFormData() == true)
            {
                updateCustomerInfo();
                MessageBox.Show("Customer Updated Successfully");
                this.Close();
            }
        }


        /// <summary>
        /// This method makes sure you want to close this form and then closes it if you do
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {

            const string message = "Are you sure you would like to close this form? Cancel Any Changes";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {

                this.Close();
            }
        }


        /// <summary>
        /// Iterates over all the controls to ensure they are being used
        /// </summary>
        /// <returns></returns>
        private bool validateFormData()
        {
            bool validated = false;


            foreach (var control in Controls.Cast<Control>().Where(c => c is TextBox)) // Lambda to iterate over the controls to check for missing data.
            {
                if (string.IsNullOrEmpty(control.Text.ToString()))
                {
                    string controlName = control.Name.ToString();
                    string message = $"You cannot leave required fields empty.";
                    string caption = "Incomplete Data";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else
                {
                    validated = true;
                }
            }



            return validated;
        }


        /// <summary>
        /// Gets data on the form and creates an object 
        /// </summary>
        private void createObject()
        {


            country.CountryName = countryTxtBox.Text.ToString();

            city.CountryID = country.InsertCountry(_userID);



            string _city = cityTxtBox.Text.ToString();
            city.CityName = _city;
            address.CityID = city.insertCity(_userID);

            string _addr1 = addr1TxtBox.Text.ToString();
            string _addr2 = addr2TxtBox.Text.ToString();
            string _postal = postalTxtBox.Text.ToString();
            string _phone = phoneTextBox.Text.ToString();

            address._Address = _addr1;
            address.Address2 = _addr2;
            address.PostalCode = _postal;
            address.Phone = _phone;
            customer.AddressID = address.insertAddress(_userID);


            string _name = nameTxtBox.Text.ToString();
            customer.CustomerName = _name;
            sbyte _active = 1; //Not of correct Type
            customer.Active = _active;

            int customerID = customer.insertCustomer(_userID);
            customer.CustomerID = customerID;



        }

        /// <summary>
        /// Populates the form with the selected customer data
        /// </summary>
        /// <param name="customerID"></param>
        public void populateForm(int customerID)
        {


            customer.AddressID = customer.getCustomerData(customerID);

            Console.WriteLine($"Address ID:{customer.AddressID}");


            address.CityID = address.getAddressData(customer.AddressID);

            city.CountryID = city.getCityData(address.CityID);
            country.getCountryData(city.CountryID);
            country.CountryID = city.CountryID;


            nameTxtBox.Text = customer.CustomerName;
            if (customer.Active < 1)
            {
                activeCkBx.Checked = false;
            }
            else
            {
                activeCkBx.Checked = true;
            }

            phoneTextBox.Text = address.Phone;
            addr1TxtBox.Text = address._Address;
            addr2TxtBox.Text = address.Address2;
            postalTxtBox.Text = address.PostalCode;
            cityTxtBox.Text = city.CityName;
            countryTxtBox.Text = country.CountryName;





        }



        /// <summary>
        /// Gets the updated customer information and updates tables accordingly
        /// </summary>
        public void updateCustomerInfo()
        {


            sbyte _active;
            string _name = nameTxtBox.Text.ToString();
            Console.WriteLine(_name);
            string _phone = phoneTextBox.Text.ToString();
            Console.WriteLine(_phone);
            if (activeCkBx.Checked == true)
            {
                _active = 1;
            }
            else
            {
                _active = 0;
            }
            string _addr1 = addr1TxtBox.Text.ToString();
            Console.WriteLine(_addr1);
            string _addr2 = addr2TxtBox.Text.ToString();
            Console.WriteLine(_addr2);
            string _postal = postalTxtBox.Text.ToString();
            Console.WriteLine(_postal);
            string _city = cityTxtBox.Text.ToString();
            Console.WriteLine(_city);
            string _country = countryTxtBox.Text.ToString();
            Console.WriteLine(_country);


            customer.CustomerName = _name;
            customer.Active = _active;
            address._Address = _addr1;
            address.Address2 = _addr2;
            address.PostalCode = _postal;
            address.Phone = _phone;
            city.CityName = _city;
            country.CountryName = _country;


            country.updateCountry(_userID);
            city.updateCity(_userID);

            address.updateAddress(_userID);
            customer.updateCustomer(_userID);


        }


    }
}

