namespace Api.Controllers.Requests;

public class UpdateBookmarkRequest
{
    public required string Title { get; set; }
    public required string Url { get; set; }
}