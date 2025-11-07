using DataAccess.Entities.FurnitureEntities;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Models;
using Domain.Models.FurnitureModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class FurnitureRepository : IFurnitureRepository
    {
        private readonly AppDbContext _appDbContext;

        public FurnitureRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Furniture>> GetAllByDiscriminator(string discriminator)
        {
            var furnitureEntities = await _appDbContext.Furnitures
                .Where(k => k.Discriminator == discriminator && k.IsInBasket == false && k.IsOrdered == false)
                .ToListAsync();

            var furniture = new List<Furniture>(); 

            foreach (var fE in furnitureEntities) 
            {
                switch (discriminator)
                {
                    case "Table":
                        var tE = (TableEntity)fE;
                        var table = new Table(tE.Id, tE.Name, tE.Producer, tE.Material, tE.Color, tE.Description, tE.Width, tE.Height, tE.Price, tE.OrderId,
                                             tE.ImagePath, tE.Depth, tE.HeightFloorToFrame);
                        if (!furniture.Exists(f => f.Name == table.Name))
                            furniture.Add(table);
                        break;

                    case "Chair":
                        var cE = (ChairEntity)fE;
                        var chair = new Chair(cE.Id, cE.Name, cE.Producer, cE.Material, cE.Color, cE.Description, cE.Width, cE.Height, cE.Price, cE.OrderId, cE.ImagePath);
                        if (!furniture.Exists(f => f.Name == chair.Name))
                            furniture.Add(chair);
                        break;
                }
            }
           
            return furniture;
        }

        public async Task<Furniture> GetByDiscriminatorAndName(string discriminator, string name)
        {
            var furnitureEntity = await _appDbContext.Furnitures
                .Where(k => k.Discriminator == discriminator && k.Name == name && k.IsInBasket == false && k.IsOrdered == false)
                .FirstOrDefaultAsync();

            Furniture furniture = null;

            switch (discriminator)
            {
                case "Table":
                    if (furnitureEntity is TableEntity tE)
                    {
                        var table = new Table(tE.Id, tE.Name, tE.Producer, tE.Material, tE.Color, tE.Description, tE.Width, tE.Height, tE.Price, tE.OrderId,
                                              tE.ImagePath, tE.Depth, tE.HeightFloorToFrame);
                        furniture = table;
                    }
                    break;

                case "Chair":
                    if (furnitureEntity is ChairEntity cE)
                    {
                        var chair = new Chair(cE.Id, cE.Name, cE.Producer, cE.Material, cE.Color, cE.Description, cE.Width, cE.Height, cE.Price, cE.OrderId, cE.ImagePath);
                        furniture = chair;
                    }
                    break;
            }

            return furniture;
        }

        public async Task<List<Furniture>> GetAllFromBasket()
        {
            var furnitureEntities = await _appDbContext.Furnitures
                .Where(i => i.IsInBasket == true)
                .ToListAsync();

            List<Furniture> furniture = new List<Furniture>();

            foreach (var fE in furnitureEntities)
            {
                switch (fE.Discriminator)
                {
                    case "Table":
                        var tE = (TableEntity)fE;
                        var table = new Table(tE.Id, tE.Name, tE.Producer, tE.Material, tE.Color, tE.Description, tE.Width, tE.Height, tE.Price, tE.OrderId, tE.ImagePath,
                             tE.Depth, tE.HeightFloorToFrame);
                        furniture.Add(table);
                        break;
                    case "Chair":
                        var cE = (ChairEntity)fE;
                        var chair = new Chair(cE.Id, cE.Name, cE.Producer, cE.Material, cE.Color, cE.Description, cE.Width, cE.Height, cE.Price, cE.OrderId, cE.ImagePath);
                        furniture.Add(chair);
                        break;
                }
            }

            return furniture;
        }

        public async Task<List<Furniture>> GetAllOrdered()
        {
            var furnitureEntities = await _appDbContext.Furnitures
                .Where(i => i.IsOrdered == true)
                .Include(o => o.Order)
                .ToListAsync();

            List<Furniture> furniture = new List<Furniture>();

            foreach (var fE in furnitureEntities)
            {
                switch (fE.Discriminator)
                {
                    case "Table":
                        var tE = (TableEntity)fE;
                        var table = new Table(tE.Id, tE.Name, tE.Producer, tE.Material, tE.Color, tE.Description, tE.Width, tE.Height, tE.Price, tE.OrderId, tE.ImagePath,
                             tE.Depth, tE.HeightFloorToFrame);
                        furniture.Add(table);
                        break;
                    case "Chair":
                        var cE = (ChairEntity)fE;
                        var chair = new Chair(cE.Id, cE.Name, cE.Producer, cE.Material, cE.Color, cE.Description, cE.Width, cE.Height, cE.Price, cE.OrderId, cE.ImagePath);
                        furniture.Add(chair);
                        break;
                }
            }

            return furniture;
        }

        public async Task AddInBasketById(int id)
        {
            await _appDbContext.Furnitures
                .Where(k => k.Id == id)
                .ExecuteUpdateAsync(f => f.SetProperty(i => i.IsInBasket, true));
        }

        public async Task DeleteFromBasketById(int id)
        {
            await _appDbContext.Furnitures
                .Where(k => k.Id == id)
                .ExecuteUpdateAsync(f => f.SetProperty(i => i.IsInBasket, false));
        }

        public async Task DeleteAllOrdered(List<Furniture> furniture, int orderId)
        {
            var furnitureIds = furniture.Select(f => f.Id).ToList();

            await _appDbContext.Furnitures
                .Where(f => furnitureIds.Contains(f.Id))
                .ExecuteUpdateAsync(p => p
                .SetProperty(p => p.IsOrdered, true)
                .SetProperty(p => p.IsInBasket, false)
                .SetProperty(p => p.OrderId, orderId));
        }
    }
}
