using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

using System.Configuration;
using MySql.Data.MySqlClient;



namespace Consultant_Scheduling_Mushero
{
    public partial class LoginForm : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public LoginForm()
        {

            InitializeComponent();

        }

        /// <summary>
        /// Close the application when the cancel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Get the username and password from the form and look them up in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logOnBtn_Click(object sender, EventArgs e)
        {
            string username = unTxtBx.Text.ToString();
            string password = pwTxtBx.Text.ToString();

            //creates a new user 
            User user = new User();

            //Looks for the user account based on username and password 
            user.UserID = user.FindUserAccount(username, password);
           
            //checks if there is a result 
            if (user.UserID > 0)
            {
                //Creates dashboard object 
                Dashboard db = new Dashboard(user, username);
                //Creates a new log
               
                writeLog(user.UserID);
                db.Show();
                this.Hide();
            }
            else
            {
                writeLog(user.UserID);
                MessageBox.Show("Incorrect Username or Password");
            }
        }


        /// <summary>
        /// This Method ensures that there is a password in this box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pwTxtBx_Leave(object sender, EventArgs e)
        {

            if (pwTxtBx.Text.Length == 0)
            {
                pwTxtBx.ForeColor = Color.Gray;

                pwTxtBx.Text = "Enter password";

                logOnBtn.Enabled = false;

                pwTxtBx.UseSystemPasswordChar = false;

                SelectNextControl(pwTxtBx, true, true, false, true);
            }
            else
            {
                logOnBtn.Enabled = true;
            }

        }

        /// <summary>
        /// This method creates a log file if one is not created
        /// If a log file exists already it will be in \bin\debug\
        /// </summary>
        /// <param name="id"></param>
        private void writeLog(int id)
        {
            string fileName = "log.txt";

            if (!File.Exists(fileName))
            {
                using(StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("User Logins");
                    sw.WriteLine("UserID: {0} DateTime: {1}", id, DateTime.Now);
                }
            }
            else
            {
                using(StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine("UserID: {0} DateTime: {1}", id, DateTime.Now);
                }
            }


        }

        /// <summary>
        /// This method clears the password box when someone clicks into it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pwTxtBx_Enter(object sender, EventArgs e)
        {
            pwTxtBx.Clear();

            pwTxtBx.ForeColor = Color.Black;

            pwTxtBx.UseSystemPasswordChar = true;
        }

        

    }
}


