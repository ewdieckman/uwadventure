using System.Data.SqlClient;
using UWAdventure.Entities.Persistence;
using Dapper;
using System.Configuration;
using UWAdventure.Entities.ViewModels;
using System.Collections.Generic;

namespace UWAdventure.Data
{
    /// <summary>
    /// Data access object for products
    /// </summary>
    public class ProductDAO
    {

        public ProductDAO()
        {

        }

        public ProductDTO GetByID(int product_id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT * FROM [production].[products] WHERE product_id=@product_id;";
                ProductDTO product = connection.QuerySingleOrDefault<ProductDTO>(sql, new { product_id });
                if (product == null)
                {
                    //returning the static NOT FOUND object for ProductDTO.  Easy to compare, plus more obvious what is means:
                    // if (myproduct = ProductDTO.NOTFOUND)  compared to  if (myproduct == null) - the former is clearer as to what is happening
                    return ProductDTO.NOTFOUND;
                }
                return product;
            }
        }

        /// <summary>
        /// Returns 10 random products
        /// </summary>
        public IList<ProductViewModel> GetRandom10()
        {
            IList<ProductViewModel> products;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT * FROM 
                            (SELECT TOP 10000000 products.product_id AS ProductID
	                        ,products.list_price AS ListPrice
	                        ,products.model_year AS ModelYear
	                        ,brands.brand_name AS Brand
	                        ,cate.category_name AS Category
	                        ,products.product_name AS [Name]
                            ,ROW_NUMBER() OVER (ORDER BY NEWID()) AS row_num

                            FROM [production].[products]
                            
                            INNER JOIN
	                        production.brands AS brands ON products.brand_id = brands.brand_id
	                        
                            INNER JOIN
	                        production.categories AS cate ON products.category_id = cate.category_id

                            ORDER BY newid()
                            ) AS randomly_sorted_products WHERE row_num < 11 ORDER BY Name ;";
                products = connection.Query<ProductViewModel>(sql)
                    .AsList();
                return products;
            }
        }
    }
}
