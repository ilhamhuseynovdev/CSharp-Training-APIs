using ECommerce_Media_Service.Models.Response;
using ECommerce_Media_Service.Services.Interfaces;

namespace ECommerce_Media_Service.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetUsdRateAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CurrencyApiResponse>("https://open.er-api.com/v6/latest/AZN");
                if (response is not null && response.Rates is not null && response.Rates.ContainsKey("USD"))
                {
                    return response.Rates["USD"];
                }

                return 0;

            }
            catch (Exception ex)
            {

                return 0.58m;
            }
        }
    }
}
