using CleanArchitecture.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Persistence.Entities;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Persistence.Interfaces
{
    public interface ITypeImmobilierRepository:IGenericRepository<TypeImmobilier>
    {
        Task<ServiceResponse<TypeImmobilier>> GetByLabelAsync(string label);
        Task<ServiceResponse<int>> TypeImmobilierItemCount(int typeImmobilierId);
    }
}
