namespace FurnitureAPI.ResponseModels.FurnitureResponseModels
{
    public record AllOrderedFurnitureResponse(
        int id,
        string name,
        float price,
        DateTime orderDate,
        DateTime deliveryDate,
        string fullImagePath);
}
