using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class CategoryRepository:ICategoryRepository
    {
        MyDataBaseContext db;


        public CategoryRepository(MyDataBaseContext db)
        {
            this.db = db;
        }
       public async Task<List<Category>> GetCategory()
        {
            return await db.Categories.ToListAsync();
        }
    }
}
