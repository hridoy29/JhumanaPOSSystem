namespace POSsible
{
    partial class frmOffice
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
            this.label1 = new System.Windows.Forms.Label();
            this.picDesignRight = new System.Windows.Forms.PictureBox();
            this.picDesignFooter = new System.Windows.Forms.PictureBox();
            this.btnBackOffice = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDesignRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDesignFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(233, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "ENTER INTO OFFICE";
            // 
            // picDesignRight
            // 
            this.picDesignRight.BackColor = System.Drawing.Color.Transparent;
            this.picDesignRight.BackgroundImage = global::POSsible.Properties.Resources.design_right__146w_x_332_h;
            this.picDesignRight.Location = new System.Drawing.Point(869, 21);
            this.picDesignRight.Name = "picDesignRight";
            this.picDesignRight.Size = new System.Drawing.Size(146, 332);
            this.picDesignRight.TabIndex = 21;
            this.picDesignRight.TabStop = false;
            // 
            // picDesignFooter
            // 
            this.picDesignFooter.BackColor = System.Drawing.Color.Transparent;
            this.picDesignFooter.BackgroundImage = global::POSsible.Properties.Resources.design_01_left___263w_x_271;
            this.picDesignFooter.Location = new System.Drawing.Point(-96, 462);
            this.picDesignFooter.Name = "picDesignFooter";
            this.picDesignFooter.Size = new System.Drawing.Size(263, 271);
            this.picDesignFooter.TabIndex = 20;
            this.picDesignFooter.TabStop = false;
            // 
            // btnBackOffice
            // 
            this.btnBackOffice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackOffice.Location = new System.Drawing.Point(264, 324);
            this.btnBackOffice.Name = "btnBackOffice";
            this.btnBackOffice.Size = new System.Drawing.Size(165, 45);
            this.btnBackOffice.TabIndex = 43;
            this.btnBackOffice.Text = "BACK OFFICE";
            this.btnBackOffice.UseVisualStyleBackColor = true;
            this.btnBackOffice.Click += new System.EventHandler(this.btnBackOffice_Click);
            // 
            // btnSales
            // 
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Location = new System.Drawing.Point(469, 324);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(165, 45);
            this.btnSales.TabIndex = 44;
            this.btnSales.Text = "SALES";
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 599);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(824, 43);
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.BackgroundImage = global::POSsible.Properties.Resources.Exit_110w_x_33h;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(936, 678);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(68, 33);
            this.btnExit.TabIndex = 46;
            this.btnExit.Text = "E&XIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(824, 21);
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // frmOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(824, 642);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picDesignFooter);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnBackOffice);
            this.Controls.Add(this.picDesignRight);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(840, 680);
            this.Name = "frmOffice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmOffice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDesignRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDesignFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picDesignRight;
        private System.Windows.Forms.PictureBox picDesignFooter;
        private System.Windows.Forms.Button btnBackOffice;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}