using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DTOLayer.DTOs.CargoOperationDTOs
{
    public class UpdateCargoOperationDTO
    {
        public int CargoOperationID { get; set; }
        public string CargoBarcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
