using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    internal class ProductService:IProductService
    {


        IProductRepository repository;

        public ProductService(IProductRepository productRepository)
        {
            repository = productRepository;
        }
        public async Task<List<Product>> GetProduct()
        {
            return await repository.GetProduct();
        }
    }
}
