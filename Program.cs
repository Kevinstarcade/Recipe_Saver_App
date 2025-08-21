using Microsoft.EntityFrameworkCore;
using Recipe_Saver_App.Components;
using Recipe_Saver_App.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.Json;

// TODO: determine if I want to use ASP.NET and razor or if I follow the new Blazor path.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();

// TODO: figure out how to handle cycles properly with EF Core and JSON serialization
//builder.Services.Configure<JsonOptions>(options =>
//{
//    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
//});

builder.Services.AddDbContextFactory<RecipesContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("RecipesContext") ??
        throw new InvalidOperationException(
            "Connection string 'RecipesContext' not found.")));

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