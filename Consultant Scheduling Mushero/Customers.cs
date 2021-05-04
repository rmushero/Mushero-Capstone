using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultant_Scheduling_Mushero
{
    public partial class Customers : Form
    {

        string currentUser;
        bool modification = false;
               

        Customer customer = new Customer();
        Address address = new Address();
        City city = new City();
        Country country = new Country();

        public Customers(string username)
        {
            InitializeComponent();
            this.Text = "Add Customer";
            currentUser = username;
        }

        public Customers(string username, string type)
        {
            InitializeComponent();
            currentUser = username;
            createGenericObj();
        }

        // Modify Customer
        public Customers(string username, int id)
        {
            InitializeComponent();
            this.Text = "Modify Customer";
            modification = true;
            currentUser = username;
            populateForm(id);
        }
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

        private void createNewCustomer()
        {
            if (validateFormData() == true)
            {

                createObject();
                MessageBox.Show("Customer Created Successfully");
                this.Close();
            }
        }

        private void updateExistingCustomer()
        {
            if (validateFormData() == true)
            {
                updateCustomerInfo();
                MessageBox.Show("Customer Updated Successfully");
                this.Close();
            }
        }

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

            foreach (var control in Controls.Cast<Control>().Where(c => c is TextBox))
            {
                if (string.IsNullOrEmpty(control.Text.ToString()))
                {
                    string controlName = control.Name.ToString();
                    string message = $"You cannot leave {controlName} empty.";
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
        /// creates a dummy customer for method testing
        /// </summary>
        private void createGenericObj()
        {
            string _country = "USA";
            country.Country_name = _country;
            city.CountryId = country.InsertCountry(currentUser);
           
            string _city = "Hermansville";
            city.CityName = _city;
            address.CityId = city.insertCity( currentUser);
            string _addr1 = "W4988 US Highway 2";
            string _addr2 = "null";
            string _postal = "49847";
            string _phone = "920-757-4186";
            address.Address1 = _addr1;
            address.Address2 = _addr2;
            address.PostalCode = _postal;
            address.Phone = _phone;
            customer.AddressId = address.insertAddress(currentUser);

            string _name = "Rodney Mushero";
            sbyte _active = 1;
            customer.CustomerName = _name;
            customer.Active = _active;

            int customerID = customer.insertCustomer(currentUser);
            customer.CustomerId = customerID;
        }


        /// <summary>
        /// Gets data on the form and creates an object 
        /// </summary>
        private void createObject()
        {    

            string _country = countryTxtBox.Text.ToString();
            country.Country_name = _country;
            city.CountryId = country.InsertCountry(currentUser);


            string _city = cityTxtBox.Text.ToString();
            city.CityName = _city;
            address.CityId = city.insertCity(currentUser);

            string _addr1 = addr1TxtBox.Text.ToString();
            string _addr2 = addr2TxtBox.Text.ToString();
            string _postal = postalTxtBox.Text.ToString();
            string _phone = phoneTextBox.Text.ToString();
           
            address.Address1 = _addr1;
            address.Address2 = _addr2;
            address.PostalCode = _postal;
            address.Phone = _phone;
            customer.AddressId = address.insertAddress(currentUser);


            string _name = nameTxtBox.Text.ToString();
            customer.CustomerName = _name;
            sbyte _active = 1; //Not of correct Type
            customer.Active = _active;

            int customerID = customer.insertCustomer(currentUser);
            customer.CustomerId = customerID;




        }

        /// <summary>
        /// Populates the form with the selected customer data
        /// </summary>
        /// <param name="customerID"></param>
        public void populateForm(int customerID)
        {
            

            customer.AddressId = customer.getCustomerData(customerID);

            Console.WriteLine($"Address ID:{customer.AddressId}");


           address.CityId = address.getAddressData(customer.AddressId);

            city.CountryId = city.getCityData(address.CityId);
            country.getCountryData(city.CountryId);
            country.CountryId = city.CountryId;


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
            addr1TxtBox.Text = address.Address1;
            addr2TxtBox.Text = address.Address2;
            postalTxtBox.Text = address.PostalCode;
            cityTxtBox.Text = city.CityName;
            countryTxtBox.Text = country.Country_name;





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
                    _active = 1; //Not of correct Type
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
                 address.Address1 = _addr1;               
                 address.Address2 = _addr2;               
                 address.PostalCode = _postal;               
                 address.Phone = _phone;               
                 city.CityName = _city;
                 country.Country_name = _country;


            country.updateCountry(currentUser);
            city.updateCity(currentUser);
        
            address.updateAddress(currentUser);
            customer.updateCustomer(currentUser);

        }
                      

    


    }
}

