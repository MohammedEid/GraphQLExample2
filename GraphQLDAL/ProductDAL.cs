using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLDAL
{
    public static class ProductDAL
    {
        private static Product MapProductObject(DataRow ProductDataRow)
        {
            Product Product = new Product();
            Product.ProductID = ProductDataRow["ProductID"] != null ? Int32.Parse(ProductDataRow["ProductID"].ToString()) : 0;
            Product.ProductName = ProductDataRow["ProductName"] != null ? ProductDataRow["ProductName"].ToString() : null;
            Product.SupplierID = ProductDataRow["SupplierID"] != null ? Int32.Parse(ProductDataRow["SupplierID"].ToString()) : 0;
            Product.CategoryID = ProductDataRow["CategoryID"] != null ? Int32.Parse(ProductDataRow["CategoryID"].ToString()) : 0;
            Product.QuantityPerUnit = ProductDataRow["QuantityPerUnit"] != null ? ProductDataRow["QuantityPerUnit"].ToString() : null;
            Product.UnitPrice = ProductDataRow["UnitPrice"] != null ? decimal.Parse(ProductDataRow["UnitPrice"].ToString()) : (decimal)0;
            Product.UnitsInStock = ProductDataRow["UnitsInStock"] != null ? Int32.Parse(ProductDataRow["UnitsInStock"].ToString()) : 0;
            Product.UnitsOnOrder = ProductDataRow["UnitsOnOrder"] != null ? Int32.Parse(ProductDataRow["UnitsOnOrder"].ToString()) : 0;
            Product.ReorderLevel = ProductDataRow["ReorderLevel"] != null ? Int32.Parse(ProductDataRow["ReorderLevel"].ToString()) : 0;
            Product.Discontinued = ProductDataRow["Discontinued"] != null ? bool.Parse(ProductDataRow["Discontinued"].ToString()) : false;
            
            return Product;
        }
        public static List<Product> GetProducts()
        {
            DataSet dsProducts = SQLHelper.ExecuteDataset("dbo.GetProducts", null);
            List<Product> Products = new List<Product>();
            if (dsProducts.Tables[0].Rows.Count > 0)
            {
                Product Product = new Product();
                for (int i = 0; i < dsProducts.Tables[0].Rows.Count; i++)
                {
                    Product = MapProductObject(dsProducts.Tables[0].Rows[i]);
                    Products.Add(Product);
                }
            }
            return Products;
        }
        public static Product GetProductById(int ProductId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@ProductId", ProductId);
            DataSet dsProduct = SQLHelper.ExecuteDataset("dbo.GetProductById", Parameters);
            Product Product = new Product();
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                Product = MapProductObject(dsProduct.Tables[0].Rows[0]);
            }
            return Product;
        }
    }
}
