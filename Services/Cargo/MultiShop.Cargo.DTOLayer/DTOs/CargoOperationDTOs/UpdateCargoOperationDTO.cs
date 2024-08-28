namespace MultiShop.Cargo.DTOLayer.DTOs.CargoOperationDTOs
{
    public record UpdateCargoOperationDTO
    {
        public int CargoOperationID { get; set; }
        public string CargoBarcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}