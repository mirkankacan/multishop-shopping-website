﻿namespace MultiShop.IdentityServer.DTOs
{
    public record UserRegisterDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
}