using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWAdventure.Entities.ViewModels
{
    /// <summary>
    /// View model for products
    /// </summary>
    public class ProductViewModel
    {
        public decimal ListPrice { get; set; }
        public string Name { get; set; }
        public int ProductID { get; set; }
        public short ModelYear { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

        public override string ToString()
        {
            if (Name == string.Empty)
                return base.ToString();
            else
                return Name;

        }
    }
}
