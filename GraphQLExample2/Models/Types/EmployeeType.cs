using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            //ScalarGraphType scalarGraphType = new ScalarGraphType();
            
            Field(x => x.EmployeeID).Description("Employee ID");
            Field(x => x.LastName).Description("Last Name");
            Field(x => x.FirstName).Description("First Name");
            Field(x => x.Title).Description("Title");
            Field(x => x.TitleOfCourtesy).Description("Title Of Courtesy");
            Field(x => x.BirthDate, nullable: true).Description("BirthDate");
            Field(x => x.HireDate, nullable: true).Description("BirthDate");
            Field(x => x.Address).Description("Address");
            Field(x => x.City).Description("City");
            Field(x => x.Region).Description("Region");
            Field(x => x.PostalCode).Description("PostalCode");
            Field(x => x.Country).Description("Country");
            Field(x => x.HomePhone).Description("HomePhone");
            Field(x => x.Extension).Description("Extension");
            //Field(x => x.Photo);
            //Field(x => x.Photo, typeof(ByteGraphType)).Description("Photo");
            Field(x => x.Notes).Description("Notes");
            Field(x => x.ReportsTo, nullable: true).Description("ReportsTo");
            Field(x => x.PhotoPath).Description("PhotoPath");
            //Field<ListGraphType<ByteGraphType>>("Photo", resolve: x => x.Source.Photo);
            //Field<ListGraphType<StringGraphType>>("Photo", "Photo Description");
            //Field("createdAt", CustomerType, resolve = _.value.createdAt)
            //Field<ListGraphType<GraphQLObjectType>>("Photo")
        }
    }
}