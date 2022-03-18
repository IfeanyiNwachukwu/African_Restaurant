using AfricanChicken.Web.Models;

namespace AfricanChicken.Web.ServiceStore.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
