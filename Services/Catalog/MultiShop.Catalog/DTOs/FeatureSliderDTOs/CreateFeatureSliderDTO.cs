﻿namespace MultiShop.Catalog.DTOs.FeatureSliderDTOs
{
    public record CreateFeatureSliderDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}