using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class CustomerRepository
    {
        private static CustomerRepository Repository = new CustomerRepository();
        public static CustomerRepository Instance { get { return Repository; } }
        public Task<List<Customer>> GetCustomers()
        {
            return Task.FromResult(CustomerDAL.GetCustomers());
        }
        public Task<Customer> GetCustomerById(string CustomerId)
        {
            return Task.FromResult(CustomerDAL.GetCustomerById(CustomerId));
        }
        public Task<Customer> GetCustomersByOrder(int OrderId)
        {
            return Task.FromResult(CustomerDAL.GetCustomersByOrder(OrderId));
        }
    }
}