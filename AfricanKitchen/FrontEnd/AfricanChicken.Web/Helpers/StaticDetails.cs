namespace AfricanKitchen.Web.Helpers
{
    public static class StaticDetails
    {
        public static string ProductAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
