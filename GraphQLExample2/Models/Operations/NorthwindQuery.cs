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

            Field<OrdersVmType>(
                "GetOrders", //Name
                "Get All Orders", //Get Orders and count in one database request
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

            Field<ListGraphType<OrderType>>(
                Name = "GetEmployeeOrders",
                Description = "Get Orders of sepcific Employee",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "EmployeeId", Description = "Employee ID" }
                    ),
                resolve: context => OrderRepository.Instance.GetOrdersByEmployeeId(context.GetArgument<int>("EmployeeId")).Result
                );

            Field<ListGraphType<OrderType>>(
                Name = "GetShipperOrders",
                Description = "Get Orders of sepcific Shipper",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "ShipperId", Description = "Shipper ID" }
                    ),
                resolve: context => OrderRepository.Instance.GetShipperOrders(context.GetArgument<int>("ShipperId")).Result
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

            #region Employee Queries

            Field<ListGraphType<EmployeeType>>(
                "GetEmployees", //Name
                "Get All Employees", //Description
                resolve: context => EmployeeRepository.Instance.GetEmployees().Result
                );

            Field<EmployeeType>(
                "GetEmployeeById", //Name
                "Get Employee By Employee Id", //Description
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "EmployeeId", Description = "Employee Id", DefaultValue = 1 }
                    ),
                resolve: context => EmployeeRepository.Instance.GetEmployeeById(context.GetArgument<int>("EmployeeId")).Result
                );

            #endregion

            #region Shipper Queries
            
            Field<ListGraphType<ShipperType>>(
                "GetShippers", //Name
                "Get All Shippers", //Description
                resolve: context => ShipperRepository.Instance.GetShippers().Result
                );

            Field<ShipperType>(
                "GetShipperById", //Name
                "Get Shipper By Shipper Id", //Description
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "ShipperId", Description = "Shipper Id", DefaultValue = 1 }
                    ),
                resolve: context => ShipperRepository.Instance.GetShipperById(context.GetArgument<int>("ShipperId")).Result
                );

            #endregion


        }
    }
}