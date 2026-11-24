using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class CategoryService
    {
        ICategoryRepository repository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            repository = categoryRepository;
        }
        public async Task<List<Category>> GetCategory()
        {
            return await repository.GetCategory();
        }
    }
}
