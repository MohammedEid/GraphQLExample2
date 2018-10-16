using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL.Types;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType()
        {
            Field(x => x.Id).Description("Student Id");
            Field(x => x.Name).Description("Student Name");
            Field(x => x.Age).Description("Student Age");
            Field<CourseType>(
                "Course",
                resolve: context => CourseRepository.Instance.GetCourseAsync(context.Source.CourseId).Result
                );
        }
    }
}