namespace AwesomePizza.Common.Models.Dto;

public record OrderDto
{
    public required Guid Code { get; set; }
    public required string Status { get; set; }
    public required string CreationUser { get; set; }
    public required DateTime CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
    public string? ModificationUser { get; set; }
    public DateTime? DeletionDate { get; set; }
    public string? DeletionUser { get; set; }
    public required bool Deleted { get; set; }
}