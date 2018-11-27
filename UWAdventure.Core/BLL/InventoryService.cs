using System;
using System.Collections.Generic;
using System.Text;
using UWAdventure.Data;
using UWAdventure.Events;

namespace UWAdventure.BLL
{
    public class InventoryService
    {
        public InventoryService(OrderService orderService)
        {
            //OrderService orderService = new OrderService();
            //subscribe to the OrderCreated event from the Order service
            orderService.OrderCreated += OrderCreated;
        }

        /// <summary>
        /// Method for handling order creation events
        /// </summary>
        protected void OrderCreated(object sender, OrderCreatedEventArgs args)
        {
            Console.WriteLine("New order created: " + args.OrderNumber);
        }
    }
}
