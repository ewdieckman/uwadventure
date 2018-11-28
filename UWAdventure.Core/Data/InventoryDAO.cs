using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWAdventure.Data
{
    /// <summary>
    /// Data access object for inventory
    /// </summary>
    public class InventoryDAO
    {
        /// <summary>
        /// Queries the persistence store for the inventory quantity
        /// </summary>
        public int GetInventoryAmount(int store_id, int product_id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT quantity FROM production.inventory WHERE product_id=@product_id AND store_id=@store_id;";

                SqlCommand command = connection.CreateCommand();
                command.CommandText = sql;

                command.Parameters.Add(new SqlParameter("@product_id", SqlDbType.Int)).Value = product_id;
                command.Parameters.Add(new SqlParameter("@store_id", SqlDbType.Int)).Value = store_id;
                return (int)command.ExecuteScalar();
            }

        }
    }
}
