using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class OrdersVmType : ObjectGraphType<OrdersClassVm>
    {
        public OrdersVmType()
        {
            Field(x => x.OrdersCount).Description("Orders Count");
            Field<ListGraphType<OrderType>>("Orders", "Orders List");
        }
    }
}