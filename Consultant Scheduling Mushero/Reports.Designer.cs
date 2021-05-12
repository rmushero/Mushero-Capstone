
namespace Consultant_Scheduling_Mushero
{
    partial class Reports
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
            this.reportOneBtn = new System.Windows.Forms.Button();
            this.reportTwoBtn = new System.Windows.Forms.Button();
            this.reportThreeBtn = new System.Windows.Forms.Button();
            this.reportsView = new System.Windows.Forms.DataGridView();
            this.exitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reportsView)).BeginInit();
            this.SuspendLayout();
            // 
            // reportOneBtn
            // 
            this.reportOneBtn.Location = new System.Drawing.Point(8, 33);
            this.reportOneBtn.Name = "reportOneBtn";
            this.reportOneBtn.Size = new System.Drawing.Size(130, 44);
            this.reportOneBtn.TabIndex = 0;
            this.reportOneBtn.Text = "Appointments By Month";
            this.reportOneBtn.UseVisualStyleBackColor = true;
            this.reportOneBtn.Click += new System.EventHandler(this.reportOneBtn_Click);
            // 
            // reportTwoBtn
            // 
            this.reportTwoBtn.Location = new System.Drawing.Point(157, 32);
            this.reportTwoBtn.Name = "reportTwoBtn";
            this.reportTwoBtn.Size = new System.Drawing.Size(130, 45);
            this.reportTwoBtn.TabIndex = 1;
            this.reportTwoBtn.Text = "Schedule for Each Consultant";
            this.reportTwoBtn.UseVisualStyleBackColor = true;
            this.reportTwoBtn.Click += new System.EventHandler(this.reportTwoBtn_Click);
            // 
            // reportThreeBtn
            // 
            this.reportThreeBtn.Location = new System.Drawing.Point(315, 34);
            this.reportThreeBtn.Name = "reportThreeBtn";
            this.reportThreeBtn.Size = new System.Drawing.Size(130, 43);
            this.reportThreeBtn.TabIndex = 2;
            this.reportThreeBtn.Text = "Customers by User";
            this.reportThreeBtn.UseVisualStyleBackColor = true;
            this.reportThreeBtn.Click += new System.EventHandler(this.reportThreeBtn_Click);
            // 
            // reportsView
            // 
            this.reportsView.AllowUserToAddRows = false;
            this.reportsView.AllowUserToDeleteRows = false;
            this.reportsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportsView.Location = new System.Drawing.Point(2, 97);
            this.reportsView.Name = "reportsView";
            this.reportsView.ReadOnly = true;
            this.reportsView.Size = new System.Drawing.Size(791, 345);
            this.reportsView.TabIndex = 3;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(482, 43);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.reportsView);
            this.Controls.Add(this.reportThreeBtn);
            this.Controls.Add(this.reportTwoBtn);
            this.Controls.Add(this.reportOneBtn);
            this.Name = "Reports";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.reportsView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reportOneBtn;
        private System.Windows.Forms.Button reportTwoBtn;
        private System.Windows.Forms.Button reportThreeBtn;
        private System.Windows.Forms.DataGridView reportsView;
        private System.Windows.Forms.Button exitBtn;
    }
}