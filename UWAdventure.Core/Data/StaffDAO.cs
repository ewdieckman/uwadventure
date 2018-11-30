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
    /// Data access object for staff
    /// </summary>
    public class StaffDAO
    {
        /// <summary>
        /// Returns view models of all staff at a particular store
        /// </summary>
        /// <returns></returns>
        public IList<StaffViewModel> GetAllEmployees(int store_id)
        {
            IList<StaffViewModel> staff;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString))
            {
                connection.Open();

                string sql = @"SELECT staff_id AS StaffID
	                        ,first_name AS FirstName
	                        ,last_name AS LastName
	                        ,email AS Email
	                        ,phone AS Phone
                              FROM [sales].[staffs] 
                            WHERE store_id=@store_id        
                            ORDER BY LastName, FirstName;";
                staff = connection.Query<StaffViewModel>(sql, new { store_id })
                    .ToList();

            }

            return staff;
        }
    }
}
