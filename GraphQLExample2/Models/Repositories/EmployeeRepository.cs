using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class EmployeeRepository
    {
        private static EmployeeRepository Repository = new EmployeeRepository();
        public static EmployeeRepository Instance { get { return Repository; } }
        public Task<List<Employee>> GetEmployees()
        {
            return Task.FromResult(EmployeeDAL.GetEmployees());
        }
        public Task<Employee> GetEmployeeById(int EmployeeId)
        {
            return Task.FromResult(EmployeeDAL.GetEmployeeById(EmployeeId));
        }
    }
}