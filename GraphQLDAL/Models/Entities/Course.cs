using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLDAL
{
    public class Course
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public List<Student> Students { set; get; }
    }
}