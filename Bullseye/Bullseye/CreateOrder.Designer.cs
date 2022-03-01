namespace Bullseye
{
    partial class CreateOrder
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
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.dgvOrderItem = new System.Windows.Forms.DataGridView();
            this.bdsOrderItem = new System.Windows.Forms.BindingSource(this.components);
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.grpManage = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.grpSearchItems = new System.Windows.Forms.GroupBox();
            this.txtDescriptionIF = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.txtItemNameIF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemIDIF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSupplierNameIF = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCategoryIF = new System.Windows.Forms.ComboBox();
            this.btnProcessing = new System.Windows.Forms.Button();
            this.btnModifyQuanties = new System.Windows.Forms.Button();
            this.transactionlineTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionlineTableAdapter();
            this.itemTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.itemTableAdapter();
            this.transactionTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionTableAdapter();
            this.supplierTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.supplierTableAdapter();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.mtxtDeliveryDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsOrderItem)).BeginInit();
            this.grpManage.SuspendLayout();
            this.grpSearchItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("Corsiva", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblUserInfo.Location = new System.Drawing.Point(24, 9);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(1340, 60);
            this.lblUserInfo.TabIndex = 19;
            this.lblUserInfo.Text = "user info";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvOrderItem
            // 
            this.dgvOrderItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItem.Location = new System.Drawing.Point(30, 307);
            this.dgvOrderItem.Name = "dgvOrderItem";
            this.dgvOrderItem.RowTemplate.Height = 24;
            this.dgvOrderItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderItem.Size = new System.Drawing.Size(1334, 342);
            this.dgvOrderItem.TabIndex = 20;
            this.dgvOrderItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItem_CellContentClick);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(23, 136);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(112, 24);
            this.chkAll.TabIndex = 26;
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(157, 125);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(131, 44);
            this.btnRemove.TabIndex = 27;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // grpManage
            // 
            this.grpManage.BackColor = System.Drawing.Color.Aqua;
            this.grpManage.Controls.Add(this.btnSubmit);
            this.grpManage.Controls.Add(this.chkAll);
            this.grpManage.Controls.Add(this.btnRemove);
            this.grpManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpManage.Location = new System.Drawing.Point(30, 103);
            this.grpManage.Name = "grpManage";
            this.grpManage.Size = new System.Drawing.Size(310, 188);
            this.grpManage.TabIndex = 28;
            this.grpManage.TabStop = false;
            this.grpManage.Text = "Manage";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(157, 46);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(131, 44);
            this.btnSubmit.TabIndex = 28;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // grpSearchItems
            // 
            this.grpSearchItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.grpSearchItems.Controls.Add(this.txtDescriptionIF);
            this.grpSearchItems.Controls.Add(this.label17);
            this.grpSearchItems.Controls.Add(this.btnSearchItem);
            this.grpSearchItems.Controls.Add(this.txtItemNameIF);
            this.grpSearchItems.Controls.Add(this.label2);
            this.grpSearchItems.Controls.Add(this.txtItemIDIF);
            this.grpSearchItems.Controls.Add(this.label1);
            this.grpSearchItems.Controls.Add(this.label5);
            this.grpSearchItems.Controls.Add(this.cboSupplierNameIF);
            this.grpSearchItems.Controls.Add(this.label4);
            this.grpSearchItems.Controls.Add(this.cboCategoryIF);
            this.grpSearchItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearchItems.Location = new System.Drawing.Point(570, 103);
            this.grpSearchItems.Name = "grpSearchItems";
            this.grpSearchItems.Size = new System.Drawing.Size(794, 188);
            this.grpSearchItems.TabIndex = 29;
            this.grpSearchItems.TabStop = false;
            this.grpSearchItems.Text = "Search";
            // 
            // txtDescriptionIF
            // 
            this.txtDescriptionIF.Location = new System.Drawing.Point(192, 125);
            this.txtDescriptionIF.Name = "txtDescriptionIF";
            this.txtDescriptionIF.Size = new System.Drawing.Size(241, 27);
            this.txtDescriptionIF.TabIndex = 11;
            this.txtDescriptionIF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescriptionIF_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(27, 126);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 20);
            this.label17.TabIndex = 12;
            this.label17.Text = "Description:";
            // 
            // btnSearchItem
            // 
            this.btnSearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchItem.Location = new System.Drawing.Point(633, 132);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(105, 38);
            this.btnSearchItem.TabIndex = 5;
            this.btnSearchItem.Text = "Search";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            this.btnSearchItem.Click += new System.EventHandler(this.btnSearchItem_Click);
            // 
            // txtItemNameIF
            // 
            this.txtItemNameIF.Location = new System.Drawing.Point(192, 79);
            this.txtItemNameIF.Name = "txtItemNameIF";
            this.txtItemNameIF.Size = new System.Drawing.Size(241, 27);
            this.txtItemNameIF.TabIndex = 2;
            this.txtItemNameIF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemNameIF_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Item Name:";
            // 
            // txtItemIDIF
            // 
            this.txtItemIDIF.Location = new System.Drawing.Point(192, 34);
            this.txtItemIDIF.Name = "txtItemIDIF";
            this.txtItemIDIF.Size = new System.Drawing.Size(241, 27);
            this.txtItemIDIF.TabIndex = 0;
            this.txtItemIDIF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemIDIF_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Item ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(467, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Supplier:";
            // 
            // cboSupplierNameIF
            // 
            this.cboSupplierNameIF.FormattingEnabled = true;
            this.cboSupplierNameIF.Location = new System.Drawing.Point(633, 79);
            this.cboSupplierNameIF.Name = "cboSupplierNameIF";
            this.cboSupplierNameIF.Size = new System.Drawing.Size(134, 28);
            this.cboSupplierNameIF.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Category:";
            // 
            // cboCategoryIF
            // 
            this.cboCategoryIF.FormattingEnabled = true;
            this.cboCategoryIF.Location = new System.Drawing.Point(633, 34);
            this.cboCategoryIF.Name = "cboCategoryIF";
            this.cboCategoryIF.Size = new System.Drawing.Size(150, 28);
            this.cboCategoryIF.TabIndex = 3;
            // 
            // btnProcessing
            // 
            this.btnProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessing.Location = new System.Drawing.Point(354, 103);
            this.btnProcessing.Name = "btnProcessing";
            this.btnProcessing.Size = new System.Drawing.Size(100, 44);
            this.btnProcessing.TabIndex = 30;
            this.btnProcessing.Text = "Process";
            this.btnProcessing.UseVisualStyleBackColor = true;
            this.btnProcessing.Click += new System.EventHandler(this.btnProcessing_Click);
            // 
            // btnModifyQuanties
            // 
            this.btnModifyQuanties.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyQuanties.Location = new System.Drawing.Point(354, 247);
            this.btnModifyQuanties.Name = "btnModifyQuanties";
            this.btnModifyQuanties.Size = new System.Drawing.Size(210, 44);
            this.btnModifyQuanties.TabIndex = 31;
            this.btnModifyQuanties.Text = "Modify Quantities";
            this.btnModifyQuanties.UseVisualStyleBackColor = true;
            this.btnModifyQuanties.Click += new System.EventHandler(this.btnModifyQuanties_Click);
            // 
            // transactionlineTableAdapter
            // 
            this.transactionlineTableAdapter.ClearBeforeFill = true;
            // 
            // itemTableAdapter
            // 
            this.itemTableAdapter.ClearBeforeFill = true;
            // 
            // transactionTableAdapter
            // 
            this.transactionTableAdapter.ClearBeforeFill = true;
            // 
            // supplierTableAdapter
            // 
            this.supplierTableAdapter.ClearBeforeFill = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(464, 103);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 44);
            this.btnRefresh.TabIndex = 32;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // mtxtDeliveryDate
            // 
            this.mtxtDeliveryDate.Location = new System.Drawing.Point(395, 219);
            this.mtxtDeliveryDate.Mask = "00/00/0000";
            this.mtxtDeliveryDate.Name = "mtxtDeliveryDate";
            this.mtxtDeliveryDate.Size = new System.Drawing.Size(131, 22);
            this.mtxtDeliveryDate.TabIndex = 33;
            this.mtxtDeliveryDate.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(377, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Estimated Arrival:";
            // 
            // CreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 659);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mtxtDeliveryDate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnModifyQuanties);
            this.Controls.Add(this.btnProcessing);
            this.Controls.Add(this.grpSearchItems);
            this.Controls.Add(this.dgvOrderItem);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.grpManage);
            this.Name = "CreateOrder";
            this.Text = "CreateOrder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateOrder_FormClosing);
            this.Load += new System.EventHandler(this.CreateOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsOrderItem)).EndInit();
            this.grpManage.ResumeLayout(false);
            this.grpManage.PerformLayout();
            this.grpSearchItems.ResumeLayout(false);
            this.grpSearchItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.DataGridView dgvOrderItem;
        private bullseyeDataSetTableAdapters.transactionlineTableAdapter transactionlineTableAdapter;
        private bullseyeDataSetTableAdapters.itemTableAdapter itemTableAdapter;
        private bullseyeDataSetTableAdapters.transactionTableAdapter transactionTableAdapter;
        private System.Windows.Forms.BindingSource bdsOrderItem;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox grpManage;
        private System.Windows.Forms.GroupBox grpSearchItems;
        private System.Windows.Forms.TextBox txtDescriptionIF;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSearchItem;
        private System.Windows.Forms.TextBox txtItemNameIF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemIDIF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSupplierNameIF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCategoryIF;
        private bullseyeDataSetTableAdapters.supplierTableAdapter supplierTableAdapter;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnProcessing;
        private System.Windows.Forms.Button btnModifyQuanties;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.MaskedTextBox mtxtDeliveryDate;
        private System.Windows.Forms.Label label3;
    }
}