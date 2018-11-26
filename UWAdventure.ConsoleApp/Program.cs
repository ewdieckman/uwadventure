using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using UWAdventure.Data;
using UWAdventure.Entities.Persistence;

namespace UWAdventure.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //setup configuration to mimic ASP.NET configuration
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddScoped<IDbUWAdventure, DbUWAdventure>(
                    provider => new DbUWAdventure(
                        config
                    ))

                //register DAO objects

                //register business services


                .BuildServiceProvider();

            Console.WriteLine("Hello World!");

            // IDbUWAdventure is located in UW.Adventure.Core.Data.DbConnection
            // it is a little helper class that I use to programmatically grab the database connection string
            // from appsettings.json.  This is handled automatically in ASP.NET Core
            IDbUWAdventure objDB = serviceProvider.GetService<IDbUWAdventure>();

            string connection_string = objDB.GetConnectionString("uwadventure-azure");

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
