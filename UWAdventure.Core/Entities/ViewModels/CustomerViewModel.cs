﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWAdventure.Entities.ViewModels
{
    /// <summary>
    /// View model for a customer
    /// </summary>
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public override string ToString()
        {
            if (FirstName == string.Empty || LastName == string.Empty)
                return base.ToString();
            else
                return string.Format("{0}, {1}", LastName, FirstName);

        }
    }
}
