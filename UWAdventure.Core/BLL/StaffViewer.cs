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
    /// Business class for handling viewing of staff view models
    /// </summary>
    public class StaffViewer
    {
        private readonly StaffDAO _staffDAO;

        public StaffViewer()
        {
            _staffDAO = new StaffDAO();
        }

        /// <summary>
        /// Returns view models of all staff at a particular store
        /// </summary>
        public IList<StaffViewModel> GetAllEmployesByStore(int store_id)
        {
            return _staffDAO.GetAllEmployees(store_id);
        }


    }
}
