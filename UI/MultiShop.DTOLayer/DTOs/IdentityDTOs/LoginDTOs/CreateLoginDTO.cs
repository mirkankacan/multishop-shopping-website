namespace MultiShop.DTOLayer.DTOs.IdentityDTOs.LoginDTOs
{
    public record CreateLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}