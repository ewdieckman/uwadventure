using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UWAdventure.BLL;
using UWAdventure.Entities.DTO;
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

        /// <summary>
        /// Action for actually creating a new order
        /// </summary>
        /// <remarks>Is executed from the NewOrder view</remarks>
        [HttpPost]
        public ActionResult CreateOrder(UWAdventure.WebApp.Models.NewOrderModel formdata)
        {
            NewOrderDTO dto = new NewOrderDTO();

            dto.customer_id = formdata.Customer;
            dto.store_id = formdata.SelectedStore;
            dto.order_date = DateTime.Now;
            dto.staff_id = formdata.SalesAssociate;

            NewOrderItemDTO item = new NewOrderItemDTO();
            item.product_id = formdata.Product;
            item.quantity = formdata.Quantity;

            dto.items.Add(item);

            NewOrderCreator order_creator = new NewOrderCreator();
            order_creator.CreateOrder(dto);

            return RedirectToAction("AfterOrder");

        }


    }
}