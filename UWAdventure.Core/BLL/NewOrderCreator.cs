using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWAdventure.Data;
using UWAdventure.Entities.DTO;
using UWAdventure.Entities.Persistence;
using UWAdventure.Enum;
using UWAdventure.Events;

namespace UWAdventure.BLL
{
    /// <summary>
    /// Business object responsible for creating new orders in the system
    /// </summary>
    public class NewOrderCreator
    {
        private readonly OrderDAO _orderDAO;
        private readonly OrderItemDAO _orderItemDAO;
        private readonly InventoryService _inventoryService;
        private readonly ProductService _productService;
        private readonly NewOrderProcessor _newOrderProcessor;
        private readonly NewOrderCreationNotificationService _newOrderNotifier;

        public event EventHandler<OrderCreatedEventArgs> OrderCreated;              //event delegate for when order is created

        public NewOrderCreator()
        {
            _inventoryService = new InventoryService();
            _orderDAO = new OrderDAO();
            _orderItemDAO = new OrderItemDAO();
            _productService = new ProductService();
            _newOrderNotifier = new NewOrderCreationNotificationService(this);
            _newOrderProcessor = new NewOrderProcessor(this);

        }


        /// <summary>
        /// Returns the status for a new order
        /// </summary>
        private OrderStatus GetNewOrderStatus()
        {
            //could have some additional logic where an order proceeds directly to processing or something.  For now, just use "Pending"
            return OrderStatus.Pending;
        }

        /// <summary>
        /// Trigger method called to raise the <see cref="OrderCreated"/> event
        /// </summary>
        protected virtual void OnOrderCreated(OrderDTO orderDTO, ICollection<OrderItemDTO> items)
        {
            //null test, without making a copy while keeping thread-safety
            OrderCreatedEventArgs args = new OrderCreatedEventArgs() { Order = orderDTO, Items = items };
            OrderCreated?.Invoke(this, args);
        }
    }
}
