namespace AwesomePizza.Common.Models.Dto;

public class OrderFoodDto
{
    public required FoodDto Food { get; set; }
    public required int Amount { get; set; }
}