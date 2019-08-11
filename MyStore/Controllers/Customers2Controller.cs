using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customers2Controller : ControllerBase
    {
        // GET: api/Customers2
        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            List<Customers> allCustomers = new List<Customers>();

            using (var context = new StoreContext())
            {
                allCustomers = context.Customers.ToList();
                var orders = context.Orders.ToList();
                return orders;
            }

            return new List<Orders>();
        }


    }
}
