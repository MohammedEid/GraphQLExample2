using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class OrderInputType : InputObjectGraphType
    {
        public OrderInputType()
        {
            Name = "OrderInput";

            Field<IntGraphType>("OrderID");
            Field<NonNullGraphType<StringGraphType>>("CustomerID");
            Field<IntGraphType>("EmployeeID");
            Field<DateGraphType>("OrderDate");
            Field<DateGraphType>("RequiredDate");
            Field<DateGraphType>("ShippedDate");
            Field<IntGraphType>("ShipVia");
            Field<IntGraphType>("Freight");
            Field<NonNullGraphType<StringGraphType>>("ShipName");
            Field<NonNullGraphType<StringGraphType>>("ShipAddress");
            Field<NonNullGraphType<StringGraphType>>("ShipCity");
            Field<NonNullGraphType<StringGraphType>>("ShipRegion");
            Field<NonNullGraphType<StringGraphType>>("ShipPostalCode");
            Field<NonNullGraphType<StringGraphType>>("ShipCountry");

            Field<CustomerType>("Customer");
            Field<EmployeeType> ("Employee");
            Field<ShipperType>("Shipper");
            Field<Order_DetailType>("Order_Details");
        }
    }
}