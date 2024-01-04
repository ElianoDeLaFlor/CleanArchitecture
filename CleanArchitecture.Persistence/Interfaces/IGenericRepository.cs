using CleanArchitecture.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ServiceResponse<T>> GetByIdAsync(string id);
        Task<ServiceResponse<List<T>>> GetAllAsync();
        Task<ServiceResponse<T>> CreateAsync(T entity);
        Task<ServiceResponse<T>> UpdateAsync(string id,T entity);
        Task<ServiceResponse<T>> DeleteAsync(string id);
    }
}
