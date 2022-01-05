
namespace Consultant_Scheduling_Mushero
{
    partial class AppointmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.startDateTime = new System.Windows.Forms.DateTimePicker();
            this.endDateTime = new System.Windows.Forms.DateTimePicker();
            this.titleTxtBox = new System.Windows.Forms.TextBox();
            this.descriptionTxtBox = new System.Windows.Forms.TextBox();
            this.urlTxtBox = new System.Windows.Forms.TextBox();
            this.typeTxtBox = new System.Windows.Forms.TextBox();
            this.contactTxtBox = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cnclBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.customerSelection = new System.Windows.Forms.ComboBox();
            this.customerName = new System.Windows.Forms.Label();
            this.locationtxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appointment Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 265);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contact";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 264);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 307);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "URL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 352);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Start Date and Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 389);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "End Date and Time";
            // 
            // startDateTime
            // 
            this.startDateTime.CustomFormat = "yyyy/MM/dd  hh:mm tt";
            this.startDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDateTime.Location = new System.Drawing.Point(124, 352);
            this.startDateTime.Margin = new System.Windows.Forms.Padding(2);
            this.startDateTime.Name = "startDateTime";
            this.startDateTime.Size = new System.Drawing.Size(158, 20);
            this.startDateTime.TabIndex = 8;
           
            // 
            // endDateTime
            // 
            this.endDateTime.CustomFormat = "yyyy/MM/dd  hh:mm tt";
            this.endDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDateTime.Location = new System.Drawing.Point(124, 383);
            this.endDateTime.Margin = new System.Windows.Forms.Padding(2);
            this.endDateTime.Name = "endDateTime";
            this.endDateTime.Size = new System.Drawing.Size(158, 20);
            this.endDateTime.TabIndex = 9;
            // 
            // titleTxtBox
            // 
            this.titleTxtBox.Location = new System.Drawing.Point(27, 27);
            this.titleTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.titleTxtBox.Name = "titleTxtBox";
            this.titleTxtBox.Size = new System.Drawing.Size(254, 20);
            this.titleTxtBox.TabIndex = 1;
            // 
            // descriptionTxtBox
            // 
            this.descriptionTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionTxtBox.Location = new System.Drawing.Point(27, 131);
            this.descriptionTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.descriptionTxtBox.Multiline = true;
            this.descriptionTxtBox.Name = "descriptionTxtBox";
            this.descriptionTxtBox.Size = new System.Drawing.Size(254, 82);
            this.descriptionTxtBox.TabIndex = 3;
            // 
            // urlTxtBox
            // 
            this.urlTxtBox.Location = new System.Drawing.Point(27, 323);
            this.urlTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.urlTxtBox.Name = "urlTxtBox";
            this.urlTxtBox.Size = new System.Drawing.Size(254, 20);
            this.urlTxtBox.TabIndex = 7;
            // 
            // typeTxtBox
            // 
            this.typeTxtBox.Location = new System.Drawing.Point(163, 280);
            this.typeTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.typeTxtBox.Name = "typeTxtBox";
            this.typeTxtBox.Size = new System.Drawing.Size(119, 20);
            this.typeTxtBox.TabIndex = 6;
            // 
            // contactTxtBox
            // 
            this.contactTxtBox.Location = new System.Drawing.Point(27, 280);
            this.contactTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.contactTxtBox.Name = "contactTxtBox";
            this.contactTxtBox.Size = new System.Drawing.Size(119, 20);
            this.contactTxtBox.TabIndex = 5;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(103, 414);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(56, 19);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cnclBtn
            // 
            this.cnclBtn.Location = new System.Drawing.Point(172, 414);
            this.cnclBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cnclBtn.Name = "cnclBtn";
            this.cnclBtn.Size = new System.Drawing.Size(56, 19);
            this.cnclBtn.TabIndex = 11;
            this.cnclBtn.Text = "Cancel";
            this.cnclBtn.UseVisualStyleBackColor = true;
            this.cnclBtn.Click += new System.EventHandler(this.cnclBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Customer";
            // 
            // customerSelection
            // 
            this.customerSelection.FormattingEnabled = true;
            this.customerSelection.Location = new System.Drawing.Point(31, 85);
            this.customerSelection.Name = "customerSelection";
            this.customerSelection.Size = new System.Drawing.Size(121, 21);
            this.customerSelection.TabIndex = 2;
            // 
            // customerName
            // 
            this.customerName.AutoSize = true;
            this.customerName.Location = new System.Drawing.Point(93, 67);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(0, 13);
            this.customerName.TabIndex = 21;
            // 
            // locationtxtBox
            // 
            this.locationtxtBox.Location = new System.Drawing.Point(28, 239);
            this.locationtxtBox.Name = "locationtxtBox";
            this.locationtxtBox.Size = new System.Drawing.Size(253, 20);
            this.locationtxtBox.TabIndex = 22;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 453);
            this.Controls.Add(this.locationtxtBox);
            this.Controls.Add(this.customerName);
            this.Controls.Add(this.customerSelection);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cnclBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.contactTxtBox);
            this.Controls.Add(this.typeTxtBox);
            this.Controls.Add(this.urlTxtBox);
            this.Controls.Add(this.descriptionTxtBox);
            this.Controls.Add(this.titleTxtBox);
            this.Controls.Add(this.endDateTime);
            this.Controls.Add(this.startDateTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AppointmentForm";
            this.Text = "Appointments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker startDateTime;
        private System.Windows.Forms.DateTimePicker endDateTime;
        private System.Windows.Forms.TextBox titleTxtBox;
        private System.Windows.Forms.TextBox descriptionTxtBox;
        private System.Windows.Forms.TextBox urlTxtBox;
        private System.Windows.Forms.TextBox typeTxtBox;
        private System.Windows.Forms.TextBox contactTxtBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cnclBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox customerSelection;
        private System.Windows.Forms.Label customerName;
        private System.Windows.Forms.TextBox locationtxtBox;
    }
}