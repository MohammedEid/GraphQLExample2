using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLDAL
{
    public class Student
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
        public int CourseId { set; get; }
    }
}