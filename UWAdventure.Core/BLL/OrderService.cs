using System;
using UWAdventure.Data;
using UWAdventure.Entities.DTO;
using UWAdventure.Entities.Persistence;
using UWAdventure.Enum;
using UWAdventure.Events;
using System.Collections.Generic;

namespace UWAdventure.BLL
{
    /// <summary>
    /// Business logic for dealing with orders
    /// </summary>
    public class OrderService
    {

        private readonly OrderDAO _orderDAO;
        private readonly OrderItemDAO _orderItemDAO;
        private readonly InventoryService _inventoryService;
        private readonly ProductService _productService;

        public event EventHandler<OrderCreatedEventArgs> OrderCreated;         //event delegate for when order is created
        public event EventHandler<OrderShippedEventArgs> OrderShipped;         //event delegate for when order is shipped

        public OrderService()
        {
            _inventoryService = new InventoryService(this);
            _orderDAO = new OrderDAO();
            _orderItemDAO = new OrderItemDAO();
            //_storeService = storeService;
            //_customerService = customerService;
            //_staffService = staffService;
            _productService = new ProductService();
        }

        /// <summary>
        /// Creates a new order
        /// </summary>
        /// <param name="orderDTO">information needed to create a new order</param>
        /// <returns>The newly created order's order number</returns>
        public int CreateOrder(NewOrderDTO newOrderDTO)
        {

            // this method is used to validate incoming data - NEVER TRUST DATA COMING FROM A UI

            int order_number = -1;

            // although we list the price of items in the UI, we never assume that the price being passed in is correct.
            // we only pass in the product id, and then we lookup the price to ensure its accuracy

            // create the orderDTO for persistence and populate its properties
            OrderDTO orderDTO = new OrderDTO()
            {
                customer_id = newOrderDTO.customer_id,
                order_date = newOrderDTO.order_date,
                staff_id = newOrderDTO.staff_id,
                store_id = newOrderDTO.store_id,
            };

            // now we'll use a method to get the order status
            // a method is the preferred way, as maybe there is some business
            // logic to determine was a new order's status is based on certain parameters
            orderDTO.order_status = (int)GetNewOrderStatus();


            //save to the persistence store, and get the order number back?
            order_number = _orderDAO.CreateOrder(orderDTO);

            // now to populate items
            OrderItemDTO orderItemDTO;
            IList<OrderItemDTO> items = new List<OrderItemDTO>();
            foreach (NewOrderItemDTO item in newOrderDTO.items)
            {
                var product = _productService.GetByID(item.product_id);
                orderItemDTO = new OrderItemDTO()
                {
                    product_id = item.product_id,
                    price = product.list_price,
                    quantity = item.quantity,
                    order_number = order_number
                };

                items.Add(orderItemDTO);
            }

            //now save the items to the persistence store
            _orderItemDAO.CreateOrder(items);

            OnOrderCreated(order_number);


            return order_number;
        }


        /// <summary>
        /// Returns the status for a new order
        /// </summary>
        private OrderStatus GetNewOrderStatus()
        {
            //could have some additional logic where an order proceeds directly to processing or something.  For now, just use "Pending"
            return OrderStatus.Pending;
        }


        ///// <summary>
        ///// Ships the specified order
        ///// </summary>
        ///// <remarks>Sets the shipped date and updates the order status to Completed</remarks>
        //public void ShipOrder(int order_number)
        //{
        //    Order order = GetByOrderNumber(order_number);
        //    order.ShipOrder();

        //    OnOrderShipped(order.OrderNumber);
        //    Save(order);
        //}

        //public void RejectOrder(int order_number)
        //{

        //}

        /// <summary>
        /// Trigger method called to raise the <see cref="OrderCreated"/> event
        /// </summary>
        protected virtual void OnOrderCreated(int order_number)
        {
            //null test, without making a copy while keeping thread-safety
            OrderCreatedEventArgs args = new OrderCreatedEventArgs() { OrderNumber = order_number };
            OrderCreated?.Invoke(this, args);
        }

        /// <summary>
        /// Trigger method called to raise the <see cref="OrderShipped"/> event
        /// </summary>
        protected virtual void OnOrderShipped(int order_number)
        {
            //null test, without making a copy while keeping thread-safety
            OrderShippedEventArgs args = new OrderShippedEventArgs() { OrderNumber = order_number };
            OrderShipped?.Invoke(this, args);
        }

        //protected void Save(Order order)
        //{
        //    //get the parts into DTOs to transfer to the DAO
        //    OrderDTO orderDTO = OrderToDTO(order);
        //    IList<OrderItemDTO> items = new List<OrderItemDTO>();
        //    foreach(OrderItem item in order.Items)
        //    {
        //        items.Add(OrderItemToDTO(item));
        //    }

        //    //now send to DAOs to persist
        //    _orderDAO.Save(orderDTO);
        //    _orderItemDAO.Save(items, orderDTO.order_number);
        //}

        ///// <summary>
        ///// Converts an <see cref="OrderDTO"/> to <see cref="Order"/>
        ///// </summary>
        //private Order DTOtoOrder(OrderDTO orderDTO)
        //{

        //    Customer customer = _customerService.GetByID(orderDTO.customer_id);
        //    Store store = _storeService.GetByID(orderDTO.store_id);
        //    Staff created_by = _staffService.GetByID(orderDTO.staff_id);
        //    OrderStatus orderStatus = (OrderStatus)orderDTO.order_status;

        //    Order order = new Order(orderDTO.order_number, customer, created_by, orderStatus, orderDTO.order_date, store);

        //    IEnumerable<OrderItemDTO> items = _orderItemDAO.GetOrderItems(orderDTO.order_number);

        //    foreach (OrderItemDTO item in items)
        //    {
        //        Product product = _productService.GetByID(item.product_id);

        //        order.AddItemToOrder(product, item.quantity,item.price);
        //    }


        //    return order;
        //}

        ///// <summary>
        ///// Converts an <see cref="Order"/> to <see cref="OrderDTO"/>
        ///// </summary>
        //private OrderDTO OrderToDTO(Order order)
        //{
        //    OrderDTO orderDTO = new OrderDTO() {
        //        customer_id = order.Customer.CustomerID,
        //        store_id = order.Store.StoreID,
        //        staff_id = order.EnteredOrder.StaffID,
        //        order_status = (int)order.Status,
        //        order_date = order.OrderDate,
        //        shipped_date = order.ShippedDate,
        //        order_number = order.OrderNumber
        //    };

        //    return orderDTO;
        //}

        ///// <summary>
        ///// Converts an <see cref="OrderItem"/> to <see cref="OrderItemDTO"/>
        ///// </summary>
        //private OrderItemDTO OrderItemToDTO(OrderItem orderItem)
        //{
        //    OrderItemDTO orderItemDTO = new OrderItemDTO() {
        //        product_id = orderItem.Product.ProductID,
        //        order_number = orderItem.Order.OrderNumber,
        //        quantity = orderItem.Quantity,
        //        price = orderItem.Price
        //    };

        //    return orderItemDTO;
        //}
    }
}

