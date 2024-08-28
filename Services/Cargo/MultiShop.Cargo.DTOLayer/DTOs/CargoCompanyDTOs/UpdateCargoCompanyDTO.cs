namespace MultiShop.Cargo.DTOLayer.DTOs.CargoCompanyDTOs
{
    public record UpdateCargoCompanyDTO
    {
        public int CargoCompanyID { get; set; }
        public string CargoCompanyName { get; set; }
    }
}