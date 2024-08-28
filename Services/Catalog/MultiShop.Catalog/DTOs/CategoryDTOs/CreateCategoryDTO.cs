namespace MultiShop.Catalog.DTOs.CategoryDTOs
{
    public record CreateCategoryDTO
    {
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
    }
}