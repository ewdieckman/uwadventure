using System;
using System.Collections.Generic;
using System.Text;

namespace UWAdventure.Entities.DTO
{
    /// <summary>
    /// DTO for transferring new order information from presentation layer
    /// </summary>
    public class NewOrderDTO
    {
        public NewOrderDTO()
        {
            items = new List<NewOrderItemDTO>();
        }

        /// <summary>
        /// customer who made the order
        /// </summary>
        public int customer_id { get; set; }

        public DateTime order_date { get; set; }

        /// <summary>
        /// Store where the sale happened
        /// </summary>
        public int store_id { get; set; }

        /// <summary>
        /// Staff who created the order
        /// </summary>
        public int staff_id { get; set; }

        public IList<NewOrderItemDTO> items { get; set; }
    }
}
