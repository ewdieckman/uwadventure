using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UWAdventure.WebApp.Models
{
    /// <summary>
    /// Model for receiving form data for new orders
    /// </summary>
    public class NewOrderModel
    {
        public int Store { get; set; }
        public int SalesAssociate { get; set; }

    }
}