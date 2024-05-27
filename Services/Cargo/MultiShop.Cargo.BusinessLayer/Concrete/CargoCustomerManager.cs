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
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDAL _cargoCustomerDAL;

        public CargoCustomerManager(ICargoCustomerDAL cargoCustomerDAL)
        {
            _cargoCustomerDAL = cargoCustomerDAL;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoCustomerDAL.DeleteAsync(id);
        }

        public async Task<List<CargoCustomer>> TGetAllAsync()
        {
            return await _cargoCustomerDAL.GetAllAsync();
        }

        public async Task<CargoCustomer> TGetByIdAsync(int id)
        {
            return await _cargoCustomerDAL.GetByIdAsync(id);
        }

        public async Task TCreateAsync(CargoCustomer entity)
        {
            await _cargoCustomerDAL.CreateAsync(entity);
        }

        public async Task TUpdateAsync(CargoCustomer entity)
        {
            await _cargoCustomerDAL.UpdateAsync(entity);
        }
    }
}
