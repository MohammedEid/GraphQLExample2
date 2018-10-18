using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLDAL
{
    public static class CustomerDAL
    {
        private static Customer MapCustomerObject(DataRow orderDataRow)
        {
            Customer Customer = new Customer();
            Customer.CustomerID = orderDataRow["CustomerID"] != null ? orderDataRow["CustomerID"].ToString() : null;
            Customer.CompanyName = orderDataRow["CompanyName"] != null ? orderDataRow["CompanyName"].ToString() : null;
            Customer.ContactName = orderDataRow["ContactName"] != null ? orderDataRow["ContactName"].ToString() : null;
            Customer.ContactTitle = orderDataRow["ContactTitle"] != null ? orderDataRow["ContactTitle"].ToString() : null;
            Customer.Address = orderDataRow["Address"] != null ? orderDataRow["Address"].ToString() : null;
            Customer.City = orderDataRow["City"] != null ? orderDataRow["City"].ToString() : null;
            Customer.Region = orderDataRow["Region"] != null ? orderDataRow["Region"].ToString() : null;
            Customer.PostalCode = orderDataRow["PostalCode"] != null ? orderDataRow["PostalCode"].ToString() : null;
            Customer.Country = orderDataRow["Country"] != null ? orderDataRow["Country"].ToString() : null;
            Customer.Phone = orderDataRow["Phone"] != null ? orderDataRow["Phone"].ToString() : null;
            Customer.Fax = orderDataRow["Fax"] != null ? orderDataRow["Fax"].ToString() : null;

            return Customer;
        }
        public static List<Customer> GetCustomers()
        {
            DataSet dsCustomers = SQLHelper.ExecuteDataset("dbo.GetCustomers", null);
            List<Customer> Customers = new List<Customer>();
            if (dsCustomers.Tables[0].Rows.Count > 0)
            {
                Customer Customer = new Customer();
                for (int i = 0; i < dsCustomers.Tables[0].Rows.Count; i++)
                {
                    Customer = MapCustomerObject(dsCustomers.Tables[0].Rows[i]);
                    Customers.Add(Customer);
                }
            }
            return Customers;
        }
        public static Customer GetCustomersByOrder(int OrderId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@OrderId", OrderId);
            DataSet dsCustomer = SQLHelper.ExecuteDataset("dbo.GetCustomersByOrderId", Parameters);
            Customer Customer = new Customer();
            if (dsCustomer.Tables[0].Rows.Count > 0)
            {
                Customer = MapCustomerObject(dsCustomer.Tables[0].Rows[0]);
            }
            return Customer;
        }
        public static Customer GetCustomerById(string CustomerId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@CustomerId", CustomerId);
            DataSet dsCustomer = SQLHelper.ExecuteDataset("dbo.GetCustomerById", Parameters);
            Customer Customer = new Customer();
            if (dsCustomer.Tables[0].Rows.Count > 0)
            {
                Customer = MapCustomerObject(dsCustomer.Tables[0].Rows[0]);
            }
            return Customer;
        }
    }
}
