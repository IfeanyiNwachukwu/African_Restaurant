using AfricanKitchen.Web.Models;

namespace AfricanKitchen.Web.ServiceStore.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
