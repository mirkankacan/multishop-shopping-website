﻿namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.SpecialOfferDTOs
{
    public record UpdateSpecialOfferDTO
    {
        public string SpecialOfferID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}