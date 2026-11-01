namespace Identity_JWT_Auth_API.Utilities.Result
{
    public class ServiceResult<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }

        public static ServiceResult<T> Success(T data,string message = "",int statusCode=200) 
        {
            return new ServiceResult<T> { Data = data, Message = message, StatusCode = statusCode,IsSuccess = true };
        }

        public static ServiceResult<T> Failure(string message, int statusCode)
        {
            return new ServiceResult<T> { Message = message,StatusCode = statusCode,IsSuccess=false};
        }
    }
}
