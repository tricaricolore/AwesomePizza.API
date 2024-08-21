namespace AwesomePizza.Common.Models.Request;

public class SearchOrderRequest: Page.Request
{
    public string? Status { get; set; }
    public bool? Deleted { get; set; }
}