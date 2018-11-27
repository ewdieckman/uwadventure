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

namespace UWAdventure.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();

            IList<NewOrderItemDTO> items = new List<NewOrderItemDTO>();
            items.Add(new NewOrderItemDTO() {
                product_id=242,
                quantity=2
            });
            orderService.CreateOrder(new NewOrderDTO() {
                customer_id = 3,
                store_id = 2,
                staff_id = 6,
                order_date = DateTime.Now,
                items = items
            });

            Console.WriteLine("Hit any key to close this windows...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Page 2");
            Console.SetCursorPosition(30, 40);
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            Console.WriteLine("Password = " + pass);
            Console.ReadKey();
        }

        public void OtherStuff()
        {
            Console.WriteLine("Hello World!");


            string connection_string = ConfigurationManager.ConnectionStrings["uwadventure-azure"].ConnectionString;

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
