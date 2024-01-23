namespace POSsible
{
    partial class frmPreProcMsg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreProcMsg));
            this.txtStartShiftCash = new System.Windows.Forms.TextBox();
            this.lblCashInDrawer = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDoubleZero = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnSix = new System.Windows.Forms.Button();
            this.btnEight = new System.Windows.Forms.Button();
            this.btnOne = new System.Windows.Forms.Button();
            this.btnTwo = new System.Windows.Forms.Button();
            this.btnFour = new System.Windows.Forms.Button();
            this.btnFive = new System.Windows.Forms.Button();
            this.btnThree = new System.Windows.Forms.Button();
            this.btnNine = new System.Windows.Forms.Button();
            this.btnSeven = new System.Windows.Forms.Button();
            this.btnClr = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStartShiftCash
            // 
            this.txtStartShiftCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartShiftCash.Location = new System.Drawing.Point(142, 120);
            this.txtStartShiftCash.MaxLength = 8;
            this.txtStartShiftCash.Name = "txtStartShiftCash";
            this.txtStartShiftCash.Size = new System.Drawing.Size(152, 26);
            this.txtStartShiftCash.TabIndex = 0;
            this.txtStartShiftCash.TextChanged += new System.EventHandler(this.txtStartShiftCash_TextChanged);
            this.txtStartShiftCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartShiftCash_KeyPress);
            // 
            // lblCashInDrawer
            // 
            this.lblCashInDrawer.AutoSize = true;
            this.lblCashInDrawer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashInDrawer.ForeColor = System.Drawing.Color.White;
            this.lblCashInDrawer.Location = new System.Drawing.Point(137, 92);
            this.lblCashInDrawer.Name = "lblCashInDrawer";
            this.lblCashInDrawer.Size = new System.Drawing.Size(162, 20);
            this.lblCashInDrawer.TabIndex = 8;
            this.lblCashInDrawer.Text = "Start Cash Amount";
            this.lblCashInDrawer.Click += new System.EventHandler(this.lblStartShiftCash_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(253, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 57);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(99, 425);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 57);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDoubleZero);
            this.panel1.Controls.Add(this.btnZero);
            this.panel1.Controls.Add(this.btnDot);
            this.panel1.Controls.Add(this.btnSix);
            this.panel1.Controls.Add(this.btnEight);
            this.panel1.Controls.Add(this.btnOne);
            this.panel1.Controls.Add(this.btnTwo);
            this.panel1.Controls.Add(this.btnFour);
            this.panel1.Controls.Add(this.btnFive);
            this.panel1.Controls.Add(this.btnThree);
            this.panel1.Controls.Add(this.btnNine);
            this.panel1.Controls.Add(this.btnSeven);
            this.panel1.Location = new System.Drawing.Point(93, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 269);
            this.panel1.TabIndex = 15;
            // 
            // btnDoubleZero
            // 
            this.btnDoubleZero.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDoubleZero.BackgroundImage")));
            this.btnDoubleZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoubleZero.Location = new System.Drawing.Point(160, 204);
            this.btnDoubleZero.Name = "btnDoubleZero";
            this.btnDoubleZero.Size = new System.Drawing.Size(64, 57);
            this.btnDoubleZero.TabIndex = 37;
            this.btnDoubleZero.Text = "00";
            this.btnDoubleZero.UseVisualStyleBackColor = true;
            this.btnDoubleZero.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnZero
            // 
            this.btnZero.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZero.BackgroundImage")));
            this.btnZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZero.Location = new System.Drawing.Point(89, 204);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(64, 57);
            this.btnZero.TabIndex = 29;
            this.btnZero.Text = "0";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnDot
            // 
            this.btnDot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDot.BackgroundImage")));
            this.btnDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDot.Location = new System.Drawing.Point(18, 204);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(64, 57);
            this.btnDot.TabIndex = 30;
            this.btnDot.Text = ".";
            this.btnDot.UseVisualStyleBackColor = true;
            this.btnDot.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnSix
            // 
            this.btnSix.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSix.BackgroundImage")));
            this.btnSix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSix.Location = new System.Drawing.Point(160, 70);
            this.btnSix.Name = "btnSix";
            this.btnSix.Size = new System.Drawing.Size(64, 57);
            this.btnSix.TabIndex = 36;
            this.btnSix.Text = "6";
            this.btnSix.UseVisualStyleBackColor = true;
            this.btnSix.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnEight
            // 
            this.btnEight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEight.BackgroundImage")));
            this.btnEight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEight.Location = new System.Drawing.Point(89, 137);
            this.btnEight.Name = "btnEight";
            this.btnEight.Size = new System.Drawing.Size(64, 57);
            this.btnEight.TabIndex = 35;
            this.btnEight.Text = "8";
            this.btnEight.UseVisualStyleBackColor = true;
            this.btnEight.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnOne
            // 
            this.btnOne.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOne.BackgroundImage")));
            this.btnOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOne.Location = new System.Drawing.Point(18, 4);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(64, 57);
            this.btnOne.TabIndex = 34;
            this.btnOne.Text = "1";
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnTwo
            // 
            this.btnTwo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTwo.BackgroundImage")));
            this.btnTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTwo.Location = new System.Drawing.Point(89, 4);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(64, 57);
            this.btnTwo.TabIndex = 33;
            this.btnTwo.Text = "2";
            this.btnTwo.UseVisualStyleBackColor = true;
            this.btnTwo.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnFour
            // 
            this.btnFour.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFour.BackgroundImage")));
            this.btnFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFour.Location = new System.Drawing.Point(18, 70);
            this.btnFour.Name = "btnFour";
            this.btnFour.Size = new System.Drawing.Size(64, 57);
            this.btnFour.TabIndex = 32;
            this.btnFour.Text = "4";
            this.btnFour.UseVisualStyleBackColor = true;
            this.btnFour.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnFive
            // 
            this.btnFive.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFive.BackgroundImage")));
            this.btnFive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFive.Location = new System.Drawing.Point(89, 70);
            this.btnFive.Name = "btnFive";
            this.btnFive.Size = new System.Drawing.Size(64, 57);
            this.btnFive.TabIndex = 31;
            this.btnFive.Text = "5";
            this.btnFive.UseVisualStyleBackColor = true;
            this.btnFive.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnThree
            // 
            this.btnThree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThree.BackgroundImage")));
            this.btnThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThree.Location = new System.Drawing.Point(160, 4);
            this.btnThree.Name = "btnThree";
            this.btnThree.Size = new System.Drawing.Size(64, 57);
            this.btnThree.TabIndex = 28;
            this.btnThree.Text = "3";
            this.btnThree.UseVisualStyleBackColor = true;
            this.btnThree.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnNine
            // 
            this.btnNine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNine.BackgroundImage")));
            this.btnNine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNine.Location = new System.Drawing.Point(160, 137);
            this.btnNine.Name = "btnNine";
            this.btnNine.Size = new System.Drawing.Size(64, 57);
            this.btnNine.TabIndex = 27;
            this.btnNine.Text = "9";
            this.btnNine.UseVisualStyleBackColor = true;
            this.btnNine.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnSeven
            // 
            this.btnSeven.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSeven.BackgroundImage")));
            this.btnSeven.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeven.Location = new System.Drawing.Point(18, 137);
            this.btnSeven.Name = "btnSeven";
            this.btnSeven.Size = new System.Drawing.Size(64, 57);
            this.btnSeven.TabIndex = 26;
            this.btnSeven.Text = "7";
            this.btnSeven.UseVisualStyleBackColor = true;
            this.btnSeven.Click += new System.EventHandler(this.btnKeyPadKey_Click);
            // 
            // btnClr
            // 
            this.btnClr.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClr.BackgroundImage")));
            this.btnClr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClr.ForeColor = System.Drawing.Color.Black;
            this.btnClr.Location = new System.Drawing.Point(175, 425);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(70, 57);
            this.btnClr.TabIndex = 16;
            this.btnClr.Text = "CLR";
            this.btnClr.UseVisualStyleBackColor = false;
            this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(89, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(248, 24);
            this.lblDate.TabIndex = 19;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(93, 51);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(244, 24);
            this.lblTime.TabIndex = 20;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmPreProcMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(425, 507);
            this.ControlBox = false;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnClr);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtStartShiftCash);
            this.Controls.Add(this.lblCashInDrawer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPreProcMsg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start Shift";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStartShift_FormClosed);
            this.Load += new System.EventHandler(this.frmStartShift_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStartShiftCash;
        private System.Windows.Forms.Label lblCashInDrawer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDoubleZero;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnDot;
        private System.Windows.Forms.Button btnSix;
        private System.Windows.Forms.Button btnEight;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button btnTwo;
        private System.Windows.Forms.Button btnFour;
        private System.Windows.Forms.Button btnFive;
        private System.Windows.Forms.Button btnThree;
        private System.Windows.Forms.Button btnNine;
        private System.Windows.Forms.Button btnSeven;
        private System.Windows.Forms.Button btnClr;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
    }
}