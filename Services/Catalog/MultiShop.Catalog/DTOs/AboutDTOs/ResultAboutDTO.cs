﻿namespace MultiShop.Catalog.DTOs.AboutDTOs
{
    public record ResultAboutDTO
    {
        public string AboutID { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}