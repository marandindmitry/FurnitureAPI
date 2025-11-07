using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.FurnitureModels
{
    public class Table : Furniture
    {
        public double Depth { get; }
        public double HeightFloorToFrame { get; }

        public Table(
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
           string imagePath,
           double depth,
           double heightFloorToFrame)
            : base(
                  id,
                  name,
                  producer,
                  material,
                  color,
                  description,
                  width,
                  height,
                  price,
                  orderId,
                  imagePath) 
        {
            Depth = depth;
            HeightFloorToFrame = heightFloorToFrame;
        }
    }
}
