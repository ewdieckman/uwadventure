using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UWAdventure.BLL;
using UWAdventure.Entities.ViewModels;

namespace UWAdventure.Forms
{
    public partial class frmOrderSummary : Form
    {
        private readonly Form _calling_form;
        private readonly OrderSummaryViewer _orderSummaryViewer;

        public frmOrderSummary(Form calling_form)
        {
            InitializeComponent();

            //we pass in the form that opened this form.   Then we know how to get back to it.
            _calling_form = calling_form;
            _orderSummaryViewer = new OrderSummaryViewer();
        }

        #region "Form Events"
        /// <summary>
        /// Event handler for while the form is closing
        /// </summary>
        private void frmOrderSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            _calling_form.Show();
        }


        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            IList<StoreOrderSummaryViewModel> stats = GetOrderSummary();
            PrintOutResults(stats);
            dgvResults.Visible = true;
        }

        /// <summary>
        /// Retrieves order summary
        /// </summary>
        private IList<StoreOrderSummaryViewModel> GetOrderSummary()
        {
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;

            return _orderSummaryViewer.GetStoreOrderSummary(start, end);
        }

        /// <summary>
        /// Prints the stats out on the form
        /// </summary>
        private void PrintOutResults(IList<StoreOrderSummaryViewModel> stats)
        {
            BindingSource source = new BindingSource();
            source.DataSource = stats;
            dgvResults.DataSource = source;

        }

        /// <summary>
        /// clears and hides the grid
        /// </summary>
        private void ClearAndHideGrid()
        {
            //((BindingSource)dgvResults.DataSource).DataSource = null;
            dgvResults.Hide();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            ClearAndHideGrid();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            ClearAndHideGrid();
        }
    }
}
