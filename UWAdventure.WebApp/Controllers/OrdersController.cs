using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UWAdventure.BLL;
using UWAdventure.Entities.DTO;
using UWAdventure.Entities.ViewModels;
using UWAdventure.WebApp.Models;

namespace UWAdventure.WebApp.Controllers
{
    [RoutePrefix("orders")]
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
            var order_number = order_creator.CreateOrder(dto);

            return RedirectToAction("AfterOrder", new { o = order_number });

        }

        public ActionResult AfterOrder(int o)
        {
            OrderDetailViewer order_viewer = new OrderDetailViewer();
            OrderViewModel order = order_viewer.GetOrderDetails(o);

            return View(order);
        }

        [Route("staff/recent/{days:int}")]
        public ActionResult RecentOrders(int days)
        {
            // calculate the date range
            DateTime end_date = DateTime.Now;
            DateTime start_date = end_date.AddDays(-1 * days);

            OrderDetailViewer order_viewer = new OrderDetailViewer();
            IList<OrderViewModel> orders = order_viewer.GetOrderDetails(start_date, end_date);

            var model = new RecentOrdersModel();
            model.Orders = orders;
            model.Days = days;
            model.StartDate = start_date;
            model.EndDate = end_date;

            return View(model);

        }

        [Route("staff/{order_number:int}")]
        public ActionResult StaffOrderDetail(int order_number)
        {
            OrderDetailViewer order_viewer = new OrderDetailViewer();
            OrderViewModel order = order_viewer.GetOrderDetails(order_number);

            return View(order);
        }
    }
}