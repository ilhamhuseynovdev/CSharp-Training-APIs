namespace Identity_JWT_Auth_API.DTOs
{
    public class TokenResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
