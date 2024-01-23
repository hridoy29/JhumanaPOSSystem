namespace POSsible
{
    partial class frmPurchasePayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblPurChaseDate = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.MemoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurPayId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Report = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtPaidBy = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.txtReceivedBy = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtChequeDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPayType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPayAmt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOutBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.txtPurchaseType = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMemoNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemAmt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbInvoiceNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInvoiceAmt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPurChaseDate
            // 
            this.lblPurChaseDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPurChaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurChaseDate.ForeColor = System.Drawing.Color.White;
            this.lblPurChaseDate.Location = new System.Drawing.Point(368, 30);
            this.lblPurChaseDate.Name = "lblPurChaseDate";
            this.lblPurChaseDate.Size = new System.Drawing.Size(114, 22);
            this.lblPurChaseDate.TabIndex = 88;
            this.lblPurChaseDate.Text = "Payment Date";
            this.lblPurChaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.CustomFormat = "dd/MM/yy";
            this.dtpPurchaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(208, 307);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(87, 24);
            this.dtpPurchaseDate.TabIndex = 0;
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvItem.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MemoNo,
            this.PayDate,
            this.PayType,
            this.Amount,
            this.PurPayId,
            this.chequeNo,
            this.chequeDate,
            this.paidBy,
            this.receivedBy,
            this.PaidByName,
            this.Bank,
            this.edit,
            this.Report,
            this.Column6});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItem.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItem.Location = new System.Drawing.Point(17, 198);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvItem.RowHeadersVisible = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItem.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(639, 376);
            this.dgvItem.TabIndex = 3;
            this.dgvItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellContentClick);
            // 
            // MemoNo
            // 
            this.MemoNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MemoNo.HeaderText = "Memo No.";
            this.MemoNo.Name = "MemoNo";
            this.MemoNo.ReadOnly = true;
            // 
            // PayDate
            // 
            this.PayDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PayDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.PayDate.HeaderText = "Pay Date";
            this.PayDate.Name = "PayDate";
            this.PayDate.ReadOnly = true;
            this.PayDate.Width = 85;
            // 
            // PayType
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PayType.DefaultCellStyle = dataGridViewCellStyle3;
            this.PayType.HeaderText = "Pay Type";
            this.PayType.Name = "PayType";
            this.PayType.ReadOnly = true;
            // 
            // Amount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 84;
            // 
            // PurPayId
            // 
            this.PurPayId.HeaderText = "PurPay Id";
            this.PurPayId.Name = "PurPayId";
            this.PurPayId.ReadOnly = true;
            this.PurPayId.Visible = false;
            // 
            // chequeNo
            // 
            this.chequeNo.HeaderText = "chequeNo";
            this.chequeNo.Name = "chequeNo";
            this.chequeNo.ReadOnly = true;
            this.chequeNo.Visible = false;
            this.chequeNo.Width = 104;
            // 
            // chequeDate
            // 
            this.chequeDate.HeaderText = "chequeDate";
            this.chequeDate.Name = "chequeDate";
            this.chequeDate.ReadOnly = true;
            this.chequeDate.Visible = false;
            this.chequeDate.Width = 117;
            // 
            // paidBy
            // 
            this.paidBy.HeaderText = "paidBy";
            this.paidBy.Name = "paidBy";
            this.paidBy.ReadOnly = true;
            this.paidBy.Visible = false;
            this.paidBy.Width = 82;
            // 
            // receivedBy
            // 
            this.receivedBy.HeaderText = "receivedBy";
            this.receivedBy.Name = "receivedBy";
            this.receivedBy.ReadOnly = true;
            this.receivedBy.Visible = false;
            this.receivedBy.Width = 112;
            // 
            // PaidByName
            // 
            this.PaidByName.HeaderText = "PaidByName";
            this.PaidByName.Name = "PaidByName";
            this.PaidByName.ReadOnly = true;
            this.PaidByName.Visible = false;
            this.PaidByName.Width = 124;
            // 
            // Bank
            // 
            this.Bank.HeaderText = "Bank";
            this.Bank.Name = "Bank";
            this.Bank.ReadOnly = true;
            this.Bank.Visible = false;
            this.Bank.Width = 68;
            // 
            // edit
            // 
            this.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.edit.HeaderText = "Edit";
            this.edit.Image = global::POSsible.Properties.Resources.UniversalEditButton3_22230410;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Width = 45;
            // 
            // Report
            // 
            this.Report.HeaderText = "Print";
            this.Report.Image = global::POSsible.Properties.Resources.printer_icon;
            this.Report.Name = "Report";
            this.Report.ReadOnly = true;
            this.Report.Visible = false;
            this.Report.Width = 45;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.HeaderText = "Del";
            this.Column6.Image = global::POSsible.Properties.Resources.bullet_cross;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.Width = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBank);
            this.groupBox1.Controls.Add(this.txtPaidBy);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dtpPaymentDate);
            this.groupBox1.Controls.Add(this.txtReceivedBy);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dtChequeDate);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtChequeNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbPayType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPayAmt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtOutBalance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbSupplier);
            this.groupBox1.Controls.Add(this.lblPurChaseDate);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 190);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Information";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(10, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 22);
            this.label5.TabIndex = 118;
            this.label5.Text = "Paid By";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBank
            // 
            this.txtBank.Location = new System.Drawing.Point(487, 91);
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(143, 26);
            this.txtBank.TabIndex = 120;
            this.txtBank.Visible = false;
            // 
            // txtPaidBy
            // 
            this.txtPaidBy.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidBy.Location = new System.Drawing.Point(122, 121);
            this.txtPaidBy.Name = "txtPaidBy";
            this.txtPaidBy.Size = new System.Drawing.Size(230, 26);
            this.txtPaidBy.TabIndex = 117;
            this.txtPaidBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaidBy_KeyPress);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(368, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 22);
            this.label14.TabIndex = 119;
            this.label14.Text = "Bank";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label14.Visible = false;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(487, 29);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(143, 24);
            this.dtpPaymentDate.TabIndex = 115;
            // 
            // txtReceivedBy
            // 
            this.txtReceivedBy.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceivedBy.Location = new System.Drawing.Point(122, 152);
            this.txtReceivedBy.Name = "txtReceivedBy";
            this.txtReceivedBy.Size = new System.Drawing.Size(230, 26);
            this.txtReceivedBy.TabIndex = 117;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(368, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 22);
            this.label12.TabIndex = 113;
            this.label12.Text = "Cheque Date";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Visible = false;
            // 
            // dtChequeDate
            // 
            this.dtChequeDate.CustomFormat = "dd/MM/yyyy";
            this.dtChequeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChequeDate.Location = new System.Drawing.Point(487, 156);
            this.dtChequeDate.Name = "dtChequeDate";
            this.dtChequeDate.Size = new System.Drawing.Size(143, 24);
            this.dtChequeDate.TabIndex = 112;
            this.dtChequeDate.Visible = false;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(10, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 22);
            this.label13.TabIndex = 116;
            this.label13.Text = "Received By";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(368, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 22);
            this.label11.TabIndex = 111;
            this.label11.Text = "Cheque No.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Visible = false;
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(487, 125);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(143, 26);
            this.txtChequeNo.TabIndex = 110;
            this.txtChequeNo.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(368, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 22);
            this.label4.TabIndex = 109;
            this.label4.Text = "Pay Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPayType
            // 
            this.cmbPayType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPayType.FormattingEnabled = true;
            this.cmbPayType.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.cmbPayType.Location = new System.Drawing.Point(487, 59);
            this.cmbPayType.Name = "cmbPayType";
            this.cmbPayType.Size = new System.Drawing.Size(143, 26);
            this.cmbPayType.TabIndex = 108;
            this.cmbPayType.SelectedIndexChanged += new System.EventHandler(this.cmbPayType_SelectedIndexChanged);
            this.cmbPayType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPayType_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 22);
            this.label1.TabIndex = 103;
            this.label1.Text = "Pay Amount";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPayAmt
            // 
            this.txtPayAmt.Location = new System.Drawing.Point(122, 90);
            this.txtPayAmt.Name = "txtPayAmt";
            this.txtPayAmt.Size = new System.Drawing.Size(230, 26);
            this.txtPayAmt.TabIndex = 102;
            this.txtPayAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayAmt.TextChanged += new System.EventHandler(this.txtPayAmt_TextChanged);
            this.txtPayAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayAmt_KeyPress);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(10, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 22);
            this.label7.TabIndex = 101;
            this.label7.Text = "Out. Balance";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOutBalance
            // 
            this.txtOutBalance.Location = new System.Drawing.Point(122, 59);
            this.txtOutBalance.Name = "txtOutBalance";
            this.txtOutBalance.ReadOnly = true;
            this.txtOutBalance.Size = new System.Drawing.Size(230, 26);
            this.txtOutBalance.TabIndex = 100;
            this.txtOutBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 22);
            this.label2.TabIndex = 89;
            this.label2.Text = "Supplier";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplier.DisplayMember = "SupplierName";
            this.cmbSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(122, 28);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(230, 26);
            this.cmbSupplier.TabIndex = 2;
            this.cmbSupplier.ValueMember = "SupplierId";
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            // 
            // txtPurchaseType
            // 
            this.txtPurchaseType.Location = new System.Drawing.Point(154, 307);
            this.txtPurchaseType.Name = "txtPurchaseType";
            this.txtPurchaseType.ReadOnly = true;
            this.txtPurchaseType.Size = new System.Drawing.Size(50, 20);
            this.txtPurchaseType.TabIndex = 114;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(23, 587);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 22);
            this.label10.TabIndex = 107;
            this.label10.Text = "Memo No.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMemoNo
            // 
            this.txtMemoNo.Location = new System.Drawing.Point(135, 588);
            this.txtMemoNo.Name = "txtMemoNo";
            this.txtMemoNo.Size = new System.Drawing.Size(171, 20);
            this.txtMemoNo.TabIndex = 106;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(360, 337);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 22);
            this.label9.TabIndex = 105;
            this.label9.Text = "Rem. Amount";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemAmt
            // 
            this.txtRemAmt.Location = new System.Drawing.Point(511, 337);
            this.txtRemAmt.Name = "txtRemAmt";
            this.txtRemAmt.ReadOnly = true;
            this.txtRemAmt.Size = new System.Drawing.Size(136, 20);
            this.txtRemAmt.TabIndex = 104;
            this.txtRemAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(360, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 22);
            this.label8.TabIndex = 103;
            this.label8.Text = "Invoice No.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbInvoiceNo
            // 
            this.cmbInvoiceNo.DisplayMember = "description";
            this.cmbInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInvoiceNo.FormattingEnabled = true;
            this.cmbInvoiceNo.Location = new System.Drawing.Point(509, 307);
            this.cmbInvoiceNo.Name = "cmbInvoiceNo";
            this.cmbInvoiceNo.Size = new System.Drawing.Size(138, 26);
            this.cmbInvoiceNo.TabIndex = 102;
            this.cmbInvoiceNo.ValueMember = "purchaseId";
            this.cmbInvoiceNo.SelectedIndexChanged += new System.EventHandler(this.txtInvoiceNo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(27, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 22);
            this.label6.TabIndex = 99;
            this.label6.Text = "Invoice Amount";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvoiceAmt
            // 
            this.txtInvoiceAmt.Location = new System.Drawing.Point(154, 337);
            this.txtInvoiceAmt.Name = "txtInvoiceAmt";
            this.txtInvoiceAmt.ReadOnly = true;
            this.txtInvoiceAmt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtInvoiceAmt.Size = new System.Drawing.Size(143, 20);
            this.txtInvoiceAmt.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 26);
            this.label3.TabIndex = 97;
            this.label3.Text = "Pur.Type && Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "Remove";
            this.dataGridViewImageColumn1.Image = global::POSsible.Properties.Resources.bullet_cross;
            this.dataGridViewImageColumn1.MinimumWidth = 40;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.HeaderText = "Del";
            this.dataGridViewImageColumn2.Image = global::POSsible.Properties.Resources.bullet_cross;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 40;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn3.HeaderText = "Del";
            this.dataGridViewImageColumn3.Image = global::POSsible.Properties.Resources.bullet_cross;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Width = 40;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.BackgroundImage = global::POSsible.Properties.Resources.Reset_110w_x_33h;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(437, 580);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 33);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "&RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.BackgroundImage = global::POSsible.Properties.Resources.Exit_110w_x_33h;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(547, 580);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 33);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "E&XIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackgroundImage = global::POSsible.Properties.Resources.delete_110w_x_33h;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(327, 580);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 33);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPurchasePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(672, 618);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.txtPurchaseType);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMemoNo);
            this.Controls.Add(this.dtpPurchaseDate);
            this.Controls.Add(this.txtInvoiceAmt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbInvoiceNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRemAmt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmPurchasePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Payment";
            this.Load += new System.EventHandler(this.frmPurchasePayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblPurChaseDate;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMemoNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRemAmt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbInvoiceNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOutBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInvoiceAmt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtChequeDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPayType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPayAmt;
        private System.Windows.Forms.TextBox txtPurchaseType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReceivedBy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPaidBy;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurPayId;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn Report;
        private System.Windows.Forms.DataGridViewImageColumn Column6;

    }
}