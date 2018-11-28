using System;
using UWAdventure.Data;
using System.Collections.Generic;
using UWAdventure.Entities.ViewModels;

namespace UWAdventure.BLL
{
    /// <summary>
    /// Business object for providing access to order details
    /// </summary>
    public class OrderDetailViewer
    {
        private readonly OrderDAO _orderDAO;

        public OrderDetailViewer()
        {
            _orderDAO = new OrderDAO();
        }

        /// <summary>
        /// Returns a view model with all order details
        /// </summary>
        public OrderViewModel GetOrderDetails(int order_number)
        {
            return _orderDAO.GetOrderDetails(order_number);
        }

        public IList<OrderViewModel> GetOrderDetails(DateTime start_date, DateTime end_date)
        {
            return _orderDAO.GetOrderDetails(start_date, end_date);
        }

    }
}