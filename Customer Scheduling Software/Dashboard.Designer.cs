
namespace Consultant_Scheduling_Mushero
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.customerTable = new System.Windows.Forms.DataGridView();
            this.appointmentTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitAltF4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.addAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.custRefBtn = new System.Windows.Forms.Button();
            this.customerSrchBox = new System.Windows.Forms.TextBox();
            this.custSrchBtn = new System.Windows.Forms.Button();
            this.aptSrcBtn = new System.Windows.Forms.Button();
            this.aptPicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // customerTable
            // 
            this.customerTable.AllowUserToAddRows = false;
            this.customerTable.AllowUserToDeleteRows = false;
            this.customerTable.AllowUserToResizeColumns = false;
            this.customerTable.AllowUserToResizeRows = false;
            this.customerTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.customerTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.customerTable.Location = new System.Drawing.Point(17, 73);
            this.customerTable.Margin = new System.Windows.Forms.Padding(2);
            this.customerTable.MultiSelect = false;
            this.customerTable.Name = "customerTable";
            this.customerTable.ReadOnly = true;
            this.customerTable.RowHeadersVisible = false;
            this.customerTable.RowHeadersWidth = 51;
            this.customerTable.RowTemplate.Height = 24;
            this.customerTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerTable.Size = new System.Drawing.Size(732, 167);
            this.customerTable.TabIndex = 0;
            // 
            // appointmentTable
            // 
            this.appointmentTable.AllowUserToAddRows = false;
            this.appointmentTable.AllowUserToDeleteRows = false;
            this.appointmentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.appointmentTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.appointmentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.appointmentTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.appointmentTable.Location = new System.Drawing.Point(15, 287);
            this.appointmentTable.Margin = new System.Windows.Forms.Padding(2);
            this.appointmentTable.MultiSelect = false;
            this.appointmentTable.Name = "appointmentTable";
            this.appointmentTable.ReadOnly = true;
            this.appointmentTable.RowHeadersVisible = false;
            this.appointmentTable.RowHeadersWidth = 51;
            this.appointmentTable.RowTemplate.Height = 24;
            this.appointmentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentTable.Size = new System.Drawing.Size(735, 212);
            this.appointmentTable.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 259);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Appointments";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.customerToolStripMenuItem1,
            this.appointmentToolStripMenuItem2,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(777, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitAltF4ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // exitAltF4ToolStripMenuItem
            // 
            this.exitAltF4ToolStripMenuItem.Name = "exitAltF4ToolStripMenuItem";
            this.exitAltF4ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.exitAltF4ToolStripMenuItem.Text = "Exit Alt-F4";
            this.exitAltF4ToolStripMenuItem.Click += new System.EventHandler(this.exitAltF4ToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem1
            // 
            this.customerToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerToolStripMenuItem,
            this.modifyCustomerToolStripMenuItem,
            this.deleteCustomerToolStripMenuItem});
            this.customerToolStripMenuItem1.Name = "customerToolStripMenuItem1";
            this.customerToolStripMenuItem1.Size = new System.Drawing.Size(71, 20);
            this.customerToolStripMenuItem1.Text = "Customer";
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.addCustomerToolStripMenuItem.Text = "Add Customer";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.addCustomerToolStripMenuItem_Click);
            // 
            // modifyCustomerToolStripMenuItem
            // 
            this.modifyCustomerToolStripMenuItem.Name = "modifyCustomerToolStripMenuItem";
            this.modifyCustomerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.modifyCustomerToolStripMenuItem.Text = "Modify Customer";
            this.modifyCustomerToolStripMenuItem.Click += new System.EventHandler(this.modifyCustomerToolStripMenuItem_Click);
            // 
            // deleteCustomerToolStripMenuItem
            // 
            this.deleteCustomerToolStripMenuItem.Name = "deleteCustomerToolStripMenuItem";
            this.deleteCustomerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.deleteCustomerToolStripMenuItem.Text = "Delete Customer";
            this.deleteCustomerToolStripMenuItem.Click += new System.EventHandler(this.deleteCustomerToolStripMenuItem_Click);
            // 
            // appointmentToolStripMenuItem2
            // 
            this.appointmentToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAppointmentToolStripMenuItem,
            this.modifyAppointmentToolStripMenuItem,
            this.deleteAppointmentToolStripMenuItem});
            this.appointmentToolStripMenuItem2.Name = "appointmentToolStripMenuItem2";
            this.appointmentToolStripMenuItem2.Size = new System.Drawing.Size(90, 20);
            this.appointmentToolStripMenuItem2.Text = "Appointment";
            // 
            // addAppointmentToolStripMenuItem
            // 
            this.addAppointmentToolStripMenuItem.Name = "addAppointmentToolStripMenuItem";
            this.addAppointmentToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addAppointmentToolStripMenuItem.Text = "Add Appointment";
            this.addAppointmentToolStripMenuItem.Click += new System.EventHandler(this.addAppointmentToolStripMenuItem_Click);
            // 
            // modifyAppointmentToolStripMenuItem
            // 
            this.modifyAppointmentToolStripMenuItem.Name = "modifyAppointmentToolStripMenuItem";
            this.modifyAppointmentToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.modifyAppointmentToolStripMenuItem.Text = "Modify Appointment";
            this.modifyAppointmentToolStripMenuItem.Click += new System.EventHandler(this.modifyAppointmentToolStripMenuItem_Click);
            // 
            // deleteAppointmentToolStripMenuItem
            // 
            this.deleteAppointmentToolStripMenuItem.Name = "deleteAppointmentToolStripMenuItem";
            this.deleteAppointmentToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.deleteAppointmentToolStripMenuItem.Text = "Delete Appointment";
            this.deleteAppointmentToolStripMenuItem.Click += new System.EventHandler(this.deleteAppointmentToolStripMenuItem_Click_1);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsToolStripMenuItem,
            this.calendarToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // calendarToolStripMenuItem
            // 
            this.calendarToolStripMenuItem.Name = "calendarToolStripMenuItem";
            this.calendarToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.calendarToolStripMenuItem.Text = "Calendar";
            this.calendarToolStripMenuItem.Click += new System.EventHandler(this.calendarToolStripMenuItem_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(381, 256);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 5;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // custRefBtn
            // 
            this.custRefBtn.Location = new System.Drawing.Point(307, 37);
            this.custRefBtn.Name = "custRefBtn";
            this.custRefBtn.Size = new System.Drawing.Size(75, 23);
            this.custRefBtn.TabIndex = 6;
            this.custRefBtn.Text = "Refresh";
            this.custRefBtn.UseVisualStyleBackColor = true;
            this.custRefBtn.Click += new System.EventHandler(this.custRefBtn_Click);
            // 
            // customerSrchBox
            // 
            this.customerSrchBox.Location = new System.Drawing.Point(94, 38);
            this.customerSrchBox.Name = "customerSrchBox";
            this.customerSrchBox.Size = new System.Drawing.Size(100, 20);
            this.customerSrchBox.TabIndex = 7;
            // 
            // custSrchBtn
            // 
            this.custSrchBtn.Location = new System.Drawing.Point(213, 37);
            this.custSrchBtn.Name = "custSrchBtn";
            this.custSrchBtn.Size = new System.Drawing.Size(75, 23);
            this.custSrchBtn.TabIndex = 9;
            this.custSrchBtn.Text = "Search";
            this.custSrchBtn.UseVisualStyleBackColor = true;
            this.custSrchBtn.Click += new System.EventHandler(this.custSrchBtn_Click);
            // 
            // aptSrcBtn
            // 
            this.aptSrcBtn.Location = new System.Drawing.Point(293, 256);
            this.aptSrcBtn.Name = "aptSrcBtn";
            this.aptSrcBtn.Size = new System.Drawing.Size(75, 23);
            this.aptSrcBtn.TabIndex = 10;
            this.aptSrcBtn.Text = "Search";
            this.aptSrcBtn.UseVisualStyleBackColor = true;
            this.aptSrcBtn.Click += new System.EventHandler(this.aptSrcBtn_Click);
            // 
            // aptPicker
            // 
            this.aptPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.aptPicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.aptPicker.Location = new System.Drawing.Point(87, 259);
            this.aptPicker.Name = "aptPicker";
            this.aptPicker.Size = new System.Drawing.Size(200, 20);
            this.aptPicker.TabIndex = 11;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(777, 521);
            this.Controls.Add(this.aptPicker);
            this.Controls.Add(this.aptSrcBtn);
            this.Controls.Add(this.custSrchBtn);
            this.Controls.Add(this.customerSrchBox);
            this.Controls.Add(this.custRefBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerTable);
            this.Controls.Add(this.appointmentTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridView customerTable;
        private System.Windows.Forms.DataGridView appointmentTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitAltF4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem addAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button custRefBtn;
        private System.Windows.Forms.TextBox customerSrchBox;
        private System.Windows.Forms.Button custSrchBtn;
        private System.Windows.Forms.Button aptSrcBtn;
        private System.Windows.Forms.DateTimePicker aptPicker;
    }
}