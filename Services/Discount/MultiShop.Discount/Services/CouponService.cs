using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class CouponService : ICouponService
    {
        private readonly DapperContext _context;

        public CouponService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "Insert Into Coupons (Code,Rate,IsActive,ValidDate) values (@p1,@p2,@p3,@p4)";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", createCouponDto.Code);
            parameters.Add("@p2", createCouponDto.Rate);
            parameters.Add("@p3", createCouponDto.IsActive);
            parameters.Add("@p4", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task DeleteCouponAsync(int couponId)
        {
            string query = "Delete From Coupons Where CouponID=@p1";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", couponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task<List<ResultCouponDto>> GetCouponAllListAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            };
        }

        public async Task<GetCouponByIdDto> GetCouponById(int id)
        {
            string query = "Select * From Coupons Where CouponID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            var connection = _context.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<GetCouponByIdDto>(query, parameters);
            return value;
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@active, ValidDate=@date Where CouponID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("code", updateCouponDto.Code);
            parameters.Add("rate", updateCouponDto.Rate);
            parameters.Add("active", updateCouponDto.IsActive);
            parameters.Add("date", updateCouponDto.ValidDate);
            parameters.Add("id", updateCouponDto.CouponID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }
    }
}
