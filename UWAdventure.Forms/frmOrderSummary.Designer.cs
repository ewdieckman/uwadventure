namespace UWAdventure.Forms
{
    partial class frmOrderSummary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnExit = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.btnSummary = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalOrders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfUniqueProducts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "M/d/yyyy";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(50, 57);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(103, 20);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.Value = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(570, 385);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 39);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "M/d/yyyy";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(185, 57);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(104, 20);
            this.dtpEnd.TabIndex = 2;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(50, 38);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(58, 13);
            this.lblStart.TabIndex = 3;
            this.lblStart.Text = "Start Date:";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(185, 38);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(55, 13);
            this.lblEnd.TabIndex = 4;
            this.lblEnd.Text = "End Date:";
            // 
            // btnSummary
            // 
            this.btnSummary.Location = new System.Drawing.Point(53, 105);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(100, 36);
            this.btnSummary.TabIndex = 5;
            this.btnSummary.Text = "Get Summaries";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StoreName,
            this.TotalOrders,
            this.NumberOfUniqueProducts,
            this.Quantity,
            this.Revenue});
            this.dgvResults.Location = new System.Drawing.Point(49, 160);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowTemplate.ReadOnly = true;
            this.dgvResults.ShowEditingIcon = false;
            this.dgvResults.Size = new System.Drawing.Size(605, 186);
            this.dgvResults.TabIndex = 6;
            this.dgvResults.Visible = false;
            // 
            // StoreName
            // 
            this.StoreName.DataPropertyName = "StoreName";
            this.StoreName.HeaderText = "Store";
            this.StoreName.Name = "StoreName";
            this.StoreName.ReadOnly = true;
            // 
            // TotalOrders
            // 
            this.TotalOrders.DataPropertyName = "NumberOfOrders";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalOrders.DefaultCellStyle = dataGridViewCellStyle13;
            this.TotalOrders.HeaderText = "Orders";
            this.TotalOrders.Name = "TotalOrders";
            this.TotalOrders.ReadOnly = true;
            // 
            // NumberOfUniqueProducts
            // 
            this.NumberOfUniqueProducts.DataPropertyName = "NumberOfUniqueProducts";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NumberOfUniqueProducts.DefaultCellStyle = dataGridViewCellStyle14;
            this.NumberOfUniqueProducts.HeaderText = "Unique Products";
            this.NumberOfUniqueProducts.Name = "NumberOfUniqueProducts";
            this.NumberOfUniqueProducts.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "NumberOfItems";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle15;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Revenue
            // 
            this.Revenue.DataPropertyName = "TotalRevenue";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "c";
            this.Revenue.DefaultCellStyle = dataGridViewCellStyle16;
            this.Revenue.HeaderText = "Revenue";
            this.Revenue.Name = "Revenue";
            this.Revenue.ReadOnly = true;
            // 
            // frmOrderSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 436);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dtpStart);
            this.Name = "frmOrderSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Summary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrderSummary_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfUniqueProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revenue;
    }
}