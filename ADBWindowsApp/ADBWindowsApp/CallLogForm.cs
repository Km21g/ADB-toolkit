using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ADBWindowsApp
{
    public partial class CallLogForm : Form
    {
        public CallLogForm()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            txtOutput.Text = ExecuteAdbCommand("shell content query --uri content://call_log/calls/");
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            string[] logs = txtOutput.Text.Split('\n');
            using var conn = new SQLiteConnection("Data Source=C:\\Users\\NFSU_ADMIN\\Desktop\\tables\\adb.db");
            conn.Open();
            foreach (var log in logs)
            {
                if (log.Trim() == "") continue;
                var data = log.Split(',');
                string number = data[0].Split('=')[1].Trim();
                string type = data[1].Split('=')[1].Trim();
                string duration = data[2].Split('=')[1].Trim();

                var cmd = new SQLiteCommand("INSERT INTO CallLogsTable (Number, CallType, Duration) VALUES (@n, @t, @d)", conn);
                cmd.Parameters.AddWithValue("@n", number);
                cmd.Parameters.AddWithValue("@t", type);
                cmd.Parameters.AddWithValue("@d", duration);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\NFSU_ADMIN\Desktop\.txt files\CallLogsReport.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, txtOutput.Text);
            MessageBox.Show("Call log report saved.");
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            new DataViewForm("CallLogsTable").Show();
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
    }
}

