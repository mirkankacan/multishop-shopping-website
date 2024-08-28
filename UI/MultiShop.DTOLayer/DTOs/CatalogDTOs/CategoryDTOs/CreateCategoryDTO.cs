namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.CategoryDTOs
{
    public record CreateCategoryDTO
    {
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
    }
}