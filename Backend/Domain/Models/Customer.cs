using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using SharedKernel;

namespace Domain.Models
{
    public class Customer
    {
        public int Id { get; }
        public string Name { get; } = string.Empty;
        public string PhoneNumber { get; } = string.Empty;
        public List<Order>? Orders { get; } 

        private Customer(
            int id, 
            string name, 
            string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public static Result<Customer> Create(
            int id,
            string name,
            string phoneNumber)
        {
            // Валидация

            var customer = new Customer(id, name, phoneNumber);

            return Result<Customer>.Ok(customer);
        }
    }
}
