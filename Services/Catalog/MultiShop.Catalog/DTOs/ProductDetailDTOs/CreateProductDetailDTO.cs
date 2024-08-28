namespace MultiShop.Catalog.DTOs.ProductDetailDTOs
{
    public record CreateProductDetailDTO
    {
        public string ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
    }
}