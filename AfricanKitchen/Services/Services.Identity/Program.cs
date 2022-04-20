using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Builder;
using Services.Identity.Extension;
using Services.Identity.Initializer.Contracts;
using Services.Identity.Initializer.ContractsFulfilment;
using Services.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureIdentityServer();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IProfileService, ProfileService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseIdentityServer();
//app.UseAuthentication();
app.UseAuthorization();
app.UseDbInitializer();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
