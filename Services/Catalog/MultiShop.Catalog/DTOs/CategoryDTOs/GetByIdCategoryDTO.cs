namespace MultiShop.Catalog.DTOs.CategoryDTOs
{
    public record GetByIdCategoryDTO
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
    }
}