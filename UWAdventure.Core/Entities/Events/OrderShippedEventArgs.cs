using System;
using System.Collections.Generic;
using System.Text;

namespace UWAdventure.Events
{
    /// <summary>
    /// EventArgs when an order is shipped
    /// </summary>
    public class OrderShippedEventArgs : EventArgs
    {
        public int OrderNumber { get; set; }
    }
}
