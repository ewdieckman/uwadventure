using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWAdventure.Events;

namespace UWAdventure.BLL
{
    /// <summary>
    /// Business object responsible for handling notifications for processing of new orders
    /// </summary>
    /// <remarks>No real functionality - stub methods only for illustrative purposes</remarks>
    public class NewOrderProcessingNotificationService
    {
        private readonly NewOrderProcessor _newOrderProcessor;

        public NewOrderProcessingNotificationService(NewOrderProcessor newOrderProcessor)
        {
            _newOrderProcessor = newOrderProcessor;
            newOrderProcessor.OrderIsProcessing += NewOrderProcessing;
            newOrderProcessor.OrderIsRejected += NewOrderRejected;
        }

        /// <summary>
        /// Method for handling order processing events
        /// </summary>
        protected void NewOrderProcessing(object sender, OrderProcessingEventArgs args)
        {
            //maybe this method would send out emails notifying the customer that the order is being processed

            //may also notify the warehouse that an order is ready to have inventory pulled
        }

        /// <summary>
        /// Method for handling order rejected events
        /// </summary>
        protected void NewOrderRejected(object sender, OrderRejectedEventArgs args)
        {
            // this method to notify the customer that the order has been rejected

        }
    }
}
