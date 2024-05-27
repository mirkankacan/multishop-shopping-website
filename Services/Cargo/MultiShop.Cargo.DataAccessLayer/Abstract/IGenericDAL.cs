using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
