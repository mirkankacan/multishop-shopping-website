namespace MultiShop.Cargo.DTOLayer.DTOs.CargoCustomerDTOs
{
    public record CreateCargoCustomerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool IsPremium { get; set; }
    }
}