namespace MultiShop.Cargo.DTOLayer.DTOs.CargoDetailDTOs
{
    public record UpdateCargoDetailDTO
    {
        public int CargoDetailID { get; set; }
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyID { get; set; }
    }
}