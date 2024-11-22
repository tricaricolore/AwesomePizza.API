using AwesomePizza.Common.Models.Dto;

namespace AwesomePizza.Common.Models.Response;

public class SearchOrderResponse: Page.Response
{
    public List<OrderDto> Orders { get; set; } = [];
}