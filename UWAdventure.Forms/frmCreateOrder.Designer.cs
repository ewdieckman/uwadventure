namespace UWAdventure.Forms
{
    partial class frmCreateOrder
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
            this.lstBxCustomers = new System.Windows.Forms.ListBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cbStore = new System.Windows.Forms.ComboBox();
            this.lblStore = new System.Windows.Forms.Label();
            this.cbStaff = new System.Windows.Forms.ComboBox();
            this.lblStaff = new System.Windows.Forms.Label();
            this.lstBxProducts = new System.Windows.Forms.ListBox();
            this.lbProducts = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBxCustomers
            // 
            this.lstBxCustomers.FormattingEnabled = true;
            this.lstBxCustomers.Location = new System.Drawing.Point(34, 84);
            this.lstBxCustomers.Name = "lstBxCustomers";
            this.lstBxCustomers.Size = new System.Drawing.Size(209, 95);
            this.lstBxCustomers.TabIndex = 0;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(34, 65);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Customer:";
            // 
            // cbStore
            // 
            this.cbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStore.FormattingEnabled = true;
            this.cbStore.Location = new System.Drawing.Point(72, 26);
            this.cbStore.Name = "cbStore";
            this.cbStore.Size = new System.Drawing.Size(171, 21);
            this.cbStore.TabIndex = 2;
            this.cbStore.SelectedIndexChanged += new System.EventHandler(this.cbStore_SelectedIndexChanged);
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Location = new System.Drawing.Point(31, 26);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(35, 13);
            this.lblStore.TabIndex = 3;
            this.lblStore.Text = "Store:";
            // 
            // cbStaff
            // 
            this.cbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStaff.FormattingEnabled = true;
            this.cbStaff.Location = new System.Drawing.Point(362, 25);
            this.cbStaff.Name = "cbStaff";
            this.cbStaff.Size = new System.Drawing.Size(162, 21);
            this.cbStaff.TabIndex = 4;
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(274, 26);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(82, 13);
            this.lblStaff.TabIndex = 5;
            this.lblStaff.Text = "Sales Associate";
            // 
            // lstBxProducts
            // 
            this.lstBxProducts.FormattingEnabled = true;
            this.lstBxProducts.Location = new System.Drawing.Point(277, 84);
            this.lstBxProducts.Name = "lstBxProducts";
            this.lstBxProducts.Size = new System.Drawing.Size(247, 95);
            this.lstBxProducts.TabIndex = 6;
            // 
            // lbProducts
            // 
            this.lbProducts.AutoSize = true;
            this.lbProducts.Location = new System.Drawing.Point(277, 65);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(44, 13);
            this.lbProducts.TabIndex = 7;
            this.lbProducts.Text = "Product";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(109, 197);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(43, 20);
            this.txtQuantity.TabIndex = 8;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(54, 197);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "Quantity:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(431, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 32);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(331, 218);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(94, 32);
            this.btnCreateOrder.TabIndex = 11;
            this.btnCreateOrder.Text = "Create Order";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // frmCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 276);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lbProducts);
            this.Controls.Add(this.lstBxProducts);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.cbStaff);
            this.Controls.Add(this.lblStore);
            this.Controls.Add(this.cbStore);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lstBxCustomers);
            this.Name = "frmCreateOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Order - UWAdventure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCreateOrder_FormClosing);
            this.Load += new System.EventHandler(this.frmCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBxCustomers;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cbStore;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.ComboBox cbStaff;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.ListBox lstBxProducts;
        private System.Windows.Forms.Label lbProducts;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreateOrder;
    }
}