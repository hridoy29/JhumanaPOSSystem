namespace POSsible
{
    partial class frmWeightTaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWeightTaker));
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblWeightTakertitle = new System.Windows.Forms.Label();
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
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(50, 41);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(160, 26);
            this.txtWeight.TabIndex = 0;
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            this.txtWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // lblWeightTakertitle
            // 
            this.lblWeightTakertitle.AutoSize = true;
            this.lblWeightTakertitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeightTakertitle.ForeColor = System.Drawing.Color.White;
            this.lblWeightTakertitle.Location = new System.Drawing.Point(60, 8);
            this.lblWeightTakertitle.Name = "lblWeightTakertitle";
            this.lblWeightTakertitle.Size = new System.Drawing.Size(146, 20);
            this.lblWeightTakertitle.TabIndex = 12;
            this.lblWeightTakertitle.Text = "Enter Qty/Weight";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(172, 357);
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
            this.btnOk.Location = new System.Drawing.Point(24, 357);
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
            this.panel1.Location = new System.Drawing.Point(12, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 269);
            this.panel1.TabIndex = 14;
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
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(98, 357);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 57);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "CLR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // frmWeightTaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(267, 428);
            this.ControlBox = false;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblWeightTakertitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmWeightTaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weight";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmWeightTaker_FormClosed);
            this.Load += new System.EventHandler(this.frmWeightTaker_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblWeightTakertitle;
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
        private System.Windows.Forms.Button btnClear;
    }
}