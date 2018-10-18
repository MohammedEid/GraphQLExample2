using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(x => x.CustomerID).Description("CustomerID");
            Field(x => x.CompanyName).Description("CompanyName");
            Field(x => x.ContactName).Description("ContactName");
            Field(x => x.ContactTitle).Description("ContactTitle");
            Field(x => x.Address).Description("Address");
            Field(x => x.City).Description("City");
            Field(x => x.Region).Description("Region");
            Field(x => x.PostalCode).Description("PostalCode");
            Field(x => x.Country).Description("Country");
            Field(x => x.Phone).Description("Phone");
            Field(x => x.Fax).Description("Fax");

            Field<ListGraphType<OrderType>>(
                "Orders",
                resolve: context => OrderRepository.Instance.GetCustomerOrders(context.Source.CustomerID).Result
                );
        }
    }
}