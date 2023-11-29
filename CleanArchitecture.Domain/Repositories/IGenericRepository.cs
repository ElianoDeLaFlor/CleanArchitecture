﻿using CleanArchitecture.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ServiceResponse<T>> GetByIdAsync(string id);
        Task<ServiceResponse<List<T>>> GetAllAsync();
        Task<ServiceResponse<T>> CreateAsync(T entity);
        Task<ServiceResponse<T>> UpdateAsync(T entity);
        Task<ServiceResponse<T>> DeleteAsync(string id);
    }
}
