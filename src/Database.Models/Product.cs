using System;
using System.Collections.Generic;

namespace Database.DoFactory.Models
{
    public class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        //Version 2
        public DateTime? LastUpdate { get; set; }
        public string UserName { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
