using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLDAL
{
    public static class Order_DetailDAL
    {
        private static Order_Detail MapOrder_DetailObject(DataRow Order_DetailDataRow)
        {
            Order_Detail Order_Detail = new Order_Detail();
            Order_Detail.OrderID = Order_DetailDataRow["OrderID"] != null ? Int32.Parse(Order_DetailDataRow["OrderID"].ToString()) : 0;
            Order_Detail.ProductID = Order_DetailDataRow["ProductID"] != null ? Int32.Parse(Order_DetailDataRow["ProductID"].ToString()) : 0;
            Order_Detail.UnitPrice = Order_DetailDataRow["UnitPrice"] != null ? Decimal.Parse(Order_DetailDataRow["UnitPrice"].ToString()) : 0;
            Order_Detail.Quantity = Order_DetailDataRow["Quantity"] != null ? int.Parse(Order_DetailDataRow["Quantity"].ToString()) : 0;
            Order_Detail.Discount = Order_DetailDataRow["Discount"] != null ? float.Parse(Order_DetailDataRow["Discount"].ToString()) : 0;

            return Order_Detail;
        }
        public static List<Order_Detail> GetOrders_Details()
        {
            DataSet dsOrders_Details = SQLHelper.ExecuteDataset("dbo.GetOrders_Details", null);
            List<Order_Detail> Orders_Details = new List<Order_Detail>();
            if (dsOrders_Details.Tables[0].Rows.Count > 0)
            {
                Order_Detail Order_Detail = new Order_Detail();
                for (int i = 0; i < dsOrders_Details.Tables[0].Rows.Count; i++)
                {
                    Order_Detail = MapOrder_DetailObject(dsOrders_Details.Tables[0].Rows[i]);
                    Orders_Details.Add(Order_Detail);
                }
            }
            return Orders_Details;
        }
        public static List<Order_Detail> GetOrders_DetailsByOrder(int OrderId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@OrderId", OrderId);
            DataSet dsOrders_Details = SQLHelper.ExecuteDataset("dbo.GetOrders_DetailByOrderId", Parameters);
            List<Order_Detail> Orders_Details = new List<Order_Detail>();
            if (dsOrders_Details.Tables[0].Rows.Count > 0)
            {
                Order_Detail Order_Detail = new Order_Detail();
                for (int i = 0; i < dsOrders_Details.Tables[0].Rows.Count; i++)
                {
                    Order_Detail = MapOrder_DetailObject(dsOrders_Details.Tables[0].Rows[i]);
                    Orders_Details.Add(Order_Detail);
                }
            }
            return Orders_Details;
        }
        public static List<Order_Detail> GetOrders_DetailsByProduct(int ProductId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@ProductId", ProductId);
            DataSet dsOrders_Details = SQLHelper.ExecuteDataset("dbo.GetOrder_DetailByProductId", Parameters);
            List<Order_Detail> Orders_Details = new List<Order_Detail>();
            if (dsOrders_Details.Tables[0].Rows.Count > 0)
            {
                Order_Detail Order_Detail = new Order_Detail();
                for (int i = 0; i < dsOrders_Details.Tables[0].Rows.Count; i++)
                {
                    Order_Detail = MapOrder_DetailObject(dsOrders_Details.Tables[0].Rows[i]);
                    Orders_Details.Add(Order_Detail);
                }
            }
            return Orders_Details;
        }
        public static Order_Detail GetOrders_DetailByOrderAndProduct(int OrderId, int ProductId)
        {
            SqlParameter[] Parameters = new SqlParameter[2];
            Parameters[0] = new SqlParameter("@OrderId", OrderId);
            Parameters[1] = new SqlParameter("@ProductId", ProductId);
            DataSet dsOrder_Detail = SQLHelper.ExecuteDataset("dbo.GetOrders_DetailByOrderAndProduct", Parameters);
            Order_Detail Order_Detail = new Order_Detail();
            if (dsOrder_Detail.Tables[0].Rows.Count > 0)
            {
                Order_Detail = MapOrder_DetailObject(dsOrder_Detail.Tables[0].Rows[0]);
            }
            return Order_Detail;
        }
    }
}
