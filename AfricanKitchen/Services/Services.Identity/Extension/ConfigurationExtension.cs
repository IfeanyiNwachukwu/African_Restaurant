using Services.Identity.Initializer.Contracts;


namespace Services.Identity.Extension
{
    public static class ConfigurationExtension
    {

       
       
        public static void UseDbInitializer(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
            dbInitializer.Initialize();
        }


    }
}
