using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ADBWindowsApp
{
    public partial class DataViewForm : Form
    {
        private string _tableName;

        public DataViewForm(string tableName)
        {
            InitializeComponent();
            _tableName = tableName;
            LoadData();
        }

        private void LoadData()
        {
            string dbPath = @"C:\Users\NFSU_ADMIN\Desktop\tables\adb.db";
            string connectionString = $"Data Source={dbPath};Version=3;";
            string query = $"SELECT * FROM {_tableName}";

            using (var conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }
    }
}
