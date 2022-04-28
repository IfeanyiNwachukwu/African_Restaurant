using Services.OrderAPI.Contracts.Messaging;
using Services.OrderAPI.Extensions;
using Services.OrderAPI.Fulfilment.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureAuthentication();
builder.Services.ConfigureAuthorization();
//builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.ConfigureSingletonOrderRepository(builder.Configuration);
builder.Services.AddSingleton<IAzureServiceBusConsumer, AzureServiceBusConsumer>();

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
app.UseServiceBusConsumer();
app.Run();
