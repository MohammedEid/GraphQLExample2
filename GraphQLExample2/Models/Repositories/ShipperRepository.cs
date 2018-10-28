using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GraphQLDAL;

namespace GraphQLExample2
{
    public class ShipperRepository
    {
        private static ShipperRepository Repository = new ShipperRepository();
        public static ShipperRepository Instance { get { return Repository; } }
        public Task<List<Shipper>> GetShippers()
        {
            return Task.FromResult(ShipperDAL.GetShippers());
        }
        public Task<Shipper> GetShipperById(int ShipperId)
        {
            return Task.FromResult(ShipperDAL.GetShipperById(ShipperId));
        }
    }
}