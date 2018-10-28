using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQLDAL;

namespace GraphQLDAL
{
    public class OrdersVm
    {
        public List<Order> Orders { get; set; }
        public int OrdersCount { get; set; }
    }
}
