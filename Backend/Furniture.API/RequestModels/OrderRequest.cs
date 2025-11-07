using DataAccess.Entities;
using Domain.Enums;

namespace Furniture.API.RequestModels
{
    public class OrderRequest
    {
        public DeliveryType DeliveryType { get; set; }


        public PaymentOption PaymentOption { get; set; }


        public DateTime OrderDate { get; set; }


        public DateTime DeliveryDate { get; set; }


        public string CustomerName { get; set; } = string.Empty;


        public string CustomerPhoneNumber { get; set; } = string.Empty;


        public string CityName { get; set; } = string.Empty;
    }
}

