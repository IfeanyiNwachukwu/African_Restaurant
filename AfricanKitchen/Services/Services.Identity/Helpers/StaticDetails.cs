using Duende.IdentityServer.Models;

namespace Services.Identity.Helpers
{
    public static class StaticDetails
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(), //Initializes a new instance of OpenId
                new IdentityResources.Email(),
                new IdentityResources.Profile()

            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            { 
                new ApiScope("AfricanKitchen", "AfricanKitchen Server"),
                new ApiScope(name:"read", displayName:"Read your data."),
                new ApiScope(name:"write", displayName:"Write your data."),
                new ApiScope(name:"delete", displayName:"Delete your data."),

            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read","write","profile"}
                }
            };
            



    }
}
