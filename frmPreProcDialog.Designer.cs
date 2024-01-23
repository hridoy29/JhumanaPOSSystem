namespace POSsible
{
    partial class frmPreProcDialog
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
            this.lblCash = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCashValue = new System.Windows.Forms.Label();
            this.lblChangeValue = new System.Windows.Forms.Label();
            this.lblCardValue = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.ForeColor = System.Drawing.Color.White;
            this.lblCash.Location = new System.Drawing.Point(204, 434);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(142, 20);
            this.lblCash.TabIndex = 12;
            this.lblCash.Text = "Cash given       $";
            this.lblCash.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(276, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 73);
            this.label1.TabIndex = 13;
            this.label1.Text = "Change $";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(204, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Paid on Card    $";
            this.label2.Visible = false;
            // 
            // lblCashValue
            // 
            this.lblCashValue.AutoSize = true;
            this.lblCashValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashValue.ForeColor = System.Drawing.Color.White;
            this.lblCashValue.Location = new System.Drawing.Point(347, 434);
            this.lblCashValue.Name = "lblCashValue";
            this.lblCashValue.Size = new System.Drawing.Size(40, 24);
            this.lblCashValue.TabIndex = 15;
            this.lblCashValue.Text = "     ";
            this.lblCashValue.Visible = false;
            // 
            // lblChangeValue
            // 
            this.lblChangeValue.AutoSize = true;
            this.lblChangeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeValue.ForeColor = System.Drawing.Color.Firebrick;
            this.lblChangeValue.Location = new System.Drawing.Point(580, 268);
            this.lblChangeValue.Name = "lblChangeValue";
            this.lblChangeValue.Size = new System.Drawing.Size(122, 73);
            this.lblChangeValue.TabIndex = 16;
            this.lblChangeValue.Text = "     ";
            this.lblChangeValue.Click += new System.EventHandler(this.lblChangeValue_Click);
            // 
            // lblCardValue
            // 
            this.lblCardValue.AutoSize = true;
            this.lblCardValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardValue.ForeColor = System.Drawing.Color.White;
            this.lblCardValue.Location = new System.Drawing.Point(345, 385);
            this.lblCardValue.Name = "lblCardValue";
            this.lblCardValue.Size = new System.Drawing.Size(40, 24);
            this.lblCardValue.TabIndex = 17;
            this.lblCardValue.Text = "     ";
            this.lblCardValue.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.BackgroundImage = global::POSsible.Properties.Resources.enter__57w_x_100h;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(879, 654);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 57);
            this.btnOk.TabIndex = 65;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmPreProcDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1018, 748);
            this.ControlBox = false;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblCardValue);
            this.Controls.Add(this.lblChangeValue);
            this.Controls.Add(this.lblCashValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPreProcDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Information";
            this.Load += new System.EventHandler(this.frmPreProcDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCashValue;
        private System.Windows.Forms.Label lblChangeValue;
        private System.Windows.Forms.Label lblCardValue;
        private System.Windows.Forms.Button btnOk;
    }
}