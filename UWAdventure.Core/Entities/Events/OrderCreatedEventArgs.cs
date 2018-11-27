using System;
using System.Collections.Generic;
using System.Text;

namespace UWAdventure.Events
{
    /// <summary>
    /// EventArgs when an order is created
    /// </summary>
    public class OrderCreatedEventArgs : EventArgs
    {
        public int OrderNumber { get; set; }
    }
}
