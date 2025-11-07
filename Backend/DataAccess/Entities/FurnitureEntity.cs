using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class FurnitureEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Producer { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Width { get; set; }
        public double Height { get; set; }
        public float Price { get; set; }
        public int? OrderId { get; set; }
        public OrderEntity? Order { get; set; }
        public string? Discriminator { get; set; }
        public bool IsInBasket { get; set; }
        public bool IsOrdered { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
