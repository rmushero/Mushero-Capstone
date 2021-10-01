
namespace Consultant_Scheduling_Mushero
{
    partial class LoginForm
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
            this.unTxtBx = new System.Windows.Forms.TextBox();
            this.usrNmLbl = new System.Windows.Forms.Label();
            this.pwLbl = new System.Windows.Forms.Label();
            this.logOnBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.pwTxtBx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // unTxtBx
            // 
            this.unTxtBx.Location = new System.Drawing.Point(96, 46);
            this.unTxtBx.Margin = new System.Windows.Forms.Padding(2);
            this.unTxtBx.Name = "unTxtBx";
            this.unTxtBx.Size = new System.Drawing.Size(140, 20);
            this.unTxtBx.TabIndex = 0;
            // 
            // usrNmLbl
            // 
            this.usrNmLbl.AutoSize = true;
            this.usrNmLbl.Location = new System.Drawing.Point(80, 31);
            this.usrNmLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usrNmLbl.Name = "usrNmLbl";
            this.usrNmLbl.Size = new System.Drawing.Size(55, 13);
            this.usrNmLbl.TabIndex = 4;
            this.usrNmLbl.Text = "Username";
            // 
            // pwLbl
            // 
            this.pwLbl.AutoSize = true;
            this.pwLbl.Location = new System.Drawing.Point(82, 68);
            this.pwLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pwLbl.Name = "pwLbl";
            this.pwLbl.Size = new System.Drawing.Size(53, 13);
            this.pwLbl.TabIndex = 5;
            this.pwLbl.Text = "Password";
            // 
            // logOnBtn
            // 
            this.logOnBtn.Location = new System.Drawing.Point(96, 126);
            this.logOnBtn.Margin = new System.Windows.Forms.Padding(2);
            this.logOnBtn.Name = "logOnBtn";
            this.logOnBtn.Size = new System.Drawing.Size(56, 28);
            this.logOnBtn.TabIndex = 2;
            this.logOnBtn.Text = "Log On";
            this.logOnBtn.UseVisualStyleBackColor = true;
            this.logOnBtn.Click += new System.EventHandler(this.logOnBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(179, 126);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(56, 28);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // pwTxtBx
            // 
            this.pwTxtBx.Location = new System.Drawing.Point(96, 83);
            this.pwTxtBx.Margin = new System.Windows.Forms.Padding(2);
            this.pwTxtBx.Name = "pwTxtBx";
            this.pwTxtBx.Size = new System.Drawing.Size(139, 20);
            this.pwTxtBx.TabIndex = 1;
            this.pwTxtBx.Text = "Enter password";
            this.pwTxtBx.Enter += new System.EventHandler(this.pwTxtBx_Enter);
            this.pwTxtBx.Leave += new System.EventHandler(this.pwTxtBx_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 211);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pwTxtBx);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.logOnBtn);
            this.Controls.Add(this.pwLbl);
            this.Controls.Add(this.usrNmLbl);
            this.Controls.Add(this.unTxtBx);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiny Tents LLC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox unTxtBx;
        private System.Windows.Forms.Label usrNmLbl;
        private System.Windows.Forms.Label pwLbl;
        private System.Windows.Forms.Button logOnBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox pwTxtBx;
        private System.Windows.Forms.Button button1;
    }
}

