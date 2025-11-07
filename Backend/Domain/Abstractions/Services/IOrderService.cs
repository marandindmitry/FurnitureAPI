using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task MakeOrder(Order order);
    }
}
