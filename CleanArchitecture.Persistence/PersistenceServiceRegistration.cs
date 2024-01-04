using CleanArchitecture.Persistence.Data;
using CleanArchitecture.Persistence.Dto;
using CleanArchitecture.Persistence.Interfaces;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(EnityMapperProfile));
            services.AddDbContext<DataContext>(options=> options.UseSqlServer(configuration.GetConnectionString("")));
            services.AddScoped<IImmobilierRepository, ImmobilierRepository>();
            return services;
        }
    }
}
