using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IFurnitureRepository
    {
        Task<List<Furniture>> GetAllByDiscriminator(string discriminator);
        Task<Furniture> GetByDiscriminatorAndName(string discriminator, string name);
        Task<List<Furniture>> GetAllFromBasket();
        Task<List<Furniture>> GetAllOrdered();
        Task AddInBasketById(int id);
        Task DeleteFromBasketById(int id);
        Task DeleteAllOrdered(List<Furniture> furniture, int orderId);
    }
}
