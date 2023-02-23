namespace Domain.Dtos;

public class BookmarkDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Url { get; set; }
}