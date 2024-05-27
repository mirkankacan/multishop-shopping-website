using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDAL _cargoOperationDAL;

        public CargoOperationManager(ICargoOperationDAL cargoOperationDAL)
        {
            _cargoOperationDAL = cargoOperationDAL;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoOperationDAL.DeleteAsync(id);
        }

        public async Task<List<CargoOperation>> TGetAllAsync()
        {
            return await _cargoOperationDAL.GetAllAsync();
        }

        public async Task<CargoOperation> TGetByIdAsync(int id)
        {
            return await _cargoOperationDAL.GetByIdAsync(id);
        }

        public async Task TCreateAsync(CargoOperation entity)
        {
            await _cargoOperationDAL.CreateAsync(entity);
        }

        public async Task TUpdateAsync(CargoOperation entity)
        {
            await _cargoOperationDAL.UpdateAsync(entity);
        }
    }
}
