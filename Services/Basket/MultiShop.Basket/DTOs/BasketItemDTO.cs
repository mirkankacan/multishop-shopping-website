﻿namespace MultiShop.Basket.DTOs
{
    public record BasketItemDTO
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}