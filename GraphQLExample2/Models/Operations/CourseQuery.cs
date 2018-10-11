using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLExample2
{
    public class CourseQuery : ObjectGraphType
    {
        public CourseQuery()
        {
            Name = "SchoolQuery";

            Field<ListGraphType<CourseType>>(
                "GetCourses", //Name
                "Get All Courses", //Description
                resolve: context => CourseRepository.Instance.GetCoursesAsync().Result
                );

            Field<CourseType>(
                "GetCourseById", //Name
                "Get Course By Course Id", //Description
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "myId", Description = "Course Id", DefaultValue = 1 }
                    ),
                resolve: context => CourseRepository.Instance.GetCourseAsync(context.GetArgument<int>("myId")).Result
                );

            Field<IntGraphType>(
                "GetMaxCourseId",
                "Get Max Course Id",
                resolve: context => CourseRepository.Instance.GetMaxId()
                );
        }
    }
}