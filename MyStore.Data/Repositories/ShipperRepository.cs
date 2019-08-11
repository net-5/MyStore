using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;

namespace MyStore.Data.Repositories
{
    public interface IShipperRepository
    {
        List<Shippers> GetAllShippers();

        List<Shippers> GetAllShippers(string name);

        Shippers GetShipperById(int id);
        Shippers Update(Shippers shipperToUpdate);

        Shippers AddShipper(Shippers addedShipper);
        bool IsUniqueCompanyName(string name);
    }

    public class ShipperRepository : IShipperRepository
    {
        private readonly StoreContext storeContext;

        public ShipperRepository(StoreContext store)
        {
            storeContext = store;
        }

        public List<Shippers> GetAllShippers()
        {
            return storeContext.Shippers.ToList();
        }

        public List<Shippers> GetAllShippers(string name)
        {
            return storeContext.Shippers
                .Where(x => x.Companyname == name)
                .ToList();
        }

        public Shippers GetShipperById(int id)
        {
            return storeContext.Shippers.Find(id);
        }

        public Shippers Update(Shippers shipperToUpdate)
        {
            var updatedEntity = storeContext.Shippers.Update(shipperToUpdate);

            storeContext.SaveChanges();

            return updatedEntity.Entity;

        }

        public Shippers AddShipper(Shippers addedShipper)
        {
            var createdEntity = storeContext.Shippers.Add(addedShipper);
            storeContext.SaveChanges();
            return createdEntity.Entity;
        }

        public bool IsUniqueCompanyName(string name)
        {
            var unique = storeContext.Shippers.FirstOrDefault(x => x.Companyname == name);

            if (unique == null)
            {
                return true;
            }
            return false;
        }

    }
}
