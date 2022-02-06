using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using webapi1.API.Extensions;
using webapi1.API.Helpers;
using webapi1.API.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerServiceExtensions();



builder.Services.AddCors(opt =>
{
    opt.AddPolicy("corspolicy", policy =>
    {

        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();


    });

});
    
    

builder.Services.AddDbContext<StoreContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("myconnectionstring")));




var app = builder.Build();

//Using own exception middleware
app.UseMiddleware<ExceptionMiddleWare>();

// Configure the HTTP request pipeline.


app.UseSwaggerDocumenationExt();

app.UseStatusCodePagesWithRedirects("/customerror/{0}");

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseCors("corspolicy");


app.UseAuthorization();


app.MapControllers();

await app.Services.CreateScope().
    ServiceProvider.GetRequiredService<StoreContext>().Database.MigrateAsync();




await StoreContextSeed.SeedAsync(app.Services.CreateScope()
    .ServiceProvider.GetRequiredService<StoreContext>());
app.Run();
