using AfricanChicken.Web.Models;

namespace AfricanChicken.Web.ServiceStore.IServices
{
    public interface IBaseService
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
