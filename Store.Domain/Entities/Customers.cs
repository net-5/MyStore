﻿using System;
using System.Collections.Generic;

namespace MyStore.Domain.Entities
{
    public class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Custid { get; set; }
        public string Companyname { get; set; }
        public string Contactname { get; set; }
        public string Contacttitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
