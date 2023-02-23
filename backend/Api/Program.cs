using Microsoft.EntityFrameworkCore;
using Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PortalDbContext>(options => options.UseSqlite("Data Source=portal.db"));
builder.Services.AddTransient<IPortalRepository, PortalRepository>();
builder.Services.AddTransient<IBookmarkRepository, BookmarkRepository>();
builder.Services.AddTransient<INavigationItemRepository, NavigationItemRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PortalDbContext>();

    db.Database.Migrate();    
}

app.Run();
