namespace UserService.Dtos
{
    public class AuthResponse
    {
        public bool IsAuthenticated { get; set; } // Indicates if authentication was successful
        public string Token { get; set; } // JWT token (if authenticated)
        public string ErrorMessage { get; set; } // Error message (if authentication failed)
    }
}
