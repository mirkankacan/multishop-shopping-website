namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDetailDTOs
{
    public record CreateProductDetailDTO
    {
        public string ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
    }
}