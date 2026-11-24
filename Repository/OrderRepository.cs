using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class OrderRepository
    {
        MyDataBaseContext db;


        public OrderRepository(MyDataBaseContext db)
        {
            this.db = db;
        }
        public async Task<Order> Post(Order order)
        {
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            return order;
        }
    }
}
