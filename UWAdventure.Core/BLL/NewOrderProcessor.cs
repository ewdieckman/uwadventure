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
            newOrderCreator.OrderCreated += NewOrderCreated;
            _inventoryService = new InventoryService();
        }

        /// <summary>
        /// Method for handling order creation events
        /// </summary>
        protected void NewOrderCreated(object sender, OrderCreatedEventArgs args)
        {
            OrderDTO order = args.Order;
            ICollection<OrderItemDTO> items = args.Items;

            // check the inventory service to see if there is enough inventory to fill this order
            // although probably not a good business practice, we are only going to process the order
            // if it can be filled ENTIRELY.  If not, it will be rejected.

            bool reject_order = false;

            foreach(OrderItemDTO item in items)
            {
                if (item.quantity > _inventoryService.InventoryAmount(order.store_id, item.product_id))
                {
                    reject_order = true;
                    break;
                }
            }

            if (reject_order)
            {
                SetOrderAsRejected(order, items);

                // inform the inventory service that an order needs additional inventory
                foreach(OrderItemDTO item in items)
                {
                    _inventoryService.ProductRequired(order.store_id, item.product_id, item.quantity);
                }
                
            }
            else { 
                SetOrderAsProcessing(order, items);

                // might have references to talk to a shipping business object to start the shipping process
                // OR the shipping service might be listening for the OrderIsProcessing event
            }

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
            OrderProcessingEventArgs args = new OrderProcessingEventArgs() { Order = orderDTO, Items = items };
            OrderIsProcessing?.Invoke(this, args);
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
