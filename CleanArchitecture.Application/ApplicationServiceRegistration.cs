using CleanArchitecture.Application.Features.Immobilier.Commands.CreateImmobilier;
using CleanArchitecture.Application.Features.Immobilier.Commands.UpdateImmobilier;
using CleanArchitecture.Application.Mappers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            //services.AddAutoMapper(typeof(ApplicationAutoMapperEntryPoint).Assembly); 
            services.AddMediatR(config=>config.RegisterServicesFromAssemblies(typeof(ApplicationMediatrEntryPoint).Assembly));
            services.AddScoped<IValidator<CreateImmobilierCommand>, ImmobilierValidator>();
            services.AddScoped<IValidator<UpdateImmobilierCommand>, UpdateImmobilierValidator>();

            return services;
        }
    }
}
