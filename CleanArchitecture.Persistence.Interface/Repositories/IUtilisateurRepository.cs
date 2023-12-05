using CleanArchitecture.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Persistence.Entities;

namespace CleanArchitecture.Persistence.Repositories
{
    public interface IUtilisateurRepository:IGenericRepository<UtilisateurEntity>
    {
        Task<ServiceResponse<UtilisateurEntity>> GetByPseudoAsync(string label);
    }
}
