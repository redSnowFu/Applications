namespace Bullseye
{
    partial class ScanItems
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
            this.transactionlineTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionlineTableAdapter();
            this.transactionTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.transactionTableAdapter();
            this.itemTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.itemTableAdapter();
            this.dgvWaiting = new System.Windows.Forms.DataGridView();
            this.dgvProcessing = new System.Windows.Forms.DataGridView();
            this.btnScanAll = new System.Windows.Forms.Button();
            this.btnScanOne = new System.Windows.Forms.Button();
            this.btnConfirmReady = new System.Windows.Forms.Button();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.bdsWaiting = new System.Windows.Forms.BindingSource(this.components);
            this.bdsProcessing = new System.Windows.Forms.BindingSource(this.components);
            this.processingtlineTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.processingtlineTableAdapter();
            this.deliveryTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.deliveryTableAdapter();
            this.locationTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.locationTableAdapter();
            this.deliverytransactionTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.deliverytransactionTableAdapter();
            this.routeTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.routeTableAdapter();
            this.lblPickCourier = new System.Windows.Forms.Label();
            this.cboECourier = new System.Windows.Forms.ComboBox();
            this.courierTableAdapter = new Bullseye.bullseyeDataSetTableAdapters.courierTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProcessing)).BeginInit();
            this.SuspendLayout();
            // 
            // transactionlineTableAdapter
            // 
            this.transactionlineTableAdapter.ClearBeforeFill = true;
            // 
            // transactionTableAdapter
            // 
            this.transactionTableAdapter.ClearBeforeFill = true;
            // 
            // itemTableAdapter
            // 
            this.itemTableAdapter.ClearBeforeFill = true;
            // 
            // dgvWaiting
            // 
            this.dgvWaiting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaiting.Location = new System.Drawing.Point(23, 84);
            this.dgvWaiting.Name = "dgvWaiting";
            this.dgvWaiting.RowTemplate.Height = 24;
            this.dgvWaiting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWaiting.Size = new System.Drawing.Size(509, 582);
            this.dgvWaiting.TabIndex = 0;
            // 
            // dgvProcessing
            // 
            this.dgvProcessing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcessing.Location = new System.Drawing.Point(804, 84);
            this.dgvProcessing.Name = "dgvProcessing";
            this.dgvProcessing.RowTemplate.Height = 24;
            this.dgvProcessing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProcessing.Size = new System.Drawing.Size(509, 582);
            this.dgvProcessing.TabIndex = 1;
            // 
            // btnScanAll
            // 
            this.btnScanAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanAll.Location = new System.Drawing.Point(592, 183);
            this.btnScanAll.Name = "btnScanAll";
            this.btnScanAll.Size = new System.Drawing.Size(168, 44);
            this.btnScanAll.TabIndex = 31;
            this.btnScanAll.Text = "Scan All Items";
            this.btnScanAll.UseVisualStyleBackColor = true;
            this.btnScanAll.Click += new System.EventHandler(this.btnScanAll_Click);
            // 
            // btnScanOne
            // 
            this.btnScanOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanOne.Location = new System.Drawing.Point(592, 285);
            this.btnScanOne.Name = "btnScanOne";
            this.btnScanOne.Size = new System.Drawing.Size(168, 44);
            this.btnScanOne.TabIndex = 32;
            this.btnScanOne.Text = "Scan a Item";
            this.btnScanOne.UseVisualStyleBackColor = true;
            this.btnScanOne.Click += new System.EventHandler(this.btnScanOne_Click);
            // 
            // btnConfirmReady
            // 
            this.btnConfirmReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmReady.Location = new System.Drawing.Point(592, 556);
            this.btnConfirmReady.Name = "btnConfirmReady";
            this.btnConfirmReady.Size = new System.Drawing.Size(168, 55);
            this.btnConfirmReady.TabIndex = 33;
            this.btnConfirmReady.Text = "Confirm Order is ready";
            this.btnConfirmReady.UseVisualStyleBackColor = true;
            this.btnConfirmReady.Click += new System.EventHandler(this.btnConfirmReady_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("Corsiva", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblUserInfo.Location = new System.Drawing.Point(23, 9);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(1290, 60);
            this.lblUserInfo.TabIndex = 34;
            this.lblUserInfo.Text = "user info";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // processingtlineTableAdapter
            // 
            this.processingtlineTableAdapter.ClearBeforeFill = true;
            // 
            // deliveryTableAdapter
            // 
            this.deliveryTableAdapter.ClearBeforeFill = true;
            // 
            // locationTableAdapter
            // 
            this.locationTableAdapter.ClearBeforeFill = true;
            // 
            // deliverytransactionTableAdapter
            // 
            this.deliverytransactionTableAdapter.ClearBeforeFill = true;
            // 
            // routeTableAdapter
            // 
            this.routeTableAdapter.ClearBeforeFill = true;
            // 
            // lblPickCourier
            // 
            this.lblPickCourier.AutoSize = true;
            this.lblPickCourier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPickCourier.Location = new System.Drawing.Point(588, 468);
            this.lblPickCourier.Name = "lblPickCourier";
            this.lblPickCourier.Size = new System.Drawing.Size(152, 20);
            this.lblPickCourier.TabIndex = 35;
            this.lblPickCourier.Text = "Select a Courier:";
            // 
            // cboECourier
            // 
            this.cboECourier.FormattingEnabled = true;
            this.cboECourier.Location = new System.Drawing.Point(592, 509);
            this.cboECourier.Name = "cboECourier";
            this.cboECourier.Size = new System.Drawing.Size(168, 24);
            this.cboECourier.TabIndex = 36;
            // 
            // courierTableAdapter
            // 
            this.courierTableAdapter.ClearBeforeFill = true;
            // 
            // ScanItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 688);
            this.Controls.Add(this.cboECourier);
            this.Controls.Add(this.lblPickCourier);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.btnConfirmReady);
            this.Controls.Add(this.btnScanOne);
            this.Controls.Add(this.btnScanAll);
            this.Controls.Add(this.dgvProcessing);
            this.Controls.Add(this.dgvWaiting);
            this.Name = "ScanItems";
            this.Text = "ScanItems";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScanItems_FormClosing);
            this.Load += new System.EventHandler(this.ScanItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWaiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsProcessing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private bullseyeDataSetTableAdapters.transactionlineTableAdapter transactionlineTableAdapter;
        private bullseyeDataSetTableAdapters.transactionTableAdapter transactionTableAdapter;
        private bullseyeDataSetTableAdapters.itemTableAdapter itemTableAdapter;

        private System.Windows.Forms.DataGridView dgvWaiting;
        private System.Windows.Forms.DataGridView dgvProcessing;
        private System.Windows.Forms.Button btnScanAll;
        private System.Windows.Forms.Button btnScanOne;
        private System.Windows.Forms.Button btnConfirmReady;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.BindingSource bdsWaiting;
        private System.Windows.Forms.BindingSource bdsProcessing;
        private bullseyeDataSetTableAdapters.processingtlineTableAdapter processingtlineTableAdapter;
        private bullseyeDataSetTableAdapters.deliveryTableAdapter deliveryTableAdapter;
        private bullseyeDataSetTableAdapters.locationTableAdapter locationTableAdapter;
        private bullseyeDataSetTableAdapters.deliverytransactionTableAdapter deliverytransactionTableAdapter;
        private bullseyeDataSetTableAdapters.routeTableAdapter routeTableAdapter;
        private System.Windows.Forms.Label lblPickCourier;
        private System.Windows.Forms.ComboBox cboECourier;
        private bullseyeDataSetTableAdapters.courierTableAdapter courierTableAdapter;
    }
}