namespace MultiShop.Catalog.DTOs.FeatureDTOs
{
    public record CreateFeatureDTO
    {
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}