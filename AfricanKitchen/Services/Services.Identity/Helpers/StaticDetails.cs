using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Services.Identity.Helpers
{
    public static class StaticDetails
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        // IdentityResource is the resource we want to protect
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(), //Initializes a new instance of OpenId
                new IdentityResources.Email(),  
                new IdentityResources.Profile()

            };
        // Scopes are identifiers for the resource that the client wants to access
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            { 
                new ApiScope("africanKitchen", "AfricanKitchen Server"),
                new ApiScope(name:"read", displayName:"Read your data."),
                new ApiScope(name:"write", displayName:"Write your data."),
                new ApiScope(name:"delete", displayName:"Delete your data."),

            };

        /// <summary>
        /// client is a piece of software that request a token from identity server
        /// </summary>
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read","write","profile"}
                },
                 new Client
                {
                    ClientId = "africanKitchen",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris={ "https://localhost:44322/signin-oidc" },
                    PostLogoutRedirectUris={"https://localhost:44322/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "africanKitchen"
                    }
                },
            };
            



    }
}
