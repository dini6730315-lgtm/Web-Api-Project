using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class ProductRepository : IProductRepository
    {
        MyDataBaseContext db;


        public ProductRepository(MyDataBaseContext db)
        {
            this.db = db;
        }
       public async Task<List<Product>> GetProduct() 
        {
            return await db.Products.ToListAsync();
        }

        
    }
}
