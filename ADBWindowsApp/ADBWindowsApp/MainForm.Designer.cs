namespace ADBWindowsApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnContacts;
        private System.Windows.Forms.Button btnSMSMessages;
        private System.Windows.Forms.Button btnCallLogs;
        private System.Windows.Forms.Button btnDeviceInfo;
        private System.Windows.Forms.Button btnLoginAccounts;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnContacts = new Button();
            btnSMSMessages = new Button();
            btnCallLogs = new Button();
            btnDeviceInfo = new Button();
            btnLoginAccounts = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnContacts
            // 
            btnContacts.Location = new Point(30, 30);
            btnContacts.Name = "btnContacts";
            btnContacts.Size = new Size(150, 40);
            btnContacts.TabIndex = 0;
            btnContacts.Text = "Contacts";
            btnContacts.UseVisualStyleBackColor = true;
            btnContacts.Click += btnContacts_Click;
            // 
            // btnSMSMessages
            // 
            btnSMSMessages.Location = new Point(200, 30);
            btnSMSMessages.Name = "btnSMSMessages";
            btnSMSMessages.Size = new Size(150, 40);
            btnSMSMessages.TabIndex = 1;
            btnSMSMessages.Text = "SMS Messages";
            btnSMSMessages.UseVisualStyleBackColor = true;
            btnSMSMessages.Click += btnSMSMessages_Click;
            // 
            // btnCallLogs
            // 
            btnCallLogs.Location = new Point(30, 90);
            btnCallLogs.Name = "btnCallLogs";
            btnCallLogs.Size = new Size(150, 40);
            btnCallLogs.TabIndex = 2;
            btnCallLogs.Text = "Call Logs";
            btnCallLogs.UseVisualStyleBackColor = true;
            btnCallLogs.Click += btnCallLogs_Click;
            // 
            // btnDeviceInfo
            // 
            btnDeviceInfo.Location = new Point(200, 90);
            btnDeviceInfo.Name = "btnDeviceInfo";
            btnDeviceInfo.Size = new Size(150, 40);
            btnDeviceInfo.TabIndex = 3;
            btnDeviceInfo.Text = "Device Info";
            btnDeviceInfo.UseVisualStyleBackColor = true;
            btnDeviceInfo.Click += btnDeviceInfo_Click;
            // 
            // btnLoginAccounts
            // 
            btnLoginAccounts.Location = new Point(30, 150);
            btnLoginAccounts.Name = "btnLoginAccounts";
            btnLoginAccounts.Size = new Size(150, 40);
            btnLoginAccounts.TabIndex = 4;
            btnLoginAccounts.Text = "Login Accounts";
            btnLoginAccounts.UseVisualStyleBackColor = true;
            btnLoginAccounts.Click += btnLoginAccounts_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(200, 150);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(150, 40);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(379, 224);
            Controls.Add(btnExit);
            Controls.Add(btnLoginAccounts);
            Controls.Add(btnDeviceInfo);
            Controls.Add(btnCallLogs);
            Controls.Add(btnSMSMessages);
            Controls.Add(btnContacts);
            Name = "MainForm";
            Text = "Main Menu";
            ResumeLayout(false);
        }
    }
}
