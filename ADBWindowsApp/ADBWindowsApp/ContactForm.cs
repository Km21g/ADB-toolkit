using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ADBWindowsApp
{
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            string adbOutput = ExecuteAdbCommand("shell content query --uri content://contacts/phones/ --projection display_name:number");
            txtOutput.Text = adbOutput;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            string[] contacts = txtOutput.Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\Users\\NFSU_ADMIN\\Desktop\\tables\\adb.db"))
            {
                conn.Open();

                foreach (var contact in contacts)
                {
                    try
                    {
                        string name = "";
                        string number = "";

                        string[] parts = contact.Split(',');
                        foreach (string part in parts)
                        {
                            if (part.Contains("display_name="))
                                name = part.Split(new[] { "display_name=" }, StringSplitOptions.None)[1].Trim();
                            else if (part.Contains("number="))
                                number = part.Split(new[] { "number=" }, StringSplitOptions.None)[1].Trim();
                        }

                        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(number))
                        {
                            string query = "INSERT INTO ContactsTable (Name, PhoneNumber) VALUES (@Name, @Number)";
                            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Name", name);
                                cmd.Parameters.AddWithValue("@Number", number);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save contact:\n{contact}\n\nError: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                MessageBox.Show("Contacts saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string reportContent = txtOutput.Text;
            string path = @"C:\Users\NFSU_ADMIN\Desktop\.txt files\ContactsReport.txt";

            try
            {
                File.WriteAllText(path, reportContent);
                MessageBox.Show("Report saved to: " + path, "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing report: " + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            var dataViewForm = new DataViewForm("ContactsTable");
            dataViewForm.Show();
        }

        private string ExecuteAdbCommand(string command)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("ADB command failed: " + ex.Message, "ADB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
    }
}




