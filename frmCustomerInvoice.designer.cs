namespace POSsible
{
    partial class frmCustomerInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCustomerInvoice = new System.Windows.Forms.Label();
            this.Point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcustomer = new System.Windows.Forms.DataGridView();
            this.lblPoint = new System.Windows.Forms.Label();
            this.txtCustomerInvoice = new System.Windows.Forms.TextBox();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerBarcode = new System.Windows.Forms.TextBox();
            this.lblCustomerBarcode = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalPoint = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomerInvoice
            // 
            this.lblCustomerInvoice.AutoSize = true;
            this.lblCustomerInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerInvoice.Location = new System.Drawing.Point(12, 74);
            this.lblCustomerInvoice.Name = "lblCustomerInvoice";
            this.lblCustomerInvoice.Size = new System.Drawing.Size(93, 18);
            this.lblCustomerInvoice.TabIndex = 0;
            this.lblCustomerInvoice.Text = "Invoice No.";
            // 
            // Point
            // 
            this.Point.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Point.HeaderText = "Point";
            this.Point.Name = "Point";
            this.Point.ReadOnly = true;
            this.Point.Width = 150;
            // 
            // invoiceno
            // 
            this.invoiceno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.invoiceno.HeaderText = "Invoice No";
            this.invoiceno.Name = "invoiceno";
            this.invoiceno.ReadOnly = true;
            this.invoiceno.Width = 280;
            // 
            // dgvcustomer
            // 
            this.dgvcustomer.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvcustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvcustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvcustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvcustomer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvcustomer.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoiceno,
            this.Point});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcustomer.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvcustomer.Location = new System.Drawing.Point(11, 112);
            this.dgvcustomer.MultiSelect = false;
            this.dgvcustomer.Name = "dgvcustomer";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvcustomer.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvcustomer.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvcustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcustomer.Size = new System.Drawing.Size(439, 228);
            this.dgvcustomer.TabIndex = 20;
            this.dgvcustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcustomer_CellClick);
            this.dgvcustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcustomer_CellContentClick);
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint.Location = new System.Drawing.Point(296, 77);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(47, 18);
            this.lblPoint.TabIndex = 21;
            this.lblPoint.Text = "Point";
            // 
            // txtCustomerInvoice
            // 
            this.txtCustomerInvoice.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerInvoice.Enabled = false;
            this.txtCustomerInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerInvoice.Location = new System.Drawing.Point(161, 71);
            this.txtCustomerInvoice.Name = "txtCustomerInvoice";
            this.txtCustomerInvoice.Size = new System.Drawing.Size(98, 24);
            this.txtCustomerInvoice.TabIndex = 22;
            // 
            // txtPoint
            // 
            this.txtPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint.Location = new System.Drawing.Point(352, 74);
            this.txtPoint.MaxLength = 5;
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(98, 24);
            this.txtPoint.TabIndex = 23;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(161, 41);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(289, 24);
            this.txtCustomerName.TabIndex = 25;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(12, 44);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(131, 18);
            this.lblCustomerName.TabIndex = 24;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // txtCustomerBarcode
            // 
            this.txtCustomerBarcode.BackColor = System.Drawing.SystemColors.Info;
            this.txtCustomerBarcode.Enabled = false;
            this.txtCustomerBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerBarcode.Location = new System.Drawing.Point(161, 12);
            this.txtCustomerBarcode.Name = "txtCustomerBarcode";
            this.txtCustomerBarcode.Size = new System.Drawing.Size(289, 24);
            this.txtCustomerBarcode.TabIndex = 27;
            // 
            // lblCustomerBarcode
            // 
            this.lblCustomerBarcode.AutoSize = true;
            this.lblCustomerBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerBarcode.Location = new System.Drawing.Point(12, 15);
            this.lblCustomerBarcode.Name = "lblCustomerBarcode";
            this.lblCustomerBarcode.Size = new System.Drawing.Size(150, 18);
            this.lblCustomerBarcode.TabIndex = 26;
            this.lblCustomerBarcode.Text = "Customer Barcode";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.BackgroundImage = global::POSsible.Properties.Resources.Reset_110w_x_33h;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Navy;
            this.btnReset.Location = new System.Drawing.Point(231, 397);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 33);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.BackgroundImage = global::POSsible.Properties.Resources.Exit_110w_x_33h;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Navy;
            this.btnExit.Location = new System.Drawing.Point(342, 397);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 33);
            this.btnExit.TabIndex = 31;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.BackgroundImage = global::POSsible.Properties.Resources.ADD_110w_x_33h;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Navy;
            this.btnAdd.Location = new System.Drawing.Point(120, 397);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 33);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "UPDATE";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.BackgroundImage = global::POSsible.Properties.Resources.delete_110w_x_33h;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Navy;
            this.btnDelete.Location = new System.Drawing.Point(231, 263);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 33);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "Total Point:";
            // 
            // txtTotalPoint
            // 
            this.txtTotalPoint.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalPoint.Enabled = false;
            this.txtTotalPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPoint.Location = new System.Drawing.Point(299, 342);
            this.txtTotalPoint.Name = "txtTotalPoint";
            this.txtTotalPoint.Size = new System.Drawing.Size(151, 24);
            this.txtTotalPoint.TabIndex = 33;
            // 
            // frmCustomerInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(468, 442);
            this.Controls.Add(this.txtTotalPoint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtCustomerBarcode);
            this.Controls.Add(this.lblCustomerBarcode);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtPoint);
            this.Controls.Add(this.txtCustomerInvoice);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.dgvcustomer);
            this.Controls.Add(this.lblCustomerInvoice);
            this.Controls.Add(this.btnDelete);
            this.MaximizeBox = false;
            this.Name = "frmCustomerInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Invoice";
            this.Load += new System.EventHandler(this.frmCustomerInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvcustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceno;
        private System.Windows.Forms.DataGridViewTextBoxColumn point;
        //private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        public System.Windows.Forms.DataGridView dgvcustomer;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.TextBox txtCustomerInvoice;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerBarcode;
        private System.Windows.Forms.Label lblCustomerBarcode;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalPoint;
    }
}