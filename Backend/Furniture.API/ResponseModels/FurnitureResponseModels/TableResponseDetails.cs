namespace FurnitureAPI.ResponseModels.FurnitureResponseModels
{
    public record TableResponseDetails(
        int id, 
        string name, 
        string producer,
        string material,
        string color,
        double width,
        double height,
        float price,
        double depth,
        double heightFloorToFrame,
        string fullImagePath);
}
