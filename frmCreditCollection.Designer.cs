namespace POSsible
{
    partial class frmCreditCollection
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
            this.txtSaleType = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtChequeDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPayType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPayAmt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPaidBy = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMemoNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemAmt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbInvoiceNo = new System.Windows.Forms.ComboBox();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.MemoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurPayId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chequeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Report = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOutBalance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtReceivedBy = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpCollectionDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblSaleDate = new System.Windows.Forms.Label();
            this.txtInvoiceAmt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSaleDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLastInReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSaleType
            // 
            this.txtSaleType.Location = new System.Drawing.Point(139, 391);
            this.txtSaleType.Name = "txtSaleType";
            this.txtSaleType.ReadOnly = true;
            this.txtSaleType.Size = new System.Drawing.Size(59, 20);
            this.txtSaleType.TabIndex = 114;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(357, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 22);
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
            this.dtChequeDate.Location = new System.Drawing.Point(463, 143);
            this.dtChequeDate.Name = "dtChequeDate";
            this.dtChequeDate.Size = new System.Drawing.Size(167, 24);
            this.dtChequeDate.TabIndex = 112;
            this.dtChequeDate.Visible = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(357, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 22);
            this.label11.TabIndex = 111;
            this.label11.Text = "Cheque No.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Visible = false;
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(463, 112);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(167, 26);
            this.txtChequeNo.TabIndex = 110;
            this.txtChequeNo.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(357, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 22);
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
            this.cmbPayType.Location = new System.Drawing.Point(463, 50);
            this.cmbPayType.Name = "cmbPayType";
            this.cmbPayType.Size = new System.Drawing.Size(167, 26);
            this.cmbPayType.TabIndex = 108;
            this.cmbPayType.SelectedIndexChanged += new System.EventHandler(this.cmbPayType_SelectedIndexChanged);
            this.cmbPayType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPayType_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 22);
            this.label1.TabIndex = 103;
            this.label1.Text = "Pay Amount";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPayAmt
            // 
            this.txtPayAmt.Location = new System.Drawing.Point(127, 81);
            this.txtPayAmt.Name = "txtPayAmt";
            this.txtPayAmt.Size = new System.Drawing.Size(224, 26);
            this.txtPayAmt.TabIndex = 102;
            this.txtPayAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayAmt.TextChanged += new System.EventHandler(this.txtPayAmt_TextChanged);
            this.txtPayAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayAmt_KeyPress_1);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(134, 568);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 22);
            this.label10.TabIndex = 107;
            this.label10.Text = "Memo No.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 22);
            this.label5.TabIndex = 127;
            this.label5.Text = "Received By";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaidBy
            // 
            this.txtPaidBy.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidBy.Location = new System.Drawing.Point(127, 142);
            this.txtPaidBy.Name = "txtPaidBy";
            this.txtPaidBy.Size = new System.Drawing.Size(224, 26);
            this.txtPaidBy.TabIndex = 126;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(11, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 22);
            this.label13.TabIndex = 125;
            this.label13.Text = "Paid By";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMemoNo
            // 
            this.txtMemoNo.Location = new System.Drawing.Point(230, 568);
            this.txtMemoNo.Name = "txtMemoNo";
            this.txtMemoNo.Size = new System.Drawing.Size(88, 20);
            this.txtMemoNo.TabIndex = 106;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(357, 423);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 22);
            this.label9.TabIndex = 105;
            this.label9.Text = "Rem. Amt";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemAmt
            // 
            this.txtRemAmt.Location = new System.Drawing.Point(463, 421);
            this.txtRemAmt.Name = "txtRemAmt";
            this.txtRemAmt.ReadOnly = true;
            this.txtRemAmt.Size = new System.Drawing.Size(167, 20);
            this.txtRemAmt.TabIndex = 104;
            this.txtRemAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(357, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 22);
            this.label8.TabIndex = 103;
            this.label8.Text = "Invoice No.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbInvoiceNo
            // 
            this.cmbInvoiceNo.DisplayMember = "description";
            this.cmbInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInvoiceNo.FormattingEnabled = true;
            this.cmbInvoiceNo.Location = new System.Drawing.Point(463, 361);
            this.cmbInvoiceNo.Name = "cmbInvoiceNo";
            this.cmbInvoiceNo.Size = new System.Drawing.Size(167, 26);
            this.cmbInvoiceNo.TabIndex = 102;
            this.cmbInvoiceNo.ValueMember = "purchaseId";
            this.cmbInvoiceNo.SelectedIndexChanged += new System.EventHandler(this.cmbInvoiceNo_SelectedIndexChanged);
            this.cmbInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbInvoiceNo_KeyPress);
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
            this.receivedBy,
            this.paidBy,
            this.ReceivedByName,
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
            this.dgvItem.Location = new System.Drawing.Point(15, 193);
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
            this.dgvItem.Size = new System.Drawing.Size(639, 362);
            this.dgvItem.TabIndex = 120;
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
            // receivedBy
            // 
            this.receivedBy.HeaderText = "receivedBy";
            this.receivedBy.Name = "receivedBy";
            this.receivedBy.ReadOnly = true;
            this.receivedBy.Visible = false;
            this.receivedBy.Width = 112;
            // 
            // paidBy
            // 
            this.paidBy.HeaderText = "paidBy";
            this.paidBy.Name = "paidBy";
            this.paidBy.ReadOnly = true;
            this.paidBy.Visible = false;
            this.paidBy.Width = 82;
            // 
            // ReceivedByName
            // 
            this.ReceivedByName.HeaderText = "ReceivedByName";
            this.ReceivedByName.Name = "ReceivedByName";
            this.ReceivedByName.ReadOnly = true;
            this.ReceivedByName.Visible = false;
            this.ReceivedByName.Width = 159;
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
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(11, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 22);
            this.label7.TabIndex = 101;
            this.label7.Text = "Out. Balance";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOutBalance
            // 
            this.txtOutBalance.Location = new System.Drawing.Point(127, 50);
            this.txtOutBalance.Name = "txtOutBalance";
            this.txtOutBalance.ReadOnly = true;
            this.txtOutBalance.Size = new System.Drawing.Size(224, 26);
            this.txtOutBalance.TabIndex = 100;
            this.txtOutBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(23, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 22);
            this.label6.TabIndex = 99;
            this.label6.Text = "Invoice Amt.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBank);
            this.groupBox1.Controls.Add(this.txtReceivedBy);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPaidBy);
            this.groupBox1.Controls.Add(this.dtpCollectionDate);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dtChequeDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtChequeNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbPayType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPayAmt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtOutBalance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbCustomer);
            this.groupBox1.Controls.Add(this.lblSaleDate);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 179);
            this.groupBox1.TabIndex = 124;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Information";
            // 
            // txtBank
            // 
            this.txtBank.Location = new System.Drawing.Point(463, 81);
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(167, 26);
            this.txtBank.TabIndex = 129;
            this.txtBank.Visible = false;
            // 
            // txtReceivedBy
            // 
            this.txtReceivedBy.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceivedBy.Location = new System.Drawing.Point(127, 112);
            this.txtReceivedBy.Name = "txtReceivedBy";
            this.txtReceivedBy.Size = new System.Drawing.Size(224, 26);
            this.txtReceivedBy.TabIndex = 128;
            this.txtReceivedBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceivedBy_KeyPress);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(357, 83);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 22);
            this.label14.TabIndex = 117;
            this.label14.Text = "Bank";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label14.Visible = false;
            // 
            // dtpCollectionDate
            // 
            this.dtpCollectionDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCollectionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCollectionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCollectionDate.Location = new System.Drawing.Point(463, 21);
            this.dtpCollectionDate.Name = "dtpCollectionDate";
            this.dtpCollectionDate.Size = new System.Drawing.Size(167, 24);
            this.dtpCollectionDate.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 22);
            this.label2.TabIndex = 89;
            this.label2.Text = "Customer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.DisplayMember = "Name";
            this.cmbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomer.Location = new System.Drawing.Point(127, 20);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(224, 26);
            this.cmbCustomer.TabIndex = 2;
            this.cmbCustomer.ValueMember = "customerId";
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            this.cmbCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCustomer_KeyPress);
            // 
            // lblSaleDate
            // 
            this.lblSaleDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSaleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleDate.ForeColor = System.Drawing.Color.White;
            this.lblSaleDate.Location = new System.Drawing.Point(357, 22);
            this.lblSaleDate.Name = "lblSaleDate";
            this.lblSaleDate.Size = new System.Drawing.Size(105, 22);
            this.lblSaleDate.TabIndex = 88;
            this.lblSaleDate.Text = "Pay Date";
            this.lblSaleDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvoiceAmt
            // 
            this.txtInvoiceAmt.Location = new System.Drawing.Point(139, 421);
            this.txtInvoiceAmt.Name = "txtInvoiceAmt";
            this.txtInvoiceAmt.ReadOnly = true;
            this.txtInvoiceAmt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtInvoiceAmt.Size = new System.Drawing.Size(224, 20);
            this.txtInvoiceAmt.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 26);
            this.label3.TabIndex = 97;
            this.label3.Text = "SaleType-Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpSaleDate
            // 
            this.dtpSaleDate.CustomFormat = "dd/MM/yyyy";
            this.dtpSaleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSaleDate.Location = new System.Drawing.Point(205, 392);
            this.dtpSaleDate.Name = "dtpSaleDate";
            this.dtpSaleDate.Size = new System.Drawing.Size(158, 24);
            this.dtpSaleDate.TabIndex = 0;
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
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.BackgroundImage = global::POSsible.Properties.Resources.Exit_110w_x_33h;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(544, 561);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 33);
            this.btnExit.TabIndex = 123;
            this.btnExit.Text = "E&XIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.BackgroundImage = global::POSsible.Properties.Resources.Reset_110w_x_33h;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(434, 561);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 33);
            this.btnReset.TabIndex = 121;
            this.btnReset.Text = "&RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackgroundImage = global::POSsible.Properties.Resources.delete_110w_x_33h;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(324, 561);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 33);
            this.btnSave.TabIndex = 122;
            this.btnSave.Text = "&SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLastInReport
            // 
            this.btnLastInReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastInReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLastInReport.Location = new System.Drawing.Point(14, 562);
            this.btnLastInReport.Name = "btnLastInReport";
            this.btnLastInReport.Size = new System.Drawing.Size(110, 33);
            this.btnLastInReport.TabIndex = 125;
            this.btnLastInReport.Text = "Last Inv.";
            this.btnLastInReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLastInReport.UseVisualStyleBackColor = true;
            this.btnLastInReport.Click += new System.EventHandler(this.btnLastInReport_Click);
            // 
            // frmCreditCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(666, 600);
            this.Controls.Add(this.btnLastInReport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSaleType);
            this.Controls.Add(this.txtMemoNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpSaleDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInvoiceAmt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbInvoiceNo);
            this.Controls.Add(this.txtRemAmt);
            this.Controls.Add(this.label9);
            this.Name = "frmCreditCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credit Collection";
            this.Load += new System.EventHandler(this.frmCreditCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSaleType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtChequeDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPayType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPayAmt;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.TextBox txtPaidBy;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMemoNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRemAmt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbInvoiceNo;
        public System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOutBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInvoiceAmt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSaleDate;
        private System.Windows.Forms.DateTimePicker dtpSaleDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpCollectionDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtReceivedBy;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurPayId;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chequeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn Report;
        private System.Windows.Forms.DataGridViewImageColumn Column6;
        internal System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnLastInReport;
    }
}