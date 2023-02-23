namespace Api.Controllers.Requests;

public class CreateBookmarkRequest
{
    public required int ProfileId { get; set; }
    public required string Title { get; set; }
    public required string Url { get; set; }
}