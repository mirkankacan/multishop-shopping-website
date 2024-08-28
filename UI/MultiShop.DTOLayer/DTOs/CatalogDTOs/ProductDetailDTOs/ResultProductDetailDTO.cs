namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDetailDTOs
{
    public record ResultProductDetailDTO
    {
        public string ProductDetailID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
        public string ProductID { get; set; }
    }
}