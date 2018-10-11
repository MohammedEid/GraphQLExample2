using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GraphQLExample2
{
    public class StudentRepository
    {
        public static List<Student> _students;
        private static StudentRepository Repository = new StudentRepository();
        public static StudentRepository Instance { get { return Repository; } }
        public StudentRepository()
        {
            _students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Mohamed",
                    Age = 15,
                    CourseId = 1
                },
                new Student
                {
                    Id = 2,
                    Name = "Ahmed",
                    Age = 25,
                    CourseId = 1
                },
                new Student
                {
                    Id = 3,
                    Name = "Mahmoud",
                    Age = 35,
                    CourseId = 5
                },
                new Student
                {
                    Id = 4,
                    Name = "Mostafa",
                    Age = 45,
                    CourseId = 3
                },
                new Student
                {
                    Id = 5,
                    Name = "Amr",
                    Age = 55,
                    CourseId = 2
                }
            };
        }

        public Task<List<Student>> GetStudentsAsync()
        {
            return Task.FromResult(_students);
        }
        public Task<Student> GetStudentAsync(int id)
        {
            return Task.FromResult(_students.Where(s => s.Id == id).FirstOrDefault());
        }
        public Task<Student> CreateStudentAsync(Student student)
        {
            _students.Add(student);
            return Task.FromResult(student);
        }
        //public Task<Course> GetStudentCourse(int studentId)
        //{
        //    if (_students.Where(s => s.Id == studentId).FirstOrDefault() != null)
        //        return Task.FromResult(_students.Where(s => s.Id == studentId).FirstOrDefault().Course);
        //    else
        //        return null;
        //}
        public Task<List<Student>> GetStudentsByCourseIdAsync(int courseId)
        {
            return Task.FromResult(_students.Where(s => s.CourseId == courseId).ToList());
        }
        public int GetStudentsCount()
        {
            return _students.Count();
        }
    }
}