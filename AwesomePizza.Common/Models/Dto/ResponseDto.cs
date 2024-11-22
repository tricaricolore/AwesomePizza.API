namespace AwesomePizza.Common.Models.Dto;

public class ResponseDto
{
    public bool Status { get; set; }
    
    public string? Detail { get; set; }

    public ResponseDto() { }

    public ResponseDto(string? detail)
    {
        Status = true;
        Detail = detail;
    }
}