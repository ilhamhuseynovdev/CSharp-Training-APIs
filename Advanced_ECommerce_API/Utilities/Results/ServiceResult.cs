namespace Advanced_ECommerce_API.Utilities.Results
{
    public class ServiceResult<T>
    {
        public T Data { get; set; } //burda melumat return edirik hansi ki db-dan gelen melumat ya da true false kimi
        public string Message { get; set; } // burda da bizim return ederkenki mesajimiz success ve s. kimi
        public int StatusCode { get; set; } // neticenin status kodu 404 200 ve s.
        public bool IsSuccess { get; set; } // ugurlu olub olmamasin yoxlayiriq

        public static ServiceResult<T> Success(T data, string message = "", int statusCode = 200)
        {
            return new ServiceResult<T> { Data = data, Message = message, StatusCode = statusCode, IsSuccess = true };
        }

        public static ServiceResult<T> Failure(string message, int statusCode )
        {
            return new ServiceResult<T> { Message = message, StatusCode = statusCode, IsSuccess = false };
        }
    }
}
