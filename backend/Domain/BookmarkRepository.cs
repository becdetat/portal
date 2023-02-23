namespace Domain;

using Domain.Dtos;
using Domain.Models;
using Domain;
using Microsoft.EntityFrameworkCore;

public interface IBookmarkRepository
{
    Task<BookmarkDto> CreateBookmark(
        int profileId,
        string title,
        string url
    );
    Task<BookmarkDto> UpdateBookmark(int id, string title, string url);
    Task DeleteBookmark(int id);
}

public class BookmarkRepository : IBookmarkRepository
{
     public readonly PortalDbContext _dbContext;

    public BookmarkRepository(PortalDbContext dbContext) => _dbContext = dbContext;

   public async Task<BookmarkDto> CreateBookmark(
        int profileId,
        string title,
        string url
    )
    {
        var bookmark = new Bookmark
        {
            Title = title,
            Url = url,
            ProfileId = profileId
        };

        _dbContext.Bookmarks.Add(bookmark);

        await _dbContext.SaveChangesAsync();

        var dto = Mapper.MapBookmarkToBookmarkDto(bookmark);

        return dto;
    }

    public async Task<BookmarkDto> UpdateBookmark(int id, string title, string url)
    {
        var bookmark = await _dbContext.Bookmarks.FindAsync(id);

        if (bookmark is null)
        {
            throw new InvalidOperationException("The specified bookmark could not be found");
        }

        bookmark.Title = title;
        bookmark.Url = url;

        await _dbContext.SaveChangesAsync();

        return Mapper.MapBookmarkToBookmarkDto(bookmark);
    }
    
    public async Task DeleteBookmark(int id)
    {
        var bookmark = await _dbContext.Bookmarks.FindAsync(id);

        if (bookmark is null) return;

        _dbContext.Bookmarks.Remove(bookmark);

        await _dbContext.SaveChangesAsync();
    }
}