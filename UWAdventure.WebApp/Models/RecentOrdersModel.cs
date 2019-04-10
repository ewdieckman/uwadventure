using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UWAdventure.Entities.ViewModels;

namespace UWAdventure.WebApp.Models
{
    /// <summary>
    /// Page view model for recent orders page
    /// </summary>
    public class RecentOrdersModel
    {
        public IList<OrderViewModel> Orders { get; set; }
        public int Days { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}