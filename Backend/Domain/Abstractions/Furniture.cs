using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Abstractions
{
    public class Furniture
    {
        public int Id { get; }
        public string Name { get; } = string.Empty;
        public string Producer { get; } = string.Empty;
        public string Material { get; } = string.Empty;
        public string Color { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public double Width { get; }
        public double Height { get; }
        public float Price { get; }
        public int? OrderId { get; }
        public Order? Order { get; }
        public string? Discriminator { get;}
        public bool IsInBasket { get; }
        public bool IsOrdered { get; }
        public string ImagePath { get; } = string.Empty;

        public Furniture(
            int id, 
            string name,
            string producer,
            string material,
            string color,
            string description,
            double width,
            double height,
            float price,   
            int? orderId,
            string imagePath) 
        {
            Id = id;
            Name = name;
            Producer = producer;
            Material = material;
            Color = color;
            Description = description;
            Width = width;
            Height = height;
            Price = price;
            OrderId = orderId;
            ImagePath = imagePath;
        }
    }
}
