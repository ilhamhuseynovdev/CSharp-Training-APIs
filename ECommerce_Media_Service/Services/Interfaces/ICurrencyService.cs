namespace ECommerce_Media_Service.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<decimal> GetUsdRateAsync();
    }
}
