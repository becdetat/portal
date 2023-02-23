namespace Domain;

using Domain.Dtos;
using Domain.Models;

public static class Mapper
{
    public static ProfileDto MapProfileToProfileDto(Profile profile)
    {
        return new ProfileDto
        {
            Id = profile.Id,
            Name = profile.Name
        };
    }

    public static FullProfileDto MapProfileToFullProfileDto(
        Profile profile,
        IEnumerable<NavigationItem> navigationItems,
        IEnumerable<Bookmark> bookmarks)
    {
        return new FullProfileDto
        {
            Id = profile.Id,
            Name = profile.Name,
            NavigationItems = navigationItems.Select(MapNavigationItemToNavigationItemDto).ToList(),
            Bookmarks = bookmarks.Select(MapBookmarkToBookmarkDto).ToList()
        };
    }

    public static NavigationItemDto MapNavigationItemToNavigationItemDto(NavigationItem navigationItem)
    {
        return new NavigationItemDto
        {
            Id = navigationItem.Id,
            Title = navigationItem.Title,
            Icon = navigationItem.Icon,
            Url = navigationItem.Url
        };
    }

    public static BookmarkDto MapBookmarkToBookmarkDto(Bookmark bookmark)
    {
        return new BookmarkDto
        {
            Id = bookmark.Id,
            Title = bookmark.Title,
            Url = bookmark.Url
        };
    }
}

