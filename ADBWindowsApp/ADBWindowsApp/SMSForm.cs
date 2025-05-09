using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ADBWindowsApp
{
    public partial class SMSForm : Form
    {
        public SMSForm()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            string adbOutput = ExecuteAdbCommand("shell content query --uri content://sms/inbox --projection address:body");
            txtOutput.Text = adbOutput;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            string[] messages = txtOutput.Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\Users\\NFSU_ADMIN\\Desktop\\tables\\adb.db"))
            {
                conn.Open();
                foreach (var message in messages)
                {
                    string[] data = message.Split(',');
                    if (data.Length < 2) continue;

                    string smsSender = data[0].Split('=')[1].Trim();
                    string smsBody = data[1].Split('=')[1].Trim();

                    string query = "INSERT INTO MessagesTable (Sender, Message) VALUES (@Sender, @Message)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Sender", smsSender);
                        cmd.Parameters.AddWithValue("@Message", smsBody);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string reportPath = @"C:\Users\NFSU_ADMIN\Desktop\.txt files\SMSReport.txt";
            File.WriteAllText(reportPath, txtOutput.Text);
            MessageBox.Show($"Report saved to:\n{reportPath}", "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            var dataViewForm = new DataViewForm("MessagesTable");
            dataViewForm.Show();
        }

        private string ExecuteAdbCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "adb",
                Arguments = command,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return output;
            }
        }
    }
}



