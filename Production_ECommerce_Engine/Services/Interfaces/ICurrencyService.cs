namespace Production_ECommerce_Engine.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<decimal> GetUsdRateAsync();
    }
}
