using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLExample2
{
    public class SchoolSchema : Schema
    {
        public SchoolSchema() : base()
        {
            //Query = new CourseQuery();
            //Query = new StudentQuery();
            Query = new NorthwindQuery();
        }
    }
}