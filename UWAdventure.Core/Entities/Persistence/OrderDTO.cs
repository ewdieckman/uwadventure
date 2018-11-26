using System;
using UWAdventure.Enum;

namespace UWAdventure.Entities.Persistence
{
    /// <summary>
    /// DTO used for orders being persisted
    /// </summary>
    public class OrderDTO
    {

        public static OrderDTO NOTFOUND = new OrderDTO
        {
            order_status = (int)OrderStatus.Rejected,
            order_date = DateTime.MinValue,
            order_number = -1,
            customer_id = -1,
            staff_id = -1,
            store_id = -1

        };

        public int customer_id { get; set; }
        public int staff_id { get; set; }
        public int order_status { get; set; }
        public DateTime order_date { get; set; }
        public DateTime? shipped_date { get; set; }
        public int store_id { get; set; }
        public int order_number { get; set; } = -1;

        
        //implementing a VERY rudimentary Equals method.  Only taking into account the order number
        //should PROBABLY include all fields.  Saving time by just comparing order number
        public override bool Equals(object obj)
        {
            var item = obj as OrderDTO;

            if (item == null)
            {
                return false;
            }

            return this.order_number.Equals(item.order_number);
        }

        public override int GetHashCode()
        {
            return this.order_number.GetHashCode();
        }
    }
}
