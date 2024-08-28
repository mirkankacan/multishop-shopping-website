﻿namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.OfferDiscountDTOs
{
    public record CreateOfferDiscountDTO
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonTitle { get; set; }
    }
}