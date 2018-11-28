using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWAdventure.Data;
using UWAdventure.Entities.Persistence;
using UWAdventure.Enum;
using UWAdventure.Events;

namespace UWAdventure.BLL
{
    /// <summary>
    /// Business object responsible for processing new orders
    /// </summary>
    public class NewOrderProcessor
    {
        private readonly OrderDAO _orderDAO;
        private readonly InventoryService _inventoryService;
        
        public event EventHandler<OrderRejectedEventArgs> OrderIsRejected;          //event delegate for when order an order is set to Rejected
        public event EventHandler<OrderProcessingEventArgs> OrderIsProcessing;      //event delegate for when order an order is set to Processing
        public event EventHandler<OrderCompletedEventArgs> OrderIsComplete;         //event delegate for when order an order is Completed

        public NewOrderProcessor(NewOrderCreator newOrderCreator)
        {
            _inventoryService = new InventoryService();
            _orderDAO = new OrderDAO();
        }


        /// <summary>
        /// Trigger method called to raise the <see cref="OrderIsProcessing"/> event
        /// </summary>
        protected virtual void OnOrderIsProcessing(OrderDTO orderDTO, ICollection<OrderItemDTO> items)
        {
            //null test, without making a copy while keeping thread-safety
            OrderProcessingEventArgs args = new OrderProcessingEventArgs() { Order = orderDTO, Items = items };
            OrderIsProcessing?.Invoke(this, args);
        }

        /// <summary>
        /// Trigger method called to raise the <see cref="OrderIsRejected"/> event
        /// </summary>
        protected virtual void OnOrderIsRejected(OrderDTO orderDTO, ICollection<OrderItemDTO> items)
        {
            //null test, without making a copy while keeping thread-safety
            OrderRejectedEventArgs args = new OrderRejectedEventArgs() { Order = orderDTO, Items = items };
            OrderIsRejected?.Invoke(this, args);
        }

        /// <summary>
        /// Sets the order status as "processing"
        /// </summary>
        /// <param name="order_number"></param>
        protected void SetOrderAsProcessing(OrderDTO order, ICollection<OrderItemDTO> items)
        {
            _orderDAO.SetOrderStatus(order.order_number, OrderStatus.Processing);

            OnOrderIsProcessing(order, items);
        }

        /// <summary>
        /// Sets the order status as "processing"
        /// </summary>
        /// <param name="order_number"></param>
        protected void SetOrderAsRejected(OrderDTO order, ICollection<OrderItemDTO> items)
        {
            _orderDAO.SetOrderStatus(order.order_number, OrderStatus.Rejected);

            OnOrderIsRejected(order, items);
        }
    }
}
