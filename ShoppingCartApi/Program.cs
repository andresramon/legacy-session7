using ShoppingCartApi.AppServices.Interfaces;
using ShoppingCartApi.AppServices.UseCases;
using ShoppingCartApi.Domain.Services;
using ShoppingCartApi.Infrastructure.Database;
using ShoppingCartApi.Infrastructure.Queries;
using ShoppingCartApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<InMemoryDatabase>();
builder.Services.AddSingleton<ICustomerRepository,CustomerRepository>();
builder.Services.AddSingleton<IProductRepository,ProductRepository>();
builder.Services.AddSingleton<IShoppingCartRepository,ShoppingCartRepository>();
builder.Services.AddSingleton<ICartQueries,CartQueries>();
builder.Services.AddSingleton<ICartPriceService,CartPriceService>();
builder.Services.AddSingleton<CalculateCartPriceUseCase>();
builder.Services.AddSingleton<CreateEmptyCartUseCase>();
builder.Services.AddSingleton<AddProductToCartUseCase>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();