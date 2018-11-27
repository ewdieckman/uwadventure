using System.Configuration;
using System.Data.SqlClient;
using UWAdventure.Entities.Persistence;
using Dapper;
using UWAdventure.Entities.DTO;

namespace UWAdventure.Data
{
    /// <summary>
    /// Data access object for orders 
    /// </summary>
    public class OrderDAO : IOrderDAO
    {

        /// <summary>
        /// Creates a new order in the persistence store
        /// </summary>
        public int CreateOrder(OrderDTO orderDTO)
        {
            int order_number = -1;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString))
            {
                connection.Open();
                string sql = @"INSERT INTO [sales].[orders] (customer_id, order_status, order_date, shipped_date, store_id, staff_id) 
                                VALUES (@customer_id, @order_status, @order_date, @shipped_date, @store_id, @staff_id);

                                SELECT CONVERT(int, SCOPE_IDENTITY());";
                order_number = (int)connection.ExecuteScalar(sql, orderDTO);
            }

            return order_number;
        }


    }
}
