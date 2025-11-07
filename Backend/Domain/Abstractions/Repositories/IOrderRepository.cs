using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task Create(Order order);
    }
}
