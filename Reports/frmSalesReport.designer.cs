namespace POSsible.Reports
{
    partial class frmSalesReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSalesReport = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCostOfSales = new System.Windows.Forms.Label();
            this.txtCostOfSales = new System.Windows.Forms.TextBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.radDepartmentWise = new System.Windows.Forms.RadioButton();
            this.radAllDepartment = new System.Windows.Forms.RadioButton();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpToTime = new System.Windows.Forms.DateTimePicker();
            this.dtpFromTime = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSalesReport
            // 
            this.lblSalesReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesReport.Location = new System.Drawing.Point(-3, 19);
            this.lblSalesReport.Name = "lblSalesReport";
            this.lblSalesReport.Size = new System.Drawing.Size(614, 26);
            this.lblSalesReport.TabIndex = 0;
            this.lblSalesReport.Text = "Sales Summary Report";
            this.lblSalesReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCostOfSales);
            this.panel1.Controls.Add(this.txtCostOfSales);
            this.panel1.Controls.Add(this.cmbDepartment);
            this.panel1.Controls.Add(this.radDepartmentWise);
            this.panel1.Controls.Add(this.radAllDepartment);
            this.panel1.Location = new System.Drawing.Point(16, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 60);
            this.panel1.TabIndex = 7;
            // 
            // lblCostOfSales
            // 
            this.lblCostOfSales.AutoSize = true;
            this.lblCostOfSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostOfSales.Location = new System.Drawing.Point(275, 19);
            this.lblCostOfSales.Name = "lblCostOfSales";
            this.lblCostOfSales.Size = new System.Drawing.Size(281, 20);
            this.lblCostOfSales.TabIndex = 4;
            this.lblCostOfSales.Text = "% Cost Of Sales (By Default 75%)";
            // 
            // txtCostOfSales
            // 
            this.txtCostOfSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostOfSales.Location = new System.Drawing.Point(212, 16);
            this.txtCostOfSales.Name = "txtCostOfSales";
            this.txtCostOfSales.Size = new System.Drawing.Size(62, 26);
            this.txtCostOfSales.TabIndex = 3;
            this.txtCostOfSales.TextChanged += new System.EventHandler(this.txtCostOfSales_TextChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(212, 72);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(322, 26);
            this.cmbDepartment.TabIndex = 2;
            this.cmbDepartment.Visible = false;
            // 
            // radDepartmentWise
            // 
            this.radDepartmentWise.AutoSize = true;
            this.radDepartmentWise.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDepartmentWise.Location = new System.Drawing.Point(20, 72);
            this.radDepartmentWise.Name = "radDepartmentWise";
            this.radDepartmentWise.Size = new System.Drawing.Size(166, 24);
            this.radDepartmentWise.TabIndex = 0;
            this.radDepartmentWise.TabStop = true;
            this.radDepartmentWise.Text = "Department Wise";
            this.radDepartmentWise.UseVisualStyleBackColor = true;
            this.radDepartmentWise.Visible = false;
            this.radDepartmentWise.CheckedChanged += new System.EventHandler(this.radDepartmentWise_CheckedChanged);
            // 
            // radAllDepartment
            // 
            this.radAllDepartment.AutoSize = true;
            this.radAllDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAllDepartment.Location = new System.Drawing.Point(20, 17);
            this.radAllDepartment.Name = "radAllDepartment";
            this.radAllDepartment.Size = new System.Drawing.Size(147, 24);
            this.radAllDepartment.TabIndex = 1;
            this.radAllDepartment.Text = "All Department";
            this.radAllDepartment.UseVisualStyleBackColor = true;
            this.radAllDepartment.CheckedChanged += new System.EventHandler(this.radAllDepartment_CheckedChanged);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.SystemColors.Control;
            this.btnShow.BackgroundImage = global::POSsible.Properties.Resources.ADD_110w_x_33h;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.Black;
            this.btnShow.Location = new System.Drawing.Point(370, 261);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(110, 33);
            this.btnShow.TabIndex = 93;
            this.btnShow.Text = "SHOW";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.BackgroundImage = global::POSsible.Properties.Resources.Exit_110w_x_33h;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(481, 261);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 33);
            this.btnExit.TabIndex = 94;
            this.btnExit.Text = "E&XIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dtpToTime);
            this.panel2.Controls.Add(this.dtpFromTime);
            this.panel2.Controls.Add(this.dtpToDate);
            this.panel2.Controls.Add(this.dtpFromDate);
            this.panel2.Controls.Add(this.lblToDate);
            this.panel2.Controls.Add(this.lblFromDate);
            this.panel2.Location = new System.Drawing.Point(16, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 95);
            this.panel2.TabIndex = 97;
            // 
            // dtpToTime
            // 
            this.dtpToTime.CustomFormat = "HH:MM:SS";
            this.dtpToTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpToTime.Location = new System.Drawing.Point(378, 56);
            this.dtpToTime.Name = "dtpToTime";
            this.dtpToTime.ShowUpDown = true;
            this.dtpToTime.Size = new System.Drawing.Size(150, 26);
            this.dtpToTime.TabIndex = 96;
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.CustomFormat = "HH:MM:SS";
            this.dtpFromTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFromTime.Location = new System.Drawing.Point(378, 12);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.ShowUpDown = true;
            this.dtpFromTime.Size = new System.Drawing.Size(150, 26);
            this.dtpFromTime.TabIndex = 95;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(118, 56);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(238, 26);
            this.dtpToDate.TabIndex = 4;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(118, 12);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(238, 26);
            this.dtpFromDate.TabIndex = 3;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(16, 59);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(73, 20);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "To Date";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(16, 15);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(94, 20);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "From Date";
            // 
            // frmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(610, 308);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSalesReport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmSalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSalesReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radAllDepartment;
        private System.Windows.Forms.RadioButton radDepartmentWise;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblCostOfSales;
        private System.Windows.Forms.TextBox txtCostOfSales;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpToTime;
        private System.Windows.Forms.DateTimePicker dtpFromTime;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
    }
}