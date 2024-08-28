namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDTOs
{
    public record UpdateProductDTO
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageURL { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryID { get; set; }
    }
}