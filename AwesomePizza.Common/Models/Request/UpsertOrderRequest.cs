namespace AwesomePizza.Common.Models.Request;

public record UpsertOrderRequest
{
    public Guid? Id { get; set; }
    public string? Status { get; set; }
    public Dictionary<string, int>? Foods { get; set; }
}