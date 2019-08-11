using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;

namespace MyStore.Data.Repositories
{
    public interface ICustomerRepository
    {
        List<Customers> GetAllCustomers();

        List<Customers> GetAllCustomers(string country, string name);

        Customers GetCustomerById(int id);
        Customers Update(Customers customerToUpdate);

        Customers AddCustomer(Customers addedCustomer);
        bool IsUniqueCompanyName(string name);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext storeContext;

        public CustomerRepository(StoreContext store)
        {
            storeContext = store;
        }

        public List<Customers> GetAllCustomers()
        {
            return storeContext.Customers.ToList();
        }

        public List<Customers> GetAllCustomers(string country, string name)
        {
            return storeContext.Customers
                .Where(x => x.Country == country && x.Contactname == name)
                .ToList();
        }

        public Customers GetCustomerById(int id)
        {
            return storeContext.Customers.Find(id);
        }

        public Customers Update(Customers customerToUpdate)
        {
            var updatedEntity = storeContext.Customers.Update(customerToUpdate);

            storeContext.SaveChanges();

            return updatedEntity.Entity;

        }

        public Customers AddCustomer(Customers addedCustomer)
        {
            var createdEntity = storeContext.Customers.Add(addedCustomer);
            storeContext.SaveChanges();
            return createdEntity.Entity;
        }

        public bool IsUniqueCompanyName(string name)
        {
            //if (storeContext.Customers.Count(x=>x.Companyname == name) == 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            var unique = storeContext.Customers.Where(x => x.Companyname == name).FirstOrDefault();

            if (unique == null)
            {
                return true;
            }
            return false;
        }

    }
}
