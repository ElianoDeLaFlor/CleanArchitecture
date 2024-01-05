using CleanArchitecture.Persistence.Data;
using CleanArchitecture.Persistence.Dto;
using CleanArchitecture.Persistence.Interfaces;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
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
            services.AddDbContext<DataContext>(options=> options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentityCore<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IImmobilierRepository, ImmobilierRepository>();
            return services;
        }
    }
}
