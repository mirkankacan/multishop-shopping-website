﻿namespace MultiShop.Catalog.DTOs.ProductDetailDTOs
{
    public record UpdateProductDetailDTO
    {
        public string ProductDetailID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
        public string ProductID { get; set; }
    }
}