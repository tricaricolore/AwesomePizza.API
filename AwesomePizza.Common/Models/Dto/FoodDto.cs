namespace AwesomePizza.Common.Models.Dto;

public class FoodDto
{
    public required Guid Code { get; set; }
    public required string Type { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required double Price { get; set; }
    public required List<LookupDto> Ingredients { get; set; }
}