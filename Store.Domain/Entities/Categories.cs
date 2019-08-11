using System;
using System.Collections.Generic;

namespace MyStore.Domain.Entities
{
    public class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
