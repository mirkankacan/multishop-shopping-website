using MultiShop.DTOLayer.DTOs.CatalogDTOs.CategoryDTOs;

namespace MultiShop.DTOLayer.DTOs.CatalogDTOs.ProductDTOs
{
    public class ResultProductWithCategoryDTO
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageURL { get; set; }
        public string ProductDescription { get; set; }
        public ResultCategoryDTO Category { get; set; }
    }
}
