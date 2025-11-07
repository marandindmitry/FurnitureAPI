using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Enums;
using SharedKernel;

namespace Domain.Models
{
    public class Order
    {
        public int Id { get; }
        public DeliveryType DeliveryType { get; } 
        public PaymentOption PaymentOption { get; }
        public DateTime OrderDate { get; }
        public DateTime DeliveryDate { get; }
        public int CustomerId { get; }
        public Customer? Customer { get; } 
        public int CityId { get; }
        public City? City { get;  } 
        public List<Furniture>? Furniture { get; set; } 

        private Order(
            int id,
            DeliveryType deliveryType,
            PaymentOption paymentOption,
            DateTime orderDate,
            DateTime deliveryDate,
            int customerId,
            int cityId) 
        {
            Id = id;
            DeliveryType = deliveryType;
            PaymentOption = paymentOption;
            OrderDate = orderDate;
            DeliveryDate = orderDate;
            CustomerId = customerId;
            CityId = cityId;
        }

        public static Result<Order> Create(
            int id,
            DeliveryType deliveryType,
            PaymentOption paymentOption,
            DateTime orderDate,
            DateTime deliveryDate,
            int customerId,
            int cityId)
        {
           // Валидация

           var order = new Order(id, deliveryType, paymentOption, orderDate, deliveryDate, customerId, cityId);

           return Result<Order>.Ok(order);
        }
    }
}
