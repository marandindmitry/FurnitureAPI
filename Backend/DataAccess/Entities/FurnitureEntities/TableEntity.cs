using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Entities.FurnitureEntities
{
    public class TableEntity : FurnitureEntity
    {
        public double Depth { get; set; }
        public double HeightFloorToFrame { get; set; }
    }
}
