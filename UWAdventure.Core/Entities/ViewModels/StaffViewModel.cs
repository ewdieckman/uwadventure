using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWAdventure.Entities.ViewModels
{
    /// <summary>
    /// View model for staff
    /// </summary>
    public class StaffViewModel
    {
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            if (FirstName == String.Empty || LastName == String.Empty)
                return base.ToString();
            else
                return string.Format("{0}, {1}", LastName,FirstName);
        }
    }
}
