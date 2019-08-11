//using MyStore.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MyStore.Repositories
//{
//    public interface ICustomerRepository
//    {
//        List<Customers> GetAllCustomers();
//        List<Customers> GetAllCustomers(string country, string name);
//    }

//    public class CustomerRepository : ICustomerRepository
//    {
//        private readonly StoreContext storeContext;

//        public CustomerRepository(StoreContext store)
//        {
//            storeContext = store;
//        }

//        public List<Customers> GetAllCustomers()
//        {
//            return storeContext.Customers.ToList();
//        }

//        public List<Customers> GetAllCustomers(string country, string name)
//        {
//            return storeContext.Customers
//                .Where(x => x.Country == country && x.Contactname == name)
//                .ToList();
//        }

//    }
//}
