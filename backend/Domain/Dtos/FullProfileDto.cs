namespace Domain.Dtos;

public class FullProfileDto : ProfileDto
{
    public IEnumerable<NavigationItemDto> NavigationItems { get; set; } = new NavigationItemDto[0];
    public IEnumerable<BookmarkDto> Bookmarks { get; set; } = new BookmarkDto[0];
}