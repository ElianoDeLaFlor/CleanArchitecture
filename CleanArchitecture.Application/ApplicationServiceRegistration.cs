﻿using CleanArchitecture.Application.Features;
using CleanArchitecture.Application.Features.Immobilier.Commands.CreateImmobilier;
using CleanArchitecture.Application.Features.Immobilier.Commands.UpdateImmobilier;
using CleanArchitecture.Application.Mappers;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            //services.AddAutoMapper(typeof(ApplicationAutoMapperEntryPoint).Assembly); 
            services.AddMediatR(config=>config.RegisterServicesFromAssemblies(typeof(ApplicationMediatrEntryPoint).Assembly));
            services.AddScoped<IValidator<CreateImmobilierCommand>, ImmobilierValidator>();
            services.AddScoped<IValidator<UpdateImmobilierCommand>, UpdateImmobilierValidator>();
            services.AddScoped<IJwtService,JwtService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters()
                            {
                                ValidateIssuer = true,
                                 ValidateAudience = true,
                                  ValidateLifetime = true,
                                  ValidateIssuerSigningKey = true,
                                ValidAudience = configuration["Jwt:Audience"],
                                ValidIssuer= configuration["Jwt:Issuer"],
                                IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Jwt:Key"])
                        )
                            };
                        });
            return services;
        }
    }
}
