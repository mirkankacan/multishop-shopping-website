﻿namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductImageDTOs
{
    public record CreateProductImageDTO
    {
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string ProductID { get; set; }
    }
}