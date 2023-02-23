namespace Domain;

using Domain.Dtos;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public interface IPortalRepository
{
    Task<IEnumerable<ProfileDto>> GetAllProfiles(CancellationToken cancellationToken);
    Task<ProfileDto> CreateProfile(string name);
    Task<FullProfileDto> GetFullProfile(int id);
}

public class PortalRepository : IPortalRepository
{
    public readonly PortalDbContext _dbContext;

    public PortalRepository(PortalDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<ProfileDto>> GetAllProfiles(CancellationToken cancellationToken)
    {
        var profiles = await _dbContext.Profiles.ToListAsync(cancellationToken);
        var dtos = profiles
            .Select(Mapper.MapProfileToProfileDto);

        return dtos;
    }

    public async Task<ProfileDto> CreateProfile(string name)
    {
        var profile = new Profile { Name = name };

        _dbContext.Profiles.Add(profile);
        
        await _dbContext.SaveChangesAsync();

        var dto = Mapper.MapProfileToProfileDto(profile);

        return dto;
    }

    public async Task<FullProfileDto> GetFullProfile(int id)
    {
        var profile = await _dbContext.Profiles
            .SingleAsync(x => x.Id == id);
        var navigationItems = await _dbContext.NavigationItems
            .Where(x => x.ProfileId == id)
            .ToListAsync();
        var bookmarks = await _dbContext.Bookmarks
            .Where(x => x.ProfileId == id)
            .ToListAsync();
        var dto = Mapper.MapProfileToFullProfileDto(
            profile,
            navigationItems,
            bookmarks);

        return dto;
    }
}

