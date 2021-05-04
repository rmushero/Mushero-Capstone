using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultant_Scheduling_Mushero.Classes
{
    public partial class Reminder : Form
    {
        public Reminder(int appId)
        {
            Appointment appt = new Appointment();

            appt.Get_Selected_Appointment(appId); 
            InitializeComponent();
           // DataProcedures data = new DataProcedures();
            //string customerName = data.getCustomerInformation(appt.customerId).customerName;

            //headMsg.Text += customerName;
            titleTextBox.Text = appt.Title;
            descriptionTextBox.Text = appt.Description;
            locationTextBox.Text = appt.Location;
            contactTextBox.Text = appt.Contact;
            typeTextBox.Text = appt.Type;
            urlTextBox.Text = appt.Url;
            startDateTimePicker.Value = appt.Start.ToLocalTime();
            endDateTimePicker.Value = appt.End.ToLocalTime();
        }

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
