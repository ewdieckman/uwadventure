using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWAdventure.Entities.ViewModels;
using Dapper;
namespace UWAdventure.Data
{
    /// <summary>
    /// Data access object for customers
    /// </summary>
    public class CustomerDAO
    {
        /// <summary>
        /// Returns 10 random products
        /// </summary>
        public IList<CustomerViewModel> GetRandom10()
        {
            IList<CustomerViewModel> customers;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT * FROM 

                            (SELECT customers.customer_id AS CustomerID
	                        ,customers.first_name AS FirstName
	                        ,customers.last_name AS LastName
	                        ,customers.phone AS Phone
	                        ,customers.email AS Email
	                        ,customers.street AS Street
	                        ,customers.city AS City
	                        ,customers.[state] AS [State]
	                        ,customers.zip_code AS ZipCode
                            ,ROW_NUMBER() OVER (ORDER BY NEWID()) AS row_num
                            FROM [sales].[customers]
                            
                            ) AS randomly_sorted_customers WHERE row_num < 11 ORDER BY LastName, FirstName;";
                customers = connection.Query<CustomerViewModel>(sql)
                    .AsList();
                return customers;
            }
        }
    }
}
