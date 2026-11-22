using System;
using System.Collections.Generic;
using System.Text;
using Repository.Models;

namespace Entities
{
    public class Dbset<T>
    {
        public virtual Dbset<Category> Categories { get; set; }
        public virtual Dbset<OrderItem> OrderItem { get; set; }
        public virtual Dbset<Order> Orders { get; set; }
        public virtual Dbset<Product> Products { get; set; }
        public virtual Dbset<User> Users { get; set; }

    }
}
