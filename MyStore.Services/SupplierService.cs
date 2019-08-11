using System;
using System.Collections.Generic;
using System.Text;
using MyStore.Data;
using MyStore.Data.Repositories;
using MyStore.Domain.Entities;

namespace MyStore.Services
{
    public interface ISupplierService
    {
        IEnumerable<Suppliers> GetAllSuppliers();
        Suppliers FindMySupplierById(int id);

        Suppliers UpdateSupplier(Suppliers supplierToUpdate);

        Suppliers AddSupplier(Suppliers addedSupplier);

       
    }
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public IEnumerable<Suppliers> GetAllSuppliers()
        {
            return supplierRepository.GetAllSuppliers();
        }

        public Suppliers FindMySupplierById(int id)
        {
            var mySupplier = supplierRepository.GetSupplierById(id);

            if (mySupplier != null)
            {
                return mySupplier;
            }

            return null;
        }

        public Suppliers UpdateSupplier(Suppliers supplierToUpdate)
        {//id wverything ok, update the supplier in db

            return supplierRepository.Update(supplierToUpdate);
        }

        public Suppliers AddSupplier(Suppliers addedSupplier)
        {
            if (IsUniqueCompany(addedSupplier.Companyname))
            {
                return supplierRepository.AddSupplier(addedSupplier);
            }
            return null;
        }

        private bool IsUniqueCompany(string name)
        {
            return supplierRepository.IsUniqueCompanyName(name);
        }
    }
}
