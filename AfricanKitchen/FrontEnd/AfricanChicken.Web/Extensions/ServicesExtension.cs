namespace AfricanKitchen.Web.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = configuration["ServiceUrls:IdentityAPI"];
                options.GetClaimsFromUserInfoEndpoint = true;
                options.ClientId = "africankitchen";
                options.ClientSecret = "secret";
                options.ResponseType = "code";

                options.TokenValidationParameters.NameClaimType = "name";
                options.TokenValidationParameters.RoleClaimType = "role";
                options.Scope.Add("africanKitchen");
                options.SaveTokens = true;

            });
        }
    }
}
