namespace Api.Controllers.Requests;

public class CreateNavigationItemRequest
{
    public required int ProfileId { get; set; }
    public required string Title { get; set; }
    public required string Icon { get; set; }
    public required string Url { get; set; }
}