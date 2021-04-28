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


        // TODO: TimeZone compensation
        // MYSQL server is based in GMT 

        public LoginForm()
        {

            InitializeComponent();

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOnBtn_Click(object sender, EventArgs e)
        {
            string username = unTxtBx.Text.ToString();
            string password = pwTxtBx.Text.ToString();


            User user = new User();

            user.UserID = user.FindUserAccount(username, password);
           

            if (user.UserID > 0)
            {

                Dashboard db = new Dashboard(user, username);
                Logs log = new Logs(user.UserID, "Log On Attempt");
                writeLog(user.UserID);
                db.Show();
                this.Hide();
            }
            else
            {
                Logs log = new Logs(username, "Failed Logon Attempt - User Does not Exist");
                MessageBox.Show("Incorrect Username or Password");
            }
        }

        private void pwTxtBx_Leave(object sender, EventArgs e)
        {

            if (pwTxtBx.Text.Length == 0)
            {
                pwTxtBx.ForeColor = Color.Gray;

                pwTxtBx.Text = "Enter password";

                pwTxtBx.UseSystemPasswordChar = false;

                SelectNextControl(pwTxtBx, true, true, false, true);
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

        
        private void pwTxtBx_Enter(object sender, EventArgs e)
        {
            pwTxtBx.Clear();

            pwTxtBx.ForeColor = Color.Black;

            pwTxtBx.UseSystemPasswordChar = true;
        }

        

    }
}


