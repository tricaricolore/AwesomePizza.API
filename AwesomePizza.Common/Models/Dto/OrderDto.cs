namespace AwesomePizza.Common.Models.Dto;

public class OrderDto
{
    public Guid Code { get; set; }
    public string CreationUser { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
    public string? ModificationUser { get; set; }
    public DateTime? DeletionDate { get; set; }
    public string? DeletionUser { get; set; }
    public bool Deleted { get; set; }
}