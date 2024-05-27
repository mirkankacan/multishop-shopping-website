using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDAL _cargoDetailDAL;

        public CargoDetailManager(ICargoDetailDAL cargoDetailDAL)
        {
            _cargoDetailDAL = cargoDetailDAL;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoDetailDAL.DeleteAsync(id);
        }

        public async Task<List<CargoDetail>> TGetAllAsync()
        {
            return await _cargoDetailDAL.GetAllAsync();
        }

        public async Task<CargoDetail> TGetByIdAsync(int id)
        {
            return await _cargoDetailDAL.GetByIdAsync(id);
        }

        public async Task TCreateAsync(CargoDetail entity)
        {
            await _cargoDetailDAL.CreateAsync(entity);
        }

        public async Task TUpdateAsync(CargoDetail entity)
        {
            await _cargoDetailDAL.UpdateAsync(entity);
        }
    }
}
