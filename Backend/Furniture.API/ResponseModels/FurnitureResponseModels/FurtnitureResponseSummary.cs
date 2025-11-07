namespace FurnitureAPI.ResponseModels.FurnitureResponseModels
{
    public record FurnitureResponseSummary(
        string name,
        string description,
        float price, 
        string type,
        string fullImagePath);
}
