﻿using System.Configuration;
using System.Data.SqlClient;
using UWAdventure.Entities.Persistence;
using Dapper;
using UWAdventure.Entities.DTO;
using UWAdventure.Entities.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;
using UWAdventure.Enum;

namespace UWAdventure.Data
{
    /// <summary>
    /// Data access object for orders 
    /// </summary>
    public class OrderDAO
    {

        /// <summary>
        /// Creates a new order in the persistence store
        /// </summary>
        public int CreateOrder(OrderDTO orderDTO)
        {
            int order_number = -1;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString))
            {
                connection.Open();
                string sql = @"INSERT INTO [sales].[orders] (customer_id, order_status, order_date, shipped_date, store_id, staff_id) 
                                VALUES (@customer_id, @order_status, @order_date, @shipped_date, @store_id, @staff_id);

                                SELECT CONVERT(int, SCOPE_IDENTITY());";
                order_number = (int)connection.ExecuteScalar(sql, orderDTO);
            }

            return order_number;
        }


        /// <summary>
        /// Generates the SELECT and FROM portions of the Order with details query
        /// </summary>
        /// <returns></returns>
        private string GetOrderDetailsSQL()
        {
            return @"SELECT orders.order_number AS OrderNumber 
	                        ,orders.order_status AS [Status]
	                        ,orders.order_date AS OrderDate
	                        ,orders.shipped_date AS ShippedDate
	                        ,customers.customer_id AS CustomerID
	                        ,customers.first_name AS FirstName
	                        ,customers.last_name AS LastName
	                        ,customers.phone AS Phone
	                        ,customers.email AS Email
	                        ,customers.street AS Street
	                        ,customers.city AS City
	                        ,customers.[state] AS [State]
	                        ,customers.zip_code AS ZipCode
	                        ,staffs.staff_id AS StaffID
	                        ,staffs.first_name AS FirstName
	                        ,staffs.last_name AS LastName
	                        ,staffs.email AS Email
	                        ,staffs.phone AS Phone
	                        ,stores.store_id AS StoreID
	                        ,stores.store_name AS [Name]
	                        ,stores.phone AS Phone
	                        ,stores.email AS Email
	                        ,stores.street AS Street
	                        ,stores.city AS City
	                        ,stores.[state] AS [State]
	                        ,stores.zip_code AS ZipCode
	                        ,order_items.quantity AS Quantity
	                        ,order_items.price AS Price
	                        ,products.product_id AS ProductID
	                        ,products.list_price AS ListPrice
	                        ,products.model_year AS ModelYear
	                        ,brands.brand_name AS Brand
	                        ,cate.category_name AS Category
	                        ,products.product_name AS [Name]
                        FROM sales.orders as orders
	                        INNER JOIN
	                        sales.customers AS customers ON orders.customer_id = customers.customer_id
	                        INNER JOIN
	                        sales.staffs AS staffs ON orders.staff_id = staffs.staff_id
	                        INNER JOIN
	                        sales.stores AS stores ON orders.store_id = stores.store_id
	                        LEFT OUTER JOIN
	                        sales.order_items AS order_items ON orders.order_number = order_items.order_number
	                        INNER JOIN
	                        production.products AS products ON order_items.product_id = products.product_id
	                        INNER JOIN
	                        production.brands AS brands ON products.brand_id = brands.brand_id
	                        INNER JOIN
	                        production.categories AS cate ON products.category_id = cate.category_id

                            ";
        }

        /// <summary>
        /// performs the actual query and ORM for orders with details
        /// </summary>
        /// <param name="predicate">Predicate in T-SQL to filter and order an order with details query</param>
        private IList<OrderViewModel> QueryForOrderDetails(string predicate, object param)
        {
            IList<OrderViewModel> orders = null;

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString))
            {
                connection.Open();

                Dictionary<int, OrderViewModel> orderDict = new Dictionary<int, OrderViewModel>();

                //grab all the order information (except items)
                string sql = GetOrderDetailsSQL() + @"

                            WHERE " + predicate + ";";
                orders = connection.Query<OrderViewModel, CustomerViewModel, StaffViewModel, StoreViewModel, OrderItemViewModel, ProductViewModel, OrderViewModel>(
                    sql,
                    map: (ord, cust, staff, store, item, prod) =>
                    {
                        OrderViewModel orderEntry;

                        if (!orderDict.TryGetValue(ord.OrderNumber, out orderEntry))
                        {
                            orderEntry = ord;
                            orderEntry.Items = new List<OrderItemViewModel>();
                            orderDict.Add(orderEntry.OrderNumber, orderEntry);
                        }

                        item.Product = prod;
                        orderEntry.Items.Add(item);

                        orderEntry.Customer = cust;
                        orderEntry.EnteredOrder = staff;
                        orderEntry.Store = store;

                        return orderEntry;
                    },
                    splitOn: "CustomerID,StaffID,StoreID,Quantity, ProductID",
                    param: param
                    ).Distinct()
                    .AsList();

            }

            return orders;
        }

        /// <summary>
        /// returns full order details for a single order
        /// </summary>
        public OrderViewModel GetOrderDetails(int order_number)
        {
            IList<OrderViewModel> orders = QueryForOrderDetails("orders.order_number=@order_number", new { order_number });
            return orders.Count > 0 ? orders[0] : null;
        }


        /// <summary>
        /// return full order details for a batch of orders in a date range
        /// </summary>
        public IList<OrderViewModel> GetOrderDetails(DateTime start_date, DateTime end_date)
        {
            string where = " orders.order_date BETWEEN @start_date AND @end_date ORDER BY order_date DESC";

            return QueryForOrderDetails(where, new { start_date, end_date });
        }

        /// <summary>
        /// Persists a new status for an order
        /// </summary>
        public void SetOrderStatus(int order_number, OrderStatus order_status)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString))
            {
                connection.Open();
                string sql = @"UPDATE [sales].[orders] SET order_status = @order_status WHERE order_number=@order_number;";
                connection.Execute(sql, new { order_number, order_status });
            }

        }

        public IList<StoreOrderSummaryViewModel> GetStoreOrderSummary(DateTime start_date, DateTime end_date)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["uwadventure"].ConnectionString))
            {
                connection.Open();
                string sql = @"SELECT summary.count_orders AS NumberOfOrders
	                ,summary.count_products AS NumberOfUniqueProducts
	                ,summary.total_items AS NumberOfItems
	                ,summary.total_revenue AS TotalRevenue
	                ,stores.store_name AS StoreName FROM
	                (
		                SELECT 
			                orders.store_id
			                ,COUNT(DISTINCT orders.order_number) AS count_orders
			                ,COUNT(DISTINCT order_items.product_id) AS count_products
			                ,SUM(order_items.quantity) AS total_items
			                ,SUM(order_items.price) AS total_revenue
			                FROM sales.orders AS orders

			                INNER JOIN 
			                sales.order_items AS order_items ON orders.order_number = order_items.order_number

			                WHERE order_date BETWEEN @start_date AND @end_date

			                GROUP BY store_id
	                ) AS summary
	                INNER JOIN
	                sales.stores AS stores ON summary.store_id = stores.store_id
	                ORDER BY stores.store_name;";
                IList<StoreOrderSummaryViewModel> stats = connection.Query<StoreOrderSummaryViewModel>(sql, new { start_date, end_date }).AsList();

                return stats;
            }
        }
    }
}
