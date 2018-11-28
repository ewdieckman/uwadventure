using System;
using System.Collections.Generic;
using System.Text;
using UWAdventure.Data;
using UWAdventure.Events;

namespace UWAdventure.BLL
{
    public class InventoryService
    {

        private readonly InventoryDAO _inventoryDAO;

        public InventoryService()
        {
            _inventoryDAO = new InventoryDAO();
        }


        /// <summary>
        /// Returns the inventory quantity for a particular product at a store
        /// </summary>
        public int InventoryAmount(int store_id, int product_id)
        {
            return _inventoryDAO.GetInventoryAmount(store_id, product_id);
        }

        /// <summary>
        /// Informs inventory service of products needed by a particular store
        /// </summary>
        /// <remarks>Stub method - doesn't function</remarks>
        public void ProductRequired(int store_id, int product_id, int quantity)
        {

            // in this method, business logic could be applied based on business rules to check inventory,
            // then contact a supplier to increase inventory

        }

    }
}
