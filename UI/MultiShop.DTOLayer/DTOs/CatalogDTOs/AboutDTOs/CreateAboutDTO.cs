﻿namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.AboutDTOs
{
    public record CreateAboutDTO
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}