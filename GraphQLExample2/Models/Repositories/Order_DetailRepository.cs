using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class Order_DetailRepository
    {
        private static Order_DetailRepository Repository = new Order_DetailRepository();
        public static Order_DetailRepository Instance { get { return Repository; } }
        public Task<List<Order_Detail>> GetOrders_Details()
        {
            return Task.FromResult(Order_DetailDAL.GetOrders_Details());
        }
        public Task<List<Order_Detail>> GetOrders_DetailsByOrder(int OrderId)
        {
            return Task.FromResult(Order_DetailDAL.GetOrders_DetailsByOrder(OrderId));
        }
        public Task<List<Order_Detail>> GetOrders_DetailsByProduct(int ProductId)
        {
            return Task.FromResult(Order_DetailDAL.GetOrders_DetailsByProduct(ProductId));
        }
        public Task<Order_Detail> GetOrders_DetailByOrderAndProduct(int OrderId, int ProductId)
        {
            return Task.FromResult(Order_DetailDAL.GetOrders_DetailByOrderAndProduct(OrderId, ProductId));
        }
    }
}