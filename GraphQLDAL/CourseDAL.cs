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
        private static Course MapCourseObject(DataRow courseDataRow)
        {
            Course course = new Course();            
            course.Id = courseDataRow["Id"] != null ? Int32.Parse(courseDataRow["Id"].ToString()) : 0;
            course.Name = courseDataRow["Name"] != null ? courseDataRow["Name"].ToString() : null;
            course.Description = courseDataRow["Description"] != null ? courseDataRow["Description"].ToString() : null;
            return course;
        }
        public static List<Course> GetCourses()
        {
            DataSet dsCourses = SQLHelper.ExecuteDataset("dbo.GetCourses", null);
            List<Course> courses = new List<Course>();
            if(dsCourses.Tables[0].Rows.Count > 0)
            {
                Course course = new Course();
                for (int i=0;i< dsCourses.Tables[0].Rows.Count;i++)
                {
                    course = MapCourseObject(dsCourses.Tables[0].Rows[i]);
                    courses.Add(course);
                }
            }
            return courses;
        }
        public static Course GetCourseById(int courseId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@courseId", courseId);
            DataSet dsCourse = SQLHelper.ExecuteDataset("dbo.GetCourseById", Parameters);
            Course course = new Course();
            if(dsCourse.Tables[0].Rows.Count > 0)
            {
                course = MapCourseObject(dsCourse.Tables[0].Rows[0]);
            }
            return course;
        }

    }
}
