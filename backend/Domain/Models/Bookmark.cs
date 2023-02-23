namespace Domain.Models;

public class Bookmark
{
    public int Id { get; set; }
    public required int ProfileId { get; set; }
    public required string Title { get; set; }
    public required string Url { get; set; }
}