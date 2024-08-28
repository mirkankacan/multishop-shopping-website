﻿namespace MultiShop.Catalog.DTOs.OfferDiscountDTOs
{
    public record ResultOfferDiscountDTO
    {
        public string OfferDiscountID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonTitle { get; set; }
    }
}