using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class OrderService:IOrderService
    {
        IOrderRepository repository;

        public OrderService(IOrderRepository orderRepository)
        {
            repository = orderRepository;
        }

       
        public Order Post(Order order)
        {
            return repository.Post(order).Result;

        }
    }
}
