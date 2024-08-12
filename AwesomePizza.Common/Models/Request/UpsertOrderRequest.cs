namespace AwesomePizza.Common.Models.Request;

public record UpsertOrderRequest
{
    public Guid? Id { get; set; }
}