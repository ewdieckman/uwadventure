using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UWAdventure.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for menu option Reports->OrderSummary
        /// </summary>
        private void mnu_Reports_OrderSummary_Click(object sender, EventArgs e)
        {
            GoToOrderSummary();
        }


        /// <summary>
        /// Event handler for button Order Summary
        /// </summary>
        private void btnOrderSummary_Click(object sender, EventArgs e)
        {
            GoToOrderSummary();
        }

        /// <summary>
        /// Event handler for button Create New Order
        /// </summary>
        private void frmNewOrder_Click(object sender, EventArgs e)
        {
            GoToCreateOrder();
        }

        /// <summary>
        /// Event handler for menu option Orders-->Create new Order
        /// </summary>
        private void mnu_Orders_Create_Click(object sender, EventArgs e)
        {
            GoToCreateOrder();
        }

        /// <summary>
        /// Event handler for button Exit
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        /// <summary>
        /// Event handler for menu option File-->Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFile_Exit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        /// <summary>
        /// Method to exit application
        /// </summary>
        private void ExitApplication()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                "Exit UWAdventure POS",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Goes to the Create order form
        /// </summary>
        private void GoToCreateOrder()
        {
            frmCreateOrder frmCreate = new frmCreateOrder(this);
            frmCreate.Show();
            Hide();
        }

        private void GoToOrderSummary()
        {
            frmOrderSummary frmSummary = new frmOrderSummary(this);
            frmSummary.Show();
            Hide();
        }
    }
}
