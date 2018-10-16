using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class CourseType : ObjectGraphType<Course>
    {
        public CourseType()
        {
            Field(x => x.Id).Description("Course Id");
            Field(x => x.Name).Description("Course Name");
            Field(x => x.Description).Description("Course Description");
            Field<ListGraphType<StudentType>>(
                "Students",
                resolve: context => StudentRepository.Instance.GetStudentsByCourseIdAsync(context.Source.Id).Result
                );
        }
    }
}