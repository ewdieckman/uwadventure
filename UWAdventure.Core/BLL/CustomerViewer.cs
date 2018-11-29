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
    /// Business class responsible viewing customer view models
    /// </summary>
    public class CustomerViewer
    {
        private readonly CustomerDAO _customerDAO;

        public CustomerViewer()
        {
            _customerDAO = new CustomerDAO();
        }

        /// <summary>
        /// Returns 10 random customers
        /// </summary>
        public IList<CustomerViewModel> GetRandom10()
        {
            return _customerDAO.GetRandom10();
        }
    }
}
