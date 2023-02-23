namespace Domain.Models;

public class NavigationItem
{
    public int Id { get; set; }
    public required int ProfileId { get; set; }
    public required string Title { get; set; }
    public required string Icon { get; set; }
    public required string Url { get; set; }
}