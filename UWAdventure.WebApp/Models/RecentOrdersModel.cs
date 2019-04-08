using System;
using System.Collections.Generic;
using UWAdventure.Entities.ViewModels;

namespace UWAdventure.WebApp.Models
{
    public class RecentOrdersModel
    {
        public IList<OrderViewModel> Orders { get; set; }
        public int Days { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}