using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Services
{
    public interface IFurnitureService
    {
        Task<List<Furniture>> GetAllFurnitureByType(string type);
        Task<Furniture> GetFurnitureByTypeAndName(string type, string name);
        Task<List<Furniture>> GetAllFurnitureFromBasket();
        Task<List<Furniture>> GetAllOrderedFurniture();
        Task AddFurnitureInBasketById(int id);
        Task DeleteFurnitureFromBasketById(int id);
        Task DeleteAllOrderedFurniture(List<Furniture> furniture, int orderId);

    }
}
