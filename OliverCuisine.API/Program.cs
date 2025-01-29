using Microsoft.EntityFrameworkCore;
using OliverCuisine.Core.Data;
using OliverCuisine.Server;
using OliverCuisine.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<StoreDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IStoreEntities>(provider => provider.GetRequiredService<StoreDbContext>());
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200","https://localhost:4200"));

app.MapControllers();

try
{
     using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
        context.Database.Migrate();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}
app.Run();
