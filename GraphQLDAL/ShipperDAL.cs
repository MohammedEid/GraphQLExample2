using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLDAL
{
    public static class ShipperDAL
    {
        private static Shipper MapShipperObject(DataRow ShipperDataRow)
        {
            Shipper Shipper = new Shipper();
            Shipper.ShipperID = ShipperDataRow["ShipperID"] != null ? Int32.Parse(ShipperDataRow["ShipperID"].ToString()) : 0;
            Shipper.CompanyName = ShipperDataRow["CompanyName"] != null ? ShipperDataRow["CompanyName"].ToString() : null;
            Shipper.Phone = ShipperDataRow["Phone"] != null ? ShipperDataRow["Phone"].ToString() : null;

            return Shipper;
        }
        public static List<Shipper> GetShippers()
        {
            DataSet dsShippers = SQLHelper.ExecuteDataset("dbo.GetShippers", null);
            List<Shipper> Shippers = new List<Shipper>();
            if (dsShippers.Tables[0].Rows.Count > 0)
            {
                Shipper Shipper = new Shipper();
                for (int i = 0; i < dsShippers.Tables[0].Rows.Count; i++)
                {
                    Shipper = MapShipperObject(dsShippers.Tables[0].Rows[i]);
                    Shippers.Add(Shipper);
                }
            }
            return Shippers;
        }
        public static Shipper GetShipperById(int ShipperId)
        {
            SqlParameter[] Parameters = new SqlParameter[1];
            Parameters[0] = new SqlParameter("@ShipperId", ShipperId);
            DataSet dsShipper = SQLHelper.ExecuteDataset("dbo.GetShipperById", Parameters);
            Shipper Shipper = new Shipper();
            if (dsShipper.Tables[0].Rows.Count > 0)
            {
                Shipper = MapShipperObject(dsShipper.Tables[0].Rows[0]);
            }
            return Shipper;
        }
    }
}
