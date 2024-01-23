namespace POSsible
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button30 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserName.Location = new System.Drawing.Point(626, 237);
            this.txtUserName.MaxLength = 250;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(117, 31);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_OnEnter);
            this.txtUserName.Leave += new System.EventHandler(this.Control_LeaveFocus);
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserPassword.Location = new System.Drawing.Point(626, 274);
            this.txtUserPassword.MaxLength = 250;
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(117, 31);
            this.txtUserPassword.TabIndex = 1;
            this.txtUserPassword.UseSystemPasswordChar = true;
            this.txtUserPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_OnEnter);
            this.txtUserPassword.Leave += new System.EventHandler(this.Control_LeaveFocus);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(450, 240);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(168, 25);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name / Id";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(574, 277);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(46, 25);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Pin";
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.LightCoral;
            this.lblMsg.Location = new System.Drawing.Point(517, 214);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(277, 16);
            this.lblMsg.TabIndex = 12;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::POSsible.Properties.Resources.divider;
            this.pictureBox5.Location = new System.Drawing.Point(244, 67);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(5, 597);
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox4.Location = new System.Drawing.Point(0, 723);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1016, 21);
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1016, 48);
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(419, 51);
            this.label1.MinimumSize = new System.Drawing.Size(400, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 150);
            this.label1.TabIndex = 14;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Navy;
            this.btnClose.Location = new System.Drawing.Point(650, 311);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Navy;
            this.btnOk.Location = new System.Drawing.Point(556, 311);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(93, 43);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Login";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::POSsible.Properties.Resources.image___vegiotable;
            this.pictureBox1.Location = new System.Drawing.Point(0, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 377);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnClear);
            this.panel4.Location = new System.Drawing.Point(277, 137);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(186, 56);
            this.panel4.TabIndex = 45;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::POSsible.Properties.Resources.clear_buton__172w_x_45_h;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(10, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(165, 45);
            this.btnClear.TabIndex = 42;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.button30);
            this.panel5.Controls.Add(this.button23);
            this.panel5.Controls.Add(this.button26);
            this.panel5.Controls.Add(this.button38);
            this.panel5.Controls.Add(this.button37);
            this.panel5.Controls.Add(this.button27);
            this.panel5.Controls.Add(this.button31);
            this.panel5.Controls.Add(this.button34);
            this.panel5.Controls.Add(this.button28);
            this.panel5.Controls.Add(this.button33);
            this.panel5.Controls.Add(this.button29);
            this.panel5.Controls.Add(this.button32);
            this.panel5.Location = new System.Drawing.Point(105, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(358, 130);
            this.panel5.TabIndex = 46;
            // 
            // button30
            // 
            this.button30.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button30.BackgroundImage")));
            this.button30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button30.Location = new System.Drawing.Point(67, 5);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(51, 52);
            this.button30.TabIndex = 29;
            this.button30.Text = "2";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.KeyPadkey_Click);
            // 
            // button23
            // 
            this.button23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button23.BackgroundImage")));
            this.button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.Location = new System.Drawing.Point(10, 5);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(51, 52);
            this.button23.TabIndex = 22;
            this.button23.Text = "1";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.KeyPadkey_Click);
            // 
            // button26
            // 
            this.button26.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button26.BackgroundImage")));
            this.button26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button26.Location = new System.Drawing.Point(293, 5);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(51, 52);
            this.button26.TabIndex = 25;
            this.button26.Text = "6";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.KeyPadkey_Click);
            // 
            // button38
            // 
            this.button38.BackgroundImage = global::POSsible.Properties.Resources.left_arrow__51w_x_52_h;
            this.button38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button38.Image = global::POSsible.Properties.Resources.left_arrow__51w_x_52_h1;
            this.button38.Location = new System.Drawing.Point(236, 63);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(51, 52);
            this.button38.TabIndex = 37;
            this.button38.Tag = "LEFT";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.keypadOtherKey_Click);
            // 
            // button37
            // 
            this.button37.BackgroundImage = global::POSsible.Properties.Resources.right_arrow_51w_x_52h;
            this.button37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button37.Image = global::POSsible.Properties.Resources.right_arrow_51w_x_52h1;
            this.button37.Location = new System.Drawing.Point(293, 63);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(51, 52);
            this.button37.TabIndex = 36;
            this.button37.Tag = "RIGHT";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.keypadOtherKey_Click);
            // 
            // button27
            // 
            this.button27.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button27.BackgroundImage")));
            this.button27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button27.Location = new System.Drawing.Point(236, 5);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(51, 52);
            this.button27.TabIndex = 26;
            this.button27.Text = "5";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.KeyPadkey_Click);
            // 
            // button31
            // 
            this.button31.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button31.BackgroundImage")));
            this.button31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button31.Location = new System.Drawing.Point(179, 63);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(51, 52);
            this.button31.TabIndex = 30;
            this.button31.Text = "0";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.KeyPadkey_Click);
            // 
            // button34
            // 
            this.button34.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button34.BackgroundImage")));
            this.button34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button34.Location = new System.Drawing.Point(10, 63);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(51, 52);
            this.button34.TabIndex = 33;
            this.button34.Text = "7";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.KeyPadkey_Click);
            // 
            // button28
            // 
            this.button28.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button28.BackgroundImage")));
            this.button28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button28.Location = new System.Drawing.Point(179, 5);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(51, 52);
            this.button28.TabIndex = 27;
            this.button28.Text = "4";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.KeyPadkey_Click);
            // 
            // button33
            // 
            this.button33.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button33.BackgroundImage")));
            this.button33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button33.Location = new System.Drawing.Point(67, 63);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(51, 52);
            this.button33.TabIndex = 32;
            this.button33.Text = "8";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.KeyPadkey_Click);
            // 
            // button29
            // 
            this.button29.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button29.BackgroundImage")));
            this.button29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button29.Location = new System.Drawing.Point(124, 5);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(51, 52);
            this.button29.TabIndex = 28;
            this.button29.Text = "3";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.KeyPadkey_Click);
            // 
            // button32
            // 
            this.button32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button32.BackgroundImage")));
            this.button32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(124, 63);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(51, 52);
            this.button32.TabIndex = 31;
            this.button32.Text = "9";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.KeyPadkey_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(333, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 203);
            this.panel1.TabIndex = 15;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1016, 744);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.txtUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1022, 726);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.VisibleChanged += new System.EventHandler(this.frmLogin_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Panel panel1;
    }
}