using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Models;
using Furniture.API.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureAPI.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IFurnitureService _furnitureService;
        private readonly ICityRepository _cityRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly Random _random;

        public OrderController(IOrderService orderService, IFurnitureService furnitureService, ICityRepository cityRepository, ICustomerRepository customerRepository)
        {
            _orderService = orderService;
            _furnitureService = furnitureService;
            _cityRepository = cityRepository;
            _customerRepository = customerRepository;
            _random = new Random();
        }

        [Route("make-order")]
        [HttpPost]
        public async Task<ActionResult> MakeOrder([FromBody]OrderRequest orderRequest)
        {
            int id1 = _random.Next(int.MinValue, int.MaxValue);
            int id2 = _random.Next(int.MinValue, int.MaxValue);

            var customer = Customer.Create(
                id1,
                orderRequest.CustomerName,
                orderRequest.CustomerPhoneNumber).Value;

            await _customerRepository.Create(customer);

            var city = await _cityRepository.GetCityByName(orderRequest.CityName);

            var order = Order.Create(
                id2,
                orderRequest.DeliveryType,
                orderRequest.PaymentOption,
                orderRequest.OrderDate,
                orderRequest.DeliveryDate,
                customer.Id,
                city.Id).Value;

            await _orderService.MakeOrder(order);

            var furniture = await _furnitureService.GetAllFurnitureFromBasket();
            await _furnitureService.DeleteAllOrderedFurniture(furniture, order.Id);

            return Ok();
        }
    }
}
