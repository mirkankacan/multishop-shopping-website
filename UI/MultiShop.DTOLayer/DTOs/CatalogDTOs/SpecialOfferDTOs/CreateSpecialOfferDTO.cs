﻿namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.SpecialOfferDTOs
{
    public record CreateSpecialOfferDTO
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}