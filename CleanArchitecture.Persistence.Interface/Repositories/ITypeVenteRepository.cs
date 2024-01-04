﻿using CleanArchitecture.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Persistence.Entities;
using CleanArchitecture.Persistence.Interfaces;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Persistence.Repositories
{
    public interface ITypeVenteRepository:IGenericRepository<TypeVente>
    {
        Task<ServiceResponse<TypeVente>> GetByLabelAsync(string label);
        Task<ServiceResponse<int>> TypeVenteItemCount(int typeVenteId);
    }
}
