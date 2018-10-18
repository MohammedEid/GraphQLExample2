using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;

namespace GraphQLExample2
{
    public class Order_DetailQuery : ObjectGraphType
    {
        public Order_DetailQuery()
        {
            Name = "Order_DetailQuery";

            Field<ListGraphType<Order_DetailType>>(
                "GetOrdersDetails", //Name
                "Get All Orders Details", //Description
                resolve: context => Order_DetailRepository.Instance.GetOrders_Details().Result
                );

            Field<ListGraphType<Order_DetailType>>(
                "GetOrdersDetailsByOrder", //Name
                "Get Order By Order Id", //Description
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "OrderId", Description = "Order Id", DefaultValue = 1 }
                    ),
                resolve: context => Order_DetailRepository.Instance.GetOrders_DetailsByOrder(context.GetArgument<int>("OrderId")).Result
                );

            Field<ListGraphType<Order_DetailType>>(
                "GetOrdersDetailsByProduct", //Name
                "Get Order By Product Id", //Description
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "ProductId", Description = "Product Id", DefaultValue = 1 }
                    ),
                resolve: context => Order_DetailRepository.Instance.GetOrders_DetailsByProduct(context.GetArgument<int>("ProductId")).Result
                );

            Field<Order_DetailType>(
                "GetOrdersDetailByOrderAndProduct", //Name
                "Get Orders Detail By Order And Product", //Description
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "OrderId", Description = "Order Id", DefaultValue = 1 },
                    new QueryArgument<IntGraphType> { Name = "ProductId", Description = "Product Id", DefaultValue = 1 }
                    ),
                resolve: context => Order_DetailRepository.Instance.GetOrders_DetailByOrderAndProduct(context.GetArgument<int>("OrderId"), context.GetArgument<int>("ProductId")).Result
                );
        }
    }
}