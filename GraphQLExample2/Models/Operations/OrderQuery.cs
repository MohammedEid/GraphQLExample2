using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;

namespace GraphQLExample2
{
    public class OrderQuery : ObjectGraphType
    {
        public OrderQuery()
        {
            Name = "OrderQuery";

            Field<ListGraphType<OrderType>>(
                "GetOrders", //Name
                "Get All Orders", //Description
                resolve: context => OrderRepository.Instance.GetOrders().Result
                );

            Field<OrderType>(
                "GetOrderById", //Name
                "Get Order By Order Id", //Description
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "OrderId", Description = "Order Id", DefaultValue = 10248 }
                    ),
                resolve: context => OrderRepository.Instance.GetOrderById(context.GetArgument<int>("OrderId")).Result
                );

            Field<ListGraphType<OrderType>>(
                "GetCustomerOrders", //Name
                "Get Order By Customer Id", //Description
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "CustomerId", Description = "Customer Id", DefaultValue = 1 }
                    ),
                resolve: context => OrderRepository.Instance.GetCustomerOrders(context.GetArgument<string>("CustomerId")).Result
                );
        }
    }
}