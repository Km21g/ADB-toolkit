using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ADBWindowsApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            string adbOutput = ExecuteAdbCommand("shell dumpsys account");
            txtOutput.Text = adbOutput;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            using var conn = new SQLiteConnection("Data Source=C:\\Users\\NFSU_ADMIN\\Desktop\\tables\\adb.db");
            conn.Open();

            string[] lines = txtOutput.Text.Split('\n');
            foreach (var line in lines)
            {
                if (line.Contains("Account {")) // crude filter
                {
                    string[] parts = line.Split(':');
                    string name = parts[1].Split(',')[0].Trim();
                    string email = parts[1].Contains(",") ? parts[1].Split(',')[1].Trim() : "";

                    var cmd = new SQLiteCommand("INSERT INTO LoginAccountsTable (AccountName, EmailAddress) VALUES (@n, @e)", conn);
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\NFSU_ADMIN\Desktop\.txt files\LoginAccountsReport.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, txtOutput.Text);
            MessageBox.Show("Login accounts report saved.");
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            new DataViewForm("LoginAccountsTable").Show();
        }

        private string ExecuteAdbCommand(string command)
        {
            var startInfo = new ProcessStartInfo("adb", command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using var process = Process.Start(startInfo);
            return process.StandardOutput.ReadToEnd();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}

