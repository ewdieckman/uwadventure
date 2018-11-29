using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWAdventure.Data;
using UWAdventure.Entities.ViewModels;

namespace UWAdventure.BLL
{
    /// <summary>
    /// Business object used for viewing product view models
    /// </summary>
    public class ProductViewer
    {
        private readonly ProductDAO _productDAO;

        public ProductViewer()
        {
            _productDAO = new ProductDAO();
        }

        /// <summary>
        /// Returns 10 random products
        /// </summary>
        public IList<ProductViewModel> GetRandom10()
        {
            return _productDAO.GetRandom10();
        }
    }
}
