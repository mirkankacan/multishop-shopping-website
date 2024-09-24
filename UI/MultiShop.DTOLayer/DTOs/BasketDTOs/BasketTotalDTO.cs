namespace MultiShop.DTOLayer.DTOs.BasketDTOs
{
    public class BasketTotalDTO
    {
        public string UserID { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDTO> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
    }
}