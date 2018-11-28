using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWAdventure.Events;

namespace UWAdventure.BLL
{
    /// <summary>
    /// Business object responsible for notifications pertaining to new order creations
    /// </summary>
    /// <remarks>Only stubs - no real functionality</remarks>
    public class NewOrderCreationNotificationService
    {
        private readonly NewOrderCreator _newOrderCreator;

        public NewOrderCreationNotificationService(NewOrderCreator newOrderCreator)
        {
            _newOrderCreator = newOrderCreator;
            newOrderCreator.OrderCreated += NewOrderCreated;
        }

        /// <summary>
        /// Method for handling order creation events
        /// </summary>
        protected void NewOrderCreated(object sender, OrderCreatedEventArgs args)
        {
            //maybe this method would send out emails notifying the customer that the order has been created
        }
    }
}
