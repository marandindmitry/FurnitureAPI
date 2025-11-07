using DataAccess.Entities;
using DataAccess.Entities.FurnitureEntities;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Models;
using Domain.Models.FurnitureModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Order>> GetAll()
        {
            var orderEntities = await _appDbContext.Orders
                .Include(f => f.Furniture)
                .ToListAsync();


            var orders = orderEntities
                .Select(o => Order.Create(
                    o.Id,
                    o.DeliveryType,
                    o.PaymentOption,
                    o.OrderDate,
                    o.DeliveryDate,
                    o.CustomerId,
                    o.CityId))
                .Where(o => o.IsSuccess)
                .Select(o => o.Value)
                .ToList();

            foreach (var order in orders)
            {
                var orderEntity = orderEntities.FirstOrDefault(oe => oe.Id == order.Id);
                if (orderEntity != null && orderEntity.Furniture != null)
                {
                    order.Furniture = orderEntity.Furniture
                        .Select<FurnitureEntity, Furniture>(fe => fe switch
                        {
                            TableEntity te => new Table(
                                te.Id, te.Name, te.Producer, te.Material, te.Color, te.Description, te.Width, te.Height, te.Price, te.OrderId, te.ImagePath,
                                te.Depth, te.HeightFloorToFrame),
                            ChairEntity ce => new Chair(
                                ce.Id, ce.Name, ce.Producer, ce.Material, ce.Color, ce.Description, ce.Width, ce.Height, ce.Price, ce.OrderId, ce.ImagePath),
                            _ => null
                        })
                        .Where(f => f != null)
                        .ToList();
                }
            }

            return orders;
        }

        public async Task Create(Order order)
        {
            var orderEntity = new OrderEntity()
            {
                Id = order.Id,
                DeliveryType = order.DeliveryType,
                PaymentOption = order.PaymentOption,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                CustomerId = order.CustomerId,
                CityId = order.CityId,
            };

            await _appDbContext.Orders.AddAsync(orderEntity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
