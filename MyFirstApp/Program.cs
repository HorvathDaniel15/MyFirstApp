using Microsoft.EntityFrameworkCore;
using MyFirstApp.Data;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<ProductDbContext>(opt => 
{
    opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProductDb;Trusted_Connection=True;MultipleActiveResultSets=true");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();


app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "api/docs";
});

app.Run();
