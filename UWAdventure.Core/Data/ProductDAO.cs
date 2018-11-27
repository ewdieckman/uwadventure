using System.Data.SqlClient;
using UWAdventure.Entities.Persistence;
using Dapper;
using System.Configuration;

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
    }
}
