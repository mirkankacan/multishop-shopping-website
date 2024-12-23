namespace MultiShop.DTOLayer.DTOs.BasketDTOs
{
    public class BasketItemDTO
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}