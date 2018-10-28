using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLDAL
{
    public static class OrderDAL
    {
        private static Order MapOrderObject(DataRow orderDataRow)
        {
            Order order = new Order();
            order.OrderID = orderDataRow["OrderID"] != null ? Int32.Parse(orderDataRow["OrderID"].ToString()) : 0;
            order.CustomerID = orderDataRow["CustomerID"] != null ? orderDataRow["CustomerID"].ToString() : null;
            order.EmployeeID = orderDataRow["EmployeeID"] != null ? Int32.Parse(orderDataRow["EmployeeID"].ToString()) : 0;
            order.OrderDate = DateTime.TryParse(orderDataRow["OrderDate"].ToString(), out DateTime OrderDate) == true ? (DateTime?)DateTime.Parse(orderDataRow["OrderDate"].ToString()) : null;
            order.RequiredDate = DateTime.TryParse(orderDataRow["RequiredDate"].ToString(), out DateTime RequiredDate) == true ? (DateTime?)DateTime.Parse(orderDataRow["RequiredDate"].ToString()) : null;
            order.ShippedDate = DateTime.TryParse(orderDataRow["ShippedDate"].ToString(), out DateTime ShippedDate) == true ? (DateTime?)DateTime.Parse(orderDataRow["ShippedDate"].ToString()) : null;
            order.ShipVia = orderDataRow["ShipVia"] != null ? Int32.Parse(orderDataRow["ShipVia"].ToString()) : 0;
            order.Freight = orderDataRow["Freight"] != null ? decimal.Parse(orderDataRow["Freight"].ToString()) : (decimal?)0;
            order.ShipName = orderDataRow["ShipName"] != null ? orderDataRow["ShipName"].ToString() : null;
            order.ShipAddress = orderDataRow["ShipAddress"] != null ? orderDataRow["ShipAddress"].ToString() : null;
            order.ShipCity = orderDataRow["ShipCity"] != null ? orderDataRow["ShipCity"].ToString() : null;
            order.ShipRegion = orderDataRow["ShipRegion"] != null ? orderDataRow["ShipRegion"].ToString() : null;
            order.ShipPostalCode = orderDataRow["ShipPostalCode"] != null ? orderDataRow["ShipPostalCode"].ToString() : null;
            order.ShipCountry = orderDataRow["ShipCountry"] != null ? orderDataRow["ShipCountry"].ToString() : null;

            return order;
        }
        public static OrdersClassVm GetOrders()
        {
            OrdersClassVm ordersClassVm = new OrdersClassVm();
            DataSet dsOrders = SQLHelper.ExecuteDataset("dbo.GetOrders", null);
            List<Order> orders = new List<Order>();
            if (dsOrders.Tables[0].Rows.Count > 0)
            {
                Order order = new Order();
                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    order = MapOrderObject(dsOrders.Tables[0].Rows[i]);
                    orders.Add(order);
                }
            }
            ordersClassVm.Orders = orders;
            ordersClassVm.OrdersCount = Int32.Parse(dsOrders.Tables[1].Rows[0]["OrdersCount"].ToString());
            return ordersClassVm;
        }
        public static OrdersClassVm GetOrdersNew()
        {
            OrdersClassVm ordersClassVm = new OrdersClassVm();
            DataSet dsOrders = SQLHelper.ExecuteDataset("dbo.GetOrders", null);
            List<Order> orders = new List<Order>();
            if (dsOrders.Tables[0].Rows.Count > 0)
            {
                Order order = new Order();
                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    order = MapOrderObject(dsOrders.Tables[0].Rows[i]);
                    orders.Add(order);
                }
            }
            ordersClassVm.Orders = orders;
            ordersClassVm.OrdersCount = Int32.Parse(dsOrders.Tables[1].Rows[0]["OrdersCount"].ToString());
            return ordersClassVm;
        }
        public static List<Order> GetCustomerOrders(string CustomeId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@CustomeId", CustomeId);
            DataSet dsOrders = SQLHelper.ExecuteDataset("dbo.GetCustomerOrders", Parameters);
            List<Order> orders = new List<Order>();
            if (dsOrders.Tables[0].Rows.Count > 0)
            {
                Order order = new Order();
                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    order = MapOrderObject(dsOrders.Tables[0].Rows[i]);
                    orders.Add(order);
                }
            }
            return orders;
        }
        public static Order GetOrderById(int OrderId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@OrderId", OrderId);
            DataSet dsOrder = SQLHelper.ExecuteDataset("dbo.GetOrderById", Parameters);
            Order Order = new Order();
            if (dsOrder.Tables[0].Rows.Count > 0)
            {
                Order = MapOrderObject(dsOrder.Tables[0].Rows[0]);
            }
            return Order;
        }
        public static Order CreateOrder(Order order)
        {
            SqlParameter[] Parameters =
            {
                new SqlParameter("@CustomerID", order.CustomerID),
                new SqlParameter("@EmployeeID", order.EmployeeID),
                new SqlParameter("@OrderDate", order.OrderDate),
                new SqlParameter("@RequiredDate", order.RequiredDate),
                new SqlParameter("@ShippedDate", order.ShippedDate),
                new SqlParameter("@ShipVia", order.ShipVia),
                new SqlParameter("@Freight", order.Freight),
                new SqlParameter("@ShipName", order.ShipName),
                new SqlParameter("@ShipAddress", order.ShipAddress),
                new SqlParameter("@ShipCity", order.ShipCity),
                new SqlParameter("@ShipRegion", order.ShipRegion),
                new SqlParameter("@ShipPostalCode", order.ShipPostalCode),
                new SqlParameter("@ShipCountry", order.ShipCountry)
            };

            return GetOrderById(Convert.ToInt32(SQLHelper.ExecuteScalar(CommandType.StoredProcedure, "dbo.AddNewOrder", Parameters)));
        }
        public static Order EditOrder(Order order)
        {
            SqlParameter[] Parameters =
            {
                new SqlParameter("@OrderID", order.OrderID),
                new SqlParameter("@CustomerID", order.CustomerID),
                new SqlParameter("@EmployeeID", order.EmployeeID),
                new SqlParameter("@OrderDate", order.OrderDate),
                new SqlParameter("@RequiredDate", order.RequiredDate),
                new SqlParameter("@ShippedDate", order.ShippedDate),
                new SqlParameter("@ShipVia", order.ShipVia),
                new SqlParameter("@Freight", order.Freight),
                new SqlParameter("@ShipName", order.ShipName),
                new SqlParameter("@ShipAddress", order.ShipAddress),
                new SqlParameter("@ShipCity", order.ShipCity),
                new SqlParameter("@ShipRegion", order.ShipRegion),
                new SqlParameter("@ShipPostalCode", order.ShipPostalCode),
                new SqlParameter("@ShipCountry", order.ShipCountry)
            };

            return GetOrderById(Convert.ToInt32(SQLHelper.ExecuteScalar(CommandType.StoredProcedure, "dbo.EditOrder", Parameters)));
        }
        public static int DeleteOrder(int OrderID)
        {
            SqlParameter[] Parameters =
            {
                new SqlParameter("@OrderID", OrderID)
            };

            return Convert.ToInt32(SQLHelper.ExecuteScalar(CommandType.StoredProcedure, "dbo.DeleteOrder", Parameters));
        }
        public static List<Order> GetOrdersByEmployeeId(int EmployeeId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSet dsOrder = SQLHelper.ExecuteDataset("dbo.GetOrdersByEmployeeId", Parameters);
            List<Order> Orders = new List<Order>();
            Order Order = new Order();
            if (dsOrder.Tables[0].Rows.Count > 0)
            {
                for(int i=0;i< dsOrder.Tables[0].Rows.Count;i++)
                {
                    Order = new Order();
                    Order = MapOrderObject(dsOrder.Tables[0].Rows[0]);
                    Orders.Add(Order);
                }
            }
            return Orders;
        }
        public static List<Order> GetShipperOrders(int ShipperId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@ShipperID", ShipperId);
            DataSet dsOrders = SQLHelper.ExecuteDataset("dbo.GetOrdersByShipperID", Parameters);
            List<Order> orders = new List<Order>();
            if (dsOrders.Tables[0].Rows.Count > 0)
            {
                Order order = new Order();
                for (int i = 0; i < dsOrders.Tables[0].Rows.Count; i++)
                {
                    order = MapOrderObject(dsOrders.Tables[0].Rows[i]);
                    orders.Add(order);
                }
            }
            return orders;
        }
    }
}
