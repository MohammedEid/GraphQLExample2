using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class NorthwindQuery : ObjectGraphType
    {
        public NorthwindQuery()
        {
            Name = "NorthwindQuery";

            #region Order Queries

            Field<ListGraphType<OrderType>>(
                "GetOrders", //Name
                "Get All Orders", //Description
                resolve: context => OrderRepository.Instance.GetOrders().Result
                );

            Field<OrderType>(
                "GetOrderById", //Name
                "Get Order By Order Id", //Description
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "OrderId", Description = "Order Id", DefaultValue = 1 }
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

            #endregion

            #region Order Detail Queries

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

            #endregion

            #region Customer Queries

            Field<ListGraphType<CustomerType>>(
                "GetCustomers", //Name
                "Get All Customers", //Description
                resolve: context => CustomerRepository.Instance.GetCustomers().Result
                );

            Field<CustomerType>(
                "GetCustomerById", //Name
                "Get Customer By Customer Id", //Description
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "CustomerId", Description = "Customer Id", DefaultValue = 1 }
                    ),
                resolve: context => CustomerRepository.Instance.GetCustomerById(context.GetArgument<string>("CustomerId")).Result
                );

            Field<CustomerType>(
                "GetCustomersByOrder", //Name
                "Get Customer By Order Id", //Description
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "OrderId", Description = "Order Id", DefaultValue = 1 }
                    ),
                resolve: context => CustomerRepository.Instance.GetCustomersByOrder(context.GetArgument<int>("OrderId")).Result
                );

            #endregion

            #region Prdouct Queries

            Field<ListGraphType<ProductType>>(
                "GetProducts", //Name
                "Get All Products", //Description
                resolve: context => ProductRepository.Instance.GetProducts().Result
                );

            Field<ProductType>(
                "GetProductById", //Name
                "Get Product By Product Id", //Description
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "ProductId", Description = "Product Id", DefaultValue = 1 }
                    ),
                resolve: context => ProductRepository.Instance.GetProductById(context.GetArgument<int>("ProductId")).Result
                );

            #endregion

        }
    }
}