using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLDAL
{
    public static class CourseDAL
    {
        public static List<Course> GetCourses()
        {
            DataSet dsCourses = SQLHelper.ExecuteDataset("dbo.GetCourses", null);
            List<Course> courses = new List<Course>();
            if(dsCourses.Tables[0].Rows.Count > 0)
            {
                Course course = new Course();
                for (int i=0;i< dsCourses.Tables[0].Rows.Count;i++)
                {
                    DataRow drCourse = dsCourses.Tables[0].Rows[i];
                    course = new Course();
                    course.Id = Int32.Parse(drCourse["Id"].ToString());
                    course.Name = drCourse["Name"].ToString();
                    course.Description = drCourse["Description"].ToString();
                    courses.Add(course);
                }
            }
            return courses;
        }
    }
}
