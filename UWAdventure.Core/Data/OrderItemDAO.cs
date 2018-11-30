using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using UWAdventure.Entities.Persistence;
using System.Configuration;
using Dapper;

namespace UWAdventure.Data
{
    /// <summary>
    /// Data access object for order items
    /// </summary>
    public class OrderItemDAO
    {
        public OrderItemDAO()
        {
        }

        public IEnumerable<OrderItemDTO> GetOrderItems(int order_number)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates new order items
        /// </summary>
        public void CreateOrder(IList<OrderItemDTO> orderItems)
        {

            throw new NotImplementedException();
        }


    }
}
