using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class CourseRepository
    {
        public static List<Course> _courses;
        private static CourseRepository Repository = new CourseRepository();
        public static CourseRepository Instance { get { return Repository; } }
        

        public CourseRepository()
        {
            _courses = new List<Course>
            {
                new Course
                {
                    Id = 1,
                    Name = "OOP",
                    Description = "OOP Description"
                },
                new Course
                {
                    Id = 2,
                    Name = "Data Structure",
                    Description = "Data Structure Description"
                },
                new Course
                {
                    Id = 3,
                    Name = "Database",
                    Description = "Database Description"
                },
                new Course
                {
                    Id = 4,
                    Name = "Programming",
                    Description = "Programming Description"
                },
                new Course
                {
                    Id = 5,
                    Name = "Network",
                    Description = "Network Description"
                },
            };
        }
        public Task<List<Course>> GetCoursesAsync()
        {
            return Task.FromResult(CourseDAL.GetCourses());
            //return Task.FromResult(_courses);
        }
        public Task<Course> GetCourseAsync(int id)
        {
            return Task.FromResult(CourseDAL.GetCourseById(id));
            //return Task.FromResult(_courses.Where(c => c.Id == id).FirstOrDefault());
        }
        //public Task<List<Student>> GetStudentsByCourseId(int courseId)
        //{
        //    return Task.FromResult(_courses.Where(c => c.Id == courseId).Select(c => c.Students).ToList());
        //}
        public Task<Course> CreateCourseAsync(Course course)
        {
            _courses.Add(course);
            return Task.FromResult(course);
        }
        public int GetMaxId()
        {
            return _courses.Max(c => c.Id);
        }

    }
}