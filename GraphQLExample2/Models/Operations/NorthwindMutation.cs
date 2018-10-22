using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class NorthwindMutation : ObjectGraphType
    {
        public NorthwindMutation()
        {
            Name = "NorthwindMutation";

            Field<OrderType>(
                "CreateOrder",
                Description = "Create Order Description",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "orderParam", Description = "order parameter" }
                    ),
                resolve: context =>
                {
                    Order orderParam = context.GetArgument<Order>("orderParam");
                    return OrderRepository.Instance.CreateOrder(orderParam).Result;
                }
                );

            Field<OrderType>(
                "editorder",
                Description = "Edit Order Description",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "orderParam", Description = "order parameter" }
                    ),
                resolve: context =>
                {
                    Order orderParam = context.GetArgument<Order>("orderParam");
                    return OrderRepository.Instance.EditOrder(orderParam).Result;
                }
                );

            Field<IntGraphType>(
                "deleteorder",
                Description = "Delete Order Description",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "orderId", Description = "order id parameter" }
                    ),
                resolve: context =>
                {
                    return OrderRepository.Instance.DeleteOrder(context.GetArgument<int>("orderId")).Result;
                }
                );
        }
    }
}