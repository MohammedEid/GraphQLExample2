using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLExample2
{
    public class StudentQuery : ObjectGraphType
    {
        public StudentQuery()
        {
            Name = "StudentQuery";

            Field<ListGraphType<StudentType>>(
                "GetStudents",
                "Get All Students",
                resolve: context => StudentRepository.Instance.GetStudentsAsync()
                );
            Field<StudentType>(
                "GetStudentById",
                "Get Specific Student",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "sId", Description = "Student Id", DefaultValue = 1 }),
                resolve: context => StudentRepository.Instance.GetStudentAsync(context.GetArgument<int>("sId"))
                );
            Field<ListGraphType<StudentType>>(
                "GetStudentsByCourseId",
                "Get Students By Course Id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "cId", Description = "Course Id", DefaultValue = 1 }),
                resolve: context => StudentRepository.Instance.GetStudentsByCourseIdAsync(context.GetArgument<int>("cId"))
                );
            Field<IntGraphType>(
                "GetStudentsCount",
                "Get Students Count",
                resolve: context => StudentRepository.Instance.GetStudentsCount()
                );
        }
    }
}