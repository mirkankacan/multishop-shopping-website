namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureDTOs
{
    public record CreateFeatureDTO
    {
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}