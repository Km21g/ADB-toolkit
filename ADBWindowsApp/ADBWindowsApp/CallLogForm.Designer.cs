namespace ADBWindowsApp
{
    partial class CallLogForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnViewData;
        private System.Windows.Forms.TextBox txtOutput;

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
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnViewData = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();

            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(20, 20);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(100, 30);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);

            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(130, 20);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(100, 30);
            this.btnSaveData.TabIndex = 1;
            this.btnSaveData.Text = "Save Data";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);

            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(240, 20);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(120, 30);
            this.btnGenerateReport.TabIndex = 2;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);

            // 
            // btnViewData
            // 
            this.btnViewData.Location = new System.Drawing.Point(370, 20);
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.Size = new System.Drawing.Size(100, 30);
            this.btnViewData.TabIndex = 3;
            this.btnViewData.Text = "View Data";
            this.btnViewData.UseVisualStyleBackColor = true;
            this.btnViewData.Click += new System.EventHandler(this.btnViewData_Click);

            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(20, 70);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(450, 250);
            this.txtOutput.TabIndex = 4;

            // 
            // CallLogForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnViewData);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.btnLoadData);
            this.Name = "CallLogForm";
            this.Text = "Call Logs";
        }
    }
}
