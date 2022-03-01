namespace Bullseye
{
    partial class ReceiveItems
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
            this.btnSigns = new System.Windows.Forms.Button();
            this.btnScanOne = new System.Windows.Forms.Button();
            this.btnScanAll = new System.Windows.Forms.Button();
            this.dgvWaiting = new System.Windows.Forms.DataGridView();
            this.transactionTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionTableAdapter();
            this.bdsWaiting = new System.Windows.Forms.BindingSource(this.components);
            this.transactionlineTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionlineTableAdapter();
            this.inventoryTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.inventoryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWaiting)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("Corsiva", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblUserInfo.Location = new System.Drawing.Point(12, 9);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(869, 60);
            this.lblUserInfo.TabIndex = 39;
            this.lblUserInfo.Text = "user info";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSigns
            // 
            this.btnSigns.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSigns.Location = new System.Drawing.Point(654, 488);
            this.btnSigns.Name = "btnSigns";
            this.btnSigns.Size = new System.Drawing.Size(168, 55);
            this.btnSigns.TabIndex = 38;
            this.btnSigns.Text = "Signs";
            this.btnSigns.UseVisualStyleBackColor = true;
            this.btnSigns.Click += new System.EventHandler(this.btnSigns_Click);
            // 
            // btnScanOne
            // 
            this.btnScanOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanOne.Location = new System.Drawing.Point(654, 285);
            this.btnScanOne.Name = "btnScanOne";
            this.btnScanOne.Size = new System.Drawing.Size(168, 44);
            this.btnScanOne.TabIndex = 37;
            this.btnScanOne.Text = "Scan a Item";
            this.btnScanOne.UseVisualStyleBackColor = true;
            this.btnScanOne.Click += new System.EventHandler(this.btnScanOne_Click);
            // 
            // btnScanAll
            // 
            this.btnScanAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanAll.Location = new System.Drawing.Point(654, 183);
            this.btnScanAll.Name = "btnScanAll";
            this.btnScanAll.Size = new System.Drawing.Size(168, 44);
            this.btnScanAll.TabIndex = 36;
            this.btnScanAll.Text = "Scan All Items";
            this.btnScanAll.UseVisualStyleBackColor = true;
            this.btnScanAll.Click += new System.EventHandler(this.btnScanAll_Click);
            // 
            // dgvWaiting
            // 
            this.dgvWaiting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaiting.Location = new System.Drawing.Point(12, 84);
            this.dgvWaiting.Name = "dgvWaiting";
            this.dgvWaiting.RowTemplate.Height = 24;
            this.dgvWaiting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWaiting.Size = new System.Drawing.Size(565, 582);
            this.dgvWaiting.TabIndex = 35;
            this.dgvWaiting.SelectionChanged += new System.EventHandler(this.dgvWaiting_SelectionChanged);
            // 
            // transactionTableAdapter
            // 
            this.transactionTableAdapter.ClearBeforeFill = true;
            // 
            // transactionlineTableAdapter
            // 
            this.transactionlineTableAdapter.ClearBeforeFill = true;
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // ReceiveItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 687);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.btnSigns);
            this.Controls.Add(this.btnScanOne);
            this.Controls.Add(this.btnScanAll);
            this.Controls.Add(this.dgvWaiting);
            this.Name = "ReceiveItems";
            this.Text = "Receive Items";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiveItems_FormClosing);
            this.Load += new System.EventHandler(this.ReceiveItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWaiting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnSigns;
        private System.Windows.Forms.Button btnScanOne;
        private System.Windows.Forms.Button btnScanAll;
        private System.Windows.Forms.DataGridView dgvWaiting;
        private bullseyeDataSetTableAdapters.transactionTableAdapter transactionTableAdapter;
        private System.Windows.Forms.BindingSource bdsWaiting;
        private bullseyeDataSetTableAdapters.transactionlineTableAdapter transactionlineTableAdapter;
        private bullseyeDataSetTableAdapters.inventoryTableAdapter inventoryTableAdapter;
    }
}