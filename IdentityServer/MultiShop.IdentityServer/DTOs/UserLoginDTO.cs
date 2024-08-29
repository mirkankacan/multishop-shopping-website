namespace MultiShop.IdentityServer.DTOs
{
    public record UserLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}