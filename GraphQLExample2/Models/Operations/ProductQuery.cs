using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery()
        {
            Name = "ProductQuery";

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
        }
    }
}