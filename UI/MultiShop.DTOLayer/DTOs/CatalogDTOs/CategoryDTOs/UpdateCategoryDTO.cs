namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.CategoryDTOs
{
    public record UpdateCategoryDTO
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
    }
}