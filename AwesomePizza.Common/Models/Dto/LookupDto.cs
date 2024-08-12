namespace AwesomePizza.Common.Models.Dto;

public record LookupDto
{
    public required string Code { get; set; }
    public required string Description { get; set; }
    public  string CodeAndDescription => $"{Code} - {Description}";
}