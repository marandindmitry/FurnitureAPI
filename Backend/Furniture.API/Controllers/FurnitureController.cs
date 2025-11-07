using DataAccess.Entities.FurnitureEntities;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Enums;
using Domain.Models.FurnitureModels;
using Domain.Services;
using FurnitureAPI.ResponseModels.FurnitureResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FurnitureAPI.Controllers
{
    [ApiController]
    [Route("furniture")]
    public class FurnitureController : ControllerBase
    {
        private readonly IFurnitureService _furnitureService;
        private readonly IOrderRepository _orderRepository;

        public FurnitureController(IFurnitureService furnitureService, IOrderRepository orderRepository)
        {
            _furnitureService = furnitureService;
            _orderRepository = orderRepository;
        }

        
        [Route("{type}")]
        [HttpGet]
        public async Task<ActionResult<List<FurnitureResponseSummary>>> GetAllFurnitureByType([FromRoute]string type)
        {
            var furniture = await _furnitureService.GetAllFurnitureByType(type);

            var furnitureResponse = furniture
                .Select(f => new FurnitureResponseSummary(
                f.Name,            // ОТОБРАЖАЕТСЯ, А ТАКЖЕ ВРЕМЕННО СОХРАНЯЕТСЯ ДЛЯ ПОСЛЕДУЮЩЕЙ РАБОТЫ (ДОБАВЛЕНИЯ В КОРЗИНУ) ИМЕННО С ЭТИМ ТОВАРОМ
                f.Description,
                f.Price,
                type.ToLower(),
                f.ImagePath));

            return Ok(furnitureResponse);
        }

        [Route("{type}/{name}")]
        [HttpGet]
        public async Task<ActionResult<TableResponseDetails>> GetFurnitureByTypeAndName([FromRoute]string type, [FromRoute]string name)
        {
            var furniture = await _furnitureService.GetFurnitureByTypeAndName(type, name);
            
            if (type == "Table")
            {
                var table = (Domain.Models.FurnitureModels.Table)furniture;

                var furnitureResponse = new TableResponseDetails(
                table.Id,         // НЕ ОТОБРАЖАЕТСЯ, А ПРОСТО ВРЕМЕННО СОХРАНЯЕТСЯ ДЛЯ ДАЛЬНЕЙШЕГО ДОБАВЛЕНИЯ ТОВАРА В КОРЗИНУ ПО НАЖАТИЮ КНОПКИ "Добавить в корзину"
                table.Name,
                table.Producer,
                table.Material,
                table.Color,
                table.Width,
                table.Height,
                table.Price,
                table.Depth,
                table.HeightFloorToFrame,
                table.ImagePath);

                return Ok(furnitureResponse);
            }
            else if (type == "Chair")
            {
                var chair = (Chair)furniture;

                var furnitureResponse = new ChairResponseFull(
                chair.Id,       // НЕ ОТОБРАЖАЕТСЯ, А ПРОСТО ВРЕМЕННО СОХРАНЯЕТСЯ ДЛЯ ДАЛЬНЕЙШЕГО ДОБАВЛЕНИЯ ТОВАРА В КОРЗИНУ ПО НАЖАТИЮ КНОПКИ "Добавить в корзину"
                chair.Name,
                chair.Producer,
                chair.Material,
                chair.Color,
                chair.Width,
                chair.Height,
                chair.Price,
                chair.ImagePath);

                return Ok(furnitureResponse);
            }

            return BadRequest();
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult> AddFurnitureInBasketById([FromRoute]int id)
        {
            await _furnitureService.AddFurnitureInBasketById(id);

            return Ok();
        }

        [Route("basket")]
        [HttpGet]
        public async Task<ActionResult<List<FurnitureResponseInBasket>>> GetAllFurnitureFromBasket()
        {
            var furniture = await _furnitureService.GetAllFurnitureFromBasket();

            var furnitureResponse = furniture
               .Select(f => new FurnitureResponseInBasket(
                   f.Id,          // НЕ ОТОБРАЖАЕТСЯ, А ПРОСТО ВРЕМЕННО СОХРАНЯЕТСЯ ДЛЯ ДАЛЬНЕЙШЕГО ОФОРМЛЕНИЯ ЗАКАЗА ПО НАЖАТИЮ КНОПКИ "Сделать заказ" ИЛИ УДАЛЕНИЯ ТОВАРА ИЗ КОРЗНИНЫ ПО НАЖАТИЮ КНОПКИ "Удалить из корзины"
                   f.Name,            
                   f.Price,
                   f.ImagePath));

            return Ok(furnitureResponse);
        }

        [Route("basket/{id}")]
        [HttpPut]
        public async Task<ActionResult> DeleteFurnitureFromBasketById([FromRoute] int id)
        {
            await _furnitureService.DeleteFurnitureFromBasketById(id);

            return Ok();
        }

        [Route("order-list")]
        [HttpGet]
        public async Task<ActionResult<List<AllOrderedFurnitureResponse>>> GetAllOrderedFurniture()
        {
            var orders = await _orderRepository.GetAll();

            var furnitureResponse = orders
                .SelectMany(o => o.Furniture
                .Select(f => new AllOrderedFurnitureResponse(
                    o.Id,
                    f.Name,
                    f.Price,
                    o.OrderDate,
                    o.DeliveryDate,
                    f.ImagePath)));

            return Ok(furnitureResponse);
        }
    }
}
