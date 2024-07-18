namespace Assessment_18_07_2024.Models
{
    public class LoginModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class TokenResponse
    {
        public string? Token { get; set; }
    }
}
