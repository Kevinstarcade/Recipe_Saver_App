using Microsoft.EntityFrameworkCore;
using Recipe_Saver_App.Components;
using Recipe_Saver_App.Data;
using Microsoft.Extensions.DependencyInjection;

// TODO: determine if I want to use ASP.NET and razor or if I follow the new Blazor path.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<RecipesContext>(options =>
    options.UseSqlite("Data Source = C:\\Users\\kevin\\source\\repos\\Recipe_Saver_App\\recipes.db"));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorPages();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

//using Recipe_Saver_App.Models;
//using RecipesContext context = new RecipesContext();

//Recipe LasagnaSoup = new Recipe()
//{
//    RecipeName = "Lasagna Soup"
//};
//context.Recipes.Add(LasagnaSoup);
//context.SaveChanges();