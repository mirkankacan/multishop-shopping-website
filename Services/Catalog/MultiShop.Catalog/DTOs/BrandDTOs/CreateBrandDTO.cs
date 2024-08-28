namespace MultiShop.Catalog.DTOs.BrandDTOs
{
    public record CreateBrandDTO
    {
        public string BrandName { get; set; }
        public string BrandImageUrl { get; set; }
    }
}