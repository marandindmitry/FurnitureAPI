using Domain.Abstractions;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }
        public int CityId { get; set; }
        public CityEntity City { get; set; }
        public List<FurnitureEntity> Furniture { get; set; }
    }
}
