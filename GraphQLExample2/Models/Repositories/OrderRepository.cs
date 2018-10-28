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
        public Task<OrdersClassVm> GetOrders()
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

        public Task<Order> CreateOrder(Order order)
        {
            return Task.FromResult(OrderDAL.CreateOrder(order));
        }
        public Task<Order> EditOrder(Order order)
        {
            return Task.FromResult(OrderDAL.EditOrder(order));
        }
        public Task<int> DeleteOrder(int OrderID)
        {
            return Task.FromResult(OrderDAL.DeleteOrder(OrderID));
        }
        public Task<List<Order>> GetOrdersByEmployeeId(int EmployeeId)
        {
            return Task.FromResult(OrderDAL.GetOrdersByEmployeeId(EmployeeId));
        }
        public Task<List<Order>> GetShipperOrders(int ShipperId)
        {
            return Task.FromResult(OrderDAL.GetShipperOrders(ShipperId));
        }
    }
}