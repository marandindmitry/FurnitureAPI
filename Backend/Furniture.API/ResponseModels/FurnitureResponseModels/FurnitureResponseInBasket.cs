namespace FurnitureAPI.ResponseModels.FurnitureResponseModels
{
    public record FurnitureResponseInBasket(
        int id,
        string name,
        float price,
        string fullImagePath);
}
