using EcomLDC.Application.UseCases;
using EcomLDC.Infrastructure;
using EcomLDC.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Repositories + UoW
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// UseCases
builder.Services.AddScoped<CreateOrderHandler>();
builder.Services.AddScoped<GetProductsHandler>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
