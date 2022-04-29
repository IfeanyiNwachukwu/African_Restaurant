using Integration.MessageBus.Contracts;
using Integration.MessageBus.Fulfilment;
using Services.ShoppingCartAPI.ContractFulfilment.RepositoriesManager.CouponRepositoryStore;
using Services.ShoppingCartAPI.ContractFulfilment.RepositoriesManager.ShoppingCartRepositoryStore;
using Services.ShoppingCartAPI.Contracts.IRepositoryManager.CouponRepositoryStore;
using Services.ShoppingCartAPI.Contracts.IRepositoryManager.ShoppingCartRepositoryStore;
using Services.ShoppingCartAPI.Extensions;
using Services.ShoppingCartAPI.Helpers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureAuthentication();
builder.Services.ConfigureAuthorization();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddSingleton<IMessageBus, AzureServiceBusMessageBus>();
StaticDetails.CheckoutTopic = builder.Configuration["AzureServiceBus:CheckoutTopic"];
builder.Services.ConfigureHttpClient(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
