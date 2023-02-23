namespace Domain;

using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public interface INavigationItemRepository
{
    Task<NavigationItemDto> CreateNavigationItem(
        int profileId,
        string title,
        string icon,
        string url
    );
}

public class NavigationItemRepository : INavigationItemRepository
{
    public readonly PortalDbContext _dbContext;

    public NavigationItemRepository(PortalDbContext dbContext) => _dbContext = dbContext;

    public async Task<NavigationItemDto> CreateNavigationItem(
        int profileId,
        string title,
        string icon,
        string url
    )
    {
        var navigationItem = new NavigationItem
        {
            Title = title,
            Icon = icon,
            Url = url,
            ProfileId = profileId
        };

        _dbContext.NavigationItems.Add(navigationItem);

        await _dbContext.SaveChangesAsync();

        var dto = Mapper.MapNavigationItemToNavigationItemDto(navigationItem);

        return dto;
    }
}