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

        }
    }
}