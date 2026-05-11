using Microsoft.EntityFrameworkCore;
using VideoGameRepo.Data;
using VideoGameRepo.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

builder.Services.AddDbContext<VideoGameRepoDbContext>(options =>
{
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/games", async (Game game, VideoGameRepoDbContext ctx) =>
{
    ctx.Games.Add(game);
    await ctx.SaveChangesAsync();

    return Results.Created($"/games/{game.Id}", game);
});

app.MapGet("/games/{id}", async (int id, VideoGameRepoDbContext ctx) =>
{
    return await ctx.Games.FindAsync(id) is Game game ? Results.Ok(game) : Results.NotFound();
});

app.MapGet("/games", async (VideoGameRepoDbContext ctx) =>
{
    return await ctx.Games.ToListAsync();
});

app.MapPut("/games/{id}", async (int id, Game game, VideoGameRepoDbContext ctx) =>
{
    var rowsAffected = await ctx.Games.Where(b => b.Id == id)
    .ExecuteUpdateAsync(s => s
    .SetProperty(b => b.Title, game.Title)
    .SetProperty(b => b.Cost, game.Cost)
    );
    return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
});

app.MapDelete("/games/{id}", async (int id, VideoGameRepoDbContext ctx) =>
{
    if (await ctx.Games.FindAsync(id) is Game game)
    {
        ctx.Games.Remove(game);
        await ctx.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});
app.Run();