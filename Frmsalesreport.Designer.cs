namespace POSsible
{
    partial class Frmsalesreport
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
            this.btnok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbltotalsales = new System.Windows.Forms.Label();
            this.lblnoinvoice = new System.Windows.Forms.Label();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.btnsearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnok
            // 
            this.btnok.BackgroundImage = global::POSsible.Properties.Resources.ADD_110w_x_33h;
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnok.Location = new System.Drawing.Point(159, 147);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(110, 33);
            this.btnok.TabIndex = 0;
            this.btnok.Text = "Ok";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Sales:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Transactions:";
            // 
            // lbltotalsales
            // 
            this.lbltotalsales.AutoSize = true;
            this.lbltotalsales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalsales.Location = new System.Drawing.Point(128, 93);
            this.lbltotalsales.Name = "lbltotalsales";
            this.lbltotalsales.Size = new System.Drawing.Size(0, 18);
            this.lbltotalsales.TabIndex = 3;
            // 
            // lblnoinvoice
            // 
            this.lblnoinvoice.AutoSize = true;
            this.lblnoinvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnoinvoice.Location = new System.Drawing.Point(217, 63);
            this.lblnoinvoice.Name = "lblnoinvoice";
            this.lblnoinvoice.Size = new System.Drawing.Size(0, 18);
            this.lblnoinvoice.TabIndex = 4;
            // 
            // dpDate
            // 
            this.dpDate.CustomFormat = "dd/MM/yyyy";
            this.dpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDate.Location = new System.Drawing.Point(26, 21);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(209, 24);
            this.dpDate.TabIndex = 5;
            this.dpDate.Visible = false;
            // 
            // btnsearch
            // 
            this.btnsearch.BackgroundImage = global::POSsible.Properties.Resources.Searchfinal_32x_24;
            this.btnsearch.Location = new System.Drawing.Point(237, 21);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(32, 24);
            this.btnsearch.TabIndex = 6;
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Visible = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // Frmsalesreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(291, 199);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.dpDate);
            this.Controls.Add(this.lblnoinvoice);
            this.Controls.Add(this.lbltotalsales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnok);
            this.MaximizeBox = false;
            this.Name = "Frmsalesreport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.Load += new System.EventHandler(this.Frmsalesreport_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltotalsales;
        private System.Windows.Forms.Label lblnoinvoice;
        private System.Windows.Forms.DateTimePicker dpDate;
        private System.Windows.Forms.Button btnsearch;
    }
}