using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _appDbContext;

        public CityRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<City> GetCityByName(string cityName)
        {
            var cityEntity = await _appDbContext.Cities
                .Where(n => n.Name == cityName)
                .FirstOrDefaultAsync();

            var city = City.Create(
                cityEntity.Id,
                cityEntity.Name,
                cityEntity.DeliveryAddresses);

            return city.Value;
        }
    }
}
