using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.FurnitureModels
{
    public class Chair : Furniture
    {
        public Chair(
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
                  imagePath) { }
    }
}
