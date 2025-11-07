using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Domain.Abstractions.Repositories;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Customer customer)
        {
            var customerEntity = new CustomerEntity()
            {
                Id = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber
            };

            await _appDbContext.Customers.AddAsync(customerEntity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
