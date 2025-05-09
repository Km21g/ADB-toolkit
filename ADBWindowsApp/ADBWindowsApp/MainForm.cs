using System;
using System.Windows.Forms;

namespace ADBWindowsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnContacts_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            contactForm.Show();
            this.Hide();
        }

        private void btnSMSMessages_Click(object sender, EventArgs e)
        {
            SMSForm smsForm = new SMSForm();
            smsForm.Show();
            this.Hide();
        }

        private void btnCallLogs_Click(object sender, EventArgs e)
        {
            CallLogForm callLogForm = new CallLogForm();
            callLogForm.Show();
            this.Hide();
        }

        private void btnDeviceInfo_Click(object sender, EventArgs e)
        {
            DeviceInfoForm deviceInfoForm = new DeviceInfoForm();
            deviceInfoForm.Show();
            this.Hide();
        }

        private void btnLoginAccounts_Click(object sender, EventArgs e)
        {
            // Corrected class name from LoginAccountsForm to LoginForm
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

