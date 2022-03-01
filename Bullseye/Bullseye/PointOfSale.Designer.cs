namespace Bullseye
{
    partial class PointOfSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointOfSale));
            this.btnSale = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.picCancel = new System.Windows.Forms.PictureBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInumInput = new System.Windows.Forms.Label();
            this.lblQuanInput = new System.Windows.Forms.Label();
            this.mtxtItemNumber = new System.Windows.Forms.MaskedTextBox();
            this.mtxtQuantities = new System.Windows.Forms.MaskedTextBox();
            this.lblItemNumTitle = new System.Windows.Forms.Label();
            this.lblItemNum = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblSubtotalTitle = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTaxTitle = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblGrandTotalTitle = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.itemTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.itemTableAdapter();
            this.transactionlineTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionlineTableAdapter();
            this.transactionTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionTableAdapter();
            this.inventoryTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.inventoryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.picCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSale
            // 
            this.btnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.Location = new System.Drawing.Point(941, 87);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(104, 40);
            this.btnSale.TabIndex = 0;
            this.btnSale.Text = "Sale";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(1097, 87);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(104, 40);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // picCancel
            // 
            this.picCancel.Image = ((System.Drawing.Image)(resources.GetObject("picCancel.Image")));
            this.picCancel.Location = new System.Drawing.Point(1237, 87);
            this.picCancel.Name = "picCancel";
            this.picCancel.Size = new System.Drawing.Size(42, 40);
            this.picCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCancel.TabIndex = 2;
            this.picCancel.TabStop = false;
            this.picCancel.Click += new System.EventHandler(this.picCancel_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.itemName,
            this.quantity,
            this.price,
            this.category});
            this.dgvItems.Location = new System.Drawing.Point(25, 72);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(877, 567);
            this.dgvItems.TabIndex = 3;
            this.dgvItems.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvItems_RowsAdded);
            this.dgvItems.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvItems_RowsRemoved);
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "Item ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            // 
            // itemName
            // 
            this.itemName.HeaderText = "Item Name";
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // category
            // 
            this.category.HeaderText = "Category";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("Corsiva", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblUserInfo.Location = new System.Drawing.Point(0, 9);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(1300, 60);
            this.lblUserInfo.TabIndex = 19;
            this.lblUserInfo.Text = "user info";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(941, 150);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 40);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "#";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInumInput
            // 
            this.lblInumInput.AutoSize = true;
            this.lblInumInput.ForeColor = System.Drawing.Color.Red;
            this.lblInumInput.Location = new System.Drawing.Point(941, 236);
            this.lblInumInput.Name = "lblInumInput";
            this.lblInumInput.Size = new System.Drawing.Size(164, 17);
            this.lblInumInput.TabIndex = 21;
            this.lblInumInput.Text = "Item Number (Required):";
            // 
            // lblQuanInput
            // 
            this.lblQuanInput.AutoSize = true;
            this.lblQuanInput.ForeColor = System.Drawing.Color.Red;
            this.lblQuanInput.Location = new System.Drawing.Point(941, 280);
            this.lblQuanInput.Name = "lblQuanInput";
            this.lblQuanInput.Size = new System.Drawing.Size(148, 17);
            this.lblQuanInput.TabIndex = 23;
            this.lblQuanInput.Text = "Quantities (Required):";
            // 
            // mtxtItemNumber
            // 
            this.mtxtItemNumber.Location = new System.Drawing.Point(1137, 236);
            this.mtxtItemNumber.Mask = "00000";
            this.mtxtItemNumber.Name = "mtxtItemNumber";
            this.mtxtItemNumber.Size = new System.Drawing.Size(123, 22);
            this.mtxtItemNumber.TabIndex = 25;
            this.mtxtItemNumber.ValidatingType = typeof(int);
            // 
            // mtxtQuantities
            // 
            this.mtxtQuantities.Location = new System.Drawing.Point(1137, 280);
            this.mtxtQuantities.Mask = "00000";
            this.mtxtQuantities.Name = "mtxtQuantities";
            this.mtxtQuantities.Size = new System.Drawing.Size(123, 22);
            this.mtxtQuantities.TabIndex = 26;
            this.mtxtQuantities.ValidatingType = typeof(int);
            // 
            // lblItemNumTitle
            // 
            this.lblItemNumTitle.AutoSize = true;
            this.lblItemNumTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemNumTitle.Location = new System.Drawing.Point(941, 378);
            this.lblItemNumTitle.Name = "lblItemNumTitle";
            this.lblItemNumTitle.Size = new System.Drawing.Size(131, 17);
            this.lblItemNumTitle.TabIndex = 27;
            this.lblItemNumTitle.Text = "Number of Items:";
            // 
            // lblItemNum
            // 
            this.lblItemNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItemNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemNum.Location = new System.Drawing.Point(1097, 378);
            this.lblItemNum.Name = "lblItemNum";
            this.lblItemNum.Size = new System.Drawing.Size(163, 28);
            this.lblItemNum.TabIndex = 28;
            this.lblItemNum.Text = "0";
            this.lblItemNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(1097, 430);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(163, 28);
            this.lblSubtotal.TabIndex = 30;
            this.lblSubtotal.Text = "$0.00";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotalTitle
            // 
            this.lblSubtotalTitle.AutoSize = true;
            this.lblSubtotalTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalTitle.Location = new System.Drawing.Point(941, 430);
            this.lblSubtotalTitle.Name = "lblSubtotalTitle";
            this.lblSubtotalTitle.Size = new System.Drawing.Size(73, 17);
            this.lblSubtotalTitle.TabIndex = 29;
            this.lblSubtotalTitle.Text = "Subtotal:";
            // 
            // lblTax
            // 
            this.lblTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(1097, 483);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(163, 28);
            this.lblTax.TabIndex = 32;
            this.lblTax.Text = "$0.00";
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTaxTitle
            // 
            this.lblTaxTitle.AutoSize = true;
            this.lblTaxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxTitle.Location = new System.Drawing.Point(941, 483);
            this.lblTaxTitle.Name = "lblTaxTitle";
            this.lblTaxTitle.Size = new System.Drawing.Size(39, 17);
            this.lblTaxTitle.TabIndex = 31;
            this.lblTaxTitle.Text = "Tax:";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(1097, 533);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(163, 28);
            this.lblGrandTotal.TabIndex = 34;
            this.lblGrandTotal.Text = "$0.00";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGrandTotalTitle
            // 
            this.lblGrandTotalTitle.AutoSize = true;
            this.lblGrandTotalTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotalTitle.Location = new System.Drawing.Point(941, 533);
            this.lblGrandTotalTitle.Name = "lblGrandTotalTitle";
            this.lblGrandTotalTitle.Size = new System.Drawing.Size(100, 17);
            this.lblGrandTotalTitle.TabIndex = 33;
            this.lblGrandTotalTitle.Text = "Grand Total:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(1097, 580);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(163, 59);
            this.btnConfirm.TabIndex = 35;
            this.btnConfirm.Text = "BTN";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(1132, 319);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(128, 34);
            this.btnAdd.TabIndex = 36;
            this.btnAdd.Text = "Add Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(944, 319);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(128, 34);
            this.btnRemove.TabIndex = 37;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // itemTableAdapter
            // 
            this.itemTableAdapter.ClearBeforeFill = true;
            // 
            // transactionlineTableAdapter
            // 
            this.transactionlineTableAdapter.ClearBeforeFill = true;
            // 
            // transactionTableAdapter
            // 
            this.transactionTableAdapter.ClearBeforeFill = true;
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // PointOfSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 665);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblGrandTotalTitle);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.lblTaxTitle);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblSubtotalTitle);
            this.Controls.Add(this.lblItemNum);
            this.Controls.Add(this.lblItemNumTitle);
            this.Controls.Add(this.mtxtQuantities);
            this.Controls.Add(this.mtxtItemNumber);
            this.Controls.Add(this.lblQuanInput);
            this.Controls.Add(this.lblInumInput);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.picCancel);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnSale);
            this.Name = "PointOfSale";
            this.Text = "PointOfSale";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PointOfSale_FormClosing);
            this.Load += new System.EventHandler(this.PointOfSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private bullseyeDataSetTableAdapters.itemTableAdapter itemTableAdapter;
        private bullseyeDataSetTableAdapters.transactionlineTableAdapter transactionlineTableAdapter;
        private bullseyeDataSetTableAdapters.transactionTableAdapter transactionTableAdapter;
        private bullseyeDataSetTableAdapters.inventoryTableAdapter inventoryTableAdapter;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.PictureBox picCancel;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInumInput;
        private System.Windows.Forms.Label lblQuanInput;
        private System.Windows.Forms.MaskedTextBox mtxtItemNumber;
        private System.Windows.Forms.MaskedTextBox mtxtQuantities;
        private System.Windows.Forms.Label lblItemNumTitle;
        private System.Windows.Forms.Label lblItemNum;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblSubtotalTitle;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTaxTitle;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label lblGrandTotalTitle;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}