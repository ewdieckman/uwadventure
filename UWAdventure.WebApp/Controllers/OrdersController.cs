using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UWAdventure.BLL;
using UWAdventure.WebApp.Models;

namespace UWAdventure.WebApp.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        // view for creating new orders
        public ActionResult NewOrder()
        {
            // need to eventually query our business layers to retrieve information to pre-populates parts of the form
            // create bll viewer objects used for populating data
            int StoreID = 1;  // Santa Cruz Store
            StaffViewer staffViewer = new StaffViewer();
            ProductViewer productViewer = new ProductViewer();
            CustomerViewer customerViewer = new CustomerViewer();
            StoreViewer storeViewer = new StoreViewer();

            NewOrderModel model = new NewOrderModel()
            {
                Staff = staffViewer.GetAllEmployesByStore(StoreID),
                Products = productViewer.GetRandom10(),
                Customers = customerViewer.GetRandom10(),
                Store = storeViewer.GetStore(StoreID)


            };

            return View(model);
        }

        public ActionResult CreateOrder(UWAdventure.WebApp.Models.NewOrderModel formdata)
        {
            throw new NotImplementedException();
        }
    }
}