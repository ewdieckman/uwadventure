using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UWAdventure.Entities.ViewModels;

namespace UWAdventure.WebApp.Models
{
    /// <summary>
    /// Model for receiving form data for new orders
    /// </summary>
    public class NewOrderModel
    {
        // form input values - populated in the view
        public int SelectedStore { get; set; }
        public int SalesAssociate { get; set; }
        public int Customer { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }

        // data for population of view's form fields
        public IList<CustomerViewModel> Customers { get; set; }
        public IList<ProductViewModel> Products { get; set; }
        public IList<StaffViewModel> Staff { get; set; }
        public StoreViewModel Store { get; set; }

    }
}