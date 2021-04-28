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
        bool flag = false;
        string Username;
        int CustomerId;
        Customer updateCandidate = new Customer();
        Address updateAddress = new Address();
        City updateCity = new City();
        Country updateCountry = new Country();

        public Customers(string username)
        {
            InitializeComponent();
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
            flag = true;
            currentUser = username;
            populateForm(id);
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (flag = true)
            {
                if (validateFormData() == true)
                {
                    updateCandidate.UpdateCustomer(currentUser);
                    this.Close();
                }
            }
            else
            {
                if (validateFormData() == true)
                {
                    createObject();
                    this.Close();
                }
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

        private void createGenericObj()
        {

            Country country = new Country();
            City city = new City();
            Address address = new Address();
            Customer newCustomer = new Customer();

           
            
            
            

            string _country = "USA";
            country.Country_name = _country;
            city.CountryId = country.InsertCountry(currentUser);
           
            string _city = "Hermansville";
            city.CityName = _city;
            address.CityId = city.InsertCity( currentUser);
            string _addr1 = "W4988 US Highway 2";
            string _addr2 = "null";
            string _postal = "49847";
            string _phone = "920-757-4186";
            address.Address1 = _addr1;
            address.Address2 = _addr2;
            address.PostalCode = _postal;
            address.Phone = _phone;

            newCustomer.AddressId = address.insertAddress(currentUser);
            string _name = "Rodney Mushero";
            sbyte _active = 1;
            newCustomer.CustomerName = _name;
            newCustomer.Active = _active;

            int customerID = newCustomer.InsertCustomer(currentUser);
            newCustomer.CustomerId = customerID;
        }
        private void createObject()
        {
            Country country = new Country();
            City city = new City();
            Address address = new Address();
            Customer newCustomer = new Customer();

            
            string _name = nameTxtBox.Text.ToString();
            string _phone = phoneTextBox.Text.ToString();
            byte _active = 1; //Not of correct Type
            string _addr1 = addr1TxtBox.Text.ToString();
            string _addr2 = addr2TxtBox.Text.ToString();
            string _postal = postalTxtBox.Text.ToString();
            string _city = cityTxtBox.Text.ToString();
            string _country = countryTxtBox.Text.ToString();
            country.Country_name = _country;
            int countryID = country.InsertCountry(currentUser);
            city.CountryId = country.CountryId;
            city.CityName = _city;
            int cityID = city.InsertCity(currentUser);
            address.CityId = cityID;
            address.Address1 = _addr1;
            address.Address2 = _addr2;
            address.PostalCode = _postal;
            address.Phone = _phone;
            int addressID = address.insertAddress(currentUser);
            newCustomer.CustomerName = _name;
            newCustomer.AddressId = addressID;
            int customerID = newCustomer.InsertCustomer(currentUser);
            newCustomer.CustomerId = customerID;




        }
        public void populateForm(int customerID)
        {

            



        }


        private void saveBtn_Click2(object sender, EventArgs e)
        {
            try
            {
                if (validateFormData() == true)
                {

                    sbyte _active;
                    string _name = nameTxtBox.Text.ToString();
                    string _phone = phoneTextBox.Text.ToString();
                    if (activeCkBx.Checked == true)
                    {
                        _active = 1; //Not of correct Type
                    }
                    else
                    {
                        _active = 0;
                    }
                    string _addr1 = addr1TxtBox.Text.ToString();
                    string _addr2 = addr2TxtBox.Text.ToString();
                    string _postal = postalTxtBox.Text.ToString();
                    string _city = cityTxtBox.Text.ToString();
                    string _country = countryTxtBox.Text.ToString();

                    if (_name != updateCandidate.CustomerName)
                    {
                        updateCandidate.CustomerName = _name;
                    }
                    if (_active != updateCandidate.Active)
                    {
                        updateCandidate.Active = _active;
                    }
                    if (_addr1 != updateAddress.Address1)
                    {
                        updateAddress.Address1 = _addr1;
                    }
                    if (_addr2 != updateAddress.Address2)
                    {
                        updateAddress.Address2 = _addr2;
                    }
                    if (_postal != updateAddress.PostalCode)
                    {
                        updateAddress.PostalCode = _postal;
                    }
                    if (_phone != updateAddress.Phone)
                    {
                        updateAddress.Phone = _phone;
                    }
                    if (_city != updateCity.CityName)
                    {
                        updateCity.CityName = _city;
                    }
                    if (_country != updateCountry.Country_name)
                    {
                        updateCountry.Country_name = _country;
                    }

                    updateCountry.updateCountry(Username);
                    updateCity.updateCity(Username);
                    updateAddress.updateAddress(Username);
                    updateCandidate.UpdateCustomer(Username);
                }
                MessageBox.Show("Customer Updated");
                this.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            const string en_message = "Are you sure you want to Delete this customer? This action cannot be undone";
            const string caption = "Delete Customer";
            var result = MessageBox.Show(en_message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {


            }
            else
            {
                try
                {
                    //todo make this a boolean 
                    // if boolean > 0 then confirm deletion
                    updateCandidate.deleteCustomerData(CustomerId);
                    this.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }



    }
}

