namespace MultiShop.Cargo.DTOLayer.DTOs.CargoOperationDTOs
{
    public record CreateCargoOperationDTO
    {
        public string CargoBarcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}