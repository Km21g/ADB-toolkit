using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ADBWindowsApp
{
    public partial class DeviceInfoForm : Form
    {
        public DeviceInfoForm()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            string cpuInfo = ExecuteAdbCommand("shell cat /proc/cpuinfo");
            string memInfo = ExecuteAdbCommand("shell cat /proc/meminfo");
            txtOutput.Text = $"CPU Info:\n{cpuInfo}\n\nMemory Info:\n{memInfo}";
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            string[] parts = txtOutput.Text.Split(new[] { "CPU Info:", "Memory Info:" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) return;

            using var conn = new SQLiteConnection("Data Source=C:\\Users\\NFSU_ADMIN\\Desktop\\tables\\adb.db");
            conn.Open();
            string query = "INSERT INTO DeviceInfoTable (CPUInfo, MemoryInfo) VALUES (@cpu, @mem)";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@cpu", parts[0].Trim());
            cmd.Parameters.AddWithValue("@mem", parts[1].Trim());
            cmd.ExecuteNonQuery();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\NFSU_ADMIN\Desktop\.txt files\DeviceInfoReport.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, txtOutput.Text);
            MessageBox.Show("Device info report saved.");
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            new DataViewForm("DeviceInfoTable").Show();
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


