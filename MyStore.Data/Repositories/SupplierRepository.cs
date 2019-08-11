using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;

namespace MyStore.Data.Repositories
{
    public interface ISupplierRepository
    {
        List<Suppliers> GetAllSuppliers();

        List<Suppliers> GetAllSuppliers(string name, string postalCode);

        Suppliers GetSupplierById(int id);
        Suppliers Update(Suppliers supplierToUpdate);

        Suppliers AddSupplier(Suppliers addedSupplier);
        bool IsUniqueCompanyName(string name);
    }

    public class SupplierRepository : ISupplierRepository
    {
        private readonly StoreContext storeContext;

        public SupplierRepository(StoreContext store)
        {
            storeContext = store;
        }

        public List<Suppliers> GetAllSuppliers()
        {
            return storeContext.Suppliers.ToList();
        }

        public List<Suppliers> GetAllSuppliers(string name, string postalCode)
        {
            return storeContext.Suppliers
                .Where(x => x.Companyname == name && x.Postalcode == postalCode)
                .ToList();
        }

        public Suppliers GetSupplierById(int id)
        {
            return storeContext.Suppliers.Find(id);
        }

        public Suppliers Update(Suppliers supplierToUpdate)
        {
            var updatedEntity = storeContext.Suppliers.Update(supplierToUpdate);

            storeContext.SaveChanges();

            return updatedEntity.Entity;

        }

        public Suppliers AddSupplier(Suppliers addedSupplier)
        {
            var createdEntity = storeContext.Suppliers.Add(addedSupplier);
            storeContext.SaveChanges();
            return createdEntity.Entity;
        }

        public bool IsUniqueCompanyName(string name)
        {
            var unique = storeContext.Suppliers.Where(x => x.Companyname == name).FirstOrDefault();

            if (unique == null)
            {
                return true;
            }
            return false;
        }

    }
}
