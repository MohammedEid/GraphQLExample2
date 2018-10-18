using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(x => x.OrderID).Description("OrderID");
            Field(x => x.CustomerID).Description("CustomerID");
            Field(x => x.EmployeeID, nullable: true).Description("EmployeeID");
            Field(x => x.OrderDate, nullable: true).Description("OrderDate");
            Field(x => x.RequiredDate, nullable: true).Description("RequiredDate");
            Field(x => x.ShippedDate, nullable: true).Description("ShippedDate");
            Field(x => x.ShipVia, nullable: true).Description("ShipVia");
            Field(x => x.Freight, nullable: true).Description("Freight");
            Field(x => x.ShipName).Description("ShipName");
            Field(x => x.ShipAddress).Description("ShipAddress");
            Field(x => x.ShipCity).Description("ShipCity");
            Field(x => x.ShipRegion).Description("ShipRegion");
            Field(x => x.ShipPostalCode).Description("ShipPostalCode");
            Field(x => x.ShipCountry).Description("ShipCountry");

            Field<CustomerType>(
                "Customer",
                resolve: context => CustomerRepository.Instance.GetCustomerById(context.Source.CustomerID).Result
                );
            //public virtual Employee Employee { get; set; }
            //public virtual Shipper Shipper { get; set; }
            Field<ListGraphType<Order_DetailType>>(
                "Orders_Detail",
                resolve: context => Order_DetailRepository.Instance.GetOrders_DetailsByOrder(context.Source.OrderID).Result
                );
        }
    }
}