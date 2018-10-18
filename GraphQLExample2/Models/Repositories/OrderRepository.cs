using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class OrderRepository
    {
        private static OrderRepository Repository = new OrderRepository();
        public static OrderRepository Instance { get { return Repository; } }
        public Task<List<Order>> GetOrders()
        {
            return Task.FromResult(OrderDAL.GetOrders());
        }
        public Task<List<Order>> GetCustomerOrders(string CustomerId)
        {
            return Task.FromResult(OrderDAL.GetCustomerOrders(CustomerId));
        }
        public Task<Order> GetOrderById(int OrderId)
        {
            return Task.FromResult(OrderDAL.GetOrderById(OrderId));
        }
    }
}