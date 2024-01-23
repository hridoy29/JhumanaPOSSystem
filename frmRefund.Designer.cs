namespace POSsible
{
    partial class frmRefund
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpRefundDate = new System.Windows.Forms.DateTimePicker();
            this.dgvRefund = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sunTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PcItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.cboInvoiceId = new System.Windows.Forms.ComboBox();
            this.dtPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.chkChangeCustomer = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomerNew = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefund)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 26);
            this.label3.TabIndex = 89;
            this.label3.Text = "Invoice No.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 24);
            this.label1.TabIndex = 91;
            this.label1.Text = "Refund Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dpRefundDate
            // 
            this.dpRefundDate.CustomFormat = "dd/MM/yyyy";
            this.dpRefundDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.dpRefundDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpRefundDate.Location = new System.Drawing.Point(162, 23);
            this.dpRefundDate.Name = "dpRefundDate";
            this.dpRefundDate.Size = new System.Drawing.Size(207, 24);
            this.dpRefundDate.TabIndex = 0;
            this.dpRefundDate.ValueChanged += new System.EventHandler(this.dpRefundDate_ValueChanged);
            // 
            // dgvRefund
            // 
            this.dgvRefund.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRefund.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRefund.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRefund.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRefund.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefund.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRefund.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefund.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.InvoiceQty,
            this.Column2,
            this.ReturnedQty,
            this.returnQty,
            this.sunTotal,
            this.Id,
            this.PcItemId});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefund.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRefund.Location = new System.Drawing.Point(9, 97);
            this.dgvRefund.Name = "dgvRefund";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefund.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvRefund.RowHeadersVisible = false;
            this.dgvRefund.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRefund.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvRefund.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRefund.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefund.Size = new System.Drawing.Size(890, 292);
            this.dgvRefund.TabIndex = 2;
            this.dgvRefund.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRefund_CellValueChanged);
            this.dgvRefund.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvRefund_CurrentCellDirtyStateChanged);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.Width = 5;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "Item Name";
            this.Column1.MinimumWidth = 15;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 126;
            // 
            // InvoiceQty
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.InvoiceQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.InvoiceQty.HeaderText = "Invoice Qty";
            this.InvoiceQty.MinimumWidth = 100;
            this.InvoiceQty.Name = "InvoiceQty";
            this.InvoiceQty.ReadOnly = true;
            this.InvoiceQty.Width = 128;
            // 
            // Column2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column2.HeaderText = "Unit price";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 114;
            // 
            // ReturnedQty
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ReturnedQty.DefaultCellStyle = dataGridViewCellStyle6;
            this.ReturnedQty.HeaderText = "Returned Qty";
            this.ReturnedQty.MinimumWidth = 100;
            this.ReturnedQty.Name = "ReturnedQty";
            this.ReturnedQty.ReadOnly = true;
            this.ReturnedQty.Width = 146;
            // 
            // returnQty
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.returnQty.DefaultCellStyle = dataGridViewCellStyle7;
            this.returnQty.HeaderText = "Return Qty";
            this.returnQty.MinimumWidth = 100;
            this.returnQty.Name = "returnQty";
            this.returnQty.Width = 124;
            // 
            // sunTotal
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.sunTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.sunTotal.HeaderText = "Subtotal";
            this.sunTotal.MinimumWidth = 100;
            this.sunTotal.Name = "sunTotal";
            this.sunTotal.ReadOnly = true;
            this.sunTotal.Width = 102;
            // 
            // Id
            // 
            this.Id.HeaderText = "";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 19;
            // 
            // PcItemId
            // 
            this.PcItemId.HeaderText = "PcItemId";
            this.PcItemId.Name = "PcItemId";
            this.PcItemId.ReadOnly = true;
            this.PcItemId.Visible = false;
            this.PcItemId.Width = 107;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnOk.BackgroundImage = global::POSsible.Properties.Resources.ADD_110w_x_33h;
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(687, 454);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(103, 40);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "&SAVE";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.buttOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.BackgroundImage = global::POSsible.Properties.Resources.cancel_current__100_x_57;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(796, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 40);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&CLOSE";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotal.Location = new System.Drawing.Point(635, 398);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(76, 32);
            this.lblTotal.TabIndex = 96;
            this.lblTotal.Text = "Total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(718, 395);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(181, 36);
            this.txtTotal.TabIndex = 3;
            // 
            // cboInvoiceId
            // 
            this.cboInvoiceId.DisplayMember = "InvoiceNo";
            this.cboInvoiceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboInvoiceId.FormattingEnabled = true;
            this.cboInvoiceId.Location = new System.Drawing.Point(162, 64);
            this.cboInvoiceId.Name = "cboInvoiceId";
            this.cboInvoiceId.Size = new System.Drawing.Size(207, 26);
            this.cboInvoiceId.TabIndex = 1;
            this.cboInvoiceId.ValueMember = "invoiceId";
            this.cboInvoiceId.SelectionChangeCommitted += new System.EventHandler(this.cboInvoiceId_SelectionChangeCommitted);
            // 
            // dtPurchaseDate
            // 
            this.dtPurchaseDate.CustomFormat = "dd/MM/yyyy";
            this.dtPurchaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.dtPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPurchaseDate.Location = new System.Drawing.Point(543, 23);
            this.dtPurchaseDate.Name = "dtPurchaseDate";
            this.dtPurchaseDate.Size = new System.Drawing.Size(233, 24);
            this.dtPurchaseDate.TabIndex = 97;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(384, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 24);
            this.label4.TabIndex = 98;
            this.label4.Text = "Sale Date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(384, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 26);
            this.label5.TabIndex = 101;
            this.label5.Text = "Customer";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.ItemHeight = 18;
            this.cboCustomer.Location = new System.Drawing.Point(543, 64);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(233, 26);
            this.cboCustomer.TabIndex = 102;
            // 
            // button_Search
            // 
            this.button_Search.BackColor = System.Drawing.SystemColors.Control;
            this.button_Search.BackgroundImage = global::POSsible.Properties.Resources.ADD_110w_x_33h;
            this.button_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Search.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Search.ForeColor = System.Drawing.Color.Black;
            this.button_Search.Location = new System.Drawing.Point(789, 20);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(110, 47);
            this.button_Search.TabIndex = 191;
            this.button_Search.Text = "SEARCH";
            this.button_Search.UseVisualStyleBackColor = false;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // chkChangeCustomer
            // 
            this.chkChangeCustomer.AutoSize = true;
            this.chkChangeCustomer.Location = new System.Drawing.Point(789, 74);
            this.chkChangeCustomer.Name = "chkChangeCustomer";
            this.chkChangeCustomer.Size = new System.Drawing.Size(110, 17);
            this.chkChangeCustomer.TabIndex = 192;
            this.chkChangeCustomer.Text = "Change Customer";
            this.chkChangeCustomer.UseVisualStyleBackColor = true;
            this.chkChangeCustomer.Visible = false;
            this.chkChangeCustomer.CheckedChanged += new System.EventHandler(this.chkChangeCustomer_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(384, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 26);
            this.label2.TabIndex = 101;
            this.label2.Text = "New Customer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCustomerNew
            // 
            this.cmbCustomerNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.cmbCustomerNew.FormattingEnabled = true;
            this.cmbCustomerNew.ItemHeight = 18;
            this.cmbCustomerNew.Location = new System.Drawing.Point(543, 105);
            this.cmbCustomerNew.Name = "cmbCustomerNew";
            this.cmbCustomerNew.Size = new System.Drawing.Size(233, 26);
            this.cmbCustomerNew.TabIndex = 102;
            // 
            // frmRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(911, 512);
            this.ControlBox = false;
            this.Controls.Add(this.dgvRefund);
            this.Controls.Add(this.chkChangeCustomer);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.cmbCustomerNew);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtPurchaseDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboInvoiceId);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dpRefundDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmRefund";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Refund";
            this.Load += new System.EventHandler(this.frmRefund_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefund)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpRefundDate;
        private System.Windows.Forms.DataGridView dgvRefund;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ComboBox cboInvoiceId;
        private System.Windows.Forms.DateTimePicker dtPurchaseDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn sunTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PcItemId;
        private System.Windows.Forms.CheckBox chkChangeCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCustomerNew;
    }
}