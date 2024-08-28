namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.CategoryDTOs
{
    public record ResultCategoryDTO
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
    }
}