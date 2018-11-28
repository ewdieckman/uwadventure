using System;
using System.Collections.Generic;
using System.Text;
using UWAdventure.Entities.Persistence;

namespace UWAdventure.Events
{
    /// <summary>
    /// EventArgs when an order is being processed
    /// </summary>
    public class OrderProcessingEventArgs : EventArgs
    {
        public OrderDTO Order { get; set; }
        public ICollection<OrderItemDTO> Items { get; set; }
    }
}
