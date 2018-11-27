using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWAdventure.Entities.ViewModels
{
    /// <summary>
    /// View model for an order item
    /// </summary>
    public class OrderItemViewModel
    {
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
