using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWAdventure.Data;
using UWAdventure.Entities.ViewModels;

namespace UWAdventure.BLL
{
    /// <summary>
    /// business class for order summary queries
    /// </summary>
    public class OrderSummaryViewer
    {
        private readonly OrderDAO _orderDAO;

        public OrderSummaryViewer()
        {
            _orderDAO = new OrderDAO();
        }

        /// <summary>
        /// Retrieves order summary stats by store for the specified date range
        /// </summary>
        public IList<StoreOrderSummaryViewModel> GetStoreOrderSummary(DateTime start_date, DateTime end_date)
        {
            return _orderDAO.GetStoreOrderSummary(start_date, end_date);
        }
    }
}
