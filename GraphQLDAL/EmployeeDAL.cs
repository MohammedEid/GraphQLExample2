using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraphQLDAL
{
    public static class EmployeeDAL
    {
        private static Employee MapEmployeeObject(DataRow EmployeeDataRow)
        {
            Employee Employee = new Employee();
            Employee.EmployeeID = EmployeeDataRow["EmployeeID"] != null ? Int32.Parse(EmployeeDataRow["EmployeeID"].ToString()) : 0;
            Employee.LastName = EmployeeDataRow["LastName"] != null ? EmployeeDataRow["LastName"].ToString() : null;
            Employee.FirstName = EmployeeDataRow["FirstName"] != null ? EmployeeDataRow["FirstName"].ToString() : null;
            Employee.Title = EmployeeDataRow["Title"] != null ? EmployeeDataRow["Title"].ToString() : null;
            Employee.TitleOfCourtesy = EmployeeDataRow["TitleOfCourtesy"] != null ? EmployeeDataRow["TitleOfCourtesy"].ToString() : null;
            Employee.BirthDate = DateTime.TryParse(EmployeeDataRow["BirthDate"].ToString(), out DateTime BirthDate) == true ? (DateTime?)DateTime.Parse(EmployeeDataRow["BirthDate"].ToString()) : null;
            Employee.HireDate = DateTime.TryParse(EmployeeDataRow["HireDate"].ToString(), out DateTime HireDate) == true ? (DateTime?)DateTime.Parse(EmployeeDataRow["HireDate"].ToString()) : null;
            Employee.Address = EmployeeDataRow["Address"] != null ? EmployeeDataRow["Address"].ToString() : null;
            Employee.City = EmployeeDataRow["City"] != null ? EmployeeDataRow["City"].ToString() : null;
            Employee.Region = EmployeeDataRow["Region"] != null ? EmployeeDataRow["Region"].ToString() : null;
            Employee.PostalCode = EmployeeDataRow["PostalCode"] != null ? EmployeeDataRow["PostalCode"].ToString() : null;
            Employee.Country = EmployeeDataRow["Country"] != null ? EmployeeDataRow["Country"].ToString() : null;
            Employee.HomePhone = EmployeeDataRow["HomePhone"] != null ? EmployeeDataRow["HomePhone"].ToString() : null;
            Employee.Extension = EmployeeDataRow["Extension"] != null ? EmployeeDataRow["Extension"].ToString() : null;
            //Employee.Photo = EmployeeDataRow["Photo"] != null ? (List<string>)EmployeeDataRow["Photo"] : null;
            Employee.Notes = EmployeeDataRow["Notes"] != null ? EmployeeDataRow["Notes"].ToString() : null;
            Employee.ReportsTo = Int32.TryParse(EmployeeDataRow["ReportsTo"].ToString(), out int ReportsTo) == true ? Int32.Parse(EmployeeDataRow["ReportsTo"].ToString()) : 0;
            Employee.PhotoPath = EmployeeDataRow["PhotoPath"] != null ? EmployeeDataRow["PhotoPath"].ToString() : null;


            return Employee;
        }
        public static List<Employee> GetEmployees()
        {
            DataSet dsEmployees = SQLHelper.ExecuteDataset("dbo.GetEmployees", null);
            List<Employee> Employees = new List<Employee>();
            if (dsEmployees.Tables[0].Rows.Count > 0)
            {
                Employee Employee = new Employee();
                for (int i = 0; i < dsEmployees.Tables[0].Rows.Count; i++)
                {
                    Employee = MapEmployeeObject(dsEmployees.Tables[0].Rows[i]);
                    Employees.Add(Employee);
                }
            }
            return Employees;
        }
        public static Employee GetEmployeeById(int EmployeeId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSet dsEmployee = SQLHelper.ExecuteDataset("dbo.GetEmployeeById", Parameters);
            Employee Employee = new Employee();
            if (dsEmployee.Tables[0].Rows.Count > 0)
            {
                Employee = MapEmployeeObject(dsEmployee.Tables[0].Rows[0]);
            }
            return Employee;
        }
    }
}
