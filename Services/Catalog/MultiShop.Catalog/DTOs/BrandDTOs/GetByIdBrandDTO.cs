namespace MultiShop.Catalog.DTOs.BrandDTOs
{
    public record GetByIdBrandDTO
    {
        public string BrandID { get; set; }
        public string BrandName { get; set; }
        public string BrandImageUrl { get; set; }
    }
}