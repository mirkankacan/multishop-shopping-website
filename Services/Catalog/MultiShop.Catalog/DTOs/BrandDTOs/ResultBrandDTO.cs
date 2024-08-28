namespace MultiShop.Catalog.DTOs.BrandDTOs
{
    public record ResultBrandDTO
    {
        public string BrandID { get; set; }
        public string BrandName { get; set; }
        public string BrandImageUrl { get; set; }
    }
}