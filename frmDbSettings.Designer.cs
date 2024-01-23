namespace POSsible
{
    partial class frmDbSettings
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
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.lblDatabaseServer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtDatabaseUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDatabaseServer = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.lblSecurityCode = new System.Windows.Forms.Label();
            this.txtSecurityCode = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtTerminalIP = new System.Windows.Forms.TextBox();
            this.lblTerminalIP = new System.Windows.Forms.Label();
            this.txtPrinterName = new System.Windows.Forms.TextBox();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.txtScalePort = new System.Windows.Forms.TextBox();
            this.lblScalePort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseName.ForeColor = System.Drawing.Color.Black;
            this.lblDatabaseName.Location = new System.Drawing.Point(37, 139);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(128, 18);
            this.lblDatabaseName.TabIndex = 0;
            this.lblDatabaseName.Text = "Database Name";
            // 
            // lblDatabaseServer
            // 
            this.lblDatabaseServer.AutoSize = true;
            this.lblDatabaseServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseServer.ForeColor = System.Drawing.Color.Black;
            this.lblDatabaseServer.Location = new System.Drawing.Point(37, 108);
            this.lblDatabaseServer.Name = "lblDatabaseServer";
            this.lblDatabaseServer.Size = new System.Drawing.Size(133, 18);
            this.lblDatabaseServer.TabIndex = 1;
            this.lblDatabaseServer.Text = "Database Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Black;
            this.lblUserName.Location = new System.Drawing.Point(37, 47);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(120, 18);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "Database User";
            // 
            // txtDatabaseUser
            // 
            this.txtDatabaseUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatabaseUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabaseUser.Location = new System.Drawing.Point(203, 45);
            this.txtDatabaseUser.Name = "txtDatabaseUser";
            this.txtDatabaseUser.Size = new System.Drawing.Size(191, 24);
            this.txtDatabaseUser.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(203, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(191, 24);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtDatabaseServer
            // 
            this.txtDatabaseServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatabaseServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabaseServer.Location = new System.Drawing.Point(203, 106);
            this.txtDatabaseServer.Name = "txtDatabaseServer";
            this.txtDatabaseServer.Size = new System.Drawing.Size(191, 24);
            this.txtDatabaseServer.TabIndex = 6;
            this.txtDatabaseServer.TextChanged += new System.EventHandler(this.txtDatabaseServer_TextChanged);
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabaseName.Location = new System.Drawing.Point(203, 137);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(191, 24);
            this.txtDatabaseName.TabIndex = 7;
            // 
            // lblSecurityCode
            // 
            this.lblSecurityCode.AutoSize = true;
            this.lblSecurityCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurityCode.ForeColor = System.Drawing.Color.Black;
            this.lblSecurityCode.Location = new System.Drawing.Point(37, 325);
            this.lblSecurityCode.Name = "lblSecurityCode";
            this.lblSecurityCode.Size = new System.Drawing.Size(114, 18);
            this.lblSecurityCode.TabIndex = 8;
            this.lblSecurityCode.Text = "Security Code";
            this.lblSecurityCode.Visible = false;
            // 
            // txtSecurityCode
            // 
            this.txtSecurityCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecurityCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecurityCode.Location = new System.Drawing.Point(172, 324);
            this.txtSecurityCode.Name = "txtSecurityCode";
            this.txtSecurityCode.Size = new System.Drawing.Size(140, 24);
            this.txtSecurityCode.TabIndex = 9;
            this.txtSecurityCode.Visible = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.Control;
            this.btnSubmit.BackgroundImage = global::POSsible.Properties.Resources.ADD_110w_x_33h;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.Navy;
            this.btnSubmit.Location = new System.Drawing.Point(171, 272);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(110, 33);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Save";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.BackgroundImage = global::POSsible.Properties.Resources.Exit_110w_x_33h;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Navy;
            this.btnCancel.Location = new System.Drawing.Point(283, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 33);
            this.btnCancel.TabIndex = 78;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMsg.Location = new System.Drawing.Point(70, 9);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 18);
            this.lblMsg.TabIndex = 79;
            // 
            // txtTerminalIP
            // 
            this.txtTerminalIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTerminalIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerminalIP.Location = new System.Drawing.Point(203, 169);
            this.txtTerminalIP.Name = "txtTerminalIP";
            this.txtTerminalIP.Size = new System.Drawing.Size(191, 24);
            this.txtTerminalIP.TabIndex = 8;
            // 
            // lblTerminalIP
            // 
            this.lblTerminalIP.AutoSize = true;
            this.lblTerminalIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminalIP.ForeColor = System.Drawing.Color.Black;
            this.lblTerminalIP.Location = new System.Drawing.Point(37, 171);
            this.lblTerminalIP.Name = "lblTerminalIP";
            this.lblTerminalIP.Size = new System.Drawing.Size(93, 18);
            this.lblTerminalIP.TabIndex = 80;
            this.lblTerminalIP.Text = "Terminal IP";
            // 
            // txtPrinterName
            // 
            this.txtPrinterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrinterName.Location = new System.Drawing.Point(203, 199);
            this.txtPrinterName.Name = "txtPrinterName";
            this.txtPrinterName.Size = new System.Drawing.Size(191, 24);
            this.txtPrinterName.TabIndex = 9;
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.AutoSize = true;
            this.lblPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinterName.ForeColor = System.Drawing.Color.Black;
            this.lblPrinterName.Location = new System.Drawing.Point(37, 201);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.Size = new System.Drawing.Size(107, 18);
            this.lblPrinterName.TabIndex = 82;
            this.lblPrinterName.Text = "Printer Name";
            // 
            // txtScalePort
            // 
            this.txtScalePort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScalePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScalePort.Location = new System.Drawing.Point(203, 229);
            this.txtScalePort.Name = "txtScalePort";
            this.txtScalePort.Size = new System.Drawing.Size(191, 24);
            this.txtScalePort.TabIndex = 10;
            // 
            // lblScalePort
            // 
            this.lblScalePort.AutoSize = true;
            this.lblScalePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScalePort.ForeColor = System.Drawing.Color.Black;
            this.lblScalePort.Location = new System.Drawing.Point(37, 231);
            this.lblScalePort.Name = "lblScalePort";
            this.lblScalePort.Size = new System.Drawing.Size(136, 18);
            this.lblScalePort.TabIndex = 84;
            this.lblScalePort.Text = "Scale Port Name";
            // 
            // frmDbSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(420, 323);
            this.Controls.Add(this.txtScalePort);
            this.Controls.Add(this.lblScalePort);
            this.Controls.Add(this.txtPrinterName);
            this.Controls.Add(this.lblPrinterName);
            this.Controls.Add(this.txtTerminalIP);
            this.Controls.Add(this.lblTerminalIP);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtSecurityCode);
            this.Controls.Add(this.lblSecurityCode);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.txtDatabaseServer);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtDatabaseUser);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDatabaseServer);
            this.Controls.Add(this.lblDatabaseName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmDbSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.Label lblDatabaseServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtDatabaseUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDatabaseServer;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label lblSecurityCode;
        private System.Windows.Forms.TextBox txtSecurityCode;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtTerminalIP;
        private System.Windows.Forms.Label lblTerminalIP;
        private System.Windows.Forms.TextBox txtPrinterName;
        private System.Windows.Forms.Label lblPrinterName;
        private System.Windows.Forms.TextBox txtScalePort;
        private System.Windows.Forms.Label lblScalePort;
    }
}