using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class Order_DetailType : ObjectGraphType<Order_Detail>
    {
        public Order_DetailType()
        {
            Field(x => x.OrderID).Description("OrderID");
            Field(x => x.ProductID).Description("ProductID");
            Field(x => x.UnitPrice).Description("UnitPrice");
            Field(x => x.Quantity).Description("Quantity");
            Field(x => x.Discount).Description("Discount");

            Field<OrderType>(
                "Order",
                resolve: context => OrderRepository.Instance.GetOrderById(context.Source.OrderID).Result
                );
            Field<ProductType>(
                "Product",
                resolve: context => ProductRepository.Instance.GetProductById(context.Source.ProductID).Result
                );
        }
    }
}