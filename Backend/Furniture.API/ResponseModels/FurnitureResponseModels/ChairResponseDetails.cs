namespace FurnitureAPI.ResponseModels.FurnitureResponseModels
{
    public record ChairResponseFull(
        int id,
        string name,
        string producer,
        string material,
        string color,
        double width,
        double height,
        float price,
        string fullImagePath);
}
