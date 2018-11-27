using System;
using System.Collections.Generic;
using System.Text;

namespace UWAdventure.Entities.Persistence
{
    /// <summary>
    /// DTO used for product being persisted
    /// </summary>
    public class ProductDTO
    {
        public static ProductDTO NOTFOUND = new ProductDTO
        {
            product_name = "NOT FOUND"
        };

        public int product_id { get; set; } = -1;
        public string product_name { get; set; } = "";
        public int brand_id { get; set; } = -1;
        public int category_id { get; set; } = -1;
        public short model_year { get; set; } = -1;
        public decimal list_price { get; set; } = -1;
    }
}
