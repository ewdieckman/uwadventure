using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWAdventure.Entities.ViewModels
{
    /// <summary>
    /// View model for showing order summary details by store
    /// </summary>
    public class StoreOrderSummaryViewModel
    {
        public string StoreName { get; set; }
        public int NumberOfOrders { get; set; }
        public int NumberOfUniqueProducts { get; set; }
        public int NumberOfItems { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
