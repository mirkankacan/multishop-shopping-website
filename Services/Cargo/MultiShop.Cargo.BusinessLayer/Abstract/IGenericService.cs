using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TCreateAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(int id);
        Task<T> TGetByIdAsync(int id);
        Task<List<T>> TGetAllAsync();
    }
}
