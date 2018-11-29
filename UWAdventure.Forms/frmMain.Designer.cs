namespace UWAdventure.Forms
{
    partial class frmMain
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
            this.btnExit = new System.Windows.Forms.Button();
            this.frmNewOrder = new System.Windows.Forms.Button();
            this.btnOrderSummary = new System.Windows.Forms.Button();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Orders_Create = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Reports_OrderSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(259, 182);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 33);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmNewOrder
            // 
            this.frmNewOrder.Location = new System.Drawing.Point(39, 78);
            this.frmNewOrder.Name = "frmNewOrder";
            this.frmNewOrder.Size = new System.Drawing.Size(97, 41);
            this.frmNewOrder.TabIndex = 1;
            this.frmNewOrder.Text = "&Create Order";
            this.frmNewOrder.UseVisualStyleBackColor = true;
            this.frmNewOrder.Click += new System.EventHandler(this.frmNewOrder_Click);
            // 
            // btnOrderSummary
            // 
            this.btnOrderSummary.Location = new System.Drawing.Point(179, 78);
            this.btnOrderSummary.Name = "btnOrderSummary";
            this.btnOrderSummary.Size = new System.Drawing.Size(103, 41);
            this.btnOrderSummary.TabIndex = 2;
            this.btnOrderSummary.Text = "&Order Summary";
            this.btnOrderSummary.UseVisualStyleBackColor = true;
            this.btnOrderSummary.Click += new System.EventHandler(this.btnOrderSummary_Click);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.ordersToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(383, 24);
            this.mnuMain.TabIndex = 3;
            this.mnuMain.Text = "Main Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile_Exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuFile_Exit
            // 
            this.mnuFile_Exit.Name = "mnuFile_Exit";
            this.mnuFile_Exit.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_Exit.Text = "E&xit";
            this.mnuFile_Exit.Click += new System.EventHandler(this.mnuFile_Exit_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Orders_Create});
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.ordersToolStripMenuItem.Text = "Orders";
            // 
            // mnu_Orders_Create
            // 
            this.mnu_Orders_Create.Name = "mnu_Orders_Create";
            this.mnu_Orders_Create.Size = new System.Drawing.Size(180, 22);
            this.mnu_Orders_Create.Text = "&Create Order";
            this.mnu_Orders_Create.Click += new System.EventHandler(this.mnu_Orders_Create_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Reports_OrderSummary});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // mnu_Reports_OrderSummary
            // 
            this.mnu_Reports_OrderSummary.Name = "mnu_Reports_OrderSummary";
            this.mnu_Reports_OrderSummary.Size = new System.Drawing.Size(158, 22);
            this.mnu_Reports_OrderSummary.Text = "Order Summary";
            this.mnu_Reports_OrderSummary.Click += new System.EventHandler(this.mnu_Reports_OrderSummary_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 240);
            this.Controls.Add(this.btnOrderSummary);
            this.Controls.Add(this.frmNewOrder);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UWAdventure POS";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button frmNewOrder;
        private System.Windows.Forms.Button btnOrderSummary;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Exit;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_Orders_Create;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_Reports_OrderSummary;
    }
}

