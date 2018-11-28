using System;
using System.Collections.Generic;
using System.Text;

namespace UWAdventure.Entities.DTO
{
    /// <summary>
    /// DTO for transfering new order item information from the presentation layer
    /// </summary>
    public class NewOrderItemDTO
    {
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}
