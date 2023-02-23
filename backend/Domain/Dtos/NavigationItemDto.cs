namespace Domain.Dtos;

public class NavigationItemDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Icon { get; set; }
    public required string Url { get; set; }
}