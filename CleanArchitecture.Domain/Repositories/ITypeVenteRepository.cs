using CleanArchitecture.Domain.Response;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface ITypeVenteRepository:IGenericRepository<TypeVente>
    {
        Task<ServiceResponse<TypeVente>> GetByLabelAsync(string label);
        Task<ServiceResponse<int>> TypeVenteItemCount(int typeVenteId);
    }
}
