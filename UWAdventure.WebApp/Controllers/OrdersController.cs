using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return View();
        }

        public ActionResult CreateOrder(UWAdventure.WebApp.Models.NewOrderModel formdata)
        {
            
        }
    }
}