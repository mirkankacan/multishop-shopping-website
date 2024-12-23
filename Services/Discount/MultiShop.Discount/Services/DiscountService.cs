using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDTO createCouponDTO)
        {
            string query = "INSERT INTO Coupons(Code,Rate,IsActive,ValidDate) VALUES(@newCode, @newRate, @newIsActive, @newValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@newCode", createCouponDTO.Code);
            parameters.Add("@newRate", createCouponDTO.Rate);
            parameters.Add("@newIsActive", createCouponDTO.IsActive);
            parameters.Add("@newValidDate", createCouponDTO.ValidDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponID=@couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDTO>> GetAllCouponsAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var discounts = await connection.QueryAsync<ResultCouponDTO>(query);
                return discounts.ToList();
            }
        }

        public async Task<GetByIdCouponDTO> GetByIdCouponAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponID = @couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var discount = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDTO>(query, parameters);
                return discount;
            }
        }

        public async Task<GetByIdCouponDTO> GetCouponByCodeAsync(string code)
        {
            string query = "SELECT * FROM Coupons WHERE Code = @code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _dapperContext.CreateConnection())
            {
                var discount = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDTO>(query, parameters);
                return discount;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDTO updateCouponDTO)
        {
            string query = "UPDATE Coupons SET Code = @updatedCode, Rate = @updatedRate, IsActive = @updatedIsActive, ValidDate = @updatedValidDate WHERE CouponID = @couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", updateCouponDTO.CouponID);
            parameters.Add("@updatedCode", updateCouponDTO.Code);
            parameters.Add("@updatedRate", updateCouponDTO.Rate);
            parameters.Add("@updatedIsActive", updateCouponDTO.IsActive);
            parameters.Add("@updatedValidDate", updateCouponDTO.ValidDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}