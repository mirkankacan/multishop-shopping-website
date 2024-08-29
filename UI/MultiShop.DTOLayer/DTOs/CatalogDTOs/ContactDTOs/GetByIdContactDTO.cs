﻿namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.ContactDTOs
{
    public record GetByIdContactDTO
    {
        public string ContactID { get; set; }

        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}