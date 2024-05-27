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
    public class CargoCompanyManager:ICargoCompanyService
    {
        private readonly ICargoCompanyDAL _cargoCompanyDAL;

        public CargoCompanyManager(ICargoCompanyDAL cargoCompanyDAL)
        {
            _cargoCompanyDAL = cargoCompanyDAL;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoCompanyDAL.DeleteAsync(id);
        }

        public async Task<List<CargoCompany>> TGetAllAsync()
        {
            return await _cargoCompanyDAL.GetAllAsync();
        }

        public async Task<CargoCompany> TGetByIdAsync(int id)
        {
            return await _cargoCompanyDAL.GetByIdAsync(id);
        }

        public async Task TCreateAsync(CargoCompany entity)
        {
            await _cargoCompanyDAL.CreateAsync(entity);
        }

        public async Task TUpdateAsync(CargoCompany entity)
        {
            await _cargoCompanyDAL.UpdateAsync(entity);
        }
    }
}
