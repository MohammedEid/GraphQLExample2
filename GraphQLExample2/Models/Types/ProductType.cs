using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.ProductID).Description("ProductID");
            Field(x => x.ProductName).Description("ProductName");
            Field(x => x.SupplierID).Description("SupplierID");
            Field(x => x.CategoryID).Description("CategoryID");
            Field(x => x.QuantityPerUnit).Description("QuantityPerUnit");
            Field(x => x.UnitPrice).Description("UnitPrice");
            Field(x => x.UnitsInStock, nullable: true).Description("UnitsInStock");
            Field(x => x.UnitsOnOrder, nullable: true).Description("UnitsOnOrder");
            Field(x => x.ReorderLevel, nullable: true).Description("ReorderLevel");
            Field(x => x.Discontinued).Description("Discontinued");

            Field<ListGraphType<Order_DetailType>>(
                "Orders_Detail",
                resolve: context => Order_DetailRepository.Instance.GetOrders_DetailsByProduct(context.Source.ProductID).Result
                );
            //public virtual Category Category { get; set; }
            //public virtual Supplier Supplier { get; set; }
        }
    }
}