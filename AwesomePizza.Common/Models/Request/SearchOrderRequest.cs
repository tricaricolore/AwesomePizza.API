namespace AwesomePizza.Common.Models.Request;

public class SearchOrderRequest: Page.Request
{
    public bool? Deleted { get; set; }
}