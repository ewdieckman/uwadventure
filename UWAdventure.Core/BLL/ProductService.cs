using System;
using System.Collections.Generic;
using System.Text;
using UWAdventure.Data;
using UWAdventure.Entities.Persistence;

namespace UWAdventure.BLL
{
    /// <summary>
    /// Business logic for dealing with product
    /// </summary>
    public class ProductService 
    {
        private readonly ProductDAO _productDAO;

        public ProductService()
        {
            _productDAO = new ProductDAO();
        }
        public ProductDTO GetByID(int product_id)
        {
            return _productDAO.GetByID(product_id);
        }



    }
}
