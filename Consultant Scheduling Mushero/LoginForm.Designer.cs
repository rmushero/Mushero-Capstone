
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.unTxtBx = new System.Windows.Forms.TextBox();
            this.usrNmLbl = new System.Windows.Forms.Label();
            this.pwLbl = new System.Windows.Forms.Label();
            this.logOnBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.pwTxtBx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // unTxtBx
            // 
            resources.ApplyResources(this.unTxtBx, "unTxtBx");
            this.unTxtBx.Name = "unTxtBx";
            // 
            // usrNmLbl
            // 
            resources.ApplyResources(this.usrNmLbl, "usrNmLbl");
            this.usrNmLbl.Name = "usrNmLbl";
            // 
            // pwLbl
            // 
            resources.ApplyResources(this.pwLbl, "pwLbl");
            this.pwLbl.Name = "pwLbl";
            // 
            // logOnBtn
            // 
            resources.ApplyResources(this.logOnBtn, "logOnBtn");
            this.logOnBtn.Name = "logOnBtn";
            this.logOnBtn.UseVisualStyleBackColor = true;
            this.logOnBtn.Click += new System.EventHandler(this.logOnBtn_Click);
            // 
            // cancelBtn
            // 
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // pwTxtBx
            // 
            resources.ApplyResources(this.pwTxtBx, "pwTxtBx");
            this.pwTxtBx.Name = "pwTxtBx";
            this.pwTxtBx.Enter += new System.EventHandler(this.pwTxtBx_Enter);
            this.pwTxtBx.Leave += new System.EventHandler(this.pwTxtBx_Leave);
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pwTxtBx);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.logOnBtn);
            this.Controls.Add(this.pwLbl);
            this.Controls.Add(this.usrNmLbl);
            this.Controls.Add(this.unTxtBx);
            this.Name = "LoginForm";
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
    }
}

