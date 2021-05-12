
namespace Consultant_Scheduling_Mushero
{
    partial class CalendarVw
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
            this.apptDataGridView = new System.Windows.Forms.DataGridView();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.exitButton = new System.Windows.Forms.Button();
            this.weeklyDataGridView = new System.Windows.Forms.DataGridView();
            this.weekLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.apptDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weeklyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // apptDataGridView
            // 
            this.apptDataGridView.AllowUserToAddRows = false;
            this.apptDataGridView.AllowUserToDeleteRows = false;
            this.apptDataGridView.AllowUserToResizeColumns = false;
            this.apptDataGridView.AllowUserToResizeRows = false;
            this.apptDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.apptDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.apptDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.apptDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apptDataGridView.Location = new System.Drawing.Point(305, 62);
            this.apptDataGridView.MultiSelect = false;
            this.apptDataGridView.Name = "apptDataGridView";
            this.apptDataGridView.ReadOnly = true;
            this.apptDataGridView.RowHeadersVisible = false;
            this.apptDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.apptDataGridView.ShowCellErrors = false;
            this.apptDataGridView.ShowCellToolTips = false;
            this.apptDataGridView.ShowEditingIcon = false;
            this.apptDataGridView.ShowRowErrors = false;
            this.apptDataGridView.Size = new System.Drawing.Size(431, 311);
            this.apptDataGridView.TabIndex = 10;
            // 
            // monthCalendar
            // 
            this.monthCalendar.CalendarDimensions = new System.Drawing.Size(1, 2);
            this.monthCalendar.Location = new System.Drawing.Point(55, 51);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowTodayCircle = false;
            this.monthCalendar.TabIndex = 11;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitButton.Location = new System.Drawing.Point(368, 738);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(58, 30);
            this.exitButton.TabIndex = 12;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click_1);
            // 
            // weeklyDataGridView
            // 
            this.weeklyDataGridView.AllowUserToAddRows = false;
            this.weeklyDataGridView.AllowUserToDeleteRows = false;
            this.weeklyDataGridView.AllowUserToResizeColumns = false;
            this.weeklyDataGridView.AllowUserToResizeRows = false;
            this.weeklyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.weeklyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.weeklyDataGridView.Location = new System.Drawing.Point(66, 411);
            this.weeklyDataGridView.MultiSelect = false;
            this.weeklyDataGridView.Name = "weeklyDataGridView";
            this.weeklyDataGridView.ReadOnly = true;
            this.weeklyDataGridView.RowHeadersVisible = false;
            this.weeklyDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.weeklyDataGridView.ShowCellErrors = false;
            this.weeklyDataGridView.ShowCellToolTips = false;
            this.weeklyDataGridView.ShowEditingIcon = false;
            this.weeklyDataGridView.ShowRowErrors = false;
            this.weeklyDataGridView.Size = new System.Drawing.Size(670, 268);
            this.weeklyDataGridView.TabIndex = 14;
            // 
            // weekLabel
            // 
            this.weekLabel.AutoSize = true;
            this.weekLabel.Location = new System.Drawing.Point(375, 711);
            this.weekLabel.Name = "weekLabel";
            this.weekLabel.Size = new System.Drawing.Size(35, 13);
            this.weekLabel.TabIndex = 17;
            this.weekLabel.Text = "label1";
            // 
            // CalendarVw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 797);
            this.Controls.Add(this.weekLabel);
            this.Controls.Add(this.apptDataGridView);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.weeklyDataGridView);
            this.Name = "CalendarVw";
            this.Text = "Calendar";
            ((System.ComponentModel.ISupportInitialize)(this.apptDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weeklyDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.DataGridView apptDataGridView;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.DataGridView weeklyDataGridView;
        private System.Windows.Forms.Label weekLabel;
    }
}