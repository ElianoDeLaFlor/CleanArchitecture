using AutoMapper;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Utility;
using CleanArchitecture.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Dto
{
    public class EnityMapperProfile:Profile
    {
        public EnityMapperProfile()
        {
            CreateMap<Immobilier, ImmobilierEntity>();
            CreateMap<ImmobilierEntity, Immobilier>();
        }
    }
}
