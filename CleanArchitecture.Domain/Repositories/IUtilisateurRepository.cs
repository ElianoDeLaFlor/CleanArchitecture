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
    public interface IUtilisateurRepository:IGenericRepository<Utilisateur>
    {
        Task<ServiceResponse<Utilisateur>> GetByPseudoAsync(string label);
    }
}
