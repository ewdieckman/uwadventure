using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWAdventure.Entities.ViewModels;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace UWAdventure.Data
{
    /// <summary>
    /// Data access object for stores
    /// </summary>
    public class StoreDAO
    {
        /// <summary>
        /// Returns view models of all the stores in UWAdventure
        /// </summary>
        /// <returns></returns>
        public IList<StoreViewModel> GetAllStores()
        {
            IList<StoreViewModel> stores;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString))
            {
                connection.Open();

                string sql = @"SELECT [store_id] AS StoreID
                                  ,[store_name] AS [Name]
                                  ,[phone] AS Phone
                                  ,[email] AS Email
                                  ,[street] AS Street
                                  ,[city] AS City
                                  ,[state] AS State
                                  ,[zip_code] AS ZipCode
                              FROM [sales].[stores] ORDER BY store_name;";
                stores = connection.Query<StoreViewModel>(sql)
                    .ToList();

            }

            return stores;
        }
    }
}
