using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using UWAdventure.Entities.Persistence;
using System.Data.SqlClient;
using UWAdventure.BLL;
using UWAdventure.Entities.DTO;
using UWAdventure.Entities.ViewModels;

namespace UWAdventure.ConsoleApp
{
    class Program
    {
        private static OrderSummaryViewer _orderSummaryViewer;
        private static StoreViewer _storeViewer;
        private static StaffViewer _staffViewer;
        private static ProductViewer _productViewer;
        private static CustomerViewer _customerViewer;

        private static NewOrderCreator _newOrderCreator;

        static void Main(string[] args)
        {

            string menu_return;
            do
            {
                menu_return = MainMenu();
            } while (menu_return != "9");

        }


        /// <summary>
        /// Main menu UI
        /// </summary>
        public static string MainMenu()
        {
            WriteHeader();
            Console.WriteLine("MAIN MENU:");
            Console.WriteLine();
            Console.WriteLine("1. Create Order");
            Console.WriteLine("2. Order Summary");
            Console.WriteLine("");
            Console.WriteLine("9. Exit POS");

            CommandPrompt("Enter menu option");
            string selection = Console.ReadLine();

            if (selection == "1")
            {
                CreateOrderForm();
            }
            else if (selection == "2")
            {
                string menu_return;
                do
                {
                    menu_return = OrderSummaryMenu();
                } while (menu_return != "9");
            }
            else if (selection != "9")
            {
                Console.WriteLine("Invalid entry.");
                Console.WriteLine("Press any key....");
                Console.ReadKey();
            }

            return selection;

        }

        /// <summary>
        /// Runs the order form in the UI
        /// </summary>
        private static void CreateOrderForm()
        {
            int store_id, staff_id, product_id, customer_id, quantity;

            if (_storeViewer == null)
                _storeViewer = new StoreViewer();
            if (_staffViewer == null)
                _staffViewer = new StaffViewer();
            if (_productViewer == null)
                _productViewer = new ProductViewer();
            if (_customerViewer == null)
                _customerViewer = new CustomerViewer();
            if (_newOrderCreator == null)
                _newOrderCreator = new NewOrderCreator();

            IList<StaffViewModel> staff;
            IList<StoreViewModel> stores = _storeViewer.GetAllStores();
            IList<CustomerViewModel> customers = _customerViewer.GetRandom10();
            IList<ProductViewModel> products = _productViewer.GetRandom10();

            WriteHeader();
            WriteOrderFormHeader();

            Console.WriteLine("Select store:");
            Console.WriteLine("---------------");
            for (var i = 0;i<stores.Count;i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, stores[i].Name);
            }

            CommandPrompt("Select store");
            string str_store_id = Console.ReadLine();

            //validate the incoming store_id
            if (!Int32.TryParse(str_store_id, out store_id) || store_id > stores.Count || store_id < 1)
            {
                Console.WriteLine("Invalid store entry.  Press any key...");
                Console.ReadKey();
                return;
            }

            //store_id is valid - grab employees
            staff = _staffViewer.GetAllEmployesByStore(store_id);

            //write the employee info onscreen
            WriteHeader();
            WriteOrderFormHeader();

            Console.WriteLine("Select salesperson:");
            Console.WriteLine("--------------------");
            for (var i = 0; i < staff.Count; i++)
            {
                Console.WriteLine("{0}. {1} {2}", i + 1, staff[i].FirstName, staff[i].LastName);
            }
            CommandPrompt("Select salesperson");
            string str_staff_id = Console.ReadLine();

            //validate the incoming staff_id
            if (!Int32.TryParse(str_staff_id, out staff_id) || staff_id > staff.Count || staff_id < 1)
            {
                Console.WriteLine("Invalid salesperson entry.  Press any key...");
                Console.ReadKey();
                return;
            }

            //staff_id is valid - print out customers
            WriteHeader();
            WriteOrderFormHeader();
            Console.WriteLine("Select customer:");
            Console.WriteLine("--------------------");
            for (var i = 0; i < customers.Count; i++)
            {
                Console.WriteLine("{0}. {1} {2}", i + 1, customers[i].FirstName, customers[i].LastName);
            }
            CommandPrompt("Select customer");
            string str_customer_id = Console.ReadLine();

            //validate the incoming customer_id
            if (!Int32.TryParse(str_customer_id, out customer_id) || customer_id > customers.Count || customer_id < 1)
            {
                Console.WriteLine("Invalid customer entry.  Press any key...");
                Console.ReadKey();
                return;
            }


            //customer_id is valid - print out products
            WriteHeader();
            WriteOrderFormHeader();
            Console.WriteLine("Select product:");
            Console.WriteLine("--------------------");
            for (var i = 0; i < products.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, products[i].Name);
            }
            CommandPrompt("Select product");
            string str_product_id = Console.ReadLine();

            //validate the incoming product_id
            if (!Int32.TryParse(str_product_id, out product_id) || product_id > products.Count || product_id < 1)
            {
                Console.WriteLine("Invalid product entry.  Press any key...");
                Console.ReadKey();
                return;
            }

            //product_id is valid - print out quantity
            WriteHeader();
            WriteOrderFormHeader();
            Console.WriteLine("Select quantity:");
            string str_quantity = Console.ReadLine();

            //validate the incoming product_id
            if (!Int32.TryParse(str_quantity, out quantity) || quantity < 1)
            {
                Console.WriteLine("Invalid quantity.  Press any key...");
                Console.ReadKey();
                return;
            }

            //all inputs valid - show an order summary screen
            WriteHeader();
            WriteOrderFormHeader();
            Console.WriteLine("Order Details:");
            Console.WriteLine("----------------");
            Console.WriteLine("Entered by {0} {1} at {2}", staff[staff_id - 1].FirstName, staff[staff_id - 1].LastName, stores[store_id - 1].Name);
            Console.WriteLine("Order for {0} {1}", customers[customer_id - 1].FirstName, customers[customer_id - 1].LastName);
            Console.WriteLine(products[product_id - 1].Name);
            Console.WriteLine("Qty: {0}", quantity);
            CommandPrompt("Is this correct? (Y/N)");
            string str_response = Console.ReadLine();

            if (str_response.ToLower() == "y")
            {
                NewOrderDTO newOrder = new NewOrderDTO() {
                    store_id = store_id,
                    staff_id = staff_id,
                    customer_id = customer_id,
                    order_date = DateTime.Now,
                };

                NewOrderItemDTO newItem = new NewOrderItemDTO()
                {
                    product_id = product_id,
                    quantity = quantity
                };

                newOrder.items.Add(newItem);

                _newOrderCreator = new NewOrderCreator();
                try
                {
                    int order_number = _newOrderCreator.CreateOrder(newOrder);
                    WriteHeader();
                    WriteOrderFormHeader();
                    Console.WriteLine("Order #{0} created successfully.", order_number);
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return;
            }
            
        }

        /// <summary>
        /// Writes the order form header to the UI
        /// </summary>
        private static void WriteOrderFormHeader()
        {
            Console.WriteLine();
            Console.WriteLine("Create New Order");
            Console.WriteLine("#######################");
            Console.WriteLine();
            Console.WriteLine();

        }
        /// <summary>
        /// Order summary menu UI
        /// </summary>
        public static string OrderSummaryMenu()
        {
            WriteHeader();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine();
            Console.WriteLine("1. Run Order Summary");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("9. Return to the Main Menu");
            CommandPrompt("Enter menu option");
            string selection = Console.ReadLine();

            if (selection == "1")
            {
                RunOrderSummary();
            }
            else if (selection != "9")
            {
                Console.WriteLine("Invalid entry.");
                Console.WriteLine("Press any key....");
                Console.ReadKey();
                
            }

            return selection;
        }

        /// <summary>
        /// Runs the order summary
        /// </summary>
        private static void RunOrderSummary()
        {
            if (_orderSummaryViewer == null)
                _orderSummaryViewer = new OrderSummaryViewer();

            WriteHeader();

            Console.WriteLine("Enter start date in range:  (format M/D/YYYY)");
            string str_start_date = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter end date in range:  (format M/D/YYYY)");
            string str_end_date = Console.ReadLine();

            DateTime start_date, end_date;

            if (!DateTime.TryParse(str_start_date, out start_date) || !DateTime.TryParse(str_end_date, out end_date))
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Invalid date entries.  Press any key...");
                Console.ReadKey();
                return;
            }
            else
            {
                IList<StoreOrderSummaryViewModel> stats = _orderSummaryViewer.GetStoreOrderSummary(start_date, end_date);

                Console.Clear();
                Console.WriteLine("Order Summary from {0:M/d/yyyy} to {1:M/d/yyyy}", start_date, end_date);
                Console.WriteLine("###############################################################################################");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();


                Console.WriteLine("{0,-30} {1,9} {2,9} {3,9} {4,19}", "Store", "Orders", "Products", "Quantity", "Revenue");
                Console.WriteLine("================================================================================");
                foreach (StoreOrderSummaryViewModel stat in stats)
                {
                    PrintOutSummaryLine(stat);
                }

                Console.CursorTop = Console.WindowHeight - Console.CursorTop - 2;
                Console.WriteLine("Press any key....");
                Console.ReadKey();
            }

            
        }

        /// <summary>
        /// prints out a summary line 
        /// </summary>
        /// <param name="stat"></param>
        private static void PrintOutSummaryLine(StoreOrderSummaryViewModel stat)
        {
            // custom line formatting information is here:
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting

            Console.WriteLine("{0,-30} {1,9} {2,9} {3,9} {4,19:c}", 
                stat.StoreName, stat.NumberOfOrders, stat.NumberOfUniqueProducts, stat.NumberOfItems, stat.TotalRevenue);
        }

        /// <summary>
        /// Writes the command prompt
        /// </summary>
        private static void CommandPrompt(string prompt = "")
        {
            //put the cursor at the bottom of the screen
            Console.CursorTop = Console.WindowHeight - 5;
            Console.WriteLine(prompt == string.Empty ? "Enter command" : prompt + ":");
            Console.Write("# ");

        }

        /// <summary>
        /// Writes the UI header
        /// </summary>
        /// <remarks>Clears the screen as well</remarks>
        private static void WriteHeader()
        {
            Console.Clear();
            Console.WriteLine("#### UW Adventure POS ####");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void OtherStuff()
        {
            Console.WriteLine("Hello World!");


            string connection_string = ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString;

            // create an empty list that holds OrderDTO objects
            IList<OrderDTO> orders = new List<OrderDTO>();

            // using block automatically disposes the connection object so we don't have to close it explicitly.
            using (SqlConnection connection = new SqlConnection(connection_string))
            {

                connection.Open();

                SqlCommand command = connection.CreateCommand();

                command.CommandText = @"SELECT * 

                    FROM sales.orders

                    ORDER BY order_date;";

                // this executes the reader - preps the SQL Server, but hasn't pulled any actualy data yet.
                SqlDataReader rdr = command.ExecuteReader();

                // to make it easier to identify columns by their name rather than their index, we can grab 
                // their ordinal and store it in a variable for use later
                int ordinal_order_number = rdr.GetOrdinal("order_number");
                int ordinal_order_date = rdr.GetOrdinal("order_date");

                // declaring this entity for use later
                OrderDTO order;

                // if we enclose the datareader in a try/finally block, it helps us if there is an error during reading data, the finally will execute and 
                // be sure to close the reader
                try
                {
                    // every time the Read() method is executed, it tells the reader to collect another row of data from the database server
                    // it returns a boolean indicating whether they are still more rows of data available
                    while (rdr.Read())
                    {
                        // here we are hydrating our object with data from the server
                        // I only chose to populate 2 of the properties for brevity sake.   The rest would
                        // typically be populated in the same fashion
                        order = new OrderDTO();
                        order.order_date = rdr.GetDateTime(ordinal_order_date);
                        order.order_number = rdr.GetInt32(ordinal_order_number);

                        // add this to our list
                        orders.Add(order);
                    }
                }
                finally
                {
                    rdr.Close();
                }


            }

            // the database connection has been close, but we now have access to the data in the strongly-typed
            // object OrderDTO.   Technically, this is now residing in memory.
            foreach (OrderDTO dto in orders)
            {
                Console.WriteLine(dto.order_number);
            }

            Console.WriteLine("Hit any key to close this windows...");
            Console.ReadKey();


        }
    }
}
