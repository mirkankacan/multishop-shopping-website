namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.BrandDTOs
{
    public record CreateBrandDTO
    {
        public string BrandName { get; set; }
        public string BrandImageUrl { get; set; }
    }
}