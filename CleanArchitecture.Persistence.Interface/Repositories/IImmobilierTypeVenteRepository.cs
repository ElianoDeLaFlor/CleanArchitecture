using CleanArchitecture.Domain.Response;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Persistence.Entities;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Persistence.Interfaces;

namespace CleanArchitecture.Persistence.Repositories
{
    public interface IImmobilierTypeVenteRepository:IGenericRepository<ImmobilierTypeVente>
    {
        Task<ServiceResponse<List<ImmobilierTypeImmobilier>>> GetByImmobilierIdAsync(string id);
        Task<ServiceResponse<List<ImmobilierTypeImmobilier>>> GetByTypeImmobilierIdAsync(int id);
        Task<ServiceResponse<List<ImmobilierTypeImmobilier>>> GetImmobilierTypeImmobilierAsync(string typeImmobilierId, string immobilierId);
        Task<ServiceResponse<int>> GetByImmobilierCount(string id);
        Task<ServiceResponse<int>> DeleteByImmobilierAndTypeImmobilierAsync(int typeImmobilierId, string immobilierId);
    }
}
