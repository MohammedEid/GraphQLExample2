using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class ShipperType : ObjectGraphType<Shipper>
    {
        public ShipperType()
        {
            Field(x => x.ShipperID).Description("Shipper ID");
            Field(x => x.CompanyName).Description("Company Name");
            Field(x => x.Phone).Description("Phone");

            Field<ListGraphType<OrderType>>(
                "Orders",
                resolve: context => OrderRepository.Instance.GetShipperOrders(context.Source.ShipperID).Result
                );
        }
    }
}