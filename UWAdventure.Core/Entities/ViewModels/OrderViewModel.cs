using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWAdventure.Enum;

namespace UWAdventure.Entities.ViewModels
{
    /// <summary>
    /// View model for orders
    /// </summary>
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Items = new List<OrderItemViewModel>();
        }

        public int OrderNumber { get; set; }
        public CustomerViewModel Customer { get; set; }
        public StaffViewModel EnteredOrder { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public StoreViewModel Store { get; set; }
        public IList<OrderItemViewModel> Items { get; set; }
    }
}
