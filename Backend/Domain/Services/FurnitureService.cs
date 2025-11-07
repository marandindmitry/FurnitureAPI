using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FurnitureService : IFurnitureService
    {
        private readonly IFurnitureRepository _furnitureRepository;

        public FurnitureService(IFurnitureRepository furnitureRepository)
        {
            _furnitureRepository = furnitureRepository;
        }

        public async Task<List<Furniture>> GetAllFurnitureByType(string type)
        {
            return await _furnitureRepository.GetAllByDiscriminator(type);
        }

        public async Task<Furniture> GetFurnitureByTypeAndName(string type, string name)
        {
            var furniture = await _furnitureRepository.GetByDiscriminatorAndName(type, name);

            return furniture;
        }

        public async Task<List<Furniture>> GetAllFurnitureFromBasket()
        {
            var furniture = await _furnitureRepository.GetAllFromBasket();

            return furniture;
        }

        public async Task<List<Furniture>> GetAllOrderedFurniture()
        {
            var furniture = await _furnitureRepository.GetAllOrdered();

            return furniture;
        }

        public async Task AddFurnitureInBasketById(int id)
        {
            await _furnitureRepository.AddInBasketById(id);
        }

        public async Task DeleteFurnitureFromBasketById(int id)
        {
            await _furnitureRepository.DeleteFromBasketById(id);
        }

        public async Task DeleteAllOrderedFurniture(List<Furniture> furniture, int orderId)
        {
            await _furnitureRepository.DeleteAllOrdered(furniture, orderId);
        }
    }
}
