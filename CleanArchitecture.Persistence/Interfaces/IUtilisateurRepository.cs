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
    public interface IUtilisateurRepository:IGenericRepository<Utilisateur>
    {
        Task<ServiceResponse<Utilisateur>> GetByPseudoAsync(string label);
    }
}
