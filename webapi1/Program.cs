using Core.Interfaces;
using Infrastucture.Data;
using Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoreContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("myconnectionstring")));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.Services.CreateScope().ServiceProvider.GetRequiredService<StoreContext>().Database.MigrateAsync();




await StoreContextSeed.SeedAsync(app.Services.CreateScope().ServiceProvider.GetRequiredService<StoreContext>());
app.Run();
