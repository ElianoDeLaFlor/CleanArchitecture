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
    public interface ITypeImmobilierRepository:IGenericRepository<TypeImmobilier>
    {
        Task<ServiceResponse<TypeImmobilier>> GetByLabelAsync(string label);
        Task<ServiceResponse<int>> TypeImmobilierItemCount(int typeImmobilierId);
    }
}
