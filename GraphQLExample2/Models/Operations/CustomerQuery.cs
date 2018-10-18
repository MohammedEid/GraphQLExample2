using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;

namespace GraphQLExample2
{
    public class CustomerQuery : ObjectGraphType
    {
        public CustomerQuery()
        {
            Name = "CustomerQuery";

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
        }
    }
}