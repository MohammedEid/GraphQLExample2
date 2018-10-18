using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GraphQLDAL;

namespace GraphQLDAL
{
    public class ProductRepository
    {
        private static ProductRepository Repository = new ProductRepository();
        public static ProductRepository Instance { get { return Repository; } }
        public Task<List<Product>> GetProducts()
        {
            return Task.FromResult(ProductDAL.GetProducts());
        }
        public Task<Product> GetProductById(int ProductId)
        {
            return Task.FromResult(ProductDAL.GetProductById(ProductId));
        }
    }
}
