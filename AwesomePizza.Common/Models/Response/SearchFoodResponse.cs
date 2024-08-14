using AwesomePizza.Common.Models.Dto;

namespace AwesomePizza.Common.Models.Response;

public class SearchFoodResponse: Page.Response
{
    public List<FoodDto> Foods { get; set; } = [];
}