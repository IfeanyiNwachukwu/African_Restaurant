using AfricanKitchen.Web.Helpers;
using AfricanKitchen.Web.Models;
using AfricanKitchen.Web.ServiceStore.IServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AfricanKitchen.Web.ServiceStore.Services
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory _httpClient { get; set; }
        public ResponseDTO responseModel { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            responseModel = new ResponseDTO();
            _httpClient = httpClient;
        }
        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("MangoAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                if (!string.IsNullOrEmpty(apiRequest.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
                }
                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case StaticDetails.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDetails.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDetails.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;
            }
            catch (Exception ex)
            {

                var DTO = new ResponseDTO
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string>() { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(DTO);
                var apiResponseDTO = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDTO;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
