using System;
using System.Collections.Generic;
using System.Text;

namespace UWAdventure.Entities.Persistence
{
    public class OrderItemDTO
    {
        public int order_number { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
}
