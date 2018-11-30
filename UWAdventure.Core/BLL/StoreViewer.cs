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
    /// Business class responsible
    /// </summary>
    public class StoreViewer
    {
        private readonly StoreDAO _storeDAO;

        public StoreViewer()
        {
            _storeDAO = new StoreDAO();
        }

        /// <summary>
        /// Returns view models of all the stores in UWAdventure
        /// </summary>
        public IList<StoreViewModel> GetAllStores()
        {
            return _storeDAO.GetAllStores();
        }
    }
}
