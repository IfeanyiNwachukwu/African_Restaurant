using Integration.MessageBus.Contracts;
using Integration.MessageBus.Fulfilment;
using Services.ShoppingCartAPI.Contracts.IRepositoryManager.ShoppingCartRepositoryStore;
using Services.ShoppingCartAPI.Extensions;
using Services.ShoppingCartAPI.Helpers;
using Services.ShoppingCartAPI.RepositoriesManager.ShoppingCartRepositoryStore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddSingleton<IMessageBus, AzureServiceBusMessageBus>();
StaticDetails.CheckoutTopic = builder.Configuration["AzureServiceBus:CheckoutTopic"];


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
