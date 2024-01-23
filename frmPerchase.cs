using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace UYSYSPOS
{
	/// <summary>
	/// Summary description for frmPurches.
	/// </summary>
	public class frmPurches : System.Windows.Forms.Form
    {
		internal System.Windows.Forms.ListView listView1;
		internal System.Windows.Forms.ColumnHeader columnHeader1;
		internal System.Windows.Forms.ColumnHeader columnHeader2;
		internal System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblUnitQty;
		private System.Windows.Forms.Label lblUnitCost;
		private System.Windows.Forms.TextBox txtUnitPrice;
		private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtSubTotal;
		private System.Windows.Forms.Label lblTotal;
        internal ComboBox cboItemSelect;
        private TextBox txtTotal;
        private TextBox textBox1;
        private Label label1;
        private Label lblPurchaseDescription;
        private TextBox txtPurchaseDescription;
        private DateTimePicker dtpPurChaseDate;
        private Label lblPurChaseDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPurches()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lblUnitQty = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.lblUnitCost = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cboItemSelect = new System.Windows.Forms.ComboBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPurchaseDescription = new System.Windows.Forms.Label();
            this.txtPurchaseDescription = new System.Windows.Forms.TextBox();
            this.dtpPurChaseDate = new System.Windows.Forms.DateTimePicker();
            this.lblPurChaseDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUnitQty
            // 
            this.lblUnitQty.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitQty.Location = new System.Drawing.Point(196, 78);
            this.lblUnitQty.Name = "lblUnitQty";
            this.lblUnitQty.Size = new System.Drawing.Size(144, 23);
            this.lblUnitQty.TabIndex = 44;
            this.lblUnitQty.Text = "Perchase Qty";
            this.lblUnitQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(20, 111);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(616, 272);
            this.listView1.TabIndex = 40;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item Name";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ShortCode";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // lblUnitCost
            // 
            this.lblUnitCost.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitCost.Location = new System.Drawing.Point(346, 76);
            this.lblUnitCost.Name = "lblUnitCost";
            this.lblUnitCost.Size = new System.Drawing.Size(134, 23);
            this.lblUnitCost.TabIndex = 45;
            this.lblUnitCost.Text = "Unit Cost";
            this.lblUnitCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitPrice.Location = new System.Drawing.Point(203, 104);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(137, 26);
            this.txtUnitPrice.TabIndex = 46;
            this.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(17, 76);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(152, 23);
            this.lblSubtotal.TabIndex = 47;
            this.lblSubtotal.Text = "ItemName";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(340, 104);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(160, 26);
            this.txtSubTotal.TabIndex = 48;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(424, 389);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 24);
            this.lblTotal.TabIndex = 50;
            this.lblTotal.Text = "Total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(153)))), ((int)(((byte)(159)))));
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(243, 433);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(128, 32);
            this.btnAdd.TabIndex = 51;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(153)))), ((int)(((byte)(159)))));
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(377, 433);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(128, 32);
            this.btnEdit.TabIndex = 52;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(153)))), ((int)(((byte)(159)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(511, 433);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 32);
            this.btnExit.TabIndex = 53;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboItemSelect
            // 
            this.cboItemSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemSelect.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemSelect.Items.AddRange(new object[] {
            "CocaCola",
            "Grapes",
            "Potatoes"});
            this.cboItemSelect.Location = new System.Drawing.Point(20, 103);
            this.cboItemSelect.Name = "cboItemSelect";
            this.cboItemSelect.Size = new System.Drawing.Size(182, 27);
            this.cboItemSelect.TabIndex = 54;
            this.cboItemSelect.SelectedIndexChanged += new System.EventHandler(this.cboItemSelect_SelectedIndexChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(476, 389);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(160, 19);
            this.txtTotal.TabIndex = 49;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(502, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(134, 26);
            this.textBox1.TabIndex = 56;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(508, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 55;
            this.label1.Text = "Sub Total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPurchaseDescription
            // 
            this.lblPurchaseDescription.AutoSize = true;
            this.lblPurchaseDescription.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseDescription.Location = new System.Drawing.Point(346, 34);
            this.lblPurchaseDescription.Name = "lblPurchaseDescription";
            this.lblPurchaseDescription.Size = new System.Drawing.Size(84, 17);
            this.lblPurchaseDescription.TabIndex = 57;
            this.lblPurchaseDescription.Text = "Description";
            // 
            // txtPurchaseDescription
            // 
            this.txtPurchaseDescription.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseDescription.Location = new System.Drawing.Point(436, 31);
            this.txtPurchaseDescription.Multiline = true;
            this.txtPurchaseDescription.Name = "txtPurchaseDescription";
            this.txtPurchaseDescription.Size = new System.Drawing.Size(190, 25);
            this.txtPurchaseDescription.TabIndex = 58;
            // 
            // dtpPurChaseDate
            // 
            this.dtpPurChaseDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPurChaseDate.Location = new System.Drawing.Point(129, 31);
            this.dtpPurChaseDate.Name = "dtpPurChaseDate";
            this.dtpPurChaseDate.Size = new System.Drawing.Size(200, 25);
            this.dtpPurChaseDate.TabIndex = 59;
            this.dtpPurChaseDate.ValueChanged += new System.EventHandler(this.dtpPurChaseDate_ValueChanged);
            // 
            // lblPurChaseDate
            // 
            this.lblPurChaseDate.AutoSize = true;
            this.lblPurChaseDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurChaseDate.Location = new System.Drawing.Point(20, 35);
            this.lblPurChaseDate.Name = "lblPurChaseDate";
            this.lblPurChaseDate.Size = new System.Drawing.Size(103, 17);
            this.lblPurChaseDate.TabIndex = 60;
            this.lblPurChaseDate.Text = "Purchase Date";
            // 
            // frmPurches
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(130)))), ((int)(((byte)(143)))));
            this.ClientSize = new System.Drawing.Size(661, 574);
            this.Controls.Add(this.lblPurChaseDate);
            this.Controls.Add(this.dtpPurChaseDate);
            this.Controls.Add(this.txtPurchaseDescription);
            this.Controls.Add(this.lblPurchaseDescription);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboItemSelect);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblUnitCost);
            this.Controls.Add(this.lblUnitQty);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Location = new System.Drawing.Point(70, 85);
            this.Name = "frmPurches";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Perchase Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

        private void cboItemSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void dtpPurChaseDate_ValueChanged(object sender, EventArgs e)
        {

        }

	}
	
}
