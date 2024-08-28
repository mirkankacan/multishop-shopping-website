namespace MultiShop.Catalog.DTOs.FeatureDTOs
{
    public record ResultFeatureDTO
    {
        public string FeatureID { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}