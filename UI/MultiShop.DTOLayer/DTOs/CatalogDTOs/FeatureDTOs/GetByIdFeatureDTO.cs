namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.FeatureDTOs
{
    public record GetByIdFeatureDTO
    {
        public string FeatureID { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}