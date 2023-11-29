using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface ITypeImmobilierRepository:IGenericRepository<TypeImmobilier>
    {
        Task<ServiceResponse<TypeImmobilier>> GetByLabelAsync(string label);
        Task<ServiceResponse<int>> TypeImmobilierItemCount(int typeImmobilierId);
    }
}
