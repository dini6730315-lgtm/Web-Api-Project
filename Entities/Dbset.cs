using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Dbset<T>
    {
        public virtual Dbset<Categories> Categories { get; set; }
        public virtual Dbset<OrderItem> OrderItem { get; set; }
        public virtual Dbset<Orders> Orders { get; set; }
        public virtual Dbset<Products> Products { get; set; }
        public virtual Dbset<Users> Users { get; set; }

    }
}
