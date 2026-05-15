using Microsoft.EntityFrameworkCore;
using VideoGameRepo.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Tell the application to support Controllers and Views (The GUI engine)
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VideoGameRepoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// 2. Configure HTTP request pipeline properties for a web app
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Required to load Bootstrap/CSS styles

app.UseRouting();
app.UseAuthorization();

// 3. Define the Root route to point directly to your new Games GUI
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Games}/{action=Index}/{id?}");

app.Run();
