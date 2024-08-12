namespace AwesomePizza.Common.Models;

public class Page
{
    public abstract class Request
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
    
    public abstract class Response: Request
    {
        public int TotalItems { get; set; }
    }
}