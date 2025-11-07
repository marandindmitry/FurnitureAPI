using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class City
    {
        public int Id { get; }
        public string Name { get; } = string.Empty;
        public string DeliveryAddresses { get; }

        private City(
            int id, 
            string name, 
            string deliveryAddresses)
        {
            Id = id;
            Name = name;
            DeliveryAddresses = deliveryAddresses;
        }

        public static Result<City> Create(
            int id,
            string name,
            string deliveryAddresses)
        {
            // Валидация

            var city = new City(id, name, deliveryAddresses);

            return Result<City>.Ok(city);
        }
    }
}
