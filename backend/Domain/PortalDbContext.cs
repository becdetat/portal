namespace Domain;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Domain.Models;

public class PortalDbContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<NavigationItem> NavigationItems { get; set; }
    public DbSet<Bookmark> Bookmarks { get; set; }

    public PortalDbContext(DbContextOptions<PortalDbContext> options)
        : base(options)
    { }
}
