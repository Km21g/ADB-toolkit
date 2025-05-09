namespace ADBWindowsApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnViewData;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLoadData = new Button();
            btnSaveData = new Button();
            btnGenerateReport = new Button();
            btnViewData = new Button();
            txtOutput = new TextBox();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnLoadData
            // 
            btnLoadData.Location = new Point(20, 220);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(100, 30);
            btnLoadData.TabIndex = 2;
            btnLoadData.Text = "Load Data";
            btnLoadData.UseVisualStyleBackColor = true;
            btnLoadData.Click += btnLoadData_Click;
            // 
            // btnSaveData
            // 
            btnSaveData.Location = new Point(130, 220);
            btnSaveData.Name = "btnSaveData";
            btnSaveData.Size = new Size(100, 30);
            btnSaveData.TabIndex = 3;
            btnSaveData.Text = "Save Data";
            btnSaveData.UseVisualStyleBackColor = true;
            btnSaveData.Click += btnSaveData_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(240, 220);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(100, 30);
            btnGenerateReport.TabIndex = 4;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnViewData
            // 
            btnViewData.Location = new Point(130, 260);
            btnViewData.Name = "btnViewData";
            btnViewData.Size = new Size(100, 30);
            btnViewData.TabIndex = 5;
            btnViewData.Text = "View Data";
            btnViewData.UseVisualStyleBackColor = true;
            btnViewData.Click += btnViewData_Click;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(20, 49);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(360, 150);
            txtOutput.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(115, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Login Accounts";
            lblTitle.Click += lblTitle_Click;
            // 
            // LoginForm
            // 
            ClientSize = new Size(400, 310);
            Controls.Add(lblTitle);
            Controls.Add(txtOutput);
            Controls.Add(btnLoadData);
            Controls.Add(btnSaveData);
            Controls.Add(btnGenerateReport);
            Controls.Add(btnViewData);
            Name = "LoginForm";
            Text = "Login Accounts";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
