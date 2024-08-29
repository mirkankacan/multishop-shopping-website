namespace MultiShop.DTOLayer.DTOs.IdentityDTOs.RegisterDTOs
{
    public record CreateRegisterDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool TermsAndPolicy { get; set; }
    }
}